# MerchantDefinedFields — operations

Accessor: `client.MerchantDefinedFields` · Source: `Api/MerchantDefinedFields.cs` · 4 operations

**Parameter names are literal.** Signatures are generated code verbatim — in named arguments use the exact parameter names shown (the cancellation-token parameter is named `ct`).

### CreateMerchantDefinedFieldDefinition
- **HTTP**: `POST /invoicing/v2/{referenceType}/merchantDefinedFields` (Default (apitest))
- **Signature**: `CreateMerchantDefinedFieldDefinition(ReferenceType referenceType, MerchantDefinedFieldDefinitionRequest merchantDefinedFieldDefinitionRequest, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `IReadOnlyList<CreateMerchantDefinedFieldDefinitionResponse>`
- **Error**: `SdkException<CreateMerchantDefinedFieldDefinitionError>` — **Case A (typed)**
- **Error accessors**: `TryGetCreateMerchantDefinedFieldDefinitionException1(out CreateMerchantDefinedFieldDefinitionException1)` [400, 409, 412] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteMerchantDefinedFieldsDefinitions
- **HTTP**: `DELETE /invoicing/v2/{referenceType}/merchantDefinedFields/{id}` (Default (apitest))
- **Signature**: `DeleteMerchantDefinedFieldsDefinitions(ReferenceType referenceType, long id, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode: HttpStatusCode` · `ReadAsBytes(): ReadOnlyMemory<byte>` · `ReadAsString(): string` · `ReadAsJson<T>(): T?`
- **No-throw variant**: absent
- **Pagination**: none

### GetMerchantDefinedFieldsDefinitions
- **HTTP**: `GET /invoicing/v2/{referenceType}/merchantDefinedFields` (Default (apitest))
- **Signature**: `GetMerchantDefinedFieldsDefinitions(ReferenceType referenceType, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `IReadOnlyList<GetMerchantDefinedFieldsDefinitionsResponse>`
- **Error**: `SdkException<GetMerchantDefinedFieldsDefinitionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetGetMerchantDefinedFieldsDefinitionsException1(out GetMerchantDefinedFieldsDefinitionsException1)` [404] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PutMerchantDefinedFieldsDefinitions
- **HTTP**: `PUT /invoicing/v2/{referenceType}/merchantDefinedFields/{id}` (Default (apitest))
- **Signature**: `PutMerchantDefinedFieldsDefinitions(ReferenceType referenceType, long id, MerchantDefinedFieldCore merchantDefinedFieldCore, RequestOptions? requestOptions = null, CancellationToken ct = default)`
  - defaults: `requestOptions` = null
- **Returns**: `void` (Task)
- **Error**: `SdkException<PutMerchantDefinedFieldsDefinitionsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [400, 409] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
