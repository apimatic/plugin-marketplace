# SecureFileShare — operations

Accessor: `client.SecureFileShare` · Source: `Api/SecureFileShare.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetFile
- **HTTP**: `GET /sfs/v1/files/{fileId}` (Default (apitest))
- **Signature**: `GetFile(string fileId, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetFileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetFileDetail
- **HTTP**: `GET /sfs/v1/file-details` (Default (apitest))
- **Signature**: `GetFileDetail(DateTimeOffset startDate, DateTimeOffset endDate, string? organizationId, string? name, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - `name` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startDate` ← `startDate`, `endDate` ← `endDate`, `organizationId` ← `organizationId`, `name` ← `name`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetFileDetailError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
