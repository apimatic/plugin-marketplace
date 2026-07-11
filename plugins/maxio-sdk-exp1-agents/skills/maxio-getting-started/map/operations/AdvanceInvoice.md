# AdvanceInvoice — operations

Accessor: `client.AdvanceInvoice` · Source: `Api/AdvanceInvoice.cs` · 3 operations

### IssueAdvanceInvoice
- **HTTP**: `POST /subscriptions/{subscription_id}/advance_invoice/issue.json` (Production)
- **Signature**: `IssueAdvanceInvoice(int subscriptionId, IssueAdvanceInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<IssueAdvanceInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadAdvanceInvoice
- **HTTP**: `GET /subscriptions/{subscription_id}/advance_invoice.json` (Production)
- **Signature**: `ReadAdvanceInvoice(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `Invoice`
- **Error**: `SdkException<ReadAdvanceInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidAdvanceInvoice
- **HTTP**: `POST /subscriptions/{subscription_id}/advance_invoice/void.json` (Production)
- **Signature**: `VoidAdvanceInvoice(int subscriptionId, VoidInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<VoidAdvanceInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
