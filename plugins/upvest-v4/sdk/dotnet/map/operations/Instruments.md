<!-- Generated file — do not edit; regenerated with the SDK. -->

# Instruments — operations

Accessor: `client.Instruments` · Source: `src/UpvestInvestmentApi/Api/Instruments.cs` · 2 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### ListInstruments

- **Auth**: `options.OauthClientCredentials` (scopes: `instruments:read`)
- **Signature**: `ListInstruments(ListInstrumentsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `trading_status` ← `TradingStatus`, `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `InstrumentsListResponse`
- **Error**: `ApiException<ListInstrumentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListInstrumentsRequest` | `src/UpvestInvestmentApi/Requests/Instruments/ListInstrumentsRequest.cs` |
| `InstrumentTradingStatus` | `src/UpvestInvestmentApi/Models/Enums/InstrumentTradingStatus.cs` |
| `Sort1` | `src/UpvestInvestmentApi/Models/Enums/Sort1.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `InstrumentsListResponse` | `src/UpvestInvestmentApi/Models/InstrumentsListResponse.cs` |
| `ListInstrumentsError` | `src/UpvestInvestmentApi/Errors/ListInstrumentsError.cs` |

### RetrieveInstrument

- **Auth**: `options.OauthClientCredentials` (scopes: `instruments:read`)
- **Signature**: `RetrieveInstrument(RetrieveInstrumentRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `InstrumentId`
- **Returns**: `InstrumentsResponse`
- **Error**: `ApiException<RetrieveInstrumentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveInstrumentRequest` | `src/UpvestInvestmentApi/Requests/Instruments/RetrieveInstrumentRequest.cs` |
| `InstrumentUniqueIdentifier` | `src/UpvestInvestmentApi/Models/AnyOf/InstrumentUniqueIdentifier.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `InstrumentsResponse` | `src/UpvestInvestmentApi/Models/InstrumentsResponse.cs` |
| `RetrieveInstrumentError` | `src/UpvestInvestmentApi/Errors/RetrieveInstrumentError.cs` |

