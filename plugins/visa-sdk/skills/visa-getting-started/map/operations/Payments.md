# Payments — operations

Accessor: `client.Payments` · Source: `Api/Payments.cs` · 6 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateOrderRequest
- **HTTP**: `POST /pts/v2/payment-references/{id}/intents` (Default (apitest))
- **Signature**: `CreateOrderRequest(string id, OrderPaymentRequest orderPaymentRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreateOrderRequestError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreatePayment
- **HTTP**: `POST /pts/v2/payments` (Default (apitest))
- **Signature**: `CreatePayment(CreatePaymentRequest createPaymentRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreatePaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateSessionRequest
- **HTTP**: `POST /pts/v2/payment-references` (Default (apitest))
- **Signature**: `CreateSessionRequest(CreateSessionReq createSessionReq, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreateSessionRequestError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### IncrementAuth
- **HTTP**: `PATCH /pts/v2/payments/{id}` (Default (apitest))
- **Signature**: `IncrementAuth(string id, IncrementAuthRequest incrementAuthRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<IncrementAuthError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RefreshPaymentStatus
- **HTTP**: `POST /pts/v2/refresh-payment-status/{id}` (Default (apitest))
- **Signature**: `RefreshPaymentStatus(string id, RefreshPaymentStatusRequest refreshPaymentStatusRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<RefreshPaymentStatusError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateSessionRequest
- **HTTP**: `PATCH /pts/v2/payment-references/{id}` (Default (apitest))
- **Signature**: `UpdateSessionRequest(string id, CreateSessionRequest createSessionRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<UpdateSessionRequestError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
