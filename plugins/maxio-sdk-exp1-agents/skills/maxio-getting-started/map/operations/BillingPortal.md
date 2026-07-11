# BillingPortal — operations

Accessor: `client.BillingPortal` · Source: `Api/BillingPortal.cs` · 4 operations

### EnableBillingPortalForCustomer
- **HTTP**: `POST /portal/customers/{customer_id}/enable.json` (Production)
- **Signature**: `EnableBillingPortalForCustomer(int customerId, AutoInvite? autoInvite, CancellationToken ct = default)`
  - `autoInvite` — nullable, no default → **must pass explicitly**
- **Returns**: `CustomerResponse`
- **Error**: `SdkException<EnableBillingPortalForCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadBillingPortalLink
- **HTTP**: `GET /portal/customers/{customer_id}/management_link.json` (Production)
- **Signature**: `ReadBillingPortalLink(int customerId, CancellationToken ct = default)`
- **Returns**: `PortalManagementLink`
- **Error**: `SdkException<ReadBillingPortalLinkError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetTooManyManagementLinkRequestsError1(out TooManyManagementLinkRequestsError1)` [429] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ResendBillingPortalInvitation
- **HTTP**: `POST /portal/customers/{customer_id}/invitations/invite.json` (Production)
- **Signature**: `ResendBillingPortalInvitation(int customerId, CancellationToken ct = default)`
- **Returns**: `ResentInvitation`
- **Error**: `SdkException<ResendBillingPortalInvitationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RevokeBillingPortalAccess
- **HTTP**: `DELETE /portal/customers/{customer_id}/invitations/revoke.json` (Production)
- **Signature**: `RevokeBillingPortalAccess(int customerId, CancellationToken ct = default)`
- **Returns**: `RevokedInvitation`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none
