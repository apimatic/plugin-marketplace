# ReferralCodes — operations

Accessor: `client.ReferralCodes` · Source: `Api/ReferralCodes.cs` · 1 operations

### ValidateReferralCode
- **HTTP**: `GET /referral_codes/validate.json` (Production)
- **Signature**: `ValidateReferralCode(string code, CancellationToken ct = default)`
- **Returns**: `ReferralValidationResponse`
- **Error**: `SdkException<ValidateReferralCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetSingleStringErrorResponse1(out SingleStringErrorResponse1)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
