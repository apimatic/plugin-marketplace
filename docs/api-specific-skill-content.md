# API-specific skill content, captured before simplification
On 2026-08-28 the shipped paypal-sdk and twilio-sdk plugins moved to the **simplified templatized
skills** — the two rendered skills (`integrate-{api}`, `{api}-getting-started`) now carry only the
slots today's plugin generator can fill (API name, source-code and package identity), with every
other API-specific passage replaced by the static formulation the generator's blueprint uses
(`templates/plugin-template/`): generator-static facts stated sharply, API-dependent facts pointed
at the map.

This file preserves the **richer hand-written per-API content** those slots carried, verbatim,
so it can be re-incorporated when the generator learns to compute per-API facts from the API
definition. Each entry names the skill and section the content belonged to. The frames that
consumed these slots are in git history (`templates/plugin/` before this change); the values below
are the complete set — nothing else was API-specific.

> Verification caveat: this content was verified against the SDKs pinned at capture time
> (checkout-sample-sdk@v1.0.1, twilio-csharp-sdk@51fdf48, both generator 4.0.0). Re-verify counts
> and operation lists against the current map before re-incorporating any of it.

## `description.triggers`
_Fed integrate-{api} — the per-API task phrasings in the routing description._

### paypal

```markdown
take a payment at checkout, capture, refund, save a card, subscriptions, billing plans, vaulting, transaction search
```

### twilio

```markdown
SMS/MMS, voice calls, phone numbers, one-time-code verification, conversations, task routing
```

## `map.exampleApiFile`
_Fed {api}-getting-started — a real controller file from this API's map, used in every “e.g.”._

### paypal

```markdown
Api/Orders.cs
```

### twilio

```markdown
Api/Api20100401Message.cs
```

## `map.exampleErrorFile`
_Fed {api}-getting-started — a real typed-error file from this API's map._

### paypal

```markdown
Errors/CreateOrderError.cs
```

### twilio

```markdown
Errors/CreateConfigurationError.cs
```

## `map.exampleModelFile`
_Fed {api}-getting-started — a real model file from this API's map._

### paypal

```markdown
Models/OrderRequest.cs
```

### twilio

```markdown
Models/ApiV2010AccountMessage.cs
```

## `plan.sourceExample`
_Fed integrate-{api} — real map-page names for the contract sheet's source-column example._

### paypal

```markdown
`operations/Orders.md`,
   `records-1-Ac-Pa.md`
```

### twilio

```markdown
`operations/Api20100401Message.md`,
   `records-1-Ac-Ca.md`
```

## `readiness.irrecoverable`
_Fed integrate-{api} — the closing irrecoverable-outcomes phrase, in this API's own terms._

### paypal

```markdown
a duplicate charge, a PAN in a log, or production traffic sent to
   sandbox (or worse, sandbox traffic sent to production).
```

### twilio

```markdown
a duplicate charge, personal data in a log, or a test suite that sends
   real SMS to real numbers.
```

## `readiness.row1`
_Fed integrate-{api} — PRODUCTION READINESS row 1 — credential fail-fast, with this API's scheme parts spelled out._

### paypal

```markdown
   | 1 | **Credential fail-fast** | Where credentials are bound, and that the host refuses to start when one is missing or blank — rather than discovering it as a 401 on the first call in production. |
```

### twilio

```markdown
   | 1 | **Credential fail-fast** | Where credentials are bound, and that the host refuses to start when one is missing or blank — rather than discovering it as a 401 on the first call in production. Basic auth needs **both** halves; a blank auth token is not a missing one. |
```

## `readiness.row2`
_Fed integrate-{api} — row 2 — secret sourcing & rotation, naming this SDK's DI extension._

### paypal

```markdown
   | 2 | **Secret sourcing & rotation** | Where the secret comes from, and that `AddPayPalServerSdkClient` builds the options object **once at registration** and captures it in the singleton — so a rotated secret does not take effect until the process restarts. If rotation without a restart is required, say how. |
```

### twilio

```markdown
   | 2 | **Secret sourcing & rotation** | Where the secret comes from, and that `AddTwilioSdkClient` builds the options object **once at registration** and captures it in the singleton — so a rotated auth token does not take effect until the process restarts. If rotation without a restart is required, say how. |
```

## `readiness.row5`
_Fed integrate-{api} — row 5 — idempotency & ambiguous writes, with this API's real key parameters and counts._

### paypal

