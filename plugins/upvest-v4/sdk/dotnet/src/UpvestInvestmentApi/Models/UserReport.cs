using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Core.Models;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A report generated for an end user.
/// </summary>
public record UserReport
{
    /// <summary>
    /// The unique identifier of the report, as a UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// Report type
    /// * ACCOUNT_CLOSING - Securities account closure
    /// * ACCOUNT_OPENING - Securities account opening
    /// * AD_HOC_ACCOUNT_STATEMENT - Ad hoc account statement
    /// * ANNUAL_INCOME_STATEMENT - Annual tax income statement ("Erträgnisaufstellung")
    /// * ANNUAL_TAX_STATEMENT - Annual tax reporting
    /// * BANK_ACCOUNT_CONNECTED - Connect reference bank account
    /// * BUY_ORDER - Buy order
    /// * CANCELLED_ORDER - Cancelled buy or sell order (not yet executed, user cancels or trading venue cancelled)
    /// * CORPORATE_ACTION_CASH_TRANSACTION - cash transaction document (after corporate action)
    /// * CORPORATE_ACTION_SECURITY_TRANSACTION - security transaction document (after corporate action)
    /// * DIRECT_DEBIT_MANDATE - Creation of SEPA direct debit mandate
    /// * EX_POST_COST - Ex-post cost report
    /// * FEE_COLLECTION - Intake of service fees
    /// * FRENCH_IFU - French tax statement (Imprimé fiscal unique)
    /// * GENERIC_COMMUNICATION - Generic communication
    /// * INCOME_DISTRIBUTION - Income distribution report
    /// * LOSS_THRESHOLD - Notification that a holding has depreciated by 10%, or a multiple thereof, against its purchase value
    /// * MONTHLY_BILLING_STATEMENT - Monthly billing activities statement
    /// * ORDER_EX_ANTE_COST - Ex-ante cost report for a single order
    /// * ORDER_EX_ANTE_COST_SAVINGS_PLAN - Ex-ante cost report for a savings plan order
    /// * QUARTERLY_ACCOUNT_STATEMENT - Quarterly account statement
    /// * REVOKED_ORDER - Revoked buy or sell order ("Storno")
    /// * SECURITIES_TRANSFER_INCOMING - Securities are transferred in
    /// * SECURITIES_TRANSFER_OUTGOING - Securities are being transferred out
    /// * SELL_ORDER - Sell order
    /// * TAX_CONSOLIDATED_CERTIFICATE_UK - UK Consolidated Tax Certificate
    /// * TAX_PAYMENT - Tax payment document
    /// * TAX_PREPAYMENT_DE - German tax prepayment (Vorabpauschale)
    /// * TAX_PREPAYMENT_DE_CANCELLATION - German tax prepayment (Vorabpauschale) cancellation
    /// * TAX_REFUND - Tax refund document (after tax optimization)
    /// </summary>
    [JsonPropertyName("type")]
    public required ReportType Type { get; init; }

    /// <summary>
    /// The unique identifier of the report that this report replaces, as a UUID. Populated when a mistrade causes a corrected report to be issued; <c>null</c> otherwise.
    /// </summary>
    [JsonPropertyName("substituted_report_id")]
    public required Guid? SubstitutedReportId { get; init; }

    /// <summary>
    /// The contents of a report, including the account it relates to and references to the resources that triggered it.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("data")]
    public ReportData? Data { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
