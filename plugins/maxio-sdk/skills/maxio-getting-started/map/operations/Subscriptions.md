# Subscriptions — operations

Accessor: `client.Subscriptions` · Source: `Api/Subscriptions.cs` · 12 operations

### ActivateSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/activate.json` (Production)
- **Signature**: `ActivateSubscription(int subscriptionId, ActivateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly** (pass `null` if unused)
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ActivateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ApplyCouponsToSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/add_coupon.json` (Production)
- **Signature**: `ApplyCouponsToSubscription(int subscriptionId, string? code, AddCouponsRequest? body, CancellationToken ct = default)`
  - `code` — nullable, no default → **must pass explicitly**
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ApplyCouponsToSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionAddCouponError1(out SubscriptionAddCouponError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateSubscription
- **HTTP**: `POST /subscriptions.json` (Production)
- **Signature**: `CreateSubscription(CreateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<CreateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FindSubscription
- **HTTP**: `GET /subscriptions/lookup.json` (Production)
- **Signature**: `FindSubscription(string? reference, CancellationToken ct = default)`
  - `reference` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<FindSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListSubscriptions
- **HTTP**: `GET /subscriptions.json` (Production)
- **Signature**: `ListSubscriptions(SubscriptionStateFilter? state, int? product, int? productPricePointId, int? coupon, string? couponCode, SubscriptionDateField? dateField, DateTimeOffset? startDate, DateTimeOffset? endDate, DateTimeOffset? startDatetime, DateTimeOffset? endDatetime, IReadOnlyDictionary<string, string>? metadata, SortingDirection? direction, SubscriptionSort? sort, IReadOnlyList<SubscriptionListInclude>? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - All 14 filter params (`state` … `include`) are nullable with no default → **must pass explicitly** (pass `null` to skip)
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `IReadOnlyList<SubscriptionResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### OverrideSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/override.json` (Production)
- **Signature**: `OverrideSubscription(int subscriptionId, OverrideSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<OverrideSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PreviewSubscription
- **HTTP**: `POST /subscriptions/preview.json` (Production)
- **Signature**: `PreviewSubscription(CreateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionPreviewResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### PurgeSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/purge.json` (Production)
- **Signature**: `PurgeSubscription(int subscriptionId, int ack, IReadOnlyList<SubscriptionPurgeType>? cascade, CancellationToken ct = default)`
  - `cascade` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<PurgeSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionResponse(out SubscriptionResponse)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadSubscription
- **HTTP**: `GET /subscriptions/{subscription_id}.json` (Production)
- **Signature**: `ReadSubscription(int subscriptionId, IReadOnlyList<SubscriptionInclude>? include, CancellationToken ct = default)`
  - `include` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### RemoveCouponFromSubscription
- **HTTP**: `DELETE /subscriptions/{subscription_id}/remove_coupon.json` (Production)
- **Signature**: `RemoveCouponFromSubscription(int subscriptionId, string? couponCode, CancellationToken ct = default)`
  - `couponCode` — nullable, no default → **must pass explicitly**
- **Returns**: `string`
- **Error**: `SdkException<RemoveCouponFromSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionRemoveCouponErrors1(out SubscriptionRemoveCouponErrors1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdatePrepaidSubscriptionConfiguration
- **HTTP**: `POST /subscriptions/{subscription_id}/prepaid_configurations.json` (Production)
- **Signature**: `UpdatePrepaidSubscriptionConfiguration(int subscriptionId, UpsertPrepaidConfigurationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `PrepaidConfigurationResponse`
- **Error**: `SdkException<UpdatePrepaidSubscriptionConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetPrepaidConfigurationErrorResponse(out PrepaidConfigurationErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}.json` (Production)
- **Signature**: `UpdateSubscription(int subscriptionId, UpdateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<UpdateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
