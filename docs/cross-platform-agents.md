CREATING AN AGENT FILE
──────────────────────
Minimum required fields: name + description
File extension:          .md (all three tools)
                         .agent.md (VS Code Copilot format also works)
Body:                    The system prompt, in Markdown

SCOPES (where to put standalone files)
───────────────────────────────────────
Project   → .claude/agents/      (Claude Code, VS Code, Cursor all read this)
User      → ~/.claude/agents/    (Claude Code, VS Code)
           ~/.cursor/agents/     (Cursor)

IN A PLUGIN
───────────
Agent files → agents/ directory at plugin root
Manifests   → .claude-plugin/plugin.json   (Claude Code)
              .cursor-plugin/plugin.json   (Cursor)
              plugin.json at root          (VS Code)

CURSOR MANIFEST FIELDS  (verified 2026-08-25 against cursor.com/docs/reference/plugins)
──────────────────────
  agents      string or array   Path(s) to agent FILES OR DIRECTORIES
  skills      string or array   Path(s) to skill DIRECTORIES  (each holding a SKILL.md)
  commands    string or array   Path(s) to command files or directories
  rules       string or array   Path(s) to rule files or directories
  mcpServers  string|object|array

The agents/skills asymmetry is easy to get backwards: `agents` accepts a single .md file,
`skills` does not — a skill path must be the directory. Our manifests pass
`"agents": ["./agents/<name>.md"]` and `"skills": ["./skills/<name>", ...]`, which is correct
for both.

⚠ Specifying a field REPLACES folder discovery for that component; the default folder is not
also scanned. So a typo in an explicit path does not fall back to the convention — it silently
yields zero components. Omitting the field entirely is the safer default when the layout is
already conventional.

TOOL RESTRICTION
────────────────
Claude Code  → tools: Read, Grep     (allowlist, comma string)
               disallowedTools: Write (denylist, comma string)
VS Code      → tools: ['search/codebase']  (array syntax)
Cursor       → readonly: true              (binary only)

HANDOFFS
────────
VS Code      → handoffs: [{label, agent, prompt, send, model}]
Claude Code  → prompt-driven only: "use X subagent then Y subagent"
Cursor       → prompt-driven only: /agent-name or natural language

PLUGIN AGENT RESTRICTIONS
─────────────────────────
Claude Code  → hooks, mcpServers, permissionMode are STRIPPED from plugin agents
VS Code      → no restrictions
Cursor       → no restrictions (hooks in agent files not supported anyway)

CODEX
─────
Codex has no agents key in .codex-plugin/plugin.json. A custom subagent is a standalone TOML
file — name, description and developer_instructions required — in a config-layer agents/
directory:

  ~/.codex/agents/        personal
  .codex/agents/          project-scoped
  $CODEX_HOME/agents/     whatever CODEX_HOME points at

That is why each Codex-targeting plugin carries codex/agents/<name>.toml holding the .md
body verbatim under developer_instructions, kept in sync by hand.

⚠ ONE STANDING SILENT FAILURE, and one that was fixed before we wrote it down
   (rechecked 2026-08-27):

1. FIXED — and this entry was wrong when it was written. Named custom-agent invocation from
   tool-backed sessions was genuinely broken: openai/codex#15250, "Custom subagents in
   .codex/agents are not accessible from tool-backed Codex sessions as docs imply". This
   document and all three carriers described that issue as **open**. It was closed as
   completed on **2026-08-05T03:53:06Z** — twenty days before the 2026-08-25 stamp above —
   with the maintainer's closing note, in full: "Tool-backed sessions expose and apply
   configured agent roles."

   The verification that produced this entry checked that the issue existed and read its
   labels. It did not check `state`, and an issue's number and labels survive its closure
   unchanged, so nothing about the evidence looked stale. That is the failure mode worth
   keeping: a citation that is real, specific and current-looking, and wrong about the one
   field that mattered.

   What survives is version skew rather than the bug. The fix ships in a codex-cli build;
   bundled builds lag, and the VS Code extension was still shipping codex-cli 0.144.5 in July
   2026. On a build older than the fix, a child still spawns with no developer_instructions
   and nothing errors. Interactive CLI binding by name was confirmed live on codex-cli 0.147.0
   (gpt-5.6-sol, 2026-08-20) for the maxio carrier — agent_path=/root/maxio_sdk, brief
   arriving as a `developer` role message. Current release at the time of writing:
   rust-v0.149.0 (2026-08-20).

2. Project-scoped .codex/agents/ loads ONLY in a trusted project. An untrusted project skips
   the .codex/ layer entirely — deliberate, it blocks supply-chain injection of agent
   definitions — so a user who clones the repo and declines the trust prompt gets no agent,
   silently. ~/.codex/agents/ and $CODEX_HOME/agents/ are unaffected.

Treat any Codex result as unverified until the brief is confirmed to have arrived — on an
older bundled build the delivery failure is still silent, and item 2 is unaffected by the fix.
The carriers' headers carry the same warning.

CLAIMS CHECKED AND REJECTED  (2026-08-25)
─────────────────────────────────────────
Earlier research asserted three "silent-failure defects" in the shipped manifests. Two are
wrong and one did not reproduce; recorded here so they are not re-fixed. A fourth rejected
claim was added on 2026-08-27:

0. "The root plugin.json (Agent-Plugin format) CANNOT carry agents, which is why the modern
   plugins quietly dropped VS Code." Wrong. Agent Plugins 1.0 ships custom agents from a
   client-extension namespace — com.github.copilot/agents/*.agent.md — beside the portable
   skills/ folder, and VS Code, Copilot CLI and the Copilot app all load them. The manifest
   does not list them; they are found by convention. So VS Code CAN run these agents.

   What actually blocks us is narrower and real: a .agent.md declares its tools from a
   VS Code-specific vocabulary (search/codebase, web/fetch, read/terminalLastCommand, edit, …)
   that the published docs do not enumerate. These agents need a shell (dotnet build, the lazy
   git clone) and file writes. A guessed tools: list would mis-capability the agent silently,
   so VS Code stays out of scope until those ids are verified against a running instance.

   Separately: the two VS Code manifests that exist (context-matic, acp-paypal) predate
   1.0 — no $schema, and skills/mcpServers/logo/displayName as top-level fields, none of which
   are in the closed 1.0 schema. Unknown fields are ignored rather than rejected, so they are
   not invalid, but those keys do nothing and discovery falls back to convention (skills/,
   mcp.json — note we ship .mcp.json). A conformance pass is worth scheduling.

  "Cursor's agents key takes a directory, so passing a file means the specialist silently
   doesn't exist"  → WRONG. The schema is "agent files or directories". Our manifests are
   valid, and all agent/skill paths in all three Cursor manifests resolve on disk.

  "The Codex carriers document their install location backwards"  → WRONG. The three
   locations they name are the three Codex reads.

  "SendMessage addresses agents by name and the router never says to name the spawn"
   → NOT REPRODUCED. The router mandates exactly one spawn per session, which leaves the
   agent-type name unambiguous as an address. Revisit only if a router ever spawns two.
