<!-- Generated file — do not edit; regenerated with the SDK. -->

# Files — operations

Accessor: `client.Files` · Source: `src/UpvestInvestmentApi/Api/Files.cs` · 1 operation

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### FetchingFileMetadata

- **Auth**: `options.OauthClientCredentials` (scopes: `files:read`)
- **Signature**: `FetchingFileMetadata(FetchingFileMetadataRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `Folder`, `FileName`
- **Query params (wire ← C#)**: `redirect` ← `Redirect`
- **Returns**: `FilesMetadata`
- **Error**: `ApiException<FetchingFileMetadataError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `FetchingFileMetadataRequest` | `src/UpvestInvestmentApi/Requests/Files/FetchingFileMetadataRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `FilesMetadata` | `src/UpvestInvestmentApi/Models/FilesMetadata.cs` |
| `FetchingFileMetadataError` | `src/UpvestInvestmentApi/Errors/FetchingFileMetadataError.cs` |

