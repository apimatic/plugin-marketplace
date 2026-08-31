# PaymentBatchSummaries — operations

Accessor: `client.PaymentBatchSummaries` · Source: `Api/PaymentBatchSummaries.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetPaymentBatchSummary
- **HTTP**: `GET /reporting/v3/payment-batch-summaries` (Default (apitest))
- **Signature**: `GetPaymentBatchSummary(DateTimeOffset startTime, DateTimeOffset endTime, string? organizationId, string? rollUp, string? breakdown, int? startDayOfWeek, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 4 params (`organizationId` … `startDayOfWeek`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`, `organizationId` ← `organizationId`, `rollUp` ← `rollUp`, `breakdown` ← `breakdown`, `startDayOfWeek` ← `startDayOfWeek`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetPaymentBatchSummaryError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
