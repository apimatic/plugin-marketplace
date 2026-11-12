<!-- Generated file — do not edit; regenerated with the SDK. -->

# WebhookSubscriptions — operations

Accessor: `client.WebhookSubscriptions` · Source: `src/UpvestInvestmentApi/Api/WebhookSubscriptions.cs` · 7 operations

**Type sources**: the file declaring each type an operation names (`RawError` excluded — see sdk-map.md).

### CreateWebhook

- **Auth**: `options.OauthClientCredentials` (scopes: `webhooks:admin`)
- **Signature**: `CreateWebhook(CreateWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `Webhook`
- **Error**: `ApiException<CreateWebhookError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `CreateWebhookRequest` | `src/UpvestInvestmentApi/Requests/WebhookSubscriptions/CreateWebhookRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `WebhookCreateRequest` | `src/UpvestInvestmentApi/Models/WebhookCreateRequest.cs` |
| `Webhook` | `src/UpvestInvestmentApi/Models/Webhook.cs` |
| `CreateWebhookError` | `src/UpvestInvestmentApi/Errors/CreateWebhookError.cs` |

### DeleteWebhook

- **Auth**: `options.OauthClientCredentials` (scopes: `webhooks:admin`)
- **Signature**: `DeleteWebhook(DeleteWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WebhookId`
- **Returns**: `void` (Task)
- **Error**: `ApiException<DeleteWebhookError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `DeleteWebhookRequest` | `src/UpvestInvestmentApi/Requests/WebhookSubscriptions/DeleteWebhookRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `DeleteWebhookError` | `src/UpvestInvestmentApi/Errors/DeleteWebhookError.cs` |

### GetJwks

- **Auth**: `options.OauthClientCredentials` (scopes: `webhooks:read`, `webhooks:admin`)
- **Signature**: `GetJwks(GetJwksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Returns**: `AuthVerificationKeys`
- **Error**: `ApiException<GetJwksError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `GetJwksRequest` | `src/UpvestInvestmentApi/Requests/WebhookSubscriptions/GetJwksRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `AuthVerificationKeys` | `src/UpvestInvestmentApi/Models/AuthVerificationKeys.cs` |
| `GetJwksError` | `src/UpvestInvestmentApi/Errors/GetJwksError.cs` |

### ListWebhooks

- **Auth**: `options.OauthClientCredentials` (scopes: `webhooks:read`, `webhooks:admin`)
- **Signature**: `ListWebhooks(ListWebhooksRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
- **Query params (wire ← C#)**: `sort` ← `Sort`, `order` ← `Order`, `offset` ← `Offset`, `limit` ← `Limit`
- **Returns**: `WebhooksListResponse`
- **Error**: `ApiException<ListWebhooksError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `ListWebhooksRequest` | `src/UpvestInvestmentApi/Requests/WebhookSubscriptions/ListWebhooksRequest.cs` |
| `Sort` | `src/UpvestInvestmentApi/Models/Enums/Sort.cs` |
| `Order` | `src/UpvestInvestmentApi/Models/Enums/Order.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `WebhooksListResponse` | `src/UpvestInvestmentApi/Models/WebhooksListResponse.cs` |
| `ListWebhooksError` | `src/UpvestInvestmentApi/Errors/ListWebhooksError.cs` |

### RetrieveWebhook

- **Auth**: `options.OauthClientCredentials` (scopes: `webhooks:read`, `webhooks:admin`)
- **Signature**: `RetrieveWebhook(RetrieveWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WebhookId`
- **Returns**: `Webhook`
- **Error**: `ApiException<RetrieveWebhookError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `RetrieveWebhookRequest` | `src/UpvestInvestmentApi/Requests/WebhookSubscriptions/RetrieveWebhookRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `Webhook` | `src/UpvestInvestmentApi/Models/Webhook.cs` |
| `RetrieveWebhookError` | `src/UpvestInvestmentApi/Errors/RetrieveWebhookError.cs` |

### TestWebhook

- **Auth**: `options.OauthClientCredentials` (scopes: `webhooks:admin`)
- **Signature**: `TestWebhook(TestWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WebhookId`
- **Returns**: `WebhooksTestResponse`
- **Error**: `ApiException<TestWebhookError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `TestWebhookRequest` | `src/UpvestInvestmentApi/Requests/WebhookSubscriptions/TestWebhookRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `WebhooksTestResponse` | `src/UpvestInvestmentApi/Models/WebhooksTestResponse.cs` |
| `TestWebhookError` | `src/UpvestInvestmentApi/Errors/TestWebhookError.cs` |

### UpdateWebhook

- **Auth**: `options.OauthClientCredentials` (scopes: `webhooks:admin`)
- **Signature**: `UpdateWebhook(UpdateWebhookRequest request, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default)`
  - required: `WebhookId`
- **Returns**: `Webhook`
- **Error**: `ApiException<UpdateWebhookError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent([NotNullWhen(true)] out RawError? value)` [400, 401, 403, 404, 406, 429, 500, 503, 504] · `TryGetRawError([NotNullWhen(true)] out RawError? error)` [fallback]

| Type | Source |
| --- | --- |
| `UpdateWebhookRequest` | `src/UpvestInvestmentApi/Requests/WebhookSubscriptions/UpdateWebhookRequest.cs` |
| `UpvestApiVersion` | `src/UpvestInvestmentApi/Models/Enums/UpvestApiVersion.cs` |
| `WebhookUpdateRequest` | `src/UpvestInvestmentApi/Models/WebhookUpdateRequest.cs` |
| `Webhook` | `src/UpvestInvestmentApi/Models/Webhook.cs` |
| `UpdateWebhookError` | `src/UpvestInvestmentApi/Errors/UpdateWebhookError.cs` |

