<!-- Generated file — do not edit; regenerated with the SDK. -->

# VirtualBankAccounts — operations

Accessor: `client.VirtualBankAccounts` · Source: `src/UpvestInvestmentApi/Api/VirtualBankAccounts.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateVirtualBankAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`)
- **Signature**: `CreateVirtualBankAccount(CreateVirtualBankAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PaymentsVirtualBankAccountsResponse`
- **Error**: `ApiException<CreateVirtualBankAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateVirtualBankAccountRequest` | `src/UpvestInvestmentApi/Requests/VirtualBankAccounts/CreateVirtualBankAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsVirtualBankAccountCreateRequest` | `src/UpvestInvestmentApi/Models/PaymentsVirtualBankAccountCreateRequest.cs` |
| `PaymentsVirtualBankAccountsResponse` | `src/UpvestInvestmentApi/Models/PaymentsVirtualBankAccountsResponse.cs` |
| `CreateVirtualBankAccountError` | `src/UpvestInvestmentApi/Errors/CreateVirtualBankAccountError.cs` |

### ListVirtualBankAccounts

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`, `payments:read`)
- **Signature**: `ListVirtualBankAccounts(ListVirtualBankAccountsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `PaymentsVirtualBankAccountsListResponse`
- **Error**: `ApiException<ListVirtualBankAccountsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListVirtualBankAccountsRequest` | `src/UpvestInvestmentApi/Requests/VirtualBankAccounts/ListVirtualBankAccountsRequest.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsVirtualBankAccountsListResponse` | `src/UpvestInvestmentApi/Models/PaymentsVirtualBankAccountsListResponse.cs` |
| `ListVirtualBankAccountsError` | `src/UpvestInvestmentApi/Errors/ListVirtualBankAccountsError.cs` |

### RetrieveVirtualBankAccount

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`, `payments:read`)
- **Signature**: `RetrieveVirtualBankAccount(RetrieveVirtualBankAccountRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `VirtualBankAccountId`
- **Returns**: `PaymentsVirtualBankAccountsResponse`
- **Error**: `ApiException<RetrieveVirtualBankAccountError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveVirtualBankAccountRequest` | `src/UpvestInvestmentApi/Requests/VirtualBankAccounts/RetrieveVirtualBankAccountRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsVirtualBankAccountsResponse` | `src/UpvestInvestmentApi/Models/PaymentsVirtualBankAccountsResponse.cs` |
| `RetrieveVirtualBankAccountError` | `src/UpvestInvestmentApi/Errors/RetrieveVirtualBankAccountError.cs` |

