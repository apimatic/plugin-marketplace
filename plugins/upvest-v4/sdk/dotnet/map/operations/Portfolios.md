<!-- Generated file — do not edit; regenerated with the SDK. -->

# Portfolios — operations

Accessor: `client.Portfolios` · Source: `src/UpvestInvestmentApi/Api/Portfolios.cs` · 14 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CancelPortfoliosOrder

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `CancelPortfoliosOrder(CancelPortfoliosOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PortfolioOrderId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<CancelPortfoliosOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CancelPortfoliosOrderRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/CancelPortfoliosOrderRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `CancelPortfoliosOrderError` | `src/UpvestInvestmentApi/Errors/CancelPortfoliosOrderError.cs` |

### CreatePortfoliosAllocation

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `CreatePortfoliosAllocation(CreatePortfoliosAllocationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PortfoliosAllocation`
- **Error**: `ApiException<CreatePortfoliosAllocationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreatePortfoliosAllocationRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/CreatePortfoliosAllocationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosAllocationCreateRequest` | `src/UpvestInvestmentApi/Models/PortfoliosAllocationCreateRequest.cs` |
| `PortfoliosAllocation` | `src/UpvestInvestmentApi/Models/PortfoliosAllocation.cs` |
| `CreatePortfoliosAllocationError` | `src/UpvestInvestmentApi/Errors/CreatePortfoliosAllocationError.cs` |

### CreatePortfoliosConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `CreatePortfoliosConfiguration(CreatePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PortfoliosConfiguration`
- **Error**: `ApiException<CreatePortfoliosConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 422, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreatePortfoliosConfigurationRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/CreatePortfoliosConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosConfigurationCreateRequest` | `src/UpvestInvestmentApi/Models/PortfoliosConfigurationCreateRequest.cs` |
| `PortfoliosConfiguration` | `src/UpvestInvestmentApi/Models/PortfoliosConfiguration.cs` |
| `CreatePortfoliosConfigurationError` | `src/UpvestInvestmentApi/Errors/CreatePortfoliosConfigurationError.cs` |

### CreatePortfoliosOrder

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `CreatePortfoliosOrder(CreatePortfoliosOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PortfoliosOrder`
- **Error**: `ApiException<CreatePortfoliosOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreatePortfoliosOrderRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/CreatePortfoliosOrderRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosOrderPlaceRequest` | `src/UpvestInvestmentApi/Models/PortfoliosOrderPlaceRequest.cs` |
| `PortfoliosOrder` | `src/UpvestInvestmentApi/Models/PortfoliosOrder.cs` |
| `CreatePortfoliosOrderError` | `src/UpvestInvestmentApi/Errors/CreatePortfoliosOrderError.cs` |

### DeletePortfoliosConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `DeletePortfoliosConfiguration(DeletePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeletePortfoliosConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeletePortfoliosConfigurationRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/DeletePortfoliosConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeletePortfoliosConfigurationError` | `src/UpvestInvestmentApi/Errors/DeletePortfoliosConfigurationError.cs` |

### ListPortfoliosAllocationAccounts

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `ListPortfoliosAllocationAccounts(ListPortfoliosAllocationAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AllocationId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `PortfoliosAllocationAccountsListResponse`
- **Error**: `ApiException<ListPortfoliosAllocationAccountsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPortfoliosAllocationAccountsRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosAllocationAccountsRequest.cs` |
| `Sort24` | `src/UpvestInvestmentApi/Models/Enums/Sort24.cs` |
| `Order60` | `src/UpvestInvestmentApi/Models/Enums/Order60.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosAllocationAccountsListResponse` | `src/UpvestInvestmentApi/Models/PortfoliosAllocationAccountsListResponse.cs` |
| `ListPortfoliosAllocationAccountsError` | `src/UpvestInvestmentApi/Errors/ListPortfoliosAllocationAccountsError.cs` |

### ListPortfoliosAllocations

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `ListPortfoliosAllocations(ListPortfoliosAllocationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `instrument_ids` ← `InstrumentIds`
- **Returns**: `PortfoliosAllocationsListResponse`
- **Error**: `ApiException<ListPortfoliosAllocationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPortfoliosAllocationsRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosAllocationsRequest.cs` |
| `Sort24` | `src/UpvestInvestmentApi/Models/Enums/Sort24.cs` |
| `Order60` | `src/UpvestInvestmentApi/Models/Enums/Order60.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosAllocationsListResponse` | `src/UpvestInvestmentApi/Models/PortfoliosAllocationsListResponse.cs` |
| `ListPortfoliosAllocationsError` | `src/UpvestInvestmentApi/Errors/ListPortfoliosAllocationsError.cs` |

### ListPortfoliosConfigurations

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `ListPortfoliosConfigurations(ListPortfoliosConfigurationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `account_id` ← `AccountId`, `allocation_id` ← `AllocationId`
- **Returns**: `PortfoliosConfigurationsListResponse`
- **Error**: `ApiException<ListPortfoliosConfigurationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPortfoliosConfigurationsRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosConfigurationsRequest.cs` |
| `Sort25` | `src/UpvestInvestmentApi/Models/Enums/Sort25.cs` |
| `Order60` | `src/UpvestInvestmentApi/Models/Enums/Order60.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosConfigurationsListResponse` | `src/UpvestInvestmentApi/Models/PortfoliosConfigurationsListResponse.cs` |
| `ListPortfoliosConfigurationsError` | `src/UpvestInvestmentApi/Errors/ListPortfoliosConfigurationsError.cs` |

### ListPortfoliosOrders

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `ListPortfoliosOrders(ListPortfoliosOrdersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `allocation_id` ← `AllocationId`, `account_id` ← `AccountId`
- **Returns**: `PortfoliosOrdersListResponse`
- **Error**: `ApiException<ListPortfoliosOrdersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPortfoliosOrdersRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/ListPortfoliosOrdersRequest.cs` |
| `Sort24` | `src/UpvestInvestmentApi/Models/Enums/Sort24.cs` |
| `Order60` | `src/UpvestInvestmentApi/Models/Enums/Order60.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosOrdersListResponse` | `src/UpvestInvestmentApi/Models/PortfoliosOrdersListResponse.cs` |
| `ListPortfoliosOrdersError` | `src/UpvestInvestmentApi/Errors/ListPortfoliosOrdersError.cs` |

### RetrievePortfoliosAllocation

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `RetrievePortfoliosAllocation(RetrievePortfoliosAllocationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AllocationId`
- **Returns**: `PortfoliosAllocation`
- **Error**: `ApiException<RetrievePortfoliosAllocationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrievePortfoliosAllocationRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/RetrievePortfoliosAllocationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosAllocation` | `src/UpvestInvestmentApi/Models/PortfoliosAllocation.cs` |
| `RetrievePortfoliosAllocationError` | `src/UpvestInvestmentApi/Errors/RetrievePortfoliosAllocationError.cs` |

### RetrievePortfoliosConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `RetrievePortfoliosConfiguration(RetrievePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Returns**: `PortfoliosConfiguration`
- **Error**: `ApiException<RetrievePortfoliosConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrievePortfoliosConfigurationRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/RetrievePortfoliosConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosConfiguration` | `src/UpvestInvestmentApi/Models/PortfoliosConfiguration.cs` |
| `RetrievePortfoliosConfigurationError` | `src/UpvestInvestmentApi/Errors/RetrievePortfoliosConfigurationError.cs` |

### RetrievePortfoliosOrder

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:read`, `portfolios:admin`)
- **Signature**: `RetrievePortfoliosOrder(RetrievePortfoliosOrderRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `PortfolioOrderId`
- **Returns**: `PortfoliosOrder`
- **Error**: `ApiException<RetrievePortfoliosOrderError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrievePortfoliosOrderRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/RetrievePortfoliosOrderRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosOrder` | `src/UpvestInvestmentApi/Models/PortfoliosOrder.cs` |
| `RetrievePortfoliosOrderError` | `src/UpvestInvestmentApi/Errors/RetrievePortfoliosOrderError.cs` |

### UpdatePortfoliosAllocation

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `UpdatePortfoliosAllocation(UpdatePortfoliosAllocationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AllocationId`
- **Returns**: `PortfoliosAllocation`
- **Error**: `ApiException<UpdatePortfoliosAllocationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdatePortfoliosAllocationRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/UpdatePortfoliosAllocationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosAllocationUpdateRequest` | `src/UpvestInvestmentApi/Models/PortfoliosAllocationUpdateRequest.cs` |
| `PortfoliosAllocation` | `src/UpvestInvestmentApi/Models/PortfoliosAllocation.cs` |
| `UpdatePortfoliosAllocationError` | `src/UpvestInvestmentApi/Errors/UpdatePortfoliosAllocationError.cs` |

### UpdatePortfoliosConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `portfolios:admin`)
- **Signature**: `UpdatePortfoliosConfiguration(UpdatePortfoliosConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`, `IdempotencyKey`
- **Returns**: `PortfoliosConfiguration`
- **Error**: `ApiException<UpdatePortfoliosConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdatePortfoliosConfigurationRequest` | `src/UpvestInvestmentApi/Requests/Portfolios/UpdatePortfoliosConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PortfoliosConfigurationUpdateRequest` | `src/UpvestInvestmentApi/Models/PortfoliosConfigurationUpdateRequest.cs` |
| `PortfoliosConfiguration` | `src/UpvestInvestmentApi/Models/PortfoliosConfiguration.cs` |
| `UpdatePortfoliosConfigurationError` | `src/UpvestInvestmentApi/Errors/UpdatePortfoliosConfigurationError.cs` |

