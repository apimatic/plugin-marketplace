# Events — operations

Accessor: `client.Events` · Source: `Api/Events.cs` · 3 operations

### ListEvents
- **HTTP**: `GET /events.json` (Production)
- **Signature**: `ListEvents(long? sinceId, long? maxId, Direction? direction, IReadOnlyList<EventKey>? filter, ListEventsDateField? dateField, string? startDate, string? endDate, string? startDatetime, string? endDatetime, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `sinceId` — nullable, no default → **must pass explicitly**
  - `maxId` — nullable, no default → **must pass explicitly**
  - `direction` — nullable, no default → **must pass explicitly**
  - `filter` — nullable, no default → **must pass explicitly**
  - `dateField` — nullable, no default → **must pass explicitly**
  - `startDate` — nullable, no default → **must pass explicitly**
  - `endDate` — nullable, no default → **must pass explicitly**
  - `startDatetime` — nullable, no default → **must pass explicitly**
  - `endDatetime` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<EventResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListSubscriptionEvents
- **HTTP**: `GET /subscriptions/{subscription_id}/events.json` (Production)
- **Signature**: `ListSubscriptionEvents(int subscriptionId, long? sinceId, long? maxId, Direction? direction, IReadOnlyList<EventKey>? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `sinceId` — nullable, no default → **must pass explicitly**
  - `maxId` — nullable, no default → **must pass explicitly**
  - `direction` — nullable, no default → **must pass explicitly**
  - `filter` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<EventResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadEventsCount
- **HTTP**: `GET /events/count.json` (Production)
- **Signature**: `ReadEventsCount(long? sinceId, long? maxId, Direction? direction, IReadOnlyList<EventKey>? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `sinceId` — nullable, no default → **must pass explicitly**
  - `maxId` — nullable, no default → **must pass explicitly**
  - `direction` — nullable, no default → **must pass explicitly**
  - `filter` — nullable, no default → **must pass explicitly**
- **Returns**: `CountResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`
