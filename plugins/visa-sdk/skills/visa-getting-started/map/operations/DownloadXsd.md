# DownloadXsd — operations

Accessor: `client.DownloadXsd` · Source: `Api/DownloadXsd.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetXsdv2
- **HTTP**: `GET /reporting/v3/xsds/{reportDefinitionNameVersion}` (Default (apitest))
- **Signature**: `GetXsdv2(string reportDefinitionNameVersion, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetXsdv2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
