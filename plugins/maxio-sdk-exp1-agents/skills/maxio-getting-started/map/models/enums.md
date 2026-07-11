# Enums

98 string/int enums. These are `StringEnum<T>` / `IntEnum<T>` records (NOT C# enums) — construct via `Type.FromValue("wireValue")` or the static members. The full accepted value list per enum:

| Enum | Backing | Values | Source |
|---|---|---|---|
| `AllVaults` | StringEnum | `adyen`, `authorizenet`, `beanstream`, `blue_snap`, `bogus`, `braintree1`, `braintree_blue`, `checkout`, `cybersource`, `elavon`, `eway`, `eway_rapid`, `eway_rapid_std`, `firstdata`, `forte`, `gocardless`, `litle`, `maxio_payments`, `maxp`, `moduslink`, `moneris`, `nmi`, `orbital`, `payment_express`, `paymill`, `paypal`, `paypal_complete`, `pin`, `square`, `stripe`, `stripe_connect`, `trust_commerce`, `unipaas`, `wirecard` | `Models/Enums/AllVaults.cs` |
| `AllocationPreviewDirection` | StringEnum | `upgrade`, `downgrade` | `Models/Enums/AllocationPreviewDirection.cs` |
| `AllocationPreviewLineItemKind` | StringEnum | `quantity_based_component`, `on_off_component`, `coupon`, `tax` | `Models/Enums/AllocationPreviewLineItemKind.cs` |
| `ApplePayVault` | StringEnum | `braintree_blue` | `Models/Enums/ApplePayVault.cs` |
| `AutoInvite` | IntEnum | `Value0 = 0`, `Value1 = 1` | `Models/Enums/AutoInvite.cs` |
| `BankAccountHolderType` | StringEnum | `personal`, `business` | `Models/Enums/BankAccountHolderType.cs` |
| `BankAccountType` | StringEnum | `checking`, `savings` | `Models/Enums/BankAccountType.cs` |
| `BankAccountVault` | StringEnum | `authorizenet`, `blue_snap`, `bogus`, `forte`, `gocardless`, `maxio_payments`, `maxp`, `stripe_connect` | `Models/Enums/BankAccountVault.cs` |
| `BasicDateField` | StringEnum | `updated_at`, `created_at` | `Models/Enums/BasicDateField.cs` |
| `BillingManifestLineItemKind` | StringEnum | `baseline`, `initial`, `trial`, `coupon`, `component`, `tax` | `Models/Enums/BillingManifestLineItemKind.cs` |
| `CancellationMethod` | StringEnum | `merchant_ui`, `merchant_api`, `dunning`, `billing_portal`, `unknown`, `imported` | `Models/Enums/CancellationMethod.cs` |
| `CardType` | StringEnum | `visa`, `master`, `elo`, `cabal`, `alelo`, `discover`, `american_express`, `naranja`, `diners_club`, `jcb`, `dankort`, `maestro`, `maestro_no_luhn`, `forbrugsforeningen`, `sodexo`, `alia`, `vr`, `unionpay`, `carnet`, `cartes_bancaires`, `olimpica`, `creditel`, `confiable`, `synchrony`, `routex`, `mada`, `bp_plus`, `passcard`, `edenred`, `anda`, `tarjeta-d`, `hipercard`, `bogus`, `switch`, `solo`, `laser` | `Models/Enums/CardType.cs` |
| `ChargebackStatus` | StringEnum | `open`, `lost`, `won`, `closed` | `Models/Enums/ChargebackStatus.cs` |
| `CleanupScope` | StringEnum | `all`, `customers` | `Models/Enums/CleanupScope.cs` |
| `CollectionMethod` | StringEnum | `automatic`, `remittance`, `prepaid`, `invoice` | `Models/Enums/CollectionMethod.cs` |
| `ComponentKind` | StringEnum | `metered_component`, `quantity_based_component`, `on_off_component`, `prepaid_usage_component`, `event_based_component` | `Models/Enums/ComponentKind.cs` |
| `CompoundingStrategy` | StringEnum | `compound`, `full-price` | `Models/Enums/CompoundingStrategy.cs` |
| `CreateInvoiceStatus` | StringEnum | `draft`, `open` | `Models/Enums/CreateInvoiceStatus.cs` |
| `CreatePrepaymentMethod` | StringEnum | `check`, `cash`, `money_order`, `ach`, `paypal_account`, `credit_card`, `credit_card_on_file`, `other` | `Models/Enums/CreatePrepaymentMethod.cs` |
| `CreateSignupProformaPreviewInclude` | StringEnum | `next_proforma_invoice` | `Models/Enums/CreateSignupProformaPreviewInclude.cs` |
| `CreditCardVault` | StringEnum | `adyen`, `authorizenet`, `beanstream`, `blue_snap`, `bogus`, `braintree1`, `braintree_blue`, `checkout`, `cybersource`, `elavon`, `eway`, `eway_rapid`, `eway_rapid_std`, `firstdata`, `forte`, `litle`, `maxio_payments`, `maxp`, `moduslink`, `moneris`, `nmi`, `orbital`, `payment_express`, `paymill`, `paypal`, `paypal_complete`, `pin`, `square`, `stripe`, `stripe_connect`, `trust_commerce`, `unipaas`, `wirecard` | `Models/Enums/CreditCardVault.cs` |
| `CreditNoteStatus` | StringEnum | `open`, `applied` | `Models/Enums/CreditNoteStatus.cs` |
| `CreditScheme` | StringEnum | `none`, `credit`, `refund` | `Models/Enums/CreditScheme.cs` |
| `CreditType` | StringEnum | `full`, `prorated`, `none` | `Models/Enums/CreditType.cs` |
| `CurrencyPriceRole` | StringEnum | `baseline`, `trial`, `initial` | `Models/Enums/CurrencyPriceRole.cs` |
| `CustomFieldOwner` | StringEnum | `Customer`, `Subscription` | `Models/Enums/CustomFieldOwner.cs` |
| `DebitNoteRole` | StringEnum | `chargeback`, `refund` | `Models/Enums/DebitNoteRole.cs` |
| `DebitNoteStatus` | StringEnum | `open`, `applied`, `banished`, `paid` | `Models/Enums/DebitNoteStatus.cs` |
| `Direction` | StringEnum | `asc`, `desc` | `Models/Enums/Direction.cs` |
| `DiscountType` | StringEnum | `amount`, `percent` | `Models/Enums/DiscountType.cs` |
| `DowngradeCreditCreditType` | StringEnum | `full`, `prorated`, `none` | `Models/Enums/DowngradeCreditCreditType.cs` |
| `EventKey` | StringEnum | `payment_success`, `payment_failure`, `signup_success`, `signup_failure`, `delayed_signup_creation_success`, `delayed_signup_creation_failure`, `billing_date_change`, `expiration_date_change`, `renewal_success`, `renewal_failure`, `subscription_state_change`, `subscription_product_change`, `pending_cancellation_change`, `expiring_card`, `customer_update`, `customer_create`, `customer_delete`, `component_allocation_change`, `metered_usage`, `prepaid_usage`, `upgrade_downgrade_success`, `upgrade_downgrade_failure`, `statement_closed`, `statement_settled`, `subscription_card_update`, `subscription_group_card_update`, `subscription_bank_account_update`, `refund_success`, `refund_failure`, `upcoming_renewal_notice`, `trial_end_notice`, `dunning_step_reached`, `invoice_issued`, `invoice_pending`, `prepaid_subscription_balance_changed`, `subscription_group_signup_success`, `subscription_group_signup_failure`, `direct_debit_payment_paid_out`, `direct_debit_payment_rejected`, `direct_debit_payment_pending`, `pending_payment_created`, `pending_payment_failed`, `pending_payment_completed`, `proforma_invoice_issued`, `subscription_prepayment_account_balance_changed`, `subscription_service_credit_account_balance_changed`, `custom_field_value_change`, `item_price_point_changed`, `renewal_success_recreated`, `renewal_failure_recreated`, `payment_success_recreated`, `payment_failure_recreated`, `subscription_deletion`, `subscription_group_bank_account_update`, `subscription_paypal_account_update`, `subscription_group_paypal_account_update`, `subscription_customer_change`, `account_transaction_changed`, `go_cardless_payment_paid_out`, `go_cardless_payment_rejected`, `go_cardless_payment_pending`, `stripe_direct_debit_payment_paid_out`, `stripe_direct_debit_payment_rejected`, `stripe_direct_debit_payment_pending`, `maxio_payments_direct_debit_payment_paid_out`, `maxio_payments_direct_debit_payment_rejected`, `maxio_payments_direct_debit_payment_pending`, `invoice_in_collections_canceled`, `subscription_added_to_group`, `subscription_removed_from_group`, `chargeback_opened`, `chargeback_lost`, `chargeback_accepted`, `chargeback_closed`, `chargeback_won`, `payment_collection_method_changed`, `component_billing_date_changed`, `chjs_tokenization_failure`, `chjs_tokenization_success`, `subscription_term_renewal_scheduled`, `subscription_term_renewal_pending`, `subscription_term_renewal_activated`, `subscription_term_renewal_removed` | `Models/Enums/EventKey.cs` |
| `ExpirationIntervalUnit` | StringEnum | `day`, `month`, `never` | `Models/Enums/ExpirationIntervalUnit.cs` |
| `FailedPaymentAction` | StringEnum | `leave_open_invoice`, `rollback_to_pending`, `initiate_dunning` | `Models/Enums/FailedPaymentAction.cs` |
| `FirstChargeType` | StringEnum | `prorated`, `immediate`, `delayed` | `Models/Enums/FirstChargeType.cs` |
| `GroupTargetType` | StringEnum | `customer`, `subscription`, `self`, `parent`, `eldest` | `Models/Enums/GroupTargetType.cs` |
| `GroupType` | StringEnum | `single_customer`, `multiple_customers` | `Models/Enums/GroupType.cs` |
| `IncludeNotNull` | StringEnum | `not_null` | `Models/Enums/IncludeNotNull.cs` |
| `IncludeNullOrNotNull` | StringEnum | `not_null`, `null` | `Models/Enums/IncludeNullOrNotNull.cs` |
| `IncludeOption` | StringEnum | `0`, `1` | `Models/Enums/IncludeOption.cs` |
| `IntervalUnit` | StringEnum | `day`, `month` | `Models/Enums/IntervalUnit.cs` |
| `InvoiceConsolidationLevel` | StringEnum | `none`, `child`, `parent` | `Models/Enums/InvoiceConsolidationLevel.cs` |
| `InvoiceDateField` | StringEnum | `created_at`, `due_date`, `issue_date`, `updated_at`, `paid_date` | `Models/Enums/InvoiceDateField.cs` |
| `InvoiceDiscountSourceType` | StringEnum | `Coupon`, `Referral`, `Ad Hoc Coupon` | `Models/Enums/InvoiceDiscountSourceType.cs` |
| `InvoiceDiscountType` | StringEnum | `percentage`, `flat_amount`, `rollover` | `Models/Enums/InvoiceDiscountType.cs` |
| `InvoiceEventPaymentMethod` | StringEnum | `apple_pay`, `bank_account`, `credit_card`, `external`, `paypal_account` | `Models/Enums/InvoiceEventPaymentMethod.cs` |
| `InvoiceEventType` | StringEnum | `issue_invoice`, `apply_credit_note`, `create_credit_note`, `apply_payment`, `apply_debit_note`, `create_debit_note`, `refund_invoice`, `void_invoice`, `void_remainder`, `backport_invoice`, `change_invoice_status`, `change_invoice_collection_method`, `remove_payment`, `failed_payment`, `change_chargeback_status` | `Models/Enums/InvoiceEventType.cs` |
| `InvoicePaymentMethodType` | StringEnum | `credit_card`, `check`, `cash`, `money_order`, `ach`, `other` | `Models/Enums/InvoicePaymentMethodType.cs` |
| `InvoicePaymentType` | StringEnum | `external`, `prepayment`, `service_credit`, `payment` | `Models/Enums/InvoicePaymentType.cs` |
| `InvoiceRole` | StringEnum | `unset`, `signup`, `renewal`, `usage`, `reactivation`, `proration`, `migration`, `adhoc`, `backport`, `backport-balance-reconciliation` | `Models/Enums/InvoiceRole.cs` |
| `InvoiceSortField` | StringEnum | `status`, `total_amount`, `due_amount`, `created_at`, `updated_at`, `issue_date`, `due_date`, `number` | `Models/Enums/InvoiceSortField.cs` |
| `InvoiceStatus` | StringEnum | `draft`, `open`, `paid`, `pending`, `voided`, `canceled`, `processing` | `Models/Enums/InvoiceStatus.cs` |
| `ItemCategory` | StringEnum | `Business Software`, `Consumer Software`, `Digital Services`, `Physical Goods`, `Other` | `Models/Enums/ItemCategory.cs` |
| `LineItemKind` | StringEnum | `baseline`, `initial`, `trial`, `quantity_based_component`, `prepaid_usage_component`, `on_off_component`, `metered_component`, `event_based_component`, `coupon`, `tax` | `Models/Enums/LineItemKind.cs` |
| `LineItemTransactionType` | StringEnum | `charge`, `credit`, `adjustment`, `payment`, `refund`, `info_transaction`, `payment_authorization` | `Models/Enums/LineItemTransactionType.cs` |
| `ListComponentsPricePointsInclude` | StringEnum | `currency_prices` | `Models/Enums/ListComponentsPricePointsInclude.cs` |
| `ListEventsDateField` | StringEnum | `created_at` | `Models/Enums/ListEventsDateField.cs` |
| `ListPrepaymentDateField` | StringEnum | `created_at`, `application_at` | `Models/Enums/ListPrepaymentDateField.cs` |
| `ListProductsInclude` | StringEnum | `prepaid_product_price_point` | `Models/Enums/ListProductsInclude.cs` |
| `ListProductsPricePointsInclude` | StringEnum | `currency_prices` | `Models/Enums/ListProductsPricePointsInclude.cs` |
| `ListSubscriptionComponentsInclude` | StringEnum | `subscription`, `historic_usages` | `Models/Enums/ListSubscriptionComponentsInclude.cs` |
| `ListSubscriptionComponentsSort` | StringEnum | `id`, `updated_at` | `Models/Enums/ListSubscriptionComponentsSort.cs` |
| `MetafieldInput` | StringEnum | `balance_tracker`, `text`, `radio`, `dropdown` | `Models/Enums/MetafieldInput.cs` |
| `PayPalVault` | StringEnum | `braintree_blue`, `paypal`, `moduslink`, `paypal_complete` | `Models/Enums/PayPalVault.cs` |
| `PaymentType` | StringEnum | `credit_card`, `bank_account`, `paypal_account`, `apple_pay` | `Models/Enums/PaymentType.cs` |
| `PrepaymentMethod` | StringEnum | `check`, `cash`, `money_order`, `ach`, `paypal_account`, `credit_card`, `other` | `Models/Enums/PrepaymentMethod.cs` |
| `PricePointType` | StringEnum | `catalog`, `default`, `custom` | `Models/Enums/PricePointType.cs` |
| `PricingScheme` | StringEnum | `stairstep`, `volume`, `per_unit`, `tiered` | `Models/Enums/PricingScheme.cs` |
| `ProformaInvoiceDiscountSourceType` | StringEnum | `Coupon`, `Referral` | `Models/Enums/ProformaInvoiceDiscountSourceType.cs` |
| `ProformaInvoiceRole` | StringEnum | `unset`, `proforma`, `proforma_adhoc`, `proforma_automatic` | `Models/Enums/ProformaInvoiceRole.cs` |
| `ProformaInvoiceStatus` | StringEnum | `draft`, `voided`, `archived` | `Models/Enums/ProformaInvoiceStatus.cs` |
| `ProformaInvoiceTaxSourceType` | StringEnum | `Tax`, `Avalara` | `Models/Enums/ProformaInvoiceTaxSourceType.cs` |
| `ReactivationCharge` | StringEnum | `prorated`, `immediate`, `delayed` | `Models/Enums/ReactivationCharge.cs` |
| `RecurringScheme` | StringEnum | `do_not_recur`, `recur_indefinitely`, `recur_with_duration` | `Models/Enums/RecurringScheme.cs` |
| `ResourceType` | StringEnum | `subscriptions`, `customers` | `Models/Enums/ResourceType.cs` |
| `RestrictionType` | StringEnum | `Component`, `Product` | `Models/Enums/RestrictionType.cs` |
| `ResumptionCharge` | StringEnum | `prorated`, `immediate`, `delayed` | `Models/Enums/ResumptionCharge.cs` |
| `ServiceCreditType` | StringEnum | `Credit`, `Debit` | `Models/Enums/ServiceCreditType.cs` |
| `SortingDirection` | StringEnum | `asc`, `desc` | `Models/Enums/SortingDirection.cs` |
| `Status` | StringEnum | `draft`, `scheduled`, `pending`, `canceled`, `active`, `fulfilled` | `Models/Enums/Status.cs` |
| `SubscriptionDateField` | StringEnum | `current_period_ends_at`, `current_period_starts_at`, `created_at`, `activated_at`, `canceled_at`, `expires_at`, `trial_started_at`, `trial_ended_at`, `updated_at` | `Models/Enums/SubscriptionDateField.cs` |
| `SubscriptionGroupInclude` | StringEnum | `current_billing_amount_in_cents` | `Models/Enums/SubscriptionGroupInclude.cs` |
| `SubscriptionGroupPrepaymentMethod` | StringEnum | `check`, `cash`, `money_order`, `ach`, `paypal_account`, `other` | `Models/Enums/SubscriptionGroupPrepaymentMethod.cs` |
| `SubscriptionGroupsListInclude` | StringEnum | `account_balances` | `Models/Enums/SubscriptionGroupsListInclude.cs` |
| `SubscriptionInclude` | StringEnum | `coupons`, `self_service_page_token` | `Models/Enums/SubscriptionInclude.cs` |
| `SubscriptionListDateField` | StringEnum | `updated_at` | `Models/Enums/SubscriptionListDateField.cs` |
| `SubscriptionListInclude` | StringEnum | `self_service_page_token` | `Models/Enums/SubscriptionListInclude.cs` |
| `SubscriptionPurgeType` | StringEnum | `customer`, `payment_profile` | `Models/Enums/SubscriptionPurgeType.cs` |
| `SubscriptionSort` | StringEnum | `signup_date`, `period_start`, `period_end`, `next_assessment`, `updated_at`, `created_at`, `total_payments`, `id`, `open_balance`, `expires_at` | `Models/Enums/SubscriptionSort.cs` |
| `SubscriptionState` | StringEnum | `pending`, `failed_to_create`, `trialing`, `assessing`, `active`, `soft_failure`, `past_due`, `suspended`, `canceled`, `expired`, `paused`, `unpaid`, `trial_ended`, `on_hold`, `awaiting_signup` | `Models/Enums/SubscriptionState.cs` |
| `SubscriptionStateFilter` | StringEnum | `active`, `canceled`, `expired`, `expired_cards`, `on_hold`, `past_due`, `pending_cancellation`, `pending_renewal`, `suspended`, `trial_ended`, `trialing`, `unpaid` | `Models/Enums/SubscriptionStateFilter.cs` |
| `TaxConfigurationKind` | StringEnum | `custom`, `managed avalara`, `linked avalara`, `digital river` | `Models/Enums/TaxConfigurationKind.cs` |
| `TaxDestinationAddress` | StringEnum | `shipping_then_billing`, `billing_then_shipping`, `shipping_only`, `billing_only` | `Models/Enums/TaxDestinationAddress.cs` |
| `TrialType` | StringEnum | `no_obligation`, `payment_expected` | `Models/Enums/TrialType.cs` |
| `UpgradeChargeCreditType` | StringEnum | `full`, `prorated`, `none` | `Models/Enums/UpgradeChargeCreditType.cs` |
| `WebhookOrder` | StringEnum | `newest_first`, `oldest_first` | `Models/Enums/WebhookOrder.cs` |
| `WebhookStatus` | StringEnum | `successful`, `failed`, `pending`, `paused` | `Models/Enums/WebhookStatus.cs` |
| `WebhookSubscription` | StringEnum | `billing_date_change`, `component_allocation_change`, `chjs_tokenization_failure`, `chjs_tokenization_success`, `customer_create`, `customer_update`, `dunning_step_reached`, `expiring_card`, `expiration_date_change`, `invoice_issued`, `invoice_pending`, `metered_usage`, `payment_failure`, `payment_success`, `direct_debit_payment_pending`, `direct_debit_payment_paid_out`, `direct_debit_payment_rejected`, `prepaid_subscription_balance_changed`, `prepaid_usage`, `refund_failure`, `refund_success`, `renewal_failure`, `renewal_success`, `signup_failure`, `signup_success`, `statement_closed`, `statement_settled`, `subscription_card_update`, `subscription_group_card_update`, `subscription_product_change`, `subscription_state_change`, `trial_end_notice`, `upcoming_renewal_notice`, `upgrade_downgrade_failure`, `upgrade_downgrade_success`, `pending_cancellation_change`, `subscription_prepayment_account_balance_changed`, `subscription_service_credit_account_balance_changed` | `Models/Enums/WebhookSubscription.cs` |
