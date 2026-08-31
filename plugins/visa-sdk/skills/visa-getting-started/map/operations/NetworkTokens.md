# NetworkTokens — operations

Accessor: `client.NetworkTokens` · Source: `Api/NetworkTokens.cs` · 7 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GetCardArtAsset
- **HTTP**: `GET /tms/v2/tokens/{instrumentIdentifierId}/{tokenProvider}/assets/{assetType}` (Default (apitest))
- **Signature**: `GetCardArtAsset(string instrumentIdentifierId, TokenProvider tokenProvider, AssetType assetType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `GetCardArtAssetResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?`
- **No-throw variant**: absent
- **Pagination**: none

### GetTokenizedCard
- **HTTP**: `GET /tms/v2/tokenized-cards/{tokenizedCardId}` (Default (apitest))
- **Signature**: `GetTokenizedCard(string tokenizedCardId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `GetTokenizedCardResponse`
- **Error**: `SdkException<GetTokenizedCardError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetTokenizedCardException1(out GetTokenizedCardException1)` [400] · `TryGetGetTokenizedCardException21(out GetTokenizedCardException21)` [403] · `TryGetGetTokenizedCardException31(out GetTokenizedCardException31)` [404] · `TryGetGetTokenizedCardException41(out GetTokenizedCardException41)` [424] · `TryGetGetTokenizedCardException51(out GetTokenizedCardException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostIssuerLifeCycleSimulation
- **HTTP**: `POST /tms/v2/tokenized-cards/{tokenizedCardId}/issuer-life-cycle-event-simulations` (Default (apitest))
- **Signature**: `PostIssuerLifeCycleSimulation(string tokenizedCardId, string profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<PostIssuerLifeCycleSimulationError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostIssuerLifeCycleSimulationException1(out PostIssuerLifeCycleSimulationException1)` [400] · `TryGetPostIssuerLifeCycleSimulationException21(out PostIssuerLifeCycleSimulationException21)` [403] · `TryGetPostIssuerLifeCycleSimulationException31(out PostIssuerLifeCycleSimulationException31)` [404] · `TryGetPostIssuerLifeCycleSimulationException41(out PostIssuerLifeCycleSimulationException41)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostTokenPaymentCredentials
- **HTTP**: `POST /tms/v2/tokens/{tokenId}/payment-credentials` (Default (apitest))
- **Signature**: `PostTokenPaymentCredentials(string tokenId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<PostTokenPaymentCredentialsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 410, 500, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostTokenPaymentCredentialsV3
- **HTTP**: `POST /tms/v3/tokens/{tokenId}/payment-credentials` (Default (apitest))
- **Signature**: `PostTokenPaymentCredentialsV3(string tokenId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<PostTokenPaymentCredentialsV3Error>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 403, 404, 409, 410, 500, 502] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostTokenizedCard
- **HTTP**: `POST /tms/v2/tokenized-cards` (Default (apitest))
- **Signature**: `PostTokenizedCard(string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `PostTokenizedCardResponse`
- **Error**: `SdkException<PostTokenizedCardError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostTokenizedCardException1(out PostTokenizedCardException1)` [400] · `TryGetPostTokenizedCardException21(out PostTokenizedCardException21)` [403] · `TryGetPostTokenizedCardException31(out PostTokenizedCardException31)` [409] · `TryGetPostTokenizedCardException41(out PostTokenizedCardException41)` [424] · `TryGetPostTokenizedCardException51(out PostTokenizedCardException51)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PostTokenizedCardDelete
- **HTTP**: `POST /tms/v2/tokenized-cards/{tokenizedCardId}/delete` (Default (apitest))
- **Signature**: `PostTokenizedCardDelete(string tokenizedCardId, string? profileId, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - `profileId` — nullable, no default → **must pass explicitly**
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<PostTokenizedCardDeleteError>` — **Case A (typed)**
- **Error accessors**: `TryGetPostTokenizedCardDeleteException1(out PostTokenizedCardDeleteException1)` [400] · `TryGetPostTokenizedCardDeleteException21(out PostTokenizedCardDeleteException21)` [403] · `TryGetPostTokenizedCardDeleteException31(out PostTokenizedCardDeleteException31)` [404] · `TryGetPostTokenizedCardDeleteException41(out PostTokenizedCardDeleteException41)` [409] · `TryGetPostTokenizedCardDeleteException51(out PostTokenizedCardDeleteException51)` [410] · `TryGetPostTokenizedCardDeleteException61(out PostTokenizedCardDeleteException61)` [424] · `TryGetPostTokenizedCardDeleteException71(out PostTokenizedCardDeleteException71)` [500] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
