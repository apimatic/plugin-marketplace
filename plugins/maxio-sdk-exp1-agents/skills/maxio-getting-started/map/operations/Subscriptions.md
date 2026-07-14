# Subscriptions — operations

Accessor: `client.Subscriptions` · Source: `Api/Subscriptions.cs` · 12 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ActivateSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/activate.json` (Production)
- **Notes**: Activates awaiting signup and trialing subscriptions. This feature is only available on the Relationship Invoicing architecture. Subscriptions in a group may not be activated immediately. For details on how the activation works, and how to activate subscriptions through the application, see activation . The `revert_on_failure` parameter controls …
- **Signature**: `ActivateSubscription(int subscriptionId, ActivateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ActivateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ApplyCouponsToSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/add_coupon.json` (Production)
- **Notes**: Applies one or more coupon codes to an existing subscription. An existing subscription can accommodate multiple discounts/coupon codes. This is only applicable if each coupon is stackable. For more information on stackable coupons, we recommend reviewing our coupon documentation. Query Parameters vs Request Body Parameters Passing in a coupon code …
- **Signature**: `ApplyCouponsToSubscription(int subscriptionId, string? code, AddCouponsRequest? body, CancellationToken ct = default)`
  - `code` — nullable, no default → **must pass explicitly**
  - `body` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `code` ← `code`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<ApplyCouponsToSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionAddCouponError1(out SubscriptionAddCouponError1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateSubscription
- **HTTP**: `POST /subscriptions.json` (Production)
- **Notes**: Creates a Subscription for a customer and product. Specify the product with `product_id` or `product_handle`. To set a specific product price point, use `product_price_point_handle` or `product_price_point_id`. Identify an existing customer with `customer_id` or `customer_reference`. Optionally, include an existing payment profile using …
- **Signature**: `CreateSubscription(CreateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<CreateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FindSubscription
- **HTTP**: `GET /subscriptions/lookup.json` (Production)
- **Notes**: Finds a subscription by its reference.
- **Signature**: `FindSubscription(string? reference, CancellationToken ct = default)`
  - `reference` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `reference` ← `reference`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<FindSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListSubscriptions
- **HTTP**: `GET /subscriptions.json` (Production)
- **Notes**: Returns an array of subscriptions from a Site. Pay close attention to query string filters and pagination in order to control responses from the server. Search for a subscription Use the query strings below to search for a subscription using the criteria available. The return value will be an array. Self-Service Page token Self-Service Page token …
- **Signature**: `ListSubscriptions(SubscriptionStateFilter? state, int? product, int? productPricePointId, int? coupon, string? couponCode, SubscriptionDateField? dateField, DateTimeOffset? startDate, DateTimeOffset? endDate, DateTimeOffset? startDatetime, DateTimeOffset? endDatetime, IReadOnlyDictionary<string, string>? metadata, SortingDirection? direction, SubscriptionSort? sort, IReadOnlyList<SubscriptionListInclude>? include, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - 14 params (`state` … `include`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `state` ← `state`, `product` ← `product`, `product_price_point_id` ← `productPricePointId`, `coupon` ← `coupon`, `coupon_code` ← `couponCode`, `date_field` ← `dateField`, `start_date` ← `startDate`, `end_date` ← `endDate`, `start_datetime` ← `startDatetime`, `end_datetime` ← `endDatetime`, `metadata` ← `metadata`, `direction` ← `direction`, `sort` ← `sort`, `include` ← `include`
- **Returns**: `IReadOnlyList<SubscriptionResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### OverrideSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}/override.json` (Production)
- **Notes**: Sets certain subscription fields that are usually managed automatically. Some of the fields can be set via the normal Subscriptions Update API, but others can only be set using this endpoint. This endpoint is provided for cases where you need to “align” Advanced Billing data with data that happened in your system, perhaps before you started using …
- **Signature**: `OverrideSubscription(int subscriptionId, OverrideSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void` (Task)
- **Error**: `SdkException<OverrideSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleErrorResponse1(out SingleErrorResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PreviewSubscription
- **HTTP**: `POST /subscriptions/preview.json` (Production)
- **Notes**: Previews a subscription by POSTing the same JSON or XML as for a subscription creation. The "Next Billing" amount and "Next Billing" date are represented in each Subscriber's Summary. A subscription will not be created by utilizing this endpoint; it is meant to serve as a prediction. For more information, see our documentation here . Taxable …
- **Signature**: `PreviewSubscription(CreateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionPreviewResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### PurgeSubscription
- **HTTP**: `POST /subscriptions/{subscription_id}/purge.json` (Production)
- **Notes**: Purges an individual subscription for sites in test mode. Provide the subscription ID in the url. To confirm, supply the customer ID in the query string `ack` parameter. You may also delete the customer record and/or payment profiles by passing `cascade` parameters. For example, to delete just the customer record, the query params would be: …
- **Signature**: `PurgeSubscription(int subscriptionId, int ack, IReadOnlyList<SubscriptionPurgeType>? cascade, CancellationToken ct = default)`
  - `cascade` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `ack` ← `ack`, `cascade` ← `cascade`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<PurgeSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionResponse(out SubscriptionResponse)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadSubscription
- **HTTP**: `GET /subscriptions/{subscription_id}.json` (Production)
- **Notes**: Retrieves subscription details. Self-Service Page token Self-Service Page token for the subscription is not returned by default. If this information is desired, the include[]=self_service_page_token parameter must be provided with the request.
- **Signature**: `ReadSubscription(int subscriptionId, IReadOnlyList<SubscriptionInclude>? include, CancellationToken ct = default)`
  - `include` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `include` ← `include`
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### RemoveCouponFromSubscription
- **HTTP**: `DELETE /subscriptions/{subscription_id}/remove_coupon.json` (Production)
- **Notes**: Removes a coupon from an existing subscription. For more information on the expected behavior of removing a coupon from a subscription, see our documentation here.
- **Signature**: `RemoveCouponFromSubscription(int subscriptionId, string? couponCode, CancellationToken ct = default)`
  - `couponCode` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `coupon_code` ← `couponCode`
- **Returns**: `string`
- **Error**: `SdkException<RemoveCouponFromSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetSubscriptionRemoveCouponErrors1(out SubscriptionRemoveCouponErrors1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdatePrepaidSubscriptionConfiguration
- **HTTP**: `POST /subscriptions/{subscription_id}/prepaid_configurations.json` (Production)
- **Notes**: Updates a subscription's prepaid configuration.
- **Signature**: `UpdatePrepaidSubscriptionConfiguration(int subscriptionId, UpsertPrepaidConfigurationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `PrepaidConfigurationResponse`
- **Error**: `SdkException<UpdatePrepaidSubscriptionConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetPrepaidConfigurationErrorResponse(out PrepaidConfigurationErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateSubscription
- **HTTP**: `PUT /subscriptions/{subscription_id}.json` (Production)
- **Notes**: Updates one or more attributes of a subscription. Update Subscription Payment Method Change the card that your subscriber uses for their subscription. You can also use this method to change the expiration date of the card if your gateway allows . Do not use real card information for testing. See the Sites articles that cover testing your site …
- **Signature**: `UpdateSubscription(int subscriptionId, UpdateSubscriptionRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<UpdateSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
