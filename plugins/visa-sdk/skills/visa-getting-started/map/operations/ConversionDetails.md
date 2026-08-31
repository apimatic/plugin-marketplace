# ConversionDetails — operations

Accessor: `client.ConversionDetails` · Source: `Api/ConversionDetails.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetConversionDetail
- **HTTP**: `GET /reporting/v3/conversion-details` (Default (apitest))
- **Signature**: `GetConversionDetail(DateTimeOffset startTime, DateTimeOffset endTime, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`, `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetConversionDetailError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
