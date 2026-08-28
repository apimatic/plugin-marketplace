# Plugin skill templates

Template forms of the two API-specific skills, matching what the plugin generator can produce
today:

| Template | Renders to | Slots |
| --- | --- | --- |
| `integrate/SKILL.md.tmpl` | `plugins/{api}-sdk/skills/integrate-{api}/SKILL.md` | identity only |
| `getting-started/SKILL.md.tmpl` | `plugins/{api}-sdk/skills/{api}-getting-started/SKILL.md` | identity only |

The other seven skills a plugin ships (`dotnet-*`) are **static files** — byte-identical across
paypal-sdk and twilio-sdk, API-portable by design, and copied verbatim per generator version. See
CLAUDE.md, *The `dotnet-*` companion skills*.

## Simplified on 2026-08-28 — identity slots only

Today's generator can templatize **API name, source-code and package details only**, so the frames
were simplified to exactly that slot set (`values/{api}.json`):

`api.name` · `api.id` · `sdk.rootNamespace` · `sdk.package` · `sdk.repoUrl` · `sdk.cloneRef` ·
`sdk.envLogVar`

Every other API-specific passage became **static frame text**: generator-static facts stated
sharply, API-dependent facts pointed at the map ("the operation's map row", "the map's *Servers &
auth* section"). The **richer hand-written per-API content** the frames used to carry — real
readiness rows, per-API idempotency/sensitive-data/response-metadata sections, trigger lists, map
examples — is preserved verbatim in **`docs/api-specific-skill-content.md`**, one entry per
removed slot, for re-incorporation when the generator learns to compute per-API facts from the
API definition. The pre-simplification frames are in git history.

## How the extraction worked, and what `--check` proves

The paypal-sdk and twilio-sdk copies share generator surface 4.0.0, so every difference between
the two copies was, by definition, API content — that was the original slot list, since narrowed
to identity. The shipped skills in this repo are **rendered from these templates** — run

```
python templates/plugin/render.py --check
```

to prove it (CI-able). It also proves the shipped pair's `dotnet-*` statics are byte-identical to
each other. A failing check means a shipped copy was edited directly: move the edit into the
template (frame text) or into `values/{api}.json` (identity), and re-render.

## Two things to know before rendering a third API

- **maxio-sdk is not a rendering target.** Its SDK is the pre-4.0.0 generator surface, and these
  frames state 4.0.0 facts (the readiness rows' retry and timeout numbers, the injected
  Idempotency-Key mechanics). A pre-4.0.0 frame would be a separate extraction.
- **These frames describe the bundled-map era** — today's shipped plugins, whose SDK repos carry
  no map, so the map (old shape: operations pages *plus* model/enum/union pages) ships inside
  each plugin's `{api}-getting-started/`. The generator's blueprint for FUTURE SDKs is
  `templates/plugin-template/` — there the map lives **inside the SDK source repo** in its new,
  method-first shape (operations pages + shapes read from the source files the map names), and
  the statics describe the **post-4.0.0 codegen-v2 surface**, so the blueprint's skills are NOT
  interchangeable with these. Frame improvements made here should be considered for the blueprint
  too, and vice versa.
