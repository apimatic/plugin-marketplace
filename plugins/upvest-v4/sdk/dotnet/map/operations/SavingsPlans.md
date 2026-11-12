<!-- Generated file — do not edit; regenerated with the SDK. -->

# SavingsPlans — operations

Accessor: `client.SavingsPlans` · Source: `src/UpvestInvestmentApi/Api/SavingsPlans.cs` · 8 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateSavingsPlan

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:admin`)
- **Signature**: `CreateSavingsPlan(CreateSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `SavingsPlanInstrument`
- **Error**: `ApiException<CreateSavingsPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSavingsPlanRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/CreateSavingsPlanRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SavingsPlanCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/SavingsPlanCreateRequest.cs` |
| `SavingsPlanInstrument` | `src/UpvestInvestmentApi/Models/SavingsPlanInstrument.cs` |
| `CreateSavingsPlanError` | `src/UpvestInvestmentApi/Errors/CreateSavingsPlanError.cs` |

### DeleteSavingsPlan

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:admin`)
- **Signature**: `DeleteSavingsPlan(DeleteSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SavingsPlanId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteSavingsPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteSavingsPlanRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/DeleteSavingsPlanRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeleteSavingsPlanError` | `src/UpvestInvestmentApi/Errors/DeleteSavingsPlanError.cs` |

### DeleteSavingsPlanExecution

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:admin`)
- **Signature**: `DeleteSavingsPlanExecution(DeleteSavingsPlanExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SavingsPlanId`, `SavingsPlanExecutionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteSavingsPlanExecutionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteSavingsPlanExecutionRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/DeleteSavingsPlanExecutionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeleteSavingsPlanExecutionError` | `src/UpvestInvestmentApi/Errors/DeleteSavingsPlanExecutionError.cs` |

### ListSavingsPlanExecutions

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:read`, `savings_plans:admin`)
- **Signature**: `ListSavingsPlanExecutions(ListSavingsPlanExecutionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SavingsPlanId`
- **Query params (wire ← C#)**: `start_date` ← `StartDate`, `end_date` ← `EndDate`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `SavingsPlanExecutionListResponse`
- **Error**: `ApiException<ListSavingsPlanExecutionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListSavingsPlanExecutionsRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/ListSavingsPlanExecutionsRequest.cs` |
| `Sort36` | `src/UpvestInvestmentApi/Models/Enums/Sort36.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SavingsPlanExecutionListResponse` | `src/UpvestInvestmentApi/Models/SavingsPlanExecutionListResponse.cs` |
| `ListSavingsPlanExecutionsError` | `src/UpvestInvestmentApi/Errors/ListSavingsPlanExecutionsError.cs` |

### ListSavingsPlans

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:read`, `savings_plans:admin`)
- **Signature**: `ListSavingsPlans(ListSavingsPlansRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `account_id` ← `AccountId`, `user_id` ← `UserId`, `instrument_id` ← `InstrumentId`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `SavingsPlanListResponse`
- **Error**: `ApiException<ListSavingsPlansError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListSavingsPlansRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/ListSavingsPlansRequest.cs` |
| `InstrumentUniqueIdentifier5` | `src/UpvestInvestmentApi/Models/AnyOf/InstrumentUniqueIdentifier5.cs` |
| `Sort24` | `src/UpvestInvestmentApi/Models/Enums/Sort24.cs` |
| `Order60` | `src/UpvestInvestmentApi/Models/Enums/Order60.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SavingsPlanListResponse` | `src/UpvestInvestmentApi/Models/SavingsPlanListResponse.cs` |
| `ListSavingsPlansError` | `src/UpvestInvestmentApi/Errors/ListSavingsPlansError.cs` |

### RetrieveSavingsPlan

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:read`, `savings_plans:admin`)
- **Signature**: `RetrieveSavingsPlan(RetrieveSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SavingsPlanId`
- **Returns**: `SavingsPlanInstrument`
- **Error**: `ApiException<RetrieveSavingsPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveSavingsPlanRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/RetrieveSavingsPlanRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SavingsPlanInstrument` | `src/UpvestInvestmentApi/Models/SavingsPlanInstrument.cs` |
| `RetrieveSavingsPlanError` | `src/UpvestInvestmentApi/Errors/RetrieveSavingsPlanError.cs` |

### RetrieveSavingsPlanExecution

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:read`, `savings_plans:admin`)
- **Signature**: `RetrieveSavingsPlanExecution(RetrieveSavingsPlanExecutionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SavingsPlanId`, `SavingsPlanExecutionId`
- **Returns**: `SavingsPlanExecution`
- **Error**: `ApiException<RetrieveSavingsPlanExecutionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveSavingsPlanExecutionRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/RetrieveSavingsPlanExecutionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SavingsPlanExecution` | `src/UpvestInvestmentApi/Models/AnyOf/SavingsPlanExecution.cs` |
| `RetrieveSavingsPlanExecutionError` | `src/UpvestInvestmentApi/Errors/RetrieveSavingsPlanExecutionError.cs` |

### UpdateSavingsPlan

- **Auth**: `options.OauthClientCredentials` (scopes: `savings_plans:admin`)
- **Signature**: `UpdateSavingsPlan(UpdateSavingsPlanRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `SavingsPlanId`
- **Returns**: `SavingsPlanInstrument`
- **Error**: `ApiException<UpdateSavingsPlanError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateSavingsPlanRequest` | `src/UpvestInvestmentApi/Requests/SavingsPlans/UpdateSavingsPlanRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SavingsPlanUpdateRequest` | `src/UpvestInvestmentApi/Models/SavingsPlanUpdateRequest.cs` |
| `SavingsPlanInstrument` | `src/UpvestInvestmentApi/Models/SavingsPlanInstrument.cs` |
| `UpdateSavingsPlanError` | `src/UpvestInvestmentApi/Errors/UpdateSavingsPlanError.cs` |

