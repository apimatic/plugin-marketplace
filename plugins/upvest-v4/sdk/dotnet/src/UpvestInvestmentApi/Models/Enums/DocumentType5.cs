using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of document used in the Guardian check. A check carries one document, so a guardian with sole custody submits the birth certificate and the proof of custody as two checks of this type.
/// * BIRTH_CERTIFICATE - Birth certificate proving guardian relationship. Required for every guardian role.
/// * SOLE_CUSTODY_PROOF - Document proving the guardian holds sole custody of the child. Required in addition to the birth certificate when the role identified by role_id has a custody_type of SOLE_CUSTODY, and accepted only for such a role.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DocumentType5>))]
public sealed record DocumentType5 : OpenStringEnum<DocumentType5>
{
    private DocumentType5(string value) : base(value)
    {
    }

    public static readonly DocumentType5 BirthCertificate = new("BIRTH_CERTIFICATE");

    public static readonly DocumentType5 SoleCustodyProof = new("SOLE_CUSTODY_PROOF");

    public TResult Match<TResult>(Func<TResult> onBirthCertificate,
        Func<TResult> onSoleCustodyProof,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BirthCertificate => onBirthCertificate(),
            _ when this == SoleCustodyProof => onSoleCustodyProof(),
            _ => otherwise(Value)
        };

    public void Match(Action onBirthCertificate, Action onSoleCustodyProof, Action<string> otherwise)
    {
        if (this == BirthCertificate) onBirthCertificate();
        else if (this == SoleCustodyProof) onSoleCustodyProof();
        else otherwise(Value);
    }
}
