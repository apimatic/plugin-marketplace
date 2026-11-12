<!-- Generated file — do not edit; regenerated with the SDK. -->

# Isa — operations

Accessor: `client.Isa` · Source: `src/UpvestInvestmentApi/Api/Isa.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateIsaTransfer

- **Auth**: `options.OauthClientCredentials` (scopes: `isa:admin`)
- **Signature**: `CreateIsaTransfer(CreateIsaTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `IsaTransfersResponse`
- **Error**: `ApiException<CreateIsaTransferError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateIsaTransferRequest` | `src/UpvestInvestmentApi/Requests/Isa/CreateIsaTransferRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxWrappersIsaCreateIsaTransferRequest` | `src/UpvestInvestmentApi/Models/TaxWrappersIsaCreateIsaTransferRequest.cs` |
| `IsaTransfersResponse` | `src/UpvestInvestmentApi/Models/IsaTransfersResponse.cs` |
| `CreateIsaTransferError` | `src/UpvestInvestmentApi/Errors/CreateIsaTransferError.cs` |

### CreateIsaWrapper

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`, `isa:admin`)
- **Signature**: `CreateIsaWrapper(CreateIsaWrapperRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `TaxWrappersIsaIsaWrapper`
- **Error**: `ApiException<CreateIsaWrapperError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateIsaWrapperRequest` | `src/UpvestInvestmentApi/Requests/Isa/CreateIsaWrapperRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxWrappersIsaCreateIsaWrapperRequest` | `src/UpvestInvestmentApi/Models/TaxWrappersIsaCreateIsaWrapperRequest.cs` |
| `TaxWrappersIsaIsaWrapper` | `src/UpvestInvestmentApi/Models/TaxWrappersIsaIsaWrapper.cs` |
| `CreateIsaWrapperError` | `src/UpvestInvestmentApi/Errors/CreateIsaWrapperError.cs` |

### RetrieveIsaAllowances

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`, `isa:admin`)
- **Signature**: `RetrieveIsaAllowances(RetrieveIsaAllowancesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TaxWrapperId`
- **Query params (wire ← C#)**: `tax_year` ← `TaxYear`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `TaxWrappersIsaRetrieveIsaAllowancesResponse`
- **Error**: `ApiException<RetrieveIsaAllowancesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveIsaAllowancesRequest` | `src/UpvestInvestmentApi/Requests/Isa/RetrieveIsaAllowancesRequest.cs` |
| `Sort21` | `src/UpvestInvestmentApi/Models/Enums/Sort21.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxWrappersIsaRetrieveIsaAllowancesResponse` | `src/UpvestInvestmentApi/Models/TaxWrappersIsaRetrieveIsaAllowancesResponse.cs` |
| `RetrieveIsaAllowancesError` | `src/UpvestInvestmentApi/Errors/RetrieveIsaAllowancesError.cs` |

