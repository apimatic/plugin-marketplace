# assert-c1

Executable assertions for the **C1** claims the `dotnet-*` skills make.

A **C1 claim** is a fact about the emitted `Core/`, or about the generator's emission
rules, that holds for every SDK this generator produces — independent of any particular
API definition. Those are exactly the claims the `dotnet-*` skills state unconditionally,
and exactly the claims that rot silently when the generator moves.

## Why this exists

The `dotnet-*` skills were reviewed adversarially four times before this suite existed.
Every round found errors the previous round's edits had introduced, and the rounds that
*compiled code* found things three rounds of careful reading had missed. Ten distinct
false claims about the runtime shipped in five plugins for months — including one that
told readers a `POST` **is** resent on a transport fault when the opposite is true.

Review does not scale to that, and it certainly does not scale to verifying whatever the
generator emits next. This does.

## Running it

```
python assert_c1.py <sdk-root>              # a fully emitted SDK
python assert_c1.py <sdk-root> -v           # show passes too
python assert_c1.py <sdk-root> --only retry # one group
python assert_c1.py <sdk-root> --json out.json
```

`<sdk-root>` is the directory holding `Core/` — an emitted SDK, or the generator's own
`StaticCode/`. Exit status is 0 when everything applicable passes.

### Skipped is not passed

The generator template has no `Api/`, `Models/`, `Errors/` or DI extension: those are
rendered per API definition. Assertions that need them are **skipped**, not failed, and the
skip message says the claim is *unsettled here*, not confirmed.

The same rule applies whenever the fixture cannot answer: an `absent`, `count` or `at-least`
whose glob matches no file, or a check against a file that isn't there. Those are trivially
satisfied and tell you nothing, so they skip rather than pass. Getting this wrong is not
hypothetical — before it was enforced, 35 assertions reported `ok` against a directory
containing a single meaningless `.cs` file, and the twelve union assertions reported `ok`
against an SDK with no unions in it.

That is the same category error the skills themselves kept making: stating a fact
unconditionally when the sample could not settle it. A suite that quietly passes on a
fixture that cannot answer the question is worse than no suite, because it looks like
coverage.

## What a failure means

Every assertion names the skill claim it defends, so a failure reads as a contradiction
between two documents rather than a regex miss:

```
FAIL retry.predicate.method-filter-gates-both-arms
       claim: The HTTP-method filter is a top-level && ABOVE both retry arms, so a POST
              is never resent on any trigger.
     defends: dotnet-configuration-resilience § Notes, first bullet
      result: no match for /methodsToRetry\.Contains\(method\)\s*&&\s*args\.Outcome\s+switch/
```

That is a decision, not a chore: either the SDK changed and the skill must follow, or the
assertion was over-fitted to an implementation detail and should be loosened to the claim.
Prefer the second reading only when the *claim* still holds — `retry.eligibility.by-request-type`
was loosened from `_params` to `_\w+` for exactly that reason, because a later template
renamed the field without changing the behaviour.

## The two tiers

**Static** (`assert_c1.py`, this directory) — values, shapes, syntax and structure, read
straight from source. No toolchain, runs in under a second, catches most drift.

**Behavioural** (`behaviour/`) — a console checker that references the SDK and *runs* it.
Needed for the claims static analysis cannot reach: how many times a stub handler is
called, what `ToString()` actually returns, whether a transient client refetches a token.
Three of the worst defects found in this codebase were only visible from a compiled probe.

Unlike the static tier, this one is **not SDK-agnostic**: it names `PayPalServerSdk` types
directly, so it runs against that SDK (or a regeneration of it) and no other. Pointing it at
a different SDK means editing `Program.cs`. That is a deliberate trade — the compile-time
binding means a renamed member fails the build, which is a signal the static tier cannot
produce — but it does mean the static tier is the one that generalises.

## Proving the suite still has teeth

```
python mutation_test.py <sdk-root>
```

A suite that passes everywhere proves nothing, and the failure mode is quiet: a regex gets
loosened during a refactor until it matches anything, and the report stays green while the
claim rots. `mutation_test.py` copies the fixture, breaks one documented fact at a time —
the retry default, the method filter, the redaction direction, the expiry buffer — and
checks that something notices. Twenty-three mutations, twenty-three caught, no false positives. Two of them
target `Api/` rather than `Core/`, because the idempotency claim is about an emission rule and the emitted
operations are the only place it is visible.

