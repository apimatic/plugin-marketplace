# Webhooks — operations

Accessor: `client.Webhooks` · Source: `Api/Webhooks.cs` · 6 operations

### CreateEndpoint
- **HTTP**: `POST /endpoints.json` (Production)
- **Signature**: `CreateEndpoint(CreateOrUpdateEndpointRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `EndpointResponse`
- **Error**: `SdkException<CreateEndpointError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### EnableWebhooks
- **HTTP**: `PUT /webhooks/settings.json` (Production)
- **Signature**: `EnableWebhooks(EnableWebhooksRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `EnableWebhooksResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListEndpoints
- **HTTP**: `GET /endpoints.json` (Production)
- **Signature**: `ListEndpoints(CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<Endpoint>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListWebhooks
- **HTTP**: `GET /webhooks.json` (Production)
- **Signature**: `ListWebhooks(WebhookStatus? status, string? sinceDate, string? untilDate, WebhookOrder? order, int? subscription, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `status` — nullable, no default → **must pass explicitly**
  - `sinceDate` — nullable, no default → **must pass explicitly**
  - `untilDate` — nullable, no default → **must pass explicitly**
  - `order` — nullable, no default → **must pass explicitly**
  - `subscription` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<WebhookResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReplayWebhooks
- **HTTP**: `POST /webhooks/replay.json` (Production)
- **Signature**: `ReplayWebhooks(ReplayWebhooksRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ReplayWebhooksResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateEndpoint
- **HTTP**: `PUT /endpoints/{endpoint_id}.json` (Production)
- **Signature**: `UpdateEndpoint(int endpointId, CreateOrUpdateEndpointRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `EndpointResponse`
- **Error**: `SdkException<UpdateEndpointError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
