<!-- Generated file — do not edit; regenerated with the SDK. -->

# FeesConfigurations — operations

Accessor: `client.FeesConfigurations` · Source: `src/UpvestInvestmentApi/Api/FeesConfigurations.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateFeeConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `fees:admin`)
- **Signature**: `CreateFeeConfiguration(CreateFeeConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `FeeConfiguration3`
- **Error**: `ApiException<CreateFeeConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateFeeConfigurationRequest` | `src/UpvestInvestmentApi/Requests/FeesConfigurations/CreateFeeConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeConfigurationCreateRequest1` | `src/UpvestInvestmentApi/Models/FeeConfigurationCreateRequest1.cs` |
| `FeeConfiguration3` | `src/UpvestInvestmentApi/Models/FeeConfiguration3.cs` |
| `CreateFeeConfigurationError` | `src/UpvestInvestmentApi/Errors/CreateFeeConfigurationError.cs` |

### RetrieveFeeConfigurations

- **Auth**: `options.OauthClientCredentials` (scopes: `fees:read`, `fees:admin`)
- **Signature**: `RetrieveFeeConfigurations(RetrieveFeeConfigurationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Returns**: `FeeConfiguration3`
- **Error**: `ApiException<RetrieveFeeConfigurationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveFeeConfigurationsRequest` | `src/UpvestInvestmentApi/Requests/FeesConfigurations/RetrieveFeeConfigurationsRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeConfiguration3` | `src/UpvestInvestmentApi/Models/FeeConfiguration3.cs` |
| `RetrieveFeeConfigurationsError` | `src/UpvestInvestmentApi/Errors/RetrieveFeeConfigurationsError.cs` |

### UpdateFeeConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `fees:admin`)
- **Signature**: `UpdateFeeConfiguration(UpdateFeeConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Returns**: `FeeConfiguration3`
- **Error**: `ApiException<UpdateFeeConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateFeeConfigurationRequest` | `src/UpvestInvestmentApi/Requests/FeesConfigurations/UpdateFeeConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FeeConfigurationUpdateRequest` | `src/UpvestInvestmentApi/Models/FeeConfigurationUpdateRequest.cs` |
| `FeeConfiguration3` | `src/UpvestInvestmentApi/Models/FeeConfiguration3.cs` |
| `UpdateFeeConfigurationError` | `src/UpvestInvestmentApi/Errors/UpdateFeeConfigurationError.cs` |

