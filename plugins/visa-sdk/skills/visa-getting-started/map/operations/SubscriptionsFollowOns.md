# SubscriptionsFollowOns — operations

Accessor: `client.SubscriptionsFollowOns` · Source: `Api/SubscriptionsFollowOns.cs` · 2 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateFollowOnSubscription
- **HTTP**: `POST /rbs/v1/subscriptions/follow-ons/{requestId}` (Default (apitest))
- **Signature**: `CreateFollowOnSubscription(string requestId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `CreateSubscriptionResponse`
- **Error**: `SdkException<CreateFollowOnSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCreateFollowOnSubscriptionException1(out CreateFollowOnSubscriptionException1)` [400] · `TryGetCreateFollowOnSubscriptionException21(out CreateFollowOnSubscriptionException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetFollowOnSubscription
- **HTTP**: `GET /rbs/v1/subscriptions/follow-ons/{requestId}` (Default (apitest))
- **Signature**: `GetFollowOnSubscription(string requestId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetSubscriptionResponse1`
- **Error**: `SdkException<GetFollowOnSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetFollowOnSubscriptionException1(out GetFollowOnSubscriptionException1)` [400] · `TryGetGetFollowOnSubscriptionException21(out GetFollowOnSubscriptionException21)` [404] · `TryGetGetFollowOnSubscriptionException31(out GetFollowOnSubscriptionException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
