# Plans — operations

Accessor: `client.Plans` · Source: `Api/Plans.cs` · 8 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ActivatePlan
- **HTTP**: `POST /rbs/v1/plans/{id}/activate` (Default (apitest))
- **Signature**: `ActivatePlan(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `ActivateDeactivatePlanResponse`
- **Error**: `SdkException<ActivatePlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetActivatePlanException1(out ActivatePlanException1)` [400] · `TryGetActivatePlanException21(out ActivatePlanException21)` [404] · `TryGetActivatePlanException31(out ActivatePlanException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreatePlan
- **HTTP**: `POST /rbs/v1/plans` (Default (apitest))
- **Signature**: `CreatePlan(RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `CreatePlanResponse`
- **Error**: `SdkException<CreatePlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetCreatePlanException1(out CreatePlanException1)` [400] · `TryGetCreatePlanException21(out CreatePlanException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeactivatePlan
- **HTTP**: `POST /rbs/v1/plans/{id}/deactivate` (Default (apitest))
- **Signature**: `DeactivatePlan(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `ActivateDeactivatePlanResponse`
- **Error**: `SdkException<DeactivatePlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeactivatePlanException1(out DeactivatePlanException1)` [400] · `TryGetDeactivatePlanException21(out DeactivatePlanException21)` [404] · `TryGetDeactivatePlanException31(out DeactivatePlanException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeletePlan
- **HTTP**: `DELETE /rbs/v1/plans/{id}` (Default (apitest))
- **Signature**: `DeletePlan(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `DeletePlanResponse`
- **Error**: `SdkException<DeletePlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetDeletePlanException1(out DeletePlanException1)` [400] · `TryGetDeletePlanException21(out DeletePlanException21)` [404] · `TryGetDeletePlanException31(out DeletePlanException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetPlan
- **HTTP**: `GET /rbs/v1/plans/{id}` (Default (apitest))
- **Signature**: `GetPlan(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetPlanResponse`
- **Error**: `SdkException<GetPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetPlanException1(out GetPlanException1)` [400] · `TryGetGetPlanException21(out GetPlanException21)` [404] · `TryGetGetPlanException31(out GetPlanException31)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetPlanCode
- **HTTP**: `GET /rbs/v1/plans/code` (Default (apitest))
- **Signature**: `GetPlanCode(RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetPlanCodeResponse`
- **Error**: `SdkException<GetPlanCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetPlanCodeException1(out GetPlanCodeException1)` [400] · `TryGetGetPlanCodeException21(out GetPlanCodeException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### GetPlans
- **HTTP**: `GET /rbs/v1/plans` (Default (apitest))
- **Signature**: `GetPlans(int? offset, int? limit, string? code, string? status, string? name, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - 5 params (`offset` … `name`) — nullable, no default → **must pass explicitly** (pass `null` to skip)
  - defaults: `requestOptions` = null
- **Query params (wire ← C#)**: `offset` ← `offset`, `limit` ← `limit`, `code` ← `code`, `status` ← `status`, `name` ← `name`
- **Returns**: `GetAllPlansResponse`
- **Error**: `SdkException<GetPlansError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetPlansException1(out GetPlansException1)` [400] · `TryGetGetPlansException21(out GetPlansException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdatePlan
- **HTTP**: `PATCH /rbs/v1/plans/{id}` (Default (apitest))
- **Signature**: `UpdatePlan(string id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `UpdatePlanResponse`
- **Error**: `SdkException<UpdatePlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetUpdatePlanException1(out UpdatePlanException1)` [400] · `TryGetUpdatePlanException21(out UpdatePlanException21)` [502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
