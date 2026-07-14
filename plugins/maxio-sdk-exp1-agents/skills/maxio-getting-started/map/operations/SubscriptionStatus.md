# SubscriptionStatus — operations

Accessor: `client.SubscriptionStatus` · Source: `Api/SubscriptionStatus.cs` · 10 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CancelDelayedCancellation
- **HTTP**: `DELETE /subscriptions/{subscription_id}/delayed_cancel.json` (Production)
- **Notes**: Removes the delayed cancellation from a subscription, ensuring it is not canceled at the end of the current period. The request will reset the `cancel_at_end_of_period` flag to `false`. This endpoint is idempotent. If the subscription was not set to cancel in the future, removing the delayed cancellation has no effect and the call will be …
- **Signature**: `CancelDelayedCancellation(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `DelayedCancellationResponse`
- **Error**: `SdkException<CancelDelayedCancellationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CancelDunning
- **HTTP**: `POST /subscriptions/{subscription_id}/cancel_dunning.json` (Production)
- **Notes**: Cancels the active dunning process for a subscription and sets it to active.
- **Signature**: `CancelDunning(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<CancelDunningError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CancelSubscription
- **HTTP**: `DELETE /subscriptions/{subscription_id}.json` (Production)
- **Notes**: Cancels the Subscription. The Delete method sets the Subscription state to `canceled`. To cancel the subscription immediately, omit any schedule parameters from the request. To use the schedule options, the Schedule Subscription Cancellation feature must be enabled on your site.
- **Signature**: `CancelSubscription(int subscriptionId, CancellationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<CancelSubscriptionApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetCancelSubscriptionErrorResponse(out CancelSubscriptionErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### InitiateDelayedCancellation
- **HTTP**: `POST /subscriptions/{subscription_id}/delayed_cancel.json` (Production)
- **Notes**: Cancels a subscription at the end of the current billing period based on the subscription's current product. You cannot set `cancel_at_end_of_period` at subscription creation, or if the subscription is past due.
- **Signature**: `InitiateDelayedCancellation(int subscriptionId, CancellationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `DelayedCancellationResponse`
- **Error**: `SdkException<InitiateDelayedCancellationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PauseSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/hold.json` (Production)
- **Notes**: Places the subscription on hold, preventing it from renewing. Limitations You may not place a subscription on hold if the `next_billing_at` date is within 24 hours.
- **Signature**: `PauseSubscription(int subscriptionId, PauseRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<PauseSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PreviewRenewal
- **HTTP**: `POST /subscriptions/{subscription_id}/renewals/preview.json` (Production)
- **Notes**: Previews a subscription’s next renewal assessment. Renewal Preview is an object representing a subscription’s next assessment. You can retrieve it to see a snapshot of how much your customer will be charged on their next renewal. The "Next Billing" amount and "Next Billing" date are already represented in the UI on each Subscriber's Summary. For …
- **Signature**: `PreviewRenewal(int subscriptionId, RenewalPreviewRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `RenewalPreviewResponse`
- **Error**: `SdkException<PreviewRenewalError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReactivateSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/reactivate.json` (Production)
- **Notes**: Reactivates a previously canceled subscription. For details on how the reactivation works, and how to reactivate subscriptions through the application, see reactivation . Note: The term "resume" is used also during another process in Advanced Billing. This occurs when an on-hold subscription is "resumed". This returns the subscription to an active …
- **Signature**: `ReactivateSubscription(int subscriptionId, ReactivateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ReactivateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ResumeSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/resume.json` (Production)
- **Notes**: Resumes a paused (on-hold) subscription. If the normal next renewal date has not passed, the subscription will return to active and will renew on that date. Otherwise, it will behave like a reactivation, setting the billing date to 'now' and charging the subscriber.
- **Signature**: `ResumeSubscription(int subscriptionId, ResumptionCharge? calendarBillingResumptionCharge, CancellationToken ct = default)`
  - `calendarBillingResumptionCharge` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `calendar_billing['resumption_charge']` ← `calendarBillingResumptionCharge`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ResumeSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### RetrySubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/retry.json` (Production)
- **Notes**: Retries collecting the balance due on a past-due subscription without waiting for the next scheduled attempt. 3D Secure (3DS) Authentication post-authentication flow When a payment requires 3DS Authentication to adhere to Strong Customer Authentication (SCA), the request enters a post-authentication flow where a 422 Unprocessable Entity status is …
- **Signature**: `RetrySubscription(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<RetrySubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateAutomaticSubscriptionResumption
- **HTTP**: `PUT /subscriptions/{subscription_id}/hold.json` (Production)
- **Notes**: Updates the date on which a paused subscription will automatically resume. To update a subscription's resume date, use this method to change or update the `automatically_resume_at` date. Remove the resume date Alternatively, you can change the `automatically_resume_at` to `null` if you would like the subscription to not have a resume date.
- **Signature**: `UpdateAutomaticSubscriptionResumption(int subscriptionId, PauseRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<UpdateAutomaticSubscriptionResumptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