Run it after any change that loosens a pattern. A `MISS` means either the claim has no
assertion or the one defending it has stopped discriminating.

### What does NOT belong in the behavioural tier

Only checks that need the SDK *running*. A check that exercises a BCL behaviour and never
touches generated code proves nothing about the SDK and costs a build — the date-format check
was exactly that (it serialized an anonymous type through `System.Text.Json` and asserted
ISO-8601, which is a fact about STJ). The SDK-side half of that claim — that no converter is
attached to a model property — is a static probe, and it now skips honestly on a fixture with
no date property rather than passing.

## Adding an assertion

Assertions live in `assertions/*.json`, grouped and numbered so the surface
discriminators run first. Each one is:

```json
{
  "id": "retry.defaults.max-retries",
  "kind": "present",
  "file": "Core/Configuration/RetryOptions.cs",
  "pattern": "MaxRetries\\s*=\\s*3\\s*,",
  "claim": "MaxRetries defaults to 3, i.e. up to 4 attempts.",
  "defends": "dotnet-configuration-resilience § defaults table"
}
```

(No `requires` on that one: it reads a file under `Core/`, which every fixture has. Adding a
spurious `requires` is not harmless — it makes the assertion SKIP on the generator template,
silently removing it from the one run that catches drift.)

`claim` and `defends` are not documentation — they are what makes a failure actionable.
Write the claim as the skill states it, in the skill's own terms.

Kinds: `file`, `no-file`, `present`, `absent`, `count`, `at-least`, `ordered`, `probe`.
Reach for `probe` when a regex would have to lie about what it checks — a Python function
in `assert_c1.py` registered with `@probe("name")`. The ten existing probes cover the
structural claims: every operation's parameter order, converters on model properties,
`JsonIgnore` versus defaults, enum declaration form, the absence of client-side validation,
the client constructor not being a thin wrapper, the `Idempotency-Key` emission rule and the
source of its value, the raw-PAN model set, the webhook verifier having no callers, and every
OAuth2 credentials property having its `TokenStrategy` sibling.

Three of those deliberately raise `Unsettleable` rather than pass on a fixture that cannot
answer them: the PAN allow-list is paypal-sdk's and skips on any other root namespace, the
OAuth2 pairing skips on an SDK with no OAuth2 scheme, and the webhook probe skips without a
`SignatureVerifier.cs`. Each was a vacuous `ok` before — an `absent` regex asks "is there a
counter-example", and on a fixture with no examples at all the answer is no.

`requires` lists the fixture parts the assertion needs (`api`, `models`, `enums`,
`errors`, `root-client`, `di`). Omit it for `Core/`-only assertions.

## Surfaces

Two surfaces ship in this repo: generator **4.0.0** (paypal-sdk, twilio-sdk — 122 `Core/*.cs`)
and **pre-4.0.0** (maxio-sdk — 88). Until a maxio fixture existed, every assertion here had only
ever run against 4.0.0, which meant the C1-vs-C2 distinction the whole suite rests on had never
itself been tested: an assertion cannot be shown to be generator-static by checking it against
one generator.

The suite handles the two surfaces in two different ways, deliberately:

**The general 328 are never filtered.** They run in full against every fixture, including the
one where ~100 of them cannot hold. Those 100 are pinned in `maxio-pre-4.0.0-drift.txt` and
graded with `--expect-failures`, so the job goes red when the delta **changes** rather than
while it merely exists. Failing loudly against a recorded baseline beats silently running a
smaller suite — and the baseline doubles as the readable document of what the two surfaces
actually differ on, grouped by family with a line on each explaining why.

**Assertions that are true of one surface only declare it.** `assertions/15-pre-4.0.0.json`
carries `"surfaces": ["pre-4.0.0"]` on all 14 of its entries, because they assert things that
are *false* on 4.0.0 — a bare `.Handle<HttpRequestException>()` with no method gate, an empty
pipeline for retry-ineligible requests, no delay clamp, a `RawClient` that catches nothing.
Ten of the fourteen fail on a 4.0.0 fixture if you force them to run
(`--surface pre-4.0.0` against paypal); the other four are pins that hold on both.

