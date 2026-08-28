# plugin-template — the generator's blueprint

A complete plugin skeleton for the code-generation engine to stamp out per API, for **future
generator-emitted SDKs**. Two decisions of record shape it:

- **The SDK map lives inside the SDK source repo** (at `{{map.pathInSdkRepo}}/`), not bundled in
  the plugin — the map and the SDK regenerate together in one repo, so they cannot drift apart.
- **Eight slots, nothing else.** Today's generator can templatize API identity, source-code and
  package details only, so every other API-specific passage is written as static text that is
  true for any 4.0.0-generated SDK: generator-static facts are stated sharply (the injected
  `Idempotency-Key` header, the logging env-var arming, headers-never-reachable — all backed by
  `tools/assert-c1/` assertions), and every API-dependent fact is an instruction to read it off
  the map ("the operation's map row", "the map's *Servers & auth* section").

```
skills/
  dotnet-*                          7 STATIC skills — copied verbatim per generator version
  (rendered per API:)
  integrate-{api}/SKILL.md          from integrate/SKILL.md.tmpl
  {api}-getting-started/SKILL.md    from getting-started/SKILL.md.tmpl
manifests/                          4 identity manifests (Claude Code, Cursor, Codex, VS Code 1.0)
values/example-api.json             the slot spec — all 8 slots, with what fills each
```

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
  per-API facts from the definition, `templates/plugin/values/{paypal,twilio}.json` are worked
  examples of the sharper content each section can then carry.

## Guardrails

- `skills/dotnet-*` is the third copy of the static seven (shipped paypal-sdk and twilio-sdk are
  the other two). `python templates/plugin/render.py --check` fails if any of the three drifts.
- `templates/plugin/` is the sibling extraction that **renders the two shipped hand-crafted
  plugins** (paypal-sdk and twilio-sdk; maxio-sdk is pre-4.0.0 and is neither rendered there nor
  a target here). Its frames carry per-API slots this blueprint deliberately does not; frame
  improvements should be considered for both trees.
- The acceptance test for a generated plugin is `tools/assert-c1/` run against its own emitted
  SDK: every generator-static claim the skills make must pass there. (It cannot vouch for the
  API-specific content — in this blueprint there deliberately is none beyond the 8 identity
  slots.)
