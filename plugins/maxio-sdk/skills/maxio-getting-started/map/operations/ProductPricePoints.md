# ProductPricePoints — operations

Accessor: `client.ProductPricePoints` · Source: `Api/ProductPricePoints.cs` · 11 operations

### ArchiveProductPricePoint
- **HTTP**: `DELETE /products/{product_id}/price_points/{price_point_id}.json` (Production)
- **Signature**: `ArchiveProductPricePoint(ProductIdModel productId, PricePointIdModel pricePointId, CancellationToken ct = default)`
- **Returns**: `ProductPricePointResponse`
- **Error**: `SdkException<ArchiveProductPricePointError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### BulkCreateProductPricePoints
- **HTTP**: `POST /products/{product_id}/price_points/bulk.json` (Production)
- **Signature**: `BulkCreateProductPricePoints(int productId, BulkCreateProductPricePointsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `BulkCreateProductPricePointsResponse`
- **Error**: `SdkException<BulkCreateProductPricePointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetMapOfJsonElement(out IReadOnlyDictionary<string, JsonElement>)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateProductCurrencyPrices
- **HTTP**: `POST /product_price_points/{product_price_point_id}/currency_prices.json` (Production)
- **Signature**: `CreateProductCurrencyPrices(int productPricePointId, CreateProductCurrencyPricesRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CurrencyPricesResponse`
- **Error**: `SdkException<CreateProductCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateProductPricePoint
- **HTTP**: `POST /products/{product_id}/price_points.json` (Production)
- **Signature**: `CreateProductPricePoint(ProductIdModel productId, CreateProductPricePointRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProductPricePointResponse`
- **Error**: `SdkException<CreateProductPricePointError>` — **Case A (typed)**
- **Error accessors**: `TryGetProductPricePointErrorResponse1(out ProductPricePointErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListAllProductPricePoints
- **HTTP**: `GET /products_price_points.json` (Production)
- **Signature**: `ListAllProductPricePoints(SortingDirection? direction, ListPricePointsFilter? filter, ListProductsPricePointsInclude? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `direction`, `filter`, `include`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `ListProductPricePointsResponse`
- **Error**: `SdkException<ListAllProductPricePointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListProductPricePoints
- **HTTP**: `GET /products/{product_id}/price_points.json` (Production)
- **Signature**: `ListProductPricePoints(ProductIdModel productId, bool? currencyPrices, IReadOnlyList<PricePointType>? filterType, bool? archived, int? page = 1, int? perPage = 10, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `currencyPrices`, `filterType`, `archived`
  - `page` = 1, `perPage` = 10 (optional defaults)
- **Returns**: `ListProductPricePointsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### PromoteProductPricePointToDefault
- **HTTP**: `PATCH /products/{product_id}/price_points/{price_point_id}/default.json` (Production)
- **Signature**: `PromoteProductPricePointToDefault(int productId, int pricePointId, CancellationToken ct = default)`
- **Returns**: `ProductResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadProductPricePoint
- **HTTP**: `GET /products/{product_id}/price_points/{price_point_id}.json` (Production)
- **Signature**: `ReadProductPricePoint(ProductIdModel productId, PricePointIdModel pricePointId, bool? currencyPrices, CancellationToken ct = default)`
  - `currencyPrices` — nullable, no default → **must pass explicitly**
- **Returns**: `ProductPricePointResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UnarchiveProductPricePoint
- **HTTP**: `PATCH /products/{product_id}/price_points/{price_point_id}/unarchive.json` (Production)
- **Signature**: `UnarchiveProductPricePoint(int productId, int pricePointId, CancellationToken ct = default)`
- **Returns**: `ProductPricePointResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateProductCurrencyPrices
- **HTTP**: `PUT /product_price_points/{product_price_point_id}/currency_prices.json` (Production)
- **Signature**: `UpdateProductCurrencyPrices(int productPricePointId, UpdateCurrencyPricesRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CurrencyPricesResponse`
- **Error**: `SdkException<UpdateProductCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateProductPricePoint
- **HTTP**: `PUT /products/{product_id}/price_points/{price_point_id}.json` (Production)
- **Signature**: `UpdateProductPricePoint(ProductIdModel productId, PricePointIdModel pricePointId, UpdateProductPricePointRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProductPricePointResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none
