---
name: integrate-paypal
description: 'Routes PayPal Server SDK tasks to the paypal-plan or paypal-debug subagent. Use when the user asks to integrate PayPal, implement PayPal payments, or reports a PayPal error or unexpected SDK behaviour in a C# project.'
---

# PayPal Server SDK — Skill Router (C#)

This skill routes PayPal *planning* to the `paypal-plan` subagent and PayPal *debugging* to the `paypal-debug` subagent. You (the main agent) then implement the plan `paypal-plan` produces (Step 3) and may answer quick PayPal questions directly — but never work from your own SDK knowledge: ground every PayPal fact in the MCP server (see below).

**Scope guard:** Only apply this skill when the user is working on PayPal or PayPal Server SDK integration. When the user is doing something unrelated, do nothing.

## Grounding in the MCP Server — Never Guess About PayPal

Your training data on the PayPal Server SDK is stale and must never be used as a source of truth. The `acp-paypal-server-sdk-cs` MCP server is the authoritative source for every PayPal SDK fact. **Whenever you are uncertain about anything PayPal-related — even if you think you know the answer — consult the MCP server instead of guessing.**

The subagents (`paypal-plan`, `paypal-debug`) do this during their runs. You also call these tools directly for **quick lookups** — to route correctly, to answer a standalone question, or to fill a small gap while implementing a plan. But use **paypal-plan** for any actual *planning*, and implement the plan it returns rather than re-deriving it; re-spawn `paypal-plan` if you need a new or expanded plan (see the grounding rules under Notes).

| Tool | Use it when you need to… |
|---|---|
| **ask** | Understand a concept or workflow in plain language — authentication flows, how orders/captures/subscriptions/webhooks work, feature behaviour, recommended patterns, or "is X possible with this SDK?". Break broad questions into focused ones (e.g. _"How does order capture work?"_, _"How are webhooks verified?"_). |
| **endpoint_search** | Confirm an exact SDK method's name, controller, parameters, return type, or error codes (e.g. `CreateOrderAsync`, `CaptureOrderAsync`). Use case-sensitive exact or partial method names. |
| **model_search** | Confirm a request/response model's fields, types, required vs. optional, and enum values (e.g. `OrderRequest`, `Money`, `LinkDescription`). Use case-sensitive exact or partial model names. |

Guidance:
- If a user's PayPal question can be answered from the MCP server without code changes, answer it directly using **ask** (and **endpoint_search** / **model_search** for specifics) — you do not have to spawn an agent for a pure question.
- If the question turns into actual integration or debugging work, route to the appropriate agent per the workflow below.
- Resolve PayPal ambiguity through MCP lookups first; only ask the user when the ambiguity is about *their* intent, not about how the SDK works.
- When an MCP response includes a **References** section, preserve it verbatim when relaying information to the user.

## When to Apply

Apply this skill when the user:
- Asks to integrate PayPal into a C# project
- Wants to implement PayPal payments, orders, subscriptions, payouts, or webhooks
- Reports a PayPal error, failed payment, incorrect API response, or unexpected SDK behaviour
- Needs to maintain or change existing PayPal code — SDK version upgrades, deprecated fields, or new parameters on existing calls
- Mentions PayPal and C# implementation, integration, or debugging

## Workflow

### Step 1 — Ensure Project Guidelines and Conventions Exist

Before spawning an agent, check whether project guidelines and conventions have already been set up.

- `csharp-conventions` is the skill produced by **add_skills**.
- `csharp-security-guidelines.md`, `csharp-test-guidelines.md`, and `update-activity-workflow.md` are files produced by **add_guidelines**.
- Check these independently. Do not treat the presence of one as proof the others exist.
- **If any guideline files are missing:** Call **add_guidelines** with `language: "csharp"`.
- **If `csharp-conventions` is missing:** Call **add_skills** with `language: "csharp"`.
- **If all already exist:** Skip and proceed to step 2.

### Step 2 — Select and Spawn the Agent

