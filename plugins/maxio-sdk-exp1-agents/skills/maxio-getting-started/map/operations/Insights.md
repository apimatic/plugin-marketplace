# Insights — operations

Accessor: `client.Insights` · Source: `Api/Insights.cs` · 4 operations

### ListMrrMovements
- **HTTP**: `GET /mrr_movements.json` (Production)
- **Signature**: `ListMrrMovements(int? subscriptionId, SortingDirection? direction, int? page = 1, int? perPage = 10, CancellationToken ct = default)`
  - `subscriptionId` — nullable, no default → **must pass explicitly**
  - `direction` — nullable, no default → **must pass explicitly**
- **Returns**: `ListMrrResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListMrrPerSubscription
- **HTTP**: `GET /subscriptions_mrr.json` (Production)
- **Signature**: `ListMrrPerSubscription(ListMrrFilter? filter, string? atTime, Direction? direction, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `filter` — nullable, no default → **must pass explicitly**
  - `atTime` — nullable, no default → **must pass explicitly**
  - `direction` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionMrrResponse`
- **Error**: `SdkException<ListMrrPerSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionsMrrErrorResponse1(out SubscriptionsMrrErrorResponse1)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadMrr
- **HTTP**: `GET /mrr.json` (Production)
- **Signature**: `ReadMrr(DateTimeOffset? atTime, int? subscriptionId, CancellationToken ct = default)`
  - `atTime` — nullable, no default → **must pass explicitly**
  - `subscriptionId` — nullable, no default → **must pass explicitly**
- **Returns**: `MrrResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadSiteStats
- **HTTP**: `GET /stats.json` (Production)
- **Signature**: `ReadSiteStats(CancellationToken ct = default)`
- **Returns**: `SiteSummary`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none
