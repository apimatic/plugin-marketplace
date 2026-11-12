<!-- Generated file — do not edit; regenerated with the SDK. -->

# AccessTokens — operations

Accessor: `client.AccessTokens` · Source: `src/UpvestInvestmentApi/Api/AccessTokens.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### IssueToken

- **Signature**: `IssueToken(IssueTokenRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ClientId`, `ClientSecret`, `Scope`
- **Returns**: `AuthAccessToken`
- **Error**: `ApiException<IssueTokenError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `IssueTokenRequest` | `src/UpvestInvestmentApi/Requests/AccessTokens/IssueTokenRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AuthAccessToken` | `src/UpvestInvestmentApi/Models/AuthAccessToken.cs` |
| `IssueTokenError` | `src/UpvestInvestmentApi/Errors/IssueTokenError.cs` |

