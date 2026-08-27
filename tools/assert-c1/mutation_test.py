#!/usr/bin/env python3
"""mutation_test — does assert-c1 still have teeth?

An assertion suite that passes everywhere proves nothing. The failure mode is
quiet: a regex gets loosened during a refactor until it matches anything, and the
suite keeps reporting green while the claim it was defending rots.

This copies a fixture, breaks one documented fact at a time, and checks that at
least one assertion notices. A mutation nothing catches is a gap — either the
claim has no assertion, or the assertion that should defend it is too loose.

    python mutation_test.py <sdk-root>

Exit status is 0 when every mutation is caught.

Adding a mutation: pick a fact one of the dotnet-* skills states, and break it the
way a generator change plausibly would — change a default, flip a boolean
argument, delete a guard. Do not invent syntax errors; those are caught by the
compiler, not by this.
"""

from __future__ import annotations

import argparse
import os
import shutil
import subprocess
import sys
import tempfile

HERE = os.path.dirname(os.path.abspath(__file__))

# (file, find, replace, what this pretends the generator did)
MUTATIONS = [
    ("Core/Configuration/RetryOptions.cs",
     "MaxRetries = 3,", "MaxRetries = 5,",
     "the default retry count changed"),
    ("Core/Configuration/RetryOptions.cs",
     "HttpMethod.Put,", "HttpMethod.Post,",
     "POST became retryable by default"),
    ("Core/ResiliencePipelineFactory.cs",
     "methodsToRetry.Contains(method) &&", "true &&",
     "the method filter stopped gating the retry arms"),
    ("Core/ResiliencePipelineFactory.cs",
     "MaxDelay = TimeSpan.FromMinutes(1)", "MaxDelay = TimeSpan.FromMinutes(5)",
     "the delay ceiling moved off 60s"),
    ("Core/ResiliencePipelineFactory.cs",
     "Exception: HttpRequestException or TimeoutRejectedException",
     "Exception: HttpRequestException",
     "the per-attempt timeout stopped being a retry trigger"),
    ("Core/Logging/HttpLogger.cs",
     "MaskPairs(query, maskUnknownKeys: true)", "MaskPairs(query, maskUnknownKeys: false)",
     "URL redaction flipped from allow-list to deny-list"),
    ("Core/Logging/HttpLogger.cs",
     "isForm ? MaskPairs", "true ? MaskPairs",
     "JSON bodies started going through the form masker"),
    ("Core/Configuration/LoggingOptions.cs",
     "BodySizeLimit { get; init; } = 32 * 1024", "BodySizeLimit { get; init; } = 64 * 1024",
     "the logged-body truncation limit changed"),
    ("Core/Authentication/OAuth2/OAuthToken.cs",
     "ExpiryBufferSeconds = 30", "ExpiryBufferSeconds = 5",
     "the OAuth expiry buffer shrank"),
    # The TokenStrategy sibling disappearing. As an `absent` regex this claim passed
    # vacuously on any SDK with no OAuth2 scheme at all; as a probe it skips there and
    # actually checks here.
    ("PayPalServerSdkClientOptions.cs",
     "public IOAuth2TokenStrategy<OAuth2ClientCredentials>? Oauth2TokenStrategy { get; set; }",
     "public IOAuth2TokenStrategy<OAuth2ClientCredentials>? TokenStrategyRenamed { get; set; }",
     "the OAuth2 TokenStrategy sibling lost its paired name"),
    ("Core/Configuration/RetryOptions.cs",
     "public static RetryOptions Disabled()", "internal static RetryOptions Disabled()",
     "Disabled() stopped being part of the public surface"),
    # These two target Api/ rather than Core/: the idempotency claim is about an
    # EMISSION rule, so the emitted operations are the only place it is visible.
    ("Api/Orders.cs",
     'new HeaderParam("Idempotency-Key", Guid.NewGuid())],',
     'new HeaderParam("PayPal-Removed-Header", (string?)null)],',
     "the generator stopped injecting Idempotency-Key on a write"),
    # A CONSTANT idempotency key. Worse than no key: every call on that operation dedupes
    # against the first one ever made, so the second charge silently returns the first
    # charge's result. The earlier version of the probe counted value-sources without
    # asserting on them, and this passed green.
    ("Api/Orders.cs",
     'new HeaderParam("Idempotency-Key", Guid.NewGuid())],',
     'new HeaderParam("Idempotency-Key", "fixed-key-abc")],',
     "the injected idempotency key became a constant"),
    ("Api/Orders.cs",
     '[new Param("fields", fields)],' + chr(10) +
     '            [new HeaderParam("PayPal-Mock-Response", payPalMockResponse),' + chr(10) +
     '                new HeaderParam("PayPal-Auth-Assertion", payPalAuthAssertion)],',
     '[new Param("fields", fields)],' + chr(10) +
     '            [new HeaderParam("PayPal-Mock-Response", payPalMockResponse),' + chr(10) +
     '                new HeaderParam("PayPal-Auth-Assertion", payPalAuthAssertion),' + chr(10) +
     '                new HeaderParam("Idempotency-Key", Guid.NewGuid())],',
     "Idempotency-Key started being injected on reads too"),
    ("Models/CardResponse.cs",
     '[JsonPropertyName("last_digits")]',
     '[JsonPropertyName("number")]',
     "a response model started carrying a raw PAN"),
    ("Models/ErrorDetails.cs",
     '[JsonPropertyName("value")]',
     '[JsonPropertyName("number")]',
     "an eighth undocumented model started carrying a raw PAN"),
    ("Core/Webhooks/Signing/SignatureVerifier.cs",
     "internal sealed class SignatureVerifier",
     "public sealed class SignatureVerifier",
     "the webhook signature verifier became public"),
    ("Core/Webhooks/WebhookEventParser.cs",
     "return CreateEvent(root, request);",
     "return Verify(request) ? CreateEvent(root, request) : default!;",
     "the webhook parser started verifying signatures"),
    ("Core/Webhooks/WebhookRequest.cs",
     "public sealed class WebhookRequest",
     "public sealed class WebhookRequest // paired with SignatureVerifier",
     "something outside its own file started referencing the verifier"),
    # Values GROWING, not shrinking. Every one of these was invisible until the patterns
    # defending them were anchored: an unanchored `= 30` still matches `= 300`, so a limit
    # that widens tenfold reads as unchanged. The shrink direction was already covered; this
    # is the direction that quietly relaxes a bound.
    ("Core/Authentication/OAuth2/OAuthToken.cs",
     "ExpiryBufferSeconds = 30;", "ExpiryBufferSeconds = 300;",
     "the OAuth expiry buffer grew tenfold"),
    ("Core/Configuration/LoggingOptions.cs",
     "BodySizeLimit { get; init; } = 32 * 1024;", "BodySizeLimit { get; init; } = 32 * 10240;",
     "the logged-body limit grew tenfold"),
    ("Core/ResiliencePipelineFactory.cs",
     "AttemptNumber = args.AttemptNumber + 1,", "AttemptNumber = args.AttemptNumber + 10,",
     "OnRetry's attempt number stopped being one-based"),
    ("Core/HttpStatusPolicy.cs",
     "is >= 200 and <= 299;", "is >= 200 and <= 2999;",
     "the success window widened past 2xx"),
]


