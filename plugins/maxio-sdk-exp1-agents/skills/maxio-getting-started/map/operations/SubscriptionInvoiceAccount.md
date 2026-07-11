# SubscriptionInvoiceAccount — operations

Accessor: `client.SubscriptionInvoiceAccount` · Source: `Api/SubscriptionInvoiceAccount.cs` · 7 operations

### CreatePrepayment
- **HTTP**: `POST /subscriptions/{subscription_id}/prepayments.json` (Production)
- **Signature**: `CreatePrepayment(int subscriptionId, CreatePrepaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `CreatePrepaymentResponse`
- **Error**: `SdkException<CreatePrepaymentApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetCreatePrepaymentErrorResponse(out CreatePrepaymentErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeductServiceCredit
- **HTTP**: `POST /subscriptions/{subscription_id}/service_credit_deductions.json` (Production)
- **Signature**: `DeductServiceCredit(int subscriptionId, DeductServiceCreditRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `void`
- **Error**: `SdkException<DeductServiceCreditApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeductServiceCreditErrorResponse(out DeductServiceCreditErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### IssueServiceCredit
- **HTTP**: `POST /subscriptions/{subscription_id}/service_credits.json` (Production)
- **Signature**: `IssueServiceCredit(int subscriptionId, IssueServiceCreditRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ServiceCredit`
- **Error**: `SdkException<IssueServiceCreditApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetIssueServiceCreditErrorResponse(out IssueServiceCreditErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListPrepayments
- **HTTP**: `GET /subscriptions/{subscription_id}/prepayments.json` (Production)
- **Signature**: `ListPrepayments(int subscriptionId, ListPrepaymentsFilter? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `filter` — nullable, no default → **must pass explicitly**
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `PrepaymentsResponse`
- **Error**: `SdkException<ListPrepaymentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ListServiceCredits
- **HTTP**: `GET /subscriptions/{subscription_id}/service_credits/list.json` (Production)
- **Signature**: `ListServiceCredits(int subscriptionId, SortingDirection? direction, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `direction` — nullable, no default → **must pass explicitly**
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `ListServiceCreditsResponse`
- **Error**: `SdkException<ListServiceCreditsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadAccountBalances
- **HTTP**: `GET /subscriptions/{subscription_id}/account_balances.json` (Production)
- **Signature**: `ReadAccountBalances(int subscriptionId, CancellationToken ct = default)`
- **Returns**: `AccountBalances`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### RefundPrepayment
- **HTTP**: `POST /subscriptions/{subscription_id}/prepayments/{prepayment_id}/refunds.json` (Production)
- **Signature**: `RefundPrepayment(int subscriptionId, long prepaymentId, RefundPrepaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `PrepaymentResponse`
- **Error**: `SdkException<RefundPrepaymentApiError>` — **Case A (typed)**
- **Error accessors**: `TryGetRefundPrepaymentBaseErrorsResponse1(out RefundPrepaymentBaseErrorsResponse1)` [400] · `TryGetString(out string)` [404] · `TryGetRefundPrepaymentErrorResponse(out RefundPrepaymentErrorResponse)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
