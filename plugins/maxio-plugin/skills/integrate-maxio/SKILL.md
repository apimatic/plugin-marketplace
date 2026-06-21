---
name: integrate-maxio
description: 'Entry point and router for all Maxio Advanced Billing .NET SDK work — routes to the maxio-plan or maxio-debug subagent, or answers grounded questions directly. Use when the user asks to integrate Maxio (formerly Chargify) billing, implement subscriptions/customers/invoices/payments with the Maxio .NET SDK, asks how the Maxio .NET SDK works (auth, models, an operation, error handling), or reports a Maxio error or unexpected SDK behaviour in a C#/.NET project.'
---

# Maxio Advanced Billing .NET SDK — Skill Router

This skill routes Maxio *planning* to the `maxio-plan` subagent and Maxio *debugging* to the `maxio-debug` subagent. You (the main agent) then implement the plan `maxio-plan` produces (Step 2) and may answer quick Maxio questions directly — but **never work from your own SDK knowledge**: ground every Maxio fact in the bundled Maxio skills and the cloned SDK source (see below).

**Scope guard:** Only apply this skill when the user is working on the **Maxio Advanced Billing .NET SDK** in a **C#/.NET** project. This plugin is C#/.NET-only and Maxio-only (the SDK is `AsadAli.AdvancedBilling.Sdk`, namespace `MaxioAdvancedBilling`). When the user is doing something unrelated — a different API, or a non-.NET language — do nothing.

## Grounding in the bundled skills + SDK source — never guess about Maxio

Your training data on the Maxio Advanced Billing SDK is stale and must **never** be used as a source of truth — not for code, not for answering questions, not for resolving ambiguity. The authoritative sources are, in order:

1. **The bundled Maxio skills** — `maxio-getting-started` (the SDK-specific reference layer) and its seven companion `dotnet-*` skills (`dotnet-client-initialization`, `dotnet-authentication`, `dotnet-calling-endpoints`, `dotnet-models`, `dotnet-error-handling`, `dotnet-configuration-resilience`, `dotnet-testing`). These carry the usage layer — the gotchas a raw signature can't show.
2. **The cloned SDK source** — `maxio-getting-started` tells you to clone the SDK source repo to your system temp dir once, up front, and grep it (`api-reference.md`, `Api/`, `Models/`, `Errors/`, `Core/`) for exact signatures, model shapes, enums, and error types. This is the surface-level source of truth.

**Whenever you are uncertain about anything Maxio-related — even if you think you know the answer — load the relevant skill and check the source instead of guessing.** Do **not** decompile or reflect over the installed NuGet package, and do **not** answer from memory.

The subagents (`maxio-plan`, `maxio-debug`) do this grounding during their runs. You also do it directly for **quick lookups** — to route correctly, to answer a standalone question, or to fill a small gap while implementing a plan. But use **maxio-plan** for any actual *planning*, and implement the plan it returns rather than re-deriving it (Step 1 is the single source for when to spawn or re-spawn it).

| Need | How to ground it (the replacement for guessing) |
|---|---|
| Understand a concept or workflow — auth flow, how customers/subscriptions/invoices/payments work, recommended patterns, "is X possible with this SDK?" | **Load `maxio-getting-started`**, then the relevant companion `dotnet-*` skill. Break broad questions into focused ones. |
| Confirm an exact SDK method — its controller property, name, parameter order, return type, or thrown error type | **Grep the cloned SDK source** (`api-reference.md` for the index, then the method in `Api/`). Follow `dotnet-calling-endpoints`. |
| Confirm a request/response model's fields, required vs optional, enums, unions | **Grep the cloned SDK source** under `Models/` (+ `Models/Enums/`, `Models/AnyOf/`, `Models/OneOf/`). Follow `dotnet-models`. |
| Confirm which error type an operation throws | **Grep `Errors/`** in the cloned source. Follow `dotnet-error-handling`. |

Guidance:
- **The companion skills do not replace orchestration.** `maxio-getting-started` and the `dotnet-*` skills may surface on their own when you're in a Maxio/.NET context — that's expected, and you use their content to *ground*. But they are a reference layer, **not** a substitute for the plan/debug workflow: for any actual integration or debugging *work*, still route through `maxio-plan` / `maxio-debug` per Step 1 rather than implementing straight out of `maxio-getting-started`. (Pure questions are the one exception — see the next bullet.)
- If a user's Maxio question can be answered from the bundled skills + source without code changes, answer it directly that way — you do not have to spawn an agent for a pure question. Still ground it; never answer from memory.
- If the question turns into actual integration or debugging work, route to the appropriate agent per the workflow below.
- When grounding directly (a quick lookup or a pure question), **ensure an SDK source clone exists first** — if one isn't already in your system temp dir, follow `maxio-getting-started` to create it before you grep, then leave it for cleanup at the end.
- Resolve Maxio ambiguity through the skills + source first; only ask the user when the ambiguity is about *their* intent, not about how the SDK works.
- Keep only the SDK facts and minimal code snippets that help write the integration; drop reference dumps rather than carrying them into your context.
- This plugin has **no MCP server and no telemetry** — there are no milestones to report. Ground, plan, implement, verify.

## When to Apply

Apply this skill when the user:
- Asks to integrate Maxio Advanced Billing into their C#/.NET project
- Wants to implement customers, subscriptions, products, invoices, payments, or webhooks with the Maxio .NET SDK
- Reports a Maxio error, failed call, incorrect API response, or unexpected SDK behaviour
- Needs to maintain or change existing Maxio code — SDK version upgrades, deprecated fields, or new parameters on existing calls
- Asks a conceptual question about how the Maxio .NET SDK works — authentication, models, a specific operation, or error handling (answer it directly, grounded; see the Grounding section)
- Mentions Maxio (or Chargify) implementation, integration, or debugging in a .NET context

