# Coupons — operations

Accessor: `client.Coupons` · Source: `Api/Coupons.cs` · 14 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ArchiveCoupon
- **HTTP**: `DELETE /product_families/{product_family_id}/coupons/{coupon_id}.json` (Production)
- **Notes**: Archives a coupon, making it unavailable for future use while remaining active on existing subscriptions. Archiving makes that Coupon unavailable for future use, but allows it to remain attached and functional on existing Subscriptions that are using it. The `archived_at` date and time will be assigned.
- **Signature**: `ArchiveCoupon(int productFamilyId, int couponId, CancellationToken ct = default)`
- **Returns**: `CouponResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### CreateCoupon
- **HTTP**: `POST /product_families/{product_family_id}/coupons.json` (Production)
- **Notes**: Creates a coupon under the specified product family. You can create either a flat amount coupon by specifying amount_in_cents, or a percentage coupon by specifying percentage You can restrict a coupon to only apply to specific products / components by optionally passing in `restricted_products` and/or `restricted_components` objects in the format: …
- **Signature**: `CreateCoupon(int productFamilyId, CouponRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponResponse`
- **Error**: `SdkException<CreateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateCouponSubcodes
- **HTTP**: `POST /coupons/{coupon_id}/codes.json` (Production)
- **Notes**: Creates subcodes for an existing coupon. Coupon Subcodes Intro Coupon Subcodes allow you to create a set of unique codes that allow you to expand the use of one coupon. For example: Master Coupon Code: SPRING2020 Coupon Subcodes: SPRING90210 DP80302 SPRINGBALTIMORE Coupon subcodes can be administered in the Admin Interface or via the API. When …
- **Signature**: `CreateCouponSubcodes(int couponId, CouponSubcodes? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponSubcodesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### CreateOrUpdateCouponCurrencyPrices
- **HTTP**: `PUT /coupons/{coupon_id}/currency_prices.json` (Production)
- **Notes**: Creates and/or updates currency prices for an existing coupon. Multiple prices can be created or updated in a single request but each of the currencies must be defined on the site level already and the coupon must be an amount-based coupon, not percentage. Currency pricing for coupons must mirror the setup of the primary coupon pricing - if the …
- **Signature**: `CreateOrUpdateCouponCurrencyPrices(int couponId, CouponCurrencyRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponCurrencyResponse`
- **Error**: `SdkException<CreateOrUpdateCouponCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorStringMapResponse1(out ErrorStringMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteCouponSubcode
- **HTTP**: `DELETE /coupons/{coupon_id}/codes/{subcode}.json` (Production)
- **Notes**: Deletes a specific subcode from a coupon. Given a coupon with an ID of 567, and a coupon subcode of 20OFF, the URL to `DELETE` this coupon subcode would be: http://subdomain.chargify.com/coupons/567/codes/20OFF.&lt;format&gt; Note: If you are using any of the allowed special characters (“%”, “@”, “+”, “-”, “_”, and “.”), you must encode them for …
- **Signature**: `DeleteCouponSubcode(int couponId, string subcode, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteCouponSubcodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FindCoupon
- **HTTP**: `GET /coupons/find.json` (Production)
- **Notes**: Searches for a coupon by code, returning a 404 if no coupon is found. By passing a code parameter, the find will attempt to locate a coupon that matches that code. If you have more than one product family and if the coupon you are trying to find does not belong to the default product family in your site, then you will need to specify (either in …
- **Signature**: `FindCoupon(int? productFamilyId, string? code, bool? currencyPrices, CancellationToken ct = default)`
  - `productFamilyId` — nullable, no default → **must pass explicitly**
  - `code` — nullable, no default → **must pass explicitly**
  - `currencyPrices` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `product_family_id` ← `productFamilyId`, `code` ← `code`, `currency_prices` ← `currencyPrices`
- **Returns**: `CouponResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListCouponSubcodes
- **HTTP**: `GET /coupons/{coupon_id}/codes.json` (Production)
- **Notes**: Lists the subcodes attached to a coupon.
- **Signature**: `ListCouponSubcodes(int couponId, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - defaults: `page` = 1, `perPage` = 20
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`
- **Returns**: `CouponSubcodes`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListCoupons
- **HTTP**: `GET /coupons.json` (Production)
- **Notes**: Lists coupons for a site.
- **Signature**: `ListCoupons(ListCouponsFilter? filter, bool? currencyPrices, int? page = 1, int? perPage = 30, CancellationToken ct = default)`
  - `filter` — nullable, no default → **must pass explicitly**
  - `currencyPrices` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 30
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `filter` ← `filter`, `currency_prices` ← `currencyPrices`
- **Returns**: `IReadOnlyList<CouponResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListCouponsForProductFamily
- **HTTP**: `GET /product_families/{product_family_id}/coupons.json` (Production)
- **Notes**: Lists coupons for a specific product family in a site.
- **Signature**: `ListCouponsForProductFamily(int productFamilyId, ListCouponsFilter? filter, bool? currencyPrices, int? page = 1, int? perPage = 30, CancellationToken ct = default)`
  - `filter` — nullable, no default → **must pass explicitly**
  - `currencyPrices` — nullable, no default → **must pass explicitly**
  - defaults: `page` = 1, `perPage` = 30
- **Query params (wire ← C#)**: `page` ← `page`, `per_page` ← `perPage`, `filter` ← `filter`, `currency_prices` ← `currencyPrices`
- **Returns**: `IReadOnlyList<CouponResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadCoupon
- **HTTP**: `GET /product_families/{product_family_id}/coupons/{coupon_id}.json` (Production)
- **Notes**: Returns a coupon by its Advanced Billing-assigned ID. You must identify the Coupon in this call by the ID parameter that Advanced Billing assigns. If instead you would like to find a Coupon using a Coupon code, see the Coupon Find method. When fetching a coupon, if you have defined multiple currencies at the site level, you can optionally pass the …
- **Signature**: `ReadCoupon(int productFamilyId, int couponId, bool? currencyPrices, CancellationToken ct = default)`
  - `currencyPrices` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `currency_prices` ← `currencyPrices`
- **Returns**: `CouponResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadCouponUsage
- **HTTP**: `GET /product_families/{product_family_id}/coupons/{coupon_id}/usage.json` (Production)
- **Notes**: Lists coupon usage details, one entry per product.
- **Signature**: `ReadCouponUsage(int productFamilyId, int couponId, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<CouponUsage>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCoupon
- **HTTP**: `PUT /product_families/{product_family_id}/coupons/{coupon_id}.json` (Production)
- **Notes**: Updates a coupon. You can restrict a coupon to only apply to specific products / components by optionally passing in hashes of `restricted_products` and/or `restricted_components` in the format: `{ "&lt;product/component_id&gt;": boolean_value }`
- **Signature**: `UpdateCoupon(int productFamilyId, int couponId, CouponRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponResponse`
- **Error**: `SdkException<UpdateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCouponSubcodes
- **HTTP**: `PUT /coupons/{coupon_id}/codes.json` (Production)
- **Notes**: Updates the subcodes for a coupon, replacing all existing subcodes with the new list. Send an array of new coupon subcodes. Note : All current subcodes for that Coupon will be deleted first, and replaced with the list of subcodes sent to this endpoint. The response will contain: The created subcodes, Subcodes that were not created because they …
- **Signature**: `UpdateCouponSubcodes(int couponId, CouponSubcodes? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponSubcodesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ValidateCoupon
- **HTTP**: `GET /coupons/validate.json` (Production)
- **Notes**: Verifies whether a specific coupon code is valid. This method is useful for validating coupon codes that are entered by a customer. If the coupon is found and is valid, the coupon will be returned with a 200 status code. If the coupon is invalid, the status code will be 404 and the response will say why it is invalid. If the coupon is valid, the …
- **Signature**: `ValidateCoupon(string code, int? productFamilyId, CancellationToken ct = default)`
  - `productFamilyId` — nullable, no default → **must pass explicitly**
- **Query params (wire ← C#)**: `code` ← `code`, `product_family_id` ← `productFamilyId`
- **Returns**: `CouponResponse`
- **Error**: `SdkException<ValidateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleStringErrorResponse1(out SingleStringErrorResponse1)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
