# Invoices — operations

Accessor: `client.Invoices` · Source: `Api/Invoices.cs` · 7 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateInvoice
- **HTTP**: `POST /invoicing/v2/invoices` (Default (apitest))
- **Signature**: `CreateInvoice(CreateInvoiceRequest createInvoiceRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `InvoicingV2InvoicesPost201Response`
- **Error**: `SdkException<CreateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoicesPost400Response1(out InvoicingV2InvoicesPost400Response1)` [400] · `TryGetInvoicingV2InvoicesPost404Response1(out InvoicingV2InvoicesPost404Response1)` [404] · `TryGetInvoicingV2InvoicesPost502Response1(out InvoicingV2InvoicesPost502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetAllInvoices
- **HTTP**: `GET /invoicing/v2/invoices` (Default (apitest))
- **Signature**: `GetAllInvoices(int offset, int limit, string? status, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `status` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `offset` ← `offset`, `limit` ← `limit`, `status` ← `status`
- **Returns**: `InvoicingV2InvoicesAllGet200Response`
- **Error**: `SdkException<GetAllInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoicesAllGet400Response1(out InvoicingV2InvoicesAllGet400Response1)` [400] · `TryGetInvoicingV2InvoicesAllGet404Response1(out InvoicingV2InvoicesAllGet404Response1)` [404] · `TryGetInvoicingV2InvoicesAllGet502Response1(out InvoicingV2InvoicesAllGet502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetInvoice
- **HTTP**: `GET /invoicing/v2/invoices/{id}` (Default (apitest))
- **Signature**: `GetInvoice(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `InvoicingV2InvoicesGet200Response`
- **Error**: `SdkException<GetInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoicesGet400Response1(out InvoicingV2InvoicesGet400Response1)` [400] · `TryGetInvoicingV2InvoicesGet404Response1(out InvoicingV2InvoicesGet404Response1)` [404] · `TryGetInvoicingV2InvoicesGet502Response1(out InvoicingV2InvoicesGet502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PerformCancelAction
- **HTTP**: `POST /invoicing/v2/invoices/{id}/cancelation` (Default (apitest))
- **Signature**: `PerformCancelAction(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `InvoicingV2InvoicesCancel200Response`
- **Error**: `SdkException<PerformCancelActionError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoicesCancel400Response1(out InvoicingV2InvoicesCancel400Response1)` [400] · `TryGetInvoicingV2InvoicesCancel404Response1(out InvoicingV2InvoicesCancel404Response1)` [404] · `TryGetInvoicingV2InvoicesCancel502Response1(out InvoicingV2InvoicesCancel502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PerformPublishAction
- **HTTP**: `POST /invoicing/v2/invoices/{id}/publication` (Default (apitest))
- **Signature**: `PerformPublishAction(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `InvoicingV2InvoicesPublish200Response`
- **Error**: `SdkException<PerformPublishActionError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoicesPublish400Response1(out InvoicingV2InvoicesPublish400Response1)` [400] · `TryGetInvoicingV2InvoicesPublish404Response1(out InvoicingV2InvoicesPublish404Response1)` [404] · `TryGetInvoicingV2InvoicesPublish502Response1(out InvoicingV2InvoicesPublish502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PerformSendAction
- **HTTP**: `POST /invoicing/v2/invoices/{id}/delivery` (Default (apitest))
- **Signature**: `PerformSendAction(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `InvoicingV2InvoicesSend200Response`
- **Error**: `SdkException<PerformSendActionError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoicesSend400Response1(out InvoicingV2InvoicesSend400Response1)` [400] · `TryGetInvoicingV2InvoicesSend404Response1(out InvoicingV2InvoicesSend404Response1)` [404] · `TryGetInvoicingV2InvoicesSend502Response1(out InvoicingV2InvoicesSend502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateInvoice
- **HTTP**: `PUT /invoicing/v2/invoices/{id}` (Default (apitest))
- **Signature**: `UpdateInvoice(string id, UpdateInvoiceRequest updateInvoiceRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `InvoicingV2InvoicesPut200Response`
- **Error**: `SdkException<UpdateInvoiceError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoicesPut400Response1(out InvoicingV2InvoicesPut400Response1)` [400] · `TryGetInvoicingV2InvoicesPut404Response1(out InvoicingV2InvoicesPut404Response1)` [404] · `TryGetInvoicingV2InvoicesPut502Response1(out InvoicingV2InvoicesPut502Response1)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
