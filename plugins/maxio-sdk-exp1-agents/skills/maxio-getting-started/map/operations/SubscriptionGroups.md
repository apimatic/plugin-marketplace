# SubscriptionGroups — operations

Accessor: `client.SubscriptionGroups` · Source: `Api/SubscriptionGroups.cs` · 9 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### AddSubscriptionToGroup
- **HTTP**: `POST /subscriptions/{subscription_id}/group.json` (Production)
- **Notes**: For sites making use of the Relationship Billing and Customer Hierarchy features, it is possible to add existing subscriptions to subscription groups. Passing `group` parameters with a `target` containing a `type` and optional `id` is all that's needed. When the `target` parameter specifies a `"customer"` or `"subscription"` that is already part …
- **Signature**: `AddSubscriptionToGroup(int subscriptionId, AddSubscriptionToAGroup? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### CreateSubscriptionGroup
- **HTTP**: `POST /subscription_groups.json` (Production)
- **Notes**: Creates a subscription group with given members.
- **Signature**: `CreateSubscriptionGroup(CreateSubscriptionGroupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupResponse`
- **Error**: `SdkException<CreateSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionGroupCreateErrorResponse1(out SubscriptionGroupCreateErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscriptionGroup
- **HTTP**: `DELETE /subscription_groups/{uid}.json` (Production)
- **Notes**: Deletes a subscription group. Only groups without members can be deleted.
- **Signature**: `DeleteSubscriptionGroup(string uid, CancellationToken ct = default)`
- **Returns**: `DeleteSubscriptionGroupResponse`
- **Error**: `SdkException<DeleteSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FindSubscriptionGroup
- **HTTP**: `GET /subscription_groups/lookup.json` (Production)
- **Notes**: Finds the subscription group associated with a subscription. If the subscription is not in a group, the endpoint will return a 404 code.
- **Signature**: `FindSubscriptionGroup(string subscriptionId, CancellationToken ct = default)`
- **Query params (wire ← C#)**: `subscription_id` ← `subscriptionId`
- **Returns**: `FullSubscriptionGroupResponse`
- **Error**: `SdkException<FindSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListSubscriptionGroups
- **HTTP**: `GET /subscription_groups.json` (Production)
- **Notes**: Returns an array of subscription groups for the site. The response is paginated and will return a `meta` key with pagination information. Account Balance Information Account balance information for the subscription groups is not returned by default. If this information is desired, the `include[]=account_balances` parameter must be provided with …
- **Signature**: `ListSubscriptionGroups(IReadOnlyList<SubscriptionGroupsListInclude>? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `include` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `include` ← `include`
- **Returns**: `ListSubscriptionGroupsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadSubscriptionGroup
- **HTTP**: `GET /subscription_groups/{uid}.json` (Production)
- **Notes**: Returns subscription group details. Current Billing Amount in Cents Current billing amount for the subscription group is not returned by default. If this information is desired, the `include[]=current_billing_amount_in_cents` parameter must be provided with the request.
- **Signature**: `ReadSubscriptionGroup(string uid, IReadOnlyList<SubscriptionGroupInclude>? include, CancellationToken ct = default)`
  - `include` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `include` ← `include`
- **Returns**: `FullSubscriptionGroupResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### RemoveSubscriptionFromGroup
- **HTTP**: `DELETE /subscriptions/{subscription_id}/group.json` (Production)
- **Notes**: For sites making use of the Relationship Billing and Customer Hierarchy features, it is possible to remove an existing subscription from a subscription group.
- **Signature**: `RemoveSubscriptionFromGroup(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RemoveSubscriptionFromGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### SignupWithSubscriptionGroup
- **HTTP**: `POST /subscription_groups/signup.json` (Production)
- **Notes**: Creates multiple subscriptions at once under the same customer and consolidates them into a subscription group. You must provide one and only one of the `payer_id`/`payer_reference`/`payer_attributes` for the customer attached to the group. You must provide one and only one of the …
- **Signature**: `SignupWithSubscriptionGroup(SubscriptionGroupSignupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupSignupResponse`
- **Error**: `SdkException<SignupWithSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionGroupSignupErrorResponse1(out SubscriptionGroupSignupErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateSubscriptionGroupMembers
- **HTTP**: `PUT /subscription_groups/{uid}.json` (Production)
- **Notes**: Updates subscription group members. `"member_ids"` should contain an array of both subscription IDs to set as group members and subscription IDs already present in the groups. Not including them will result in removing them from the subscription group. To clean up members, just leave the array empty.
- **Signature**: `UpdateSubscriptionGroupMembers(string uid, UpdateSubscriptionGroupRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupResponse`
- **Error**: `SdkException<UpdateSubscriptionGroupMembersError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionGroupUpdateErrorResponse1(out SubscriptionGroupUpdateErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
