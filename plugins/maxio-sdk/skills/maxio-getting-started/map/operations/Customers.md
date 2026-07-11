# Customers — operations

Accessor: `client.Customers` · Source: `Api/Customers.cs` · 7 operations

### CreateCustomer
- **HTTP**: `POST /customers.json` (Production)
- **Signature**: `CreateCustomer(CreateCustomerRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CustomerResponse`
- **Error**: `SdkException<CreateCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetCustomerErrorResponse1(out CustomerErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteCustomer
- **HTTP**: `DELETE /customers/{id}.json` (Production)
- **Signature**: `DeleteCustomer(int id, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListCustomerSubscriptions
- **HTTP**: `GET /customers/{customer_id}/subscriptions.json` (Production)
- **Signature**: `ListCustomerSubscriptions(int customerId, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<SubscriptionResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListCustomers
- **HTTP**: `GET /customers.json` (Production)
- **Signature**: `ListCustomers(SortingDirection? direction, BasicDateField? dateField, string? startDate, string? endDate, string? startDatetime, string? endDatetime, string? q, int? page = 1, int? perPage = 50, CancellationToken ct = default)`
  - `direction` — nullable, no default → **must pass explicitly**
  - `dateField` — nullable, no default → **must pass explicitly**
  - `startDate` — nullable, no default → **must pass explicitly**
  - `endDate` — nullable, no default → **must pass explicitly**
  - `startDatetime` — nullable, no default → **must pass explicitly**
  - `endDatetime` — nullable, no default → **must pass explicitly**
  - `q` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<CustomerResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadCustomer
- **HTTP**: `GET /customers/{id}.json` (Production)
- **Signature**: `ReadCustomer(int id, CancellationToken ct = default)`
- **Returns**: `CustomerResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadCustomerByReference
- **HTTP**: `GET /customers/lookup.json` (Production)
- **Signature**: `ReadCustomerByReference(string reference, CancellationToken ct = default)`
- **Returns**: `CustomerResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCustomer
- **HTTP**: `PUT /customers/{id}.json` (Production)
- **Signature**: `UpdateCustomer(int id, UpdateCustomerRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CustomerResponse`
- **Error**: `SdkException<UpdateCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetCustomerErrorResponse1(out CustomerErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
