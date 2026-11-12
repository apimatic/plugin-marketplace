<!-- Generated file — do not edit; regenerated with the SDK. -->

# TransactionFeesModels — operations

Accessor: `client.TransactionFeesModels` · Source: `src/UpvestInvestmentApi/Api/TransactionFeesModels.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateTransactionFeeModel

- **Auth**: `options.OauthClientCredentials` (scopes: `transaction_fees:admin`)
- **Signature**: `CreateTransactionFeeModel(CreateTransactionFeeModelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `FeeConfiguration`
- **Error**: `ApiException<CreateTransactionFeeModelError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateTransactionFeeModelRequest` | `src/UpvestInvestmentApi/Requests/TransactionFeesModels/CreateTransactionFeeModelRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeConfigurationCreateRequest` | `src/UpvestInvestmentApi/Models/FeeConfigurationCreateRequest.cs` |
| `FeeConfiguration` | `src/UpvestInvestmentApi/Models/FeeConfiguration.cs` |
| `CreateTransactionFeeModelError` | `src/UpvestInvestmentApi/Errors/CreateTransactionFeeModelError.cs` |

### ListTransactionFeeModels

- **Auth**: `options.OauthClientCredentials` (scopes: `transaction_fees:admin`, `transaction_fees:read`)
- **Signature**: `ListTransactionFeeModels(ListTransactionFeeModelsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `TransactionFeeModelsListResponse`
- **Error**: `ApiException<ListTransactionFeeModelsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListTransactionFeeModelsRequest` | `src/UpvestInvestmentApi/Requests/TransactionFeesModels/ListTransactionFeeModelsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TransactionFeeModelsListResponse` | `src/UpvestInvestmentApi/Models/TransactionFeeModelsListResponse.cs` |
| `ListTransactionFeeModelsError` | `src/UpvestInvestmentApi/Errors/ListTransactionFeeModelsError.cs` |

### RetrieveTransactionFeeModel

- **Auth**: `options.OauthClientCredentials` (scopes: `transaction_fees:admin`, `transaction_fees:read`)
- **Signature**: `RetrieveTransactionFeeModel(RetrieveTransactionFeeModelRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TransactionFeeModelId`
- **Returns**: `FeeConfiguration`
- **Error**: `ApiException<RetrieveTransactionFeeModelError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveTransactionFeeModelRequest` | `src/UpvestInvestmentApi/Requests/TransactionFeesModels/RetrieveTransactionFeeModelRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeConfiguration` | `src/UpvestInvestmentApi/Models/FeeConfiguration.cs` |
| `RetrieveTransactionFeeModelError` | `src/UpvestInvestmentApi/Errors/RetrieveTransactionFeeModelError.cs` |

