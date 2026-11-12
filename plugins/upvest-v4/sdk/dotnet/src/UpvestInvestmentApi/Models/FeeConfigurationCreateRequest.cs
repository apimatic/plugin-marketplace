using System.Collections.Generic;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.AnyOf;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request to create a transaction fee model. Defines the currency, charge method, value type, application type, base amount scope, and the fee tiers. Transaction fee models are immutable once created.
/// </summary>
public record FeeConfigurationCreateRequest
{
    /// <summary>
    /// A human-readable label for the transaction fee model.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * EUR — Euro.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Indicates how the transaction fee is charged.
    /// * <c>CHARGED_BY_CLIENT</c> — The fee is charged by the client as part of post-trade settlement; the fee movement occurs outside Upvest cash balances.
    /// * <c>COLLECTED_BY_UPVEST</c> — The fee is charged by the client and collected by Upvest; the fee amount is debited from the user's Upvest cash balance.
    /// * <c>CHARGED_BY_CLIENT_NET</c> — The fee is charged and collected by the client; the fee amount is deducted from the transaction amount, so the user's Upvest cash balance changes by the net amount.
    /// </summary>
    [JsonPropertyName("charge_method")]
    public required FeeChargeMethod1 ChargeMethod { get; init; }

    /// <summary>
    /// The value type of the transaction fee model.
    /// * <c>ABSOLUTE</c> — Tier fees are fixed cash amounts.
    /// * <c>RELATIVE</c> — Tier fees are percentages of the order value, expressed in basis points.
    /// </summary>
    [JsonPropertyName("value_type")]
    public required ValueTypeEnum ValueType { get; init; }

    /// <summary>
    /// The application type of the transaction fee model.
    /// * <c>VOLUME</c> — The full order value is assessed against the tier thresholds, and the matching tier's fee applies to the total order volume.
    /// </summary>
    [JsonPropertyName("application_type")]
    public string ApplicationType { get; } = "VOLUME";

    /// <summary>
    /// The scope of the base amount that fee tiers are evaluated against.
    /// * <c>GROSS_AMOUNT</c> — Tiers are evaluated against the gross cash amount of the transaction the fee model is applied to (e.g. the total cash value of an order, a contribution or a transfer).
    /// * <c>ORDER</c> — Tiers are evaluated against the total cash value of each order. DEPRECATED: Use <c>GROSS_AMOUNT</c> instead. Existing fee models using <c>ORDER</c> continue to work unchanged.
    /// </summary>
    [JsonPropertyName("base_amount_scope")]
    public required BaseAmountScope BaseAmountScope { get; init; }

    /// <summary>
    /// The tiers of the transaction fee model.
    /// </summary>
    [JsonPropertyName("tiers")]
    public required IReadOnlyList<FeeTier> Tiers { get; init; }
}
