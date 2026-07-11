# SubscriptionProducts — operations

Accessor: `client.SubscriptionProducts` · Source: `Api/SubscriptionProducts.cs` · 2 operations

### MigrateSubscriptionProduct
- **HTTP**: `POST /subscriptions/{subscription_id}/migrations.json` (Production)
- **Signature**: `MigrateSubscriptionProduct(int subscriptionId, SubscriptionProductMigrationRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionResponse`
- **Error**: `SdkException<MigrateSubscriptionProductError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### PreviewSubscriptionProductMigration
- **HTTP**: `POST /subscriptions/{subscription_id}/migrations/preview.json` (Production)
- **Signature**: `PreviewSubscriptionProductMigration(int subscriptionId, SubscriptionMigrationPreviewRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SubscriptionMigrationPreviewResponse`
- **Error**: `SdkException<PreviewSubscriptionProductMigrationError>` — **Case A (typed)**
- **Error accessors**: `TryGetErrorListResponse1(out ErrorListResponse1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
