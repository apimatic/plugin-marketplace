using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The operation type a transaction fee model is assigned to.
/// * PENSION_DE_CONTRIBUTION -
/// * PENSION_DE_CONTRIBUTION_GOVERNMENT_BONUS -
/// * PENSION_DE_INCOMING_TRANSFER -
/// * PENSION_DE_OUTGOING_TRANSFER -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<TransactionCategory>))]
public sealed record TransactionCategory : OpenStringEnum<TransactionCategory>
{
    private TransactionCategory(string value) : base(value)
    {
    }

    public static readonly TransactionCategory PensionDeContribution = new("PENSION_DE_CONTRIBUTION");

    public static readonly TransactionCategory PensionDeContributionGovernmentBonus = new(
        "PENSION_DE_CONTRIBUTION_GOVERNMENT_BONUS");

    public static readonly TransactionCategory PensionDeIncomingTransfer = new("PENSION_DE_INCOMING_TRANSFER");

    public static readonly TransactionCategory PensionDeOutgoingTransfer = new("PENSION_DE_OUTGOING_TRANSFER");

    public TResult Match<TResult>(Func<TResult> onPensionDeContribution,
        Func<TResult> onPensionDeContributionGovernmentBonus,
        Func<TResult> onPensionDeIncomingTransfer,
        Func<TResult> onPensionDeOutgoingTransfer,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == PensionDeContribution => onPensionDeContribution(),
            _ when this == PensionDeContributionGovernmentBonus => onPensionDeContributionGovernmentBonus(),
            _ when this == PensionDeIncomingTransfer => onPensionDeIncomingTransfer(),
            _ when this == PensionDeOutgoingTransfer => onPensionDeOutgoingTransfer(),
            _ => otherwise(Value)
        };

    public void Match(Action onPensionDeContribution,
        Action onPensionDeContributionGovernmentBonus,
        Action onPensionDeIncomingTransfer,
        Action onPensionDeOutgoingTransfer,
        Action<string> otherwise)
    {
        if (this == PensionDeContribution) onPensionDeContribution();
        else if (this == PensionDeContributionGovernmentBonus) onPensionDeContributionGovernmentBonus();
        else if (this == PensionDeIncomingTransfer) onPensionDeIncomingTransfer();
        else if (this == PensionDeOutgoingTransfer) onPensionDeOutgoingTransfer();
        else otherwise(Value);
    }
}
