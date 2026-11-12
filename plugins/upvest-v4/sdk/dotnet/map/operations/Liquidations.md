<!-- Generated file — do not edit; regenerated with the SDK. -->

# Liquidations — operations

Accessor: `client.Liquidations` · Source: `src/UpvestInvestmentApi/Api/Liquidations.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelAccountLiquidation

- **Auth**: `options.OauthClientCredentials` (scopes: `account_liquidations:admin`)
- **Signature**: `CancelAccountLiquidation(CancelAccountLiquidationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`, `AccountLiquidationId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelAccountLiquidationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelAccountLiquidationRequest` | `src/UpvestInvestmentApi/Requests/Liquidations/CancelAccountLiquidationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CancelAccountLiquidationError` | `src/UpvestInvestmentApi/Errors/CancelAccountLiquidationError.cs` |

### CreateAccountLiquidation

- **Auth**: `options.OauthClientCredentials` (scopes: `account_liquidations:admin`)
- **Signature**: `CreateAccountLiquidation(CreateAccountLiquidationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`, `IdempotencyKey`
- **Returns**: `AccountLiquidation`
- **Error**: `ApiException<CreateAccountLiquidationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateAccountLiquidationRequest` | `src/UpvestInvestmentApi/Requests/Liquidations/CreateAccountLiquidationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountLiquidationRequest2` | `src/UpvestInvestmentApi/Models/AnyOf/AccountLiquidationRequest2.cs` |
| `AccountLiquidation` | `src/UpvestInvestmentApi/Models/AccountLiquidation.cs` |
| `CreateAccountLiquidationError` | `src/UpvestInvestmentApi/Errors/CreateAccountLiquidationError.cs` |

### ListAccountsLiquidations

- **Auth**: `options.OauthClientCredentials` (scopes: `account_liquidations:read`, `account_liquidations:admin`)
- **Signature**: `ListAccountsLiquidations(ListAccountsLiquidationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`, `start_date` ← `StartDate`, `end_date` ← `EndDate`
- **Returns**: `PortfoliosOrdersListResponse1`
- **Error**: `ApiException<ListAccountsLiquidationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAccountsLiquidationsRequest` | `src/UpvestInvestmentApi/Requests/Liquidations/ListAccountsLiquidationsRequest.cs` |
| `Sort24` | `src/UpvestInvestmentApi/Models/Enums/Sort24.cs` |
| `Order60` | `src/UpvestInvestmentApi/Models/Enums/Order60.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosOrdersListResponse1` | `src/UpvestInvestmentApi/Models/PortfoliosOrdersListResponse1.cs` |
| `ListAccountsLiquidationsError` | `src/UpvestInvestmentApi/Errors/ListAccountsLiquidationsError.cs` |

### RetrieveAccountLiquidation

- **Auth**: `options.OauthClientCredentials` (scopes: `account_liquidations:read`, `account_liquidations:admin`)
- **Signature**: `RetrieveAccountLiquidation(RetrieveAccountLiquidationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`, `AccountLiquidationId`
- **Returns**: `AccountLiquidation`
- **Error**: `ApiException<RetrieveAccountLiquidationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveAccountLiquidationRequest` | `src/UpvestInvestmentApi/Requests/Liquidations/RetrieveAccountLiquidationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountLiquidation` | `src/UpvestInvestmentApi/Models/AccountLiquidation.cs` |
| `RetrieveAccountLiquidationError` | `src/UpvestInvestmentApi/Errors/RetrieveAccountLiquidationError.cs` |

