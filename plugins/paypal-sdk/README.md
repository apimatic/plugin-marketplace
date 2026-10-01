# PayPal SDK Assistant

A plugin whose skills teach a coding agent to install and use the APIMatic-generated **PayPal Server SDK for C#/.NET**
(NuGet package `Darker98.PayPalServerSdk`, source at
[Darker98/paypal-csharp-sdk](https://github.com/Darker98/paypal-csharp-sdk)). Every SDK fact the skills state is
grounded in the SDK's own source and generated map, not in what a model remembers about this API.

## How it works

There is no agent and no MCP server — just skills. The entry point is the router skill
`dotnet-integrate-pay-pal-server-sdk`, a mandatory first step that sets the workflow (write a plan file before editing
any project file, ground every contract fact, load the companion skills the plan names).

The SDK map is **not bundled** in this plugin. It ships inside the SDK source repo (`sdk-map.md` plus `map/operations/`),
so the map and the SDK regenerate together and cannot drift apart. `dotnet-getting-started` tells the agent to take one
shallow clone of the SDK repo into the system temp directory at the start of SDK work and read the map there. The clone is
a read-only reference, never part of the build.

## Skills

Two layers, the same shape for every APIMatic-generated .NET SDK:

| Layer | Skill | What it carries |
| --- | --- | --- |
| Router | `dotnet-integrate-pay-pal-server-sdk` | Mandatory first step: the plan-file gate, contract-sheet labels, required-reading rule |
| SDK-specific | `dotnet-getting-started` | Install, root namespace, environments, auth pattern, how to obtain and use the SDK map |
| API-agnostic usage | `dotnet-client-initialization`, `dotnet-authentication`, `dotnet-calling-endpoints`, `dotnet-models`, `dotnet-error-handling`, `dotnet-configuration-resilience`, `dotnet-testing` | How to use any SDK the same generator produces |

## Install

```
/plugin marketplace add apimatic/plugin-marketplace
/plugin install paypal-sdk@apimatic
```

Then ask a PayPal task in C# (e.g. *"add order creation and capture to my ASP.NET Core checkout"*) to trigger the router skill.

> This is an unofficial, APIMatic-generated SDK. It is not affiliated with or endorsed by PayPal; the official PayPal package is `PayPalServerSDK`.
