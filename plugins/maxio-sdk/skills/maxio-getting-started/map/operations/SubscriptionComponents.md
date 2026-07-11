# SubscriptionComponents — operations

Accessor: `client.SubscriptionComponents` · Source: `Api/SubscriptionComponents.cs` · 17 operations

### ActivateEventBasedComponent
- **HTTP**: `POST /event_based_billing/subscriptions/{subscription_id}/components/{component_id}/activate.json` (Production)
- **Signature**: `ActivateEventBasedComponent(int subscriptionId, int componentId, ActivateEventBasedComponent? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### AllocateComponent
- **HTTP**: `POST /subscriptions/{subscription_id}/components/{component_id}/allocations.json` (Production)
- **Signature**: `AllocateComponent(int subscriptionId, int componentId, CreateAllocationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `AllocationResponse`
- **Error**: `SdkException<AllocateComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### AllocateComponents
- **HTTP**: `POST /subscriptions/{subscription_id}/allocations.json` (Production)
- **Signature**: `AllocateComponents(int subscriptionId, AllocateComponents? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<AllocationResponse>`
- **Error**: `SdkException<AllocateComponentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### BulkRecordEvents
- **HTTP**: `POST /events/{api_handle}/bulk.json` (Ebb (events))
- **Signature**: `BulkRecordEvents(string apiHandle, string? storeUid, IReadOnlyList<EbbEvent>? body, CancellationToken ct = default)`
  - `storeUid` — nullable, no default → **must pass explicitly**
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### BulkResetSubscriptionComponentsPricePoints
- **HTTP**: `POST /subscriptions/{subscription_id}/price_points/reset.json` (Production)
- **Signature**: `BulkResetSubscriptionComponentsPricePoints(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### BulkUpdateSubscriptionComponentsPricePoints
- **HTTP**: `POST /subscriptions/{subscription_id}/price_points.json` (Production)
- **Signature**: `BulkUpdateSubscriptionComponentsPricePoints(int subscriptionId, BulkComponentsPricePointAssignment? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `BulkComponentsPricePointAssignment`
- **Error**: `SdkException<BulkUpdateSubscriptionComponentsPricePointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetComponentPricePointError1(out ComponentPricePointError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateUsage
- **HTTP**: `POST /subscriptions/{subscription_id_or_reference}/components/{component_id}/usages.json` (Production)
- **Signature**: `CreateUsage(SubscriptionIdOrReference subscriptionIdOrReference, ComponentIdModel componentId, CreateUsageRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `UsageResponse`
- **Error**: `SdkException<CreateUsageError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeactivateEventBasedComponent
- **HTTP**: `POST /event_based_billing/subscriptions/{subscription_id}/components/{component_id}/deactivate.json` (Production)
- **Signature**: `DeactivateEventBasedComponent(int subscriptionId, int componentId, CancellationToken ct = default)`
- **Returns**: `void`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### DeletePrepaidUsageAllocation
- **HTTP**: `DELETE /subscriptions/{subscription_id}/components/{component_id}/allocations/{allocation_id}.json` (Production)
- **Signature**: `DeletePrepaidUsageAllocation(int subscriptionId, int componentId, int allocationId, CreditSchemeRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<DeletePrepaidUsageAllocationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetSubscriptionComponentAllocationError1(out SubscriptionComponentAllocationError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListAllocations
- **HTTP**: `GET /subscriptions/{subscription_id}/components/{component_id}/allocations.json` (Production)
- **Signature**: `ListAllocations(int subscriptionId, int componentId, int? page = 1, CancellationToken ct = default)`
  - `page` = 1 — optional
- **Returns**: `IReadOnlyList<AllocationResponse>`
- **Error**: `SdkException<ListAllocationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none (only `page`, no `perPage`)

### ListSubscriptionComponents
- **HTTP**: `GET /subscriptions/{subscription_id}/components.json` (Production)
- **Signature**: `ListSubscriptionComponents(int subscriptionId, SubscriptionListDateField? dateField, SortingDirection? direction, ListSubscriptionComponentsFilter? filter, string? endDate, string? endDatetime, IncludeNotNull? pricePointIds, IReadOnlyList<int>? productFamilyIds, ListSubscriptionComponentsSort? sort, string? startDate, string? startDatetime, IReadOnlyList<ListSubscriptionComponentsInclude>? include, bool? inUse, CancellationToken ct = default)`
  - All 12 filter params (`dateField` … `inUse`) are nullable with no default → **must pass explicitly** (pass `null` to skip)
- **Returns**: `IReadOnlyList<SubscriptionComponentResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListSubscriptionComponentsForSite
- **HTTP**: `GET /subscriptions_components.json` (Production)
- **Signature**: `ListSubscriptionComponentsForSite(ListSubscriptionComponentsSort? sort, SortingDirection? direction, ListSubscriptionComponentsForSiteFilter? filter, SubscriptionListDateField? dateField, string? startDate, string? startDatetime, string? endDate, string? endDatetime, IReadOnlyList<int>? subscriptionIds, IncludeNotNull? pricePointIds, IReadOnlyList<int>? productFamilyIds, ListSubscriptionComponentsInclude? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - All 12 filter params (`sort` … `include`) are nullable with no default → **must pass explicitly** (pass `null` to skip)
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `ListSubscriptionComponentsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListUsages
- **HTTP**: `GET /subscriptions/{subscription_id_or_reference}/components/{component_id}/usages.json` (Production)
- **Signature**: `ListUsages(SubscriptionIdOrReference subscriptionIdOrReference, ComponentIdModel componentId, long? sinceId, long? maxId, DateTimeOffset? sinceDate, DateTimeOffset? untilDate, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `sinceId`, `maxId`, `sinceDate`, `untilDate` — nullable, no default → **must pass explicitly**
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `IReadOnlyList<UsageResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### PreviewAllocations
- **HTTP**: `POST /subscriptions/{subscription_id}/allocations/preview.json` (Production)
- **Signature**: `PreviewAllocations(int subscriptionId, PreviewAllocationsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `AllocationPreviewResponse`
- **Error**: `SdkException<PreviewAllocationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetComponentAllocationError1(out ComponentAllocationError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadSubscriptionComponent
- **HTTP**: `GET /subscriptions/{subscription_id}/components/{component_id}.json` (Production)
- **Signature**: `ReadSubscriptionComponent(int subscriptionId, int componentId, CancellationToken ct = default)`
- **Returns**: `SubscriptionComponentResponse`
- **Error**: `SdkException<ReadSubscriptionComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RecordEvent
- **HTTP**: `POST /events/{api_handle}.json` (Ebb (events))
- **Signature**: `RecordEvent(string apiHandle, string? storeUid, EbbEvent? body, CancellationToken ct = default)`
  - `storeUid` — nullable, no default → **must pass explicitly**
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdatePrepaidUsageAllocationExpirationDate
- **HTTP**: `PUT /subscriptions/{subscription_id}/components/{component_id}/allocations/{allocation_id}.json` (Production)
- **Signature**: `UpdatePrepaidUsageAllocationExpirationDate(int subscriptionId, int componentId, int allocationId, UpdateAllocationExpirationDate? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<UpdatePrepaidUsageAllocationExpirationDateError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetSubscriptionComponentAllocationError1(out SubscriptionComponentAllocationError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
