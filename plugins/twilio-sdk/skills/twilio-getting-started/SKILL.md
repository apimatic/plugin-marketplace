---
name: twilio-getting-started
description: Twilio .NET SDK identity and lookup layer for the twilio-sdk helper agent (.NET/C# only) — install, root namespace, environments, auth pattern, and the bundled SDK map of every operation signature, model, enum, union and error type. The helper agent loads this to answer contract questions; other agents work from the contract sheet it produces.
---

# Getting started with the Twilio .NET SDK

> **Who this skill is for.** This is the **map layer**, preloaded for the `twilio-sdk` helper
> agent — if you are it, this skill is yours to follow directly and fully. It is the only place
> the bundled SDK map is opened, and the map stays here: an implementer works from the contract
> sheet this agent produces, and asks the warm agent for any fact the sheet is missing. The
> "load the companion skill" steps below address whoever is doing the grounding. This skill
> never calls back into the router, so there is no loop.

This is the **SDK-specific** entry point. For general patterns that apply to any APIMatic-generated
.NET SDK (auth, calling endpoints, models, error handling, retries, testing), see the companion
API-agnostic skills: `dotnet-client-initialization`, `dotnet-authentication`, `dotnet-calling-endpoints`,
`dotnet-models`, `dotnet-error-handling`, `dotnet-configuration-resilience`, `dotnet-testing`.

**The SDK map and these companion skills are complementary — load both.** The map (generated from the SDK
source, which remains the ground truth) is authoritative for the SDK's *surface* (signatures, model shapes,
enums, which error type an operation throws); the companion skills are the *usage layer* on top — the
best-practice way to call each piece and the gotchas a signature can't show. Reading the map or source
doesn't remove the need to load the skill for that step, so at each step below, load the companion *and*
confirm names against the map.