def run_suite(root: str) -> set[str]:
    """Return the ids of the assertions that fail against `root`."""
    out = subprocess.run(
        [sys.executable, os.path.join(HERE, "assert_c1.py"), root],
        capture_output=True, text=True, encoding="utf-8", errors="replace")
    return {line.split()[1] for line in out.stdout.splitlines()
            if line.startswith("FAIL ") and len(line.split()) > 1}


def main() -> int:
    ap = argparse.ArgumentParser(description=__doc__,
                                 formatter_class=argparse.RawDescriptionHelpFormatter)
    ap.add_argument("sdk_root")
    ap.add_argument("-v", "--verbose", action="store_true")
    args = ap.parse_args()

    baseline = run_suite(args.sdk_root)
    if baseline:
        print("the fixture already fails %d assertion(s) — fix those before mutation testing:"
              % len(baseline))
        for f in sorted(baseline):
            print("   " + f)
        return 2

    tmp = tempfile.mkdtemp(prefix="assert-c1-mutant-")
    missed, skipped_muts = [], []
    try:
        for rel, find, repl, label in MUTATIONS:
            root = os.path.join(tmp, "sdk")
            shutil.rmtree(root, ignore_errors=True)
            shutil.copytree(args.sdk_root, root,
                            ignore=shutil.ignore_patterns(".git", "bin", "obj"))

            target = os.path.join(root, rel)
            if not os.path.exists(target):
                print("SKIP %-58s (no %s in this fixture)" % (label, rel))
                skipped_muts.append(label)
                continue
            src = open(target, encoding="utf-8-sig").read()
            if find not in src:
                print("SKIP %-58s (pattern absent — fixture may be a different surface)" % label)
                skipped_muts.append(label)
                continue
            open(target, "w", encoding="utf-8").write(src.replace(find, repl, 1))

            caught = run_suite(root)
            if caught:
                print("ok   %-58s caught by %s" % (label, ", ".join(sorted(caught))))
            else:
                print("MISS %-58s NOTHING CAUGHT IT" % label)
                missed.append(label)
    finally:
        shutil.rmtree(tmp, ignore_errors=True)

    print()
    applied = len(MUTATIONS) - len(skipped_muts)
    if missed:
        print("%d mutation(s) went unnoticed — the suite has a gap there:" % len(missed))
        for m in missed:
            print("   " + m)
        return 1
    if skipped_muts:
        # Reporting "every mutation was caught" here would be the same hollow pass the
        # suite itself is built to avoid: nothing was caught, because nothing was tried.
        print("%d of %d mutation(s) could not be applied to this fixture:" % (
            len(skipped_muts), len(MUTATIONS)))
        for m in skipped_muts:
            print("   " + m)
        print()
        print("%d applied, %d caught — but coverage here is PARTIAL, not proven." % (applied, applied))
        return 1
    print("every mutation was caught (%d/%d applied)" % (applied, len(MUTATIONS)))
    return 0


if __name__ == "__main__":
    sys.exit(main())
