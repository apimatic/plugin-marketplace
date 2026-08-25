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

The generator template has no `Api/`, `Models/`, `Errors/` or DI extension: those are
rendered per API definition. Assertions that need them are **skipped**, not failed, and
the skip message says the claim is *unsettled here*, not confirmed. That distinction is
the whole point — a suite that quietly passes on a fixture that cannot answer the
question is worse than no suite.

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
  "defends": "dotnet-configuration-resilience § defaults table",
  "requires": ["api"]
}
```

`claim` and `defends` are not documentation — they are what makes a failure actionable.
Write the claim as the skill states it, in the skill's own terms.

Kinds: `file`, `no-file`, `present`, `absent`, `count`, `at-least`, `ordered`, `probe`.
Reach for `probe` when a regex would have to lie about what it checks — a Python function
in `assert_c1.py` registered with `@probe("name")`. The existing probes cover the
structural claims: every operation's parameter order, converters on model properties,
`JsonIgnore` versus defaults, enum declaration form, and the absence of client-side
validation.

`requires` lists the fixture parts the assertion needs (`api`, `models`, `enums`,
`errors`, `root-client`, `di`). Omit it for `Core/`-only assertions.

## Surfaces

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
- **OAuth2 grants other than client-credentials** — the authorization-code and password
  paths are read from Core and from compiled probes, never from a live exchange.

## Hooking it into CI

There is no workflow in `.github/` yet. The natural one runs the static tier against each
plugin's pinned SDK on every PR that touches `plugins/*/skills/dotnet-*`, and against the
current generator template on a schedule — the second is what catches the drift nobody
went looking for.
