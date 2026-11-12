using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// A securities transfer, which moves a position in a single instrument between an Upvest account and an external custodian.
/// </summary>
public record Datum9
{
    /// <summary>
    /// The unique identifier of the securities transfer, as a UUID.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Date and time when the resource was created. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Date and time when the resource was last updated. <see href="https://datatracker.ietf.org/doc/html/rfc3339#section-5.6">RFC 3339-5</see>, <see href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO8601 UTC</see>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTimeOffset UpdatedAt { get; init; }

    /// <summary>
    /// Direction of the securities transfer
    /// * <c>INCOMING</c> - Securities transfer is incoming to the user.
    /// * <c>OUTGOING</c> - Securities transfer is outgoing from the user.
    /// </summary>
    [JsonPropertyName("direction")]
    public required Direction1 Direction { get; init; }

    /// <summary>
    /// Status of the securities transfer
    /// * <c>NEW</c> - Securities transfer is created but not started processing.
    /// * <c>PROCESSING</c> - Securities transfer is in processing.
    /// * <c>SETTLED</c> - Securities transfer was successfully settled.
    /// * <c>CANCELLED</c> - Securities transfer was cancelled.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status79 Status { get; init; }

    /// <summary>
    /// Type of the securities transfer
    /// * <c>NO_OWNER_CHANGE</c> - No change of ownership.
    /// </summary>
    [JsonPropertyName("transfer_type")]
    public string TransferType { get; } = "NO_OWNER_CHANGE";

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
    /// The quantity of instrument to move in or out.
    /// </summary>
    [JsonPropertyName("quantity")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public required string Quantity { get; init; }

    /// <summary>
    /// The quantity of instruments settled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quantity_settled")]
    [RegularExpression("^[0-9]{0,63}(\\.[0-9]{1,27})?$")]
    public string? QuantitySettled { get; init; }

    /// <summary>
    /// The ID of the user. Either user_id or business_id is returned.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; init; }

    /// <summary>
    /// The ID of the business. Either user_id or business_id is returned.
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
    /// A reference for the securities transfer, set by the client and useful for correlating the transfer with client-side records.
    /// </summary>
    [JsonPropertyName("settlement_reference")]
    [RegularExpression("^[0-9A-Za-z+?/\\-:()\\.,' ]*$")]
    public required string SettlementReference { get; init; }

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
    /// The forecast date when the trade takes place. Date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("trade_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset TradeDate { get; init; }

    /// <summary>
    /// The forecast date when the settlement takes place. Date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("settlement_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public required DateTimeOffset SettlementDate { get; init; }

    /// <summary>
    /// The date when the transfer settled, only known in <c>SETTLED</c> status. Date in YYYY-MM-DD format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("actual_settlement_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? ActualSettlementDate { get; init; }

    /// <summary>
    /// Optional. Date the transfer request was received from the end user. The regulatory deadline runs from this date. Date in YYYY-MM-DD format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("order_date")]
    [JsonConverter(typeof(UpvestInvestmentApi.Core.Converters.DateOnlyDateTimeOffsetConverter))]
    public DateTimeOffset? OrderDate { get; init; }

    /// <summary>
    /// Categorised reason why a securities transfer is delayed past the regulatory deadline.
    /// * <c>COUNTERPARTY_NOT_INSTRUCTING</c> - The counterparty has not yet instructed the transfer.
    /// * <c>COUNTERPARTY_NOT_RESPONDING</c> - The counterparty is not responding.
    /// * <c>COUNTERPARTY_DOES_NOT_AGREE_TO_DELIVERY_DETAILS</c> - The counterparty does not agree to the delivery details.
    /// * <c>COUNTERPARTY_NOT_ACCEPTING</c> - The counterparty is not accepting the transfer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("delay_reason")]
    public DelayReasonCode? DelayReason { get; init; }
}
