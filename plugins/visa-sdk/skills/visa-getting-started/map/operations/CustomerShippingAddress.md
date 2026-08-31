# CustomerShippingAddress — operations

Accessor: `client.CustomerShippingAddress` · Source: `Api/CustomerShippingAddress.cs` · 5 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### DeleteCustomerShippingAddress
- **HTTP**: `DELETE /tms/v2/customers/{customerId}/shipping-addresses/{shippingAddressId}` (Default (apitest))
- **Signature**: `DeleteCustomerShippingAddress(string customerId, string shippingAddressId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteCustomerShippingAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeleteCustomerShippingAddressException1(out DeleteCustomerShippingAddressException1)` [400] · `TryGetDeleteCustomerShippingAddressException21(out DeleteCustomerShippingAddressException21)` [403] · `TryGetDeleteCustomerShippingAddressException31(out DeleteCustomerShippingAddressException31)` [404] · `TryGetDeleteCustomerShippingAddressException41(out DeleteCustomerShippingAddressException41)` [409] · `TryGetDeleteCustomerShippingAddressException51(out DeleteCustomerShippingAddressException51)` [410] · `TryGetDeleteCustomerShippingAddressException61(out DeleteCustomerShippingAddressException61)` [424] · `TryGetDeleteCustomerShippingAddressException71(out DeleteCustomerShippingAddressException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetCustomerShippingAddress
- **HTTP**: `GET /tms/v2/customers/{customerId}/shipping-addresses/{shippingAddressId}` (Default (apitest))
- **Signature**: `GetCustomerShippingAddress(string customerId, string shippingAddressId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `GetCustomerShippingAddressResponse`
- **Error**: `SdkException<GetCustomerShippingAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetCustomerShippingAddressException1(out GetCustomerShippingAddressException1)` [400] · `TryGetGetCustomerShippingAddressException21(out GetCustomerShippingAddressException21)` [403] · `TryGetGetCustomerShippingAddressException31(out GetCustomerShippingAddressException31)` [404] · `TryGetGetCustomerShippingAddressException41(out GetCustomerShippingAddressException41)` [410] · `TryGetGetCustomerShippingAddressException51(out GetCustomerShippingAddressException51)` [424] · `TryGetGetCustomerShippingAddressException61(out GetCustomerShippingAddressException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetCustomerShippingAddressesList
- **HTTP**: `GET /tms/v2/customers/{customerId}/shipping-addresses` (Default (apitest))
- **Signature**: `GetCustomerShippingAddressesList(string customerId, string? profileId, long? offset = 0L, long? limit = 20L, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `offset` = 0L, `limit` = 20L, `requestOptions` = null
- **Query params (wire ← C#)**: `offset` ← `offset`, `limit` ← `limit`
- **Returns**: `ShippingAddressListForCustomer`
- **Error**: `SdkException<GetCustomerShippingAddressesListError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetCustomerShippingAddressesListException1(out GetCustomerShippingAddressesListException1)` [400] · `TryGetGetCustomerShippingAddressesListException21(out GetCustomerShippingAddressesListException21)` [403] · `TryGetGetCustomerShippingAddressesListException31(out GetCustomerShippingAddressesListException31)` [404] · `TryGetGetCustomerShippingAddressesListException41(out GetCustomerShippingAddressesListException41)` [410] · `TryGetGetCustomerShippingAddressesListException51(out GetCustomerShippingAddressesListException51)` [424] · `TryGetGetCustomerShippingAddressesListException61(out GetCustomerShippingAddressesListException61)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PatchCustomersShippingAddress
- **HTTP**: `PATCH /tms/v2/customers/{customerId}/shipping-addresses/{shippingAddressId}` (Default (apitest))
- **Signature**: `PatchCustomersShippingAddress(string customerId, string shippingAddressId, string? profileId, string? ifMatch, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - `ifMatch` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `PatchCustomersShippingAddressResponse`
- **Error**: `SdkException<PatchCustomersShippingAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetPatchCustomersShippingAddressException1(out PatchCustomersShippingAddressException1)` [400] · `TryGetPatchCustomersShippingAddressException21(out PatchCustomersShippingAddressException21)` [403] · `TryGetPatchCustomersShippingAddressException31(out PatchCustomersShippingAddressException31)` [404] · `TryGetPatchCustomersShippingAddressException41(out PatchCustomersShippingAddressException41)` [410] · `TryGetPatchCustomersShippingAddressException51(out PatchCustomersShippingAddressException51)` [412] · `TryGetPatchCustomersShippingAddressException61(out PatchCustomersShippingAddressException61)` [424] · `TryGetPatchCustomersShippingAddressException71(out PatchCustomersShippingAddressException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostCustomerShippingAddress
- **HTTP**: `POST /tms/v2/customers/{customerId}/shipping-addresses` (Default (apitest))
- **Signature**: `PostCustomerShippingAddress(string customerId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `PostCustomerShippingAddressResponse`
- **Error**: `SdkException<PostCustomerShippingAddressError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostCustomerShippingAddressException1(out PostCustomerShippingAddressException1)` [400] · `TryGetPostCustomerShippingAddressException21(out PostCustomerShippingAddressException21)` [403] · `TryGetPostCustomerShippingAddressException31(out PostCustomerShippingAddressException31)` [409] · `TryGetPostCustomerShippingAddressException41(out PostCustomerShippingAddressException41)` [424] · `TryGetPostCustomerShippingAddressException51(out PostCustomerShippingAddressException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
