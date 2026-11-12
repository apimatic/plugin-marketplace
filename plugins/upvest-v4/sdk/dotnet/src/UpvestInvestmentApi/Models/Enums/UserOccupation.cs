using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The user's employment/occupation status.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<UserOccupation>))]
public sealed record UserOccupation : OpenStringEnum<UserOccupation>
{
    private UserOccupation(string value) : base(value)
    {
    }

    public static readonly UserOccupation Employee = new("EMPLOYEE");

    public static readonly UserOccupation Homemaker = new("HOMEMAKER");

    public static readonly UserOccupation Pensioner = new("PENSIONER");

    public static readonly UserOccupation PublicOfficial = new("PUBLIC_OFFICIAL");

    public static readonly UserOccupation Unemployed = new("UNEMPLOYED");

    public static readonly UserOccupation SelfEmployedFreelancer = new("SELF_EMPLOYED_FREELANCER");

    public static readonly UserOccupation Student = new("STUDENT");

    public static readonly UserOccupation Trainee = new("TRAINEE");

    public static readonly UserOccupation Other = new("OTHER");

    public TResult Match<TResult>(Func<TResult> onEmployee,
        Func<TResult> onHomemaker,
        Func<TResult> onPensioner,
        Func<TResult> onPublicOfficial,
        Func<TResult> onUnemployed,
        Func<TResult> onSelfEmployedFreelancer,
        Func<TResult> onStudent,
        Func<TResult> onTrainee,
        Func<TResult> onOther,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Employee => onEmployee(),
            _ when this == Homemaker => onHomemaker(),
            _ when this == Pensioner => onPensioner(),
            _ when this == PublicOfficial => onPublicOfficial(),
            _ when this == Unemployed => onUnemployed(),
            _ when this == SelfEmployedFreelancer => onSelfEmployedFreelancer(),
            _ when this == Student => onStudent(),
            _ when this == Trainee => onTrainee(),
            _ when this == Other => onOther(),
            _ => otherwise(Value)
        };

    public void Match(Action onEmployee,
        Action onHomemaker,
        Action onPensioner,
        Action onPublicOfficial,
        Action onUnemployed,
        Action onSelfEmployedFreelancer,
        Action onStudent,
        Action onTrainee,
        Action onOther,
        Action<string> otherwise)
    {
        if (this == Employee) onEmployee();
        else if (this == Homemaker) onHomemaker();
        else if (this == Pensioner) onPensioner();
        else if (this == PublicOfficial) onPublicOfficial();
        else if (this == Unemployed) onUnemployed();
        else if (this == SelfEmployedFreelancer) onSelfEmployedFreelancer();
        else if (this == Student) onStudent();
        else if (this == Trainee) onTrainee();
        else if (this == Other) onOther();
        else otherwise(Value);
    }
}
