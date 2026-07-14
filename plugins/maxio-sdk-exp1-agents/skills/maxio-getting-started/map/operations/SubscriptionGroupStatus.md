# SubscriptionGroupStatus — operations

Accessor: `client.SubscriptionGroupStatus` · Source: `Api/SubscriptionGroupStatus.cs` · 4 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CancelDelayedCancellationForGroup
- **HTTP**: `DELETE /subscription_groups/{uid}/delayed_cancel.json` (Production)
- **Notes**: Removes the delayed cancellation on a subscription group. Removing the delayed cancellation on a subscription group will ensure that the subscriptions do not get canceled at the end of the period. The request will reset the `cancel_at_end_of_period` flag to false on each member in the group.
- **Signature**: `CancelDelayedCancellationForGroup(string uid, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<CancelDelayedCancellationForGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CancelSubscriptionsInGroup
- **HTTP**: `POST /subscription_groups/{uid}/cancel.json` (Production)
- **Notes**: Cancels all subscriptions within the specified group immediately. The group is identified by the `uid` that is passed in the URL. To successfully cancel the group, the primary subscription must be on automatic billing. The group members must be on automatic billing or prepaid. To cancel a subscription group while also charging for any unbilled …
- **Signature**: `CancelSubscriptionsInGroup(string uid, CancelGroupedSubscriptionsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<CancelSubscriptionsInGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### InitiateDelayedCancellationForGroup
- **HTTP**: `POST /subscription_groups/{uid}/delayed_cancel.json` (Production)
- **Notes**: Schedules all subscriptions within the specified group to be canceled at the end of their billing period. The group is identified by its uid passed in the URL. All subscriptions in the group must be on automatic billing in order to successfully cancel them, and the group must not be in a "past_due" state.
- **Signature**: `InitiateDelayedCancellationForGroup(string uid, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<InitiateDelayedCancellationForGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReactivateSubscriptionGroup
- **HTTP**: `POST /subscription_groups/{uid}/reactivate.json` (Production)
- **Notes**: Reactivates or resumes a cancelled subscription group. Upon reactivation, any canceled invoices created after the beginning of the primary subscription's billing period will be reopened and payment will be attempted on them. If the subscription group is being reactivated (as opposed to resumed), new charges will also be assessed for the new …
- **Signature**: `ReactivateSubscriptionGroup(string uid, ReactivateSubscriptionGroupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ReactivateSubscriptionGroupResponse`
- **Error**: `SdkException<ReactivateSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
