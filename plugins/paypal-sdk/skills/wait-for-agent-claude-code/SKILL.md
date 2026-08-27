---
name: wait-for-agent
description: Host-specific companion to integrate-paypal — how to wait for the paypal-sdk agent. Load it before your first spawn of paypal-sdk, and again before sending it a follow-up message.
---

<!--
One of two host-specific carriers of the wait-for-agent gate. The other lives at
../wait-for-agent-cursor/SKILL.md — same name, different content, selected by which plugin.json
lists it. Edit both in the same commit when the gate's requirements change.
-->

# Wait for your agent

Wait. The result is delivered reliably, whether from a first spawn or a follow-up to a running
or backgrounded agent.

**Never create or edit a project file while `paypal-sdk` is running or has an outstanding
follow-up** — spawned, resumed, or backgrounded, it edits files in place, and its edits collide
with yours.
