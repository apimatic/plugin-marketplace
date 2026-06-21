# APIMatic Plugin Marketplace

General-purpose AI models are trained on public code and documentation, much of it outdated. They have no awareness of an actual API version, latest SDKs or the recommended workflows.

APIMatic gives coding assistants deterministic, version-aware API context, generated directly from your API definition and SDKs. Instead of scraping public documentation or guessing from memory, the AI is grounded in the exact OpenAPI definition, current SDK versions, executable, idiomatic code samples, and recommended integration workflows.

This repository is a multi-plugin marketplace (`name: apimatic`) targeting **Claude Code, Cursor, and VS Code**. It ships two plugins under `plugins/`.

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

### maxio-plugin

Maxio Advanced Billing (formerly Chargify) **.NET SDK** plugin. A hybrid: it takes acp-paypal's
plan/debug agent orchestration but replaces the MCP server with a **skills + SDK-source** data layer.
**No MCP server, no telemetry, Claude Code only, C#/.NET only.**

**Skills**

- **integrate-maxio** — Orchestrator/router. Routes Maxio .NET SDK tasks to the `maxio-plan` or `maxio-debug` subagent, handles blocker hand-back, and drives the implement-and-verify loop. Grounds every fact in the bundled skills + cloned SDK source — never model knowledge.
- **maxio-getting-started** + seven `dotnet-*` companions (`dotnet-client-initialization`, `dotnet-authentication`, `dotnet-calling-endpoints`, `dotnet-models`, `dotnet-error-handling`, `dotnet-configuration-resilience`, `dotnet-testing`) — bundled SDK guidance (the data layer). `maxio-getting-started` is the SDK-specific entry point and directs cloning/grepping the SDK source as the surface source of truth.

**Agents**

- **maxio-plan** — Read-only planner. Loads the bundled skills, reads/greps the SDK source clone the main agent prepared (it does not clone), and writes a contract-grounded `maxio-plan.md`. Tools: `Read, Glob, Grep, Bash, Skill, Write` (`Bash` is read-only lookup only; no MCP).
- **maxio-debug** — Diagnoses and fixes Maxio code in place, grounded in the same clone, verifying with `dotnet build` / `dotnet test`. Tools: `Read, Write, Edit, Glob, Grep, Bash, Skill` (no MCP).
- The **main agent** (via `integrate-maxio`) clones the SDK source before spawning and cleans it up afterward — cloning is not the subagents' job.

Self-contained — bundles its own copies of the Maxio SDK skills, so it has no dependency on any other plugin (do not install a separate skills-only Maxio plugin alongside it, or skill names would collide).

## Per-IDE manifest convention

MCP-backed plugins carry one manifest per IDE, and each manifest points at its own MCP config file so it can send an IDE-specific `X-Apimatic-Mcp-Client` telemetry header:

- Claude Code: `.claude-plugin/plugin.json` → `.claude-mcp.json` (header `ClaudeCode`)
- Cursor: `.cursor-plugin/plugin.json` → `.cursor-mcp.json` (header `Cursor`)
- VS Code: root `plugin.json` (Copilot format) → `.mcp.json` (header `VSCode`)

(maxio-plugin is the exception: it has no MCP server and ships only the Claude Code manifest.)
