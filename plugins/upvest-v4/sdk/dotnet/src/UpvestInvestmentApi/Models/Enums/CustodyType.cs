using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Custody type for child account groups.
/// * <c>SOLE_CUSTODY</c> — A single guardian has custody of the child account group.
/// * <c>JOINT_CUSTODY</c> — Multiple guardians are required for the child account group.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CustodyType>))]
public sealed record CustodyType : OpenStringEnum<CustodyType>
{
    private CustodyType(string value) : base(value)
    {
    }

    public static readonly CustodyType SoleCustody = new("SOLE_CUSTODY");

    public static readonly CustodyType JointCustody = new("JOINT_CUSTODY");

    public TResult Match<TResult>(Func<TResult> onSoleCustody,
        Func<TResult> onJointCustody,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == SoleCustody => onSoleCustody(),
            _ when this == JointCustody => onJointCustody(),
            _ => otherwise(Value)
        };

    public void Match(Action onSoleCustody, Action onJointCustody, Action<string> otherwise)
    {
        if (this == SoleCustody) onSoleCustody();
        else if (this == JointCustody) onJointCustody();
        else otherwise(Value);
    }
}
