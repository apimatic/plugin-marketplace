using System.Threading;
using System.Threading.Tasks;
using UpvestInvestmentApi.Core.Models;

namespace UpvestInvestmentApi.Core.ErrorResponse;

internal interface IErrorResponse<TError>
{
    Task<TError> Map(ResponseContext context, CancellationToken cancellationToken);
}
