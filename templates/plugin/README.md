# Plugin skill templates

Template forms of the two heavily API-specific skills, extracted for the plugin generator:

| Template | Renders to | Slots |
| --- | --- | --- |
| `integrate/SKILL.md.tmpl` | `plugins/{api}-sdk/skills/integrate-{api}/SKILL.md` | 12 |
| `getting-started/SKILL.md.tmpl` | `plugins/{api}-sdk/skills/{api}-getting-started/SKILL.md` | 19 |

The other seven skills a plugin ships (`dotnet-*`) are **static files** — byte-identical across
paypal-sdk and twilio-sdk, API-portable by design, and copied verbatim per generator version. See
CLAUDE.md, *The `dotnet-*` companion skills*.

## How these were extracted, and what that proves

The paypal-sdk and twilio-sdk copies share generator surface 4.0.0, so **every difference between
the two copies is, by definition, API content** — that difference became the slot list, and the
shared remainder became the frame (twilio's copy, whose post-migration wording was the cleaner,
plus four deliberate frame edits picked from whichever copy said it better). The shipped skills in
this repo are **rendered from these templates** — run

```
python templates/plugin/render.py --check
```

to prove it (CI-able). A failing check means a shipped copy was edited directly: move the edit
into the template (frame text) or into `values/{api}.json` (API content) and re-render, or the
copies drift apart again.

## Slot vocabulary

**Identity** — `api.name` (PayPal), `api.id` (paypal), `sdk.rootNamespace` (PayPalServerSdk),
`sdk.package` (AsadAli.Checkout.Sdk), `sdk.repoUrl`, `sdk.cloneRef` (v1.0.1), plus row-level
slots for the identity table (`sdk.nugetRow`, `sdk.sourceRepoRow`, `sdk.authRow`, `sdk.envRow`)
and `sdk.cloneRefPhrase` (the human explanation of the pinned ref).

**Map examples** — `map.exampleApiFile`, `map.exampleErrorFile`, `map.exampleModelFile`,
`plan.sourceExample`: real file/page names from the API's own map, used wherever the frame shows
an "e.g.".

**Per-API prose** — `description.triggers` (the task phrasings that route the skill),
`readiness.row1/2/5/6/7/8` + `readiness.irrecoverable` (the PRODUCTION READINESS decisions that
vary by API; rows 3 and 4 are surface facts and live in the frame),
`workflow.idempotencyTrapLine`, and four whole-section slots in getting-started:
`sections.idempotency`, `sections.sensitiveData` (may be empty), `sections.responseMetadata`,
`sections.nameCollision` (marketplace context — names the sibling plugins).

The values files carry the current shipped content for both APIs and double as worked examples of
what the generator must produce per section. The per-API prose slots are the ones the generator
ultimately computes from the API definition; until then they are authored, and the three-label /
map-grounding rules in the frame are what keep authored values honest.

## Two things to know before rendering a third API

- **maxio-sdk is not a rendering target.** Its SDK is the pre-4.0.0 generator surface, and these
  frames state 4.0.0 facts (the readiness rows' retry and timeout numbers, the injected
  Idempotency-Key mechanics). A pre-4.0.0
  frame would be a separate extraction.
- **These frames describe the bundled-map era** — today's shipped plugins, whose SDK repos
  carry no map. The generator's blueprint for FUTURE SDKs, where the map lives inside the SDK
  source repo, is `templates/plugin-template/` — same slot vocabulary plus
  `{{map.pathInSdkRepo}}`, with the *SDK map* / *SDK source* sections already inverted (obtain
  the source first; the map is inside it). Frame improvements made here should be considered
  for the blueprint too, and vice versa.
