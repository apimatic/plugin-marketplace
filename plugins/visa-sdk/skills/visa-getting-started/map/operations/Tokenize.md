# Tokenize — operations

Accessor: `client.Tokenize` · Source: `Api/Tokenize.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### TokenizeInvoke
- **HTTP**: `POST /tms/v2/tokenize` (Default (apitest))
- **Signature**: `TokenizeInvoke(string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `TokenizeResponse`
- **Error**: `SdkException<TokenizeError>` — **Case A (typed)**
- **Error accessors**: `TryGetTokenizeException1(out TokenizeException1)` [400] · `TryGetTokenizeException21(out TokenizeException21)` [403] · `TryGetTokenizeException31(out TokenizeException31)` [424] · `TryGetTokenizeException41(out TokenizeException41)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
