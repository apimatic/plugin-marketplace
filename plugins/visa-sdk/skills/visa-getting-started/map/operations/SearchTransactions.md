# SearchTransactions — operations

Accessor: `client.SearchTransactions` · Source: `Api/SearchTransactions.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateSearch
- **HTTP**: `POST /tss/v2/searches` (Default (apitest))
- **Signature**: `CreateSearch(CreateSearchRequest createSearchRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `TssV2TransactionsPost201Response`
- **Error**: `SdkException<CreateSearchError>` — **Case A (typed)**
- **Error accessors**: `TryGetTssV2TransactionsPost400Response1(out TssV2TransactionsPost400Response1)` [400] · `TryGetTssV2TransactionsPost502Response1(out TssV2TransactionsPost502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetSearch
- **HTTP**: `GET /tss/v2/searches/{searchId}` (Default (apitest))
- **Signature**: `GetSearch(string searchId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetSearchError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
