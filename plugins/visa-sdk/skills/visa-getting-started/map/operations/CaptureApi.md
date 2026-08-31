# CaptureApi — operations

Accessor: `client.CaptureApi` · Source: `Api/CaptureApi.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CapturePayment
- **HTTP**: `POST /pts/v2/payments/{id}/captures` (Default (apitest))
- **Signature**: `CapturePayment(string id, CapturePaymentRequest capturePaymentRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CapturePaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
