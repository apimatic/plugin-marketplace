<!-- Generated file — do not edit; regenerated with the SDK. -->

# Withdrawals — operations

Accessor: `client.Withdrawals` · Source: `src/UpvestInvestmentApi/Api/Withdrawals.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelCashWithdrawal

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`)
- **Signature**: `CancelCashWithdrawal(CancelCashWithdrawalRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WithdrawalId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelCashWithdrawalError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 422, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelCashWithdrawalRequest` | `src/UpvestInvestmentApi/Requests/Withdrawals/CancelCashWithdrawalRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CancelCashWithdrawalError` | `src/UpvestInvestmentApi/Errors/CancelCashWithdrawalError.cs` |

### CreateCashWithdrawal

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`)
- **Signature**: `CreateCashWithdrawal(CreateCashWithdrawalRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PaymentsWithdrawal`
- **Error**: `ApiException<CreateCashWithdrawalError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateCashWithdrawalRequest` | `src/UpvestInvestmentApi/Requests/Withdrawals/CreateCashWithdrawalRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsWithdrawalCreateRequest` | `src/UpvestInvestmentApi/Models/PaymentsWithdrawalCreateRequest.cs` |
| `PaymentsWithdrawal` | `src/UpvestInvestmentApi/Models/PaymentsWithdrawal.cs` |
| `CreateCashWithdrawalError` | `src/UpvestInvestmentApi/Errors/CreateCashWithdrawalError.cs` |

### ListCashWithdrawals

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`, `payments:read`)
- **Signature**: `ListCashWithdrawals(ListCashWithdrawalsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `WithdrawalsListResponse`
- **Error**: `ApiException<ListCashWithdrawalsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListCashWithdrawalsRequest` | `src/UpvestInvestmentApi/Requests/Withdrawals/ListCashWithdrawalsRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `WithdrawalsListResponse` | `src/UpvestInvestmentApi/Models/WithdrawalsListResponse.cs` |
| `ListCashWithdrawalsError` | `src/UpvestInvestmentApi/Errors/ListCashWithdrawalsError.cs` |

### RetrieveCashWithdrawal

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`, `payments:read`)
- **Signature**: `RetrieveCashWithdrawal(RetrieveCashWithdrawalRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WithdrawalId`
- **Returns**: `PaymentsWithdrawal`
- **Error**: `ApiException<RetrieveCashWithdrawalError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveCashWithdrawalRequest` | `src/UpvestInvestmentApi/Requests/Withdrawals/RetrieveCashWithdrawalRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsWithdrawal` | `src/UpvestInvestmentApi/Models/PaymentsWithdrawal.cs` |
| `RetrieveCashWithdrawalError` | `src/UpvestInvestmentApi/Errors/RetrieveCashWithdrawalError.cs` |

