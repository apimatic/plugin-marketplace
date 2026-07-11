# ReasonCodes — operations

Accessor: `client.ReasonCodes` · Source: `Api/ReasonCodes.cs` · 5 operations

### CreateReasonCode
- **HTTP**: `POST /reason_codes.json` (Production)
- **Signature**: `CreateReasonCode(CreateReasonCodeRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ReasonCodeResponse`
- **Error**: `SdkException<CreateReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteReasonCode
- **HTTP**: `DELETE /reason_codes/{reason_code_id}.json` (Production)
- **Signature**: `DeleteReasonCode(int reasonCodeId, CancellationToken ct = default)`
- **Returns**: `OkResponse`
- **Error**: `SdkException<DeleteReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListReasonCodes
- **HTTP**: `GET /reason_codes.json` (Production)
- **Signature**: `ListReasonCodes(int? page = 1, int? perPage = 20, CancellationToken ct = default)`
- **Returns**: `IReadOnlyList<ReasonCodeResponse>`
- **Error**: `SdkException<ListReasonCodesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadReasonCode
- **HTTP**: `GET /reason_codes/{reason_code_id}.json` (Production)
- **Signature**: `ReadReasonCode(int reasonCodeId, CancellationToken ct = default)`
- **Returns**: `ReasonCodeResponse`
- **Error**: `SdkException<ReadReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### UpdateReasonCode
- **HTTP**: `PUT /reason_codes/{reason_code_id}.json` (Production)
- **Signature**: `UpdateReasonCode(int reasonCodeId, UpdateReasonCodeRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ReasonCodeResponse`
- **Error**: `SdkException<UpdateReasonCodeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
