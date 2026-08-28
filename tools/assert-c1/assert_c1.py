#!/usr/bin/env python3
"""assert-c1 — executable assertions for the C1 claims the dotnet-* skills make.

A C1 claim is a fact about the emitted `Core/`, or about the generator's emission
rules, that holds for every SDK this generator produces — independent of any
particular API definition. Those claims are what the `dotnet-*` skills assert
unconditionally, and they are what silently rot when the generator moves.

Every assertion here names the skill claim it defends, so a failure reads as
"skill X says A, the SDK says B" rather than "regex didn't match".

Usage
-----
    python assert_c1.py <sdk-root> [--surface 4.0.0] [--only PREFIX] [-v]
    python assert_c1.py <sdk-root> --json report.json

`<sdk-root>` is the root of an emitted SDK (the directory holding `Core/`,
`Api/`, `Models/`), or the generator's own `StaticCode/` directory — the
`Core/`-only assertions run against either.

Exit status is 0 when every applicable assertion passes, 1 otherwise.
"""

from __future__ import annotations

import argparse
import glob
import json
import os
import re
import sys
from dataclasses import dataclass, field

HERE = os.path.dirname(os.path.abspath(__file__))
ASSERTION_DIR = os.path.join(HERE, "assertions")

# Parts of a fixture that exist only in a fully emitted SDK. An assertion that
# needs one of these is SKIPPED — not failed — when the fixture lacks it, so the
# suite can run against the generator's Core-only template without drowning the
# real findings in noise.
FIXTURE_PARTS = {
    "api": "Api/*.cs",
    "models": "Models/**/*.cs",
    "enums": "Models/Enums/*.cs",
    "errors": "Errors/*.cs",
    "root-client": "*Client.cs",
    "di": "ServiceCollectionExtensions.cs",
}


# --------------------------------------------------------------------------
# model
# --------------------------------------------------------------------------

@dataclass
class Result:
    id: str
    ok: bool
    claim: str
    defends: str
    detail: str = ""
    skipped: bool = False
    # A skip because this assertion is not declared for the surface under test. It is
    # still a skip, but it says nothing about the SDK — unlike an Unsettleable, which
    # says the fixture could not answer a question that does apply.
    notApplicable: bool = False


@dataclass
class Ctx:
    """Everything an assertion may look at, loaded once."""
    root: str
    _cache: dict = field(default_factory=dict)

    def read(self, rel: str) -> str | None:
        if rel not in self._cache:
            p = os.path.join(self.root, rel)
            try:
                with open(p, encoding="utf-8-sig") as fh:
                    self._cache[rel] = fh.read()
            except OSError:
                self._cache[rel] = None
        return self._cache[rel]

    def files(self, pattern: str) -> list[str]:
        key = "glob:" + pattern
        if key not in self._cache:
            hits = glob.glob(os.path.join(self.root, pattern), recursive=True)
            self._cache[key] = sorted(
                os.path.relpath(h, self.root).replace("\\", "/")
                for h in hits if os.path.isfile(h)
            )
        return self._cache[key]

    def exists(self, rel: str) -> bool:
        return os.path.exists(os.path.join(self.root, rel))

    def has(self, part: str) -> bool:
        """Does this fixture contain the given per-API part?

        The generator's own StaticCode/ holds Core/ and nothing else — Api/,
        Models/, Errors/ and the root client are rendered per API definition. An
        assertion that needs one of those is unanswerable there, and saying so is
        different from saying it failed."""
        return bool(self.files(FIXTURE_PARTS[part]))


# --------------------------------------------------------------------------
# assertion kinds
# --------------------------------------------------------------------------

class Unsettleable(Exception):
    """The fixture cannot answer this assertion.

    Raised instead of returning a pass, because the two are not the same thing and
    conflating them is how a suite starts lying. An `absent` check over a glob that
    matched no files is trivially satisfied and tells you nothing — reported as `ok`
    it is worse than no assertion, since it looks like coverage. The runner turns
    this into a SKIP with the reason attached.
    """


def _files_or_unsettleable(ctx: "Ctx", a: dict) -> list[str]:
    if "glob" in a:
        hits = ctx.files(a["glob"])
        if not hits:
            raise Unsettleable("glob %r matched no files" % a["glob"])
        return hits
    if not ctx.exists(a["file"]):
        raise Unsettleable("no such file: " + a["file"])
    return [a["file"]]


