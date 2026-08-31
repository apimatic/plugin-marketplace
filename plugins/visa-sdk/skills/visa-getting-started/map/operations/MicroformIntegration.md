# MicroformIntegration — operations

Accessor: `client.MicroformIntegration` · Source: `Api/MicroformIntegration.cs` · 1 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### GenerateCaptureContext
- **HTTP**: `POST /microform/v2/sessions` (Default (apitest))
- **Signature**: `GenerateCaptureContext(GenerateCaptureContextRequest generateCaptureContextRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?`
- **No-throw variant**: absent
- **Pagination**: none
