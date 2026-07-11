# ApiExports — operations

Accessor: `client.ApiExports` · Source: `Api/ApiExports.cs` · 9 operations

### ExportInvoices
- **HTTP**: `POST /api_exports/invoices.json` (Production)
- **Signature**: `ExportInvoices(CancellationToken ct = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `SdkException<ExportInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [409] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ExportProformaInvoices
- **HTTP**: `POST /api_exports/proforma_invoices.json` (Production)
- **Signature**: `ExportProformaInvoices(CancellationToken ct = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `SdkException<ExportProformaInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [409] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ExportSubscriptions
- **HTTP**: `POST /api_exports/subscriptions.json` (Production)
- **Signature**: `ExportSubscriptions(CancellationToken ct = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `SdkException<ExportSubscriptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [409] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListExportedInvoices
- **HTTP**: `GET /api_exports/invoices/{batch_id}/rows.json` (Production)
- **Signature**: `ListExportedInvoices(string batchId, int? perPage = 100, int? page = 1, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<Invoice>`
- **Error**: `SdkException<ListExportedInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListExportedProformaInvoices
- **HTTP**: `GET /api_exports/proforma_invoices/{batch_id}/rows.json` (Production)
- **Signature**: `ListExportedProformaInvoices(string batchId, int? perPage = 100, int? page = 1, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<ProformaInvoice>`
- **Error**: `SdkException<ListExportedProformaInvoicesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListExportedSubscriptions
- **HTTP**: `GET /api_exports/subscriptions/{batch_id}/rows.json` (Production)
- **Signature**: `ListExportedSubscriptions(string batchId, int? perPage = 100, int? page = 1, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<Subscription>`
- **Error**: `SdkException<ListExportedSubscriptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadInvoicesExport
- **HTTP**: `GET /api_exports/invoices/{batch_id}.json` (Production)
- **Signature**: `ReadInvoicesExport(string batchId, CancellationToken ct = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `SdkException<ReadInvoicesExportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadProformaInvoicesExport
- **HTTP**: `GET /api_exports/proforma_invoices/{batch_id}.json` (Production)
- **Signature**: `ReadProformaInvoicesExport(string batchId, CancellationToken ct = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `SdkException<ReadProformaInvoicesExportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadSubscriptionsExport
- **HTTP**: `GET /api_exports/subscriptions/{batch_id}.json` (Production)
- **Signature**: `ReadSubscriptionsExport(string batchId, CancellationToken ct = default)`
- **Returns**: `BatchJobResponse`
- **Error**: `SdkException<ReadSubscriptionsExportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
