# ReportSubscriptions — operations

Accessor: `client.ReportSubscriptions` · Source: `Api/ReportSubscriptions.cs` · 5 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateStandardOrClassicSubscription
- **HTTP**: `PUT /reporting/v3/predefined-report-subscriptions` (Default (apitest))
- **Signature**: `CreateStandardOrClassicSubscription(string? organizationId, PredefinedSubscriptionRequestBean predefinedSubscriptionRequestBean, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreateStandardOrClassicSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateSubscription2
- **HTTP**: `PUT /reporting/v3/report-subscriptions` (Default (apitest))
- **Signature**: `CreateSubscription2(string? organizationId, CreateReportSubscriptionRequest createReportSubscriptionRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreateSubscription2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscription
- **HTTP**: `DELETE /reporting/v3/report-subscriptions/{reportName}` (Default (apitest))
- **Signature**: `DeleteSubscription(string reportName, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<DeleteSubscriptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetAllSubscriptions2
- **HTTP**: `GET /reporting/v3/report-subscriptions` (Default (apitest))
- **Signature**: `GetAllSubscriptions2(string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetAllSubscriptions2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetSubscription2
- **HTTP**: `GET /reporting/v3/report-subscriptions/{reportName}` (Default (apitest))
- **Signature**: `GetSubscription2(string reportName, string? organizationId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `organizationId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `organizationId` ← `organizationId`
- **Returns**: `void` (Task)
- **Error**: `SdkException<GetSubscription2Error>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
