# Invoices — operations

Accessor: `client.Invoices` · Source: `Api/Invoices.cs` · 17 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateInvoice
- **HTTP**: `POST /subscriptions/{subscription_id}/invoices.json` (Production)
- **Notes**: This endpoint will allow you to create an ad hoc invoice. Basic Behavior You can create a basic invoice by sending an array of line items to this endpoint. Each line item, at a minimum, must include a title, a quantity and a unit price. Example: { "invoice": { "line_items": [ { "title": "A Product", "quantity": 12, "unit_price": "150.00" } ] } } …
- **Signature**: `CreateInvoice(int subscriptionId, CreateInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `InvoiceResponse`
- **Error**: `SdkException<CreateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### IssueInvoice
- **HTTP**: `POST /invoices/{uid}/issue.json` (Production)
- **Notes**: This endpoint allows you to issue an invoice that is in "pending" or "draft" status. For example, you can issue an invoice that was created when allocating new quantity on a component and using "accrue charges" option. You cannot issue a pending child invoice that was created for a member subscription in a group. For Remittance subscriptions, the …
- **Signature**: `IssueInvoice(string uid, IssueInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<IssueInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListConsolidatedInvoiceSegments
- **HTTP**: `GET /invoices/{invoice_uid}/segments.json` (Production)
- **Notes**: Invoice segments returned on the index will only include totals, not detailed breakdowns for `line_items`, `discounts`, `taxes`, `credits`, `payments`, or `custom_fields`.
- **Signature**: `ListConsolidatedInvoiceSegments(string invoiceUid, Direction? direction, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `direction` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `direction` ← `direction`
- **Returns**: `ConsolidatedInvoice`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListCreditNotes
- **HTTP**: `GET /credit_notes.json` (Production)
- **Notes**: Credit Notes are like inverse invoices. They reduce the amount a customer owes. By default, the credit notes returned by this endpoint will exclude the arrays of `line_items`, `discounts`, `taxes`, `applications`, or `refunds`. To include these arrays, pass the specific field as a key in the query with a value set to `true`.
- **Signature**: `ListCreditNotes(int? subscriptionId, int? page = 1, int? perPage = 20, bool? lineItems = false, bool? discounts = false, bool? taxes = false, bool? refunds = false, bool? applications = false, CancellationToken ct = default)`
  - `subscriptionId` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 20, `lineItems` = false, `discounts` = false, `taxes` = false, `refunds` = false, `applications` = false
- **Query params (wire ← C#)**: `subscription_id` ← `subscriptionId`, `page` ← `page`, `per_page` ← `perPage`, `line_items` ← `lineItems`, `discounts` ← `discounts`, `taxes` ← `taxes`, `refunds` ← `refunds`, `applications` ← `applications`
- **Returns**: `ListCreditNotesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListInvoiceEvents
- **HTTP**: `GET /invoices/events.json` (Production)
- **Notes**: This endpoint returns a list of invoice events. Each event contains event "data" (such as an applied payment) as well as a snapshot of the `invoice` at the time of event completion. Exposed event types are: issue_invoice apply_credit_note apply_payment refund_invoice void_invoice void_remainder backport_invoice change_invoice_status …
- **Signature**: `ListInvoiceEvents(string? sinceDate, long? sinceId, string? invoiceUid, string? withChangeInvoiceStatus, IReadOnlyList<InvoiceEventType>? eventTypes, int? page = 1, int? perPage = 100, CancellationToken ct = default)`
  - 5 params (`sinceDate` … `eventTypes`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 100
- **Query params (wire ← C#)**: `since_date` ← `sinceDate`, `since_id` ← `sinceId`, `page` ← `page`, `per_page` ← `perPage`, `invoice_uid` ← `invoiceUid`, `with_change_invoice_status` ← `withChangeInvoiceStatus`, `event_types` ← `eventTypes`
- **Returns**: `ListInvoiceEventsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListInvoices
- **HTTP**: `GET /invoices.json` (Production)
- **Notes**: By default, invoices returned on the index will only include totals, not detailed breakdowns for `line_items`, `discounts`, `taxes`, `credits`, `payments`, `custom_fields`, or `refunds`. To include breakdowns, pass the specific field as a key in the query with a value set to `true`.
- **Signature**: `ListInvoices(string? startDate, string? endDate, InvoiceStatus? status, int? subscriptionId, string? subscriptionGroupUid, string? consolidationLevel, Direction? direction, InvoiceDateField? dateField, string? startDatetime, string? endDatetime, IReadOnlyList<int>? customerIds, IReadOnlyList<string>? number, IReadOnlyList<int>? productIds, InvoiceSortField? sort, int? page = 1, int? perPage = 20, bool? lineItems = false, bool? discounts = false, bool? taxes = false, bool? credits = false, bool? payments = false, bool? customFields = false, bool? refunds = false, CancellationToken ct = default)`
  - 14 params (`startDate` … `sort`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 20, `lineItems` = false, `discounts` = false, `taxes` = false, `credits` = false, `payments` = false, `customFields` = false, `refunds` = false
- **Query params (wire ← C#)**: `start_date` ← `startDate`, `end_date` ← `endDate`, `status` ← `status`, `subscription_id` ← `subscriptionId`, `subscription_group_uid` ← `subscriptionGroupUid`, `consolidation_level` ← `consolidationLevel`, `page` ← `page`, `per_page` ← `perPage`, `direction` ← `direction`, `line_items` ← `lineItems`, `discounts` ← `discounts`, `taxes` ← `taxes`, `credits` ← `credits`, `payments` ← `payments`, `custom_fields` ← `customFields`, `refunds` ← `refunds`, `date_field` ← `dateField`, `start_datetime` ← `startDatetime`, `end_datetime` ← `endDatetime`, `customer_ids` ← `customerIds`, `number` ← `number`, `product_ids` ← `productIds`, `sort` ← `sort`
- **Returns**: `ListInvoicesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### PreviewCustomerInformationChanges
- **HTTP**: `POST /invoices/{uid}/customer_information/preview.json` (Production)
- **Notes**: Customer information may change after an invoice is issued, which may lead to a mismatch between customer information that is present on an open invoice and actual customer information. This endpoint allows you to preview these differences, if any. The endpoint doesn't accept a request body. Customer information differences are calculated on the …
- **Signature**: `PreviewCustomerInformationChanges(string uid, CancellationToken ct = default)`
- **Returns**: `CustomerChangesPreviewResponse`
- **Error**: `SdkException<PreviewCustomerInformationChangesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [404, 422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadCreditNote
- **HTTP**: `GET /credit_notes/{uid}.json` (Production)
- **Notes**: Use this endpoint to retrieve the details for a credit note.
- **Signature**: `ReadCreditNote(string uid, CancellationToken ct = default)`
- **Returns**: `CreditNote`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadInvoice
- **HTTP**: `GET /invoices/{uid}.json` (Production)
- **Notes**: Use this endpoint to retrieve the details for an invoice. PDF Invoice retrieval Individual PDF Invoices can be retrieved by using the "Accept" header application/pdf or appending .pdf as the format portion of the URL: Accept:application/pdf -H https://acme.chargify.com/invoices/inv_8gd8tdhtd3hgr.pdf &gt; output_file.pdf URL: …
- **Signature**: `ReadInvoice(string uid, CancellationToken ct = default)`
- **Returns**: `Invoice`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### RecordPaymentForInvoice
- **HTTP**: `POST /invoices/{uid}/payments.json` (Production)
- **Notes**: Applies a payment of a given type against a specific invoice. If you would like to apply a payment across multiple invoices, you can use the Bulk Payment endpoint.
- **Signature**: `RecordPaymentForInvoice(string uid, CreateInvoicePaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<RecordPaymentForInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RecordPaymentForMultipleInvoices
- **HTTP**: `POST /invoices/payments.json` (Production)
- **Notes**: This API call should be used when you want to record an external payment against multiple invoices. To apply a payment to multiple invoices, at minimum, specify the `amount` and `applications` (i.e., `invoice_uid` and `amount`) details. { "payment": { "memo": "to pay the bills", "details": "check number 8675309", "method": "check", "amount": …
- **Signature**: `RecordPaymentForMultipleInvoices(CreateMultiInvoicePaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `MultiInvoicePaymentResponse`
- **Error**: `SdkException<RecordPaymentForMultipleInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RecordPaymentForSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/payments.json` (Production)
- **Notes**: Record an external payment made against a subscription that will pay partially or in full one or more invoices. Payment will be applied starting with the oldest open invoice and then next oldest, and so on until the amount of the payment is fully consumed. Excess payment will result in the creation of a prepayment on the Invoice Account. Only …
- **Signature**: `RecordPaymentForSubscription(int subscriptionId, RecordPaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `RecordPaymentResponse`
- **Error**: `SdkException<RecordPaymentForSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RefundInvoice
- **HTTP**: `POST /invoices/{uid}/refunds.json` (Production)
- **Notes**: Refund an invoice, segment, or consolidated invoice. Partial Refund for Consolidated Invoice A refund less than the total of a consolidated invoice will be split across its segments. For a $50.00 refund on a $100.00 consolidated invoice with one $60.00 segment and one $40.00 segment, the refunded amount will be applied as 50% of each ($30.00 and …
- **Signature**: `RefundInvoice(string uid, RefundInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<RefundInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReopenInvoice
- **HTTP**: `POST /invoices/{uid}/reopen.json` (Production)
- **Notes**: This endpoint allows you to reopen any invoice with the "canceled" status. Invoices enter "canceled" status if they were open at the time the subscription was canceled (whether through dunning or an intentional cancellation). Invoices with "canceled" status are no longer considered to be due. Once reopened, they are considered due for payment. …
- **Signature**: `ReopenInvoice(string uid, CancellationToken ct = default)`
- **Returns**: `Invoice`
- **Error**: `SdkException<ReopenInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetObject(out object?)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SendInvoice
- **HTTP**: `POST /invoices/{uid}/deliveries.json` (Production)
- **Notes**: This endpoint allows for invoices to be programmatically delivered via email. This endpoint supports the delivery of both ad-hoc and automatically generated invoices. Additionally, this endpoint supports email delivery to direct recipients, carbon-copy (cc) recipients, and blind carbon-copy (bcc) recipients. File Attachments : You can attach files …
- **Signature**: `SendInvoice(string uid, SendInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<SendInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCustomerInformation
- **HTTP**: `PUT /invoices/{uid}/customer_information.json` (Production)
- **Notes**: This endpoint updates customer information on an open invoice and returns the updated invoice. If you would like to preview changes that will be applied, use the `/invoices/{uid}/customer_information/preview.json` endpoint first. The endpoint doesn't accept a request body. Customer information differences are calculated on the application side.
- **Signature**: `UpdateCustomerInformation(string uid, CancellationToken ct = default)`
- **Returns**: `Invoice`
- **Error**: `SdkException<UpdateCustomerInformationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [404, 422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VoidInvoice
- **HTTP**: `POST /invoices/{uid}/void.json` (Production)
- **Notes**: This endpoint allows you to void any invoice with the "open" or "canceled" status. It will also allow voiding of an invoice with the "pending" status if it is not a consolidated invoice.
- **Signature**: `VoidInvoice(string uid, VoidInvoiceRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `Invoice`
- **Error**: `SdkException<VoidInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetObject(out object?)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
