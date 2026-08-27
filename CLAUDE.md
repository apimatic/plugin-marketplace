# APIMatic Plugin Marketplace

General-purpose AI models are trained on public code and documentation, much of it outdated. They have no awareness of an actual API version, latest SDKs or the recommended workflows.

APIMatic gives coding assistants deterministic, version-aware API context, generated directly from your API definition and SDKs. Instead of scraping public documentation or guessing from memory, the AI is grounded in the exact OpenAPI definition, current SDK versions, executable, idiomatic code samples, and recommended integration workflows.

This repository is a multi-plugin marketplace (`name: apimatic`) targeting **Claude Code, Cursor, VS Code and Codex**. It ships seven plugins under `plugins/`, all registered in `.claude-plugin/marketplace.json`:

| Plugin | Kind | Harness manifests |
| --- | --- | --- |
| `context-matic` | MCP, multi-API | Claude Code, Cursor, VS Code |
| `acp-paypal` | MCP, PayPal | Claude Code, Cursor, VS Code |
| `maxio-sdk` | skills + map, .NET | Claude Code |
| `maxio-sdk-merged` | skills + map, .NET | Claude Code, Cursor, Codex |
| `maxio-sdk-lean` | skills + map-in-SDK, .NET | Claude Code |
| `paypal-sdk` | skills + map, .NET | Claude Code, Cursor, Codex |
| `twilio-sdk` | skills + map, .NET | Claude Code, Cursor, Codex |

No plugin currently ships to all four harnesses.

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

Maxio Advanced Billing (formerly Chargify) **.NET SDK** plugin — no MCP server, no telemetry,
Claude Code only, C#/.NET only. Its core feature is a bundled, generated **SDK map**
(`skills/maxio-getting-started/sdk-map.md` + `map/`) plus a subagent orchestration layer: the agent
answers every signature/model/enum/error question by map lookup, clones the SDK source **only on
first need** for a full body the map doesn't carry, and never greps the clone or opens the SDK's
`api-reference.md`.

**Skills**

- **integrate-maxio** — orchestrator/router: routes a Maxio .NET SDK task to the `maxio-plan` or
  `maxio-debug` agent, handles blocker hand-back, and drives the implement-and-verify loop.
- **maxio-getting-started** — SDK-specific entry point: identity, client construction, servers/auth,
  the SDK map, lookup hygiene ("keep lookups cheap"), and the contract-sheet workflow.
- Seven `dotnet-*` companions (`dotnet-client-initialization`, `dotnet-authentication`,
  `dotnet-calling-endpoints`, `dotnet-models`, `dotnet-error-handling`,
  `dotnet-configuration-resilience`, `dotnet-testing`) — usage guidance layered on the map.

**Agents**

- **maxio-plan** — read-only planner: loads the bundled skills + SDK map and writes a
  contract-grounded `maxio-plan.md` before any code is written (no MCP).
- **maxio-debug** — diagnoses and fixes Maxio code in place, map-first, verifying with `dotnet build`
  / `dotnet test` (no MCP).

The map's generated pages are never hand-edited — they are produced by the
`sdk-map-generator` repo and verified field-exact against the SDK source
(github.com/asadali214/advanced-billing-sample-sdk, pinned per map stamp).

### maxio-sdk-merged

Same SDK and same bundled map as `maxio-sdk`, but the two agents are collapsed into **one** `maxio-sdk`
agent that plans, answers narrow contract questions, and fixes build errors in place. Ships Claude Code,
Cursor and Codex manifests; the Codex carrier is `codex/agents/maxio-sdk.toml`, whose
`developer_instructions` is a verbatim copy of `agents/maxio-sdk.md`. Regenerate it with
`python tools/sync-codex-carrier.py` rather than editing it by hand; CI fails the PR if the two drift.

> `skills/dotnet/` in this plugin is an empty directory skeleton — the folders exist locally but contain
> no files and nothing under it is tracked by git. It is not referenced by any manifest. Treat the
> top-level `skills/*` directories as the live ones, and delete the skeleton if it turns up in a
> working copy.

### maxio-sdk-lean

Same SDK, same single-agent shape, but the map is **not bundled** — it ships inside the SDK's own source
(branch `docs/sdk-map` of `mohammadali2549/advanced-billing-sample-sdk`) and the agent reads it from the
root of the clone. Claude Code manifest only.

### paypal-sdk

PayPal **.NET SDK** plugin — no MCP server, Claude Code + Cursor, C#/.NET only. Bundled SDK map
(`skills/paypal-getting-started/sdk-map.md` + `map/`) over
`github.com/asadali214/checkout-sample-sdk` at tag `v1.0.1` (40 operations, 5 controllers), plus the
`integrate-paypal` router and a single `paypal-sdk` agent. The SDK is on nuget.org as
`AsadAli.Checkout.Sdk`; the clone is a read-only reference, never a build dependency.

(Do not install alongside `acp-paypal` — the `integrate-paypal` skill name collides.)

### twilio-sdk

Twilio **.NET SDK** plugin with the same single-agent shape, over
`github.com/context-plugins/twilio-csharp-sdk`. Ships Claude Code, Cursor and Codex manifests; the Codex
carrier is `codex/agents/twilio-sdk.toml`, kept in sync with `agents/twilio-sdk.md` by hand.

## The `dotnet-*` companion skills are shared, but not uniform

Five plugins (`maxio-sdk`, `maxio-sdk-lean`, `maxio-sdk-merged`, `paypal-sdk`, `twilio-sdk`) each carry
their own copy of the seven `dotnet-*` skills. The copies have **drifted**, and the drift is not
accidental: they describe the emitted `Core/`, and the SDKs behind these plugins come from **two different
generator versions**. Before editing any `dotnet-*` skill, see the provenance stamp at the top of that
file — it names the generator surface the text was verified against. Copying a correction from one plugin
to another without checking that stamp will introduce a falsehood.

## Per-IDE manifest convention

MCP-backed plugins carry one manifest per IDE, and each manifest points at its own MCP config file so it can send an IDE-specific `X-Apimatic-Mcp-Client` telemetry header:

- Claude Code: `.claude-plugin/plugin.json` → `.claude-mcp.json` (header `ClaudeCode`)
- Cursor: `.cursor-plugin/plugin.json` → `.cursor-mcp.json` (header `Cursor`)
- VS Code: root `plugin.json` (Copilot format) → `.mcp.json` (header `VSCode`)

(The five SDK plugins are the exception: they have no MCP server, so their manifests point at no MCP config.
`maxio-sdk` and `maxio-sdk-lean` ship only the Claude Code manifest; `maxio-sdk-merged`, `twilio-sdk`
and `paypal-sdk` add Cursor and Codex. None of the five ships a VS Code manifest.)

Codex is carried differently from the others: the agent body cannot live in a Markdown file with
frontmatter, so it is duplicated into `codex/agents/<agent>.toml` under `developer_instructions`. That
duplication used to be hand-maintained, and drift was silent — Codex would run a different brief from
Claude Code and Cursor with nothing to say so. Edit the `.md`, then run
`python tools/sync-codex-carrier.py` to regenerate the `.toml`, and commit both together. The
`codex-carrier-sync` workflow runs `--check` on any PR touching either.
