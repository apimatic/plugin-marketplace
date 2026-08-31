# CustomerPaymentInstrument — operations

Accessor: `client.CustomerPaymentInstrument` · Source: `Api/CustomerPaymentInstrument.cs` · 5 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### DeleteCustomerPaymentInstrument
- **HTTP**: `DELETE /tms/v2/customers/{customerId}/payment-instruments/{paymentInstrumentId}` (Default (apitest))
- **Signature**: `DeleteCustomerPaymentInstrument(string customerId, string paymentInstrumentId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteCustomerPaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeleteCustomerPaymentInstrumentException1(out DeleteCustomerPaymentInstrumentException1)` [400] · `TryGetDeleteCustomerPaymentInstrumentException21(out DeleteCustomerPaymentInstrumentException21)` [403] · `TryGetDeleteCustomerPaymentInstrumentException31(out DeleteCustomerPaymentInstrumentException31)` [404] · `TryGetDeleteCustomerPaymentInstrumentException41(out DeleteCustomerPaymentInstrumentException41)` [409] · `TryGetDeleteCustomerPaymentInstrumentException51(out DeleteCustomerPaymentInstrumentException51)` [410] · `TryGetDeleteCustomerPaymentInstrumentException61(out DeleteCustomerPaymentInstrumentException61)` [424] · `TryGetDeleteCustomerPaymentInstrumentException71(out DeleteCustomerPaymentInstrumentException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetCustomerPaymentInstrument
- **HTTP**: `GET /tms/v2/customers/{customerId}/payment-instruments/{paymentInstrumentId}` (Default (apitest))
- **Signature**: `GetCustomerPaymentInstrument(string customerId, string paymentInstrumentId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `PaymentInstrument11`
- **Error**: `SdkException<GetCustomerPaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetCustomerPaymentInstrumentException1(out GetCustomerPaymentInstrumentException1)` [400] · `TryGetGetCustomerPaymentInstrumentException21(out GetCustomerPaymentInstrumentException21)` [403] · `TryGetGetCustomerPaymentInstrumentException31(out GetCustomerPaymentInstrumentException31)` [404] · `TryGetGetCustomerPaymentInstrumentException41(out GetCustomerPaymentInstrumentException41)` [410] · `TryGetGetCustomerPaymentInstrumentException51(out GetCustomerPaymentInstrumentException51)` [424] · `TryGetGetCustomerPaymentInstrumentException61(out GetCustomerPaymentInstrumentException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetCustomerPaymentInstrumentsList
- **HTTP**: `GET /tms/v2/customers/{customerId}/payment-instruments` (Default (apitest))
- **Signature**: `GetCustomerPaymentInstrumentsList(string customerId, string? profileId, long? offset = 0L, long? limit = 20L, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `offset` = 0L, `limit` = 20L, `requestOptions` = null
- **Query params (wire ← C#)**: `offset` ← `offset`, `limit` ← `limit`
- **Returns**: `PaymentInstrumentList`
- **Error**: `SdkException<GetCustomerPaymentInstrumentsListError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetCustomerPaymentInstrumentsListException1(out GetCustomerPaymentInstrumentsListException1)` [400] · `TryGetGetCustomerPaymentInstrumentsListException21(out GetCustomerPaymentInstrumentsListException21)` [403] · `TryGetGetCustomerPaymentInstrumentsListException31(out GetCustomerPaymentInstrumentsListException31)` [404] · `TryGetGetCustomerPaymentInstrumentsListException41(out GetCustomerPaymentInstrumentsListException41)` [410] · `TryGetGetCustomerPaymentInstrumentsListException51(out GetCustomerPaymentInstrumentsListException51)` [424] · `TryGetGetCustomerPaymentInstrumentsListException61(out GetCustomerPaymentInstrumentsListException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PatchCustomersPaymentInstrument
- **HTTP**: `PATCH /tms/v2/customers/{customerId}/payment-instruments/{paymentInstrumentId}` (Default (apitest))
- **Signature**: `PatchCustomersPaymentInstrument(string customerId, string paymentInstrumentId, string? profileId, string? ifMatch, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - `ifMatch` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `PaymentInstrument11`
- **Error**: `SdkException<PatchCustomersPaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetPatchCustomersPaymentInstrumentException1(out PatchCustomersPaymentInstrumentException1)` [400] · `TryGetPatchCustomersPaymentInstrumentException21(out PatchCustomersPaymentInstrumentException21)` [403] · `TryGetPatchCustomersPaymentInstrumentException31(out PatchCustomersPaymentInstrumentException31)` [404] · `TryGetPatchCustomersPaymentInstrumentException41(out PatchCustomersPaymentInstrumentException41)` [410] · `TryGetPatchCustomersPaymentInstrumentException51(out PatchCustomersPaymentInstrumentException51)` [412] · `TryGetPatchCustomersPaymentInstrumentException61(out PatchCustomersPaymentInstrumentException61)` [424] · `TryGetPatchCustomersPaymentInstrumentException71(out PatchCustomersPaymentInstrumentException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostCustomerPaymentInstrument
- **HTTP**: `POST /tms/v2/customers/{customerId}/payment-instruments` (Default (apitest))
- **Signature**: `PostCustomerPaymentInstrument(string customerId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `PaymentInstrument11`
- **Error**: `SdkException<PostCustomerPaymentInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostCustomerPaymentInstrumentException1(out PostCustomerPaymentInstrumentException1)` [400] · `TryGetPostCustomerPaymentInstrumentException21(out PostCustomerPaymentInstrumentException21)` [403] · `TryGetPostCustomerPaymentInstrumentException31(out PostCustomerPaymentInstrumentException31)` [409] · `TryGetPostCustomerPaymentInstrumentException41(out PostCustomerPaymentInstrumentException41)` [424] · `TryGetPostCustomerPaymentInstrumentException51(out PostCustomerPaymentInstrumentException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
