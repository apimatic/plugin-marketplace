# BillingPortal — operations

Accessor: `client.BillingPortal` · Source: `Api/BillingPortal.cs` · 4 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### EnableBillingPortalForCustomer
- **HTTP**: `POST /portal/customers/{customer_id}/enable.json` (Production)
- **Notes**: Enables Billing Portal access for a customer, with an option to send an invitation email at the same time. Billing Portal Documentation Full documentation on how the Billing Portal operates within the Advanced Billing UI can be located here . This documentation is focused on how to configure the Billing Portal Settings, as well as Subscriber …
- **Signature**: `EnableBillingPortalForCustomer(int customerId, AutoInvite? autoInvite, CancellationToken ct = default)`
  - `autoInvite` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `auto_invite` ← `autoInvite`
- **Returns**: `CustomerResponse`
- **Error**: `SdkException<EnableBillingPortalForCustomerError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadBillingPortalLink
- **HTTP**: `GET /portal/customers/{customer_id}/management_link.json` (Production)
- **Notes**: Returns the exact URL required for a subscriber to access the Billing Portal. Rules for Management Link API When retrieving a management URL, multiple requests for the same customer in a short period will return the same URL We will not generate a new URL for 15 days You must cache and remember this URL if you are going to need it again within 15 …
- **Signature**: `ReadBillingPortalLink(int customerId, CancellationToken ct = default)`
- **Returns**: `PortalManagementLink`
- **Error**: `SdkException<ReadBillingPortalLinkError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetTooManyManagementLinkRequestsError1(out TooManyManagementLinkRequestsError1)` [429] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ResendBillingPortalInvitation
- **HTTP**: `POST /portal/customers/{customer_id}/invitations/invite.json` (Production)
- **Notes**: Resends a customer's Billing Portal invitation. If you attempt to resend an invitation 5 times within 30 minutes, you will receive a `422` response with an `error` message in the body. If you attempt to resend an invitation when the Billing Portal is already disabled for a Customer, you will receive a `422` error response. If you attempt to resend …
- **Signature**: `ResendBillingPortalInvitation(int customerId, CancellationToken ct = default)`
- **Returns**: `ResentInvitation`
- **Error**: `SdkException<ResendBillingPortalInvitationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RevokeBillingPortalAccess
- **HTTP**: `DELETE /portal/customers/{customer_id}/invitations/revoke.json` (Production)
- **Notes**: Revokes a customer's Billing Portal invitation. If you attempt to revoke an invitation when the Billing Portal is already disabled for a Customer, you will receive a 422 error response. Limitations This endpoint will only return a JSON response.
- **Signature**: `RevokeBillingPortalAccess(int customerId, CancellationToken ct = default)`
- **Returns**: `RevokedInvitation`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none
