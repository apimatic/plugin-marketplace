# SalesCommissions — operations

Accessor: `client.SalesCommissions` · Source: `Api/SalesCommissions.cs` · 3 operations

### ListSalesCommissionSettings
- **HTTP**: `GET /sellers/{seller_id}/sales_commission_settings.json` (Production)
- **Signature**: `ListSalesCommissionSettings(string sellerId, bool? liveMode, int? page = 1, int? perPage = 100, string? authorization = "Bearer <<apiKey>>", CancellationToken ct = default)`
  - `liveMode` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<SaleRepSettings>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListSalesReps
- **HTTP**: `GET /sellers/{seller_id}/sales_reps.json` (Production)
- **Signature**: `ListSalesReps(string sellerId, bool? liveMode, int? page = 1, int? perPage = 100, string? authorization = "Bearer <<apiKey>>", CancellationToken ct = default)`
  - `liveMode` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<ListSaleRepItem>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadSalesRep
- **HTTP**: `GET /sellers/{seller_id}/sales_reps/{sales_rep_id}.json` (Production)
- **Signature**: `ReadSalesRep(string sellerId, string salesRepId, bool? liveMode, int? page = 1, int? perPage = 100, string? authorization = "Bearer <<apiKey>>", CancellationToken ct = default)`
  - `liveMode` — nullable, no default → **must pass explicitly**
- **Returns**: `SaleRep`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`
