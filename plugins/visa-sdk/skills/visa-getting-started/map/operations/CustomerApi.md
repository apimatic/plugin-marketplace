# CustomerApi — operations

Accessor: `client.CustomerApi` · Source: `Api/CustomerApi.cs` · 4 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### DeleteCustomer
- **HTTP**: `DELETE /tms/v2/customers/{customerId}` (Default (apitest))
- **Signature**: `DeleteCustomer(string customerId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeleteCustomerException1(out DeleteCustomerException1)` [400] · `TryGetDeleteCustomerException21(out DeleteCustomerException21)` [403] · `TryGetDeleteCustomerException31(out DeleteCustomerException31)` [404] · `TryGetDeleteCustomerException41(out DeleteCustomerException41)` [410] · `TryGetDeleteCustomerException51(out DeleteCustomerException51)` [424] · `TryGetDeleteCustomerException61(out DeleteCustomerException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetCustomer
- **HTTP**: `GET /tms/v2/customers/{customerId}` (Default (apitest))
- **Signature**: `GetCustomer(string customerId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `GetCustomerResponse`
- **Error**: `SdkException<GetCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetCustomerException1(out GetCustomerException1)` [400] · `TryGetGetCustomerException21(out GetCustomerException21)` [403] · `TryGetGetCustomerException31(out GetCustomerException31)` [404] · `TryGetGetCustomerException41(out GetCustomerException41)` [410] · `TryGetGetCustomerException51(out GetCustomerException51)` [424] · `TryGetGetCustomerException61(out GetCustomerException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PatchCustomer
- **HTTP**: `PATCH /tms/v2/customers/{customerId}` (Default (apitest))
- **Signature**: `PatchCustomer(string customerId, string? profileId, string? ifMatch, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - `ifMatch` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `PatchCustomerResponse`
- **Error**: `SdkException<PatchCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetPatchCustomerException1(out PatchCustomerException1)` [400] · `TryGetPatchCustomerException21(out PatchCustomerException21)` [403] · `TryGetPatchCustomerException31(out PatchCustomerException31)` [404] · `TryGetPatchCustomerException41(out PatchCustomerException41)` [410] · `TryGetPatchCustomerException51(out PatchCustomerException51)` [412] · `TryGetPatchCustomerException61(out PatchCustomerException61)` [424] · `TryGetPatchCustomerException71(out PatchCustomerException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostCustomer
- **HTTP**: `POST /tms/v2/customers` (Default (apitest))
- **Signature**: `PostCustomer(string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `TmsV2CustomersResponse`
- **Error**: `SdkException<PostCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostCustomerException1(out PostCustomerException1)` [400] · `TryGetPostCustomerException21(out PostCustomerException21)` [403] · `TryGetPostCustomerException31(out PostCustomerException31)` [409] · `TryGetPostCustomerException41(out PostCustomerException41)` [424] · `TryGetPostCustomerException51(out PostCustomerException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
