# APIMatic Plugin Marketplace

General-purpose AI models are trained on public code and documentation, much of it outdated. They have no awareness of an actual API version, latest SDKs or the recommended workflows.

APIMatic gives coding assistants deterministic, version-aware API context, generated directly from your API definition and SDKs. Instead of scraping public documentation or guessing from memory, the AI is grounded in the exact OpenAPI definition, current SDK versions, executable, idiomatic code samples, and recommended integration workflows.

This repository is a multi-plugin marketplace (`name: apimatic`) targeting **Claude Code, Cursor, VS Code and Codex**. It ships five plugins under `plugins/`, all registered in `.claude-plugin/marketplace.json` (mirrored in `.cursor-plugin/marketplace.json` — edit both):

| Plugin | Kind | Harness manifests |
| --- | --- | --- |
| `context-matic` | MCP, multi-API | Claude Code, Cursor, VS Code |
| `acp-paypal` | MCP, PayPal | Claude Code, Cursor, VS Code |
| `maxio-sdk` | skills + map, .NET | Claude Code, Cursor, Codex, VS Code |
| `paypal-sdk` | skills + map, .NET | Claude Code, Cursor, Codex, VS Code |
| `twilio-sdk` | skills + map, .NET | Claude Code, Cursor, Codex, VS Code |

The three SDK plugins ship to all four harnesses; the two MCP-backed plugins have no Codex manifest. An SDK plugin's four manifests all resolve to the same `skills/` directory — the VS Code one by convention, since its schema has no `skills` field — and nothing is duplicated per harness.

## Plugins

### context-matic

General-purpose, multi-API context plugin.

**MCP Server**

- `context-matic` — Get integration and implementation knowledge for third-party APIs.

**Skills**

- **integrate-context-matic** — Guidance for discovering and integrating third-party APIs using the context-matic MCP server.
- **onboard-context-matic** — Interactive onboarding tour: explains the MCP, lists available APIs, lets the user pick one to explore, demonstrates `model_search` and `endpoint_search` live, and provides a menu of suggested actions.

### acp-paypal

PayPal-focused plugin built on the same context engine.

**MCP Server**

