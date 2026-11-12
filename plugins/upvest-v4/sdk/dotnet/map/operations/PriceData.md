<!-- Generated file — do not edit; regenerated with the SDK. -->

# PriceData — operations

Accessor: `client.PriceData` · Source: `src/UpvestInvestmentApi/Api/PriceData.cs` · 3 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### RetrieveInstrumentLatestPrice

- **Auth**: `options.OauthClientCredentials` (scopes: `prices:read`)
- **Signature**: `RetrieveInstrumentLatestPrice(RetrieveInstrumentLatestPriceRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InstrumentId`, `VenueId`
- **Query params (wire ← C#)**: `price_quality` ← `PriceQuality`
- **Returns**: `InstrumentsVenuesPricesLatestResponse`
- **Error**: `ApiException<RetrieveInstrumentLatestPriceError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveInstrumentLatestPriceRequest` | `src/UpvestInvestmentApi/Requests/PriceData/RetrieveInstrumentLatestPriceRequest.cs` |
| `InstrumentUniqueIdentifier` | `src/UpvestInvestmentApi/Models/AnyOf/InstrumentUniqueIdentifier.cs` |
| `PriceQuality1` | `src/UpvestInvestmentApi/Models/Enums/PriceQuality1.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `InstrumentsVenuesPricesLatestResponse` | `src/UpvestInvestmentApi/Models/InstrumentsVenuesPricesLatestResponse.cs` |
| `RetrieveInstrumentLatestPriceError` | `src/UpvestInvestmentApi/Errors/RetrieveInstrumentLatestPriceError.cs` |

### RetrieveInstrumentPricesOhlc

- **Auth**: `options.OauthClientCredentials` (scopes: `prices:read`)
- **Signature**: `RetrieveInstrumentPricesOhlc(RetrieveInstrumentPricesOhlcRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InstrumentId`, `VenueId`
- **Query params (wire ← C#)**: `start_date` ← `StartDate`, `end_date` ← `EndDate`, `adjusted_for` ← `AdjustedFor`, `interval` ← `Interval`
- **Returns**: `InstrumentsVenuesPricesOhlcResponse`
- **Error**: `ApiException<RetrieveInstrumentPricesOhlcError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveInstrumentPricesOhlcRequest` | `src/UpvestInvestmentApi/Requests/PriceData/RetrieveInstrumentPricesOhlcRequest.cs` |
| `InstrumentUniqueIdentifier` | `src/UpvestInvestmentApi/Models/AnyOf/InstrumentUniqueIdentifier.cs` |
| `AdjustedFor` | `src/UpvestInvestmentApi/Models/Enums/AdjustedFor.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `InstrumentsVenuesPricesOhlcResponse` | `src/UpvestInvestmentApi/Models/InstrumentsVenuesPricesOhlcResponse.cs` |
| `RetrieveInstrumentPricesOhlcError` | `src/UpvestInvestmentApi/Errors/RetrieveInstrumentPricesOhlcError.cs` |

### RetrieveInstrumentVenues

- **Auth**: `options.OauthClientCredentials` (scopes: `prices:read`)
- **Signature**: `RetrieveInstrumentVenues(RetrieveInstrumentVenuesRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InstrumentId`
- **Returns**: `InstrumentsVenuesResponse`
- **Error**: `ApiException<RetrieveInstrumentVenuesError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveInstrumentVenuesRequest` | `src/UpvestInvestmentApi/Requests/PriceData/RetrieveInstrumentVenuesRequest.cs` |
| `InstrumentUniqueIdentifier` | `src/UpvestInvestmentApi/Models/AnyOf/InstrumentUniqueIdentifier.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `InstrumentsVenuesResponse` | `src/UpvestInvestmentApi/Models/InstrumentsVenuesResponse.cs` |
| `RetrieveInstrumentVenuesError` | `src/UpvestInvestmentApi/Errors/RetrieveInstrumentVenuesError.cs` |

