<!-- Generated file — do not edit; regenerated with the SDK. -->

# Tests — operations

Accessor: `client.Tests` · Source: `src/UpvestInvestmentApi/Api/Tests.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateBankTransaction

- **Auth**: `options.OauthClientCredentials` (scopes: `tests:admin`)
- **Signature**: `CreateBankTransaction(CreateBankTransactionRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `IdempotencyKey`
- **Returns**: `PaymentsBankTransactionCreateResponse`
- **Error**: `ApiException<CreateBankTransactionError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateBankTransactionRequest` | `src/UpvestInvestmentApi/Requests/Tests/CreateBankTransactionRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `PaymentsBankTransactionCreateRequest` | `src/UpvestInvestmentApi/Models/PaymentsBankTransactionCreateRequest.cs` |
| `PaymentsBankTransactionCreateResponse` | `src/UpvestInvestmentApi/Models/PaymentsBankTransactionCreateResponse.cs` |
| `CreateBankTransactionError` | `src/UpvestInvestmentApi/Errors/CreateBankTransactionError.cs` |

