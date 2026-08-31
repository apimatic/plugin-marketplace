# ReversalApi — operations

Accessor: `client.ReversalApi` · Source: `Api/ReversalApi.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### AuthReversal
- **HTTP**: `POST /pts/v2/payments/{id}/reversals` (Default (apitest))
- **Signature**: `AuthReversal(string id, AuthReversalRequest authReversalRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<AuthReversalError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### MitReversal
- **HTTP**: `POST /pts/v2/reversals` (Default (apitest))
- **Signature**: `MitReversal(MitReversalRequest mitReversalRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<MitReversalError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
