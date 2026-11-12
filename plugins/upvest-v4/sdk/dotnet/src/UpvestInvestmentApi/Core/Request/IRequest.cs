using System.Net.Http;

namespace UpvestInvestmentApi.Core.Request;

internal interface IRequest
{
    HttpContent Get();

    bool CanRetry { get; }
}
