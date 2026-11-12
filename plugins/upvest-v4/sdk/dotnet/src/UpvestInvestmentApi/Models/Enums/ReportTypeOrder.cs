using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Report type
/// * BUY_ORDER - Buy order
/// * CANCELLED_ORDER - Cancelled buy or sell order (not yet executed, user cancels or trading venue cancelled)
/// * REVOKED_ORDER - Revoked buy or sell order ("Storno")
/// * SELL_ORDER - Sell order
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportTypeOrder>))]
public sealed record ReportTypeOrder : OpenStringEnum<ReportTypeOrder>
{
    private ReportTypeOrder(string value) : base(value)
    {
    }

    public static readonly ReportTypeOrder BuyOrder = new("BUY_ORDER");

    public static readonly ReportTypeOrder CancelledOrder = new("CANCELLED_ORDER");

    public static readonly ReportTypeOrder RevokedOrder = new("REVOKED_ORDER");

    public static readonly ReportTypeOrder SellOrder = new("SELL_ORDER");

    public TResult Match<TResult>(Func<TResult> onBuyOrder,
        Func<TResult> onCancelledOrder,
        Func<TResult> onRevokedOrder,
        Func<TResult> onSellOrder,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BuyOrder => onBuyOrder(),
            _ when this == CancelledOrder => onCancelledOrder(),
            _ when this == RevokedOrder => onRevokedOrder(),
            _ when this == SellOrder => onSellOrder(),
            _ => otherwise(Value)
        };

    public void Match(Action onBuyOrder,
        Action onCancelledOrder,
        Action onRevokedOrder,
        Action onSellOrder,
        Action<string> otherwise)
    {
        if (this == BuyOrder) onBuyOrder();
        else if (this == CancelledOrder) onCancelledOrder();
        else if (this == RevokedOrder) onRevokedOrder();
        else if (this == SellOrder) onSellOrder();
        else otherwise(Value);
    }
}
