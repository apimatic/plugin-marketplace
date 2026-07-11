# SubscriptionStatus — operations

Accessor: `client.SubscriptionStatus` · Source: `Api/SubscriptionStatus.cs` · 10 operations

### CancelDelayedCancellation
- **HTTP**: `DELETE /subscriptions/{subscription_id}/delayed_cancel.json` (Production)
- **Signature**: `CancelDelayedCancellation(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `DelayedCancellationResponse`
- **Error**: `SdkException<CancelDelayedCancellationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CancelDunning
- **HTTP**: `POST /subscriptions/{subscription_id}/cancel_dunning.json` (Production)
- **Signature**: `CancelDunning(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<CancelDunningError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CancelSubscription
- **HTTP**: `DELETE /subscriptions/{subscription_id}.json` (Production)
- **Signature**: `CancelSubscription(int subscriptionId, CancellationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<CancelSubscriptionApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetCancelSubscriptionErrorResponse(out CancelSubscriptionErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### InitiateDelayedCancellation
- **HTTP**: `POST /subscriptions/{subscription_id}/delayed_cancel.json` (Production)
- **Signature**: `InitiateDelayedCancellation(int subscriptionId, CancellationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `DelayedCancellationResponse`
- **Error**: `SdkException<InitiateDelayedCancellationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PauseSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/hold.json` (Production)
- **Signature**: `PauseSubscription(int subscriptionId, PauseRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<PauseSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PreviewRenewal
- **HTTP**: `POST /subscriptions/{subscription_id}/renewals/preview.json` (Production)
- **Signature**: `PreviewRenewal(int subscriptionId, RenewalPreviewRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `RenewalPreviewResponse`
- **Error**: `SdkException<PreviewRenewalError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReactivateSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/reactivate.json` (Production)
- **Signature**: `ReactivateSubscription(int subscriptionId, ReactivateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ReactivateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ResumeSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/resume.json` (Production)
- **Signature**: `ResumeSubscription(int subscriptionId, ResumptionCharge? calendarBillingResumptionCharge, CancellationToken ct = default)`
  - `calendarBillingResumptionCharge` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ResumeSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RetrySubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/retry.json` (Production)
- **Signature**: `RetrySubscription(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<RetrySubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateAutomaticSubscriptionResumption
- **HTTP**: `PUT /subscriptions/{subscription_id}/hold.json` (Production)
- **Signature**: `UpdateAutomaticSubscriptionResumption(int subscriptionId, PauseRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<UpdateAutomaticSubscriptionResumptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
