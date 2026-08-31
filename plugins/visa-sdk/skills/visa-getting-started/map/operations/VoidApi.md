# VoidApi — operations

Accessor: `client.VoidApi` · Source: `Api/VoidApi.cs` · 5 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### MitVoid
- **HTTP**: `POST /pts/v2/voids` (Default (apitest))
- **Signature**: `MitVoid(MitVoidRequest mitVoidRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<MitVoidError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidCapture
- **HTTP**: `POST /pts/v2/captures/{id}/voids` (Default (apitest))
- **Signature**: `VoidCapture(string id, VoidCaptureRequest voidCaptureRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<VoidCaptureError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidCredit
- **HTTP**: `POST /pts/v2/credits/{id}/voids` (Default (apitest))
- **Signature**: `VoidCredit(string id, VoidCreditRequest voidCreditRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<VoidCreditError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidPayment
- **HTTP**: `POST /pts/v2/payments/{id}/voids` (Default (apitest))
- **Signature**: `VoidPayment(string id, VoidPaymentRequest voidPaymentRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<VoidPaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidRefund
- **HTTP**: `POST /pts/v2/refunds/{id}/voids` (Default (apitest))
- **Signature**: `VoidRefund(string id, VoidRefundRequest voidRefundRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<VoidRefundError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
