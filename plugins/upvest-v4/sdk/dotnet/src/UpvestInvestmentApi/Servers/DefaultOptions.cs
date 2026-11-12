using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Servers;

public class DefaultOptions
{
    public ProductionOptions Production { get; set; } = new();
    public Environment2Options Environment2 { get; set; } = new();

    internal UrlTemplate Resolve(ServerEnvironment environment, string path) =>
        environment.Match(
            () => new UrlTemplate(Production.BaseUrl, path, []),
            () => new UrlTemplate(Environment2.BaseUrl, path, []));

    public class ProductionOptions
    {
        public string BaseUrl { get; set; } = "https://sandbox.upvest.co";
    }

    public class Environment2Options
    {
        public string BaseUrl { get; set; } = "https://api.upvest.co";
    }
}
