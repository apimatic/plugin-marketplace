# Maxio Plugin (Claude Code)

A Claude Code plugin that **plans and debugs Maxio Advanced Billing (formerly Chargify) .NET SDK**
integrations — grounding every SDK fact in bundled Maxio skills and the cloned SDK source rather than
in stale model knowledge. **No MCP server required.**

## How it works

A central router skill, **`integrate-maxio`**, clones the Maxio SDK source up front, then decides
whether your task is *planning* or *debugging* and spawns the matching subagent (passing it the clone
path):

- **`maxio-plan`** — a read-only planner. It loads the bundled Maxio skills and reads/greps the SDK
  source clone the main agent prepared, then writes a self-contained `maxio-plan.md` of exact SDK
  contracts (operations, methods, models, auth) for the main agent to implement.
- **`maxio-debug`** — diagnoses and fixes Maxio issues in your code (grounded in the same clone), then
  verifies with `dotnet build` / `dotnet test`.

Both agents — and the main agent — are bound by one rule: **never answer from training data.** Maxio
facts come from the bundled skills and the cloned SDK source, in that order. This plugin grafts
agentic orchestration on top of the same SDK guidance the skills provide, with no MCP server and no
telemetry.

## Components

### Skills

- **integrate-maxio** — the orchestrator/router. Routes to `maxio-plan` / `maxio-debug`, handles
  blocker hand-back, and drives the implement-and-verify loop.
- **maxio-getting-started** — SDK-specific entry point: NuGet package `AsadAli.AdvancedBilling.Sdk`,
  root namespace `MaxioAdvancedBilling`, US/EU environments, HTTP Basic auth, and how to clone and
  navigate the SDK source. Routes to the companion `dotnet-*` skills below.
- **dotnet-client-initialization** — construct the client + options, supply an `HttpClient`, pick an
  environment, register in DI.
- **dotnet-authentication** — wire up Basic / Bearer / API-key / OAuth2 / composite auth.
- **dotnet-calling-endpoints** — method-signature conventions, request `record`s, enums, responses.
- **dotnet-models** — `OneOf`/`AnyOf` unions, collections, dates, string-/int-enums, unknown fields.
- **dotnet-error-handling** — `SdkException<TError>`, typed `{Operation}Error` vs `RawError`.
- **dotnet-configuration-resilience** — retries, timeouts, pagination, logging.
- **dotnet-testing** — unit-test SDK calls by injecting a fake `HttpClient` / `HttpMessageHandler`.

The seven `dotnet-*` skills are API-agnostic (they describe the patterns of any APIMatic-generated
.NET SDK); `maxio-getting-started` binds them to the concrete Maxio names.

### Agents

- **maxio-plan** — read-only planner (writes only `maxio-plan.md`).
- **maxio-debug** — diagnoses and fixes Maxio code in place.

## Install

```
/plugin marketplace add apimatic/plugin-marketplace
/plugin install maxio-plugin@apimatic
```

Then, in a C#/.NET project, ask to integrate or debug Maxio
(e.g. *"integrate Maxio subscriptions into my .NET app"* or
*"my Maxio CreateSubscription call returns a 422 — help"*).

## Notes

- **C#/.NET and Maxio only.** The SDK and its companion skills target C#/.NET; the plugin does nothing
  for other languages or other APIs.
- **Self-contained.** This plugin bundles its own copies of the Maxio SDK skills — it does not depend
  on any other plugin. (Do not also install a separate skills-only Maxio plugin alongside it, or the
  skill names would collide.)
- **No MCP server, no telemetry.** Grounding is the bundled skills plus a throwaway clone of the SDK
  source, which the main agent deletes when the integration is complete.
