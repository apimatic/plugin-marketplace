# Offers — operations

Accessor: `client.Offers` · Source: `Api/Offers.cs` · 5 operations

### ArchiveOffer
- **HTTP**: `PUT /offers/{offer_id}/archive.json` (Production)
- **Signature**: `ArchiveOffer(int offerId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### CreateOffer
- **HTTP**: `POST /offers.json` (Production)
- **Signature**: `CreateOffer(CreateOfferRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `OfferResponse`
- **Error**: `SdkException<CreateOfferError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorArrayMapResponse1(out ErrorArrayMapResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListOffers
- **HTTP**: `GET /offers.json` (Production)
- **Signature**: `ListOffers(bool? includeArchived, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `includeArchived` — nullable, no default → **must pass explicitly**
- **Returns**: `ListOffersResponse`
- **Error**: `SdkException<ListOffersError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadOffer
- **HTTP**: `GET /offers/{offer_id}.json` (Production)
- **Signature**: `ReadOffer(int offerId, CancellationToken ct = default)`
- **Returns**: `OfferResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UnarchiveOffer
- **HTTP**: `PUT /offers/{offer_id}/unarchive.json` (Production)
- **Signature**: `UnarchiveOffer(int offerId, CancellationToken ct = default)`
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none
