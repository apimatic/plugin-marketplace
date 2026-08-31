# InvoiceSettings — operations

Accessor: `client.InvoiceSettings` · Source: `Api/InvoiceSettings.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetInvoiceSettings
- **HTTP**: `GET /invoicing/v2/invoiceSettings` (Default (apitest))
- **Signature**: `GetInvoiceSettings(ProductType? productType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `productType` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `productType` ← `productType`
- **Returns**: `InvoicingV2InvoiceSettingsGet200Response`
- **Error**: `SdkException<GetInvoiceSettingsError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoiceSettingsGet400Response1(out InvoicingV2InvoiceSettingsGet400Response1)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateInvoiceSettings
- **HTTP**: `PUT /invoicing/v2/invoiceSettings` (Default (apitest))
- **Signature**: `UpdateInvoiceSettings(ProductType? productType, InvoiceSettingsRequest invoiceSettingsRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `productType` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `productType` ← `productType`
- **Returns**: `InvoicingV2InvoiceSettingsPut200Response`
- **Error**: `SdkException<UpdateInvoiceSettingsError>` — **Case A (typed)**
- **Error accessors**: `TryGetInvoicingV2InvoiceSettingsPut400Response1(out InvoicingV2InvoiceSettingsPut400Response1)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
