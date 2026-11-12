<!-- Generated file — do not edit; regenerated with the SDK. -->

# SDK map — Upvest Investment API (.NET)

> A generated table of contents for this SDK. Consult this map and its sub-pages to learn signatures, error types, and server/auth wiring **by lookup**. Model shapes and enum values are *not* duplicated here — the map names the file declaring each type; read the shape there. The compiler is the backstop: a wrong name fails to build.

|  |  |
| --- | --- |
| SDK display name | Upvest Investment API |
| Root namespace | `UpvestInvestmentApi` |
| Target framework | `netstandard2.0` (C# `LangVersion 14`, `Nullable enable`) |
| API spec version | `1.172.0` |
| Generator | APIMatic |

Staleness check: the API spec version above changes when the SDK is regenerated from a new spec. If a lookup here fails to compile, trust the compiler and re-read the source file named in the row.

All `Source` paths on this map and its sub-pages are relative to the **SDK root** — the directory holding this file — never to the page that carries them; the project file is `src/UpvestInvestmentApi/UpvestInvestmentApi.csproj`. Open them as-is from the SDK root, from any page; if the SDK sits under a subdirectory of a larger repo, prefix that subdirectory.

---

## Getting a client

```csharp
var httpClient = new HttpClient();
// TODO: configure more client options here
var options = new UpvestInvestmentApiClientOptions
{
    OauthClientCredentials = new OAuth2ClientCredentials
    {
        ClientId = "YOUR_CLIENT_ID",
        ClientSecret = "YOUR_CLIENT_SECRET",
    },
    Environment = ServerEnvironment.Production,
};
var client = new UpvestInvestmentApiClient(httpClient, options);
```

DI alternative (`services.AddUpvestInvestmentApiClient`):

```csharp
services.AddUpvestInvestmentApiClient(options =>
{
    options.OauthClientCredentials =
        new OAuth2ClientCredentials { ClientId = "YOUR_CLIENT_ID", ClientSecret = "YOUR_CLIENT_SECRET" };
    options.Environment = ServerEnvironment.Production;
    // TODO: configure more client options here
});
```

### Request signing — required on every call

Upvest refuses any request that is not signed with an HTTP message signature, including the SDK's own token request. The client always signs. If `options.Hooks` holds an `UpvestSigningHook`, that hook is used. Otherwise the client builds one from the signing environment variables (listed below). If those are not set either, every call fails before it is sent, with an `InvalidOperationException` that names what to set. No operation takes `signature`, `signature-input`, `authorization` or `upvest-client-id`: the hook and the OAuth scheme set them.

```csharp
using UpvestInvestmentApi.Signing;

options.Hooks = [new UpvestSigningHook(UpvestHttpSignatureCredentials.FromFile(
    keyId: "YOUR_SIGNING_KEY_ID", privateKeyPath: "upvest-signing-key.pem",
    upvestClientId: "YOUR_CLIENT_ID", privateKeyPassphrase: null))];
// or: options.Hooks = [UpvestSigningHook.FromEnvironment()];
```

| Type | Members | Source |
| --- | --- | --- |
| `UpvestSigningHook` (`SdkHook`) | `UpvestSigningHook(UpvestHttpSignatureCredentials credentials)` · `static FromEnvironment(): UpvestSigningHook` (throws when not configured) | `src/UpvestInvestmentApi/Signing/UpvestSigningHook.cs` |
| `UpvestHttpSignatureCredentials` (`IDisposable`) | `UpvestHttpSignatureCredentials(string keyId, string privateKeyPem, string upvestClientId, string? privateKeyPassphrase = null)` · `static FromFile(string keyId, string privateKeyPath, string upvestClientId, string? privateKeyPassphrase = null)` · `static FromEnvironment(): UpvestHttpSignatureCredentials?` · `KeyId: string` · `UpvestClientId: string` | `src/UpvestInvestmentApi/Signing/UpvestHttpSignatureCredentials.cs` |

`FromEnvironment` reads `UPVEST_API_KEY_ID`, one of `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_FILENAME` / `UPVEST_API_HTTP_SIGN_PRIVATE_KEY` / `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_BASE64`, optionally `UPVEST_API_HTTP_SIGN_PRIVATE_KEY_PASSPHRASE`, and the client ID from `UPVEST_API_CLIENT_ID`, else `UPVEST_INVESTMENT_API_OAUTH_CLIENT_CREDENTIALS_CLIENT_ID`. `ServerEnvironment.Production` is `https://sandbox.upvest.co`. More detail: README, "Request signing (required by Upvest)".

Every API group is a property on the client (e.g. `client.AccessTokens`). Source: `src/UpvestInvestmentApi/UpvestInvestmentApiClient.cs`. The only constructor is `UpvestInvestmentApiClient(HttpClient httpClient, UpvestInvestmentApiClientOptions options)`.

All `UpvestInvestmentApiClientOptions` properties (source: `src/UpvestInvestmentApi/UpvestInvestmentApiClientOptions.cs`):

| Property | Type |
| --- | --- |
| `Environment` | `ServerEnvironment` |
| `Retry` | `RetryOptions` |
| `Logging` | `LoggingOptions` |
| `TimeProvider` | `TimeProvider` |
| `Server` | `ServerOptions` |
| `StreamReadTimeout` | `TimeSpan?` |
| `Hooks` | `IReadOnlyList<SdkHook>` |
| `OauthClientCredentials` | `OAuth2ClientCredentials?` |

`ServerEnvironment` (source: `src/UpvestInvestmentApi/Servers/ServerEnvironment.cs`, namespace `UpvestInvestmentApi.Servers`)
`OAuth2ClientCredentials` (source: `src/UpvestInvestmentApi/Core/Authentication/OAuth2/ClientCredentials/OAuth2ClientCredentials.cs`, namespace `UpvestInvestmentApi.Core.Authentication.OAuth2.ClientCredentials`)

`RetryOptions` members (namespace `UpvestInvestmentApi.Core.Configuration` — add `using UpvestInvestmentApi.Core.Configuration;`; source: `src/UpvestInvestmentApi/Core/Configuration/RetryOptions.cs`; all members are `required`, so build a full instance or start from `RetryOptions.Default()`):

| Member | Type |
| --- | --- |
| `StatusCodesToRetry` | `IReadOnlyList<HttpStatusCode>` |
| `HttpMethodsToRetry` | `IReadOnlyList<HttpMethod>` |
| `MaxRetries` | `int` |
| `Delay` | `TimeSpan` |
| `Timeout` | `TimeSpan?` |
| `BackOffFactor` | `int` |
| `UseExponentialBackoff` | `bool` |
| `MaxJitter` | `TimeSpan` |
| `OnRetry` | `Action<RetryAttempt>?` |

---

## Error-handling model (read once — applies to every operation)

Operations are **throw-based**. On an error status the SDK throws `ApiException<TError>` (`src/UpvestInvestmentApi/Core/Exceptions/ApiException.cs`, namespace `UpvestInvestmentApi.Core.Exceptions`) exposing `.Error` of type `TError` beside the `StatusCode`, `Headers` and `ContentType` of the response. There are two cases:

- **Case A — typed error.** `TError` is a generated `…Error : ApiError` class (namespace `UpvestInvestmentApi.Errors`) with status-specific `TryGet…(out …)` accessors (each returns `true` when that shape is present) plus the inherited `TryGetRawError([NotNullWhen(true)] out RawError? error)` fallback, and an exhaustive `Match` pair — `Match<TResult>(Func<T, TResult> on{Arm}…, Func<RawError, TResult> otherwise)` and its `Action` twin — with one `on…` arm per accessor, in the ordinal order of their names, and a required `otherwise` that receives the `RawError` of a status the operation does not declare. The operation blocks name the exact `TryGet…` methods and the HTTP status each maps to.
- **Case B — raw error.** `TError` is `RawError` (`src/UpvestInvestmentApi/Core/ErrorResponse/RawError.cs`, namespace `UpvestInvestmentApi.Core.ErrorResponse`): `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?`.

⚠ Each of the three lives in its own namespace. `src/UpvestInvestmentApi/Core/` holds several namespaces, so a catch block naming `ApiException<T>`, a typed `{Operation}Error` and `RawError` together needs a `using` for each.

`ApiException<TError>` is one leaf of the `SdkException` family (`src/UpvestInvestmentApi/Core/Exceptions/SdkException.cs`): a request that produced no usable response surfaces as `SdkConnectionException` or `SdkTimeoutException`, a body that does not match its declared type as `ResponseDeserializationException`, and a required credential that is not configured, or one that could not be applied, as `AuthSchemeException`. Every one of them names the failed call. The full table is in [README → Error Handling](README.md#error-handling).

Core error types (`src/UpvestInvestmentApi/Core/ErrorResponse/`) — public members with their **declared types**, verbatim from source:

| Type | Public members | Source |
| --- | --- | --- |
| `ApiError` — abstract base of the 160 typed error classes in `src/UpvestInvestmentApi/Errors/` | `TryGetRawError([NotNullWhen(true)] out RawError? error): bool` | `src/UpvestInvestmentApi/Core/ErrorResponse/ApiError.cs` |
| `RawError` | `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?` | `src/UpvestInvestmentApi/Core/ErrorResponse/RawError.cs` |

Every accessor over a reference-type payload, on a typed error and on a `OneOf`/`AnyOf` union alike, is `[NotNullWhen(true)] out T?`: read the value inside the `if`, where the compiler has narrowed it; a value-type payload (`long`, `JsonElement`) stays a bare `out`.

Typed-error payload shapes (the `out` types in each operation page's error-accessor cells) are ordinary records/unions — no special handling. The operation's **Type sources** table gives the file that declares each one; read field names, declared types, and JSON wire names there, as for any other model.

```csharp
try
{
    var response = await client.AccessTokens.IssueToken(new IssueTokenRequest
    {
        UpvestApiVersion = UpvestApiVersion._1,
        ClientId = Guid.Parse("363f3305-7ab0-4e82-a158-f9d382ad08b6"),
        ClientSecret = "WHIW1yic-ouct3sceh",
        GrantType = "client_credentials",
        Scope = "users:read",
    });
}
catch (ApiException<IssueTokenError> ex)
{
    // Case A — typed error
    if (ex.Error.TryGetNoContent(out var error))
    {
        // Handle 400, 401, 403, 406, 429, 500, 503, 504
    }
    else if (ex.Error.TryGetRawError(out var raw))
    {
        // Any other error status
    }
}
catch (ApiException<RawError> ex)
{
    // Case B — raw error
    // ex.Error.StatusCode, ex.Error.ReadAsString(), ex.Error.ReadAsJson<T>()
}
```

**No-throw (`…Result`) variants: absent across this SDK** — every operation is throw-only. Of **160 operations**, **160 are Case A (typed)** and **0 are Case B (raw)**.

---

## Operations — by controller (42 groups, 160 operations)

Each links to a sub-page with one row per operation: signature, the request record's required members, query-param wire names (with the serialization style where the spec declares one), return type, error Case A/B, and Case A's typed accessors with their statuses. Each operation also carries a **Type sources** table — every type it names, with the file that declares it — so resolving a body, return, or error payload to its source is a lookup, never a search. `RawError` is excluded there (its members and path are above); an operation with no table names nothing but primitives and `RawError`.

**Each row states what is specific to its operation. Everything below holds for EVERY operation unless that operation's row says otherwise, so a row silent on one of these points is telling you the default here applies — take it and move on rather than opening the source to confirm it.**

| Applies to every operation | Stated where | A row appears only when |
| --- | --- | --- |
| **Throw-only** — no `…Result`/no-throw variant exists anywhere in this SDK | this page, Error-handling model | a no-throw sibling exists (none do at this SDK version) |
| **No pagination** — the operation returns a single response, not a `Pageable` | here | pagination is offered — the block carries a **Pagination** bullet naming the posture (page-, offset-, cursor- or link-based, or the `page`-without-page-size case) |
| **Case B error accessors are always these four** — `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?` | the `RawError` row above | never — a `Case B` label always implies exactly these four; Case A rows list their own typed accessors |
| **Server group `Default`** — base URL per Servers & auth below | here | the operation is on another group — its block carries a **Server group** bullet |
| **Inputs are one request record** — an operation that takes input takes a single request record as its first parameter; build it with an object initializer, using the property names in the record's source (its file is in the operation's **Type sources**). A member the row does not list as required is optional or already carries the spec's default | here | never — it always holds |

**The HTTP verb and route live on the operation itself**, in the source file named at the top of its operations page. This map is method-first: the C# method is the interface you call. When something wire-level needs the route — reproducing a raw request, pointing the client at a mock, reading a provider-side log — read it from that file; do not reconstruct it from memory or infer it from the method name.

**The endpoint's behavioural prose lives there too**, as the XML `<remarks>` on the method. Rows here give you the contract — names, types, shapes, errors. Where an operation's *semantics* decide what you must pass — a parameter whose value changes server-side behaviour, an ordering or exclusivity rule between fields — that is what `<remarks>` settles; read it there rather than filling it in from memory.

| Controller (`client.X`) | Ops | Page |
| --- | --- | --- |
| `AccessTokens` | 1 | [map/operations/AccessTokens.md](map/operations/AccessTokens.md) |
| `AccountGroups` | 6 | [map/operations/AccountGroups.md](map/operations/AccountGroups.md) |
| `AccountsApi` | 7 | [map/operations/AccountsApi.md](map/operations/AccountsApi.md) |
| `BusinessChecks` | 3 | [map/operations/BusinessChecks.md](map/operations/BusinessChecks.md) |
| `Businesses` | 4 | [map/operations/Businesses.md](map/operations/Businesses.md) |
| `CashBalanceTransfers` | 6 | [map/operations/CashBalanceTransfers.md](map/operations/CashBalanceTransfers.md) |
| `CashBalances` | 3 | [map/operations/CashBalances.md](map/operations/CashBalances.md) |
| `CreditFundings` | 3 | [map/operations/CreditFundings.md](map/operations/CreditFundings.md) |
| `DirectDebits` | 3 | [map/operations/DirectDebits.md](map/operations/DirectDebits.md) |
| `Fees` | 3 | [map/operations/Fees.md](map/operations/Fees.md) |
| `FeesConfigurations` | 3 | [map/operations/FeesConfigurations.md](map/operations/FeesConfigurations.md) |
| `Files` | 1 | [map/operations/Files.md](map/operations/Files.md) |
| `Isa` | 3 | [map/operations/Isa.md](map/operations/Isa.md) |
| `Instruments` | 2 | [map/operations/Instruments.md](map/operations/Instruments.md) |
| `Liquidations` | 4 | [map/operations/Liquidations.md](map/operations/Liquidations.md) |
| `Mandates` | 5 | [map/operations/Mandates.md](map/operations/Mandates.md) |
| `Orders` | 5 | [map/operations/Orders.md](map/operations/Orders.md) |
| `Portfolios` | 14 | [map/operations/Portfolios.md](map/operations/Portfolios.md) |
| `PortfoliosRebalancing` | 3 | [map/operations/PortfoliosRebalancing.md](map/operations/PortfoliosRebalancing.md) |
| `Positions` | 2 | [map/operations/Positions.md](map/operations/Positions.md) |
| `PriceData` | 3 | [map/operations/PriceData.md](map/operations/PriceData.md) |
| `ReferenceAccounts` | 5 | [map/operations/ReferenceAccounts.md](map/operations/ReferenceAccounts.md) |
| `Reports` | 4 | [map/operations/Reports.md](map/operations/Reports.md) |
| `Returns` | 1 | [map/operations/Returns.md](map/operations/Returns.md) |
| `Roles` | 4 | [map/operations/Roles.md](map/operations/Roles.md) |
| `SavingsPlans` | 8 | [map/operations/SavingsPlans.md](map/operations/SavingsPlans.md) |
| `SecuritiesTransfers` | 2 | [map/operations/SecuritiesTransfers.md](map/operations/SecuritiesTransfers.md) |
| `TaxExemptions` | 5 | [map/operations/TaxExemptions.md](map/operations/TaxExemptions.md) |
| `TaxResidencies` | 2 | [map/operations/TaxResidencies.md](map/operations/TaxResidencies.md) |
| `Tests` | 1 | [map/operations/Tests.md](map/operations/Tests.md) |
| `TopUps` | 4 | [map/operations/TopUps.md](map/operations/TopUps.md) |
| `TransactionFeesConfigurations` | 4 | [map/operations/TransactionFeesConfigurations.md](map/operations/TransactionFeesConfigurations.md) |
| `TransactionFeesModels` | 3 | [map/operations/TransactionFeesModels.md](map/operations/TransactionFeesModels.md) |
| `Transactions` | 2 | [map/operations/Transactions.md](map/operations/Transactions.md) |
| `UserChecks` | 3 | [map/operations/UserChecks.md](map/operations/UserChecks.md) |
| `UserIdentifiers` | 4 | [map/operations/UserIdentifiers.md](map/operations/UserIdentifiers.md) |
| `Users` | 5 | [map/operations/Users.md](map/operations/Users.md) |
| `Valuations` | 2 | [map/operations/Valuations.md](map/operations/Valuations.md) |
| `VirtualBankAccounts` | 3 | [map/operations/VirtualBankAccounts.md](map/operations/VirtualBankAccounts.md) |
| `VirtualCashBalances` | 3 | [map/operations/VirtualCashBalances.md](map/operations/VirtualCashBalances.md) |
| `WebhookSubscriptions` | 7 | [map/operations/WebhookSubscriptions.md](map/operations/WebhookSubscriptions.md) |
| `Withdrawals` | 4 | [map/operations/Withdrawals.md](map/operations/Withdrawals.md) |

---

## Models — where they live, how to build them

**Shapes live only in the source.** Every file under `src/UpvestInvestmentApi/Models/`, `src/UpvestInvestmentApi/Errors/` and `src/UpvestInvestmentApi/Requests/` declares exactly one public type, named after the file, and no two share a name — so a type name *is* its path. Take it from the operation's **Type sources** table, or build it from the kind's directory below. Never grep for a type.

| Group | Count | Directory (file = `<TypeName>.cs`) |
| --- | --- | --- |
| Records (plain `record` data models) | 335 | `src/UpvestInvestmentApi/Models/` |
| Unions (`AnyOf`) — variant factories + `TryGet…` + `Match` | 48 | `src/UpvestInvestmentApi/Models/AnyOf/` |
| Enums (`OpenStringEnum<T>` / `OpenIntEnum<T>`) — C# member names + wire values | 168 | `src/UpvestInvestmentApi/Models/Enums/` |
| Typed error classes (`: ApiError`, one per Case A operation) | 160 | `src/UpvestInvestmentApi/Errors/` |
| Request records (one per operation that takes input; never serialized) | 160 | `src/UpvestInvestmentApi/Requests/` — a controller's records sit in a folder named after it (an operation with several tags is filed under the first tag it declares) |

Conventions: records are immutable, `init`-only; `required` properties must be set in the object initializer; `T?` is optional. A field's wire name is its `[JsonPropertyName]` and often differs from the C# name (`AmountInCents` ↔ `amount_in_cents`) — read it off the property, don't derive it. `OneOf`/`AnyOf` unions wrap `Optional<T>` variants — build via static factory or implicit conversion, read one variant via `TryGet…(out …)` or branch over all of them with the generated `Match`, which takes one `on{Variant}` handler per variant in declaration order and then `otherwise`, which receives the raw `JsonElement` of a value the SDK could not place: unions are open on read, so an unrecognised discriminator value or a body no variant accepts lands in `TryGetUnknown(out JsonElement)` and re-serializes verbatim; pass handlers by name, and treat an added or moved variant as a breaking change; `AllOf` compositions are not unions — every constituent is a `required` property, so set them all, and those constituent properties carry no `[JsonPropertyName]` and have no wire name of their own, because the generated converter flattens each constituent's own fields directly into the one parent JSON object. Enums are **not** C# enums — use the static members, whose names are PascalCase even when the wire value isn't (`CollectionMethod.Invoice`, not `.invoice`); there is no public factory, so resolve a raw value with `TryGetKnownValue` and branch with the generated `Match`, whose `otherwise` arm receives any value the SDK does not declare.

Namespaces by content type (add `using` accordingly):

| Contents | Namespace |
| --- | --- |
| Client & options (root) | `UpvestInvestmentApi` |
| Operation controllers (`src/UpvestInvestmentApi/Api/`) | `UpvestInvestmentApi.Api` |
| Records (`src/UpvestInvestmentApi/Models/`) | `UpvestInvestmentApi.Models` |
| Enums (`src/UpvestInvestmentApi/Models/Enums/`) | `UpvestInvestmentApi.Models.Enums` |
| AnyOf unions (`src/UpvestInvestmentApi/Models/AnyOf/`) | `UpvestInvestmentApi.Models.AnyOf` |
| Error classes (`src/UpvestInvestmentApi/Errors/`) | `UpvestInvestmentApi.Errors` |
| Request records (`src/UpvestInvestmentApi/Requests/`) | `UpvestInvestmentApi.Requests` — plus `.<Controller>` for a controller's records (an operation with several tags is filed under the first tag it declares) |

---

## Servers & auth

**OAuth2 (client credentials).** Set `options.OauthClientCredentials` with your client id and secret; tokens are fetched from `https://sandbox.upvest.co/auth/token`.

Operation blocks name their credential in an **Auth** bullet; an operation whose spec declares no scheme carries no such bullet.

- `AND` — every credential listed must be configured; the call fails before anything is sent, naming each one that is not.
- `OR` — the first configured credential that applies is sent, in the order listed; a configured one that fails falls through to the next; when none is configured the call fails before anything is sent, naming all of them.
- `OR anonymous` — the operation accepts anonymous callers: it is authenticated when a whole alternative listed before it is configured (every credential in an AND group), and sent without credentials otherwise.
- `(scopes: …)` — the OAuth2 scopes the operation's token is requested with; a client-credentials scheme mints one token per scope set.

A required credential you never configured fails the call with `AuthSchemeException` before anything is sent, so a `401` on an operation that requires a credential means the server rejected the one that was sent. A credential option left `null` is read from an environment variable when the client is constructed; the README's **Credentials from environment variables** table names them. A value set in code always wins, including the placeholder assignments in the **Getting a client** sample; delete the line for any credential you supply through an environment variable.

**Environments.** `options.Environment` selects the target environment (`src/UpvestInvestmentApi/Servers/ServerEnvironment.cs`):

| Environment | Value | Hosting |
| --- | --- | --- |
| `ServerEnvironment.Production` *(default)* | `production` | Sandbox environment |
| `ServerEnvironment.Environment2` | `environment2` | Live environment |

**1 server group.** Base-URL templates and override points (`options.Server.…`):

| Group | `Production` base URL | `Environment2` base URL | Override point |
| --- | --- | --- | --- |
| `Default` | `https://sandbox.upvest.co` | `https://api.upvest.co` | `options.Server.Default.Production.BaseUrl` (and the other environments) |

Retry/resilience is configurable via `options.Retry` (`RetryOptions`, backed by Polly).

