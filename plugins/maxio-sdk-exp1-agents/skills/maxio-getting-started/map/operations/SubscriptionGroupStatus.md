# SubscriptionGroupStatus — operations

Accessor: `client.SubscriptionGroupStatus` · Source: `Api/SubscriptionGroupStatus.cs` · 4 operations

### CancelDelayedCancellationForGroup
- **HTTP**: `DELETE /subscription_groups/{uid}/delayed_cancel.json` (Production)
- **Signature**: `CancelDelayedCancellationForGroup(string uid, CancellationToken ct = default)`
- **Returns**: `void`
- **Error**: `SdkException<CancelDelayedCancellationForGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CancelSubscriptionsInGroup
- **HTTP**: `POST /subscription_groups/{uid}/cancel.json` (Production)
- **Signature**: `CancelSubscriptionsInGroup(string uid, CancelGroupedSubscriptionsRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<CancelSubscriptionsInGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### InitiateDelayedCancellationForGroup
- **HTTP**: `POST /subscription_groups/{uid}/delayed_cancel.json` (Production)
- **Signature**: `InitiateDelayedCancellationForGroup(string uid, CancellationToken ct = default)`
- **Returns**: `void`
- **Error**: `SdkException<InitiateDelayedCancellationForGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReactivateSubscriptionGroup
- **HTTP**: `POST /subscription_groups/{uid}/reactivate.json` (Production)
- **Signature**: `ReactivateSubscriptionGroup(string uid, ReactivateSubscriptionGroupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ReactivateSubscriptionGroupResponse`
- **Error**: `SdkException<ReactivateSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
