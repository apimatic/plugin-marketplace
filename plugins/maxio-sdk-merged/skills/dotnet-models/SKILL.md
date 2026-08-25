---
name: dotnet-models
description: Working with models in an APIMatic-generated .NET SDK in C# — building request models, required members and nullability, enums, union/AnyOf accessors, and JSON wire names versus C# property names. Load before constructing request payloads or mapping SDK models onto your own domain types.
---

<!-- core-surface: APIMatic .NET generator pre-4.0.0 — the client sends no `X-APIMatic-Gen-Version` header.
     Confirmed 2026-08-25 against asadali214/advanced-billing-sample-sdk@v1.0.2: 88 Core/*.cs.
     This surface has NO LoggingOptions, NO RequestOptions, NO RetryOptions.Disabled(). Its retry predicate
     is `.Handle<HttpRequestException>()` OR `.HandleResult(status AND method)` — so transport faults retry
     on EVERY verb and only the status arm is method-gated; MaxRetries = 0 throws in Polly (the floor is 1);
     a retry-ineligible request runs on an EMPTY pipeline and so loses the per-attempt timeout; there is no
     Retry-After handling and no delay clamp.
     verified-this-file: not audited, and not scheduled - this plugin wraps a pre-4.0.0 test
     SDK and is not a generation target. Production plugins are generated at 4.0.0 or later; see
     the paypal-sdk / twilio-sdk copy of this file for the audited text.
     Sampled from one pre-4.0.0 SDK only; another pre-4.0.0 SDK may differ, so re-check before relying on
     this. The paypal-sdk / twilio-sdk copies of this file describe generator 4.0.0 — correct there, wrong
     here. Do NOT copy runtime claims across a core-surface boundary. -->

# Working with models in an APIMatic .NET SDK

Most request/response data are immutable `record`s built with object-initializers (covered in
`dotnet-calling-endpoints`). This skill covers the **non-obvious model shapes** that trip integrations up.
The patterns are generic across APIMatic .NET SDKs; take the real type names from the contract sheet (the
SDK helper agent grounds it from the SDK map/source) — never a decompiled or reflected view of the
installed package.

> Throughout this skill, `{...}` is a placeholder for a name you take from your SDK (e.g. `{Union}`,
> `{Variant}`, `{EnumType}`, `{RequestType}`) — replace it with the concrete identifier from the source.

## Polymorphic union types: `OneOf` and `AnyOf`

When a field can be one of several types, APIMatic generates a union `record` (under
`{RootNamespace}.Models.OneOf` or `.Models.AnyOf`). Build these with the generated **static factory
methods** (one per variant) and read them back with **`TryGet…` methods** — a union has no
object-initializer. JSON (de)serialization is automatic.

- `OneOf` — the value is exactly one variant (sometimes indicated by a discriminator field such as `type`).
- `AnyOf` — the value may match one of several primitive/shape variants.

### Construct

```csharp
// One static factory per variant: {Union}.{Variant}(value)
var u1 = {Union}.String("...");
var u2 = {Union}.{Variant}(new {Variant} { /* ... */ });

// AnyOf unions over primitives also expose implicit conversions:
{Union} u3 = "...";    // same as {Union}.String("...")
{Union} u4 = 10.50m;   // same as {Union}.Decimal(10.50m)
```

### Read / unwrap

```csharp
// Each variant has a bool TryGet{Variant}(out var value):
if (u1.TryGetString(out var s))        { /* use s (string)  */ }
else if (u1.TryGetDecimal(out var d))  { /* use d (decimal) */ }

// OneOf: branch over the variants you expect
if (resp.{Field}.TryGet{Variant}(out var v))           { /* ... */ }
else if (resp.{Field}.TryGet{OtherVariant}(out var w)) { /* ... */ }
```

The factory and `TryGet` names are built mechanically from the **variant's CLR type name**:

| Variant CLR type | Factory method | Reader |
| --- | --- | --- |
| `double` | `.Double(double)` | `TryGetDouble(out double)` |
| `decimal` | `.Decimal(decimal)` | `TryGetDecimal(out decimal)` |
| `string` | `.String(string)` | `TryGetString(out string)` |
| a model `{Variant}` | `.{Variant}({Variant})` | `TryGet{Variant}(out {Variant})` |
| a list of `{Variant}` | `.ListOf{Variant}(IReadOnlyList<{Variant}>)` | `TryGetListOf{Variant}(out IReadOnlyList<{Variant}>)` |

The exact CLR type varies per union — a numeric variant may be `double`, `decimal`, or `long` — so take the
real method name from the contract sheet (the SDK helper agent grounds it from the SDK map/source). (Unions use the per-variant
factories and `TryGet…` readers shown above; `FromValue` belongs to enums.) The `Optional<T>` backing a
union is internal — interact only through the
factories and `TryGet…`.

## Collections

List/array properties are `IReadOnlyList<T>?`; maps are `IReadOnlyDictionary<TKey, TValue>?`. Assign a
`List<>`/array/`Dictionary<>` directly (each implements the read-only interface), or use collection
expressions:

```csharp
var body = new {RequestType}
{
    {ListProp} = ["A", "B"],                                    // IReadOnlyList<string>
    {MapProp}  = new Dictionary<string, string> { ["k"] = "v" } // IReadOnlyDictionary<string,string>
};
```

A null collection is omitted from the JSON; an **empty** collection is serialized.

## Dates & numbers

- Date/time fields are `DateTimeOffset?`, serialized as ISO-8601 / RFC-3339 — work with `DateTimeOffset`
  and let the SDK handle the wire format. For manual formatting/parsing use the BCL (`DateTimeOffset.Parse`,
  `.ToString("O")`); the SDK's date handling is internal.
- Money/quantities may be `string`, `decimal`, or a string-or-number `AnyOf` union; the model's property
  type is the source of truth. Numeric types vary per SDK (`int`, `long`, `double`, …) — take the exact
  type from the contract sheet; don't assume `double`.

## Enums

Enums are type-safe string-enums (`StringEnum<T>`) or int-enums (`IntEnum<T>`): use the static constants,
or `FromValue(...)` for a value not known at compile time; they convert implicitly to their underlying
value. Reading back: `.Value` (equivalently `ToString()` or the implicit conversion) yields the raw wire
value, and the enum types are `record`s, so `==` compares by value — `{EnumType}.FromValue("x")` equals the
`x` constant. Guard unknown values with `TryGetKnownValue(...)` or `instance.IsKnownValue()`.

⚠ **`FromValue` is emitted per enum, not guaranteed on all of them.** Some generated enums — server /
environment selectors are the ones to watch — expose only their static constants and keep the conversion
helper `protected`, so `{EnumType}.FromValue(someString)` does not compile. Check the type before you plan
to map a configuration string through it; where it is absent, write the string→constant mapping yourself
and default deliberately rather than reaching for a helper that isn't there.

```csharp
{request}.{EnumProp} = {EnumType}.SomeConstant;
{request}.{EnumProp} = {EnumType}.FromValue(serverProvidedValue);   // tolerates unknown values
string wire = {response}.{EnumProp}.Value;                          // raw wire value back out
if ({EnumType}.TryGetKnownValue(value, out var known)) { /* known constant */ }
```

See [reference.md](reference.md) for full string- and int-enum declarations and union-member discovery.

## Unknown / future fields

Models declare their properties explicitly. Whether unknown JSON fields are kept depends on the SDK:
APIMatic can generate an additional-properties map that captures them, but where a model has none — the
common case — unknown fields are dropped on deserialization. Check the model; to read an unmodeled field,
regenerate the SDK or parse that response yourself.
