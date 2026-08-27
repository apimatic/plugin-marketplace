---
name: wait-for-agent
description: Host-specific companion to integrate-paypal — how a completion from the paypal-sdk agent actually reaches you in Cursor. Load it before your first spawn of paypal-sdk, and again before sending it a follow-up message.
---

<!--
Cursor's carrier of the wait-for-agent gate. Claude Code's carrier lives at
../wait-for-agent-claude-code/SKILL.md — same name, different content, selected by which
plugin.json lists it. The two gate paragraphs (never edit project files; how a notification
arrives) must stay in sync in substance across both files even though the wording differs per
host. Edit both in the same commit when the gate's requirements change.
-->

# Wait for your agent — Cursor

**Cursor only delivers a subagent's completion notification at a turn boundary.** This is true
whether you just spawned `paypal-sdk` or sent it a follow-up message: do not sit inside the
current turn waiting for its reply. A blocking wait, a sleep, or a status-polling action you
invent yourself will never actually receive the notification — it can only arrive once your
turn has ended.

The one thing you may do first is the **read-only** Step-1 prerequisite work (repo survey,
restore, baseline build, env checks) — it touches no project file. Once that is done and the
agent is still running, end your turn with a brief status update rather than sitting inside the
turn.

Ending the turn here is not handing back to the user, not deferring work, and not the kind of
early stop that leaves the task unfinished — it is the mechanism for making progress on work
that is genuinely running in the background. Treat it as continuing the task, not pausing it:
the moment the notification arrives, pick the plan straight back up.

**Never create or edit a project file while `paypal-sdk` is running or has an outstanding
follow-up** — spawned, resumed, or backgrounded, it edits files in place, and its edits collide
with yours.