## Workflow

### Step 1 — Select and Spawn the Agent

| Agent | When to spawn |
|---|---|
| **maxio-plan** | User wants to add or implement any Maxio feature (customers, subscriptions, products, invoices, payments, webhooks), **or maintain/change existing Maxio code** (SDK upgrades, deprecated fields, new parameters). Produces a detailed API work plan (operations, SDK methods, models, auth) that you implement in **Step 2**. For maintenance, ask `maxio-plan` for a plan covering the change, then implement it. |
| **maxio-debug** | User is experiencing errors, unexpected behaviour, failed calls, incorrect API responses, or SDK misuse. |

- **Prepare the SDK source clone before spawning — it's your job, not the subagents'.** Cloning the SDK source (and cleaning it up afterwards) is the main agent's responsibility. Before you spawn `maxio-plan` or `maxio-debug`, ensure the SDK source clone exists in your system temp dir — create it per `maxio-getting-started` if it isn't already there — and **include its path in the spawn prompt**. The subagents do **not** clone; they read the clone you prepared and grep it for SDK contracts. (They keep `Bash`/`Grep`/`Read` purely to look things up in that clone.)
- **One spawn per implementation.** Spawn `maxio-plan` **once** for the whole implementation and pass it the user's full request — regardless of how many Maxio features it involves. It produces a single plan covering the entire scope, looking up shared auth/models only once. Do not spawn it again to cover additional features of the same implementation.
- Re-spawn `maxio-plan` only when something forces a *new* plan: an ambiguity or blocker the user has now resolved (see the blocker handling below), or a genuine scope change introducing Maxio operations the plan never covered. For small gaps mid-implementation, prefer a quick direct lookup yourself (grep the source / load a skill) over a re-spawn (see Step 2).
- **maxio-plan** returns an API work plan — before incorporating it, inspect the Assumptions and Blockers section:
  - **If a blocker is present, or an assumption is potentially incorrect or major in impact:** Stop, surface it to the user in plain language, and ask them to confirm or correct it. Then re-spawn **maxio-plan**, telling it the existing `maxio-plan.md` is present and appending the user's clarification, so it revises only the affected sections instead of re-planning from scratch. Do not proceed to implementation until the plan is free of unresolved blockers and major assumptions.
  - **If assumptions are minor and no blockers exist:** Incorporate the plan into your master plan alongside the repo/implementation work and proceed to **Step 2**.
- **maxio-debug** returns a root-cause summary and fix. Before relaying, inspect the Unresolved blockers section:
  - **If a blocker is present:** Stop, surface it to the user in plain language, and ask them to confirm or provide what's needed. Then re-spawn **maxio-debug** with the user's answer appended to the original prompt. Repeat until no unresolved blockers remain.
  - **If there are no unresolved blockers:** Relay the summary and fix to the user.
- If the task is ambiguous, default to **maxio-plan**.

### Step 2 — Implement and Verify (maxio-plan path)

Applies after a `maxio-plan` plan is accepted — for a new integration or for maintenance of existing Maxio code. (`maxio-debug` implements and verifies its own fixes, so this step does not apply to the debug path.)

1. **Read `maxio-plan.md`** at the path the agent returned, then **implement it as returned**, treating its SDK contracts as authoritative. Work through the features/operations sequentially against that one file; read it once up front — you do not need to re-read it in full at each step. Follow the project's established conventions and any security/test guidelines already present in the repo.
2. If a small SDK detail is missing, ground it yourself — load the relevant `dotnet-*` skill and/or grep the cloned SDK source — rather than re-spawning, and **never** fill the gap from memory. Re-spawn `maxio-plan` only per Step 1 (a resolved ambiguity, or genuinely out-of-scope operations the plan never covered).
3. **Verify:** after every code change, run the project's build step (`dotnet build`) and fix all errors; then run any tests covering the integration (`dotnet test`).
4. If you hit a Maxio-specific error you cannot resolve from the plan or a quick lookup, spawn **maxio-debug** with the details rather than guessing.
5. **Clean up the SDK source clone** once the whole integration is complete and verified — it is a throwaway reference in your system temp dir. Load `maxio-getting-started` for the exact clone path and the OS-specific delete command. The subagents never delete it (a later spawn may reuse it); final cleanup is yours.

## Notes

- The subagents own the work inside their runs: their own skill loading, SDK-source grounding, code changes, and compilation. The main agent uses **maxio-plan** for planning and implements the returned plan; it may ground facts directly for quick lookups, and on the integration/maintenance path it verifies the build itself (Step 2).
- **SDK source clone cleanup (every path).** If an SDK source clone was created in your temp dir during a task, delete it once that task is fully resolved — whether that's a completed integration (Step 2, item 5), a relayed `maxio-debug` fix, or an answered standalone question. The subagents never delete it (a later spawn may reuse it); final cleanup is always the main agent's. Load `maxio-getting-started` for the exact path and the OS-specific delete command.

### Grounding rules (main agent)

- Treat the SDK contracts in a returned `maxio-plan`/`maxio-debug` result as **authoritative**. Do not independently re-verify or re-derive them — the agent already grounded them against the bundled skills and SDK source.
- **The cloned SDK source + the bundled `dotnet-*` skills are the source of truth.** Do **not** decompile, reflect over, or grep the installed NuGet package as a substitute — a compiled assembly drops the XML doc-comments, exact parameter names/order, and request-builder lists the skills rely on. Read the cloned *source* instead.
- To resolve an item the plan flags as open, surface it to the user, ground it via the skills + source, or re-spawn `maxio-plan` per Step 1. If a fact genuinely cannot be confirmed from the source or skills after honest effort, label it "unverified" rather than guessing — never substitute model knowledge.
