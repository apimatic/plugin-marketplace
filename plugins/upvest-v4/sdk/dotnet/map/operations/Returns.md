<!-- Generated file — do not edit; regenerated with the SDK. -->

# Returns — operations

Accessor: `client.Returns` · Source: `src/UpvestInvestmentApi/Api/Returns.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListAccountReturns

- **Auth**: `options.OauthClientCredentials` (scopes: `account_returns:read`)
- **Signature**: `ListAccountReturns(ListAccountReturnsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Query params (wire ← C#)**: `start_date` ← `StartDate`, `end_date` ← `EndDate`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `AccountReturnListResponse`
- **Error**: `ApiException<ListAccountReturnsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 405, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListAccountReturnsRequest` | `src/UpvestInvestmentApi/Requests/Returns/ListAccountReturnsRequest.cs` |
| `Sort33` | `src/UpvestInvestmentApi/Models/Enums/Sort33.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountReturnListResponse` | `src/UpvestInvestmentApi/Models/AccountReturnListResponse.cs` |
| `ListAccountReturnsError` | `src/UpvestInvestmentApi/Errors/ListAccountReturnsError.cs` |

