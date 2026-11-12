<!-- Generated file — do not edit; regenerated with the SDK. -->

# TaxResidencies — operations

Accessor: `client.TaxResidencies` · Source: `src/UpvestInvestmentApi/Api/TaxResidencies.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### RetrieveTaxResidencies

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:read`, `taxes:admin`)
- **Signature**: `RetrieveTaxResidencies(RetrieveTaxResidenciesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Returns**: `TaxResidencyRecord`
- **Error**: `ApiException<RetrieveTaxResidenciesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveTaxResidenciesRequest` | `src/UpvestInvestmentApi/Requests/TaxResidencies/RetrieveTaxResidenciesRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxResidencyRecord` | `src/UpvestInvestmentApi/Models/TaxResidencyRecord.cs` |
| `RetrieveTaxResidenciesError` | `src/UpvestInvestmentApi/Errors/RetrieveTaxResidenciesError.cs` |

### SetTaxResidencies

- **Auth**: `options.OauthClientCredentials` (scopes: `taxes:admin`)
- **Signature**: `SetTaxResidencies(SetTaxResidenciesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`, `IdempotencyKey`
- **Returns**: `TaxResidencyRecord`
- **Error**: `ApiException<SetTaxResidenciesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `SetTaxResidenciesRequest` | `src/UpvestInvestmentApi/Requests/TaxResidencies/SetTaxResidenciesRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TaxResidenciesSetRequest` | `src/UpvestInvestmentApi/Models/TaxResidenciesSetRequest.cs` |
| `TaxResidencyRecord` | `src/UpvestInvestmentApi/Models/TaxResidencyRecord.cs` |
| `SetTaxResidenciesError` | `src/UpvestInvestmentApi/Errors/SetTaxResidenciesError.cs` |

