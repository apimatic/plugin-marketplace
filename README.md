# APIMatic Context Plugin Catalog

This plugin that helps you maintain and integrate third-party APIs using APIMatic's [Context Plugin Catalog](https://www.apimatic.io) MCP server.

## What it does

When you ask your agent to integrate an external API — Paypal, Maxio, Spotify, or others — this plugin guides it through a structured discovery workflow:

1. **Discover** available API SDKs for your project's language via `list_apis`
2. **Get guidance** on authentication, endpoints, and code samples via `ask`
3. **Look up** specific SDK models and methods via `model_search` and `endpoint_search`

Your agent never guesses at API capabilities — it always queries the official documentation for up-to-date SDK information and code samples.

## Requirements

- No API key required — the Context Plugin Catalog MCP server is publicly accessible

## Installation

### Manual MCP setup

To use the Context Plugin Catalog MCP server without this plugin, add the following to your MCP config:

```json
{
  "mcpServers": {
    "context-plugin-catalog": {
      "url": "https://chatbotapi.apimatic.io/mcp/catalog"
    }
  }
}
```

## Usage

Once installed, describe what you want to build and the skill activates automatically:

- _"Integrate Stripe payments into my checkout flow"_
- _"Add SendGrid email sending to my Node app"_
- _"Set up Twilio SMS notifications in my Python service"_

You can also invoke the skill directly (exact command may vary by tool or editor):

```
/apimatic:context-plugin-catalog integrate Stripe payments
```

## Supported languages

`typescript` · `javascript` · `python` · `csharp` · `java` · `go` · `ruby` · `php`

The language is inferred automatically from your project's files (e.g. `.csproj` → C#, `package.json` + TypeScript → `typescript`).

## Plugin contents

| Path | Purpose |
|---|---|
| `.cursor-plugin/plugin.json` | Plugin manifest |
| `skills/context-plugin-catalog/SKILL.md` | API integration skill |
| `.mcp.json` | APIMatic MCP server configuration |
| `assets/logo.svg` | Plugin logo |
