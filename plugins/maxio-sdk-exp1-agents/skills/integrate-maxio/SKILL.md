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
  It has **no Bash**: it cannot clone, run, or inspect SDK source, and it cannot run
  commands of any kind. Never route a source lookup to it.
- **`maxio-debug`** owns SDK-related build/runtime failures **and is the ONLY helper
  that touches SDK source** — anything that needs the SDK cloned or a source file
  opened goes to it. Its first move on a failing SDK name is opening the exact source
  file the map names — never re-guessing.

**Scope guard:** Maxio Advanced Billing .NET SDK (`AsadAli.AdvancedBilling.Sdk`,
namespace `MaxioAdvancedBilling`) in C#/.NET projects only. Unrelated API or language —
do nothing.

## The four rules that make this work

1. **Never write a Maxio/SDK fact from memory.** Your training data on this SDK is
   stale. Every signature, field name, enum value, and error type in code you write must
   come from the contract sheet or from a lookup (rule 3). If it's not in the sheet and
   you haven't looked it up, you don't know it.
2. **Keep your own context lean.** Do NOT bulk-load `maxio-getting-started`, the
   `dotnet-*` skills, or the SDK map pages yourself — that is `maxio-plan`'s job, inside
   its own context. Do not carry reference dumps; the contract sheet is your working
   reference. (Exception: a single targeted map-page read per rule 3 is fine.)
3. **Missing contract mid-implementation = look it up, never guess.** When you hit an
   SDK fact the sheet doesn't cover, either (a) ask `maxio-plan` ONE narrow question —
   it answers from the map in its reply, no file — or (b) make one targeted read of the
   specific map page yourself (the sheet's rows name their map sources). Choose (b)
   ONLY for a single fact on a page the sheet's citation names — and NEVER open
   `map/models/records-*.md` yourself: they are the largest pages in the map and ride
   in your context for every remaining turn. Model/enum field questions, several
   related unknowns, or any urge to "double-check" sheet rows against the map → (a),
   batched into ONE ask (the plan agent already holds those pages warm and answers in
   seconds). Then continue. Under no circumstances write the call from memory "to fix
   later".
4. **Reuse helpers; don't re-spawn them.** Every fresh spawn rebuilds a prompt cache
   from scratch (the dominant helper cost). If your harness can send a follow-up
   message to an already-spawned agent (e.g. a SendMessage/continue tool), direct all
   follow-up questions and plan revisions to the EXISTING `maxio-plan` agent — its map
   context is already warm. Spawn fresh only when that isn't available or the agent is
   gone.

## Workflow

### Step 1 — Plan (always first for implementation work)

Spawn **`maxio-plan`** once with the user's full request (all features in scope — one
spawn covers the whole implementation). The brief must **dictate the output path**:
the absolute path where it writes the plan (`<project repo root>/maxio-plan.md`) —
do not let the helper pick its own location.

It writes `maxio-plan.md` (plan + contract sheet) and returns its path.

**Parallelize the wait — prerequisites only.** Repo reconnaissance (where the
integration lands in this codebase) is not `maxio-plan`'s job: kick it off in the
SAME message as the `maxio-plan` spawn (parallel tool calls; background spawns if
your harness has them). While `maxio-plan` works, do ONLY work that needs no SDK
knowledge and touches no project file:

- the repo survey (read-only exploration of conventions and layering) — brief it to
  return each convention as *pattern + the ONE exemplar file path to imitate*, NOT
  inline code snippets: you will Read the exemplar at edit time anyway (edits need
  the file's exact current text), so a snippet dump gets paid for twice;
- `dotnet restore` and a baseline `dotnet build` / `dotnet test` of the UNTOUCHED
  solution, so later failures are attributable to your changes;
- locating the SDK package and its version in the project;
- credentials/environment verification (per the task's secret-handling rules);
- setting up your task tracking.

Never sit idle waiting on a helper — every one of the items above fits inside the
plan agent's runtime. Equally: never use the wait to get a "head start" on
implementation. Writing or editing ANY project file before the gate below is a
defect, no matter how obvious the code seems.

**HARD GATE — no project-file creation or edits until:** the plan agent has
RETURNED, the file EXISTS at the path you dictated (check it — helpers have
misreported save locations), and you have read it. The gate bars coding
"meanwhile"; it does not bar the read-only prerequisite work above. Starting to
code before the sheet exists defeats the entire plan-first design.

Before implementing, check the plan's **Assumptions & Blockers** section:
- Blocker or major assumption → surface it to the user in plain language, get their
  answer, send the clarification to `maxio-plan` (rule 4: message the existing agent;
  re-spawn only if unavailable). It revises the file in place and replies with the
  changed rows.
- Minor assumptions only → proceed.

Full re-planning only on genuine scope change; for gaps use rule 3's narrow-question
mode.

### Step 2 — Implement from the contract sheet

1. Read `maxio-plan.md` once — and ONCE means once for the whole session. When a
   helper later revises the sheet, it replies with the changed rows verbatim: work
   from its reply, never re-read the file in full (a second full read rides in your
   context for every remaining turn). Treat the contracts as authoritative — do not
   re-derive or "double-check" them from memory. If you are no longer sure what a
   sheet row actually said, that is a rule-3 lookup — ask `maxio-plan`, or re-read
   just that section of the sheet (Read with offset/limit). The ban is on FULL
   re-reads, never on targeted ones; reconstructing a half-remembered row from
   memory is guessing.
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
- Independent helpers are spawned together in ONE message, never serially — every
  foreground helper you wait on alone is pure idle time.
- Require tight returns: `maxio-plan` returns a path + one-paragraph summary (narrow
  mode: just the answer); `maxio-debug` returns root cause + fix applied + files touched
  + unresolved blockers. If a return arrives bloated, use what you need and drop the
  rest — do not paste it into files or re-quote it.
- **Shared artifacts:** helpers pass artifacts to each other (the SDK clone path,
  above all) via a `## Session artifacts` section at the bottom of `maxio-plan.md` —
  that rule lives in their own prompts; all you need to know is that such paths live
  there, not with you.
- Neither you nor the subagents ever decompile/reflect over the NuGet package, open the
  SDK's `api-reference.md`, or web-search Maxio topics. `maxio-debug` handles all SDK
  source-clone needs per `maxio-getting-started`'s rules; you never clone.
