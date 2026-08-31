# BinLookup — operations

Accessor: `client.BinLookup` · Source: `Api/BinLookup.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetAccountInfo
- **HTTP**: `POST /bin/v1/binlookup` (Default (apitest))
- **Signature**: `GetAccountInfo(RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetAccountInfoResponse`
- **Error**: `SdkException<GetAccountInfoError>` — **Case A (typed)**
- **Error accessors**: `TryGetBinLookupv400Response1(out BinLookupv400Response1)` [400] · `TryGetBinLookup403Response1(out BinLookup403Response1)` [403] · `TryGetGetAccountInfoException1(out GetAccountInfoException1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
