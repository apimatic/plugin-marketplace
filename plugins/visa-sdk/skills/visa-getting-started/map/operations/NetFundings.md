# NetFundings — operations

Accessor: `client.NetFundings` · Source: `Api/NetFundings.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetNetFundingDetails
- **HTTP**: `GET /reporting/v3/net-fundings` (Default (apitest))
- **Signature**: `GetNetFundingDetails(DateTimeOffset startTime, DateTimeOffset endTime, string? organizationId, string? groupName, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - `groupName` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `startTime` ← `startTime`, `endTime` ← `endTime`, `organizationId` ← `organizationId`, `groupName` ← `groupName`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetNetFundingDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 403, 404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
