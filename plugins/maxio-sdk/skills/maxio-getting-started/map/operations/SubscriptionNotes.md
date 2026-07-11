# SubscriptionNotes — operations

Accessor: `client.SubscriptionNotes` · Source: `Api/SubscriptionNotes.cs` · 5 operations

### CreateSubscriptionNote
- **HTTP**: `POST /subscriptions/{subscription_id}/notes.json` (Production)
- **Signature**: `CreateSubscriptionNote(int subscriptionId, UpdateSubscriptionNoteRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionNoteResponse`
- **Error**: `SdkException<CreateSubscriptionNoteError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSubscriptionNote
- **HTTP**: `DELETE /subscriptions/{subscription_id}/notes/{note_id}.json` (Production)
- **Signature**: `DeleteSubscriptionNote(int subscriptionId, int noteId, CancellationToken ct = default)`
- **Returns**: `void`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### ListSubscriptionNotes
- **HTTP**: `GET /subscriptions/{subscription_id}/notes.json` (Production)
- **Signature**: `ListSubscriptionNotes(int subscriptionId, int? page = 1, int? perPage = 20, CancellationToken ct = default)`
  - `page` = 1, `perPage` = 20 — optional
- **Returns**: `IReadOnlyList<SubscriptionNoteResponse>`
- **Error**: `SdkException<ListSubscriptionNotesError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### ReadSubscriptionNote
- **HTTP**: `GET /subscriptions/{subscription_id}/notes/{note_id}.json` (Production)
- **Signature**: `ReadSubscriptionNote(int subscriptionId, int noteId, CancellationToken ct = default)`
- **Returns**: `SubscriptionNoteResponse`
- **Error**: `SdkException<RawError>` — **Case B**
- **Error accessors**: `StatusCode` · `ReadAsString()` · `ReadAsJson<T>()` · `ReadAsBytes()`
- **No-throw variant**: absent
- **Pagination**: none

### UpdateSubscriptionNote
- **HTTP**: `PUT /subscriptions/{subscription_id}/notes/{note_id}.json` (Production)
- **Signature**: `UpdateSubscriptionNote(int subscriptionId, int noteId, UpdateSubscriptionNoteRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionNoteResponse`
- **Error**: `SdkException<UpdateSubscriptionNoteError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