def _flags(a: dict) -> int:
    f = re.MULTILINE
    if a.get("dotall"):
        f |= re.DOTALL
    if a.get("ignorecase"):
        f |= re.IGNORECASE
    return f


def k_file(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """The named file exists."""
    return ctx.exists(a["file"]), a["file"]


def k_no_file(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """The named file does NOT exist. Used to pin a surface boundary."""
    return not ctx.exists(a["file"]), a["file"]


def k_present(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """A pattern matches at least once in the named file."""
    src = ctx.read(a["file"])
    if src is None:
        return False, "file not found: " + a["file"]
    m = re.search(a["pattern"], src, _flags(a))
    if m:
        return True, "matched at offset %d" % m.start()
    return False, "no match for /%s/ in %s" % (a["pattern"], a["file"])


def k_absent(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """A pattern matches nowhere in the named file (or glob)."""
    targets = _files_or_unsettleable(ctx, a)
    hits = []
    for rel in targets:
        src = ctx.read(rel)
        if src and re.search(a["pattern"], src, _flags(a)):
            hits.append(rel)
    if hits:
        return False, "found in %d file(s): %s" % (len(hits), ", ".join(hits[:4]))
    return True, "absent across %d file(s)" % len(targets)


def k_count(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """A pattern matches exactly `expect` times across a glob."""
    total = 0
    for rel in _files_or_unsettleable(ctx, a):
        src = ctx.read(rel)
        if src:
            total += len(re.findall(a["pattern"], src, _flags(a)))
    want = a["expect"]
    if isinstance(want, list):          # inclusive [lo, hi]
        ok = want[0] <= total <= want[1]
        return ok, "found %d, expected %d..%d" % (total, want[0], want[1])
    return total == want, "found %d, expected %d" % (total, want)


def k_at_least(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """A pattern matches at least `expect` times across a glob.

    Use where the exact count is API-dependent but a floor proves the shape is
    emitted at all — a zero here means the fixture cannot settle the claim.
    """
    total = 0
    for rel in _files_or_unsettleable(ctx, a):
        src = ctx.read(rel)
        if src:
            total += len(re.findall(a["pattern"], src, _flags(a)))
    return total >= a["expect"], "found %d, expected >= %d" % (total, a["expect"])


def k_ordered(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """Two patterns both match, and the first matches before the second.

    This is how a syntactic claim about *structure* gets pinned — e.g. that the
    Retry-After lookup is consulted before the computed backoff.
    """
    src = ctx.read(a["file"])
    if src is None:
        return False, "file not found: " + a["file"]
    f = _flags(a)
    m1 = re.search(a["first"], src, f)
    m2 = re.search(a["then"], src, f)
    if not m1:
        return False, "first pattern /%s/ not found" % a["first"]
    if not m2:
        return False, "second pattern /%s/ not found" % a["then"]
    if m1.start() < m2.start():
        return True, "ordered: %d < %d" % (m1.start(), m2.start())
    return False, "out of order: first at %d, then at %d" % (m1.start(), m2.start())


PROBES: dict = {}


def probe(name):
    def deco(fn):
        PROBES[name] = fn
        return fn
    return deco


def k_probe(ctx: Ctx, a: dict) -> tuple[bool, str]:
    """Escape hatch for structural checks a regex cannot express honestly."""
    fn = PROBES.get(a["probe"])
    if fn is None:
        return False, "unknown probe: " + a["probe"]
    return fn(ctx, a)


KINDS = {
    "file": k_file,
    "no-file": k_no_file,
    "present": k_present,
    "absent": k_absent,
    "count": k_count,
    "at-least": k_at_least,
    "ordered": k_ordered,
    "probe": k_probe,
}


# --------------------------------------------------------------------------
# probes
# --------------------------------------------------------------------------

OPERATION_RE = re.compile(
    r"^    public\s+(?:async\s+)?[\w<>?,\.\[\]\s]+?\s+(\w+)\s*\(", re.M)


def _operation_signatures(ctx: Ctx):
    """Yield (file, name, parameter-text) for every public operation in Api/."""
    for rel in ctx.files("Api/*.cs"):
        src = ctx.read(rel) or ""
        for m in OPERATION_RE.finditer(src):
            depth, i = 1, m.end()
            while i < len(src) and depth:
                if src[i] == "(":
                    depth += 1
                elif src[i] == ")":
                    depth -= 1
                i += 1
            yield rel, m.group(1), src[m.end():i - 1]


@probe("operations-carry-requestoptions-before-ct")
def _p_requestoptions(ctx: Ctx, a: dict):
    """Every generated operation ends `RequestOptions? requestOptions = null,
    CancellationToken ct = default` — in that order.

    This is the claim a positional call is built from; get the order wrong and
    the call mis-binds. An API-agnostic template cannot state it as a value, so
    it has to be checked structurally against every emitted operation."""
    total, bad = 0, []
    for rel, name, params in _operation_signatures(ctx):
        total += 1
        flat = " ".join(params.split())
        if not re.search(
                r"RequestOptions\?\s+requestOptions\s*=\s*null\s*,\s*"
                r"CancellationToken\s+ct\s*=\s*default\s*$", flat):
            bad.append("%s.%s" % (rel.split("/")[-1][:-3], name))
    if total == 0:
        return False, "no operations found under Api/ — wrong fixture?"
    if bad:
        return False, "%d of %d operations do not end with requestOptions then ct: %s" % (
            len(bad), total, ", ".join(bad[:5]))
    return True, "all %d operations" % total


def _execute_blocks(ctx: Ctx):
    """Yield (file, argument-text) for every `_rawClient.Execute*` call in Api/."""
    for rel in ctx.files("Api/*.cs"):
        src = ctx.read(rel) or ""
        for m in re.finditer(r"_rawClient\.Execute\w*\(", src):
            depth, i = 1, m.end()
            while i < len(src) and depth:
                if src[i] == "(":
                    depth += 1
                elif src[i] == ")":
                    depth -= 1
                i += 1
            yield rel, src[m.end():i - 1]


_IDEM_HEADER = 'HeaderParam("Idempotency-Key"'
_IDEM_INJECTED = 'HeaderParam("Idempotency-Key", Guid.NewGuid())'
# Deliberately NOT a negative lookahead after `,\s*`: `\s*` matches zero characters and
# the lookahead then reads the space rather than the value, so `(?!Guid\.NewGuid)`
# succeeds on the injected form too and every operation reads as spec-declared. Presence
# minus the injected literal has no such hole.


def _operations_with_blocks(ctx: Ctx):
    """Yield (file, method-name, parameter-text, Execute-argument-text) per operation.

    The idempotency probe needs the SIGNATURE as well as the call, because the claim it
    defends is about where the header's value comes from — and "a parameter feeds it" is
    only answerable against that operation's own parameter list."""
    for rel in ctx.files("Api/*.cs"):
        src = ctx.read(rel) or ""
        for m in re.finditer(r"\bpublic\s+[\w<>,\[\]\?\.\s]+?\s+(\w+)\s*\(", src):
            depth, i = 1, m.end()
            while i < len(src) and depth:
                if src[i] == "(":
                    depth += 1
                elif src[i] == ")":
                    depth -= 1
                i += 1
            # No window cap: an operation with a long parameter list and a long form body
            # can run past any fixed budget, and a truncated block silently loses the very
            # arguments this probe reads — a parameter would read as unreferenced.
            params, rest = src[m.end():i - 1], src[i:]
            c = rest.find("_rawClient.Execute")
            if c < 0 or "\n    public " in rest[:c]:
                continue
            j = rest.index("(", c) + 1
            depth, k = 1, j
            while k < len(rest) and depth:
                if rest[k] == "(":
                    depth += 1
                elif rest[k] == ")":
                    depth -= 1
                k += 1
            yield rel, m.group(1), params, rest[j:k - 1]


_IDEM_VALUE = re.compile(r'HeaderParam\(\s*"Idempotency-Key"\s*,\s*((?:[^()]|\([^()]*\))*)\)')


@probe("idempotency-key-on-every-non-get")
def _p_idempotency_key(ctx: Ctx, a: dict):
    """Every non-GET operation sends an `Idempotency-Key` header and no GET does; its value
    is either a generator-injected `Guid.NewGuid()` or a parameter of that same operation,
    and NEVER a GUID on an operation whose own signature offers an idempotency parameter.

    The skills tell the reader that seeing this header proves nothing — only the *source*
    of its value does. Three distinct regressions would each falsify that, so all three are
    checked rather than counted:

      * the header disappears from a write, or appears on a read;
      * the value becomes a CONSTANT — every call on that operation would then dedupe
        against the first one ever made, which is worse than no key at all;
      * the generator starts injecting a GUID *over* a spec-declared idempotency parameter,
        so the caller's key is silently discarded and the write only looks deduplicated.

    Counting injected-vs-declared without asserting on it, as an earlier version of this
    probe did, leaves all three green."""
    get_with, nonget_without, bad_value, overridden = [], [], [], []
    total = injected = declared = 0
    for rel, name, params, blk in _operations_with_blocks(ctx):
        total += 1
        mt = re.search(r"HttpMethod\.(\w+)|new HttpMethod\(\"(\w+)\"\)", blk)
        meth = ((mt.group(1) or mt.group(2)) if mt else "?").upper()
        where = "%s.%s" % (rel.split("/")[-1][:-3], name)
        vm = _IDEM_VALUE.search(blk)
        if meth == "GET":
            if vm:
                get_with.append(where)
            continue
        if not vm:
            nonget_without.append(where)
            continue
        value = vm.group(1).strip()
        param_names = set(re.findall(r"(\w+)\s*(?:,|$)", params))
        if value == "Guid.NewGuid()":
            injected += 1
            # A spec-declared idempotency parameter the generator DISCARDS is the expensive
            # failure: the caller passes a key and it never ships. Declaring one alongside an
            # injected header is NOT that — Twilio's payment operations route the caller's
            # value into the form body and the header is simply a separate, inert thing. So
            # flag only a parameter that reaches the request nowhere at all.
            for p in param_names:
                if "idempotency" in p.lower() and p not in blk:
                    overridden.append("%s (param %s unreferenced)" % (where, p))
        elif re.fullmatch(r"[A-Za-z_]\w*", value) and value in param_names:
            declared += 1
        else:
            bad_value.append("%s -> %s" % (where, value[:40]))
    if total == 0:
        return False, "no operations with _rawClient.Execute under Api/ — wrong fixture?"
    if get_with:
        return False, "%d GET operation(s) carry an Idempotency-Key: %s" % (
            len(get_with), ", ".join(sorted(get_with)[:4]))
    if nonget_without:
        return False, "%d non-GET operation(s) carry none: %s" % (
            len(nonget_without), ", ".join(sorted(nonget_without)[:4]))
    if bad_value:
        return False, ("%d operation(s) set Idempotency-Key to something that is neither "
                       "Guid.NewGuid() nor one of their own parameters — a constant key "
                       "dedupes every call against the first: %s") % (
            len(bad_value), ", ".join(sorted(bad_value)[:4]))
    if overridden:
        return False, ("%d operation(s) declare an idempotency parameter but ship an injected "
                       "GUID instead, so the caller's key never reaches the provider: %s") % (
            len(overridden), ", ".join(sorted(overridden)[:4]))
    return True, "%d operations — %d injected, %d fed by a parameter, 0 on a GET, 0 constant" % (
        total, injected, declared)


_PAN_MODELS = {
    "ApplePayTokenizedCard", "CardRequest", "GooglePayCard", "NetworkToken",
    "PaymentTokenRequestCard", "SetupTokenRequestCard", "SubscriptionCardRequest",
}


@probe("raw-pan-models-are-the-documented-set")
def _p_pan_models(ctx: Ctx, a: dict):
    """The models carrying a raw card `number` are exactly the set the
    paypal-getting-started card-data section names, and no *response* model is
    among them.

    This one guards a hand-written list, which is the kind of fact this whole
    suite exists to stop trusting. The section tells a reader that request bodies
    disclose a PAN while response bodies carry only `last_digits` — safe advice
    only while that asymmetry holds. If a regenerated spec adds `number` to a
    response model, or adds an eighth card model nobody documented, the guidance
    silently under-warns on a PCI boundary.

    Skips on a fixture with no card models at all: absence of cards settles
    nothing about an API that has them."""
    # This allow-list is paypal-sdk's, enumerated from ITS API definition. Every other
    # assertion in this suite is SDK-agnostic; this one is not, and on a third SDK with a
    # different set of card models it would fail for being a different API rather than for
    # any drift. Scope it to the SDK it documents and say so, rather than failing loudly
    # somewhere it was never meant to run.
    ns = ""
    for rel in ctx.files("Core/**/*.cs"):
        m = re.search(r"^namespace\s+([\w.]+)", ctx.read(rel) or "", re.M)
        if m:
            ns = m.group(1).split(".")[0]
            break
    if ns and ns != "PayPalServerSdk":
        raise Unsettleable(
            "the raw-PAN allow-list is paypal-sdk's; this fixture's root namespace is %s" % ns)
    found = set()
    for rel in ctx.files("Models/*.cs"):
        src = ctx.read(rel) or ""
        if '[JsonPropertyName("number")]' in src:
            found.add(rel.split("/")[-1][:-3])
    if not found:
        raise Unsettleable("no model carries a raw `number` field in this fixture")
    extra, missing = sorted(found - _PAN_MODELS), sorted(_PAN_MODELS - found)
    responses = sorted(m for m in found if m.endswith("Response"))
    if responses:
        return False, "response model(s) now carry a raw `number`: %s" % ", ".join(responses)
    if extra or missing:
        return False, "documented set is stale — undocumented: %s | documented but gone: %s" % (
            ", ".join(extra) or "none", ", ".join(missing) or "none")
    return True, "%d models, exactly the documented set, none of them a response" % len(found)


@probe("signature-verifier-has-no-callers")
def _p_verifier_unused(ctx: Ctx, a: dict):
    """`SignatureVerifier` is referenced nowhere but its own file.

    The skills tell a reader that inbound-webhook signature verification is
    theirs to write. That is only true while nothing generated calls the
    verifier — an `internal` type is exactly what you would expect generated
    code to use, so the day a concrete parser starts calling it, the guidance
    is telling people to hand-roll a check the SDK already performs."""
    own, callers = None, []
    for rel in ctx.files("**/*.cs"):
        if rel.endswith("SignatureVerifier.cs"):
            own = rel
            continue
        if "SignatureVerifier" in (ctx.read(rel) or ""):
            callers.append(rel)
    if own is None:
        raise Unsettleable("no SignatureVerifier.cs in this fixture")
    if callers:
        return False, "%d file(s) now reference SignatureVerifier: %s" % (
            len(callers), ", ".join(sorted(callers)[:5]))
    return True, "referenced only by %s" % own


_OAUTH_CREDS = re.compile(
    r"public\s+(OAuth2\w*Credentials)\?\s+(\w+)\s*\{\s*get;\s*set;\s*\}")


@probe("oauth2-credentials-have-a-token-strategy-sibling")
def _p_oauth_strategy_sibling(ctx: Ctx, a: dict):
    """Every OAuth2 credentials property on the options class has a
    `{Property}TokenStrategy` sibling typed over that same credentials type.

    Written as a probe rather than an `absent` regex because the regex form asked
    "is there a credentials property WITHOUT a sibling" — which is trivially false,
    and therefore green, on an SDK that declares no OAuth2 property at all. Twilio
    is exactly that SDK (Basic auth only), so the claim reported `ok` there while
    checking nothing. An SDK with no OAuth2 scheme cannot settle a claim about
    OAuth2 schemes; it skips."""
    opts = [r for r in ctx.files("*ClientOptions.cs")]
    if not opts:
        raise Unsettleable("no *ClientOptions.cs in this fixture")
    pairs, missing = [], []
    for rel in opts:
        src = ctx.read(rel) or ""
        for m in _OAUTH_CREDS.finditer(src):
            cred, name = m.group(1), m.group(2)
            pairs.append(name)
            want = re.compile(
                r"IOAuth2(?:Refreshable)?TokenStrategy<%s>\?\s+%sTokenStrategy\b"
                % (re.escape(cred), re.escape(name)))
            if not want.search(src):
                missing.append("%s (%s)" % (name, cred))
    if not pairs:
        raise Unsettleable(
            "this SDK's options class declares no OAuth2 credentials property — nothing "
            "to pair a token strategy with")
    if missing:
        return False, "%d OAuth2 credentials property(ies) with no matching TokenStrategy sibling: %s" % (
            len(missing), ", ".join(missing))
    return True, "%d OAuth2 credentials property(ies), each with its TokenStrategy sibling" % len(pairs)


@probe("no-converter-on-model-property")
def _p_no_model_converter(ctx: Ctx, a: dict):
    """No model property carries a [JsonConverter], other than the generated
    enum and union converters applied at type level.

    This is what makes "a DateTimeOffset property round-trips as System.Text.Json's
    default" true: the four date converters exist but are never attached here."""
    offenders = []
    for rel in ctx.files("Models/**/*.cs"):
        src = ctx.read(rel) or ""
        for m in re.finditer(r"^\s*\[JsonConverter\(typeof\(([^)]+)\)\)\]\s*$\n(\s*)(.*)$",
                             src, re.M):
            conv, _, nextline = m.group(1), m.group(2), m.group(3)
            # type-level converters sit immediately above a type declaration
            if re.match(r"\s*(public|internal|file)\s+.*\b(record|class|struct)\b", nextline):
                continue
            offenders.append("%s: %s" % (rel, conv))
    if offenders:
        return False, "%d property-level converter(s): %s" % (
            len(offenders), "; ".join(offenders[:4]))
    files = ctx.files("Models/**/*.cs")
    if not files:
        raise Unsettleable("no model files to inspect")
    # A fixture with models but no DateTimeOffset property cannot exercise this: the
    # claim is about what a date property does NOT carry, so with no date property the
    # absence proves nothing.
    dated = [f for f in files if re.search(r"\bDateTimeOffset\??\s+\w+\s*\{", ctx.read(f) or "")]
    if not dated:
        raise Unsettleable("no DateTimeOffset model property in this fixture — the claim is "
                           "about what such a property does not carry")
    return True, "no property-level converters across %d model file(s) (%d with a date property)" % (
        len(files), len(dated))


@probe("jsonignore-only-on-defaultless-optionals")
def _p_jsonignore(ctx: Ctx, a: dict):
    """`[JsonIgnore(WhenWritingNull)]` is emitted only on optional properties
    that have no initializer; one with a default is always serialized.

    The skills used to say "leaving one unset omits it from the JSON", which is
    false for every defaulted property."""
    # Line-based on purpose: the equivalent single regex needs a nested quantifier
    # over the attribute block, which backtracks catastrophically on a large
    # Models/ tree. Attribute blocks are line-structured, so read them that way.
    prop_re = re.compile(r"^\s*public\s+[\w<>?\[\]\.,\s]+\s+\w+\s*\{\s*get;\s*init;\s*\}(\s*=)?")
    with_default_and_ignore, defaulted = [], 0
    for rel in ctx.files("Models/**/*.cs"):
        src = ctx.read(rel) or ""
        saw_ignore = False
        for line in src.splitlines():
            stripped = line.strip()
            if stripped.startswith("["):
                if "JsonIgnoreCondition.WhenWritingNull" in stripped:
                    saw_ignore = True
                continue
            m = prop_re.match(line)
            if m:
                has_default = bool(m.group(1))
                if has_default:
                    defaulted += 1
                    if saw_ignore:
                        with_default_and_ignore.append("%s: %s" % (rel, stripped[:60]))
            if stripped:                       # any non-attribute line ends the block
                saw_ignore = False
    if with_default_and_ignore:
        return False, "%d defaulted propert(y|ies) also carry JsonIgnore: %s" % (
            len(with_default_and_ignore), ", ".join(with_default_and_ignore[:3]))
    if defaulted == 0:
        raise Unsettleable("no defaulted optional properties in this fixture — "
                           "nothing here can exercise the claim")
    return True, "%d defaulted properties, none carrying JsonIgnore" % defaulted


@probe("generated-enums-are-sealed-records")
def _p_enum_records(ctx: Ctx, a: dict):
    """Generated enums are `sealed record`s, which is *why* `ToString()` returns
    the record debug form instead of the wire value: the synthesised record
    ToString shadows TypedEnum's override."""
    files = ctx.files("Models/Enums/*.cs") or ctx.files("Models/**/*Enum*.cs")
    if not files:
        return False, "no enum files found — wrong fixture?"
    bad = []
    for rel in files:
        src = ctx.read(rel) or ""
        if re.search(r"public\s+sealed\s+record\s+\w+\s*:\s*(String|Int)Enum<", src):
            continue
        if re.search(r":\s*(String|Int)Enum<", src):
            bad.append(rel)
    if bad:
        return False, "%d enum(s) not declared `public sealed record`: %s" % (
            len(bad), ", ".join(bad[:3]))
    return True, "%d enum file(s), all sealed records" % len(files)


@probe("no-client-side-validation")
def _p_no_validation(ctx: Ctx, a: dict):
    """Nothing in the SDK evaluates the DataAnnotations attributes it emits.

    The attributes are the provider's documented contract, not a client guard —
    and an integration that assumes otherwise sends the request anyway."""
    hits = []
    for rel in ctx.files("**/*.cs"):
        src = ctx.read(rel) or ""
        if re.search(r"\bValidator\.(TryValidateObject|ValidateObject)\b|\bValidationContext\b", src):
            hits.append(rel)
    if hits:
        return False, "validation is invoked in: " + ", ".join(hits[:4])
    attrs = 0
    for rel in ctx.files("Models/**/*.cs"):
        src = ctx.read(rel) or ""
        attrs += len(re.findall(r"^\s*\[(StringLength|RegularExpression|MaxLength|MinLength|Range)\(",
                                src, re.M))
    return True, "%d validation attribute(s) emitted, 0 evaluated" % attrs


@probe("client-ctor-is-not-a-thin-wrapper")
def _p_client_ctor(ctx: Ctx, a: dict):
    """The generated client's constructor eagerly builds the resilience pipelines,
    the logger and the auth schemes — so the client owns state (for OAuth2, the
    token cache) and is not a stateless wrapper you can rebuild per request."""
    roots = [f for f in ctx.files("*Client.cs") if "Options" not in f]
    if not roots:
        return False, "no root *Client.cs found — wrong fixture?"
    want = {
        "resilience pipeline": r"new\s+ResiliencePipelineFactory\(",
        "logger": r"new\s+HttpLogger\(",
        "auth schemes": r"new\s+AuthSchemes\(",
    }
    src = ctx.read(roots[0]) or ""
    missing = [name for name, pat in want.items() if not re.search(pat, src)]
    if missing:
        return False, "%s does not build: %s" % (roots[0], ", ".join(missing))
    return True, "%s builds pipelines, logger and auth schemes in its ctor" % roots[0]


# --------------------------------------------------------------------------
# runner
# --------------------------------------------------------------------------

def load_assertions(only: str | None) -> list[dict]:
    out = []
    for path in sorted(glob.glob(os.path.join(ASSERTION_DIR, "*.json"))):
        with open(path, encoding="utf-8") as fh:
            doc = json.load(fh)
        for a in doc["assertions"]:
            a.setdefault("group", doc.get("group", os.path.basename(path)[:-5]))
            if only and not a["id"].startswith(only):
                continue
            out.append(a)
    return out


def run(root: str, surface: str, only: str | None) -> list[Result]:
    ctx = Ctx(root)
    results = []
    for a in load_assertions(only):
        surfaces = a.get("surfaces")
        if surfaces and surface not in surfaces:
            results.append(Result(a["id"], True, a["claim"], a.get("defends", ""),
                                  "not applicable to surface " + surface,
                                  skipped=True, notApplicable=True))
            continue
        missing = [p for p in a.get("requires", []) if not ctx.has(p)]
        if missing:
            results.append(Result(
                a["id"], True, a["claim"], a.get("defends", ""),
                "fixture has no %s — this claim is UNSETTLED here, not confirmed"
                % ", ".join(missing), skipped=True))
            continue
        fn = KINDS.get(a["kind"])
        if fn is None:
            results.append(Result(a["id"], False, a["claim"], a.get("defends", ""),
                                  "unknown assertion kind: " + a["kind"]))
            continue
        try:
            ok, detail = fn(ctx, a)
        except Unsettleable as exc:
            results.append(Result(a["id"], True, a["claim"], a.get("defends", ""),
                                  "UNSETTLED here (%s) — not confirmed" % exc, skipped=True))
            continue
        except Exception as exc:                      # a broken assertion is a failure
            ok, detail = False, "%s: %s" % (type(exc).__name__, exc)
        results.append(Result(a["id"], ok, a["claim"], a.get("defends", ""), detail))
    return results


def main() -> int:
    # Claims and defends lines carry em-dashes, arrows and section marks. On a Windows
    # console that defaults to cp1252 those raise UnicodeEncodeError mid-report, so the
    # runner dies on its own output and reports nothing about the SDK. Degrade the
    # character instead of the run.
    for stream in (sys.stdout, sys.stderr):
        try:
            stream.reconfigure(encoding="utf-8", errors="replace")
        except (AttributeError, ValueError):
            pass
    ap = argparse.ArgumentParser(description=__doc__,
                                 formatter_class=argparse.RawDescriptionHelpFormatter)
    ap.add_argument("sdk_root")
    ap.add_argument("--surface", default="4.0.0",
                    help="core surface the fixture is expected to be: 4.0.0 (paypal-sdk, twilio-sdk) or "
                         "pre-4.0.0 (maxio-sdk). Assertions that declare a `surfaces` key run only on "
                         "the surfaces they name; everything else runs everywhere. The filtering is "
                         "reported separately as `n/a on this surface` rather than folded into the "
                         "skip count, so a narrowed run cannot be mistaken for a full one. The general "
                         "suite is still NOT filtered by surface — it runs in full against every "
                         "fixture, and the ~100 assertions that cannot hold on pre-4.0.0 are pinned in "
                         "maxio-pre-4.0.0-drift.txt via --expect-failures. Failing loudly against a "
                         "recorded baseline beats silently running less.")
    ap.add_argument("--only", help="run only assertions whose id starts with this prefix")
    ap.add_argument("--json", help="write a machine-readable report here")
    ap.add_argument("--expect-failures", metavar="FILE",
                    help="a file of assertion ids that are KNOWN to fail on this fixture, one per "
                         "line (# comments allowed). Succeeds only when the failing set matches it "
                         "exactly. Use for a fixture that is deliberately a different surface — the "
                         "generator template, say — so the job goes red when the drift CHANGES "
                         "rather than sitting red forever and teaching everyone to ignore it.")
    ap.add_argument("-v", "--verbose", action="store_true", help="also print passes")
    args = ap.parse_args()

    if not os.path.isdir(args.sdk_root):
        print("not a directory: " + args.sdk_root, file=sys.stderr)
        return 2

    results = run(args.sdk_root, args.surface, args.only)
    failed = [r for r in results if not r.ok]
    skipped = [r for r in results if r.skipped]
    # Split for the summary: unsettled is a gap in what this run proved, not-applicable is not.
    notapplicable = [r for r in skipped if r.notApplicable]
    unsettled = [r for r in skipped if not r.notApplicable]

    for r in results:
        if r.ok and not args.verbose:
            continue
        mark = ("n/a " if r.notApplicable else "SKIP") if r.skipped \
            else ("ok  " if r.ok else "FAIL")
        print("%s %s" % (mark, r.id))
        if not r.ok or args.verbose:
            print("       claim: %s" % r.claim)
            if r.defends:
                print("     defends: %s" % r.defends)
            print("      result: %s" % r.detail)

    print()
    summary = "%d assertions: %d passed, %d failed, %d unsettled" % (
        len(results), len(results) - len(failed) - len(skipped), len(failed), len(unsettled))
    if notapplicable:
        summary += ", %d n/a on this surface" % len(notapplicable)
    print(summary + "   [%s, surface %s]" % (args.sdk_root, args.surface))

    if args.json:
        with open(args.json, "w", encoding="utf-8") as fh:
            json.dump({
                "sdkRoot": args.sdk_root,
                "surface": args.surface,
                "total": len(results),
                "failed": len(failed),
                "skipped": len(skipped),
                "unsettled": len(unsettled),
                "notApplicable": len(notapplicable),
                "results": [r.__dict__ for r in results],
            }, fh, indent=2)
        print("report: " + args.json)

    if args.expect_failures:
        with open(args.expect_failures, encoding="utf-8") as fh:
            expected = {ln.split("#")[0].strip() for ln in fh}
        expected.discard("")
        actual = {r.id for r in failed}
        # A baselined failure that becomes SKIPPED has not been fixed — the fixture just
        # stopped being able to answer it (a glob that no longer matches, say). Comparing
        # only the failing set would let that pass as "resolved", which is precisely the
        # kind of generator change this job exists to catch.
        # Only an UNSETTLED baselined failure is the disguised-regression case. One that went
        # not-applicable was filtered on purpose and belongs in `gone`, to be removed from the
        # baseline like any other resolved entry.
        vanished = {r.id for r in unsettled} & expected
        new, gone = sorted(actual - expected), sorted(expected - actual - vanished)
        print()
        if not new and not gone and not vanished:
            print("drift unchanged: %d known failure(s), exactly as recorded in %s"
                  % (len(expected), os.path.basename(args.expect_failures)))
            return 0
        if new:
            print("NEW drift — these were not failing before:")
            for i in new:
                print("   + " + i)
        if gone:
            print("drift RESOLVED — remove these from the baseline:")
            for i in gone:
                print("   - " + i)
        if vanished:
            print("BASELINED FAILURE WENT UNSETTLEABLE — not fixed, just no longer checkable:")
            for i in sorted(vanished):
                print("   ? " + i)
        return 1

    return 1 if failed else 0


if __name__ == "__main__":
    sys.exit(main())
