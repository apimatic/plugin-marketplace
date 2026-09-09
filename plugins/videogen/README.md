# Videogen SDK Plugin

A plugin whose skills teach a coding agent to install and use the APIMatic-generated **Videogen SDK**, in Python. Every SDK fact the skills state is grounded in the SDK's own source and generated documentation, not in what a model remembers about this API.

## What's inside

One skill set per language. The entry point is that language's getting-started skill, which carries what is specific to this SDK; the rest are API-agnostic and describe how to use any SDK the same generator produces.

| Language | Skill prefix | Skills |
| --- | --- | --- |
| Python | `python-` | `python-authentication`, `python-calling-endpoints`, `python-client-initialization`, `python-configuration-resilience`, `python-error-handling`, `python-getting-started`, `python-integrate-videogen`, `python-models`, `python-testing` |

## Install

This plugin ships in the **APIMatic plugin marketplace**. Add the marketplace, then install by name:

```
/plugin marketplace add apimatic/plugin-marketplace
/plugin install videogen@apimatic
```

In Codex the same two steps are CLI commands:

```
codex plugin marketplace add https://github.com/apimatic/plugin-marketplace
codex plugin add videogen@apimatic
```

Then ask a usage question (e.g. *"how do I authenticate this SDK with an API key?"*) to trigger the relevant skill.