```markdown
   | 5 | **Idempotency & ambiguous writes** | For each write in scope: the key it uses, or that none exists. Name the real parameter — `payPalRequestId`, on 12 operations, nullable and positional. The injected `Idempotency-Key` header is **not** a key and must not be cited as one. Where no key exists, record the reconciliation path instead. |
```

### twilio

```markdown
   | 5 | **Idempotency & ambiguous writes** | For each write in scope: the key it uses, or that none exists. Only **8 of 887** operations take one — `idempotencyKey` as a form field on `CreatePayments`, `UpdatePayments`, `CreateUserDefinedMessage`, `CreateUserDefinedMessageSubscription`, and as a caller-supplied header on the four `ConversationsV2` operations. The injected `Idempotency-Key` header on the other 430 writes is **not** a key and must not be cited as one. Where no key exists, record the reconciliation path instead. |
```

## `readiness.row6`
_Fed integrate-{api} — row 6 — observability, naming this API's correlation-id fields._

### paypal

```markdown
   | 6 | **Observability** | What is logged at which level, that **JSON request bodies are logged unredacted** when `LogRequestBody` is on, and which correlation id reaches your own logs — `DebugId` is `required` on every typed error body. |
```

### twilio

```markdown
   | 6 | **Observability** | What is logged at which level, that **JSON request bodies are logged unredacted** when `LogRequestBody` is on, and which correlation id reaches your own logs. |
```

## `readiness.row7`
_Fed integrate-{api} — row 7 — sensitive data, naming the exact fields (PAN / phone numbers / message bodies)._

### paypal

```markdown
   | 7 | **Card data** | Whether the scope can carry a raw PAN — the payment-source branch of `CreateOrder`, `AuthorizeOrder`, `CaptureOrder`, `ConfirmOrder`, `CreatePaymentToken`, `CreateSetupToken`, `CreateSubscription`. If it can: `LogRequestBody` stays off **and** `LoggerFactory` is assigned explicitly, so `PAYPALSERVERSDKCLIENT_LOG=trace` cannot switch it on from outside the code. |
```

### twilio

```markdown
   | 7 | **Sensitive data** | Whether the scope carries data you would not want in a log — phone numbers, message bodies, recording URLs, call metadata. If it does: `LogRequestBody` stays off **and** `LoggerFactory` is assigned explicitly, so `TWILIOSDKCLIENT_LOG=trace` cannot switch it on from outside the code. Form bodies are masked only by deny-list, so a key you have not listed prints in the clear. |
```

## `readiness.row8`
_Fed integrate-{api} — row 8 — environment selection, enumerating this API's ServerEnvironment members and server groups._

### paypal

```markdown
   | 8 | **Environment selection** | Which base URL each deployment talks to. `ServerEnvironment` has exactly **one** member — `Sandbox` — and every call resolves through `Server.Default.Sandbox.BaseUrl`. Reaching production therefore means assigning the production URL to a property named `Sandbox`; setting `options.Environment` alone never leaves the sandbox host. Say which deployment sets what. |
```

### twilio

```markdown
   | 8 | **Environment selection** | Which base URLs each deployment talks to — **plural, and there are fifteen**. `ServerEnvironment` has exactly one member, `Production`, but `ServerOptions` declares fifteen server groups (`Default` … `Default14`) on fifteen different hosts, and each operation resolves through its own. Only **197 of 887** go through `Server.Default` / `api.twilio.com`; the other **690** reach `conversations`, `flex-api`, `messaging`, `numbers`, `taskrouter`, `verify`, `trusthub`, `sync`, `studio`, `video`, `insights`, `proxy`, `content` and `lookups`. **This SDK has no sandbox**, so a dev run, an integration test and a production deploy all reach live Twilio: real messages, real charges. State which groups the scope touches and what each deployment repoints — overriding `Default` alone leaves 690 operations pointed at production. |
```

## `sdk.authRow`
_Fed {api}-getting-started — the identity table's Auth row with the exact credentials properties and types._

### paypal

```markdown
| Auth | Credentials properties on `PayPalServerSdkClientOptions`: `Oauth2: OAuth2ClientCredentials?`, `Oauth2TokenStrategy: IOAuth2TokenStrategy<OAuth2ClientCredentials>?` — see the SDK map's *Servers & auth* section |
```

### twilio

```markdown
| Auth | Credentials properties on `TwilioSdkClientOptions`: `AccountSidAuthToken: BasicAuthCredentials?` — see the SDK map's *Servers & auth* section |
```

## `sdk.cloneRefPhrase`
_Fed {api}-getting-started — the human phrasing of the pinned ref (tag vs commit)._

### paypal

