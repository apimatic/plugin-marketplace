<!-- Generated file — do not edit; regenerated with the SDK. -->

# Transactions — operations

Accessor: `client.Transactions` · Source: `src/UpvestInvestmentApi/Api/Transactions.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListCashTransactions

- **Auth**: `options.OauthClientCredentials` (scopes: `transactions:read`)
- **Signature**: `ListCashTransactions(ListCashTransactionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `account_group_id` ← `AccountGroupId`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `CashTransactionListResponse`
- **Error**: `ApiException<ListCashTransactionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListCashTransactionsRequest` | `src/UpvestInvestmentApi/Requests/Transactions/ListCashTransactionsRequest.cs` |
| `Sort30` | `src/UpvestInvestmentApi/Models/Enums/Sort30.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CashTransactionListResponse` | `src/UpvestInvestmentApi/Models/CashTransactionListResponse.cs` |
| `ListCashTransactionsError` | `src/UpvestInvestmentApi/Errors/ListCashTransactionsError.cs` |

### ListSecuritiesTransactions

- **Auth**: `options.OauthClientCredentials` (scopes: `transactions:read`)
- **Signature**: `ListSecuritiesTransactions(ListSecuritiesTransactionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `account_group_id` ← `AccountGroupId`, `account_id` ← `AccountId`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `SecurityTransactionListResponse`
- **Error**: `ApiException<ListSecuritiesTransactionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListSecuritiesTransactionsRequest` | `src/UpvestInvestmentApi/Requests/Transactions/ListSecuritiesTransactionsRequest.cs` |
| `Sort30` | `src/UpvestInvestmentApi/Models/Enums/Sort30.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SecurityTransactionListResponse` | `src/UpvestInvestmentApi/Models/SecurityTransactionListResponse.cs` |
| `ListSecuritiesTransactionsError` | `src/UpvestInvestmentApi/Errors/ListSecuritiesTransactionsError.cs` |

