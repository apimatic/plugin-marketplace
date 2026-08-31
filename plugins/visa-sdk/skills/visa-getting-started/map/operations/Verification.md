# Verification — operations

Accessor: `client.Verification` · Source: `Api/Verification.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ValidateExportCompliance
- **HTTP**: `POST /risk/v1/export-compliance-inquiries` (Default (apitest))
- **Signature**: `ValidateExportCompliance(ValidateExportComplianceRequest validateExportComplianceRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<ValidateExportComplianceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VerifyCustomerAddress
- **HTTP**: `POST /risk/v1/address-verifications` (Default (apitest))
- **Signature**: `VerifyCustomerAddress(VerifyCustomerAddressRequest verifyCustomerAddressRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<VerifyCustomerAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