```markdown
at tag `v1.0.1` (the exact
release the map was generated from; see the map's source-commit stamp)
```

### twilio

```markdown
at commit `51fdf48` (the exact
commit the map was generated from; see the map's source-commit stamp)
```

## `sdk.envRow`
_Fed {api}-getting-started — the identity table's Environments row with the real ServerEnvironment members._

### paypal

```markdown
| Environments | `options.Environment` — `ServerEnvironment` members: `Sandbox` (see the SDK map's *Servers & auth* section) |
```

### twilio

```markdown
| Environments | `options.Environment` — `ServerEnvironment` members: `Production` (see the SDK map's *Servers & auth* section) |
```

## `sdk.nugetRow`
_Fed {api}-getting-started — the identity table's NuGet row._

### paypal

```markdown
| NuGet package | `AsadAli.Checkout.Sdk` (install version-less — see *Install* below) |
```

### twilio

```markdown
| NuGet package | `AsadAli.TwilioSdk` (install version-less — see *Install* below) |
```

## `sdk.sourceRepoRow`
_Fed {api}-getting-started — the identity table's Source-repo row with the ref phrasing._

### paypal

```markdown
| Source repo | https://github.com/asadali214/checkout-sample-sdk (tag `v1.0.1` — the release this map documents) |
```

### twilio

```markdown
| Source repo | https://github.com/context-plugins/twilio-csharp-sdk (commit `51fdf48` — the commit this map documents; `main` has since been regenerated with a newer generator) |
```

## `sections.idempotency`
_Fed {api}-getting-started — the whole per-API Idempotency section (real key params, operation counts, retention prose)._

### paypal

```markdown
## Idempotency — `payPalRequestId`, and the header that isn't it

Twelve operations take a `payPalRequestId` parameter. It carries the `PayPal-Request-Id` header, and it is
PayPal's idempotency key — the only one this SDK offers. All twelve are POSTs that move money or create a
billing artefact:

| Group | Operations | Key retention (from the parameter docs) |
| --- | --- | --- |
| `Orders` | `AuthorizeOrder`, `CaptureOrder`, `CreateOrder` | **6 hours** (up to 72 by arrangement with your account manager) |
| `Payments` | `CaptureAuthorizedPayment`, `ReauthorizePayment`, `RefundCapturedPayment`, `VoidPayment` | **45 days** |
| `Subscriptions` | `CaptureSubscription`, `CreateBillingPlan`, `CreateSubscription` | **72 hours** |
| `Vault` | `CreatePaymentToken`, `CreateSetupToken` | **3 hours** |

Three things decide whether the integration is actually safe, and the signature states none of them:

- **It is a nullable positional parameter with no default**, so `null` compiles and runs. Passing `null` is
  not "taking the default" — it is switching idempotency off on a payment capture. The map row flags the
  parameter as *must pass explicitly*; that flag is about argument binding, and this is about money.
- **The value must be generated and persisted *before* the first attempt**, keyed to business intent — the
  order being captured, not the attempt capturing it. A value minted inside the call, or freshly on each
  caller-level retry, is a *different* key, and PayPal treats it as a different request. Persist it with the
  unit of work so that a process restart reuses it rather than generating a new one.
- **Retention is finite and differs per group** — the fourth column above, and the spread is wide: a Vault
  key is forgotten in 3 hours, a Payments key survives 45 days. Past the window the same value no longer
  deduplicates, so a replay after the window is a fresh write. Reconcile instead.

`CreateOrder`'s parameter doc adds that the key is **mandatory** for single-step create-order calls carrying
payment-source information (card, `PayPal.vault_id`, `PayPal.billing_agreement_id`).

**The other fourteen writes have no key at all.** Of the 26 non-GET operations only these 12 expose
`payPalRequestId`; for the remaining 14 the answer is reconciliation — see
`dotnet-configuration-resilience` § *Reconcile after a failure* — not a key.

⚠ **Do not read the injected `Idempotency-Key` header as protection.** The generator puts
`Idempotency-Key: Guid.NewGuid()` on all 26 non-GET operations, including the 14 that have no real key. It is
not a PayPal parameter, PayPal documents `PayPal-Request-Id` instead, and the value is fresh on every call.
`dotnet-configuration-resilience` § *Make the write idempotent at the provider* explains why a visible header
is worse than an absent one.
```

### twilio

```markdown
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
```

## `sections.responseMetadata`
_Fed {api}-getting-started — the whole per-API response-metadata section (which typed errors carry a status)._

### paypal

