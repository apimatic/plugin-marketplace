# Events — operations

Accessor: `client.Events` · Source: `Api/Events.cs` · 3 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ListEvents
- **HTTP**: `GET /events.json` (Production)
- **Notes**: Lists events for a site. Events Intro Advanced Billing Events include various activity that happens around a Site. This information is especially useful to track down issues that arise when subscriptions are not created due to errors. Within the Advanced Billing UI, "Events" are referred to as "Site Activity". Full documentation on how to view …
- **Signature**: `ListEvents(long? sinceId, long? maxId, Direction? direction, IReadOnlyList<EventKey>? filter, ListEventsDateField? dateField, string? startDate, string? endDate, string? startDatetime, string? endDatetime, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - 9 params (`sinceId` … `endDatetime`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `since_id` ← `sinceId`, `max_id` ← `maxId`, `direction` ← `direction`, `filter` ← `filter`, `date_field` ← `dateField`, `start_date` ← `startDate`, `end_date` ← `endDate`, `start_datetime` ← `startDatetime`, `end_datetime` ← `endDatetime`
- **Returns**: `IReadOnlyList<EventResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListSubscriptionEvents
- **HTTP**: `GET /subscriptions/{subscription_id}/events.json` (Production)
- **Notes**: Lists events for a subscription. Event Key The event type is identified by the key property. You can check supported keys here . Event Specific Data Different event types may include additional data in `event_specific_data` property. While some events share the same schema for `event_specific_data`, others may not include it at all. For precise …
- **Signature**: `ListSubscriptionEvents(int subscriptionId, long? sinceId, long? maxId, Direction? direction, IReadOnlyList<EventKey>? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - 4 params (`sinceId` … `filter`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `since_id` ← `sinceId`, `max_id` ← `maxId`, `direction` ← `direction`, `filter` ← `filter`
- **Returns**: `IReadOnlyList<EventResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadEventsCount
- **HTTP**: `GET /events/count.json` (Production)
- **Notes**: Returns the total count of events for a given site.
- **Signature**: `ReadEventsCount(long? sinceId, long? maxId, Direction? direction, IReadOnlyList<EventKey>? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - 4 params (`sinceId` … `filter`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `since_id` ← `sinceId`, `max_id` ← `maxId`, `direction` ← `direction`, `filter` ← `filter`
- **Returns**: `CountResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`