> **Ground every signature, model, enum, and error type in the bundled SDK map** (`sdk-map.md` + `map/`,
> in this skill's directory) — it carries every operation signature, error type, enum value list, field
> list with JSON wire names, and union accessor by lookup, so most questions never touch the SDK source
> at all. When the map can't answer something — a full method/model body, or a map-sourced name that
> fails to compile — the SDK source must be consulted (you clone it — see the *SDK source*
> section below) and the one file the map names opened; **never fill the gap from memory.** Do **not** decompile or
> reflect over the installed reference, do **not** fetch GitHub files ad hoc, and do **not** grep or run
> other expensive searches over the clone.

## SDK identity

| | |
| --- | --- |
| API | Twilio |
| NuGet package | `AsadAli.TwilioSdk` (install version-less — see *Install* below) |
| Source repo | https://github.com/context-plugins/twilio-csharp-sdk (branch `main`) |
| Root namespace | `TwilioSdk` (the `using` namespace) |
| Client class | `TwilioSdkClient` |
| Options class | `TwilioSdkClientOptions` |
<!-- gen:auth -->
| Auth | Credentials properties on `TwilioSdkClientOptions`: `AccountSidAuthToken: BasicAuthCredentials?` — see the SDK map's *Servers & auth* section |
<!-- /gen:auth -->
<!-- gen:environments -->
| Environments | `options.Environment` — `ServerEnvironment` members: `Production` (see the SDK map's *Servers & auth* section) |
<!-- /gen:environments -->

The table above is **orientation, not a copy-paste recipe** — it gives you the names and facts (install,
namespaces, the auth *pattern*, the environments), while the actual integration code comes from the companion
skills. Load each one as you reach its step (see **Integration workflow** below) and confirm its types
against the SDK map: the client construction and DI from `dotnet-client-initialization`, the exact
auth-credentials property name from `dotnet-authentication`, each call from `dotnet-calling-endpoints`, and so
on.

## Namespaces (using-directives)

The SDK splits its public types across **separate child namespaces**. C# does **not** import child
namespaces transitively, so `using TwilioSdk.Models;` alone does **not** make enums, union
types, or error types visible — you get `CS0103`/`CS0246` ("name/type does not exist") on build. Add a
separate `using` for each kind of type you reference — the map lists each type's namespace, so take it from
the map row; only if the map is silent do you open the file in the clone and copy the `namespace`
declaration at its top.

## Install — add the NuGet package

This SDK is published to NuGet; install it into the project that will call Twilio:

```bash
dotnet add package AsadAli.TwilioSdk
```

> Install **version-less** so it floats to the latest release — do not pin a version from memory.
> The package pulls the SDK's runtime dependencies in transitively. There is **no SDK source in
> your solution**: the only local copy that ever exists is the read-only **reference clone** the
> *SDK source* section below describes, which lives in the system temp directory, is never
> referenced by the build, and is cloned only when the map genuinely falls short.

## SDK map — look up first, open second, never grep

This skill bundles a generated table-of-contents for the SDK, right next to this file:

- **`sdk-map.md`** — the index: SDK identity (namespace, version, source commit), the
  client-construction and error-handling models, the servers/auth wiring, and link tables into `map/`.
- **`map/operations/{Controller}.md`** — one page per controller. Each operation
  row carries the HTTP verb/path, the exact C# signature with must-pass-explicitly params, the return type,
  the error case (typed `{Operation}Error` vs `RawError`) with its `TryGet…` accessors, and pagination.
  Each page's header names the source file it came from (e.g. `Api/Api20100401Message.cs`).
- **`map/models/`** — record models (alphabetical pages), `unions.md` (variant factories + `TryGet…`),
  and `enums.md` (full value lists).

**This map is how you traverse the SDK.** Do **not** grep, Glob, `find`, or otherwise scan the clone to
locate an operation, model, enum, union, or error type — that burns time and context on a tree
whose entire surface is already indexed here. Instead:

1. Open `sdk-map.md` and follow the link table to the branch page you need (controller or model group).
2. Read the fact by lookup — most questions (signature, error accessors, enum values, pagination) end here
   without touching the clone at all.
3. Only when you need a **full method or model body** the map doesn't carry, take the file path the map
   names (e.g. `Api/Api20100401Message.cs`, `Errors/CreateConfigurationError.cs`, `Models/ApiV2010AccountMessage.cs`) and
   **open that one file directly in the clone**.

Keep lookups cheap — the rules that keep a session's context small:

- Collect the contracts for **every** in-scope operation in **one** map pass — signature, required fields
  with wire names, error accessors, enum values — into a short **contract sheet** in your plan or working
  notes, then implement from the sheet. Don't re-open the map per field, and never re-look-up a fact the
  sheet already carries.
- When you do open a source file, read it **scoped**: the Read tool with an offset/limit, or the Grep tool
  on the one symbol — never dump a whole file into the conversation with `cat`/`sed`.
- Never open the SDK's `api-reference.md` — the map supersedes it.

Staleness check: `sdk-map.md` records the source commit it was generated from (provenance). The map
documents that pinned commit, while `dotnet add package` installs the latest release — so if a name from
the map ever fails to compile, trust the compiler, re-read the source file the map's row names, and
report the drift; never patch around it from memory.

## SDK source — clone only on a map-side issue; don't reflect or fetch files

The clone is the ground truth the map was generated from, but it is a **last resort, not a step** — most
integrations never open it. Clone only when the map has actually failed you: a map-sourced name fails to
compile, ambiguity remains after the map lookup, or you need a full method/model body the map doesn't
carry. (You clone only on a real map-side issue — never "just in case".) The clone lives in the **system
temp directory** (`<temp>/twilio-sdk-src/`), never in the project
repo, so the clone stays invisible to the main agent — navigated via the SDK map above, a read-only
reference, **not** a build dependency (never add a project reference to *this* clone; the build takes the
SDK from the NuGet package in the *Install* section).

**Clone only on a real map-side issue.** Clone once this session — shallow, from branch `main` (the
branch the map was generated from) — into a fresh timestamped folder under `<temp>/twilio-sdk-src/`, and reuse
that folder for the rest of your session:

```bash
# Linux/macOS:
dir="${TMPDIR:-/tmp}/twilio-sdk-src/$(date +%Y%m%d-%H%M%S)"
git clone --depth 1 --branch main https://github.com/context-plugins/twilio-csharp-sdk "$dir"
# Reuse "$dir" for the rest of your session (it is your clone path).
```

```powershell
# Windows (PowerShell):
$dir = "$env:TEMP\twilio-sdk-src\$(Get-Date -Format yyyyMMdd-HHmmss)"
git clone --depth 1 --branch main https://github.com/context-plugins/twilio-csharp-sdk $dir
# Reuse $dir for the rest of your session (it is your clone path).
```

The clone lives in `<temp>/twilio-sdk-src/`, **never** in the project repo, and its path never goes into
`twilio-plan.md` — the main agent must never see the clone or its path.

Then confirm the SDK shape **only** from that local clone — not by either of these:

- **Don't decompile or run reflection over the built assembly.** A compiled assembly drops what the source
  carries and the other skills rely on: the XML `<exception>`/parameter doc-comments, the exact parameter
  names and order, and each method's internal request-builder list.
- **Don't fetch GitHub files one at a time** as your way in — `…/blob/…` pages return HTML (not source) and
  guessed paths fail, which is exactly how ad-hoc fetching breaks. Clone once and read locally instead. Only
  if you truly cannot clone (`git` is unavailable) fetch a **raw** URL
  (`https://raw.githubusercontent.com/<owner>/<repo>/main/…`, derived from the source repo above —
  never a `…/blob/…` page), e.g. `…/main/Api/Api20100401Message.cs`.

Layout — where the SDK map's file references resolve (open these directly; don't scan for them):

- `Api/` — one file per controller/group; **this is where the operation methods and their signatures live**
  (each carries XML-doc comments for the params, the endpoint path, and the thrown error type). The map's
  per-controller pages name the exact file (e.g. `Api/Api20100401Message.cs`).
- `Models/` (+ `Models/Enums/`, `Models/AnyOf/`, `Models/OneOf/`) — request/response records, enums, unions.
- `Errors/` — per-operation `{Operation}Error` types (only Case-A operations have one; the map's rows say
  which case each operation is).
- `Core/` — HTTP infrastructure (`SdkException<T>`, `RawError`, auth, retries).
- `Servers/`, `TwilioSdkClient.cs`, `ServiceCollectionExtensions.cs` — environments, the client, DI.

**Leave the clone in place — don't delete it.** It's a read-only reference with nothing of yours in it, and
keeping it is what lets every later step in this session reuse it instead of cloning again. The OS reaps the
temp directory on its own; a future session simply makes its own timestamped clone.

## Idempotency — eight operations have a real key; the header is not it

Of this SDK's 887 operations, **434 are non-GET and every one of them sends an `Idempotency-Key` header**.
On 430 of those the value is `Guid.NewGuid()`, injected by the generator — you cannot set it, and Twilio does
not document that header as a general mechanism. Only **eight** operations let you supply a key, in two
different shapes:

| Shape | Operations |
| --- | --- |
| **Form field** `IdempotencyKey` (parameter `idempotencyKey`) | `Api20100401Payment.CreatePayments`, `Api20100401Payment.UpdatePayments`, `Api20100401UserDefinedMessage.CreateUserDefinedMessage`, `Api20100401UserDefinedMessageSubscription.CreateUserDefinedMessageSubscription` |
| **Header** `Idempotency-Key`, caller's value (no injected GUID) | `ConversationsV2ConfigurationApi.CreateConfiguration`, `.DeleteConfiguration`, `.UpdateConfiguration2`, `ConversationsV2ConversationApi.DeleteConversationAsync` |

⚠ **The two payment operations carry both keys at once.** `CreatePayments` emits
`new HeaderParam("Idempotency-Key", Guid.NewGuid())` on the line directly above
`new Param("IdempotencyKey", idempotencyKey)` in the form body. Only the second is yours and only the second
means anything. The names differ by one hyphen, and these are the operations that charge a card — so this is
the one place in the SDK where reading the wrong one costs money.

On these two the compiler is on your side: `CreatePayments` and `UpdatePayments` declare
`string idempotencyKey` — **non-nullable and positional**, so you cannot quietly omit it. The other six
declare `string?`, and there `null` compiles and silently gives up the protection.

**The remaining 426 writes have no key at all.** For those the answer is reconciliation — see
`dotnet-configuration-resilience` § *Reconcile after a failure* — not a key. Do not let the injected header
persuade you otherwise; `dotnet-configuration-resilience` § *Make the write idempotent at the provider*
explains why a visible header is worse than an absent one.

**Eleven operations offer optimistic concurrency instead**, via an `If-Match` header parameter — a
different guarantee (reject my write if the resource changed) solving a different problem (lost updates,
not duplicates). Seven updates: `SyncV1Document.UpdateDocument`, `SyncV1SyncListItem.UpdateSyncListItem`,
`SyncV1SyncMapItem.UpdateSyncMapItem`, `TaskrouterV1Task.UpdateTask`,
`TaskrouterV1TaskReservation.UpdateTaskReservation`, `TaskrouterV1Worker.UpdateWorker`,
`TaskrouterV1WorkerReservation.UpdateWorkerReservation`. And four **conditional deletes**, which are the
easier ones to overlook: `SyncV1SyncListItem.DeleteSyncListItem`, `SyncV1SyncMapItem.DeleteSyncMapItem`,
`TaskrouterV1Task.DeleteTask`, `TaskrouterV1Worker.DeleteWorker`.

## Response metadata — headers are not reachable, and the status only sometimes

`dotnet-error-handling` describes `ApiResult<TResponse, TError>`, which exposes `StatusCode` and `Headers`
on both success and failure, and correctly says the generator emits it only where configured to. **On this
SDK it never was: zero of the 887 operations have a `{Operation}Result` sibling.** The type ships in
`Core/Models` and nothing returns it, so that whole section describes a door this SDK does not have.

What is actually reachable:

| you want | on a success | on a failure |
| --- | --- | --- |
| the **body** | the return value | `RawError` (858 Case B ops) or a typed accessor (29 Case A ops) |
| the **status** | not exposed | **usually yes** — `ex.Error.StatusCode` on the 858 Case B ops; on a Case A op only via the `_` fallback arm |
| **headers** | not exposed | **never** — `RawError` carries a status but no headers |

This SDK is unusually well off for the status, because almost every operation throws
`SdkException<RawError>` and `RawError` carries `StatusCode` directly. Do not carry that assumption to
another API generated by the same toolchain — the split between Case A and Case B comes from the API
definition, and an SDK that is mostly Case A gives you no status at all on the documented statuses.

**Headers are the real gap, and it is total.** A `Retry-After` on a 429 the SDK has already exhausted its
retries against, rate-limit budget headers, and a request-id echo for correlation are all unavailable
in-band, on success and failure alike. `RawClient.ExecuteResult` does return an `ApiResult`, but `RawClient`
is `internal sealed`, so it is not a way round this either.

A `DelegatingHandler` is the only route — see `dotnet-configuration-resilience` § *When you still want a
`DelegatingHandler`*, which also covers the DI blast radius. Two caveats before you build one: under retry
it observes one response *per attempt*, not per call, so "the" value is the last attempt's; and getting it
to the caller needs `AsyncLocal` or a scoped service.

## The `dotnet-*` skill names are not unique in this marketplace

Three plugins in this marketplace — `maxio-sdk`, `paypal-sdk` and `twilio-sdk` — each ship their own copy
of the same seven `dotnet-*` skill names. The 21 copies are **not interchangeable**: they resolve to
**16 distinct versions**, and `dotnet-configuration-resilience` and `dotnet-error-handling` differ in all
three. Two of them installed side by side therefore expose two different skills under one name, and nothing
announces which one a bare name resolves to.

**Load the copy that ships with THIS plugin.** Where your harness supports plugin-qualified skill names,
write them out — `twilio-sdk:dotnet-error-handling`, `twilio-sdk:dotnet-configuration-resilience`, and so on. Where it does not, and more than one of those three plugins is installed,
confirm you have this plugin's copy before you rely on it: check the `core-surface:` stamp at the top of
the file, where it must name generator **4.0.0**.

The drift is not cosmetic, and it is not safe to shrug at:

- `maxio-sdk` documents a **pre-4.0.0** generator surface — 88 `Core/*.cs` against 122, with 28 of the 87
  shared files differing. Loading its copy here would describe a runtime this SDK does not have.
- `paypal-sdk` and `twilio-sdk` are both 4.0.0 but still differ where the *API definition* differs. The
  clearest case is `dotnet-error-handling`: twilio's boundary ladder reads `ex.Error.StatusCode`, which
  works there because 858 of its 887 operations are Case B — and is unavailable on paypal, where 39 of 40
  are Case A and carry no status at all.

## Integration workflow — load the companion skill at each step

Before you write the code for each step, load the named companion skill — even if you've already read the
relevant source. Each step calls out the trap the signature hides (in *parens*). A typical integration reaches
them in this order:

1. **Client & DI setup** — load **dotnet-client-initialization** before you write
   `new TwilioSdkClient(...)`, build its options, or DI-register via
   `AddTwilioSdkClient`. (*The signature won't tell you:* the `HttpClient`/handler
   pipeline must be long-lived and reused via `IHttpClientFactory`, not rebuilt per request; the SDK client
   wrapper over it may be transient.)
2. **Authentication** — load **dotnet-authentication** before you set credentials. The scheme(s) this SDK
   accepts are the credentials properties on `TwilioSdkClientOptions` — the map's *Servers & auth* section
   lists them. (*The signature won't tell you:* set credentials before
   constructing the client or in the DI callback, and load secrets from configuration rather than hardcoding.)
3. **Calling an endpoint / building a request body** — load **dotnet-calling-endpoints** before the first
   `client.{ApiGroup}.{Operation}(...)` call. (*The signature won't tell you:* call list/search ops with
   named arguments — many optional params have no C# default and mis-bind in a positional call; and on the
   two payment operations, `idempotencyKey` sits one hyphen away from an injected header that is not it,
   see *Idempotency* above.)
4. **Models** — load **dotnet-models** the moment a request/response field isn't a plain string or number.
   (*The signature won't tell you:* unions are built with factory methods and read via `TryGet…` (no `new`),
   enums are `StringEnum<T>` not C# enums, and unmodeled JSON fields are dropped on deserialize.)
5. **Error handling** — load **dotnet-error-handling** before you write any `try/catch`. (*The signature won't
   tell you:* many read/list/find/delete ops are Case B (`SdkException<RawError>`, no typed
   accessors) while others are Case A typed `{Operation}Error`s — confirm each operation's case in its map
   row; and `TryGetRawError` is not a catch-all on the typed errors. Each operation's map row also says
   whether a no-throw `…Result` variant exists — never assume one does.)
6. **Configuration & resilience** — load **dotnet-configuration-resilience** when you tune retries, timeouts,
   the base URL, pagination, or logging. (*The signature won't tell you:* `HttpMethodsToRetry` gates **every**
   retry trigger, so a `POST` is never resent by default — but a `GET` that hangs costs ≈407s, not the ≈100s
   `Timeout` suggests, because the per-attempt timeout is itself retried. `Timeout` is per-attempt not total,
   `RetryOptions.Disabled()` turns retries off, and there **is** a built-in logger on `options.Logging` —
   whose `LogRequestBody` does not redact JSON.)
7. **Testing** — load **dotnet-testing** before you stub the SDK. (*The signature won't tell you:* the
   `HttpClient` constructor argument is the test seam; match the project's existing framework and assertion
   style.)
