# EventsBasedBillingSegments — operations

Accessor: `client.EventsBasedBillingSegments` · Source: `Api/EventsBasedBillingSegments.cs` · 6 operations

### BulkCreateSegments
- **HTTP**: `POST /components/{component_id}/price_points/{price_point_id}/segments/bulk.json` (Production)
- **Signature**: `BulkCreateSegments(string componentId, string pricePointId, BulkCreateSegments? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ListSegmentsResponse`
- **Error**: `SdkException<BulkCreateSegmentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetEventBasedBillingSegment1(out EventBasedBillingSegment1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### BulkUpdateSegments
- **HTTP**: `PUT /components/{component_id}/price_points/{price_point_id}/segments/bulk.json` (Production)
- **Signature**: `BulkUpdateSegments(string componentId, string pricePointId, BulkUpdateSegments? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `ListSegmentsResponse`
- **Error**: `SdkException<BulkUpdateSegmentsError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetEventBasedBillingSegment1(out EventBasedBillingSegment1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### CreateSegment
- **HTTP**: `POST /components/{component_id}/price_points/{price_point_id}/segments.json` (Production)
- **Signature**: `CreateSegment(string componentId, string pricePointId, CreateSegmentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SegmentResponse`
- **Error**: `SdkException<CreateSegmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetEventBasedBillingSegmentErrors1(out EventBasedBillingSegmentErrors1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### DeleteSegment
- **HTTP**: `DELETE /components/{component_id}/price_points/{price_point_id}/segments/{id}.json` (Production)
- **Signature**: `DeleteSegment(string componentId, string pricePointId, double id, CancellationToken ct = default)`
- **Returns**: `void`
- **Error**: `SdkException<DeleteSegmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404, 422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none

### ListSegmentsForPricePoint
- **HTTP**: `GET /components/{component_id}/price_points/{price_point_id}/segments.json` (Production)
- **Signature**: `ListSegmentsForPricePoint(string componentId, string pricePointId, ListSegmentsFilter? filter, int? page = 1, int? perPage = 30, CancellationToken ct = default)`
  - `filter` — nullable, no default → **must pass explicitly**
- **Returns**: `ListSegmentsResponse`
- **Error**: `SdkException<ListSegmentsForPricePointError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetEventBasedBillingListSegmentsErrors1(out EventBasedBillingListSegmentsErrors1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: manual `page`+`perPage`

### UpdateSegment
- **HTTP**: `PUT /components/{component_id}/price_points/{price_point_id}/segments/{id}.json` (Production)
- **Signature**: `UpdateSegment(string componentId, string pricePointId, double id, UpdateSegmentRequest? body, CancellationToken ct = default)`
  - `body` — nullable, no default → **must pass explicitly**
- **Returns**: `SegmentResponse`
- **Error**: `SdkException<UpdateSegmentError>` — **Case A (typed)**
- **Error accessors**: `TryGetNoContent(out RawError)` [404] · `TryGetEventBasedBillingSegmentErrors1(out EventBasedBillingSegmentErrors1)` [422] · `TryGetRawError(out RawError)` [fallback]
- **No-throw variant**: absent
- **Pagination**: none
