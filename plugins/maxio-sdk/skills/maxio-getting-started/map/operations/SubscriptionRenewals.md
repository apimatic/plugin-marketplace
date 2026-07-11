# SubscriptionRenewals — operations

Accessor: `client.SubscriptionRenewals` · Source: `Api/SubscriptionRenewals.cs` · 11 operations

### CancelScheduledRenewalConfiguration
- **HTTP**: `PUT /subscriptions/{subscription_id}/scheduled_renewals/{id}/cancel.json` (Production)
- **Signature**: `CancelScheduledRenewalConfiguration(int subscriptionId, int id, CancellationToken ct = default)`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `SdkException<CancelScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateScheduledRenewalConfiguration
- **HTTP**: `POST /subscriptions/{subscription_id}/scheduled_renewals.json` (Production)
- **Signature**: `CreateScheduledRenewalConfiguration(int subscriptionId, ScheduledRenewalConfigurationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `SdkException<CreateScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateScheduledRenewalConfigurationItem
- **HTTP**: `POST /subscriptions/{subscription_id}/scheduled_renewals/{scheduled_renewals_configuration_id}/configuration_items.json` (Production)
- **Signature**: `CreateScheduledRenewalConfigurationItem(int subscriptionId, int scheduledRenewalsConfigurationId, ScheduledRenewalConfigurationItemRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ScheduledRenewalConfigurationItemResponse`
- **Error**: `SdkException<CreateScheduledRenewalConfigurationItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteScheduledRenewalConfigurationItem
- **HTTP**: `DELETE /subscriptions/{subscription_id}/scheduled_renewals/{scheduled_renewals_configuration_id}/configuration_items/{id}.json` (Production)
- **Signature**: `DeleteScheduledRenewalConfigurationItem(int subscriptionId, int scheduledRenewalsConfigurationId, int id, CancellationToken ct = default)`
- **Returns**: `void`
- **Error**: `SdkException<DeleteScheduledRenewalConfigurationItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListScheduledRenewalConfigurations
- **HTTP**: `GET /subscriptions/{subscription_id}/scheduled_renewals.json` (Production)
- **Signature**: `ListScheduledRenewalConfigurations(int subscriptionId, Status? status, CancellationToken ct = default)`
  - `status` — nullable, no default → **must pass explicitly**
- **Returns**: `ScheduledRenewalConfigurationsResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### LockInScheduledRenewalImmediately
- **HTTP**: `PUT /subscriptions/{subscription_id}/scheduled_renewals/{id}/immediate_lock_in.json` (Production)
- **Signature**: `LockInScheduledRenewalImmediately(int subscriptionId, int id, CancellationToken ct = default)`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `SdkException<LockInScheduledRenewalImmediatelyError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ReadScheduledRenewalConfiguration
- **HTTP**: `GET /subscriptions/{subscription_id}/scheduled_renewals/{id}.json` (Production)
- **Signature**: `ReadScheduledRenewalConfiguration(int subscriptionId, int id, CancellationToken ct = default)`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ScheduleScheduledRenewalLockIn
- **HTTP**: `PUT /subscriptions/{subscription_id}/scheduled_renewals/{id}/schedule_lock_in.json` (Production)
- **Signature**: `ScheduleScheduledRenewalLockIn(int subscriptionId, int id, ScheduledRenewalLockInRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `SdkException<ScheduleScheduledRenewalLockInError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UnpublishScheduledRenewalConfiguration
- **HTTP**: `PUT /subscriptions/{subscription_id}/scheduled_renewals/{id}/unpublish.json` (Production)
- **Signature**: `UnpublishScheduledRenewalConfiguration(int subscriptionId, int id, CancellationToken ct = default)`
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `SdkException<UnpublishScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateScheduledRenewalConfiguration
- **HTTP**: `PUT /subscriptions/{subscription_id}/scheduled_renewals/{id}.json` (Production)
- **Signature**: `UpdateScheduledRenewalConfiguration(int subscriptionId, int id, ScheduledRenewalConfigurationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ScheduledRenewalConfigurationResponse`
- **Error**: `SdkException<UpdateScheduledRenewalConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateScheduledRenewalConfigurationItem
- **HTTP**: `PUT /subscriptions/{subscription_id}/scheduled_renewals/{scheduled_renewals_configuration_id}/configuration_items/{id}.json` (Production)
- **Signature**: `UpdateScheduledRenewalConfigurationItem(int subscriptionId, int scheduledRenewalsConfigurationId, int id, ScheduledRenewalUpdateRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ScheduledRenewalConfigurationItemResponse`
- **Error**: `SdkException<UpdateScheduledRenewalConfigurationItemError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
