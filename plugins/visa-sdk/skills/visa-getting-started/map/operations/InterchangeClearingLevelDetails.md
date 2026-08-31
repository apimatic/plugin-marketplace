# InterchangeClearingLevelDetails — operations

Accessor: `client.InterchangeClearingLevelDetails` · Source: `Api/InterchangeClearingLevelDetails.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetInterchangeClearingLevelDetails
- **HTTP**: `GET /reporting/v3/interchange-clearing-level-details` (Default (apitest))
- **Signature**: `GetInterchangeClearingLevelDetails(DateTimeOffset startTime, DateTimeOffset endTime, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`, `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?`
- **No-throw variant**: absent
- **Pagination**: none
