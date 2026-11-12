using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of document used to proof data change
/// * UTILITY_BILL - Utility bill
/// * TELEPHONE_BILL - Telephone bill
/// * INTERNET_BILL - Internet bill
/// * BANK_STATEMENT - Bank statement
/// * REGISTRATION_CERT - Registration certificate
/// * RESIDENCE_PERMIT - Residence permit
/// * ID_CARD - National Identification document
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DocumentType2>))]
public sealed record DocumentType2 : OpenStringEnum<DocumentType2>
{
    private DocumentType2(string value) : base(value)
    {
    }

    public static readonly DocumentType2 UtilityBill = new("UTILITY_BILL");

    public static readonly DocumentType2 TelephoneBill = new("TELEPHONE_BILL");

    public static readonly DocumentType2 InternetBill = new("INTERNET_BILL");

    public static readonly DocumentType2 BankStatement = new("BANK_STATEMENT");

    public static readonly DocumentType2 RegistrationCert = new("REGISTRATION_CERT");

    public static readonly DocumentType2 ResidencePermit = new("RESIDENCE_PERMIT");

    public static readonly DocumentType2 IdCard = new("ID_CARD");

    public TResult Match<TResult>(Func<TResult> onUtilityBill,
        Func<TResult> onTelephoneBill,
        Func<TResult> onInternetBill,
        Func<TResult> onBankStatement,
        Func<TResult> onRegistrationCert,
        Func<TResult> onResidencePermit,
        Func<TResult> onIdCard,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == UtilityBill => onUtilityBill(),
            _ when this == TelephoneBill => onTelephoneBill(),
            _ when this == InternetBill => onInternetBill(),
            _ when this == BankStatement => onBankStatement(),
            _ when this == RegistrationCert => onRegistrationCert(),
            _ when this == ResidencePermit => onResidencePermit(),
            _ when this == IdCard => onIdCard(),
            _ => otherwise(Value)
        };

    public void Match(Action onUtilityBill,
        Action onTelephoneBill,
        Action onInternetBill,
        Action onBankStatement,
        Action onRegistrationCert,
        Action onResidencePermit,
        Action onIdCard,
        Action<string> otherwise)
    {
        if (this == UtilityBill) onUtilityBill();
        else if (this == TelephoneBill) onTelephoneBill();
        else if (this == InternetBill) onInternetBill();
        else if (this == BankStatement) onBankStatement();
        else if (this == RegistrationCert) onRegistrationCert();
        else if (this == ResidencePermit) onResidencePermit();
        else if (this == IdCard) onIdCard();
        else otherwise(Value);
    }
}
