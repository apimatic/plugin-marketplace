# Upvest Investment API SDK Plugin

A plugin whose skills teach a coding agent to install and use the APIMatic-generated **Upvest Investment API SDK**, in C#/.NET. Every SDK fact the skills state is grounded in the SDK's own source and generated documentation, not in what a model remembers about this API.

## What's inside

One skill set per language. The entry point is that language's getting-started skill, which carries what is specific to this SDK; the rest are API-agnostic and describe how to use any SDK the same generator produces.

| Language | Skill prefix | Skills |
| --- | --- | --- |
| C#/.NET | `dotnet-` | `dotnet-authentication`, `dotnet-calling-endpoints`, `dotnet-client-initialization`, `dotnet-configuration-resilience`, `dotnet-error-handling`, `dotnet-getting-started`, `dotnet-integrate-upvest-investment-api`, `dotnet-models`, `dotnet-testing` |

## Agents

| Agent | What it does |
| --- | --- |
| `upvest-investment-api-planner` | Writes `upvest-investment-api-plan.md`, the plan and its contract sheet, before any project code is written, and revises it in place. `dotnet-integrate-upvest-investment-api` starts it once the SDK is installed or its source reached, on the main agent's own model. |

How each host gets it:

- **Claude Code** loads it from `scoped/agents/` with the plugin and lists it as `upvest-v4:upvest-investment-api-planner`. Its file sets `model: inherit`, so it runs on the main agent's model.
- **Where no subagent tool lists it** (a host that doesn't load a plugin's agents, or subagents turned off), the main agent says so in one line and writes the plan itself before any code.

## Install

From the APIMatic plugin marketplace, in Claude Code 2.1.275 or later:

```
/plugin install upvest-v4 --marketplace apimatic/plugin-marketplace
```

This plugin was **generated for you, not published to a shared plugin marketplace** — so you install it from a local path rather than by name. Point your coding agent at the directory holding this plugin, then install it:

```
/plugin marketplace add <path to the directory containing this plugin>
/plugin install upvest-v4
```

In Codex the same two steps are CLI commands:

```
codex plugin marketplace add <path to the directory containing this plugin>
codex plugin add upvest-v4@<marketplace>
```

`<marketplace>` is the name the directory you just added registers under — `codex plugin marketplace list` prints it.

Once your team publishes it to a plugin marketplace, add that marketplace in place of the local path and install `upvest-v4` from it by name.

Then ask a usage question (e.g. *"how do I authenticate this SDK with an API key?"*) to trigger the relevant skill.