```markdown
## Response metadata — status and headers are not reachable

`dotnet-error-handling` describes `ApiResult<TResponse, TError>`, which exposes `StatusCode` and `Headers`
on both success and failure, and correctly says the generator emits it only where configured to. **On this
SDK it never was: zero of the 40 operations have a `{Operation}Result` sibling.** The type ships in
`Core/Models` and nothing returns it, so that whole section describes a door this SDK does not have.

What is actually reachable:

| you want | on a success | on a failure |
| --- | --- | --- |
| the **body** | the return value | the typed accessor — `Name`, `Message`, `DebugId`, `Details[].Issue` |
| the **status** | not exposed | any arm whose out-type is `RawError` → `RawError.StatusCode`: the `_` fallback on all 39, plus a documented-500 `TryGetNoContent` on seven Payments-side operations. Never on the model arms |
| **headers** | not exposed | not exposed — `RawError` carries a status but no headers |

Three things production integrations routinely need are therefore unavailable in-band: a `Retry-After` on a
429 the SDK has already exhausted its retries against, rate-limit budget headers, and a request-id echo for
correlation. `RawClient.ExecuteResult` does return an `ApiResult`, but `RawClient` is `internal sealed`, so
it is not a way round this either.

A `DelegatingHandler` is the only route — see `dotnet-configuration-resilience` § *When you still want a
`DelegatingHandler`*, which also covers the DI blast radius. Two caveats before you build one: under retry
it observes one response *per attempt*, not per call, so "the" status is the last attempt's; and getting the
value to the caller needs `AsyncLocal` or a scoped service. For correlation specifically you probably do not
need it — `DebugId` is `required` on every typed error body and is what PayPal support asks for.
```

### twilio

```markdown
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
```

## `sections.sensitiveData`
_Fed {api}-getting-started — the whole per-API sensitive-data section (empty where the API carries none)._

### paypal

```markdown
## Card data — `LogRequestBody` writes PANs to your logs

This API carries raw card numbers in **request** bodies, and this SDK logs JSON request bodies
**verbatim** — `HttpLogger` masks form bodies by deny-list and JSON bodies not at all
(`dotnet-configuration-resilience` § *Logging*). The two facts together mean one configuration flag puts
primary account numbers and CVVs into your log sink.

Seven request models carry a raw `number`, four of them alongside the `security_code`:

| Model | Raw fields |
| --- | --- |
| `CardRequest`, `PaymentTokenRequestCard`, `SetupTokenRequestCard`, `SubscriptionCardRequest` | `number`, `security_code`, `expiry` |
| `ApplePayTokenizedCard`, `GooglePayCard` | `number`, `expiry` |
| `NetworkToken` | `number`, `expiry`, `cryptogram` |

They reach the wire through the payment-source branch of seven operations: `CreateOrder`,
`AuthorizeOrder`, `CaptureOrder`, `ConfirmOrder`, `CreatePaymentToken`, `CreateSetupToken` and
`CreateSubscription`. A card is optional on all of them — the same call with `paypal` or `token` as the
payment source carries none — so whether an integration is in scope depends on the branch it uses, not on
the operation it calls.

**Rules that follow, and they are not stylistic:**

- **Never enable `LogRequestBody` on a build that can take a card**, including locally against sandbox with
  a real PAN. There is no redaction to fall back on and no `RedactedKeys` entry that helps, because the
  deny-list applies only to form bodies.
- **Set `options.Logging.LoggerFactory` explicitly in production**, even to `NullLoggerFactory.Instance`.
  Leaving it null on a hand-built client arms the `PAYPALSERVERSDKCLIENT_LOG` environment variable, and its
  `trace` level forces `LogRequestBody` on — a card leak that needs no code change and no deploy.
- **Do not echo a request body into your own diagnostics** on these operations. The SDK's logger is not the
  only way this data escapes; an exception handler that serialises the request it was building is the same
  leak with your name on it.

**Responses are materially safer** and it is worth knowing why, so the caution lands where it belongs:
`CardResponse` carries `last_digits`, `brand` and `expiry` — no `number`, no `security_code`. Logging a
*response* body on a card flow does not disclose a PAN. The asymmetry is the point: the risk is on the way
out, not the way back.
```

### twilio

*(empty — this API had no content here)*

## `workflow.idempotencyTrapLine`
_Fed {api}-getting-started — the workflow step-3 idempotency trap, in this API's own numbers._

### paypal

```markdown
   twelve operations taking `payPalRequestId`, passing `null` compiles and silently turns idempotency off,
```

### twilio

```markdown
   two payment operations, `idempotencyKey` sits one hyphen away from an injected header that is not it,
```
