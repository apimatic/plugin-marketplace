<!-- Generated file — do not edit; regenerated with the SDK. -->

# PortfoliosRebalancing — operations

Accessor: `client.PortfoliosRebalancing` · Source: `src/UpvestInvestmentApi/Api/PortfoliosRebalancing.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListPortfolioRebalancingExecutionOrders

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `ListPortfolioRebalancingExecutionOrders(ListPortfolioRebalancingExecutionOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ExecutionId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`, `start_date` ← `StartDate`, `end_date` ← `EndDate`
- **Returns**: `PortfoliosRebalancingExecutionOrderListResponse`
- **Error**: `ApiException<ListPortfolioRebalancingExecutionOrdersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPortfolioRebalancingExecutionOrdersRequest` | `src/UpvestInvestmentApi/Requests/PortfoliosRebalancing/ListPortfolioRebalancingExecutionOrdersRequest.cs` |
| `Sort27` | `src/UpvestInvestmentApi/Models/Enums/Sort27.cs` |
| `Order60` | `src/UpvestInvestmentApi/Models/Enums/Order60.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosRebalancingExecutionOrderListResponse` | `src/UpvestInvestmentApi/Models/PortfoliosRebalancingExecutionOrderListResponse.cs` |
| `ListPortfolioRebalancingExecutionOrdersError` | `src/UpvestInvestmentApi/Errors/ListPortfolioRebalancingExecutionOrdersError.cs` |

### RetrievePortfoliosRebalancingExecution

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `RetrievePortfoliosRebalancingExecution(RetrievePortfoliosRebalancingExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ExecutionId`
- **Returns**: `PortfoliosRebalancingExecution`
- **Error**: `ApiException<RetrievePortfoliosRebalancingExecutionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrievePortfoliosRebalancingExecutionRequest` | `src/UpvestInvestmentApi/Requests/PortfoliosRebalancing/RetrievePortfoliosRebalancingExecutionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosRebalancingExecution` | `src/UpvestInvestmentApi/Models/PortfoliosRebalancingExecution.cs` |
| `RetrievePortfoliosRebalancingExecutionError` | `src/UpvestInvestmentApi/Errors/RetrievePortfoliosRebalancingExecutionError.cs` |

### TriggerPortfolioRebalancing

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `TriggerPortfolioRebalancing(TriggerPortfolioRebalancingOperationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `TriggerPortfolioRebalancingResponse`
- **Error**: `ApiException<TriggerPortfolioRebalancingError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `TriggerPortfolioRebalancingOperationRequest` | `src/UpvestInvestmentApi/Requests/PortfoliosRebalancing/TriggerPortfolioRebalancingOperationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TriggerPortfolioRebalancingRequest` | `src/UpvestInvestmentApi/Models/AnyOf/TriggerPortfolioRebalancingRequest.cs` |
| `TriggerPortfolioRebalancingResponse` | `src/UpvestInvestmentApi/Models/TriggerPortfolioRebalancingResponse.cs` |
| `TriggerPortfolioRebalancingError` | `src/UpvestInvestmentApi/Errors/TriggerPortfolioRebalancingError.cs` |

