#!/usr/bin/env python3
"""render — instantiate the plugin skill templates, or prove the shipped files match them.

    python templates/plugin/render.py --check          # every shipped file == render(template, values)
    python templates/plugin/render.py --api paypal     # print the rendered files' paths after writing

The shipped integrate-{api} and {api}-getting-started skills in this repo are GENERATED from
these templates — extracted from the paypal/twilio pair, where both SDKs share generator surface
4.0.0, so every difference between the two copies was by definition an API slot. --check failing
means someone edited a shipped copy directly: make the edit in the template (frame text) or in
values/{api}.json (API content) and re-render, or the copies start drifting apart again — which
is exactly what this layout exists to prevent.

maxio-sdk is NOT a rendering target: it documents the pre-4.0.0 generator surface, and these
templates state 4.0.0 facts in their frames.
"""
import argparse
import io
import json
import os
import re
import sys

HERE = os.path.dirname(os.path.abspath(__file__))
ROOT = os.path.dirname(os.path.dirname(HERE))

TEMPLATES = {
    "integrate": ("integrate/SKILL.md.tmpl", "plugins/{api}-sdk/skills/integrate-{api}/SKILL.md"),
    "getting-started": ("getting-started/SKILL.md.tmpl", "plugins/{api}-sdk/skills/{api}-getting-started/SKILL.md"),
}


def rd(p):
    return io.open(p, encoding="utf-8").read()


def render(tpl, vals):
    out = tpl
    for k, v in vals.items():
        out = out.replace("{{%s}}" % k, v)
    m = re.search(r"\{\{[^}]+\}\}", out)
    if m:
        raise SystemExit("unfilled slot: %s — add it to the values file" % m.group(0))
    return out


def apis():
    vdir = os.path.join(HERE, "values")
    return sorted(f[:-5] for f in os.listdir(vdir) if f.endswith(".json"))


def main():
    ap = argparse.ArgumentParser(description=__doc__,
                                 formatter_class=argparse.RawDescriptionHelpFormatter)
    ap.add_argument("--check", action="store_true",
                    help="compare rendered output against the shipped files; exit 1 on any mismatch")
    ap.add_argument("--api", help="render only this API (default: every values/*.json)")
    args = ap.parse_args()

    failed = 0
    for api in ([args.api] if args.api else apis()):
        vals = json.loads(rd(os.path.join(HERE, "values", api + ".json")))
        for name, (tpl_rel, out_pat) in TEMPLATES.items():
            out_path = os.path.join(ROOT, out_pat.format(api=api))
            text = render(rd(os.path.join(HERE, tpl_rel)), vals)
            if args.check:
                shipped = rd(out_path)
                if shipped == text:
                    print("ok    %s" % out_pat.format(api=api))
                else:
                    failed += 1
                    a, b = shipped.splitlines(), text.splitlines()
                    line = next((i + 1 for i, (x, y) in enumerate(zip(a, b)) if x != y),
                                min(len(a), len(b)) + 1)
                    print("DRIFT %s — first difference at line %d (shipped has been edited "
                          "directly; move the edit into the template or the values file)"
                          % (out_pat.format(api=api), line))
            else:
                io.open(out_path, "w", encoding="utf-8", newline="\n").write(text)
                print("wrote %s" % out_pat.format(api=api))

    # The blueprint tree carries its own copies of the seven static dotnet-* skills; a third
    # copy is a third chance to drift, so --check also proves them byte-identical to shipped.
    if args.check:
        import glob as _glob
        tdir = os.path.join(os.path.dirname(HERE), "plugin-template", "skills")
        for src in sorted(_glob.glob(os.path.join(tdir, "dotnet-*", "*"))):
            rel = os.path.relpath(src, tdir).replace(os.sep, "/")
            shipped = os.path.join(ROOT, "plugins", "paypal-sdk", "skills", rel)
            if rd(shipped) != rd(src):
                failed += 1
                print("DRIFT templates/plugin-template/skills/%s != shipped static — re-copy from "
                      "plugins/paypal-sdk/skills/ (or fix shipped first)" % rel)
        if not failed:
            print("ok    plugin-template statics == shipped statics")
    return 1 if failed else 0


if __name__ == "__main__":
    sys.exit(main())
