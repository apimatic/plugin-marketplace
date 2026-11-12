using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// The type of document used in the PoR process. Maximum age of the document is 12 months (stated on the document) applicable for: Utility bills (water, gas, electricity), Telephone bills (only landline), Internet bills, Bank account statements. Documents that need to be still valid - Registration certificate (must be valid and issued within the past 5 years), Residence permit e.g. Blue Card (as long as valid and contains the registration address), ID Card that contains the registration address.
/// * UTILITY_BILL -
/// * TELEPHONE_BILL -
/// * INTERNET_BILL -
/// * BANK_STATEMENT -
/// * REGISTRATION_CERT -
/// * RESIDENCE_PERMIT -
/// * ID_CARD -
/// </summary>
[JsonConverter(typeof(StringEnumConverter<DocumentType7>))]
public sealed record DocumentType7 : OpenStringEnum<DocumentType7>
{
    private DocumentType7(string value) : base(value)
    {
    }

    public static readonly DocumentType7 UtilityBill = new("UTILITY_BILL");

    public static readonly DocumentType7 TelephoneBill = new("TELEPHONE_BILL");

    public static readonly DocumentType7 InternetBill = new("INTERNET_BILL");

    public static readonly DocumentType7 BankStatement = new("BANK_STATEMENT");

    public static readonly DocumentType7 RegistrationCert = new("REGISTRATION_CERT");

    public static readonly DocumentType7 ResidencePermit = new("RESIDENCE_PERMIT");

    public static readonly DocumentType7 IdCard = new("ID_CARD");

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
