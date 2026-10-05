# APIMatic Plugin Marketplace

General-purpose AI models are trained on public code and documentation, much of it outdated. They have no awareness of an actual API version, latest SDKs or the recommended workflows.

APIMatic gives coding assistants deterministic, version-aware API context, generated directly from your API definition and SDKs. Instead of scraping public documentation or guessing from memory, the AI is grounded in the exact OpenAPI definition, current SDK versions, executable, idiomatic code samples, and recommended integration workflows.

This repository is a multi-plugin marketplace (`name: apimatic`) targeting **Claude Code, Cursor, and VS Code**. It ships three plugins under `plugins/`: `context-matic`, `acp-paypal`, and `maxio-sdk`.

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

Maxio Advanced Billing (formerly Chargify) **.NET SDK** plugin — skills only: no agent, no MCP
server, no telemetry, C#/.NET only. It teaches an agent to install and use the APIMatic-generated
SDK (NuGet `Darker98.MaxioAdvancedBilling`, source `Darker98/maxio-csharp-sdk`). The SDK map
(`sdk-map.md` + `map/operations/`) is **not bundled**: it ships in the SDK source repo, and
`dotnet-getting-started` has the agent take one shallow clone of it at the start of SDK work.

**Skills** (flat `skills/<name>/`)

- **dotnet-integrate-maxio-advanced-billing** — mandatory first step / router: the plan-file gate
  (`maxio-advanced-billing-plan.md`), contract-sheet labels and the required-reading rule.
- **dotnet-getting-started** — SDK-specific entry point: identity, install, servers/auth, how to
  obtain and use the SDK map.
- Seven `dotnet-*` companions (`dotnet-client-initialization`, `dotnet-authentication`,
  `dotnet-calling-endpoints`, `dotnet-models`, `dotnet-error-handling`,
  `dotnet-configuration-resilience`, `dotnet-testing`) — usage guidance layered on the map.

The map's pages are generated with the SDK and never hand-edited.

## Per-IDE manifest convention

MCP-backed plugins carry one manifest per IDE, and each manifest points at its own MCP config file so it can send an IDE-specific `X-Apimatic-Mcp-Client` telemetry header:

- Claude Code: `.claude-plugin/plugin.json` → `.claude-mcp.json` (header `ClaudeCode`)
- Cursor: `.cursor-plugin/plugin.json` → `.cursor-mcp.json` (header `Cursor`)
- VS Code: root `plugin.json` (Copilot format) → `.mcp.json` (header `VSCode`)

(The maxio-sdk plugin is the exception: it has no MCP server and ships only the Claude Code manifest.)
