# NotificationOfChanges — operations

Accessor: `client.NotificationOfChanges` · Source: `Api/NotificationOfChanges.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetNotificationOfChangeReport
- **HTTP**: `GET /reporting/v3/notification-of-changes` (Default (apitest))
- **Signature**: `GetNotificationOfChangeReport(DateTimeOffset startTime, DateTimeOffset endTime, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetNotificationOfChangeReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
