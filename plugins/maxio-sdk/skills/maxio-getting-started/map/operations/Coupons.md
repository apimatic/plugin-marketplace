# Coupons — operations

Accessor: `client.Coupons` · Source: `Api/Coupons.cs` · 14 operations

### ArchiveCoupon
- **HTTP**: `DELETE /product_families/{product_family_id}/coupons/{coupon_id}.json` (Production)
- **Signature**: `ArchiveCoupon(int productFamilyId, int couponId, CancellationToken ct = default)`
- **Returns**: `CouponResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### CreateCoupon
- **HTTP**: `POST /product_families/{product_family_id}/coupons.json` (Production)
- **Signature**: `CreateCoupon(int productFamilyId, CouponRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponResponse`
- **Error**: `SdkException<CreateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateCouponSubcodes
- **HTTP**: `POST /coupons/{coupon_id}/codes.json` (Production)
- **Signature**: `CreateCouponSubcodes(int couponId, CouponSubcodes? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponSubcodesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### CreateOrUpdateCouponCurrencyPrices
- **HTTP**: `PUT /coupons/{coupon_id}/currency_prices.json` (Production)
- **Signature**: `CreateOrUpdateCouponCurrencyPrices(int couponId, CouponCurrencyRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponCurrencyResponse`
- **Error**: `SdkException<CreateOrUpdateCouponCurrencyPricesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorStringMapResponse1(out ErrorStringMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteCouponSubcode
- **HTTP**: `DELETE /coupons/{coupon_id}/codes/{subcode}.json` (Production)
- **Signature**: `DeleteCouponSubcode(int couponId, string subcode, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteCouponSubcodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FindCoupon
- **HTTP**: `GET /coupons/find.json` (Production)
- **Signature**: `FindCoupon(int? productFamilyId, string? code, bool? currencyPrices, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `productFamilyId`, `code`, `currencyPrices`
- **Returns**: `CouponResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListCouponSubcodes
- **HTTP**: `GET /coupons/{coupon_id}/codes.json` (Production)
- **Signature**: `ListCouponSubcodes(int couponId, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `page` = 1, `perPage` = 20 (optional defaults)
- **Returns**: `CouponSubcodes`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListCoupons
- **HTTP**: `GET /coupons.json` (Production)
- **Signature**: `ListCoupons(ListCouponsFilter? filter, bool? currencyPrices, int? page = 1, int? perPage = 30, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `filter`, `currencyPrices`
  - `page` = 1, `perPage` = 30 (optional defaults)
- **Returns**: `IReadOnlyList<CouponResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListCouponsForProductFamily
- **HTTP**: `GET /product_families/{product_family_id}/coupons.json` (Production)
- **Signature**: `ListCouponsForProductFamily(int productFamilyId, ListCouponsFilter? filter, bool? currencyPrices, int? page = 1, int? perPage = 30, CancellationToken ct = default)`
  - **Must pass explicitly** (nullable, no default): `filter`, `currencyPrices`
  - `page` = 1, `perPage` = 30 (optional defaults)
- **Returns**: `IReadOnlyList<CouponResponse>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadCoupon
- **HTTP**: `GET /product_families/{product_family_id}/coupons/{coupon_id}.json` (Production)
- **Signature**: `ReadCoupon(int productFamilyId, int couponId, bool? currencyPrices, CancellationToken ct = default)`
  - `currencyPrices` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ReadCouponUsage
- **HTTP**: `GET /product_families/{product_family_id}/coupons/{coupon_id}/usage.json` (Production)
- **Signature**: `ReadCouponUsage(int productFamilyId, int couponId, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<CouponUsage>`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCoupon
- **HTTP**: `PUT /product_families/{product_family_id}/coupons/{coupon_id}.json` (Production)
- **Signature**: `UpdateCoupon(int productFamilyId, int couponId, CouponRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponResponse`
- **Error**: `SdkException<UpdateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateCouponSubcodes
- **HTTP**: `PUT /coupons/{coupon_id}/codes.json` (Production)
- **Signature**: `UpdateCouponSubcodes(int couponId, CouponSubcodes? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponSubcodesResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ValidateCoupon
- **HTTP**: `GET /coupons/validate.json` (Production)
- **Signature**: `ValidateCoupon(string code, int? productFamilyId, CancellationToken ct = default)`
  - `productFamilyId` — nullable, no default → **must pass explicitly**
- **Returns**: `CouponResponse`
- **Error**: `SdkException<ValidateCouponError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleStringErrorResponse1(out SingleStringErrorResponse1)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
