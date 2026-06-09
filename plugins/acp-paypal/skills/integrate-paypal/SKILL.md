---
name: integrate-paypal
description: 'Routes PayPal Server SDK tasks to the paypal-plan or paypal-debug subagent. Use when the user asks to integrate PayPal, implement PayPal payments, or reports a PayPal error or unexpected SDK behaviour in a C# project.'
---

# PayPal Server SDK — Skill Router (C#)

This skill routes PayPal work to the appropriate specialised subagent. Do not do the work inline — spawn the agent.

**Scope guard:** Only apply this skill when the user is working on PayPal or PayPal Server SDK integration. When the user is doing something unrelated, do nothing.

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
