<!-- Generated file — do not edit; regenerated with the SDK. -->

# Valuations — operations

Accessor: `client.Valuations` · Source: `src/UpvestInvestmentApi/Api/Valuations.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### GetAccountValuation

- **Auth**: `options.OauthClientCredentials` (scopes: `valuations:read`)
- **Signature**: `GetAccountValuation(GetAccountValuationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`, `PriceQuality`
- **Query params (wire ← C#)**: `price_quality` ← `PriceQuality`
- **Returns**: `AccountValuation`
- **Error**: `ApiException<GetAccountValuationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `GetAccountValuationRequest` | `src/UpvestInvestmentApi/Requests/Valuations/GetAccountValuationRequest.cs` |
| `PriceQuality3` | `src/UpvestInvestmentApi/Models/Enums/PriceQuality3.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountValuation` | `src/UpvestInvestmentApi/Models/AccountValuation.cs` |
| `GetAccountValuationError` | `src/UpvestInvestmentApi/Errors/GetAccountValuationError.cs` |

### ListAccountValuationHistory

- **Auth**: `options.OauthClientCredentials` (scopes: `valuations:read`)
- **Signature**: `ListAccountValuationHistory(ListAccountValuationHistoryRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Query params (wire ← C#)**: `start_date` ← `StartDate`, `end_date` ← `EndDate`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountValuationListResponse`
- **Error**: `ApiException<ListAccountValuationHistoryError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAccountValuationHistoryRequest` | `src/UpvestInvestmentApi/Requests/Valuations/ListAccountValuationHistoryRequest.cs` |
| `Sort29` | `src/UpvestInvestmentApi/Models/Enums/Sort29.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountValuationListResponse` | `src/UpvestInvestmentApi/Models/AccountValuationListResponse.cs` |
| `ListAccountValuationHistoryError` | `src/UpvestInvestmentApi/Errors/ListAccountValuationHistoryError.cs` |

