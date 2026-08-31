# PurchaseAndRefundDetails — operations

Accessor: `client.PurchaseAndRefundDetails` · Source: `Api/PurchaseAndRefundDetails.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetPurchaseAndRefundDetails
- **HTTP**: `GET /reporting/v3/purchase-refund-details` (Default (apitest))
- **Signature**: `GetPurchaseAndRefundDetails(DateTimeOffset startTime, DateTimeOffset endTime, string? organizationId, string? groupName, int? offset, string? paymentSubtype = "ALL", string? viewBy = "requestDate", int? limit = 2000, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - `groupName` — nullable, no default → **must pass explicitly**
  - `offset` — nullable, no default → **must pass explicitly**
  - defaults: `paymentSubtype` = "ALL", `viewBy` = "requestDate", `limit` = 2000, `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`, `organizationId` ← `organizationId`, `paymentSubtype` ← `paymentSubtype`, `viewBy` ← `viewBy`, `groupName` ← `groupName`, `offset` ← `offset`, `limit` ← `limit`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetPurchaseAndRefundDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
