# SubscriptionComponents — operations

Accessor: `client.SubscriptionComponents` · Source: `Api/SubscriptionComponents.cs` · 17 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ActivateEventBasedComponent
- **HTTP**: `POST /event_based_billing/subscriptions/{subscription_id}/components/{component_id}/activate.json` (Production)
- **Notes**: Activates an event-based component for a single subscription. In order to bill your subscribers on your Events data under the Events-Based Billing feature, the components must be activated for the subscriber. Learn more about the role of activation in the Events-Based Billing docs . Use this endpoint to activate an event-based component for a …
- **Signature**: `ActivateEventBasedComponent(int subscriptionId, int componentId, ActivateEventBasedComponent? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### AllocateComponent
- **HTTP**: `POST /subscriptions/{subscription_id}/components/{component_id}/allocations.json` (Production)
- **Notes**: Creates an allocation, sets the current allocated quantity for the component, and records a memo. Allocations can only be updated for Quantity, On/Off, and Prepaid Components. When creating an allocation via the API, you can pass the `upgrade_charge`, `downgrade_credit`, and `accrue_charge` to be applied. &gt; Note: These proration and accrual …
- **Signature**: `AllocateComponent(int subscriptionId, int componentId, CreateAllocationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `AllocationResponse`
- **Error**: `SdkException<AllocateComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### AllocateComponents
- **HTTP**: `POST /subscriptions/{subscription_id}/allocations.json` (Production)
- **Notes**: Creates multiple allocations, sets the current allocated quantity for each of the components, and records a memo. A `component_id` is required for each allocation. The charges and/or credits that are created will be rolled up into a single total which is used to determine whether this is an upgrade or a downgrade. Order of Resolution for …
- **Signature**: `AllocateComponents(int subscriptionId, AllocateComponents? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<AllocationResponse>`
- **Error**: `SdkException<AllocateComponentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### BulkRecordEvents
- **HTTP**: `POST /events/{api_handle}/bulk.json` (Ebb (events))
- **Notes**: Records a collection of events. *Note: this endpoint differs from the standard Chargify API endpoints in that the subdomain will be `events` and your site subdomain will be included in the URL path.* A maximum of 1000 events can be published in a single request. A 422 will be returned if this limit is exceeded.
- **Signature**: `BulkRecordEvents(string apiHandle, string? storeUid, IReadOnlyList<EbbEvent>? body, CancellationToken ct = default)`
  - `storeUid` — nullable, no default → **must pass explicitly**
  - `body` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `store_uid` ← `storeUid`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### BulkResetSubscriptionComponentsPricePoints
- **HTTP**: `POST /subscriptions/{subscription_id}/price_points/reset.json` (Production)
- **Notes**: Resets all of a subscription's components to use the current default. Note : this will update the price point for all of the subscription's components, even ones that have not been allocated yet.
- **Signature**: `BulkResetSubscriptionComponentsPricePoints(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### BulkUpdateSubscriptionComponentsPricePoints
- **HTTP**: `POST /subscriptions/{subscription_id}/price_points.json` (Production)
- **Notes**: Updates the price points on one or more of a subscription's components. The `price_point` key can take either a: 1. Price point id (integer) 2. Price point handle (string) 3. `"_default"` string, which will reset the price point to the component's current default price point.
- **Signature**: `BulkUpdateSubscriptionComponentsPricePoints(int subscriptionId, BulkComponentsPricePointAssignment? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `BulkComponentsPricePointAssignment`
- **Error**: `SdkException<BulkUpdateSubscriptionComponentsPricePointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetComponentPricePointError1(out ComponentPricePointError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateUsage
- **HTTP**: `POST /subscriptions/{subscription_id_or_reference}/components/{component_id}/usages.json` (Production)
- **Notes**: Records an instance of metered or prepaid usage for a subscription. You can report metered or prepaid usage to Advanced Billing as often as you wish. You can report usage as it happens or periodically, such as each night or once per billing period. Full documentation on how to create Components in the Advanced Billing UI can be located here . …
- **Signature**: `CreateUsage(SubscriptionIdOrReference subscriptionIdOrReference, ComponentIdModel componentId, CreateUsageRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `UsageResponse`
- **Error**: `SdkException<CreateUsageError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeactivateEventBasedComponent
- **HTTP**: `POST /event_based_billing/subscriptions/{subscription_id}/components/{component_id}/deactivate.json` (Production)
- **Notes**: Deactivates an event-based component for a single subscription. Deactivating the event-based component causes Advanced Billing to ignore related events at subscription renewal.
- **Signature**: `DeactivateEventBasedComponent(int subscriptionId, int componentId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### DeletePrepaidUsageAllocation
- **HTTP**: `DELETE /subscriptions/{subscription_id}/components/{component_id}/allocations/{allocation_id}.json` (Production)
- **Notes**: Deletes a prepaid usage allocation. Prepaid Usage components are unique in that their allocations are always additive. In order to reduce a subscription's allocated quantity for a prepaid usage component, each allocation must be destroyed individually via this endpoint. Credit Scheme By default, destroying an allocation will generate a service …
- **Signature**: `DeletePrepaidUsageAllocation(int subscriptionId, int componentId, int allocationId, CreditSchemeRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeletePrepaidUsageAllocationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetSubscriptionComponentAllocationError1(out SubscriptionComponentAllocationError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListAllocations
- **HTTP**: `GET /subscriptions/{subscription_id}/components/{component_id}/allocations.json` (Production)
- **Notes**: Returns the 50 most recent Allocations, ordered by most recent first. On/Off Components When a subscription's on/off component has been toggled to on (`1`) or off (`0`), usage will be logged in this response.
- **Signature**: `ListAllocations(int subscriptionId, int componentId, int? page = 1, CancellationToken ct = default)`
  - defaults: `page` = 1
- **Query params (wire ← C#)**: `page` ← `page`
- **Returns**: `IReadOnlyList<AllocationResponse>`
- **Error**: `SdkException<ListAllocationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none (only `page`, no `perPage`)

### ListSubscriptionComponents
- **HTTP**: `GET /subscriptions/{subscription_id}/components.json` (Production)
- **Notes**: Lists a subscription's applied components. Archived Components When requesting to list components for a given subscription, if the subscription contains archived components they will be listed in the server response.
- **Signature**: `ListSubscriptionComponents(int subscriptionId, SubscriptionListDateField? dateField, SortingDirection? direction, ListSubscriptionComponentsFilter? filter, string? endDate, string? endDatetime, IncludeNotNull? pricePointIds, IReadOnlyList<int>? productFamilyIds, ListSubscriptionComponentsSort? sort, string? startDate, string? startDatetime, IReadOnlyList<ListSubscriptionComponentsInclude>? include, bool? inUse, CancellationToken ct = default)`
  - 12 params (`dateField` … `inUse`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
- **Query params (wire ← C#)**: `date_field` ← `dateField`, `direction` ← `direction`, `filter` ← `filter`, `end_date` ← `endDate`, `end_datetime` ← `endDatetime`, `price_point_ids` ← `pricePointIds`, `product_family_ids` ← `productFamilyIds`, `sort` ← `sort`, `start_date` ← `startDate`, `start_datetime` ← `startDatetime`, `include` ← `include`, `in_use` ← `inUse`
- **Returns**: `IReadOnlyList<SubscriptionComponentResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListSubscriptionComponentsForSite
- **HTTP**: `GET /subscriptions_components.json` (Production)
- **Notes**: Lists components applied to each subscription.
- **Signature**: `ListSubscriptionComponentsForSite(ListSubscriptionComponentsSort? sort, SortingDirection? direction, ListSubscriptionComponentsForSiteFilter? filter, SubscriptionListDateField? dateField, string? startDate, string? startDatetime, string? endDate, string? endDatetime, IReadOnlyList<int>? subscriptionIds, IncludeNotNull? pricePointIds, IReadOnlyList<int>? productFamilyIds, ListSubscriptionComponentsInclude? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - 12 params (`sort` … `include`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `sort` ← `sort`, `direction` ← `direction`, `filter` ← `filter`, `date_field` ← `dateField`, `start_date` ← `startDate`, `start_datetime` ← `startDatetime`, `end_date` ← `endDate`, `end_datetime` ← `endDatetime`, `subscription_ids` ← `subscriptionIds`, `price_point_ids` ← `pricePointIds`, `product_family_ids` ← `productFamilyIds`, `include` ← `include`
- **Returns**: `ListSubscriptionComponentsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListUsages
- **HTTP**: `GET /subscriptions/{subscription_id_or_reference}/components/{component_id}/usages.json` (Production)
- **Notes**: Returns a list of usages associated with a subscription for a particular metered component. This will display the previously recorded components for a subscription. This endpoint is not compatible with quantity-based components. Since Date and Until Date Usage Note: The `since_date` and `until_date` attributes each default to midnight on the date …
- **Signature**: `ListUsages(SubscriptionIdOrReference subscriptionIdOrReference, ComponentIdModel componentId, long? sinceId, long? maxId, DateTimeOffset? sinceDate, DateTimeOffset? untilDate, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - 4 params (`sinceId` … `untilDate`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `since_id` ← `sinceId`, `max_id` ← `maxId`, `since_date` ← `sinceDate`, `until_date` ← `untilDate`, `page` ← `page`, `per_page` ← `perPage`
- **Returns**: `IReadOnlyList<UsageResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### PreviewAllocations
- **HTTP**: `POST /subscriptions/{subscription_id}/allocations/preview.json` (Production)
- **Notes**: Previews a potential subscription's quantity-based or on/off component allocation in the middle of the current billing period. This is useful if you want users to be able to see the effect of a component operation before actually doing it. Fine-grained Component Control: Use with multiple `upgrade_charge`s or `downgrade_credits` When the …
- **Signature**: `PreviewAllocations(int subscriptionId, PreviewAllocationsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `AllocationPreviewResponse`
- **Error**: `SdkException<PreviewAllocationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetComponentAllocationError1(out ComponentAllocationError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadSubscriptionComponent
- **HTTP**: `GET /subscriptions/{subscription_id}/components/{component_id}.json` (Production)
- **Notes**: Returns information for a specific component on a subscription.
- **Signature**: `ReadSubscriptionComponent(int subscriptionId, int componentId, CancellationToken ct = default)`
- **Returns**: `SubscriptionComponentResponse`
- **Error**: `SdkException<ReadSubscriptionComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RecordEvent
- **HTTP**: `POST /events/{api_handle}.json` (Ebb (events))
- **Notes**: Records a single event for Events-Based Billing. Documentation Events-Based Billing is an evolved form of metered billing that is based on data-rich events streamed in real-time from your system to Advanced Billing. These events can then be transformed, enriched, or analyzed to form the computed totals of usage charges billed to your customers. …
- **Signature**: `RecordEvent(string apiHandle, string? storeUid, EbbEvent? body, CancellationToken ct = default)`
  - `storeUid` — nullable, no default → **must pass explicitly**
  - `body` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `store_uid` ← `storeUid`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdatePrepaidUsageAllocationExpirationDate
- **HTTP**: `PUT /subscriptions/{subscription_id}/components/{component_id}/allocations/{allocation_id}.json` (Production)
- **Notes**: Updates the expiration date for a prepaid usage allocation. This expiration date can be changed after the fact to allow for extending or shortening the allocation's active window. In order to change a prepaid usage allocation's expiration date, a PUT call must be made to the allocation's endpoint with a new expiration date. Limitations A few …
- **Signature**: `UpdatePrepaidUsageAllocationExpirationDate(int subscriptionId, int componentId, int allocationId, UpdateAllocationExpirationDate? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<UpdatePrepaidUsageAllocationExpirationDateError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetSubscriptionComponentAllocationError1(out SubscriptionComponentAllocationError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
