<!-- Generated file — do not edit; regenerated with the SDK. -->

# TaxExemptions — operations

Accessor: `client.TaxExemptions` · Source: `src/UpvestInvestmentApi/Api/TaxExemptions.cs` · 5 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateTaxExemption

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`)
- **Signature**: `CreateTaxExemption(CreateTaxExemptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `WebhookTaxExemptionCreatedTaxExemption`
- **Error**: `ApiException<CreateTaxExemptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateTaxExemptionRequest` | `src/UpvestInvestmentApi/Requests/TaxExemptions/CreateTaxExemptionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxesTaxExemptionsCreateRequest` | `src/UpvestInvestmentApi/Models/TaxesTaxExemptionsCreateRequest.cs` |
| `WebhookTaxExemptionCreatedTaxExemption` | `src/UpvestInvestmentApi/Models/WebhookTaxExemptionCreatedTaxExemption.cs` |
| `CreateTaxExemptionError` | `src/UpvestInvestmentApi/Errors/CreateTaxExemptionError.cs` |

### DeleteTaxExemption

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`)
- **Signature**: `DeleteTaxExemption(DeleteTaxExemptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TaxExemptionId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteTaxExemptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteTaxExemptionRequest` | `src/UpvestInvestmentApi/Requests/TaxExemptions/DeleteTaxExemptionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeleteTaxExemptionError` | `src/UpvestInvestmentApi/Errors/DeleteTaxExemptionError.cs` |

### RetrieveTaxExemptionById

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`)
- **Signature**: `RetrieveTaxExemptionById(RetrieveTaxExemptionByIdRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TaxExemptionId`
- **Returns**: `WebhookTaxExemptionCreatedTaxExemption`
- **Error**: `ApiException<RetrieveTaxExemptionByIdError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveTaxExemptionByIdRequest` | `src/UpvestInvestmentApi/Requests/TaxExemptions/RetrieveTaxExemptionByIdRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `WebhookTaxExemptionCreatedTaxExemption` | `src/UpvestInvestmentApi/Models/WebhookTaxExemptionCreatedTaxExemption.cs` |
| `RetrieveTaxExemptionByIdError` | `src/UpvestInvestmentApi/Errors/RetrieveTaxExemptionByIdError.cs` |

### RetrieveTaxExemptionsForUser

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`)
- **Signature**: `RetrieveTaxExemptionsForUser(RetrieveTaxExemptionsForUserRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `TaxExemptionRetrieveForUserResponse`
- **Error**: `ApiException<RetrieveTaxExemptionsForUserError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveTaxExemptionsForUserRequest` | `src/UpvestInvestmentApi/Requests/TaxExemptions/RetrieveTaxExemptionsForUserRequest.cs` |
| `Sort9` | `src/UpvestInvestmentApi/Models/Enums/Sort9.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxExemptionRetrieveForUserResponse` | `src/UpvestInvestmentApi/Models/TaxExemptionRetrieveForUserResponse.cs` |
| `RetrieveTaxExemptionsForUserError` | `src/UpvestInvestmentApi/Errors/RetrieveTaxExemptionsForUserError.cs` |

### UpdateTaxExemption

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`)
- **Signature**: `UpdateTaxExemption(UpdateTaxExemptionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `TaxExemptionId`
- **Returns**: `WebhookTaxExemptionCreatedTaxExemption`
- **Error**: `ApiException<UpdateTaxExemptionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateTaxExemptionRequest` | `src/UpvestInvestmentApi/Requests/TaxExemptions/UpdateTaxExemptionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxesTaxExemptionsUpdateRequest` | `src/UpvestInvestmentApi/Models/TaxesTaxExemptionsUpdateRequest.cs` |
| `WebhookTaxExemptionCreatedTaxExemption` | `src/UpvestInvestmentApi/Models/WebhookTaxExemptionCreatedTaxExemption.cs` |
| `UpdateTaxExemptionError` | `src/UpvestInvestmentApi/Errors/UpdateTaxExemptionError.cs` |

