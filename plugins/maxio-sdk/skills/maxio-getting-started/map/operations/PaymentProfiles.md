# PaymentProfiles — operations

Accessor: `client.PaymentProfiles` · Source: `Api/PaymentProfiles.cs` · 12 operations

### ChangeSubscriptionDefaultPaymentProfile
- **HTTP**: `POST /subscriptions/{subscription_id}/payment_profiles/{payment_profile_id}/change_payment_profile.json` (Production)
- **Signature**: `ChangeSubscriptionDefaultPaymentProfile(int subscriptionId, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<ChangeSubscriptionDefaultPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ChangeSubscriptionGroupDefaultPaymentProfile
- **HTTP**: `POST /subscription_groups/{uid}/payment_profiles/{payment_profile_id}/change_payment_profile.json` (Production)
- **Signature**: `ChangeSubscriptionGroupDefaultPaymentProfile(string uid, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<ChangeSubscriptionGroupDefaultPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreatePaymentProfile
- **HTTP**: `POST /payment_profiles.json` (Production)
- **Signature**: `CreatePaymentProfile(CreatePaymentProfileRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<CreatePaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscriptionGroupPaymentProfile
- **HTTP**: `DELETE /subscription_groups/{uid}/payment_profiles/{payment_profile_id}.json` (Production)
- **Signature**: `DeleteSubscriptionGroupPaymentProfile(string uid, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscriptionsPaymentProfile
- **HTTP**: `DELETE /subscriptions/{subscription_id}/payment_profiles/{payment_profile_id}.json` (Production)
- **Signature**: `DeleteSubscriptionsPaymentProfile(int subscriptionId, int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### DeleteUnusedPaymentProfile
- **HTTP**: `DELETE /payment_profiles/{payment_profile_id}.json` (Production)
- **Signature**: `DeleteUnusedPaymentProfile(int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteUnusedPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListPaymentProfiles
- **HTTP**: `GET /payment_profiles.json` (Production)
- **Signature**: `ListPaymentProfiles(int? customerId, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `customerId` — nullable, no default → **must pass explicitly**
- **Returns**: `IReadOnlyList<PaymentProfileResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadOneTimeToken
- **HTTP**: `GET /one_time_tokens/{chargify_token}.json` (Production)
- **Signature**: `ReadOneTimeToken(string chargifyToken, CancellationToken ct = default)`
- **Returns**: `GetOneTimeTokenRequest`
- **Error**: `SdkException<ReadOneTimeTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadPaymentProfile
- **HTTP**: `GET /payment_profiles/{payment_profile_id}.json` (Production)
- **Signature**: `ReadPaymentProfile(int paymentProfileId, CancellationToken ct = default)`
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<ReadPaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SendRequestUpdatePaymentEmail
- **HTTP**: `POST /subscriptions/{subscription_id}/request_payment_profiles_update.json` (Production)
- **Signature**: `SendRequestUpdatePaymentEmail(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<SendRequestUpdatePaymentEmailError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdatePaymentProfile
- **HTTP**: `PUT /payment_profiles/{payment_profile_id}.json` (Production)
- **Signature**: `UpdatePaymentProfile(int paymentProfileId, UpdatePaymentProfileRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `PaymentProfileResponse`
- **Error**: `SdkException<UpdatePaymentProfileError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorStringMapResponse1(out ErrorStringMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### VerifyBankAccount
- **HTTP**: `PUT /bank_accounts/{bank_account_id}/verification.json` (Production)
- **Signature**: `VerifyBankAccount(int bankAccountId, BankAccountVerificationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `BankAccountResponse`
- **Error**: `SdkException<VerifyBankAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
