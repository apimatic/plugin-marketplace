# TransactionDetailsApi — operations

Accessor: `client.TransactionDetailsApi` · Source: `Api/TransactionDetailsApi.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetTransaction
- **HTTP**: `GET /tss/v2/transactions/{id}` (Default (apitest))
- **Signature**: `GetTransaction(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetTransactionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404, 500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
