<!-- Generated file — do not edit; regenerated with the SDK. -->

# TransactionFeesConfigurations — operations

Accessor: `client.TransactionFeesConfigurations` · Source: `src/UpvestInvestmentApi/Api/TransactionFeesConfigurations.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateTransactionFeeAccountGroupConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `transaction_fees:admin`)
- **Signature**: `CreateTransactionFeeAccountGroupConfiguration(CreateTransactionFeeAccountGroupConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `TransactionFeeAccountGroupConfiguration`
- **Error**: `ApiException<CreateTransactionFeeAccountGroupConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateTransactionFeeAccountGroupConfigurationRequest` | `src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/CreateTransactionFeeAccountGroupConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TransactionFeeAccountGroupConfigurationCreateRequest` | `src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfigurationCreateRequest.cs` |
| `TransactionFeeAccountGroupConfiguration` | `src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfiguration.cs` |
| `CreateTransactionFeeAccountGroupConfigurationError` | `src/UpvestInvestmentApi/Errors/CreateTransactionFeeAccountGroupConfigurationError.cs` |

### DeleteTransactionFeeAccountGroupConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `transaction_fees:admin`)
- **Signature**: `DeleteTransactionFeeAccountGroupConfiguration(DeleteTransactionFeeAccountGroupConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`, `Id`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteTransactionFeeAccountGroupConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteTransactionFeeAccountGroupConfigurationRequest` | `src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/DeleteTransactionFeeAccountGroupConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeleteTransactionFeeAccountGroupConfigurationError` | `src/UpvestInvestmentApi/Errors/DeleteTransactionFeeAccountGroupConfigurationError.cs` |

### ListTransactionFeeAccountGroupConfigurations

- **Auth**: `options.OauthClientCredentials` (scopes: `transaction_fees:admin`, `transaction_fees:read`)
- **Signature**: `ListTransactionFeeAccountGroupConfigurations(ListTransactionFeeAccountGroupConfigurationsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Id`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `TransactionFeeAccountGroupConfigurationsListResponse`
- **Error**: `ApiException<ListTransactionFeeAccountGroupConfigurationsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListTransactionFeeAccountGroupConfigurationsRequest` | `src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/ListTransactionFeeAccountGroupConfigurationsRequest.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TransactionFeeAccountGroupConfigurationsListResponse` | `src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfigurationsListResponse.cs` |
| `ListTransactionFeeAccountGroupConfigurationsError` | `src/UpvestInvestmentApi/Errors/ListTransactionFeeAccountGroupConfigurationsError.cs` |

### UpdateTransactionFeeAccountGroupConfiguration

- **Auth**: `options.OauthClientCredentials` (scopes: `transaction_fees:admin`)
- **Signature**: `UpdateTransactionFeeAccountGroupConfiguration(UpdateTransactionFeeAccountGroupConfigurationRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Id`
- **Returns**: `TransactionFeeAccountGroupConfiguration`
- **Error**: `ApiException<UpdateTransactionFeeAccountGroupConfigurationError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 409, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateTransactionFeeAccountGroupConfigurationRequest` | `src/UpvestInvestmentApi/Requests/TransactionFeesConfigurations/UpdateTransactionFeeAccountGroupConfigurationRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TransactionFeeAccountGroupConfigurationUpdateRequest` | `src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfigurationUpdateRequest.cs` |
| `TransactionFeeAccountGroupConfiguration` | `src/UpvestInvestmentApi/Models/TransactionFeeAccountGroupConfiguration.cs` |
| `UpdateTransactionFeeAccountGroupConfigurationError` | `src/UpvestInvestmentApi/Errors/UpdateTransactionFeeAccountGroupConfigurationError.cs` |

