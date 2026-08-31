# RefundApi — operations

Accessor: `client.RefundApi` · Source: `Api/RefundApi.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### RefundCapture
- **HTTP**: `POST /pts/v2/captures/{id}/refunds` (Default (apitest))
- **Signature**: `RefundCapture(string id, RefundCaptureRequest refundCaptureRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<RefundCaptureError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RefundPayment
- **HTTP**: `POST /pts/v2/payments/{id}/refunds` (Default (apitest))
- **Signature**: `RefundPayment(string id, RefundPaymentRequest refundPaymentRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<RefundPaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
