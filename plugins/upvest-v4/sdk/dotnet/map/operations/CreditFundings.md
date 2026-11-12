<!-- Generated file — do not edit; regenerated with the SDK. -->

# CreditFundings — operations

Accessor: `client.CreditFundings` · Source: `src/UpvestInvestmentApi/Api/CreditFundings.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListCreditFundings

- **Auth**: `options.OauthClientCredentials` (scopes: `credit_fundings:read`, `payments:admin`, `payments:read`)
- **Signature**: `ListCreditFundings(ListCreditFundingsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `PaymentsCreditFundingsListResponse`
- **Error**: `ApiException<ListCreditFundingsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListCreditFundingsRequest` | `src/UpvestInvestmentApi/Requests/CreditFundings/ListCreditFundingsRequest.cs` |
| `Sort9` | `src/UpvestInvestmentApi/Models/Enums/Sort9.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsCreditFundingsListResponse` | `src/UpvestInvestmentApi/Models/PaymentsCreditFundingsListResponse.cs` |
| `ListCreditFundingsError` | `src/UpvestInvestmentApi/Errors/ListCreditFundingsError.cs` |

### RetrieveCreditFunding

- **Auth**: `options.OauthClientCredentials` (scopes: `credit_fundings:read`, `payments:admin`, `payments:read`)
- **Signature**: `RetrieveCreditFunding(RetrieveCreditFundingRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `CreditFundingId`
- **Returns**: `PaymentsCreditFundingsResponse`
- **Error**: `ApiException<RetrieveCreditFundingError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveCreditFundingRequest` | `src/UpvestInvestmentApi/Requests/CreditFundings/RetrieveCreditFundingRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsCreditFundingsResponse` | `src/UpvestInvestmentApi/Models/PaymentsCreditFundingsResponse.cs` |
| `RetrieveCreditFundingError` | `src/UpvestInvestmentApi/Errors/RetrieveCreditFundingError.cs` |

### RetrieveFundingDetails

- **Auth**: `options.OauthClientCredentials` (scopes: `payments:admin`, `payments:read`)
- **Signature**: `RetrieveFundingDetails(RetrieveFundingDetailsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `AccountGroupId`
- **Query params (wire ← C#)**: `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `AccountGroupsPaymentsCreditFundingDetailsResponse`
- **Error**: `ApiException<RetrieveFundingDetailsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveFundingDetailsRequest` | `src/UpvestInvestmentApi/Requests/CreditFundings/RetrieveFundingDetailsRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AccountGroupsPaymentsCreditFundingDetailsResponse` | `src/UpvestInvestmentApi/Models/AccountGroupsPaymentsCreditFundingDetailsResponse.cs` |
| `RetrieveFundingDetailsError` | `src/UpvestInvestmentApi/Errors/RetrieveFundingDetailsError.cs` |

