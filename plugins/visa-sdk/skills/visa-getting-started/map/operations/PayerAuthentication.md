# PayerAuthentication — operations

Accessor: `client.PayerAuthentication` · Source: `Api/PayerAuthentication.cs` · 3 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CheckPayerAuthEnrollment
- **HTTP**: `POST /risk/v1/authentications` (Default (apitest))
- **Signature**: `CheckPayerAuthEnrollment(CheckPayerAuthEnrollmentRequest checkPayerAuthEnrollmentRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CheckPayerAuthEnrollmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PayerAuthSetup
- **HTTP**: `POST /risk/v1/authentication-setups` (Default (apitest))
- **Signature**: `PayerAuthSetup(PayerAuthSetupRequest payerAuthSetupRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<PayerAuthSetupError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ValidateAuthenticationResults
- **HTTP**: `POST /risk/v1/authentication-results` (Default (apitest))
- **Signature**: `ValidateAuthenticationResults(ValidateRequest validateRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<ValidateAuthenticationResultsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
