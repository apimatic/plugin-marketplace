#!/usr/bin/env python3
"""Generate codex/agents/maxio-sdk.toml FROM agents/maxio-sdk.md.

WHY THIS IS GENERATED, NOT HAND-WRITTEN. Claude Code and Cursor both read
agents/maxio-sdk.md directly. Codex cannot: it defines a custom subagent as a TOML
file in a config-layer agents/ directory, keyed on `developer_instructions`.

If the TOML were hand-authored it would drift from the .md, and the three agents
would then be running different briefs -- which would silently turn a cross-agent
comparison into a cross-brief comparison. So the TOML is DERIVED: description comes
from the .md frontmatter verbatim, and developer_instructions is the .md body
VERBATIM, byte for byte. Re-run this whenever agents/maxio-sdk.md changes.

The body is emitted as a TOML *literal* multi-line string ('''...'''), which performs
no escape processing, so the bytes survive exactly. Verified 2026-08-20 that the body
contains no ''' sequence and no backslashes, which is what makes that safe; this script
asserts both rather than trusting it.

Usage: python generate-codex-agent.py [--check]
       --check verifies the committed TOML still matches the .md (exit 1 if drifted).
"""
import io, os, re, sys

HERE = os.path.dirname(os.path.abspath(__file__))
PLUGIN = os.path.abspath(os.path.join(HERE, "..", ".."))
MD = os.path.join(PLUGIN, "agents", "maxio-sdk.md")
TOML = os.path.join(HERE, "maxio-sdk.toml")

def build():
    raw = io.open(MD, encoding="utf-8", newline="").read()
    parts = re.split(r"(?m)^---\s*$", raw, maxsplit=2)
    if len(parts) < 3:
        sys.exit(f"{MD}: expected YAML frontmatter delimited by ---")
    fm, body = parts[1], parts[2]

    def fmval(key):
        m = re.search(rf"(?m)^{key}:\s*(.+?)\s*$", fm)
        return m.group(1).strip() if m else None

    name = fmval("name") or "maxio-sdk"
    desc = fmval("description")
    if not desc:
        sys.exit(f"{MD}: frontmatter has no description")

    body = body.strip("\n")
    # The two properties that make the literal-string embedding lossless.
    assert "'''" not in body, "body contains ''' - literal TOML string would break"
    assert "\\" not in body, "body contains a backslash - re-check escaping assumptions"

    Q = chr(39) * 3
    header = [
        "# GENERATED FILE - do not edit by hand.",
        "# Source: plugins/maxio-sdk-merged/agents/maxio-sdk.md",
        "# Regenerate: python codex/agents/generate-codex-agent.py",
        "#",
        "# Codex defines a custom subagent as a TOML file in a config-layer agents/ directory",
        "# (~/.codex/agents/ personal, .codex/agents/ project-scoped, or $CODEX_HOME/agents/).",
        "# It does NOT read a plugin agents/*.md, and .codex-plugin/plugin.json has no agents",
        "# key. So this file is the Codex-shaped carrier for the SAME agent brief that Claude",
        "# Code and Cursor load from the .md - identical instructions, different invocation.",
        "#",
        "# The harness copies this into $CODEX_HOME/agents/ at provision, so benchmark runs",
        "# need no manual install. A human working by hand copies it to .codex/agents/.",
        "",
        'name = "' + name + '"',
        "",
        "description = " + Q + desc + Q,
        "",
        "# VERBATIM body of agents/maxio-sdk.md. Codex delivers this to the child as a",
        "# `developer` role message - the strongest placement short of the system prompt.",
        "developer_instructions = " + Q,
        body,
        Q,
        "",
        "# The agent writes maxio-plan.md, edits handed-over project files, and runs",
        "# `dotnet build`. read-only breaks all three.",
        'sandbox_mode = "workspace-write"',
        "",
        "[sandbox_workspace_write]",
        "# REQUIRED for the lazy SDK clone. Network access defaults to false under",
        "# workspace-write, so `git clone` fails and the agent can never resolve a real map",
        "# gap from source - it would silently degrade to map-only.",
        "network_access = true",
        "",
    ]
    return chr(10).join(header)


def main():
    out = build()
    if "--check" in sys.argv:
        cur = io.open(TOML, encoding="utf-8", newline="").read() if os.path.exists(TOML) else ""
        if cur != out:
            sys.exit("DRIFT: maxio-sdk.toml does not match agents/maxio-sdk.md - regenerate it")
        print("OK: maxio-sdk.toml matches agents/maxio-sdk.md")
        return
    io.open(TOML, "w", encoding="utf-8", newline="").write(out)
    print(f"wrote {TOML} ({len(out)} chars)")

if __name__ == "__main__":
    main()
