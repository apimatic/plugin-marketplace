using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Request body for creating a securities transfer in either direction.
/// </summary>
public record TransfersSecuritiesTransferCreateRequest
{
    /// <summary>
    /// Direction of the securities transfer
    /// * <c>INCOMING</c> - Securities transfer is incoming to the user.
    /// * <c>OUTGOING</c> - Securities transfer is outgoing from the user.
    /// </summary>
    [JsonPropertyName("direction")]
    public required Direction1 Direction { get; init; }

    /// <summary>
    /// <c>ISIN</c> or other identity (depends on instrument_id_type) of the security to be transferred.
    /// </summary>
    [JsonPropertyName("instrument_id")]
    public required string InstrumentId { get; init; }

    /// <summary>
    /// The kind of identifier given in <c>instrument_id</c>.
    /// * ISIN — International Securities Identification Number.
    /// </summary>
    [JsonPropertyName("instrument_id_type")]
    public string InstrumentIdType { get; } = "ISIN";

    /// <summary>
    /// The quantity of the instrument to move in or out, as a decimal string of at most 15 digits including the decimal place. Only full units settle; fractional quantities are not supported by the SWIFT messaging used for settlement.
    /// </summary>
    [JsonPropertyName("quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Quantity { get; init; }

    /// <summary>
    /// Type of the securities transfer
    /// * NO_OWNER_CHANGE - No change of ownership.
    /// </summary>
    [JsonPropertyName("transfer_type")]
    public string TransferType { get; } = "NO_OWNER_CHANGE";

    /// <summary>
    /// The ID of the user. Either user ID or business ID must be specified.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// The ID of the business. Either user ID or business ID must be specified.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("business_id")]
    public Guid? BusinessId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account.
    /// </summary>
    [JsonPropertyName("account_id")]
    public required Guid AccountId { get; init; }

    /// <summary>
    /// Business Identifier Code (also known as SWIFT-BIC, BIC, SWIFT ID or SWIFT code) <see href="https://en.wikipedia.org/wiki/ISO_9362">ISO 9362</see>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("place_of_settlement")]
    [RegularExpression("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$")]
    public string? PlaceOfSettlement { get; init; }

    /// <summary>
    /// A reference for the securities transfer, set by the client and useful for correlating the transfer with client-side records. For automatic incoming transfers, where the client subscribes to the corresponding webhook, Upvest sets this value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_reference")]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,' ]*$")]
    public string? SettlementReference { get; init; }

    /// <summary>
    /// Counterparty for securities transfer. The <c>type</c> field determines which counterparty variant is present in the payload.
    /// </summary>
    [JsonPropertyName("counterparty")]
    public required SecuritiesTransferCounterpartyBic Counterparty { get; init; }

    /// <summary>
    /// Settlement counterparties for the securities transfer.
    /// When <c>settlement_counterparties</c> is provided, <c>settlement_agent</c> is required. Other participants are optional but must respect the following dependency rules:
    /// * <c>settlement_custodian</c> presence requires <c>settlement_party</c> to be present.
    /// * <c>settlement_intermediary_1</c> presence requires <c>settlement_custodian</c> to be present.
    /// * <c>settlement_intermediary_2</c> presence requires <c>settlement_intermediary_1</c> to be present.
    /// <para>
    ///  Note: <c>settlement_custodian</c> can be provided without an explicit <c>settlement_party</c> since the default <c>counterparty</c> field at transfer level serves as the settlement party.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_counterparties")]
    public SettlementCounterparties? SettlementCounterparties { get; init; }

    /// <summary>
    /// Optional forecast date when the trade takes place. If provided, usually T+1 is sufficient. Depending on the market this means valid working days. Date in YYYY-MM-DD format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trade_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? TradeDate { get; init; }

    /// <summary>
    /// Optional forecast date when the settlement takes place. If provided, usually T+2 is sufficient or trade_date + 1. Depending on the market this means valid working days. Date in YYYY-MM-DD format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("settlement_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? SettlementDate { get; init; }

    /// <summary>
    /// Optional date when the transfer request was received from the end user. If omitted, Upvest defaults <c>order_date</c> to the transfer's <c>created_at</c> timestamp. The regulatory deadline runs from this date. Date in YYYY-MM-DD format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("order_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? OrderDate { get; init; }
}
