---
name: context-plugin-catalog
description: Discovers and integrates third-party APIs using the Context Plugin Catalog MCP server. Uses `list_apis` to find available API SDKs, `ask` for integration guidance, `model_search` and `endpoint_search` for SDK details. Use when the user asks to integrate a third-party API, add an API client, implement features with an external API, or work with any third-party API or SDK.
---

# API Integration

When the user asks to integrate a third-party API or implement anything involving an external API or SDK, follow this workflow. Do not rely on your own knowledge for available APIs or their capabilities — always use the Context Plugin Catalog MCP server.

## When to Apply

Apply this skill when the user:
- Asks to integrate a third-party API
- Wants to add a client or SDK for an external service
- Requests implementation that depends on an external API
- Mentions a specific API (e.g. PayPal, Twilio) and implementation or integration

## Workflow

### 1. Discover Available APIs

Call **list_apis** to find available APIs — always start here.

- Provide the `language` parameter matching the project's primary language (e.g. `csharp`, `python`, `typescript`, `go`, `java`, `ruby`, `php`).
- Infer the language from the codebase (e.g. `.csproj` → `csharp`, `package.json` with TypeScript → `typescript`).
- The response returns available APIs with their names, descriptions, and `key` values.
- Identify the API that matches the user's request based on the name and description.
- Extract the correct `key` for the user's requested API before proceeding. This key will be used for all subsequent tool calls related to that API.

**If the requested API is not in the list:**
- Inform the user that the API is not currently available in the Context Plugin Catalog.
- Continue integrating the required API WITHOUT The Context Plugin Catalog plugin.

### 2. Begin Integration

Call **update_activity** as the first tool call when integration begins (after discovering the API via `list_apis`).

- Pass `language` and `key` (from step 1) if known.
- Pass `phase='planning'` when about to look up integration guidance or SDK details.
- Pass `phase='execution'` when about to generate or fix code.
- Pass `milestone` only when a specific milestone has just been completed (see milestone reference below).

### 3. Get Integration Guidance

Call **update_activity** immediately before **ask**, then call **ask**.

- Provide `ask` with: `language`, `key` (from step 1), and your `query`.
- Break complex questions into smaller focused queries for best results:
  - _"How do I authenticate?"_
  - _"How do I create a payment?"_
  - _"What are the rate limits?"_

### 4. Look Up SDK Models and Endpoints (as needed)

Call **update_activity** immediately before each **model_search** or **endpoint_search**, then call the tool.

- **model_search** — look up a model/object definition.
  - Provide: `language`, `key`, and an exact or partial case-sensitive model name as `query` (e.g. `availableBalance`, `TransactionId`).
  - Returns the model's definition and properties. Does not generate code.

- **endpoint_search** — look up an endpoint method's details.
  - Provide: `language`, `key`, and an exact or partial case-sensitive method name as `query` (e.g. `createUser`, `get_account_balance`).
  - Returns the method's description, parameters, and response. Does not generate code.

### 5. Record Milestones

Call **update_activity** (with the appropriate `milestone`) whenever one of these is observed or confirmed:

| Milestone | When to pass it |
|---|---|
| `sdk_setup` | SDK packages installed and environment confirmed set up |
| `auth_configured` | API keys or auth configured, ready to make first call |
| `first_call_attempted` | First API call code written and executed |
| `first_call_succeeded` | Successful response from first API call received |
| `error_encountered` | Developer reports a bug, error response, or failing call |
| `error_resolved` | Fix applied and API call confirmed working |
| `tests_passing` | Integration tests written and confirmed passing |

## IDE Guardrails

- After each code modification, compile the project and address any required fixes.

## Checklist

- [ ] `list_apis` called with correct `language` for the project
- [ ] Correct `key` identified for the requested API (or user informed if not found)
- [ ] `update_activity` called as first tool when integration begins
- [ ] `update_activity` called immediately before every `ask`, `model_search`, and `endpoint_search`
- [ ] `update_activity` called with the appropriate `milestone` at each integration milestone
- [ ] `ask` used for integration guidance and code samples
- [ ] `model_search` / `endpoint_search` used as needed for SDK details
- [ ] Project compiles after each code modification

## Notes

- **Discovery first**: Always use `list_apis` → `ask` → `model_search`/`endpoint_search`. Never rely on your own knowledge for API capabilities.
- **Language parameter**: Must be one of `csharp`, `python`, `typescript`, `go`, `java`, `ruby`, `php`. Infer from the project's file extensions or build configuration.
- **API not found**: If an API is missing from `list_apis`, do not guess at SDK usage — inform the user and stop.
- **update_activity skipped for list_apis**: `list_apis` is API discovery, not integration — do not call `update_activity` before it.
