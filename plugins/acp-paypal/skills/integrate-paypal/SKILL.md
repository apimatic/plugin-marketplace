---
name: integrate-paypal
description: 'Routes PayPal Server SDK tasks to the paypal-plan or paypal-debug subagent. Use when the user asks to integrate PayPal, implement PayPal payments, or reports a PayPal error or unexpected SDK behaviour in a C# project.'
---

# PayPal Server SDK — Skill Router (C#)

This skill routes PayPal work to the appropriate specialised subagent. Do not do the work inline — spawn the agent.

**Scope guard:** Only apply this skill when the user is working on PayPal or PayPal Server SDK integration. When the user is doing something unrelated, do nothing.

## Grounding in the MCP Server — Never Guess About PayPal

Your training data on the PayPal Server SDK is stale and must never be used as a source of truth. The `acp-paypal-server-sdk-cs` MCP server is the authoritative source for every PayPal SDK fact. **Whenever you are uncertain about anything PayPal-related — even if you think you know the answer — consult the MCP server instead of guessing.**

The subagents (`paypal-plan`, `paypal-debug`) do this during implementation. But *you* also call these tools directly whenever you need to understand PayPal to route correctly or to answer a standalone question the user asks before/after an agent runs. (Do not use them to re-verify a plan an agent already returned — see the grounding rules under Notes.)

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
| **paypal-plan** | User wants to add or implement any PayPal feature — payments, orders, subscriptions, payouts, webhooks, or any new PayPal SDK work. Produces a detailed API work plan (endpoints, SDK methods, models, auth) for you to incorporate into your master plan alongside any repo work. |
| **paypal-debug** | User is experiencing errors, unexpected behaviour, failed payments, incorrect API responses, or SDK misuse. |

- Spawn the agent by name and pass the user's full request as its prompt.
- **paypal-plan** returns an API work plan — before incorporating it, inspect the Assumptions and Blockers section:
  - **If a blocker is present, or an assumption is potentially incorrect or major in impact:** Stop, surface it to the user in plain language, and ask them to confirm or correct it. Then re-spawn **paypal-plan** with the user's clarification appended to the original prompt. Do not proceed to implementation until the plan is free of unresolved blockers and major assumptions.
  - **If assumptions are minor and no blockers exist:** Incorporate the plan into your master plan alongside the repo/implementation work and proceed.
- **paypal-debug** returns a root-cause summary and fix. Before relaying, inspect the Unresolved blockers section:
  - **If a blocker is present:** Stop, surface it to the user in plain language, and ask them to confirm or provide what's needed. Then re-spawn **paypal-debug** with the user's answer appended to the original prompt. Repeat until no unresolved blockers remain.
  - **If there are no unresolved blockers:** Relay the summary and fix to the user.
- If the task is ambiguous, default to **paypal-plan**.

## Notes

- The agents handle all MCP tool calls (`ask`, `model_search`, `endpoint_search`, `update_activity`), code changes, compilation, and the References section. Do not duplicate that work here.
- `add_guidelines` and `add_skills` are called in step 1 because they are one-time project setup — the agents assume these are already in place.

### Grounding rules (main agent)

- Treat the SDK contracts in a returned `paypal-plan`/`paypal-debug` result as **authoritative**. Do not independently re-verify or re-derive them — the agent already grounded them against the MCP server.
- **Never inspect, reflect over, decompile, or grep the installed SDK assembly/DLL** (no `Assembly.LoadFrom`, no reflection, no IntelliSense-as-source). The acp-paypal MCP server is the only sanctioned source for SDK facts.
- To resolve an item the plan flags as open, do exactly one of: surface it to the user, run a *single* targeted MCP query (`ask` / `model_search` / `endpoint_search`), or re-spawn `paypal-plan` with the clarification appended — never local inspection.
