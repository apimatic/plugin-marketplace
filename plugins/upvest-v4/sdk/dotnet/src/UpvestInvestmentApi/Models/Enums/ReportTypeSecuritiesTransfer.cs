using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Enum;

namespace UpvestInvestmentApi.Models.Enums;

/// <summary>
/// Report type
/// * SECURITIES_TRANSFER_INCOMING - Securities are transferred in
/// * SECURITIES_TRANSFER_OUTGOING - Securities are being transferred out
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportTypeSecuritiesTransfer>))]
public sealed record ReportTypeSecuritiesTransfer : OpenStringEnum<ReportTypeSecuritiesTransfer>
{
    private ReportTypeSecuritiesTransfer(string value) : base(value)
    {
    }

    public static readonly ReportTypeSecuritiesTransfer SecuritiesTransferIncoming = new(
        "SECURITIES_TRANSFER_INCOMING");

    public static readonly ReportTypeSecuritiesTransfer SecuritiesTransferOutgoing = new(
        "SECURITIES_TRANSFER_OUTGOING");

    public TResult Match<TResult>(Func<TResult> onSecuritiesTransferIncoming,
        Func<TResult> onSecuritiesTransferOutgoing,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == SecuritiesTransferIncoming => onSecuritiesTransferIncoming(),
            _ when this == SecuritiesTransferOutgoing => onSecuritiesTransferOutgoing(),
            _ => otherwise(Value)
        };

    public void Match(Action onSecuritiesTransferIncoming,
        Action onSecuritiesTransferOutgoing,
        Action<string> otherwise)
    {
        if (this == SecuritiesTransferIncoming) onSecuritiesTransferIncoming();
        else if (this == SecuritiesTransferOutgoing) onSecuritiesTransferOutgoing();
        else otherwise(Value);
    }
}
