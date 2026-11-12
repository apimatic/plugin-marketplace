using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Type of documentation supporting the US withholding tax status.
/// * KYC - Withholding status derived from the existing KYC data (non-resident aliens only).
/// * W8-BEN - IRS Form W-8BEN provided by the user (non-resident aliens only).
/// * W9 - IRS Form W-9 provided by the user (US persons only).
/// * UNDOCUMENTED - No documentation is available for the user.
/// <para>
/// For a non-resident alien, "KYC" is accepted for every operating model; whether "W8-BEN" and "UNDOCUMENTED" are also accepted depends on your operating model.
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<UserDocumentationType>))]
public sealed record UserDocumentationType : OpenStringEnum<UserDocumentationType>
{
    private UserDocumentationType(string value) : base(value)
    {
    }

    public static readonly UserDocumentationType Kyc = new("KYC");

    public static readonly UserDocumentationType W8Ben = new("W8-BEN");

    public static readonly UserDocumentationType W9 = new("W9");

    public static readonly UserDocumentationType Undocumented = new("UNDOCUMENTED");

    public TResult Match<TResult>(Func<TResult> onKyc,
        Func<TResult> onW8Ben,
        Func<TResult> onW9,
        Func<TResult> onUndocumented,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Kyc => onKyc(),
            _ when this == W8Ben => onW8Ben(),
            _ when this == W9 => onW9(),
            _ when this == Undocumented => onUndocumented(),
            _ => otherwise(Value)
        };

    public void Match(Action onKyc, Action onW8Ben, Action onW9, Action onUndocumented, Action<string> otherwise)
    {
        if (this == Kyc) onKyc();
        else if (this == W8Ben) onW8Ben();
        else if (this == W9) onW9();
        else if (this == Undocumented) onUndocumented();
        else otherwise(Value);
    }
}
