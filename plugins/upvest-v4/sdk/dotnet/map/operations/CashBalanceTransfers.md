<!-- Generated file — do not edit; regenerated with the SDK. -->

# CashBalanceTransfers — operations

Accessor: `client.CashBalanceTransfers` · Source: `src/UpvestInvestmentApi/Api/CashBalanceTransfers.cs` · 6 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelCashBalanceTransfer

- **Auth**: `options.OauthClientCredentials` (scopes: `cash_balance_transfers:admin`)
- **Signature**: `CancelCashBalanceTransfer(CancelCashBalanceTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CashBalanceTransferId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelCashBalanceTransferError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 422, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelCashBalanceTransferRequest` | `src/UpvestInvestmentApi/Requests/CashBalanceTransfers/CancelCashBalanceTransferRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CancelCashBalanceTransferError` | `src/UpvestInvestmentApi/Errors/CancelCashBalanceTransferError.cs` |

### CreateCashBalanceTransfer

- **Auth**: `options.OauthClientCredentials` (scopes: `cash_balance_transfers:admin`)
- **Signature**: `CreateCashBalanceTransfer(CreateCashBalanceTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PaymentsCashBalanceTransfer`
- **Error**: `ApiException<CreateCashBalanceTransferError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateCashBalanceTransferRequest` | `src/UpvestInvestmentApi/Requests/CashBalanceTransfers/CreateCashBalanceTransferRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsCashBalanceTransferCreateRequest` | `src/UpvestInvestmentApi/Models/PaymentsCashBalanceTransferCreateRequest.cs` |
| `PaymentsCashBalanceTransfer` | `src/UpvestInvestmentApi/Models/PaymentsCashBalanceTransfer.cs` |
| `CreateCashBalanceTransferError` | `src/UpvestInvestmentApi/Errors/CreateCashBalanceTransferError.cs` |

### ListBusinessCashBalanceTransfers

- **Auth**: `options.OauthClientCredentials` (scopes: `cash_balance_transfers:admin`, `cash_balance_transfers:read`)
- **Signature**: `ListBusinessCashBalanceTransfers(ListBusinessCashBalanceTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `BusinessCashBalanceTransfersListResponse`
- **Error**: `ApiException<ListBusinessCashBalanceTransfersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessCashBalanceTransfersRequest` | `src/UpvestInvestmentApi/Requests/CashBalanceTransfers/ListBusinessCashBalanceTransfersRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessCashBalanceTransfersListResponse` | `src/UpvestInvestmentApi/Models/BusinessCashBalanceTransfersListResponse.cs` |
| `ListBusinessCashBalanceTransfersError` | `src/UpvestInvestmentApi/Errors/ListBusinessCashBalanceTransfersError.cs` |

### ListCashBalanceTransfers

- **Auth**: `options.OauthClientCredentials` (scopes: `cash_balance_transfers:admin`, `cash_balance_transfers:read`)
- **Signature**: `ListCashBalanceTransfers(ListCashBalanceTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `CashBalanceTransfersListResponse`
- **Error**: `ApiException<ListCashBalanceTransfersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListCashBalanceTransfersRequest` | `src/UpvestInvestmentApi/Requests/CashBalanceTransfers/ListCashBalanceTransfersRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CashBalanceTransfersListResponse` | `src/UpvestInvestmentApi/Models/CashBalanceTransfersListResponse.cs` |
| `ListCashBalanceTransfersError` | `src/UpvestInvestmentApi/Errors/ListCashBalanceTransfersError.cs` |

### ListUserCashBalanceTransfers

- **Auth**: `options.OauthClientCredentials` (scopes: `cash_balance_transfers:admin`, `cash_balance_transfers:read`)
- **Signature**: `ListUserCashBalanceTransfers(ListUserCashBalanceTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `UserCashBalanceTransfersListResponse`
- **Error**: `ApiException<ListUserCashBalanceTransfersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListUserCashBalanceTransfersRequest` | `src/UpvestInvestmentApi/Requests/CashBalanceTransfers/ListUserCashBalanceTransfersRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `UserCashBalanceTransfersListResponse` | `src/UpvestInvestmentApi/Models/UserCashBalanceTransfersListResponse.cs` |
| `ListUserCashBalanceTransfersError` | `src/UpvestInvestmentApi/Errors/ListUserCashBalanceTransfersError.cs` |

### RetrieveCashBalanceTransfer

- **Auth**: `options.OauthClientCredentials` (scopes: `cash_balance_transfers:admin`, `cash_balance_transfers:read`)
- **Signature**: `RetrieveCashBalanceTransfer(RetrieveCashBalanceTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CashBalanceTransferId`
- **Returns**: `PaymentsCashBalanceTransfer`
- **Error**: `ApiException<RetrieveCashBalanceTransferError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveCashBalanceTransferRequest` | `src/UpvestInvestmentApi/Requests/CashBalanceTransfers/RetrieveCashBalanceTransferRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsCashBalanceTransfer` | `src/UpvestInvestmentApi/Models/PaymentsCashBalanceTransfer.cs` |
| `RetrieveCashBalanceTransferError` | `src/UpvestInvestmentApi/Errors/RetrieveCashBalanceTransferError.cs` |

