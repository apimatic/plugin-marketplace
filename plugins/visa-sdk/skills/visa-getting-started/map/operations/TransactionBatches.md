# TransactionBatches — operations

Accessor: `client.TransactionBatches` · Source: `Api/TransactionBatches.cs` · 3 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetTransactionBatchDetails
- **HTTP**: `GET /pts/v1/transaction-batch-details/{id}` (Default (apitest))
- **Signature**: `GetTransactionBatchDetails(string id, DateTimeOffset? uploadDate, string? status, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `uploadDate` — nullable, no default → **must pass explicitly**
  - `status` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `uploadDate` ← `uploadDate`, `status` ← `status`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetTransactionBatchDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 403, 404, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetTransactionBatchId
- **HTTP**: `GET /pts/v1/transaction-batches/{id}` (Default (apitest))
- **Signature**: `GetTransactionBatchId(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetTransactionBatchIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 403, 404, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetTransactionBatches
- **HTTP**: `GET /pts/v1/transaction-batches` (Default (apitest))
- **Signature**: `GetTransactionBatches(DateTimeOffset startTime, DateTimeOffset endTime, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetTransactionBatchesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 403, 404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