| Agent | When to spawn |
|---|---|
| **paypal-plan** | User wants to add or implement any PayPal feature (payments, orders, subscriptions, payouts, webhooks), **or maintain/change existing PayPal code** (SDK upgrades, deprecated fields, new parameters). Produces a detailed API work plan (endpoints, SDK methods, models, auth) that you implement in **Step 3**. For maintenance, ask `paypal-plan` for a plan covering the change, then implement it. |
| **paypal-debug** | User is experiencing errors, unexpected behaviour, failed payments, incorrect API responses, or SDK misuse. |

- Spawn the agent by name and pass the user's full request as its prompt.
- **paypal-plan** returns an API work plan — before incorporating it, inspect the Assumptions and Blockers section:
  - **If a blocker is present, or an assumption is potentially incorrect or major in impact:** Stop, surface it to the user in plain language, and ask them to confirm or correct it. Then re-spawn **paypal-plan** with the user's clarification appended to the original prompt. Do not proceed to implementation until the plan is free of unresolved blockers and major assumptions.
  - **If assumptions are minor and no blockers exist:** Incorporate the plan into your master plan alongside the repo/implementation work and proceed to **Step 3**.
- **paypal-debug** returns a root-cause summary and fix. Before relaying, inspect the Unresolved blockers section:
  - **If a blocker is present:** Stop, surface it to the user in plain language, and ask them to confirm or provide what's needed. Then re-spawn **paypal-debug** with the user's answer appended to the original prompt. Repeat until no unresolved blockers remain.
  - **If there are no unresolved blockers:** Relay the summary and fix to the user.
- If the task is ambiguous, default to **paypal-plan**.

### Step 3 — Implement and Verify (paypal-plan path)

Applies after a `paypal-plan` plan is accepted — for a new integration or for maintenance of existing PayPal code. (`paypal-debug` implements and verifies its own fixes, so this step does not apply to the debug path.)

1. **Implement the plan as returned** by `paypal-plan`, treating its SDK contracts as authoritative. Follow the project's `csharp-conventions` and the `csharp-security-guidelines.md` / `csharp-test-guidelines.md` set up in Step 1.
2. If a small SDK detail is missing, make a quick MCP lookup yourself (`ask` / `endpoint_search` / `model_search`). If the work has grown beyond the plan — new operations or a materially different approach — re-spawn `paypal-plan` for an updated plan instead of improvising.
3. **Report milestones** by calling **update_activity** the moment each is concretely reached in code (not when merely planned); do not batch or defer. If `update-activity-workflow.md` was set up in Step 1, follow its guidance on milestone reporting:

   | Milestone | When to call |
   |---|---|
   | `sdk_setup` | SDK package installed and confirmed (e.g. `dotnet add package` succeeded). |
   | `auth_configured` | PayPal credentials written into the project's runtime environment **and** referenced in actual code. |
   | `first_call_made` | First PayPal API call code written and executed. |

4. **Verify:** after every code change, run `dotnet build` and fix all errors; then run any tests covering the integration.
5. If you hit a PayPal-specific error you cannot resolve from the plan or a quick lookup, spawn **paypal-debug** with the details rather than guessing.
6. Preserve every **References** section — from the plan and from any MCP lookups you make — verbatim when relaying to the user.

## Notes

- The subagents own the work inside their runs: their own MCP lookups, code changes, compilation, milestones, and References. The main agent uses **paypal-plan** for planning and implements the returned plan; it may call the MCP server directly for quick lookups, and on the integration/maintenance path it fires the integration milestones and verifies the build itself (Step 3).
- `add_guidelines` and `add_skills` are called in step 1 because they are one-time project setup — the agents assume these are already in place.

### Grounding rules (main agent)

- Treat the SDK contracts in a returned `paypal-plan`/`paypal-debug` result as **authoritative**. Do not independently re-verify or re-derive them — the agent already grounded them against the MCP server.
- **Never inspect, reflect over, decompile, or grep the installed SDK assembly/DLL** (no `Assembly.LoadFrom`, no reflection, no IntelliSense-as-source). The acp-paypal MCP server is the only sanctioned source for SDK facts.
- The `acp-paypal-server-sdk-cs` MCP server is the primary source of truth for the PayPal SDK. To resolve an item the plan flags as open, surface it to the user, query the MCP server (`ask` / `model_search` / `endpoint_search`), or re-spawn `paypal-plan` with the clarification appended — never local inspection.
