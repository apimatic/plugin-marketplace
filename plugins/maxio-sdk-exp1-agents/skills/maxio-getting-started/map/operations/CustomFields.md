# CustomFields — operations

Accessor: `client.CustomFields` · Source: `Api/CustomFields.cs` · 9 operations

### CreateMetadata
- **HTTP**: `POST /{resource_type}/{resource_id}/metadata.json` (Production)
- **Signature**: `CreateMetadata(ResourceType resourceType, int resourceId, CreateMetadataRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<Metadata>`
- **Error**: `SdkException<CreateMetadataError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateMetafields
- **HTTP**: `POST /{resource_type}/metafields.json` (Production)
- **Signature**: `CreateMetafields(ResourceType resourceType, CreateMetafieldsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<Metafield>`
- **Error**: `SdkException<CreateMetafieldsError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteMetadata
- **HTTP**: `DELETE /{resource_type}/{resource_id}/metadata.json` (Production)
- **Signature**: `DeleteMetadata(ResourceType resourceType, int resourceId, string? name, IReadOnlyList<string>? names, CancellationToken ct = default)`
  - `name` — nullable, no default → **must pass explicitly**
  - `names` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteMetadataError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteMetafield
- **HTTP**: `DELETE /{resource_type}/metafields.json` (Production)
- **Signature**: `DeleteMetafield(ResourceType resourceType, string? name, CancellationToken ct = default)`
  - `name` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteMetafieldError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListMetadata
- **HTTP**: `GET /{resource_type}/{resource_id}/metadata.json` (Production)
- **Signature**: `ListMetadata(ResourceType resourceType, int resourceId, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
- **Returns**: `PaginatedMetadata`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListMetadataForResourceType
- **HTTP**: `GET /{resource_type}/metadata.json` (Production)
- **Signature**: `ListMetadataForResourceType(ResourceType resourceType, BasicDateField? dateField, DateTimeOffset? startDate, DateTimeOffset? endDate, DateTimeOffset? startDatetime, DateTimeOffset? endDatetime, bool? withDeleted, IReadOnlyList<int>? resourceIds, SortingDirection? direction, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `dateField` — nullable, no default → **must pass explicitly**
  - `startDate` — nullable, no default → **must pass explicitly**
  - `endDate` — nullable, no default → **must pass explicitly**
  - `startDatetime` — nullable, no default → **must pass explicitly**
  - `endDatetime` — nullable, no default → **must pass explicitly**
  - `withDeleted` — nullable, no default → **must pass explicitly**
  - `resourceIds` — nullable, no default → **must pass explicitly**
  - `direction` — nullable, no default → **must pass explicitly**
- **Returns**: `PaginatedMetadata`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListMetafields
- **HTTP**: `GET /{resource_type}/metafields.json` (Production)
- **Signature**: `ListMetafields(ResourceType resourceType, string? name, SortingDirection? direction, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `name` — nullable, no default → **must pass explicitly**
  - `direction` — nullable, no default → **must pass explicitly**
- **Returns**: `ListMetafieldsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### UpdateMetadata
- **HTTP**: `PUT /{resource_type}/{resource_id}/metadata.json` (Production)
- **Signature**: `UpdateMetadata(ResourceType resourceType, int resourceId, UpdateMetadataRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<Metadata>`
- **Error**: `SdkException<UpdateMetadataError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateMetafield
- **HTTP**: `PUT /{resource_type}/metafields.json` (Production)
- **Signature**: `UpdateMetafield(ResourceType resourceType, UpdateMetafieldsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<Metafield>`
- **Error**: `SdkException<UpdateMetafieldError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
