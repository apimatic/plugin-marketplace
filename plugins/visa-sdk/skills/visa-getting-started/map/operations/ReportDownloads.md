# ReportDownloads — operations

Accessor: `client.ReportDownloads` · Source: `Api/ReportDownloads.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### DownloadReport
- **HTTP**: `GET /reporting/v3/report-downloads` (Default (apitest))
- **Signature**: `DownloadReport(DateTimeOffset reportDate, string reportName, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `reportDate` ← `reportDate`, `reportName` ← `reportName`, `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<DownloadReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
