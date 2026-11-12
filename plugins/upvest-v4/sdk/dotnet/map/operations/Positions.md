<!-- Generated file — do not edit; regenerated with the SDK. -->

# Positions — operations

Accessor: `client.Positions` · Source: `src/UpvestInvestmentApi/Api/Positions.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListPositions

- **Auth**: `options.OauthClientCredentials` (scopes: `positions:read`)
- **Signature**: `ListPositions(ListPositionsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountId`
- **Query params (wire ← C#)**: `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `PositionsListResponse`
- **Error**: `ApiException<ListPositionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListPositionsRequest` | `src/UpvestInvestmentApi/Requests/Positions/ListPositionsRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PositionsListResponse` | `src/UpvestInvestmentApi/Models/PositionsListResponse.cs` |
| `ListPositionsError` | `src/UpvestInvestmentApi/Errors/ListPositionsError.cs` |

### RetrievePosition

- **Auth**: `options.OauthClientCredentials` (scopes: `positions:read`)
- **Signature**: `RetrievePosition(RetrievePositionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InstrumentId`, `AccountId`
- **Returns**: `AccountsPositionsResponse`
- **Error**: `ApiException<RetrievePositionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrievePositionRequest` | `src/UpvestInvestmentApi/Requests/Positions/RetrievePositionRequest.cs` |
| `InstrumentUniqueIdentifier` | `src/UpvestInvestmentApi/Models/AnyOf/InstrumentUniqueIdentifier.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountsPositionsResponse` | `src/UpvestInvestmentApi/Models/AccountsPositionsResponse.cs` |
| `RetrievePositionError` | `src/UpvestInvestmentApi/Errors/RetrievePositionError.cs` |

