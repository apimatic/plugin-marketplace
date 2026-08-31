# PullFundsApi — operations

Accessor: `client.PullFundsApi` · Source: `Api/PullFundsApi.cs` · 3 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreatePullFundsRefund
- **HTTP**: `POST /pts/v1/pull-funds-transfer/{id}/refund` (Default (apitest))
- **Signature**: `CreatePullFundsRefund(string id, string contentType, string xRequestid, string vcMerchantId, string vcPermissions, string vcCorrelationId, string vcOrganizationId, PullFundsRefundRequest pullFundsRefundRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreatePullFundsRefundError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 404, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreatePullFundsReversal
- **HTTP**: `POST /pts/v1/pull-funds-transfer/{id}/reversal` (Default (apitest))
- **Signature**: `CreatePullFundsReversal(string id, string contentType, string xRequestid, string vcMerchantId, string vcPermissions, string vcCorrelationId, string vcOrganizationId, PullFundsReversalRequest pullFundsReversalRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreatePullFundsReversalError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 404, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreatePullFundsTransfer
- **HTTP**: `POST /pts/v1/pull-funds-transfer` (Default (apitest))
- **Signature**: `CreatePullFundsTransfer(string contentType, string xRequestid, string vcMerchantId, string vcPermissions, string vcCorrelationId, string vcOrganizationId, PullFundsRequest pullFundsRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreatePullFundsTransferError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 401, 404, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
