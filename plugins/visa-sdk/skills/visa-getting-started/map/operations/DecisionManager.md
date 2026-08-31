# DecisionManager — operations

Accessor: `client.DecisionManager` · Source: `Api/DecisionManager.cs` · 5 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### ActionDecisionManagerCase
- **HTTP**: `POST /risk/v1/decisions/{id}/actions` (Default (apitest))
- **Signature**: `ActionDecisionManagerCase(string id, CaseManagementActionsRequest caseManagementActionsRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `ActionDecisionManagerCaseResponse`
- **Error**: `SdkException<ActionDecisionManagerCaseError>` — **Case A (typed)**
- **Error accessors**: `TryGetActionDecisionManagerCaseException1(out ActionDecisionManagerCaseException1)` [400] · `TryGetActionDecisionManagerCaseException21(out ActionDecisionManagerCaseException21)` [403] · `TryGetActionDecisionManagerCaseException31(out ActionDecisionManagerCaseException31)` [422] · `TryGetActionDecisionManagerCaseException41(out ActionDecisionManagerCaseException41)` [500] · `TryGetActionDecisionManagerCaseException51(out ActionDecisionManagerCaseException51)` [502] · `TryGetActionDecisionManagerCaseException61(out ActionDecisionManagerCaseException61)` [503] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### AddNegative
- **HTTP**: `POST /risk/v1/lists/{type}/entries` (Default (apitest))
- **Signature**: `AddNegative(string type, AddNegativeListRequest addNegativeListRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<AddNegativeError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CommentDecisionManagerCase
- **HTTP**: `POST /risk/v1/decisions/{id}/comments` (Default (apitest))
- **Signature**: `CommentDecisionManagerCase(string id, CaseManagementCommentsRequest caseManagementCommentsRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `CommentDecisionManagerCaseResponse`
- **Error**: `SdkException<CommentDecisionManagerCaseError>` — **Case A (typed)**
- **Error accessors**: `TryGetCommentDecisionManagerCaseException1(out CommentDecisionManagerCaseException1)` [400] · `TryGetCommentDecisionManagerCaseException21(out CommentDecisionManagerCaseException21)` [403] · `TryGetCommentDecisionManagerCaseException31(out CommentDecisionManagerCaseException31)` [422] · `TryGetCommentDecisionManagerCaseException41(out CommentDecisionManagerCaseException41)` [500] · `TryGetCommentDecisionManagerCaseException51(out CommentDecisionManagerCaseException51)` [502] · `TryGetCommentDecisionManagerCaseException61(out CommentDecisionManagerCaseException61)` [503] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateBundledDecisionManagerCase
- **HTTP**: `POST /risk/v1/decisions` (Default (apitest))
- **Signature**: `CreateBundledDecisionManagerCase(RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<CreateBundledDecisionManagerCaseError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### FraudUpdate
- **HTTP**: `POST /risk/v1/decisions/{id}/marking` (Default (apitest))
- **Signature**: `FraudUpdate(string id, FraudMarkingActionRequest fraudMarkingActionRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<FraudUpdateError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
