---
name: wait-for-agent
description: Host-specific companion to integrate-paypal — how a completion from the paypal-sdk agent actually reaches you in Claude Code. Load it before your first spawn of paypal-sdk, and again before sending it a follow-up message.
---

<!--
Claude Code's carrier of the wait-for-agent gate. Cursor's carrier lives at
../wait-for-agent-cursor/SKILL.md — same name, different content, selected by which plugin.json
lists it. The two gate paragraphs (never edit project files; how a notification arrives) must
stay in sync in substance across both files even though the wording differs per host. Edit both
in the same commit when the gate's requirements change.
-->

# Wait for your agent — Claude Code

**A first spawn of `paypal-sdk` blocks.** Calling the Agent tool on it — without `isolation` or
a background mode — does not return control to you until the agent finishes; its result comes
back as that same tool call's result. You do not need to invent any special "waiting" behavior
for this case: just don't take an action that assumes the result before the tool call returns.
Do the read-only Step-1 prerequisite work (repo survey, restore, baseline build, env checks) in
the SAME message as the spawn (parallel tool calls) so the block costs you nothing.

**A follow-up message to an already-running or backgrounded `paypal-sdk` agent is different.**
Its reply arrives later, as a notification — never inside the same turn you sent the follow-up.
Never invent a blocking loop, a sleep, or a status-polling action to force it sooner; that
notification will never arrive mid-turn no matter how you wait for it. Once you've exhausted
the read-only prerequisite work, end your turn with a brief status update — that is how the
reply actually reaches you.

Ending the turn here is not handing back to the user, not deferring work, and not the kind of
early stop that leaves the task unfinished — it is the mechanism for making progress on work
that is genuinely running in the background. Treat it as continuing the task, not pausing it:
the moment the notification lands, pick the plan straight back up.

**Never create or edit a project file while `paypal-sdk` is running or has an outstanding
follow-up** — spawned, resumed, or backgrounded, it edits files in place, and its edits collide
with yours.
