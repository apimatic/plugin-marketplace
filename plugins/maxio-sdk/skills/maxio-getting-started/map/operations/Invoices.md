# Invoices — operations

Accessor: `client.Invoices` · Source: `Api/Invoices.cs` · 17 operations

### CreateInvoice
- **HTTP**: `POST /subscriptions/{subscription_id}/invoices.json` (Production)
- **Signature**: `CreateInvoice(int subscriptionId, CreateInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `InvoiceResponse`
- **Error**: `SdkException<CreateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### IssueInvoice
- **HTTP**: `POST /invoices/{uid}/issue.json` (Production)
- **Signature**: `IssueInvoice(string uid, IssueInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<IssueInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListConsolidatedInvoiceSegments
- **HTTP**: `GET /invoices/{invoice_uid}/segments.json` (Production)
- **Signature**: `ListConsolidatedInvoiceSegments(string invoiceUid, Direction? direction, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `direction` — nullable, no default → **must pass explicitly**
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `ConsolidatedInvoice`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListCreditNotes
- **HTTP**: `GET /credit_notes.json` (Production)
- **Signature**: `ListCreditNotes(int? subscriptionId, int? page = 1, int? perPage = 20, bool? lineItems = false, bool? discounts = false, bool? taxes = false, bool? refunds = false, bool? applications = false, CancellationToken ct = default)`
  - `subscriptionId` — nullable, no default → **must pass explicitly**
  - `page` = 1, `perPage` = 20; `lineItems`/`discounts`/`taxes`/`refunds`/`applications` = false (optional defaults)
- **Returns**: `ListCreditNotesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListInvoiceEvents
- **HTTP**: `GET /invoices/events.json` (Production)
- **Signature**: `ListInvoiceEvents(string? sinceDate, long? sinceId, string? invoiceUid, string? withChangeInvoiceStatus, IReadOnlyList<InvoiceEventType>? eventTypes, int? page = 1, int? perPage = 100, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `sinceDate`, `sinceId`, `invoiceUid`, `withChangeInvoiceStatus`, `eventTypes`
  - `page` = 1, `perPage` = 100 (optional defaults)
- **Returns**: `ListInvoiceEventsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListInvoices
- **HTTP**: `GET /invoices.json` (Production)
- **Signature**: `ListInvoices(string? startDate, string? endDate, InvoiceStatus? status, int? subscriptionId, string? subscriptionGroupUid, string? consolidationLevel, Direction? direction, InvoiceDateField? dateField, string? startDatetime, string? endDatetime, IReadOnlyList<int>? customerIds, IReadOnlyList<string>? number, IReadOnlyList<int>? productIds, InvoiceSortField? sort, int? page = 1, int? perPage = 20, bool? lineItems = false, bool? discounts = false, bool? taxes = false, bool? credits = false, bool? payments = false, bool? customFields = false, bool? refunds = false, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `startDate`, `endDate`, `status`, `subscriptionId`, `subscriptionGroupUid`, `consolidationLevel`, `direction`, `dateField`, `startDatetime`, `endDatetime`, `customerIds`, `number`, `productIds`, `sort`
  - `page` = 1, `perPage` = 20; `lineItems`/`discounts`/`taxes`/`credits`/`payments`/`customFields`/`refunds` = false (optional defaults)
- **Returns**: `ListInvoicesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### PreviewCustomerInformationChanges
- **HTTP**: `POST /invoices/{uid}/customer_information/preview.json` (Production)
- **Signature**: `PreviewCustomerInformationChanges(string uid, CancellationToken ct = default)`
- **Returns**: `CustomerChangesPreviewResponse`
- **Error**: `SdkException<PreviewCustomerInformationChangesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [404, 422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadCreditNote
- **HTTP**: `GET /credit_notes/{uid}.json` (Production)
- **Signature**: `ReadCreditNote(string uid, CancellationToken ct = default)`
- **Returns**: `CreditNote`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadInvoice
- **HTTP**: `GET /invoices/{uid}.json` (Production)
- **Signature**: `ReadInvoice(string uid, CancellationToken ct = default)`
- **Returns**: `Invoice`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### RecordPaymentForInvoice
- **HTTP**: `POST /invoices/{uid}/payments.json` (Production)
- **Signature**: `RecordPaymentForInvoice(string uid, CreateInvoicePaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<RecordPaymentForInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RecordPaymentForMultipleInvoices
- **HTTP**: `POST /invoices/payments.json` (Production)
- **Signature**: `RecordPaymentForMultipleInvoices(CreateMultiInvoicePaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `MultiInvoicePaymentResponse`
- **Error**: `SdkException<RecordPaymentForMultipleInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RecordPaymentForSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/payments.json` (Production)
- **Signature**: `RecordPaymentForSubscription(int subscriptionId, RecordPaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `RecordPaymentResponse`
- **Error**: `SdkException<RecordPaymentForSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RefundInvoice
- **HTTP**: `POST /invoices/{uid}/refunds.json` (Production)
- **Signature**: `RefundInvoice(string uid, RefundInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<RefundInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReopenInvoice
- **HTTP**: `POST /invoices/{uid}/reopen.json` (Production)
- **Signature**: `ReopenInvoice(string uid, CancellationToken ct = default)`
- **Returns**: `Invoice`
- **Error**: `SdkException<ReopenInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetObject(out object?)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SendInvoice
- **HTTP**: `POST /invoices/{uid}/deliveries.json` (Production)
- **Signature**: `SendInvoice(string uid, SendInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<SendInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCustomerInformation
- **HTTP**: `PUT /invoices/{uid}/customer_information.json` (Production)
- **Signature**: `UpdateCustomerInformation(string uid, CancellationToken ct = default)`
- **Returns**: `Invoice`
- **Error**: `SdkException<UpdateCustomerInformationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [404, 422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidInvoice
- **HTTP**: `POST /invoices/{uid}/void.json` (Production)
- **Signature**: `VoidInvoice(string uid, VoidInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<VoidInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetObject(out object?)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
