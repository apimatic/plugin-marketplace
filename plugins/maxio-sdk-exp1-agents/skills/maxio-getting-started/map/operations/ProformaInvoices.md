# ProformaInvoices — operations

Accessor: `client.ProformaInvoices` · Source: `Api/ProformaInvoices.cs` · 10 operations

### CreateConsolidatedProformaInvoice
- **HTTP**: `POST /subscription_groups/{uid}/proforma_invoices.json` (Production)
- **Signature**: `CreateConsolidatedProformaInvoice(string uid, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreateConsolidatedProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateProformaInvoice
- **HTTP**: `POST /subscriptions/{subscription_id}/proforma_invoices.json` (Production)
- **Signature**: `CreateProformaInvoice(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `ProformaInvoice`
- **Error**: `SdkException<CreateProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateSignupProformaInvoice
- **HTTP**: `POST /subscriptions/proforma_invoices.json` (Production)
- **Signature**: `CreateSignupProformaInvoice(CreateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProformaInvoice`
- **Error**: `SdkException<CreateSignupProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetProformaBadRequestErrorResponse1(out ProformaBadRequestErrorResponse1)` [400] · `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeliverProformaInvoice
- **HTTP**: `POST /proforma_invoices/{proforma_invoice_uid}/deliveries.json` (Production)
- **Signature**: `DeliverProformaInvoice(string proformaInvoiceUid, DeliverProformaInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProformaInvoice`
- **Error**: `SdkException<DeliverProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListProformaInvoices
- **HTTP**: `GET /subscriptions/{subscription_id}/proforma_invoices.json` (Production)
- **Signature**: `ListProformaInvoices(int subscriptionId, string? startDate, string? endDate, ProformaInvoiceStatus? status, Direction? direction, int? page = 1, int? perPage = 20, bool? lineItems = false, bool? discounts = false, bool? taxes = false, bool? credits = false, bool? payments = false, bool? customFields = false, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `startDate`, `endDate`, `status`, `direction`
  - `page` = 1, `perPage` = 20; `lineItems`/`discounts`/`taxes`/`credits`/`payments`/`customFields` = false (optional defaults)
- **Returns**: `ListProformaInvoicesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListSubscriptionGroupProformaInvoices
- **HTTP**: `GET /subscription_groups/{uid}/proforma_invoices.json` (Production)
- **Signature**: `ListSubscriptionGroupProformaInvoices(string uid, bool? lineItems = false, bool? discounts = false, bool? taxes = false, bool? credits = false, bool? payments = false, bool? customFields = false, CancellationToken ct = default)`
  - `lineItems`/`discounts`/`taxes`/`credits`/`payments`/`customFields` = false (optional defaults)
- **Returns**: `ListProformaInvoicesResponse`
- **Error**: `SdkException<ListSubscriptionGroupProformaInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PreviewProformaInvoice
- **HTTP**: `POST /subscriptions/{subscription_id}/proforma_invoices/preview.json` (Production)
- **Signature**: `PreviewProformaInvoice(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `ProformaInvoice`
- **Error**: `SdkException<PreviewProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PreviewSignupProformaInvoice
- **HTTP**: `POST /subscriptions/proforma_invoices/preview.json` (Production)
- **Signature**: `PreviewSignupProformaInvoice(CreateSignupProformaPreviewInclude? include, CreateSubscriptionRequest? body, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `include`, `body`
- **Returns**: `SignupProformaPreviewResponse`
- **Error**: `SdkException<PreviewSignupProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetProformaBadRequestErrorResponse1(out ProformaBadRequestErrorResponse1)` [400] · `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadProformaInvoice
- **HTTP**: `GET /proforma_invoices/{proforma_invoice_uid}.json` (Production)
- **Signature**: `ReadProformaInvoice(string proformaInvoiceUid, CancellationToken ct = default)`
- **Returns**: `ProformaInvoice`
- **Error**: `SdkException<ReadProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidProformaInvoice
- **HTTP**: `POST /proforma_invoices/{proforma_invoice_uid}/void.json` (Production)
- **Signature**: `VoidProformaInvoice(string proformaInvoiceUid, VoidInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ProformaInvoice`
- **Error**: `SdkException<VoidProformaInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
