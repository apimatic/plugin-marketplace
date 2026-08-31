# Subscriptions — operations

Accessor: `client.Subscriptions` · Source: `Api/Subscriptions.cs` · 10 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ActivateSubscription
- **HTTP**: `POST /rbs/v1/subscriptions/{id}/activate` (Default (apitest))
- **Signature**: `ActivateSubscription(string id, bool? processMissedPayments = true, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `processMissedPayments` = true, `requestOptions` = null
- **Query params (wire ← C#)**: `processMissedPayments` ← `processMissedPayments`
- **Returns**: `ActivateSubscriptionResponse`
- **Error**: `SdkException<ActivateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetActivateSubscriptionException1(out ActivateSubscriptionException1)` [400] · `TryGetActivateSubscriptionException21(out ActivateSubscriptionException21)` [404] · `TryGetActivateSubscriptionException31(out ActivateSubscriptionException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CancelSubscription
- **HTTP**: `POST /rbs/v1/subscriptions/{id}/cancel` (Default (apitest))
- **Signature**: `CancelSubscription(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `CancelSubscriptionResponse`
- **Error**: `SdkException<CancelSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCancelSubscriptionException1(out CancelSubscriptionException1)` [400] · `TryGetCancelSubscriptionException21(out CancelSubscriptionException21)` [404] · `TryGetCancelSubscriptionException31(out CancelSubscriptionException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateSubscription
- **HTTP**: `POST /rbs/v1/subscriptions` (Default (apitest))
- **Signature**: `CreateSubscription(RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `CreateSubscriptionResponse`
- **Error**: `SdkException<CreateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCreateSubscriptionException1(out CreateSubscriptionException1)` [400] · `TryGetCreateSubscriptionException21(out CreateSubscriptionException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetAllSubscriptions
- **HTTP**: `GET /rbs/v1/subscriptions` (Default (apitest))
- **Signature**: `GetAllSubscriptions(int? offset, int? limit, string? code, string? status, string? customerId, string? clientReferenceInformationCode, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 6 params (`offset` … `clientReferenceInformationCode`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `offset` ← `offset`, `limit` ← `limit`, `code` ← `code`, `status` ← `status`, `customerId` ← `customerId`, `clientReferenceInformationCode` ← `clientReferenceInformationCode`
- **Returns**: `GetAllSubscriptionsResponse`
- **Error**: `SdkException<GetAllSubscriptionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetAllSubscriptionsException1(out GetAllSubscriptionsException1)` [400] · `TryGetGetAllSubscriptionsException21(out GetAllSubscriptionsException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetSubscription
- **HTTP**: `GET /rbs/v1/subscriptions/{id}` (Default (apitest))
- **Signature**: `GetSubscription(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetSubscriptionResponse`
- **Error**: `SdkException<GetSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetSubscriptionException1(out GetSubscriptionException1)` [400] · `TryGetGetSubscriptionException21(out GetSubscriptionException21)` [404] · `TryGetGetSubscriptionException31(out GetSubscriptionException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetSubscriptionCode
- **HTTP**: `GET /rbs/v1/subscriptions/code` (Default (apitest))
- **Signature**: `GetSubscriptionCode(RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetSubscriptionCodeResponse`
- **Error**: `SdkException<GetSubscriptionCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetSubscriptionCodeException1(out GetSubscriptionCodeException1)` [400] · `TryGetGetSubscriptionCodeException21(out GetSubscriptionCodeException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SubscriptionsIdPaymentsGet
- **HTTP**: `GET /rbs/v1/subscriptions/{id}/payments` (Default (apitest))
- **Signature**: `SubscriptionsIdPaymentsGet(string id, int? offset, int? limit, int? scheduledPaymentsCount, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `offset` — nullable, no default → **must pass explicitly**
  - `limit` — nullable, no default → **must pass explicitly**
  - `scheduledPaymentsCount` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `offset` ← `offset`, `limit` ← `limit`, `scheduledPaymentsCount` ← `scheduledPaymentsCount`
- **Returns**: `GetSubscriptionsPaymentsResponse`
- **Error**: `SdkException<SubscriptionsIdPaymentsGetError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionsIdPaymentsGetException1(out SubscriptionsIdPaymentsGetException1)` [400] · `TryGetSubscriptionsIdPaymentsGetException21(out SubscriptionsIdPaymentsGetException21)` [404] · `TryGetSubscriptionsIdPaymentsGetException31(out SubscriptionsIdPaymentsGetException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SubscriptionsIdPaymentsPut
- **HTTP**: `PUT /rbs/v1/subscriptions/{id}/payments` (Default (apitest))
- **Signature**: `SubscriptionsIdPaymentsPut(string id, UpdatePayments updatePayments, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetSubscriptionsPaymentsResponse1`
- **Error**: `SdkException<SubscriptionsIdPaymentsPutError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionsIdPaymentsPutException1(out SubscriptionsIdPaymentsPutException1)` [400] · `TryGetSubscriptionsIdPaymentsPutException21(out SubscriptionsIdPaymentsPutException21)` [404] · `TryGetSubscriptionsIdPaymentsPutException31(out SubscriptionsIdPaymentsPutException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SuspendSubscription
- **HTTP**: `POST /rbs/v1/subscriptions/{id}/suspend` (Default (apitest))
- **Signature**: `SuspendSubscription(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `SuspendSubscriptionResponse`
- **Error**: `SdkException<SuspendSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSuspendSubscriptionException1(out SuspendSubscriptionException1)` [400] · `TryGetSuspendSubscriptionException21(out SuspendSubscriptionException21)` [404] · `TryGetSuspendSubscriptionException31(out SuspendSubscriptionException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateSubscription
- **HTTP**: `PATCH /rbs/v1/subscriptions/{id}` (Default (apitest))
- **Signature**: `UpdateSubscription(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `UpdateSubscriptionResponse`
- **Error**: `SdkException<UpdateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetUpdateSubscriptionException1(out UpdateSubscriptionException1)` [400] · `TryGetUpdateSubscriptionException21(out UpdateSubscriptionException21)` [404] · `TryGetUpdateSubscriptionException31(out UpdateSubscriptionException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
