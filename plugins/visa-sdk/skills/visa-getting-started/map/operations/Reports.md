# Reports — operations

Accessor: `client.Reports` · Source: `Api/Reports.cs` · 3 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateReport
- **HTTP**: `POST /reporting/v3/reports` (Default (apitest))
- **Signature**: `CreateReport(string? organizationId, CreateAdhocReportRequest createAdhocReportRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreateReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetReportByReportId
- **HTTP**: `GET /reporting/v3/reports/{reportId}` (Default (apitest))
- **Signature**: `GetReportByReportId(string reportId, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetReportByReportIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SearchReports
- **HTTP**: `GET /reporting/v3/reports` (Default (apitest))
- **Signature**: `SearchReports(DateTimeOffset startTime, DateTimeOffset endTime, string timeQueryType, string? organizationId, string? reportMimeType, string? reportFrequency, string? reportName, int? reportDefinitionId, string? reportStatus, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 6 params (`organizationId` … `reportStatus`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`, `timeQueryType` ← `timeQueryType`, `organizationId` ← `organizationId`, `reportMimeType` ← `reportMimeType`, `reportFrequency` ← `reportFrequency`, `reportName` ← `reportName`, `reportDefinitionId` ← `reportDefinitionId`, `reportStatus` ← `reportStatus`
- **Returns**: `void` (Task)
- **Error**: `SdkException<SearchReportsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
