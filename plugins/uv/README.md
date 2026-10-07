# Upvest Investment API SDK Plugin

A plugin whose skills teach a coding agent to install and use the APIMatic-generated **Upvest Investment API SDK**, in csharp. Every SDK fact the skills state is grounded in the SDK's own source and generated documentation, not in what a model remembers about this API.

## What's inside

One skill set per language. The entry point is that language's getting-started skill, which carries what is specific to this SDK; the rest are API-agnostic and describe how to use any SDK the same generator produces.

| Language | Skill prefix | Skills |
| --- | --- | --- |
| csharp | `csharp-` | `csharp-authentication`, `csharp-calling-endpoints`, `csharp-client-initialization`, `csharp-configuration-resilience`, `csharp-error-handling`, `csharp-getting-started`, `csharp-models`, `csharp-testing` |

## Install

This plugin was **generated for you, not published to a shared plugin marketplace** — so you install it from a local path rather than by name. Point your coding agent at the directory holding this plugin, then install it:

```
/plugin marketplace add <path to the directory containing this plugin>
/plugin install uv
```

In Codex the same two steps are CLI commands:

```
codex plugin marketplace add <path to the directory containing this plugin>
codex plugin add uv@<marketplace>
```

`<marketplace>` is the name the directory you just added registers under — `codex plugin marketplace list` prints it.

Once your team publishes it to a plugin marketplace, add that marketplace in place of the local path and install `uv` from it by name.

Then ask a usage question (e.g. *"how do I authenticate this SDK with an API key?"*) to trigger the relevant skill.

