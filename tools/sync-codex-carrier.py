#!/usr/bin/env python3
"""sync-codex-carrier — keep a Codex agent TOML's body identical to its Markdown agent.

Claude Code and Cursor load an agent from `agents/<name>.md`. Codex cannot: it wants a
TOML file keyed on `developer_instructions`. So the same brief lives twice, and
CLAUDE.md says to edit both in the same commit.

That instruction is the whole safety mechanism, which is the problem — nothing checks
it. When the two drift, Claude/Cursor and Codex run *different* briefs and every
cross-harness comparison silently becomes a cross-brief comparison. No error, no
failing test, and the numbers still look like numbers.

    python sync-codex-carrier.py            # rewrite every carrier from its .md
    python sync-codex-carrier.py --check    # exit 1 if any carrier is stale (CI)

The Markdown body is everything after the YAML frontmatter. The TOML keeps its own
header comments, `name` and `description`; only the `developer_instructions` block is
replaced.
"""

from __future__ import annotations

import argparse
import io
import os
import re
import sys

REPO = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))

# (markdown agent, codex carrier) — relative to the repo root.
PAIRS = [
    ("plugins/twilio-sdk/agents/twilio-sdk.md",
     "plugins/twilio-sdk/codex/agents/twilio-sdk.toml"),
    ("plugins/maxio-sdk-merged/agents/maxio-sdk.md",
     "plugins/maxio-sdk-merged/codex/agents/maxio-sdk.toml"),
    ("plugins/paypal-sdk/agents/paypal-sdk.md",
     "plugins/paypal-sdk/codex/agents/paypal-sdk.toml"),
]

OPEN = "developer_instructions = '''\n"
CLOSE = "\n'''"


def read(path: str) -> str:
    return io.open(os.path.join(REPO, path), encoding="utf-8").read()


def md_body(text: str) -> str:
    """Everything after the YAML frontmatter, stripped of trailing blank lines."""
    m = re.match(r"^---\n.*?\n---\n", text, re.S)
    if not m:
        raise SystemExit("no YAML frontmatter found — is this an agent file?")
    return text[m.end():].strip("\n")


def rebuilt(toml_text: str, body: str, carrier: str) -> str:
    i = toml_text.find(OPEN)
    if i < 0:
        raise SystemExit("%s: no `developer_instructions = '''` block" % carrier)
    j = toml_text.find(CLOSE, i + len(OPEN))
    if j < 0:
        raise SystemExit("%s: unterminated developer_instructions block" % carrier)
    if "'''" in body:
        # A literal ''' in the body would close the TOML string early and truncate the
        # brief at that point — silently, which is the failure this tool exists to stop.
        raise SystemExit("%s: the Markdown body contains ''', which cannot be carried "
                         "in a TOML literal string" % carrier)
    return toml_text[:i + len(OPEN)] + body + toml_text[j:]


def main() -> int:
    ap = argparse.ArgumentParser(description=__doc__,
                                 formatter_class=argparse.RawDescriptionHelpFormatter)
    ap.add_argument("--check", action="store_true",
                    help="do not write; exit 1 if any carrier is out of sync")
    args = ap.parse_args()

    stale = []
    for md, carrier in PAIRS:
        body = md_body(read(md))
        current = read(carrier)
        want = rebuilt(current, body, carrier)
        if want == current:
            print("ok    %s" % carrier)
            continue
        if args.check:
            print("STALE %s  (does not match %s)" % (carrier, md))
            stale.append(carrier)
        else:
            io.open(os.path.join(REPO, carrier), "w",
                    encoding="utf-8", newline="\n").write(want)
            print("wrote %s  (from %s)" % (carrier, md))

    if stale:
        print()
        print("%d carrier(s) drifted from their Markdown agent. Codex would run a "
              "different brief from Claude Code and Cursor, and nothing would say so." % len(stale))
        print("Fix: python tools/sync-codex-carrier.py")
        return 1
    return 0


if __name__ == "__main__":
    sys.exit(main())
