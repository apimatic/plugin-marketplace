---
name: integrate-paypal
description: 'Guidance for integrating the PayPal Server SDK v4 into a project. Use when the user asks to integrate PayPal, implement PayPal payments/orders/subscriptions/webhooks, or upgrade to / work with v4 of the PayPal Server SDK.'
---

# PayPal Server SDK v4 — Integration Skill

This skill guides integration of the **PayPal Server SDK v4** into the user's project: how to scope the work, install and configure the SDK, and implement common payment flows following the project's conventions.

**Scope guard:** Only apply this skill when the user is working on PayPal or the PayPal Server SDK. When the user is doing something unrelated, do nothing.

## Ground every SDK fact in an authoritative source — never guess

General-purpose model training data on the PayPal Server SDK is stale and version-drifted, and v4 introduced breaking changes from earlier major versions. **Do not write PayPal SDK code from memory.** Before relying on any method name, parameter, request/response model field, enum value, authentication pattern, or error code, confirm it against an authoritative, version-pinned source:

- The PayPal Server SDK v4 package actually installed in the project (its source / type-definition files for the exact installed version).
- The official PayPal Server SDK v4 documentation for the project's language.

When you are uncertain about anything PayPal-related — even if you think you know the answer — verify it rather than guessing. A plan built on outdated SDK knowledge produces broken code.

## When to apply

Apply this skill when the user:
- Asks to integrate PayPal into their project, or implement PayPal payments, orders, subscriptions, payouts, or webhooks.
- Wants to adopt or upgrade to **v4** of the PayPal Server SDK, or migrate existing PayPal code to v4.
- Needs to maintain or change existing PayPal code — deprecated fields, new parameters, or version bumps within v4.

## Workflow

### Step 1 — Scope the work

1. Read the user's request and identify the PayPal operations involved: what must be called, in what order, and with what inputs/outputs.
2. Inspect the project to learn its language, package manager, existing PayPal usage (if any), configuration/secrets conventions, and test setup.
3. Resolve PayPal-specific ambiguity against an authoritative source (installed package / official v4 docs) before asking the user. Only ask the user when the ambiguity is about *their* intent, not about how the SDK works.

### Step 2 — Install and configure the SDK

1. Add the PayPal Server SDK v4 package for the project's language using its package manager, pinning to a v4 version. Confirm the install resolved.
2. Wire credentials (client ID / secret) through the project's existing secrets/runtime-config mechanism — never hard-code them. Select the correct environment (sandbox vs. live) per the project's config.
3. Instantiate the SDK client following the v4 client/auth pattern documented for the installed version.

### Step 3 — Implement the operations

1. For each operation, confirm the exact SDK method, request/response models, required vs. optional fields, enum values, and error/exception types against the authoritative source — then write the code.
2. Construct requests with the v4 models, invoke the methods, and handle responses and errors explicitly (including the documented failure status codes).
3. Follow the project's established conventions and any security/test guidelines already present in the repo.

### Step 4 — Verify

1. After every change, run the project's build/compile step and fix all errors.
2. Run any tests covering the integration. If the project offers a way to exercise the code path against the PayPal sandbox, run it.
3. If you hit a PayPal error you cannot resolve from the authoritative source, surface it to the user rather than guessing.

## Notes

- Keep only the SDK snippets that help write the integration; drop documentation-link reference dumps rather than carrying them into your context.
- Prefer sandbox credentials and the sandbox environment for all development and testing; switch to live only when the user explicitly intends a production integration.
