# BillingAgreements — operations

Accessor: `client.BillingAgreements` · Source: `Api/BillingAgreements.cs` · 3 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### BillingAgreementsDeRegistration
- **HTTP**: `PATCH /pts/v2/billing-agreements/{id}` (Default (apitest))
- **Signature**: `BillingAgreementsDeRegistration(string id, ModifyBillingAgreement modifyBillingAgreement, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<BillingAgreementsDeRegistrationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### BillingAgreementsIntimation
- **HTTP**: `POST /pts/v2/billing-agreements/{id}/intimations` (Default (apitest))
- **Signature**: `BillingAgreementsIntimation(string id, IntimateBillingAgreement intimateBillingAgreement, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<BillingAgreementsIntimationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### BillingAgreementsRegistration
- **HTTP**: `POST /pts/v2/billing-agreements` (Default (apitest))
- **Signature**: `BillingAgreementsRegistration(CreateBillingAgreement createBillingAgreement, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<BillingAgreementsRegistrationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
