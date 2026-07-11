---
name: integrate-maxio
description: 'Entry point and router for all Maxio Advanced Billing .NET SDK work — routes planning to the maxio-plan subagent (which returns a map-grounded contract sheet) and SDK errors to the maxio-debug subagent. Use when the user asks to integrate Maxio (formerly Chargify) billing, implement subscriptions/customers/usage/invoices with the Maxio .NET SDK, or reports a Maxio error or unexpected SDK behaviour in a C#/.NET project.'
---

# Maxio Advanced Billing .NET SDK — Router (map + subagents)

You (the main agent) orchestrate; the subagents carry the SDK knowledge. The division of
labour exists to keep YOUR context small and YOUR code grounded:

- **`maxio-plan`** does all SDK discovery against the bundled SDK map and returns a
  **contract sheet** — the exact signatures, wire names, envelope shapes, error
  accessors, and enum values for the operations in scope. You implement from the sheet.
- **`maxio-debug`** owns SDK-related build/runtime failures. Its first move on a failing
  SDK name is opening the exact source file the map names — never re-guessing.

**Scope guard:** Maxio Advanced Billing .NET SDK (`AsadAli.AdvancedBilling.Sdk`,
namespace `MaxioAdvancedBilling`) in C#/.NET projects only. Unrelated API or language —
do nothing.

## The three rules that make this work

1. **Never write a Maxio/SDK fact from memory.** Your training data on this SDK is
   stale. Every signature, field name, enum value, and error type in code you write must
   come from the contract sheet or from a lookup (rule 3). If it's not in the sheet and
   you haven't looked it up, you don't know it.
2. **Keep your own context lean.** Do NOT bulk-load `maxio-getting-started`, the
   `dotnet-*` skills, or the SDK map pages yourself — that is `maxio-plan`'s job, inside
   its own context. Do not carry reference dumps; the contract sheet is your working
   reference. (Exception: a single targeted map-page read per rule 3 is fine.)
3. **Missing contract mid-implementation = look it up, never guess.** When you hit an
   SDK fact the sheet doesn't cover, either (a) re-spawn `maxio-plan` with ONE narrow
   question — it answers from the map in its final message, no file — or (b) make one
   targeted read of the specific map page yourself (the sheet's rows name their map
   sources). Choose (a) when there are several related unknowns, (b) for a single field
   name. Then continue. Under no circumstances write the call from memory "to fix later".

## Workflow

### Step 1 — Plan (always first for implementation work)

Spawn **`maxio-plan`** once with the user's full request (all features in scope — one
spawn covers the whole implementation). It writes `maxio-plan.md` (plan + contract
sheet) and returns its path.

Before implementing, check the plan's **Assumptions & Blockers** section:
- Blocker or major assumption → surface it to the user in plain language, get their
  answer, re-spawn `maxio-plan` with the clarification appended (it revises in place).
- Minor assumptions only → proceed.

Re-spawn for planning only on genuine scope change; for gaps use rule 3's narrow-question
mode.

### Step 2 — Implement from the contract sheet

1. Read `maxio-plan.md` once. Treat its contracts as authoritative — do not re-derive
   or "double-check" them from memory.
2. Implement sequentially. Follow the repo's own conventions and layering.
3. After every change: `dotnet build`; fix non-SDK errors yourself.
4. **Any compile or runtime error involving an SDK type or member** (`CS1061`,
   `CS0117`, `CS0234`, `CS0104`, `CS1503`, `CS7036`, … on `MaxioAdvancedBilling.*`, or a
   provider error at runtime) → spawn **`maxio-debug`** with the exact error output and
   the files involved. Do not attempt more than one self-fix of an SDK-name error before
   escalating — rewriting from the same knowledge that produced the error is guessing.
5. Run the project's tests (`dotnet test`); verify the integration end to end the way
   the task demands.

### Step 3 — Answering pure questions

A standalone Maxio question with no code change: spawn `maxio-plan` in narrow-question
mode and relay its grounded answer. Never answer from memory, even for "easy" questions.

## Subagent hygiene

- Give each spawn a complete, self-contained brief (task scope, project paths, the
  plan-file path when relevant, exact error text for debug).
- Require tight returns: `maxio-plan` returns a path + one-paragraph summary (narrow
  mode: just the answer); `maxio-debug` returns root cause + fix applied + files touched
  + unresolved blockers. If a return arrives bloated, use what you need and drop the
  rest — do not paste it into files or re-quote it.
- Neither you nor the subagents ever decompile/reflect over the NuGet package, open the
  SDK's `api-reference.md`, or web-search Maxio topics. `maxio-debug` handles all SDK
  source-clone needs per `maxio-getting-started`'s rules; you never clone.
