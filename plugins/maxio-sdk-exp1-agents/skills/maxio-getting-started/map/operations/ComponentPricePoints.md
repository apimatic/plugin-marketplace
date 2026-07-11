# ComponentPricePoints — operations

Accessor: `client.ComponentPricePoints` · Source: `Api/ComponentPricePoints.cs` · 12 operations

### ArchiveComponentPricePoint
- **HTTP**: `DELETE /components/{component_id}/price_points/{price_point_id}.json` (Production)
- **Signature**: `ArchiveComponentPricePoint(ComponentIdModel componentId, PricePointIdModel pricePointId, CancellationToken ct = default)`
- **Returns**: `ComponentPricePointResponse`
- **Error**: `SdkException<ArchiveComponentPricePointError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### BulkCreateComponentPricePoints
- **HTTP**: `POST /components/{component_id}/price_points/bulk.json` (Production)
- **Signature**: `BulkCreateComponentPricePoints(string componentId, CreateComponentPricePointsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentPricePointsResponse`
- **Error**: `SdkException<BulkCreateComponentPricePointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CloneComponentPricePoint
- **HTTP**: `POST /components/{component_id}/price_points/{price_point_id}/clone.json` (Production)
- **Signature**: `CloneComponentPricePoint(ComponentIdModel componentId, PricePointIdModel pricePointId, CloneComponentPricePointRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentPricePointCurrencyOverageResponse`
- **Error**: `SdkException<CloneComponentPricePointError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateComponentPricePoint
- **HTTP**: `POST /components/{component_id}/price_points.json` (Production)
- **Signature**: `CreateComponentPricePoint(int componentId, CreateComponentPricePointRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentPricePointResponse`
- **Error**: `SdkException<CreateComponentPricePointError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateCurrencyPrices
- **HTTP**: `POST /price_points/{price_point_id}/currency_prices.json` (Production)
- **Signature**: `CreateCurrencyPrices(int pricePointId, CreateCurrencyPricesRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentCurrencyPricesResponse`
- **Error**: `SdkException<CreateCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListAllComponentPricePoints
- **HTTP**: `GET /components_price_points.json` (Production)
- **Signature**: `ListAllComponentPricePoints(ListComponentsPricePointsInclude? include, SortingDirection? direction, ListPricePointsFilter? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `include`, `direction`, `filter`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `ListComponentsPricePointsResponse`
- **Error**: `SdkException<ListAllComponentPricePointsError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListComponentPricePoints
- **HTTP**: `GET /components/{component_id}/price_points.json` (Production)
- **Signature**: `ListComponentPricePoints(int componentId, bool? currencyPrices, IReadOnlyList<PricePointType>? filterType, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `currencyPrices`, `filterType`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `ComponentPricePointsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### PromoteComponentPricePointToDefault
- **HTTP**: `PUT /components/{component_id}/price_points/{price_point_id}/default.json` (Production)
- **Signature**: `PromoteComponentPricePointToDefault(int componentId, int pricePointId, CancellationToken ct = default)`
- **Returns**: `ComponentResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadComponentPricePoint
- **HTTP**: `GET /components/{component_id}/price_points/{price_point_id}.json` (Production)
- **Signature**: `ReadComponentPricePoint(ComponentIdModel componentId, PricePointIdModel pricePointId, bool? currencyPrices, CancellationToken ct = default)`
  - `currencyPrices` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentPricePointCurrencyOverageResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UnarchiveComponentPricePoint
- **HTTP**: `PUT /components/{component_id}/price_points/{price_point_id}/unarchive.json` (Production)
- **Signature**: `UnarchiveComponentPricePoint(int componentId, int pricePointId, CancellationToken ct = default)`
- **Returns**: `ComponentPricePointResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateComponentPricePoint
- **HTTP**: `PUT /components/{component_id}/price_points/{price_point_id}.json` (Production)
- **Signature**: `UpdateComponentPricePoint(ComponentIdModel componentId, PricePointIdModel pricePointId, UpdateComponentPricePointRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentPricePointResponse`
- **Error**: `SdkException<UpdateComponentPricePointError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCurrencyPrices
- **HTTP**: `PUT /price_points/{price_point_id}/currency_prices.json` (Production)
- **Signature**: `UpdateCurrencyPrices(int pricePointId, UpdateCurrencyPricesRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ComponentCurrencyPricesResponse`
- **Error**: `SdkException<UpdateCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
