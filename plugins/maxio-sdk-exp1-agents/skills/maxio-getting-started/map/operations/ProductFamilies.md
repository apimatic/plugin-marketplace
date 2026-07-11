# ProductFamilies — operations

Accessor: `client.ProductFamilies` · Source: `Api/ProductFamilies.cs` · 4 operations

### CreateProductFamily
- **HTTP**: `POST /product_families.json` (Production)
- **Signature**: `CreateProductFamily(CreateProductFamilyRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProductFamilyResponse`
- **Error**: `SdkException<CreateProductFamilyError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListProductFamilies
- **HTTP**: `GET /product_families.json` (Production)
- **Signature**: `ListProductFamilies(BasicDateField? dateField, DateTimeOffset? startDate, DateTimeOffset? endDate, DateTimeOffset? startDatetime, DateTimeOffset? endDatetime, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `dateField`, `startDate`, `endDate`, `startDatetime`, `endDatetime`
- **Returns**: `IReadOnlyList<ProductFamilyResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListProductsForProductFamily
- **HTTP**: `GET /product_families/{product_family_id}/products.json` (Production)
- **Signature**: `ListProductsForProductFamily(string productFamilyId, BasicDateField? dateField, ListProductsFilter? filter, DateTimeOffset? startDate, DateTimeOffset? endDate, DateTimeOffset? startDatetime, DateTimeOffset? endDatetime, bool? includeArchived, ListProductsInclude? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `dateField`, `filter`, `startDate`, `endDate`, `startDatetime`, `endDatetime`, `includeArchived`, `include`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `IReadOnlyList<ProductResponse>`
- **Error**: `SdkException<ListProductsForProductFamilyError>` — **Case A (typed)**
- **Error accessors**: `TryGetString(out string)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadProductFamily
- **HTTP**: `GET /product_families/{id}.json` (Production)
- **Signature**: `ReadProductFamily(int id, CancellationToken ct = default)`
- **Returns**: `ProductFamilyResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none