Surface-filtered assertions are counted and reported **separately** from unsettled ones —
`13 unsettled, 14 n/a on this surface`, never one merged skip count. The two mean opposite
things: an unsettled assertion is a question this run left open, an n/a one is closed by
construction. Merging them is the same mistake as reporting a skip as a pass.

`X-APIMatic-Gen-Version` **does not pin the surface.** codegen-v2 still stamps `4.0.0`
while its `StaticCode/Core` has moved ahead of the SDKs reporting that same value — 20 of
121 shared files differ, and `RequestOptions` has gained a property. The version string is
therefore not a usable discriminator, and the `surface.*` assertions do that job instead
by pinning file presence and shape.

Running this against the current generator template is a useful habit precisely because it
fails: those failures are the diff between what the skills describe and what the next
generated plugin will contain.

## Known coverage gaps

These are claims the sampled SDKs cannot settle. They are recorded in the `core-surface`
stamps at the top of each skill, and they are the first assertions worth writing when a
fixture that exercises them exists:

- **Union member naming for primitive variants** — every union in both sampled SDKs has
  model variants only, so the `BigDecimal` / `Guid` / `Date` / `DateTime` / formatted-string
  / `ListOf` / `MapOf` rows come from the generator's naming rule, not an emitted artifact.
- **Pagination and SSE at the operation level** — neither SDK generates a paginated or a
  streaming operation, so `Pageable<TPage,TItem>` and `Task<IAsyncEnumerable<T>>` are
  verified as Core types but inferred as method signatures.
- **Webhook events at the operation level** — neither spec declares webhook events, so no concrete
  `WebhookEventParser`/`WebhookEvent` subclass is generated and the `Signing/` verifier has zero callers.
  Whether a spec that *does* declare events generates a parser, and whether that parser calls the internal
  `SignatureVerifier`, is unsettled here. The four `webhooks.*` assertions pin what is true on a fixture
  with no events; they cannot speak for one that has them.

- **OAuth2 grants other than client-credentials** — the authorization-code and password
  paths are read from Core and from compiled probes, never from a live exchange.

## CI

`.github/workflows/assert-c1.yml`. Four jobs — `fixtures` reads fixtures.json into the `static` matrix and
fails if that list is empty, then:

**static** — clones each SDK fixture at its pinned ref and runs the suite, plus the mutation
test on one of them. Triggers on any PR touching `plugins/{paypal,twilio,maxio}-sdk/skills/dotnet-*`
or this directory. Fixtures are listed in `fixtures.json`; the refs there must track what the
plugins themselves pin, or CI reports green about a surface nobody ships any more. A fixture that
names an `expectFailures` baseline is graded against it; one that does not must come back clean.

maxio has no mutation test yet — `mutation_test.py`'s edits are written against 4.0.0 `Core/`
files and would fail to apply rather than prove anything. Until a pre-4.0.0 mutation set exists,
that fixture's assertions are unproven in the one way the others are proven: nothing yet
demonstrates they can still fail.

**behavioural** — runs the compiled checks against the published package. PayPal-specific by
construction (see above), so it does not fan out over fixtures the way the static job does.

**generator template drift** — schedule and manual only, because nothing in a PR to *this*
repo moves the generator, and the job is about the generator moving. It needs
`CODEGEN_V2_TOKEN` and skips cleanly without it.

That last job is expected to fail: the template still stamps `4.0.0` while its `Core/` has
moved ahead of both shipped SDKs. `generator-template-drift.txt` records exactly which
assertions fail, and `--expect-failures` makes the job go red only when that set **changes**
— a new id means the generator moved again, a removed one means the gap closed and the
skills can follow. A job that is permanently red is one everybody learns to ignore.

Regenerate either baseline after reconciling:

```
python assert_c1.py <StaticCode> | grep '^FAIL' | awk '{print $2}' | sort
python assert_c1.py <maxio-sdk> --surface pre-4.0.0 | grep '^FAIL' | awk '{print $2}' | sort
```

`maxio-pre-4.0.0-drift.txt` is grouped and commented rather than a flat list, so regenerating it
by piping the above loses the per-family reasons. Merge new ids into the right group instead.
