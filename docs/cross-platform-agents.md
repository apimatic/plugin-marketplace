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

⚠ TWO SILENT FAILURES, both verified 2026-08-25:

1. Named custom-agent invocation is NOT available in tool-backed sessions. The spawn_agent
   tool surface exposes generic spawning only, with no parameter for "spawn the agent defined
   in .codex/agents/x.toml" — openai/codex#15250, open, labelled bug + tool-calls. Interactive
   CLI binding by name does work: confirmed live on codex-cli 0.147.0 (gpt-5.6-sol,
   2026-08-20) for the maxio carrier, agent_path=/root/maxio_sdk, brief arriving as a
   `developer` role message. So whether our router's "spawn the <api>-sdk agent" instruction
   reaches the brief depends on the session type, and when it does not, the child spawns
   generically with no developer_instructions and nothing errors.

2. Project-scoped .codex/agents/ loads ONLY in a trusted project. An untrusted project skips
   the .codex/ layer entirely — deliberate, it blocks supply-chain injection of agent
   definitions — so a user who clones the repo and declines the trust prompt gets no agent,
   silently. ~/.codex/agents/ and $CODEX_HOME/agents/ are unaffected.

Treat any Codex result as unverified until the brief is confirmed to have arrived. The
carriers' headers carry the same warning.

CLAIMS CHECKED AND REJECTED  (2026-08-25)
─────────────────────────────────────────
Earlier research asserted three "silent-failure defects" in the shipped manifests. Two are
wrong and one did not reproduce; recorded here so they are not re-fixed:

  "Cursor's agents key takes a directory, so passing a file means the specialist silently
   doesn't exist"  → WRONG. The schema is "agent files or directories". Our manifests are
   valid, and all agent/skill paths in all three Cursor manifests resolve on disk.

  "The Codex carriers document their install location backwards"  → WRONG. The three
   locations they name are the three Codex reads.

  "SendMessage addresses agents by name and the router never says to name the spawn"
   → NOT REPRODUCED. The router mandates exactly one spawn per session, which leaves the
   agent-type name unambiguous as an address. Revisit only if a router ever spawns two.
