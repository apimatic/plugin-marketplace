using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Role type for a business entity.
/// * <c>LEGAL_REPRESENTATIVE</c> — The user is a legal representative of the business.
/// * <c>AUTHORISED_SIGNATORY</c> — The user is authorised to sign documents and make commitments on behalf of the business.
/// * <c>ULTIMATE_BENEFICIAL_OWNER</c> — The user ultimately owns or controls the business.
/// * <c>CONTRACTING_EXECUTIVE</c> — The user is able to enter into contracts on behalf of the business.
/// * <c>TRADER</c> — The user is authorised to place orders on behalf of the business.
/// * <c>SOLE_TRADER</c> — The user places orders on behalf of a sole trader entity.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RoleType1>))]
public sealed record RoleType1 : OpenStringEnum<RoleType1>
{
    private RoleType1(string value) : base(value)
    {
    }

    public static readonly RoleType1 LegalRepresentative = new("LEGAL_REPRESENTATIVE");

    public static readonly RoleType1 AuthorisedSignatory = new("AUTHORISED_SIGNATORY");

    public static readonly RoleType1 UltimateBeneficialOwner = new("ULTIMATE_BENEFICIAL_OWNER");

    public static readonly RoleType1 ContractingExecutive = new("CONTRACTING_EXECUTIVE");

    public static readonly RoleType1 Trader = new("TRADER");

    public static readonly RoleType1 SoleTrader = new("SOLE_TRADER");

    public TResult Match<TResult>(Func<TResult> onLegalRepresentative,
        Func<TResult> onAuthorisedSignatory,
        Func<TResult> onUltimateBeneficialOwner,
        Func<TResult> onContractingExecutive,
        Func<TResult> onTrader,
        Func<TResult> onSoleTrader,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == LegalRepresentative => onLegalRepresentative(),
            _ when this == AuthorisedSignatory => onAuthorisedSignatory(),
            _ when this == UltimateBeneficialOwner => onUltimateBeneficialOwner(),
            _ when this == ContractingExecutive => onContractingExecutive(),
            _ when this == Trader => onTrader(),
            _ when this == SoleTrader => onSoleTrader(),
            _ => otherwise(Value)
        };

    public void Match(Action onLegalRepresentative,
        Action onAuthorisedSignatory,
        Action onUltimateBeneficialOwner,
        Action onContractingExecutive,
        Action onTrader,
        Action onSoleTrader,
        Action<string> otherwise)
    {
        if (this == LegalRepresentative) onLegalRepresentative();
        else if (this == AuthorisedSignatory) onAuthorisedSignatory();
        else if (this == UltimateBeneficialOwner) onUltimateBeneficialOwner();
        else if (this == ContractingExecutive) onContractingExecutive();
        else if (this == Trader) onTrader();
        else if (this == SoleTrader) onSoleTrader();
        else otherwise(Value);
    }
}
