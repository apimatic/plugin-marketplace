# Components — operations

Accessor: `client.Components` · Source: `Api/Components.cs` · 12 operations

### ArchiveComponent
- **HTTP**: `DELETE /product_families/{product_family_id}/components/{component_id}.json` (Production)
- **Signature**: `ArchiveComponent(int productFamilyId, string componentId, CancellationToken ct = default)`
- **Returns**: `Component`
- **Error**: `SdkException<ArchiveComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateEventBasedComponent
- **HTTP**: `POST /product_families/{product_family_id}/event_based_components.json` (Production)
- **Signature**: `CreateEventBasedComponent(string productFamilyId, CreateEbbComponent? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<CreateEventBasedComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateMeteredComponent
- **HTTP**: `POST /product_families/{product_family_id}/metered_components.json` (Production)
- **Signature**: `CreateMeteredComponent(string productFamilyId, CreateMeteredComponent? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<CreateMeteredComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateOnOffComponent
- **HTTP**: `POST /product_families/{product_family_id}/on_off_components.json` (Production)
- **Signature**: `CreateOnOffComponent(string productFamilyId, CreateOnOffComponent? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<CreateOnOffComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreatePrepaidUsageComponent
- **HTTP**: `POST /product_families/{product_family_id}/prepaid_usage_components.json` (Production)
- **Signature**: `CreatePrepaidUsageComponent(string productFamilyId, CreatePrepaidComponent? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<CreatePrepaidUsageComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateQuantityBasedComponent
- **HTTP**: `POST /product_families/{product_family_id}/quantity_based_components.json` (Production)
- **Signature**: `CreateQuantityBasedComponent(string productFamilyId, CreateQuantityBasedComponent? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<CreateQuantityBasedComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FindComponent
- **HTTP**: `GET /components/lookup.json` (Production)
- **Signature**: `FindComponent(string handle, CancellationToken ct = default)`
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListComponents
- **HTTP**: `GET /components.json` (Production)
- **Signature**: `ListComponents(BasicDateField? dateField, string? startDate, string? endDate, string? startDatetime, string? endDatetime, bool? includeArchived, ListComponentsFilter? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `dateField`, `startDate`, `endDate`, `startDatetime`, `endDatetime`, `includeArchived`, `filter`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `IReadOnlyList<ComponentResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListComponentsForProductFamily
- **HTTP**: `GET /product_families/{product_family_id}/components.json` (Production)
- **Signature**: `ListComponentsForProductFamily(int productFamilyId, bool? includeArchived, ListComponentsFilter? filter, BasicDateField? dateField, string? endDate, string? endDatetime, string? startDate, string? startDatetime, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `includeArchived`, `filter`, `dateField`, `endDate`, `endDatetime`, `startDate`, `startDatetime`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `IReadOnlyList<ComponentResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadComponent
- **HTTP**: `GET /product_families/{product_family_id}/components/{component_id}.json` (Production)
- **Signature**: `ReadComponent(int productFamilyId, string componentId, CancellationToken ct = default)`
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateComponent
- **HTTP**: `PUT /components/{component_id}.json` (Production)
- **Signature**: `UpdateComponent(string componentId, UpdateComponentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<UpdateComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateProductFamilyComponent
- **HTTP**: `PUT /product_families/{product_family_id}/components/{component_id}.json` (Production)
- **Signature**: `UpdateProductFamilyComponent(int productFamilyId, string componentId, UpdateComponentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<UpdateProductFamilyComponentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
