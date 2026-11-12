using System;
using System.Text.Json.Serialization;
using UpvestInvestmentApi.Models.Enums;

namespace UpvestInvestmentApi.Models;

/// <summary>
/// Entity representing cash transaction reference.
/// </summary>
public record CashTransactionReference
{
    /// <summary>
    /// Unique identifier for a resource of given type.
    /// </summary>
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// Type of the reference.
    /// * ACCOUNT_GROUP - Account group
    /// * CASH_BALANCE_TRANSFER - Cash balance transfer
    /// * CORPORATE_ACTION - Corporate action
    /// * CORPORATE_ACTION_TRANSACTION_ID - Corporate action transaction ID
    /// * CREDIT_FUNDING - Credit Funding
    /// * DIRECT_DEBIT - Direct debit funding request
    /// * EXTERNAL_DIRECT_DEBIT - External direct debit collection
    /// * FEE_COLLECTION - Fee collection
    /// * ISA_TRANSFER - ISA transfer
    /// * ORDER - Order
    /// * ORDER_EXECUTION - Order execution
    /// * PENSION_DE_ALLOWANCE - German pension allowance
    /// * PENSION_DE_ALLOWANCE_UPDATE - German pension allowance update
    /// * TAX_TRANSACTION - Tax transaction
    /// * TOPUP - Cash top up
    /// * TRANSACTION_FEE_EXECUTION - Transaction fee execution
    /// * VIRTUAL_CASH_DECREASE - Virtual cash decreased
    /// * VIRTUAL_CASH_INCREASE - Virtual cash increased
    /// * WITHDRAWAL - Cash withdrawal
    /// </summary>
    [JsonPropertyName("type")]
    public required Type50 Type { get; init; }
}
