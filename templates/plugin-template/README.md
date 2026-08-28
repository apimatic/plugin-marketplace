# plugin-template — the generator's blueprint

A complete plugin skeleton for the code-generation engine to stamp out per API, for **future
generator-emitted SDKs**. It differs from `templates/plugin/` in one decision of record: here
**the SDK map lives inside the SDK source repo** (at `{{map.pathInSdkRepo}}/`), not bundled in
the plugin — the map and the SDK regenerate together in one repo, so they cannot drift apart.

```
skills/
  dotnet-*                          7 STATIC skills — copied verbatim per generator version
  (rendered per API:)
  integrate-{api}/SKILL.md          from integrate/SKILL.md.tmpl        (12+ slots)
  {api}-getting-started/SKILL.md    from getting-started/SKILL.md.tmpl  (19+ slots)
manifests/                          4 identity manifests (Claude Code, Cursor, Codex, VS Code 1.0)
values/example-api.json             the slot spec — every slot, with what fills it
```

## What the map move changes in the frames

Compared to `templates/plugin/` (which tracks the three *shipped* plugins, bundled-map era):

- **Acquisition inverts.** Obtaining the SDK source at the pinned ref is the *first* step of SDK
  work in a session — the map is inside it — and appears as the first parallel prerequisite in
  the integrate workflow. What stays a last resort is opening **full source files** beyond the
  map pages: the lookup hygiene (map page first, one named file on a real gap, never grep the
  tree) is unchanged.
- **New slot `{{map.pathInSdkRepo}}`** — where the generator emits the map inside the SDK repo.
  Pick one path and keep it stable; every map reference in both frames goes through it.
- **`sdk.cloneRef` must be a real pin** — a tag or a full commit SHA, never a branch. On
  2026-08-28 the twilio SDK's `main` was regenerated under the shipped plugin and CI went red
  within nine minutes; a generated plugin pins the ref its map was generated from, and the two
  move together.

## The statics are guarded, not just copied

`skills/dotnet-*` is the third copy of the static seven (shipped paypal-sdk and twilio-sdk are
the other two, byte-identical). `python templates/plugin/render.py --check` fails if this copy
drifts from the shipped set — when the statics change (a generator release, a correction), fix
the shipped pair first and re-copy here.

## What the generator computes vs. what it copies

- **Copies verbatim:** the seven statics, the manifest shapes (identity fields slotted).
- **Renders from slots:** everything in `values/example-api.json`. The identity slots come from
  the SDK build config; the map-example slots from the emitted map; the per-API prose slots
  (`description.triggers`, `readiness.row*`, the getting-started sections) are computed from the
  API definition — `templates/plugin/values/{paypal,twilio}.json` are worked examples of what
  each must contain.
- **Emits separately:** the map itself, into the SDK repo at `{{map.pathInSdkRepo}}/`.

The acceptance test for a generated plugin is `tools/assert-c1/` run against its own emitted
SDK: a generated plugin is correct iff every assertion defending its skill text passes there.
