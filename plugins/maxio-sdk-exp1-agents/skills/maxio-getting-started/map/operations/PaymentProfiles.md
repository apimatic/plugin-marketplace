# PaymentProfiles — operations

Accessor: `client.PaymentProfiles` · Source: `Api/PaymentProfiles.cs` · 12 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ChangeSubscriptionDefaultPaymentProfile
- **HTTP**: `POST /subscriptions/{subscription_id}/payment_profiles/{payment_profile_id}/change_payment_profile.json` (Production)
- **Notes**: Changes the default payment profile on the subscription to the existing payment profile with the specified ID. You must elect to change the existing payment profile to a new payment profile ID in order to receive a satisfactory response from this endpoint.
- **Signature**: `ChangeSubscriptionDefaultPaymentProfile(int subscriptionId, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<ChangeSubscriptionDefaultPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ChangeSubscriptionGroupDefaultPaymentProfile
- **HTTP**: `POST /subscription_groups/{uid}/payment_profiles/{payment_profile_id}/change_payment_profile.json` (Production)
- **Notes**: This will change the default payment profile on the subscription group to the existing payment profile with the id specified. You must elect to change the existing payment profile to a new payment profile ID in order to receive a satisfactory response from this endpoint. The new payment profile must belong to the subscription group's customer, …
- **Signature**: `ChangeSubscriptionGroupDefaultPaymentProfile(string uid, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<ChangeSubscriptionGroupDefaultPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreatePaymentProfile
- **HTTP**: `POST /payment_profiles.json` (Production)
- **Notes**: Creates a payment profile for a customer. When you create a new payment profile for a customer via the API, it does not automatically make the profile current for any of the customer’s subscriptions. To use the payment profile as the default, you must set it explicitly for the subscription or subscription group. Select an option from the Request …
- **Signature**: `CreatePaymentProfile(CreatePaymentProfileRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<CreatePaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscriptionGroupPaymentProfile
- **HTTP**: `DELETE /subscription_groups/{uid}/payment_profiles/{payment_profile_id}.json` (Production)
- **Notes**: Deletes a Payment Profile belonging to a Subscription Group. Note : If the Payment Profile belongs to multiple Subscription Groups and/or Subscriptions, it will be removed from all of them.
- **Signature**: `DeleteSubscriptionGroupPaymentProfile(string uid, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscriptionsPaymentProfile
- **HTTP**: `DELETE /subscriptions/{subscription_id}/payment_profiles/{payment_profile_id}.json` (Production)
- **Notes**: Deletes a payment profile belonging to the customer on the subscription. If the customer has multiple subscriptions, the payment profile will be removed from all of them. If you delete the default payment profile for a subscription, you will need to specify another payment profile to be the default through the api, or either prompt the user to …
- **Signature**: `DeleteSubscriptionsPaymentProfile(int subscriptionId, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### DeleteUnusedPaymentProfile
- **HTTP**: `DELETE /payment_profiles/{payment_profile_id}.json` (Production)
- **Notes**: Deletes an unused payment profile. If the payment profile is in use by one or more subscriptions or groups, a 422 and error message will be returned.
- **Signature**: `DeleteUnusedPaymentProfile(int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteUnusedPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListPaymentProfiles
- **HTTP**: `GET /payment_profiles.json` (Production)
- **Notes**: Returns all active payment profiles for a site, or for one customer within a site. If no payment profiles are found, this endpoint will return an empty array, not a 404.
- **Signature**: `ListPaymentProfiles(int? customerId, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `customerId` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `customer_id` ← `customerId`
- **Returns**: `IReadOnlyList<PaymentProfileResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadOneTimeToken
- **HTTP**: `GET /one_time_tokens/{chargify_token}.json` (Production)
- **Notes**: One Time Tokens aka Advanced Billing Tokens house the credit card or ACH (Authorize.Net or Stripe only) data for a customer. You can use One Time Tokens while creating a subscription or payment profile instead of passing all bank account or credit card data directly to a given API endpoint. To obtain a One Time Token you have to use Chargify.js .
- **Signature**: `ReadOneTimeToken(string chargifyToken, CancellationToken ct = default)`
- **Returns**: `GetOneTimeTokenRequest`
- **Error**: `SdkException<ReadOneTimeTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadPaymentProfile
- **HTTP**: `GET /payment_profiles/{payment_profile_id}.json` (Production)
- **Notes**: Returns a payment profile identified by its unique ID. Note that a different JSON object will be returned if the card method on file is a bank account. Response for Bank Account Example response for Bank Account: { "payment_profile": { "id": 10089892, "first_name": "Chester", "last_name": "Tester", "created_at": "2025-01-01T00:00:00-05:00", …
- **Signature**: `ReadPaymentProfile(int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<ReadPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SendRequestUpdatePaymentEmail
- **HTTP**: `POST /subscriptions/{subscription_id}/request_payment_profiles_update.json` (Production)
- **Notes**: You can send a "request payment update" email to the customer associated with the subscription. If you attempt to send a "request payment update" email more than five times within a 30-minute period, you will receive a `422` response with an error message in the body. This error message will indicate that the request has been rejected due to …
- **Signature**: `SendRequestUpdatePaymentEmail(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<SendRequestUpdatePaymentEmailError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdatePaymentProfile
- **HTTP**: `PUT /payment_profiles/{payment_profile_id}.json` (Production)
- **Notes**: Updates a payment profile. Partial Card Updates In the event that you are using the Authorize.net, Stripe, Cybersource, Forte or Braintree Blue payment gateways, you can update just the billing and contact information for a payment method. Note the lack of credit-card related data contained in the JSON payload. In this case, the following JSON is …
- **Signature**: `UpdatePaymentProfile(int paymentProfileId, UpdatePaymentProfileRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<UpdatePaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorStringMapResponse1(out ErrorStringMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VerifyBankAccount
- **HTTP**: `PUT /bank_accounts/{bank_account_id}/verification.json` (Production)
- **Notes**: Verifies a bank account. Submit the two small deposit amounts the customer received in their bank account to verify the bank account. (Stripe only)
- **Signature**: `VerifyBankAccount(int bankAccountId, BankAccountVerificationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `BankAccountResponse`
- **Error**: `SdkException<VerifyBankAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
