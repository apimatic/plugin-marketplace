# SDK map — visa (.NET)

> A generated table-of-contents for this SDK. Consult this map and its sub-pages to learn signatures, error
> types, enum values, and server/auth wiring **by lookup** — open a source file only for a full method/model
> body the map doesn't carry. The compiler is the backstop: a wrong name fails to build.

| | |
|---|---|
| SDK display name | CyberSource Merged Spec |
| Root namespace/module | `CyberSourceMergedSpec` |
<!-- gen:stamp -->
| NuGet package | `APIMatic.VisaCyberSource` |
| Target framework(s) | `netstandard2.0` (C# `LangVersion 14`, `Nullable enable`) |
| Source commit (spec stamp) | `bbc9181` (`bbc9181f5a7d2a3e1cfd85130ce997a8d4c5088f`, tagged `v2.0.1`) |
<!-- /gen:stamp -->
| Generator | APIMatic |
| Repo | https://github.com/asadali214/visa-cybersource-sample-sdk (tag `v2.0.0`) |

Staleness check: if the SDK is regenerated, the source commit stamp above changes (the SDK repo and this
plugin regenerate together). If a lookup here fails to compile, trust the compiler and re-read the source
file linked in the row.

---

## Getting a client

```csharp
using CyberSourceMergedSpec;
using CyberSourceMergedSpec.Servers; // ServerEnvironment lives here

var options = new CyberSourceMergedSpecClientOptions
{
    // Set the credentials properties for the scheme(s) this API uses — see Servers & auth below.
    // Environment selects the server environment; see Servers & auth below.
};
var client = new CyberSourceMergedSpecClient(httpClient, options); // httpClient: System.Net.Http.HttpClient
```

DI alternative (`ServiceCollectionExtensions.cs`):

```csharp
services.AddCyberSourceMergedSpecClient(o =>
{
    // set credentials / environment on o here
});
```

Every API group is a property on the client (e.g. `client.Orders`). Source:
`CyberSourceMergedSpecClient.cs`.

<!-- gen:client-options -->
All `CyberSourceMergedSpecClientOptions` properties (source: `CyberSourceMergedSpecClientOptions.cs`):

| Property | Type |
|---|---|
| `Environment` | `ServerEnvironment` |
| `Retry` | `RetryOptions` |
| `Logging` | `LoggingOptions` |
| `Server` | `ServerOptions` |
| `Hooks` | `IReadOnlyList<SdkHook>` |

`RetryOptions` members (source: `Core/Configuration/RetryOptions.cs`; build a full instance — all members are `required` — or start from `RetryOptions.Default()`):

| Member | Type |
|---|---|
| `StatusCodesToRetry` | `IReadOnlyList<HttpStatusCode>` |
| `HttpMethodsToRetry` | `IReadOnlyList<HttpMethod>` |
| `MaxRetries` | `int` |
| `Delay` | `TimeSpan` |
| `Timeout` | `TimeSpan?` |
| `BackOffFactor` | `int` |
| `UseExponentialBackoff` | `bool` |
| `MaxJitter` | `TimeSpan` |
| `OnRetry` | `Action<RetryAttempt>?` |

Client constructor(s):

- `CyberSourceMergedSpecClient(HttpClient httpClient, CyberSourceMergedSpecClientOptions options)`
<!-- /gen:client-options -->

---

## Error-handling model (read once — applies to every operation)

Operations are **throw-based**. On an error status the SDK throws `SdkException<TError>`
(`Core/Exceptions/SdkException.cs`) exposing `.Error` of type `TError`. There are two cases:

- **Case A — typed error.** `TError` is a generated `…Error : ApiError` class with status-specific
  `TryGet…(out …)` accessors (returns `true` when that shape is present) plus the inherited
  `TryGetRawError(out RawError)` fallback. The per-operation rows name the exact `TryGet…` methods and the HTTP
  status each maps to.
- **Case B — raw error.** `TError` is `RawError` (`Core/ErrorResponse/RawError.cs`): `StatusCode`,
  `ReadAsString()`, `ReadAsJson<T>()`, `ReadAsBytes()`.

<!-- gen:error-core -->
Core error types (`Core/ErrorResponse/`) — public members with their **declared types**, verbatim from source:

| Type | Public members | Source |
|---|---|---|
| `ApiError` — abstract base of all 127 typed error classes in `Errors/` | `TryGetRawError(out RawError error): bool` | `Core/ErrorResponse/ApiError.cs` |
| `RawError` | `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?` | `Core/ErrorResponse/RawError.cs` |

Typed-error payload shapes (the `out` types in each operation page's error-accessor cells) are ordinary records/unions: field names, declared types, and JSON wire names live on the records pages / `unions.md` like any other model.
<!-- /gen:error-core -->

```csharp
try { var resp = await client.{ApiGroup}.{Operation}(body); }
catch (SdkException<{Operation}Error> ex)              // Case A
{
    if (ex.Error.TryGetSomeShape(out var typed))      { /* handle that status */ }
    else if (ex.Error.TryGetRawError(out var raw))    { /* other statuses */ }
}
catch (SdkException<RawError> ex)                     // Case B
{
    var status = ex.Error.StatusCode;
    var body   = ex.Error.ReadAsString();
}
```

<!-- gen:op-stats -->
**No-throw ("`…Result`") variants: absent across this SDK** — every operation is throw-only.
Of **135 operations**, **127 are Case A (typed)** and **8 are Case B (raw)**.
<!-- /gen:op-stats -->

---

## Operations — by controller (49 groups, 135 operations)

Each links to a sub-page with one row per operation (HTTP, signature with must-pass-explicitly params, return
type, error Case A/B + accessors, pagination).

<!-- gen:ops-table -->
| Controller (`client.X`) | Ops | Page |
|---|---:|---|
| `BillingAgreements` | 3 | [map/operations/BillingAgreements.md](map/operations/BillingAgreements.md) |
| `BinLookup` | 1 | [map/operations/BinLookup.md](map/operations/BinLookup.md) |
| `CaptureApi` | 1 | [map/operations/CaptureApi.md](map/operations/CaptureApi.md) |
| `ChargebackDetails` | 1 | [map/operations/ChargebackDetails.md](map/operations/ChargebackDetails.md) |
| `ChargebackSummaries` | 1 | [map/operations/ChargebackSummaries.md](map/operations/ChargebackSummaries.md) |
| `ConversionDetails` | 1 | [map/operations/ConversionDetails.md](map/operations/ConversionDetails.md) |
| `Credit` | 1 | [map/operations/Credit.md](map/operations/Credit.md) |
| `CustomerApi` | 4 | [map/operations/CustomerApi.md](map/operations/CustomerApi.md) |
| `CustomerPaymentInstrument` | 5 | [map/operations/CustomerPaymentInstrument.md](map/operations/CustomerPaymentInstrument.md) |
| `CustomerShippingAddress` | 5 | [map/operations/CustomerShippingAddress.md](map/operations/CustomerShippingAddress.md) |
| `DecisionManager` | 5 | [map/operations/DecisionManager.md](map/operations/DecisionManager.md) |
| `DownloadDtd` | 1 | [map/operations/DownloadDtd.md](map/operations/DownloadDtd.md) |
| `DownloadXsd` | 1 | [map/operations/DownloadXsd.md](map/operations/DownloadXsd.md) |
| `InstrumentIdentifierApi` | 6 | [map/operations/InstrumentIdentifierApi.md](map/operations/InstrumentIdentifierApi.md) |
| `InterchangeClearingLevelDetails` | 1 | [map/operations/InterchangeClearingLevelDetails.md](map/operations/InterchangeClearingLevelDetails.md) |
| `InvoiceSettings` | 2 | [map/operations/InvoiceSettings.md](map/operations/InvoiceSettings.md) |
| `Invoices` | 7 | [map/operations/Invoices.md](map/operations/Invoices.md) |
| `MerchantDefinedFields` | 4 | [map/operations/MerchantDefinedFields.md](map/operations/MerchantDefinedFields.md) |
| `MicroformIntegration` | 1 | [map/operations/MicroformIntegration.md](map/operations/MicroformIntegration.md) |
| `NetFundings` | 1 | [map/operations/NetFundings.md](map/operations/NetFundings.md) |
| `NetworkTokens` | 7 | [map/operations/NetworkTokens.md](map/operations/NetworkTokens.md) |
| `NotificationOfChanges` | 1 | [map/operations/NotificationOfChanges.md](map/operations/NotificationOfChanges.md) |
| `Orders` | 2 | [map/operations/Orders.md](map/operations/Orders.md) |
| `PayerAuthentication` | 3 | [map/operations/PayerAuthentication.md](map/operations/PayerAuthentication.md) |
| `PaymentBatchSummaries` | 1 | [map/operations/PaymentBatchSummaries.md](map/operations/PaymentBatchSummaries.md) |
| `PaymentInstrumentApi` | 4 | [map/operations/PaymentInstrumentApi.md](map/operations/PaymentInstrumentApi.md) |
| `PaymentTokens` | 1 | [map/operations/PaymentTokens.md](map/operations/PaymentTokens.md) |
| `Payments` | 6 | [map/operations/Payments.md](map/operations/Payments.md) |
| `Payouts` | 1 | [map/operations/Payouts.md](map/operations/Payouts.md) |
| `Plans` | 8 | [map/operations/Plans.md](map/operations/Plans.md) |
| `PullFundsApi` | 3 | [map/operations/PullFundsApi.md](map/operations/PullFundsApi.md) |
| `PurchaseAndRefundDetails` | 1 | [map/operations/PurchaseAndRefundDetails.md](map/operations/PurchaseAndRefundDetails.md) |
| `RefundApi` | 2 | [map/operations/RefundApi.md](map/operations/RefundApi.md) |
| `ReportDefinitions` | 2 | [map/operations/ReportDefinitions.md](map/operations/ReportDefinitions.md) |
| `ReportDownloads` | 1 | [map/operations/ReportDownloads.md](map/operations/ReportDownloads.md) |
| `ReportSubscriptions` | 5 | [map/operations/ReportSubscriptions.md](map/operations/ReportSubscriptions.md) |
| `Reports` | 3 | [map/operations/Reports.md](map/operations/Reports.md) |
| `RetrievalDetails` | 1 | [map/operations/RetrievalDetails.md](map/operations/RetrievalDetails.md) |
| `RetrievalSummaries` | 1 | [map/operations/RetrievalSummaries.md](map/operations/RetrievalSummaries.md) |
| `ReversalApi` | 2 | [map/operations/ReversalApi.md](map/operations/ReversalApi.md) |
| `SearchTransactions` | 2 | [map/operations/SearchTransactions.md](map/operations/SearchTransactions.md) |
| `SecureFileShare` | 2 | [map/operations/SecureFileShare.md](map/operations/SecureFileShare.md) |
| `Subscriptions` | 10 | [map/operations/Subscriptions.md](map/operations/Subscriptions.md) |
| `SubscriptionsFollowOns` | 2 | [map/operations/SubscriptionsFollowOns.md](map/operations/SubscriptionsFollowOns.md) |
| `Tokenize` | 1 | [map/operations/Tokenize.md](map/operations/Tokenize.md) |
| `TransactionBatches` | 3 | [map/operations/TransactionBatches.md](map/operations/TransactionBatches.md) |
| `TransactionDetailsApi` | 1 | [map/operations/TransactionDetailsApi.md](map/operations/TransactionDetailsApi.md) |
| `Verification` | 2 | [map/operations/Verification.md](map/operations/Verification.md) |
| `VoidApi` | 5 | [map/operations/VoidApi.md](map/operations/VoidApi.md) |
<!-- /gen:ops-table -->

---

## Models

<!-- gen:models-table -->
| Group | Count | Page |
|---|---:|---|
| Records (plain `record` data models) | 1972 | [`Account` … `BillTo69`](map/models/records-1-Ac-Bi.md) · [`BillTo7` … `CreateBinLookupRequest`](map/models/records-2-Bi-Cr.md) · [`CreateBundledDecisionManagerCaseRequest` … `ExportComplianceWatchList`](map/models/records-3-Cr-Ex.md) · [`Features` … `Invoice1`](map/models/records-4-Fe-In.md) · [`InvoiceDetails` … `MerchantDefinedInformation7`](map/models/records-5-In-Me.md) · [`MerchantDefinedSecureInformation` … `PaymentInformation42`](map/models/records-6-Me-Pa.md) · [`PaymentInformation43` … `ProcessingInformation68`](map/models/records-7-Pa-Pr.md) · [`ProcessingInformation69` … `PtsV2RetrievePaymentTokenGet502Response1`](map/models/records-8-Pr-Pt.md) · [`PtsV2ReversalsPost201Response` … `RewardPointsDetails`](map/models/records-9-Pt-Re.md) · [`RiskAddressVerificationInformation` … `TokenizedCard`](map/models/records-10-Ri-To.md) · [`TokenizedCard1` … `Weights`](map/models/records-11-To-We.md) |
| Unions (`OneOf` / `AnyOf`) — variant factories + `TryGet…` | 0 + 0 | [map/models/unions.md](map/models/unions.md) |
| Enums (`StringEnum<T>` / `IntEnum<T>`) — literal C# member names + wire values | 12 | [map/models/enums.md](map/models/enums.md) |
<!-- /gen:models-table -->

Model conventions: records are immutable with `init`-only setters; `required` properties must be set in the
object initializer; nullable (`T?`) properties are optional. Each record field is listed as
`CSharpName (wire_name): Type` — the parenthesized name is the JSON wire name (`[JsonPropertyName]`).
Unions wrap `Optional<T>` variants — construct via a static factory or implicit
conversion, read back via `TryGet…(out …)`. Enums are **not** C# enums — build with `Type.FromValue("wire")`
or the static members (enums.md lists the literal member names: `SomeEnum.SomeMember`, not
`SomeEnum.some_member`).

<!-- gen:namespaces -->
Namespaces by content type (add `using` accordingly):

| Contents | Namespace(s) |
|---|---|
| Client & options (root) | `CyberSourceMergedSpec` |
| Operation controllers (`Api/`) | `CyberSourceMergedSpec.Api` |
| Records (`Models/`) | `CyberSourceMergedSpec.Models` |
| Enums (`Models/Enums/`) | `CyberSourceMergedSpec.Models.Enums` |
| Error classes (`Errors/`) | `CyberSourceMergedSpec.Errors` |
<!-- /gen:namespaces -->

---

## Servers & auth

<!-- gen:servers-auth -->
**Auth.** The scheme(s) this API uses surface as credentials properties on `CyberSourceMergedSpecClientOptions` (source: `CyberSourceMergedSpecClientOptions.cs`) — set them before constructing the client; load `dotnet-authentication` for the wiring:

This SDK's client options expose no credentials property, and the merged spec declares no security scheme, so **nothing is generated into the `IAuthScheme` pipeline**. The API is **not** unauthenticated: every call is signed by an opt-in **HTTP Signature** `SdkHook` that is appended at client construction when its environment variables resolve. Load `dotnet-authentication` — it documents that hook and is the only auth route this SDK has.

**Environments.** `options.Environment` is a `ServerEnvironment` (`Servers/ServerEnvironment.cs`) with members: `ServerEnvironment.Production`. Base-URL templates and override points live under `Servers/` and `options.Server`.
<!-- /gen:servers-auth -->

> ⚠ **The `gen:servers-auth` block above carries one deliberate HAND EDIT.** The generator emits
> “the API is unauthenticated, or auth travels by another route” for any SDK with no credentials
> property. For this SDK the first half of that is false and would mislead — auth is the HTTP
> Signature hook. The generator cannot know that, so the sentence was corrected by hand.
> **Re-running `sdk-map-generator` WILL overwrite it — reapply this edit afterwards.**
