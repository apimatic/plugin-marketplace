<!-- Generated file — do not edit; regenerated with the SDK. -->

# Reports — operations

Accessor: `client.Reports` · Source: `src/UpvestInvestmentApi/Api/Reports.cs` · 4 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateReport

- **Auth**: `options.OauthClientCredentials` (scopes: `reports:admin`)
- **Signature**: `CreateReport(CreateReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `ReportOrderExAnteCost`
- **Error**: `ApiException<CreateReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateReportRequest` | `src/UpvestInvestmentApi/Requests/Reports/CreateReportRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `ReportOrderExAnteCostCreateRequest` | `src/UpvestInvestmentApi/Models/AnyOf/ReportOrderExAnteCostCreateRequest.cs` |
| `ReportOrderExAnteCost` | `src/UpvestInvestmentApi/Models/AnyOf/ReportOrderExAnteCost.cs` |
| `CreateReportError` | `src/UpvestInvestmentApi/Errors/CreateReportError.cs` |

### ListBusinessReports

- **Auth**: `options.OauthClientCredentials` (scopes: `reports:read`, `reports:admin`)
- **Signature**: `ListBusinessReports(ListBusinessReportsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `BusinessId`
- **Query params (wire ← C#)**: `type` ← `Type`, `instrument` ← `Instrument`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `BusinessReportsListResponse`
- **Error**: `ApiException<ListBusinessReportsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListBusinessReportsRequest` | `src/UpvestInvestmentApi/Requests/Reports/ListBusinessReportsRequest.cs` |
| `ReportType` | `src/UpvestInvestmentApi/Models/Enums/ReportType.cs` |
| `Instrument2Model` | `src/UpvestInvestmentApi/Models/AnyOf/Instrument2Model.cs` |
| `Sort4` | `src/UpvestInvestmentApi/Models/Enums/Sort4.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `BusinessReportsListResponse` | `src/UpvestInvestmentApi/Models/BusinessReportsListResponse.cs` |
| `ListBusinessReportsError` | `src/UpvestInvestmentApi/Errors/ListBusinessReportsError.cs` |

### ListUserReports

- **Auth**: `options.OauthClientCredentials` (scopes: `reports:read`, `reports:admin`)
- **Signature**: `ListUserReports(ListUserReportsRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `UserId`
- **Query params (wire ← C#)**: `type` ← `Type`, `instrument` ← `Instrument`, `start_date` ← `StartDate`, `end_date` ← `EndDate`, `sort` ← `Sort`, `order` ← `Order`, `limit` ← `Limit`, `offset` ← `Offset`
- **Returns**: `ReportsListResponse`
- **Error**: `ApiException<ListUserReportsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListUserReportsRequest` | `src/UpvestInvestmentApi/Requests/Reports/ListUserReportsRequest.cs` |
| `ReportType` | `src/UpvestInvestmentApi/Models/Enums/ReportType.cs` |
| `Instrument2Model` | `src/UpvestInvestmentApi/Models/AnyOf/Instrument2Model.cs` |
| `Sort23` | `src/UpvestInvestmentApi/Models/Enums/Sort23.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `ReportsListResponse` | `src/UpvestInvestmentApi/Models/ReportsListResponse.cs` |
| `ListUserReportsError` | `src/UpvestInvestmentApi/Errors/ListUserReportsError.cs` |

### RetrieveReport

- **Auth**: `options.OauthClientCredentials` (scopes: `reports:read`, `reports:admin`)
- **Signature**: `RetrieveReport(RetrieveReportRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `ReportId`
- **Returns**: `Report`
- **Error**: `ApiException<RetrieveReportError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveReportRequest` | `src/UpvestInvestmentApi/Requests/Reports/RetrieveReportRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `Accept` | `src/UpvestInvestmentApi/Models/Enums/Accept.cs` |
| `Report` | `src/UpvestInvestmentApi/Models/AnyOf/Report.cs` |
| `RetrieveReportError` | `src/UpvestInvestmentApi/Errors/RetrieveReportError.cs` |

