# PaymentInstrumentApi — operations

Accessor: `client.PaymentInstrumentApi` · Source: `Api/PaymentInstrumentApi.cs` · 4 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### DeletePaymentInstrument
- **HTTP**: `DELETE /tms/v1/paymentinstruments/{paymentInstrumentId}` (Default (apitest))
- **Signature**: `DeletePaymentInstrument(string paymentInstrumentId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeletePaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeletePaymentInstrumentException1(out DeletePaymentInstrumentException1)` [403] · `TryGetDeletePaymentInstrumentException21(out DeletePaymentInstrumentException21)` [404] · `TryGetDeletePaymentInstrumentException31(out DeletePaymentInstrumentException31)` [410] · `TryGetDeletePaymentInstrumentException41(out DeletePaymentInstrumentException41)` [424] · `TryGetDeletePaymentInstrumentException51(out DeletePaymentInstrumentException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetPaymentInstrument
- **HTTP**: `GET /tms/v1/paymentinstruments/{paymentInstrumentId}` (Default (apitest))
- **Signature**: `GetPaymentInstrument(string paymentInstrumentId, bool? retrieveBinDetails, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `retrieveBinDetails` — nullable, no default → **must pass explicitly**
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `retrieveBinDetails` ← `retrieveBinDetails`
- **Returns**: `PaymentInstrument11`
- **Error**: `SdkException<GetPaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetPaymentInstrumentException1(out GetPaymentInstrumentException1)` [400] · `TryGetGetPaymentInstrumentException21(out GetPaymentInstrumentException21)` [403] · `TryGetGetPaymentInstrumentException31(out GetPaymentInstrumentException31)` [404] · `TryGetGetPaymentInstrumentException41(out GetPaymentInstrumentException41)` [410] · `TryGetGetPaymentInstrumentException51(out GetPaymentInstrumentException51)` [424] · `TryGetGetPaymentInstrumentException61(out GetPaymentInstrumentException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PatchPaymentInstrument
- **HTTP**: `PATCH /tms/v1/paymentinstruments/{paymentInstrumentId}` (Default (apitest))
- **Signature**: `PatchPaymentInstrument(string paymentInstrumentId, bool? retrieveBinDetails, string? profileId, string? ifMatch, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `retrieveBinDetails` — nullable, no default → **must pass explicitly**
  - `profileId` — nullable, no default → **must pass explicitly**
  - `ifMatch` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `retrieveBinDetails` ← `retrieveBinDetails`
- **Returns**: `PaymentInstrument11`
- **Error**: `SdkException<PatchPaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetPatchPaymentInstrumentException1(out PatchPaymentInstrumentException1)` [400] · `TryGetPatchPaymentInstrumentException21(out PatchPaymentInstrumentException21)` [403] · `TryGetPatchPaymentInstrumentException31(out PatchPaymentInstrumentException31)` [404] · `TryGetPatchPaymentInstrumentException41(out PatchPaymentInstrumentException41)` [410] · `TryGetPatchPaymentInstrumentException51(out PatchPaymentInstrumentException51)` [412] · `TryGetPatchPaymentInstrumentException61(out PatchPaymentInstrumentException61)` [424] · `TryGetPatchPaymentInstrumentException71(out PatchPaymentInstrumentException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostPaymentInstrument
- **HTTP**: `POST /tms/v1/paymentinstruments` (Default (apitest))
- **Signature**: `PostPaymentInstrument(bool? retrieveBinDetails, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `retrieveBinDetails` — nullable, no default → **must pass explicitly**
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `retrieveBinDetails` ← `retrieveBinDetails`
- **Returns**: `PaymentInstrument11`
- **Error**: `SdkException<PostPaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostPaymentInstrumentException1(out PostPaymentInstrumentException1)` [400] · `TryGetPostPaymentInstrumentException21(out PostPaymentInstrumentException21)` [403] · `TryGetPostPaymentInstrumentException31(out PostPaymentInstrumentException31)` [409] · `TryGetPostPaymentInstrumentException41(out PostPaymentInstrumentException41)` [424] · `TryGetPostPaymentInstrumentException51(out PostPaymentInstrumentException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
