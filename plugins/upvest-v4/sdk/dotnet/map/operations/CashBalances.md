<!-- Generated file — do not edit; regenerated with the SDK. -->

# CashBalances — operations

Accessor: `client.CashBalances` · Source: `src/UpvestInvestmentApi/Api/CashBalances.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### RetrieveCashBalance

- **Auth**: `options.OauthClientCredentials` (scopes: `positions:read`)
- **Signature**: `RetrieveCashBalance(RetrieveCashBalanceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Returns**: `AccountGroupsPaymentsCashBalanceResponse`
- **Error**: `ApiException<RetrieveCashBalanceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveCashBalanceRequest` | `src/UpvestInvestmentApi/Requests/CashBalances/RetrieveCashBalanceRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupsPaymentsCashBalanceResponse` | `src/UpvestInvestmentApi/Models/AccountGroupsPaymentsCashBalanceResponse.cs` |
| `RetrieveCashBalanceError` | `src/UpvestInvestmentApi/Errors/RetrieveCashBalanceError.cs` |

### RetrieveCashBalanceWithCurrency

- **Auth**: `options.OauthClientCredentials` (scopes: `positions:read`)
- **Signature**: `RetrieveCashBalanceWithCurrency(RetrieveCashBalanceWithCurrencyRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`, `Currency`
- **Returns**: `AccountGroupsPaymentsCashBalancesResponse`
- **Error**: `ApiException<RetrieveCashBalanceWithCurrencyError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveCashBalanceWithCurrencyRequest` | `src/UpvestInvestmentApi/Requests/CashBalances/RetrieveCashBalanceWithCurrencyRequest.cs` |
| `Currency1` | `src/UpvestInvestmentApi/Models/Enums/Currency1.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupsPaymentsCashBalancesResponse` | `src/UpvestInvestmentApi/Models/AccountGroupsPaymentsCashBalancesResponse.cs` |
| `RetrieveCashBalanceWithCurrencyError` | `src/UpvestInvestmentApi/Errors/RetrieveCashBalanceWithCurrencyError.cs` |

### RetrieveCashBalances

- **Auth**: `options.OauthClientCredentials` (scopes: `positions:read`)
- **Signature**: `RetrieveCashBalances(RetrieveCashBalancesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Returns**: `CashBalancesRetrieveResponse`
- **Error**: `ApiException<RetrieveCashBalancesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveCashBalancesRequest` | `src/UpvestInvestmentApi/Requests/CashBalances/RetrieveCashBalancesRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CashBalancesRetrieveResponse` | `src/UpvestInvestmentApi/Models/CashBalancesRetrieveResponse.cs` |
| `RetrieveCashBalancesError` | `src/UpvestInvestmentApi/Errors/RetrieveCashBalancesError.cs` |

