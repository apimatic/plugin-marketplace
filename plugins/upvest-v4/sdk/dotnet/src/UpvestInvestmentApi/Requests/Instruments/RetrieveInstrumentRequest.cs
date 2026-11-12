using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Requests.Instruments;

/// <summary>
/// The inputs of the RetrieveInstrument operation.
/// </summary>
public sealed record RetrieveInstrumentRequest
{
    /// <summary>
    /// The unique identifier of the instrument, provided as either an <c>isin:</c> URN or a <c>uuid:</c> URN.
    /// </summary>
    public required InstrumentUniqueIdentifier InstrumentId { get; init; }

    /// <summary>
    /// Upvest API version (Note: Do not include quotation marks)
    /// </summary>
    public UpvestApiVersion UpvestApiVersion { get; init; } = UpvestApiVersion._1;
}
