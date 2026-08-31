# DownloadDtd — operations

Accessor: `client.DownloadDtd` · Source: `Api/DownloadDtd.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetDtdv2
- **HTTP**: `GET /reporting/v3/dtds/{reportDefinitionNameVersion}` (Default (apitest))
- **Signature**: `GetDtdv2(string reportDefinitionNameVersion, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetDtdv2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
