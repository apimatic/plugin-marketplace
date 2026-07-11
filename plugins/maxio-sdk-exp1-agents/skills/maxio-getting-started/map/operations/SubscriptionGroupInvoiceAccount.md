# SubscriptionGroupInvoiceAccount — operations

Accessor: `client.SubscriptionGroupInvoiceAccount` · Source: `Api/SubscriptionGroupInvoiceAccount.cs` · 4 operations

### CreateSubscriptionGroupPrepayment
- **HTTP**: `POST /subscription_groups/{uid}/prepayments.json` (Production)
- **Signature**: `CreateSubscriptionGroupPrepayment(string uid, SubscriptionGroupPrepaymentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionGroupPrepaymentResponse`
- **Error**: `SdkException<CreateSubscriptionGroupPrepaymentError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeductSubscriptionGroupServiceCredit
- **HTTP**: `POST /subscription_groups/{uid}/service_credit_deductions.json` (Production)
- **Signature**: `DeductSubscriptionGroupServiceCredit(string uid, DeductServiceCreditRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ServiceCredit`
- **Error**: `SdkException<DeductSubscriptionGroupServiceCreditError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### IssueSubscriptionGroupServiceCredit
- **HTTP**: `POST /subscription_groups/{uid}/service_credits.json` (Production)
- **Signature**: `IssueSubscriptionGroupServiceCredit(string uid, IssueServiceCreditRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ServiceCreditResponse`
- **Error**: `SdkException<IssueSubscriptionGroupServiceCreditError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListPrepaymentsForSubscriptionGroup
- **HTTP**: `GET /subscription_groups/{uid}/prepayments.json` (Production)
- **Signature**: `ListPrepaymentsForSubscriptionGroup(string uid, ListPrepaymentsFilter? filter, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `filter` — nullable, no default → **must pass explicitly**
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `ListSubscriptionGroupPrepaymentResponse`
- **Error**: `SdkException<ListPrepaymentsForSubscriptionGroupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`
