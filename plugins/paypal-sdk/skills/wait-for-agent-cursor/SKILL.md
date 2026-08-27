---
name: wait-for-agent
description: Host-specific companion to integrate-paypal — how to wait for the paypal-sdk agent. Load it before your first spawn of paypal-sdk, and again before sending it a follow-up message.
---

<!--
One of two host-specific carriers of the wait-for-agent gate. The other lives at
../wait-for-agent-claude-code/SKILL.md — same name, different content, selected by which
plugin.json lists it. Edit both in the same commit when the gate's requirements change.
-->

# Wait for your agent

Don't wait to be told the result is ready — **watch for `paypal-plan.md` on disk instead.** You
dictated the path, so you can check for it yourself. Poll it: check the path, print one short
line saying what you're still waiting for, sleep ~30s, repeat. Keep sleeps short and print every
pass — a single long sleep looks hung.

**The file appearing isn't the file being finished.** It ends with a REQUIRED READING block;
that's the completeness marker, so keep polling until that block is there.

If you're still waiting after ~30 minutes, the agent is gone, not slow — say so and re-spawn it
once with the same scope and path. Never implement from a partial sheet or fill gaps yourself.

**Never create or edit a project file while `paypal-sdk` is running or has an outstanding
follow-up** — spawned, resumed, or backgrounded, it edits files in place, and its edits collide
with yours.
