# PaymentTokens — operations

Accessor: `client.PaymentTokens` · Source: `Api/PaymentTokens.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### RetrieveOrDeletePaymentToken
- **HTTP**: `POST /pts/v2/payment-tokens` (Default (apitest))
- **Signature**: `RetrieveOrDeletePaymentToken(RequestModel request, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<RetrieveOrDeletePaymentTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
