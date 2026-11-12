<!-- Generated file — do not edit; regenerated with the SDK. -->

# VirtualCashBalances — operations

Accessor: `client.VirtualCashBalances` · Source: `src/UpvestInvestmentApi/Api/VirtualCashBalances.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelVirtualCashDecrease

- **Auth**: `options.OauthClientCredentials` (scopes: `virtual_cash_balances:admin`)
- **Signature**: `CancelVirtualCashDecrease(CancelVirtualCashDecreaseRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `VirtualCashDecreaseId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelVirtualCashDecreaseError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 422, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelVirtualCashDecreaseRequest` | `src/UpvestInvestmentApi/Requests/VirtualCashBalances/CancelVirtualCashDecreaseRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CancelVirtualCashDecreaseError` | `src/UpvestInvestmentApi/Errors/CancelVirtualCashDecreaseError.cs` |

### CreateVirtualCashDecrease

- **Auth**: `options.OauthClientCredentials` (scopes: `virtual_cash_balances:admin`)
- **Signature**: `CreateVirtualCashDecrease(CreateVirtualCashDecreaseRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `VirtualCashBalanceVirtualCashDecrease`
- **Error**: `ApiException<CreateVirtualCashDecreaseError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateVirtualCashDecreaseRequest` | `src/UpvestInvestmentApi/Requests/VirtualCashBalances/CreateVirtualCashDecreaseRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `VirtualCashBalanceVirtualCashDecreaseCreateRequest` | `src/UpvestInvestmentApi/Models/VirtualCashBalanceVirtualCashDecreaseCreateRequest.cs` |
| `VirtualCashBalanceVirtualCashDecrease` | `src/UpvestInvestmentApi/Models/VirtualCashBalanceVirtualCashDecrease.cs` |
| `CreateVirtualCashDecreaseError` | `src/UpvestInvestmentApi/Errors/CreateVirtualCashDecreaseError.cs` |

### CreateVirtualCashIncrease

- **Auth**: `options.OauthClientCredentials` (scopes: `virtual_cash_balances:admin`)
- **Signature**: `CreateVirtualCashIncrease(CreateVirtualCashIncreaseRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `VirtualCashBalanceVirtualCashIncrease`
- **Error**: `ApiException<CreateVirtualCashIncreaseError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateVirtualCashIncreaseRequest` | `src/UpvestInvestmentApi/Requests/VirtualCashBalances/CreateVirtualCashIncreaseRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `VirtualCashBalanceVirtualCashIncreaseCreateRequest` | `src/UpvestInvestmentApi/Models/VirtualCashBalanceVirtualCashIncreaseCreateRequest.cs` |
| `VirtualCashBalanceVirtualCashIncrease` | `src/UpvestInvestmentApi/Models/VirtualCashBalanceVirtualCashIncrease.cs` |
| `CreateVirtualCashIncreaseError` | `src/UpvestInvestmentApi/Errors/CreateVirtualCashIncreaseError.cs` |

