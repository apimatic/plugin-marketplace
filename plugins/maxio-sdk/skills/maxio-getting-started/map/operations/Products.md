# Products — operations

Accessor: `client.Products` · Source: `Api/Products.cs` · 6 operations

### ArchiveProduct
- **HTTP**: `DELETE /products/{product_id}.json` (Production)
- **Signature**: `ArchiveProduct(int productId, CancellationToken ct = default)`
- **Returns**: `ProductResponse`
- **Error**: `SdkException<ArchiveProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateProduct
- **HTTP**: `POST /product_families/{product_family_id}/products.json` (Production)
- **Signature**: `CreateProduct(string productFamilyId, CreateOrUpdateProductRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProductResponse`
- **Error**: `SdkException<CreateProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListProducts
- **HTTP**: `GET /products.json` (Production)
- **Signature**: `ListProducts(BasicDateField? dateField, ListProductsFilter? filter, DateTimeOffset? endDate, DateTimeOffset? endDatetime, DateTimeOffset? startDate, DateTimeOffset? startDatetime, bool? includeArchived, ListProductsInclude? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `dateField`, `filter`, `endDate`, `endDatetime`, `startDate`, `startDatetime`, `includeArchived`, `include`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `IReadOnlyList<ProductResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadProduct
- **HTTP**: `GET /products/{product_id}.json` (Production)
- **Signature**: `ReadProduct(int productId, CancellationToken ct = default)`
- **Returns**: `ProductResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadProductByHandle
- **HTTP**: `GET /products/handle/{api_handle}.json` (Production)
- **Signature**: `ReadProductByHandle(string apiHandle, CancellationToken ct = default)`
- **Returns**: `ProductResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateProduct
- **HTTP**: `PUT /products/{product_id}.json` (Production)
- **Signature**: `UpdateProduct(int productId, CreateOrUpdateProductRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProductResponse`
- **Error**: `SdkException<UpdateProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
