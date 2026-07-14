# SalesCommissions — operations

Accessor: `client.SalesCommissions` · Source: `Api/SalesCommissions.cs` · 3 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ListSalesCommissionSettings
- **HTTP**: `GET /sellers/{seller_id}/sales_commission_settings.json` (Production)
- **Notes**: Lists subscriptions with associated sales reps. Modified Authentication Process The Sales Commission API differs from other Chargify API endpoints. This resource is associated with the seller itself. Up to now all available resources were at the level of the site, therefore creating the API Key per site was a sufficient solution. To share …
- **Signature**: `ListSalesCommissionSettings(string sellerId, bool? liveMode, int? page = 1, int? perPage = 100, string? authorization = "Bearer <<apiKey>>", CancellationToken ct = default)`
  - `liveMode` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 100, `authorization` = "Bearer <<apiKey>>"
- **Query params (wire ← C#)**: `live_mode` ← `liveMode`, `page` ← `page`, `per_page` ← `perPage`
- **Returns**: `IReadOnlyList<SaleRepSettings>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListSalesReps
- **HTTP**: `GET /sellers/{seller_id}/sales_reps.json` (Production)
- **Notes**: Returns a sales rep list with details. Modified Authentication Process The Sales Commission API differs from other Chargify API endpoints. This resource is associated with the seller itself. Up to now all available resources were at the level of the site, therefore creating the API Key per site was a sufficient solution. To share resources at the …
- **Signature**: `ListSalesReps(string sellerId, bool? liveMode, int? page = 1, int? perPage = 100, string? authorization = "Bearer <<apiKey>>", CancellationToken ct = default)`
  - `liveMode` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 100, `authorization` = "Bearer <<apiKey>>"
- **Query params (wire ← C#)**: `live_mode` ← `liveMode`, `page` ← `page`, `per_page` ← `perPage`
- **Returns**: `IReadOnlyList<ListSaleRepItem>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadSalesRep
- **HTTP**: `GET /sellers/{seller_id}/sales_reps/{sales_rep_id}.json` (Production)
- **Notes**: Returns a sales rep and attached subscription details. Modified Authentication Process The Sales Commission API differs from other Chargify API endpoints. This resource is associated with the seller itself. Up to now all available resources were at the level of the site, therefore creating the API Key per site was a sufficient solution. To share …
- **Signature**: `ReadSalesRep(string sellerId, string salesRepId, bool? liveMode, int? page = 1, int? perPage = 100, string? authorization = "Bearer <<apiKey>>", CancellationToken ct = default)`
  - `liveMode` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 100, `authorization` = "Bearer <<apiKey>>"
- **Query params (wire ← C#)**: `live_mode` ← `liveMode`, `page` ← `page`, `per_page` ← `perPage`
- **Returns**: `SaleRep`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`
