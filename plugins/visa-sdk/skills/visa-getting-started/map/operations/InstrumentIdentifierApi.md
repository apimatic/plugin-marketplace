# InstrumentIdentifierApi — operations

Accessor: `client.InstrumentIdentifierApi` · Source: `Api/InstrumentIdentifierApi.cs` · 6 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### DeleteInstrumentIdentifier
- **HTTP**: `DELETE /tms/v1/instrumentidentifiers/{instrumentIdentifierId}` (Default (apitest))
- **Signature**: `DeleteInstrumentIdentifier(string instrumentIdentifierId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteInstrumentIdentifierError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeleteInstrumentIdentifierException1(out DeleteInstrumentIdentifierException1)` [403] · `TryGetDeleteInstrumentIdentifierException21(out DeleteInstrumentIdentifierException21)` [404] · `TryGetDeleteInstrumentIdentifierException31(out DeleteInstrumentIdentifierException31)` [409] · `TryGetDeleteInstrumentIdentifierException41(out DeleteInstrumentIdentifierException41)` [410] · `TryGetDeleteInstrumentIdentifierException51(out DeleteInstrumentIdentifierException51)` [424] · `TryGetDeleteInstrumentIdentifierException61(out DeleteInstrumentIdentifierException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetInstrumentIdentifier
- **HTTP**: `GET /tms/v1/instrumentidentifiers/{instrumentIdentifierId}` (Default (apitest))
- **Signature**: `GetInstrumentIdentifier(string instrumentIdentifierId, bool? retrieveBinDetails, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `retrieveBinDetails` — nullable, no default → **must pass explicitly**
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `retrieveBinDetails` ← `retrieveBinDetails`
- **Returns**: `GetInstrumentIdentifierResponse`
- **Error**: `SdkException<GetInstrumentIdentifierError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetInstrumentIdentifierException1(out GetInstrumentIdentifierException1)` [400] · `TryGetGetInstrumentIdentifierException21(out GetInstrumentIdentifierException21)` [403] · `TryGetGetInstrumentIdentifierException31(out GetInstrumentIdentifierException31)` [404] · `TryGetGetInstrumentIdentifierException41(out GetInstrumentIdentifierException41)` [410] · `TryGetGetInstrumentIdentifierException51(out GetInstrumentIdentifierException51)` [424] · `TryGetGetInstrumentIdentifierException61(out GetInstrumentIdentifierException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetInstrumentIdentifierPaymentInstrumentsList
- **HTTP**: `GET /tms/v1/instrumentidentifiers/{instrumentIdentifierId}/paymentinstruments` (Default (apitest))
- **Signature**: `GetInstrumentIdentifierPaymentInstrumentsList(string instrumentIdentifierId, bool? retrieveBinDetails, string? profileId, long? offset = 0L, long? limit = 20L, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `retrieveBinDetails` — nullable, no default → **must pass explicitly**
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `offset` = 0L, `limit` = 20L, `requestOptions` = null
- **Query params (wire ← C#)**: `retrieveBinDetails` ← `retrieveBinDetails`, `offset` ← `offset`, `limit` ← `limit`
- **Returns**: `PaymentInstrumentList`
- **Error**: `SdkException<GetInstrumentIdentifierPaymentInstrumentsListError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetInstrumentIdentifierPaymentInstrumentsListException1(out GetInstrumentIdentifierPaymentInstrumentsListException1)` [400] · `TryGetGetInstrumentIdentifierPaymentInstrumentsListException21(out GetInstrumentIdentifierPaymentInstrumentsListException21)` [403] · `TryGetGetInstrumentIdentifierPaymentInstrumentsListException31(out GetInstrumentIdentifierPaymentInstrumentsListException31)` [404] · `TryGetGetInstrumentIdentifierPaymentInstrumentsListException41(out GetInstrumentIdentifierPaymentInstrumentsListException41)` [410] · `TryGetGetInstrumentIdentifierPaymentInstrumentsListException51(out GetInstrumentIdentifierPaymentInstrumentsListException51)` [424] · `TryGetGetInstrumentIdentifierPaymentInstrumentsListException61(out GetInstrumentIdentifierPaymentInstrumentsListException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PatchInstrumentIdentifier
- **HTTP**: `PATCH /tms/v1/instrumentidentifiers/{instrumentIdentifierId}` (Default (apitest))
- **Signature**: `PatchInstrumentIdentifier(string instrumentIdentifierId, bool? retrieveBinDetails, string? profileId, string? ifMatch, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `retrieveBinDetails` — nullable, no default → **must pass explicitly**
  - `profileId` — nullable, no default → **must pass explicitly**
  - `ifMatch` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `retrieveBinDetails` ← `retrieveBinDetails`
- **Returns**: `PatchInstrumentIdentifierResponse`
- **Error**: `SdkException<PatchInstrumentIdentifierError>` — **Case A (typed)**
- **Error accessors**: `TryGetPatchInstrumentIdentifierException1(out PatchInstrumentIdentifierException1)` [400] · `TryGetPatchInstrumentIdentifierException21(out PatchInstrumentIdentifierException21)` [403] · `TryGetPatchInstrumentIdentifierException31(out PatchInstrumentIdentifierException31)` [404] · `TryGetPatchInstrumentIdentifierException41(out PatchInstrumentIdentifierException41)` [410] · `TryGetPatchInstrumentIdentifierException51(out PatchInstrumentIdentifierException51)` [412] · `TryGetPatchInstrumentIdentifierException61(out PatchInstrumentIdentifierException61)` [424] · `TryGetPatchInstrumentIdentifierException71(out PatchInstrumentIdentifierException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostInstrumentIdentifier
- **HTTP**: `POST /tms/v1/instrumentidentifiers` (Default (apitest))
- **Signature**: `PostInstrumentIdentifier(bool? retrieveBinDetails, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `retrieveBinDetails` — nullable, no default → **must pass explicitly**
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `retrieveBinDetails` ← `retrieveBinDetails`
- **Returns**: `PostInstrumentIdentifierResponse`
- **Error**: `SdkException<PostInstrumentIdentifierError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostInstrumentIdentifierException1(out PostInstrumentIdentifierException1)` [400] · `TryGetPostInstrumentIdentifierException21(out PostInstrumentIdentifierException21)` [403] · `TryGetPostInstrumentIdentifierException31(out PostInstrumentIdentifierException31)` [409] · `TryGetPostInstrumentIdentifierException41(out PostInstrumentIdentifierException41)` [424] · `TryGetPostInstrumentIdentifierException51(out PostInstrumentIdentifierException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostInstrumentIdentifierEnrollment
- **HTTP**: `POST /tms/v1/instrumentidentifiers/{instrumentIdentifierId}/enrollment` (Default (apitest))
- **Signature**: `PostInstrumentIdentifierEnrollment(string instrumentIdentifierId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<PostInstrumentIdentifierEnrollmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostInstrumentIdentifierEnrollmentException1(out PostInstrumentIdentifierEnrollmentException1)` [400] · `TryGetPostInstrumentIdentifierEnrollmentException21(out PostInstrumentIdentifierEnrollmentException21)` [403] · `TryGetPostInstrumentIdentifierEnrollmentException31(out PostInstrumentIdentifierEnrollmentException31)` [404] · `TryGetPostInstrumentIdentifierEnrollmentException41(out PostInstrumentIdentifierEnrollmentException41)` [410] · `TryGetPostInstrumentIdentifierEnrollmentException51(out PostInstrumentIdentifierEnrollmentException51)` [424] · `TryGetPostInstrumentIdentifierEnrollmentException61(out PostInstrumentIdentifierEnrollmentException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
