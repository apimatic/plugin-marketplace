# plugin-template — the generator's blueprint

A complete plugin skeleton for the code-generation engine to stamp out per API, for **future
generator-emitted SDKs**. Three decisions of record shape it:

- **The SDK map lives inside the SDK source repo** — `sdk-map.md` at the SDK root (the directory
  holding the `.csproj`; `{{map.pathInSdkRepo}}/` within the repo) plus `map/operations/`. The map
  and the SDK regenerate together in one repo, so they cannot drift apart.
- **The map is method-first.** Operation contracts (signatures, error cases and accessors,
  pagination, servers/auth) are on its pages by lookup; model, enum and error **shapes are
  deliberately not duplicated there** — every file under `Models/` and `Errors/` declares one
  public type named after the file, the operations pages carry **Type sources** tables, and the
  skills teach reading shapes from the one declaring file the map names. Verified against the
  generator's emitted Swagger Petstore sample SDK, 2026-08-28.
- **Eight slots, nothing else.** Today's generator can templatize API identity, source-code and
  package details only, so every other API-specific passage is written as static text that is
  true for any SDK this generator emits: generator-static facts are stated sharply (the injected
  `Idempotency-Key` header, the logging env-var arming, hooks — backed by `tools/assert-c1/`
  assertions), and every API-dependent fact is an instruction to read it off the map or the file
  the map names.

```
skills/
  dotnet-*                          7 STATIC skills — post-4.0.0 codegen-v2 surface (124 Core/*.cs)
  (rendered per API:)
  integrate-{api}/SKILL.md          from integrate/SKILL.md.tmpl
  {api}-getting-started/SKILL.md    from getting-started/SKILL.md.tmpl
manifests/                          4 identity manifests (Claude Code, Cursor, Codex, VS Code 1.0)
values/example-api.json             the slot spec — all 8 slots, with what fills each
```

## The statics describe the post-4.0.0 surface — not the shipped pair's 4.0.0

The `skills/dotnet-*` here were re-verified 2026-08-28 against the generator's emitted Petstore
sample (the surface this blueprint's plugins will ship with): 342 assert-c1 assertions ran, 295
passed, and the 19 failures — the surface delta (15 ids match `tools/assert-c1/
generator-template-drift.txt`, plus 4 generated-code-side) — were each examined in source; every
skill claim they touch was corrected. Headline moves: `RequestOptions` is `LogLevel?` + `Hooks`;
client-wide and per-call **hooks** (`SdkHook`, once per attempt) are the supported transport-
metadata seam; **unknown JSON fields are kept** in every model's `[JsonExtensionData]
AdditionalProperties`; binary-body retry eligibility relaxed to content-present-only; typed
`{Operation}Error` classes live under `Errors/`. The wire header still reads
`X-APIMatic-Gen-Version: 4.0.0` — identify the surface by census (124 `Core/*.cs`,
`Core/Hooks/SdkHook.cs` present), never by that string.

Because of this, the blueprint statics are **deliberately different** from the shipped
paypal-sdk/twilio-sdk statics (4.0.0) — `render.py --check` no longer compares them; it checks
the shipped pair against each other instead.

## The 8 slots

`api.name` · `api.id` · `sdk.rootNamespace` · `sdk.package` · `sdk.repoUrl` · `sdk.cloneRef` ·
`sdk.envLogVar` · `map.pathInSdkRepo` — see `values/example-api.json` for what each holds.
Everything a manifest needs is derived from these by frame formulas (displayName, description,
keywords), so the manifests need no extra inputs. Two rules learned the hard way:

- **`sdk.cloneRef` must be a real pin** — a tag or a full commit SHA, never a branch. On
  2026-08-28 the twilio SDK's `main` was regenerated under the shipped plugin and CI went red
  within nine minutes. The map documents a ref; the plugin pins that ref; they move together.
- **Never add per-API counts, provider names or accessor censuses to the static text.** That is
  what drifted the hand-written copies apart, twice. When the generator later learns to compute
  per-API facts from the definition, `docs/api-specific-skill-content.md` preserves the richer
  hand-written per-API content (readiness rows, idempotency/sensitive-data/response-metadata
  sections) each section can then carry again.

## Guardrails

- `templates/plugin/` is the sibling extraction that **renders the two shipped hand-crafted
  plugins** (paypal-sdk and twilio-sdk — bundled old-shape maps, 4.0.0 statics; maxio-sdk is
  pre-4.0.0 and belongs to neither tree). Its frames and this blueprint's share intent but not
  facts; improvements should be considered for both, checked against each side's surface.
- The acceptance test for a generated plugin is `tools/assert-c1/` run against its own emitted
  SDK. Note the general assertion set still encodes some 4.0.0 shapes: against a post-4.0.0 SDK,
  expect the 19-assertion delta this README describes (compare with
  `generator-template-drift.txt`) — a different delta means the generator moved again and these
  skills need a re-verification pass.
