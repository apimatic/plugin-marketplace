# ReportDefinitions — operations

Accessor: `client.ReportDefinitions` · Source: `Api/ReportDefinitions.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetResourceInfoByReportDefinition
- **HTTP**: `GET /reporting/v3/report-definitions/{reportDefinitionName}` (Default (apitest))
- **Signature**: `GetResourceInfoByReportDefinition(string reportDefinitionName, string? subscriptionType, string? reportMimeType, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `subscriptionType` — nullable, no default → **must pass explicitly**
  - `reportMimeType` — nullable, no default → **must pass explicitly**
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `subscriptionType` ← `subscriptionType`, `reportMimeType` ← `reportMimeType`, `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetResourceInfoByReportDefinitionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetResourceV2Info
- **HTTP**: `GET /reporting/v3/report-definitions` (Default (apitest))
- **Signature**: `GetResourceV2Info(string? subscriptionType, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `subscriptionType` — nullable, no default → **must pass explicitly**
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `subscriptionType` ← `subscriptionType`, `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetResourceV2InfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
