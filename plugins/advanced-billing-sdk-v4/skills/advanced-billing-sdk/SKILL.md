---
name: advanced-billing-sdk
description: >-
  Where to get the AsadAli.AdvancedBilling.Sdk .NET package — how to install it
  from NuGet and where its source code lives. Use this when adding the Advanced
  Billing SDK to a .NET project or locating its source/repository. For setup,
  authentication, and configuration use advanced-billing-sdk-initialization; for calling
  endpoints and handling responses/errors use advanced-billing-sdk-usage.
---

# Advanced Billing SDK (AsadAli.AdvancedBilling.Sdk)

A sample .NET client SDK for an Advanced Billing REST API, generated with APIMatic.

- **NuGet package:** `AsadAli.AdvancedBilling.Sdk`
- **NuGet listing:** https://www.nuget.org/packages/AsadAli.AdvancedBilling.Sdk
- **Target framework:** `netstandard2.0` (consumable from any modern .NET project)

## Install from NuGet

Using the .NET CLI:

```bash
dotnet add package AsadAli.AdvancedBilling.Sdk
```

Using the Package Manager Console:

```powershell
Install-Package AsadAli.AdvancedBilling.Sdk
```

Or add a `PackageReference` directly to your `.csproj` (pin the version you want):

```xml
<ItemGroup>
  <PackageReference Include="AsadAli.AdvancedBilling.Sdk" Version="1.0.0" />
</ItemGroup>
```

> The package's root namespace is `MaxioAdvancedBilling`, and the client type is
> `MaxioAdvancedBillingClient`. Add `using MaxioAdvancedBilling;` to consume it.

## Where the source code lives

- **Repository:** https://github.com/asadali214/advanced-billing-sample-sdk
- **License:** MIT
- **Releases:** new versions are published to NuGet automatically when a GitHub
  Release is created (the release tag, e.g. `v1.0.0`, becomes the package version).

Clone it with:

```bash
git clone https://github.com/asadali214/advanced-billing-sample-sdk.git
```

Notable locations in the repo:

| Path | Contents |
|---|---|
| `MaxioAdvancedBillingClient.cs` | Client class and the list of API controller groups |
| `MaxioAdvancedBillingClientOptions.cs` | All configurable options (environment, retry, auth) |
| `Api/` | One file per API controller (the available operations) |
| `Models/` | Request/response model types |
| `Errors/` | Per-operation typed error types |
| `Core/` | Transport, auth schemes, retry, pagination internals |
| `api-reference.md` | Full operation reference with usage snippets |

## Next steps

- To configure and authenticate the client, use the **advanced-billing-sdk-initialization** skill.
- To call operations and handle responses/errors, use the **advanced-billing-sdk-usage** skill.
