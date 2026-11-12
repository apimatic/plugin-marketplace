using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Status of the withdrawal
/// * NEW - Withdrawal is created but not started processing.
/// * PROCESSING - Withdrawal is in processing.
/// * CONFIRMED - Withdrawal was successfully sent to the bank for processing.
/// * CANCELLED - Withdrawal was cancelled. <b>Note</b>: In rare instances, a bank may reject a withdrawal after it has been confirmed.
/// For more information, see the <see href="/documentation/guides/payments/cash_balances/cash_withdrawal#potential-cancellation-after-confirmation">Potential cancellation after confirmation</see> section of the guide.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status34>))]
public sealed record Status34 : OpenStringEnum<Status34>
{
    private Status34(string value) : base(value)
    {
    }

    public static readonly Status34 New = new("NEW");

    public static readonly Status34 Processing = new("PROCESSING");

    public static readonly Status34 Confirmed = new("CONFIRMED");

    public static readonly Status34 Cancelled = new("CANCELLED");

    public TResult Match<TResult>(Func<TResult> onNew,
        Func<TResult> onProcessing,
        Func<TResult> onConfirmed,
        Func<TResult> onCancelled,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == New => onNew(),
            _ when this == Processing => onProcessing(),
            _ when this == Confirmed => onConfirmed(),
            _ when this == Cancelled => onCancelled(),
            _ => otherwise(Value)
        };

    public void Match(Action onNew,
        Action onProcessing,
        Action onConfirmed,
        Action onCancelled,
        Action<string> otherwise)
    {
        if (this == New) onNew();
        else if (this == Processing) onProcessing();
        else if (this == Confirmed) onConfirmed();
        else if (this == Cancelled) onCancelled();
        else otherwise(Value);
    }
}
