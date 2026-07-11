# SubscriptionGroups — operations

Accessor: `client.SubscriptionGroups` · Source: `Api/SubscriptionGroups.cs` · 9 operations

### AddSubscriptionToGroup
- **HTTP**: `POST /subscriptions/{subscription_id}/group.json` (Production)
- **Signature**: `AddSubscriptionToGroup(int subscriptionId, AddSubscriptionToAGroup? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### CreateSubscriptionGroup
- **HTTP**: `POST /subscription_groups.json` (Production)
- **Signature**: `CreateSubscriptionGroup(CreateSubscriptionGroupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupResponse`
- **Error**: `SdkException<CreateSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionGroupCreateErrorResponse1(out SubscriptionGroupCreateErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscriptionGroup
- **HTTP**: `DELETE /subscription_groups/{uid}.json` (Production)
- **Signature**: `DeleteSubscriptionGroup(string uid, CancellationToken ct = default)`
- **Returns**: `DeleteSubscriptionGroupResponse`
- **Error**: `SdkException<DeleteSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FindSubscriptionGroup
- **HTTP**: `GET /subscription_groups/lookup.json` (Production)
- **Signature**: `FindSubscriptionGroup(string subscriptionId, CancellationToken ct = default)`
- **Returns**: `FullSubscriptionGroupResponse`
- **Error**: `SdkException<FindSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListSubscriptionGroups
- **HTTP**: `GET /subscription_groups.json` (Production)
- **Signature**: `ListSubscriptionGroups(IReadOnlyList<SubscriptionGroupsListInclude>? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `include` — nullable, no default → **must pass explicitly**
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `ListSubscriptionGroupsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadSubscriptionGroup
- **HTTP**: `GET /subscription_groups/{uid}.json` (Production)
- **Signature**: `ReadSubscriptionGroup(string uid, IReadOnlyList<SubscriptionGroupInclude>? include, CancellationToken ct = default)`
  - `include` — nullable, no default → **must pass explicitly**
- **Returns**: `FullSubscriptionGroupResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### RemoveSubscriptionFromGroup
- **HTTP**: `DELETE /subscriptions/{subscription_id}/group.json` (Production)
- **Signature**: `RemoveSubscriptionFromGroup(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `void`
- **Error**: `SdkException<RemoveSubscriptionFromGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SignupWithSubscriptionGroup
- **HTTP**: `POST /subscription_groups/signup.json` (Production)
- **Signature**: `SignupWithSubscriptionGroup(SubscriptionGroupSignupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupSignupResponse`
- **Error**: `SdkException<SignupWithSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionGroupSignupErrorResponse1(out SubscriptionGroupSignupErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateSubscriptionGroupMembers
- **HTTP**: `PUT /subscription_groups/{uid}.json` (Production)
- **Signature**: `UpdateSubscriptionGroupMembers(string uid, UpdateSubscriptionGroupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupResponse`
- **Error**: `SdkException<UpdateSubscriptionGroupMembersError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionGroupUpdateErrorResponse1(out SubscriptionGroupUpdateErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
