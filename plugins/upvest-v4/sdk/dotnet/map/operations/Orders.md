<!-- Generated file — do not edit; regenerated with the SDK. -->

# Orders — operations

Accessor: `client.Orders` · Source: `src/UpvestInvestmentApi/Api/Orders.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelOrder

- **Auth**: `options.OauthClientCredentials` (scopes: `orders:admin`)
- **Signature**: `CancelOrder(CancelOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `OrderId`
- **Returns**: `OrderCancelResponse`
- **Error**: `ApiException<CancelOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelOrderRequest` | `src/UpvestInvestmentApi/Requests/Orders/CancelOrderRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `OrderCancelResponse` | `src/UpvestInvestmentApi/Models/OrderCancelResponse.cs` |
| `CancelOrderError` | `src/UpvestInvestmentApi/Errors/CancelOrderError.cs` |

### ListAccountOrders

- **Auth**: `options.OauthClientCredentials` (scopes: `orders:read`, `orders:admin`)
- **Signature**: `ListAccountOrders(ListAccountOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Query params (wire ← C#)**: `order` ← `Order`, `account_group_id` ← `AccountGroupId`, `user_id` ← `UserId`, `status` ← `Status`, `date_created_from` ← `DateCreatedFrom`, `date_created_to` ← `DateCreatedTo`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `OrdersListResponse`
- **Error**: `ApiException<ListAccountOrdersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAccountOrdersRequest` | `src/UpvestInvestmentApi/Requests/Orders/ListAccountOrdersRequest.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `Status50` | `src/UpvestInvestmentApi/Models/Enums/Status50.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `OrdersListResponse` | `src/UpvestInvestmentApi/Models/OrdersListResponse.cs` |
| `ListAccountOrdersError` | `src/UpvestInvestmentApi/Errors/ListAccountOrdersError.cs` |

### PlaceOrder

- **Auth**: `options.OauthClientCredentials` (scopes: `orders:admin`)
- **Signature**: `PlaceOrder(PlaceOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `Order39`
- **Error**: `ApiException<PlaceOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 422, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `PlaceOrderRequest` | `src/UpvestInvestmentApi/Requests/Orders/PlaceOrderRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `OrderPlaceRequest` | `src/UpvestInvestmentApi/Models/OrderPlaceRequest.cs` |
| `Order39` | `src/UpvestInvestmentApi/Models/Order39.cs` |
| `PlaceOrderError` | `src/UpvestInvestmentApi/Errors/PlaceOrderError.cs` |

### RetrieveOrder

- **Auth**: `options.OauthClientCredentials` (scopes: `orders:read`, `orders:admin`)
- **Signature**: `RetrieveOrder(RetrieveOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `OrderId`
- **Returns**: `Order39`
- **Error**: `ApiException<RetrieveOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveOrderRequest` | `src/UpvestInvestmentApi/Requests/Orders/RetrieveOrderRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `Order39` | `src/UpvestInvestmentApi/Models/Order39.cs` |
| `RetrieveOrderError` | `src/UpvestInvestmentApi/Errors/RetrieveOrderError.cs` |

### RetrieveOrderExecution

- **Auth**: `options.OauthClientCredentials` (scopes: `orders:read`, `orders:admin`)
- **Signature**: `RetrieveOrderExecution(RetrieveOrderExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ExecutionId`, `OrderId`
- **Returns**: `OrderExecution`
- **Error**: `ApiException<RetrieveOrderExecutionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveOrderExecutionRequest` | `src/UpvestInvestmentApi/Requests/Orders/RetrieveOrderExecutionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `OrderExecution` | `src/UpvestInvestmentApi/Models/OrderExecution.cs` |
| `RetrieveOrderExecutionError` | `src/UpvestInvestmentApi/Errors/RetrieveOrderExecutionError.cs` |

