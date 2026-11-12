using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

public record IsaTransfersResponse
{
    /// <summary>
    /// The unique identifier of the ISA transfer, as a UUID.
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
    /// Status of the transfer
    /// * NEW - Transfer is created.
    /// * PROCESSING - Transfer is being processed.
    /// * SETTLED - Transfer is completed.
    /// * CANCELLED - Transfer is cancelled.
    /// </summary>
    [JsonPropertyName("status")]
    public required Status81 Status { get; init; }

    /// <summary>
    /// Direction of the ISA transfer
    /// * INCOMING - Transfer is incoming to the user.
    /// </summary>
    [JsonPropertyName("direction")]
    public string Direction { get; } = "INCOMING";

    /// <summary>
    /// Type of the securities transfer
    /// * NO_ISA_MANAGER_CHANGE - Transfer occurs within the same ISA manager.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; } = "NO_ISA_MANAGER_CHANGE";

    /// <summary>
    /// Method of the ISA transfer
    /// * CASH - Cash transfer.
    /// <para>
    /// Other methods can be supported in the future, e.g. IN_SPECIE
    /// </para>
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; } = "CASH";

    /// <summary>
    /// Unique identifier of the user, as a UUID.
    /// </summary>
    [JsonPropertyName("user_id")]
    public required Guid UserId { get; init; }

    /// <summary>
    /// Universally Unique Identifier (UUID) of the account group.
    /// </summary>
    [JsonPropertyName("account_group_id")]
    public required Guid AccountGroupId { get; init; }

    /// <summary>
    /// A positive cash amount, as a decimal string with up to two decimal places.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cash_amount")]
    [RegularExpression("^[0-9]{1,9}(\\.[0-9]{2})?$")]
    public string? CashAmount { get; init; }

    /// <summary>
    /// Alphabetic three-letter <see href="https://www.iso.org/iso-4217-currency-codes.html">ISO 4217</see> currency code.
    /// * GBP — Pound Sterling.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; } = "GBP";

    /// <summary>
    /// Counterparty of the ISA transfer.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("counterparty")]
    public Counterparty2? Counterparty { get; init; }

    /// <summary>
    /// The subscription details of an internal ISA transfer, used to apportion the transfer against the current tax year's allowance.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("current_year_subscription")]
    public CurrentYearSubscription? CurrentYearSubscription { get; init; }
}
