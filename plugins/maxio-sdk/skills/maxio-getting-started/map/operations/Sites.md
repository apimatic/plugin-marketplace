# Sites — operations

Accessor: `client.Sites` · Source: `Api/Sites.cs` · 3 operations

### ClearSite
- **HTTP**: `POST /sites/clear_data.json` (Production)
- **Signature**: `ClearSite(CleanupScope? cleanupScope, CancellationToken ct = default)`
  - `cleanupScope` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListChargifyJsPublicKeys
- **HTTP**: `GET /chargify_js_keys.json` (Production)
- **Signature**: `ListChargifyJsPublicKeys(int? page = 1, int? perPage = 20, CancellationToken ct = default)`
- **Returns**: `ListPublicKeysResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadSite
- **HTTP**: `GET /site.json` (Production)
- **Signature**: `ReadSite(CancellationToken ct = default)`
- **Returns**: `SiteResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none
