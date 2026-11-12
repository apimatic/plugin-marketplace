<!-- Generated file — do not edit; regenerated with the SDK. -->

# SecuritiesTransfers — operations

Accessor: `client.SecuritiesTransfers` · Source: `src/UpvestInvestmentApi/Api/SecuritiesTransfers.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateSecuritiesTransfer

- **Auth**: `options.OauthClientCredentials` (scopes: `securities_transfers:admin`)
- **Signature**: `CreateSecuritiesTransfer(CreateSecuritiesTransferRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `SecuritiesTransfersResponse`
- **Error**: `ApiException<CreateSecuritiesTransferError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateSecuritiesTransferRequest` | `src/UpvestInvestmentApi/Requests/SecuritiesTransfers/CreateSecuritiesTransferRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `TransfersSecuritiesTransferCreateRequest` | `src/UpvestInvestmentApi/Models/TransfersSecuritiesTransferCreateRequest.cs` |
| `SecuritiesTransfersResponse` | `src/UpvestInvestmentApi/Models/SecuritiesTransfersResponse.cs` |
| `CreateSecuritiesTransferError` | `src/UpvestInvestmentApi/Errors/CreateSecuritiesTransferError.cs` |

### ListSecuritiesTransfers

- **Auth**: `options.OauthClientCredentials` (scopes: `securities_transfers:admin`, `securities_transfers:read`)
- **Signature**: `ListSecuritiesTransfers(ListSecuritiesTransfersRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Direction`
- **Query params (wire ← C#)**: `direction` ← `Direction`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`, `user_id` ← `UserId`, `account_id` ← `AccountId`, `account_group_id` ← `AccountGroupId`, `status` ← `Status`
- **Returns**: `SecurityTransfersListResponse`
- **Error**: `ApiException<ListSecuritiesTransfersError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListSecuritiesTransfersRequest` | `src/UpvestInvestmentApi/Requests/SecuritiesTransfers/ListSecuritiesTransfersRequest.cs` |
| `Direction` | `src/UpvestInvestmentApi/Models/Enums/Direction.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `Status78` | `src/UpvestInvestmentApi/Models/Enums/Status78.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `SecurityTransfersListResponse` | `src/UpvestInvestmentApi/Models/SecurityTransfersListResponse.cs` |
| `ListSecuritiesTransfersError` | `src/UpvestInvestmentApi/Errors/ListSecuritiesTransfersError.cs` |

