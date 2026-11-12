using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Reason for order cancellation. Present only when <c>status</c> is <c>CANCELLED</c>.
/// * CANCELLED_BY_CLIENT — cancelled at the end user's or client's request via the API.
/// * CANCELLED_BY_UPVEST_OPERATIONS — cancelled by Upvest operations.
/// * CANCELLED_BY_TRADING_PARTNER — cancelled by the executing partner.
/// * CANCELLED_BY_UPVEST_PLATFORM — cancelled automatically by the Upvest platform.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CancellationReason>))]
public sealed record CancellationReason : OpenStringEnum<CancellationReason>
{
    private CancellationReason(string value) : base(value)
    {
    }

    public static readonly CancellationReason CancelledByClient = new("CANCELLED_BY_CLIENT");

    public static readonly CancellationReason CancelledByUpvestOperations = new("CANCELLED_BY_UPVEST_OPERATIONS");

    public static readonly CancellationReason CancelledByTradingPartner = new("CANCELLED_BY_TRADING_PARTNER");

    public static readonly CancellationReason CancelledByUpvestPlatform = new("CANCELLED_BY_UPVEST_PLATFORM");

    public TResult Match<TResult>(Func<TResult> onCancelledByClient,
        Func<TResult> onCancelledByUpvestOperations,
        Func<TResult> onCancelledByTradingPartner,
        Func<TResult> onCancelledByUpvestPlatform,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == CancelledByClient => onCancelledByClient(),
            _ when this == CancelledByUpvestOperations => onCancelledByUpvestOperations(),
            _ when this == CancelledByTradingPartner => onCancelledByTradingPartner(),
            _ when this == CancelledByUpvestPlatform => onCancelledByUpvestPlatform(),
            _ => otherwise(Value)
        };

    public void Match(Action onCancelledByClient,
        Action onCancelledByUpvestOperations,
        Action onCancelledByTradingPartner,
        Action onCancelledByUpvestPlatform,
        Action<string> otherwise)
    {
        if (this == CancelledByClient) onCancelledByClient();
        else if (this == CancelledByUpvestOperations) onCancelledByUpvestOperations();
        else if (this == CancelledByTradingPartner) onCancelledByTradingPartner();
        else if (this == CancelledByUpvestPlatform) onCancelledByUpvestPlatform();
        else otherwise(Value);
    }
}