- `acp-paypal-server-sdk-cs` — Get PayPal Server SDK (C#) integration and debugging knowledge: endpoints, models, auth, and error codes.

**Skills**

- **integrate-paypal** — Routes PayPal Server SDK tasks to the `paypal-plan` or `paypal-debug` subagent.

**Agents**

- **paypal-plan** — Read-only planner that produces a precise, SDK-contract-grounded PayPal integration plan before any code is written.
- **paypal-debug** — Diagnoses and fixes PayPal API issues in the current solution, verifying every change against the MCP server.

### maxio-sdk

Maxio Advanced Billing (formerly Chargify) **.NET SDK** plugin — no MCP server, no telemetry, C#/.NET
only. Its core feature is a bundled, generated **SDK map** (`skills/maxio-getting-started/sdk-map.md` +
`map/`): the coding agent answers every signature/model/enum/error question by map lookup, clones the SDK
source **only on first need** for a full body the map doesn't carry, and never greps the clone or opens the
SDK's `api-reference.md`.

The plugin is skills-only — there is no agent file (see *Why the SDK plugins have no agent file* below).
`integrate-maxio` is the workflow skill: it writes the plan file `maxio-plan.md` at the project root before
any project file is touched, fills its contract sheet from the map, implements from the sheet, and fixes SDK
compile/runtime errors map-first in place. `maxio-getting-started` owns the map. Ships Claude Code, Cursor,
Codex and VS Code manifests, all pointing at the same `skills/` directory.

**Skills**

- **integrate-maxio** — workflow: plan file → contract sheet → implement → fix map-first. Carries the hard
  gate (no project-file creation or edits until `maxio-plan.md` exists), the `maxio-plan.md` format, and the
  three-label rule for sheet rows.
- **maxio-getting-started** — SDK-specific entry point: identity, client construction, servers/auth, the
  SDK map, lookup hygiene ("keep lookups cheap"), and the contract-sheet workflow.
- Seven `dotnet-*` companions (`dotnet-client-initialization`, `dotnet-authentication`,
  `dotnet-calling-endpoints`, `dotnet-models`, `dotnet-error-handling`,
  `dotnet-configuration-resilience`, `dotnet-testing`) — usage guidance layered on the map.

The map's generated pages are never hand-edited — they are produced by the `sdk-map-generator` repo and
verified field-exact against the SDK source (github.com/asadali214/advanced-billing-sample-sdk, pinned per
map stamp).

> This plugin documents a **pre-4.0.0** generator surface (88 `Core/*.cs`), unlike `paypal-sdk` and
> `twilio-sdk` at 4.0.0 (122). That is the single most important thing to know before editing any of its
> `dotnet-*` skills — see the section below.

> `skills/dotnet/` is an empty directory skeleton — the folders exist locally but contain no files and
> nothing under it is tracked by git. It is not referenced by any manifest. Treat the top-level
> `skills/*` directories as the live ones, and delete the skeleton if it turns up in a working copy.

> Two earlier variants, `maxio-sdk-lean` (map shipped inside the SDK source) and the original two-agent
> `maxio-sdk` (separate `maxio-plan` / `maxio-debug`), were retired on `dev`; this plugin — formerly
> `maxio-sdk-merged` — took over the name.

### paypal-sdk

PayPal **.NET SDK** plugin — no MCP server, Claude Code + Cursor + Codex + VS Code, C#/.NET only,
skills-only. Bundled SDK map (`skills/paypal-getting-started/sdk-map.md` + `map/`) over
`github.com/asadali214/checkout-sample-sdk` at tag `v1.0.1` (40 operations, 5 controllers), plus the
`integrate-paypal` workflow skill (plan file → contract sheet → implement → fix map-first) and the seven
`dotnet-*` companions; `paypal-getting-started` owns the map. The SDK is on nuget.org as
`AsadAli.Checkout.Sdk`; the clone is a read-only reference, never a build dependency.

(Do not install alongside `acp-paypal` — the `integrate-paypal` skill name collides.)

### twilio-sdk

Twilio **.NET SDK** plugin with the same skills-only shape, over
`github.com/context-plugins/twilio-csharp-sdk`: `integrate-twilio` is the workflow skill (plan file →
contract sheet → implement → fix map-first), `twilio-getting-started` owns the map, and the seven
`dotnet-*` companions layer usage guidance on it. Ships Claude Code, Cursor, Codex and VS Code manifests.

### Why the SDK plugins have no agent file

Until 2026-08-28 each SDK plugin shipped one `<p>-sdk` agent that did the planning and the fixing, and
`integrate-<p>` was a router that spawned it. The agent was the one artifact with a different carrier on
every harness — Markdown with frontmatter for Claude Code and Cursor, a duplicated TOML body for Codex,
nothing at all for VS Code because its `tools:` vocabulary was unverified — and it was the source of every
silent-load failure recorded in
`docs/cross-platform-agents.md`: a stale Codex copy, an untrusted-project `.codex/` layer that loads
nothing, a `tools:` list that would have given the agent the wrong capabilities without a word. Skills load identically
on all four harnesses. So the agent went, and its content moved — verbatim wherever the referent did not
change — into `integrate-<p>`.

What survives unchanged is the plan-first gate. It used to be a subagent boundary; it is a file gate now —
`<p>-plan.md` must exist at the project root, every section filled, before any project file is created or
edited. What is lost is the context boundary: the planner ran in its own context, so SDK facts could not
leak from the main agent's memory into the sheet. Without it, the three-label rule is what catches that
leakage — every contract-sheet row cites a map page, or is `UNVERIFIED`, or is `YOUR CALL — not in the
map`. A row carrying none of the three is a fact from memory, and exposing that is what the labels are for.

If a portable agent format emerges, the agent can come back — its content is all still in `integrate-<p>`.

## The `dotnet-*` companion skills are shared, but not uniform

Three plugins (`maxio-sdk`, `paypal-sdk`, `twilio-sdk`) each carry their own copy of the seven
`dotnet-*` skills, describing the emitted `Core/` of **two different generator versions**. Before editing
any `dotnet-*` skill, see the provenance stamp at the top of that file — it names the generator surface
the text was verified against. Copying a correction from one plugin to another without checking that
stamp will introduce a falsehood.

Measured: **21 copies, 14 distinct versions.** The paypal-sdk and twilio-sdk copies are **byte-identical
for all seven — deliberately**. They are API-portable: no API-definition-dependent fact is stated
unconditionally (error-shape mix, discriminators, key parameters and pagination strategies come from the
contract sheet / map at use time, and each file opens by saying so), which is what lets a plugin
generator ship them as verbatim static files for the 4.0.0 surface. Where the two APIs genuinely need
opposite advice — twilio's errors carry `ex.Error.StatusCode`, paypal's typed errors carry none — the
skill teaches both strategies and keys the choice on the operation's map row, instead of hardcoding
either. The maxio-sdk copies differ in all seven because they describe the pre-4.0.0 surface: that
difference is a surface fact, not drift.

The seven names are therefore **ambiguous at install time** only when a pairing includes `maxio-sdk`: a
bare `dotnet-error-handling` then names two different documents — one per generator surface — and
nothing announces which resolves.

Each plugin's getting-started skill now states this, and each `integrate-*` skill's plan format requires
the REQUIRED READING block to write skill names **plugin-qualified** (`paypal-sdk:dotnet-error-handling`)
— or, where the harness has no qualified form, to name the owning plugin in the same line.

### integrate-* and *-getting-started are rendered from templates

The two API-specific skills are generated: `templates/plugin/` holds their template forms
(frame + slots) with the per-API values in `values/{api}.json`. Since 2026-08-28 the frames are
**simplified to identity slots only** — API name, source-code and package details, the set
today's plugin generator can fill — with every other API-specific passage rewritten as static
frame text that points at the map. The richer hand-written per-API content the frames used to
carry is preserved verbatim in `docs/api-specific-skill-content.md` for later re-incorporation.
`python templates/plugin/render.py --check` proves the shipped copies match the templates (and
that the shipped pair's `dotnet-*` statics are byte-identical); a failing check means someone
edited a shipped copy directly — move the edit into the frame or the values file and re-render.
maxio-sdk is not a rendering target (pre-4.0.0 frame facts).

`templates/plugin-template/` is the generator's blueprint for FUTURE SDKs — a third, distinct
tree: its SDKs carry the map **inside the SDK source repo** in a new method-first shape (operation
pages + shapes read from the source files the map names, no model pages), and its `dotnet-*`
statics describe the **post-4.0.0 codegen-v2 surface** (124 `Core/*.cs`; hooks, kept unknown
fields, two-property RequestOptions), verified 2026-08-28 against the generator's emitted Petstore
sample. Its skills and statics are deliberately NOT interchangeable with the shipped pair's.

### The claims are executable — run them before you trust them

`tools/assert-c1/` turns the runtime claims these skills make into assertions and runs them against the
real SDKs in CI (`.github/workflows/assert-c1.yml`). **342 assertions across three fixtures**: paypal and
twilio at generator 4.0.0, and maxio at pre-4.0.0. Do not correct a `dotnet-*` runtime claim from reading
alone — add or run the assertion, because ten false claims shipped in five plugins for months precisely
because they read plausibly.

The maxio fixture is the one that makes the surface split real. 100 of the general assertions cannot hold
on pre-4.0.0; they are baselined in `maxio-pre-4.0.0-drift.txt`, so the job goes red when that delta
**changes**, and the 14 pre-4.0.0-only assertions in `assertions/15-pre-4.0.0.json` cover the claims
maxio's own skills make instead. Some of them are the exact inverse of the 4.0.0 claim — on pre-4.0.0 the
retry method filter gates only the status arm, so **writes are resent on transport faults**, and
`RawClient` catches nothing, so the SDK's own timeout escapes as `TimeoutRejectedException`. That is what
"do not copy runtime claims across a core-surface boundary" means in practice.

Assertions marked `run-verified` were settled by executing the SDK, not by reading it. Reach for that when
the source is ambiguous — it is how the `TimeoutRejectedException` hole was found.

The post-4.0.0 codegen-v2 surface (the generator's StaticCode, and its emitted sample SDKs) fails
**19** of the general assertions by construction — the 15 Core-side ids in
`generator-template-drift.txt` plus 4 that need generated code. That delta is the exact boundary
between the shipped pair's skills (4.0.0) and the blueprint's (`templates/plugin-template/`,
post-4.0.0): a different delta means the generator moved again.

## Per-IDE manifest convention

MCP-backed plugins carry one manifest per IDE, and each manifest points at its own MCP config file so it can send an IDE-specific `X-Apimatic-Mcp-Client` telemetry header:

- Claude Code: `.claude-plugin/plugin.json` → `.claude-mcp.json` (header `ClaudeCode`)
- Cursor: `.cursor-plugin/plugin.json` → `.cursor-mcp.json` (header `Cursor`)
- VS Code: root `plugin.json` (Copilot format) → `.mcp.json` (header `VSCode`)

(The three SDK plugins are the exception: they have no MCP server, so their manifests point at no MCP
config. All three of `maxio-sdk`, `paypal-sdk` and `twilio-sdk` ship Claude Code, Cursor, Codex
(`.codex-plugin/plugin.json`) and VS Code manifests — four manifests over one `skills/` directory. Their
VS Code manifest is the Agent Plugins 1.0 form, not the Copilot format; see below.)

### VS Code

The SDK plugins ship a root `plugin.json` in Agent Plugins 1.0 form. The reason they held back is gone: it
was the `tools:` frontmatter of the `.agent.md` — a VS Code-specific vocabulary (`search/codebase`,
`web/fetch`, `read/terminalLastCommand`, `edit`, …) the published docs do not enumerate, so a guessed list
would have handed the agent the wrong capabilities silently — and there is no agent file any more. Skills
declare no tools.

The schema (https://agent-plugins.org/schemas/1.0.0/plugin.schema.json, JSON Schema 2020-12; VS Code's
loading rules at https://code.visualstudio.com/docs/agent-customization/agent-plugins) is **closed** —
`additionalProperties: false` — and requires exactly two fields: `$schema`, a `const` of that URL, and
`name` (1–64 chars, `^(?!.*(?:--|\.\.))[a-z0-9](?:[a-z0-9.-]*[a-z0-9])?$`). The only other fields it
allows are `version`, `description`, `author` (a closed object of `name`/`email`/`url`), `homepage`,
`repository`, `license` (all strings), `keywords` (array of strings) and `extensions` (objects keyed by
reverse-domain namespace, to which the spec assigns no semantics). There is **no `skills` field and no
`agents` field**. Skills are discovered by convention: each immediate child directory of `skills/` holding
a file named exactly `SKILL.md` is one skill, and clients must not search deeper. MCP configuration, where
a plugin has any, lives in a sibling `mcp.json` in the 1.0 `mcp.schema.json` form — never inline in
`plugin.json`.

Our three manifests carry `$schema`, `name`, `version`, `description`, `author`, `homepage`, `repository`,
`license` and `keywords`, and nothing else; the values mirror `.claude-plugin/plugin.json`. Do not add
`skills`, `displayName` or `logo` to them — none is in the schema, a manifest that carries `$schema` is
checked against it, and the spec's rule for an unknown field is report-and-ignore at best, so the field
would do nothing while looking as if it did.

Note also that the two VS Code manifests that predate 1.0 (`context-matic`, `acp-paypal`) omit `$schema`.
VS Code and Copilot CLI detect a root `plugin.json` without `$schema` as the older Copilot format, and in
that format `skills` and `mcpServers` are documented component-path fields that are honoured — so those
plugins load, and their skills and MCP servers are found through those keys (an earlier version of this
note said discovery fell back to convention; it does not, in that format). `logo` and `displayName` are
unknown in both formats and do nothing. Opting them into 1.0 means adding `$schema`, dropping the four
non-schema fields, and renaming `.mcp.json` to `mcp.json` in the 1.0 form, since 1.0 discovers MCP config
by that filename only. Worth a conformance pass; out of scope here.
