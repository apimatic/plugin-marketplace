# Records (`MerchantDefinedSecureInformation` … `PaymentInformation42`)

**Exact coverage: `MerchantDefinedSecureInformation` through `PaymentInformation42`**, alphabetical — these are the literal first and last record names on this page; a name outside that range is on a neighbouring page.

Plain `record` data models (immutable, `init`-only). Each field is `CSharpName (wire_name): Type` —
the parenthesized name is the JSON wire name (`[JsonPropertyName]`). `!req` = C# `required` (must be
set in the object initializer); a trailing `?` on the type = nullable/optional; a field with neither
is optional with a generated default — where the source declares an explicit default it is shown as
`= value`. Summary is the record's XML doc summary (`—` when the source has none). Error-payload
models (the `out` types named by the operation pages' error accessors) are listed here like any
other record. A field whose type is a `OneOf`/`AnyOf` union is tagged `(union)` — construct and
read it via `unions.md` (factories + `TryGet…`), not as a record.
All records on these pages live in namespace `CyberSourceMergedSpec.Models`.

| Record | Summary | Fields | Source |
|---|---|---|---|
| `MerchantDefinedSecureInformation` | The object containing the secure data that the merchant defines. | `Secure1 (secure1): string?`, `Secure2 (secure2): string?`, `Secure3 (secure3): string?`, `Secure4 (secure4): string?` | `Models/MerchantDefinedSecureInformation.cs` |
| `MerchantDescriptor` | — | `Name (name): string?`, `AlternateName (alternateName): string?`, `Contact (contact): string?`, `Address1 (address1): string?`, `Locality (locality): string?`, `Country (country): string?`, `PostalCode (postalCode): string?`, `AdministrativeArea (administrativeArea): string?`, `Phone (phone): string?`, `Url (url): string?`, `CountryOfOrigin (countryOfOrigin): string?`, `StoreId (storeId): string?`, `StoreName (storeName): string?`, `CustomerServicePhoneNumber (customerServicePhoneNumber): string?` | `Models/MerchantDescriptor.cs` |
| `MerchantDescriptor1` | — | `StoreId (storeId): string?`, `StoreName (storeName): string?` | `Models/MerchantDescriptor1.cs` |
| `MerchantDescriptor11` | — | `Name (name): string?`, `Email (email): string?` | `Models/MerchantDescriptor11.cs` |
| `MerchantDescriptor13` | — | `AlternateName (alternateName): string?` | `Models/MerchantDescriptor13.cs` |
| `MerchantDescriptor15` | — | `Name (name): string?`, `Url (url): string?` | `Models/MerchantDescriptor15.cs` |
| `MerchantDescriptor34` | — | `Name (name): string?`, `Url (url): string?` | `Models/MerchantDescriptor34.cs` |
| `MerchantDescriptor36` | — | `Name (name): string?`, `Locality (locality): string?`, `Country (country): string?`, `AdministrativeArea (administrativeArea): string?`, `PostalCode (postalCode): string?`, `Contact (contact): string?`, `Address1 (address1): string?` | `Models/MerchantDescriptor36.cs` |
| `MerchantDescriptor37` | — | `Name (name): string?`, `Locality (locality): string?`, `Country (country): string?` | `Models/MerchantDescriptor37.cs` |
| `MerchantDescriptor38` | — | `Address1 (address1): string?`, `AdministrativeArea (administrativeArea): string?`, `Contact (contact): string?`, `Country (country): string?`, `County (county): string?`, `CustomerServicePhoneNumber (customerServicePhoneNumber): string?`, `Locality (locality): string?`, `Name (name): string?`, `Phone (phone): string?`, `PostalCode (postalCode): string?` | `Models/MerchantDescriptor38.cs` |
| `MerchantDescriptor39` | — | `Name (name): string?` | `Models/MerchantDescriptor39.cs` |
| `MerchantDescriptor6` | — | `PostalCode (postalCode): string?`, `Contact (contact): string?`, `Locality (locality): string?`, `Name (name): string?` | `Models/MerchantDescriptor6.cs` |
| `MerchantInformation` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor?`, `DomainName (domainName): string?`, `SalesOrganizationId (salesOrganizationId): string?`, `CategoryCode (categoryCode): int?`, `CategoryCodeDomestic (categoryCodeDomestic): int?`, `TaxId (taxId): string?`, `VatRegistrationNumber (vatRegistrationNumber): string?`, `CardAcceptorReferenceNumber (cardAcceptorReferenceNumber): string?`, `TransactionLocalDateTime (transactionLocalDateTime): string?`, `ServiceFeeDescriptor (serviceFeeDescriptor): ServiceFeeDescriptor?`, `CancelUrl (cancelUrl): string?`, `SuccessUrl (successUrl): string?`, `FailureUrl (failureUrl): string?`, `ReturnUrl (returnUrl): string?`, `PartnerIdCode (partnerIdCode): string?`, `ServiceLocation (serviceLocation): ServiceLocation?`, `NoteToBuyer (noteToBuyer): string?`, `MerchantName (merchantName): string?` | `Models/MerchantInformation.cs` |
| `MerchantInformation1` | — | `MerchantName (merchantName): string?`, `MerchantDescriptor (merchantDescriptor): MerchantDescriptor1?`, `CategoryCode (categoryCode): string?`, `ReturnUrl (returnUrl): string?` | `Models/MerchantInformation1.cs` |
| `MerchantInformation12` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor6?`, `CategoryCode (categoryCode): int?`, `AdministrativeArea (administrativeArea): string?`, `TransactionLocalDateTime (transactionLocalDateTime): string?`, `CancelUrl (cancelUrl): string?`, `SuccessUrl (successUrl): string?`, `FailureUrl (failureUrl): string?` | `Models/MerchantInformation12.cs` |
| `MerchantInformation15` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor?`, `CancelUrl (cancelUrl): string?`, `SuccessUrl (successUrl): string?`, `FailureUrl (failureUrl): string?`, `NoteToBuyer (noteToBuyer): string?` | `Models/MerchantInformation15.cs` |
| `MerchantInformation17` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor11?`, `CancelUrl (cancelUrl): string?`, `SuccessUrl (successUrl): string?` | `Models/MerchantInformation17.cs` |
| `MerchantInformation18` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor11?` | `Models/MerchantInformation18.cs` |
| `MerchantInformation19` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor34?`, `MerchantName (merchantName): string?` | `Models/MerchantInformation19.cs` |
| `MerchantInformation2` | — | `TransactionLocalDateTime (transactionLocalDateTime): string?` | `Models/MerchantInformation2.cs` |
| `MerchantInformation21` | — | `CategoryCode (categoryCode): int?`, `SubmitLocalDateTime (submitLocalDateTime): string?`, `VatRegistrationNumber (vatRegistrationNumber): string?`, `MerchantDescriptor (merchantDescriptor): MerchantDescriptor36?` | `Models/MerchantInformation21.cs` |
| `MerchantInformation22` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor37?` | `Models/MerchantInformation22.cs` |
| `MerchantInformation23` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor38?` | `Models/MerchantInformation23.cs` |
| `MerchantInformation24` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor39?` | `Models/MerchantInformation24.cs` |
| `MerchantInformation25` | — | `ResellerId (resellerId): string?` | `Models/MerchantInformation25.cs` |
| `MerchantInformation27` | — | `Name (name): string?`, `Phone (phone): string?`, `AddressDetails (addressDetails): AddressDetails?` | `Models/MerchantInformation27.cs` |
| `MerchantInformation3` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor?`, `CardAcceptorReferenceNumber (cardAcceptorReferenceNumber): string?`, `CategoryCode (categoryCode): int?`, `VatRegistrationNumber (vatRegistrationNumber): string?`, `ServiceFeeDescriptor (serviceFeeDescriptor): ServiceFeeDescriptor?`, `TaxId (taxId): string?` | `Models/MerchantInformation3.cs` |
| `MerchantInformation4` | — | `MerchantDescriptor (merchantDescriptor): MerchantDescriptor?`, `CategoryCode (categoryCode): int?`, `VatRegistrationNumber (vatRegistrationNumber): string?`, `CardAcceptorReferenceNumber (cardAcceptorReferenceNumber): string?`, `TaxId (taxId): string?` | `Models/MerchantInformation4.cs` |
| `MerchantInformation7` | — | `CategoryCode (categoryCode): string?` | `Models/MerchantInformation7.cs` |
| `MerchantInformation8` | — | `TransactionLocalDateTime (transactionLocalDateTime): string?` | `Models/MerchantInformation8.cs` |
| `MerchantInitiatedTransaction` | — | `Reason (reason): string?`, `PreviousTransactionId (previousTransactionId): string?`, `OriginalAuthorizedAmount (originalAuthorizedAmount): string?`, `AgreementId (agreementId): string?` | `Models/MerchantInitiatedTransaction.cs` |
| `MerchantInitiatedTransaction1` | — | `PreviousTransactionId (previousTransactionId): string?`, `OriginalAuthorizedAmount (originalAuthorizedAmount): string?` | `Models/MerchantInitiatedTransaction1.cs` |
| `MerchantInitiatedTransactionObject` | — | `Reason (reason): string?`, `PreviousTransactionId (previousTransactionId): string?`, `OriginalAuthorizedAmount (originalAuthorizedAmount): string?`, `AgreementId (agreementId): string?` | `Models/MerchantInitiatedTransactionObject.cs` |
| `Metadata` | — | `Creator (creator): string?` | `Models/Metadata.cs` |
| `Metadata1` | — | `Creator (creator): string?` | `Models/Metadata1.cs` |
| `Metadata2` | — | `CardArt (cardArt): TmsCardArt?`, `Issuer (issuer): Issuer3?`, `Creator (creator): string?` | `Models/Metadata2.cs` |
| `Metadata3` | — | `Creator (creator): string?` | `Models/Metadata3.cs` |
| `Metadata4` | — | `Creator (creator): string?` | `Models/Metadata4.cs` |
| `Method` | — | `Name (name): string?`, `Type (type): string?` | `Models/Method.cs` |
| `Method1` | — | `Name (name): string?` | `Models/Method1.cs` |
| `Method12` | — | `Type (type): string?` | `Models/Method12.cs` |
| `Method13` | — | `Name (name): string?` | `Models/Method13.cs` |
| `Method19` | — | `Name (name): string?` | `Models/Method19.cs` |
| `Method2` | — | `Name (name): string?` | `Models/Method2.cs` |
| `MitReversalRequest` | — | `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation?`, `ReversalInformation (reversalInformation): ReversalInformation?`, `ProcessingInformation (processingInformation): ProcessingInformation3?`, `OrderInformation (orderInformation): OrderInformation4?`, `PointOfSaleInformation (pointOfSaleInformation): PointOfSaleInformation2?`, `DeviceInformation (deviceInformation): DeviceInformation1?`, `ProcessorInformation (processorInformation): ProcessorInformation5?` | `Models/MitReversalRequest.cs` |
| `MitVoidRequest` | — | `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation?`, `PaymentInformation (paymentInformation): PaymentInformation9?`, `OrderInformation (orderInformation): OrderInformation14?`, `ProcessingInformation (processingInformation): ProcessingInformation17?` | `Models/MitVoidRequest.cs` |
| `ModifyBillingAgreement` | — | `AgreementInformation (agreementInformation): AgreementInformation8?`, `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation28?`, `AggregatorInformation (aggregatorInformation): AggregatorInformation5?`, `ConsumerAuthenticationInformation (consumerAuthenticationInformation): ConsumerAuthenticationInformation2?`, `DeviceInformation (deviceInformation): DeviceInformation7?`, `InstallmentInformation (installmentInformation): InstallmentInformation4?`, `MerchantInformation (merchantInformation): MerchantInformation12?`, `OrderInformation (orderInformation): OrderInformation20?`, `PaymentInformation (paymentInformation): PaymentInformation16?`, `ProcessingInformation (processingInformation): ProcessingInformation20?`, `BuyerInformation (buyerInformation): BuyerInformation7?` | `Models/ModifyBillingAgreement.cs` |
| `Morphing` | — | `Count (count): int?`, `FieldName (fieldName): string?`, `InformationCode (informationCode): string?` | `Models/Morphing.cs` |
| `MultiProcessorRouting` | — | `Name (name): string?`, `ResponseCode (responseCode): string?`, `ReasonCode (reasonCode): string?`, `Sequence (sequence): string?` | `Models/MultiProcessorRouting.cs` |
| `NetFundingSummary` | — | `Type (type): string?`, `PaymentSubType (paymentSubType): string?`, `ConveyedCount (conveyedCount): int?`, `ConveyedAmount (conveyedAmount): string?`, `SettledCount (settledCount): int?`, `FundedCount (fundedCount): int?`, `FundedAmount (fundedAmount): string?`, `CurrencyCode (currencyCode): string?` | `Models/NetFundingSummary.cs` |
| `NetTotal` | — | `Currency (currency): string !req`, `Value (value): string !req` | `Models/NetTotal.cs` |
| `Network` | — | `EconomicallyRelatedTxnId (economicallyRelatedTxnId): string?` | `Models/Network.cs` |
| `Network17` | — | `Id (id): string?` | `Models/Network17.cs` |
| `Network45` | — | `Id (id): string?` | `Models/Network45.cs` |
| `Next` | — | `Href (href): string?` | `Models/Next.cs` |
| `Next3` | — | `Href (href): string?`, `Title (title): string?`, `Method (method): string?` | `Models/Next3.cs` |
| `Next4` | — | `Href (href): string?`, `Method (method): string?` | `Models/Next4.cs` |
| `Note` | — | `Time (time): DateTimeOffset?`, `AddedBy (addedBy): string?`, `Comments (comments): string?` | `Models/Note.cs` |
| `NotificationOfChange` | Notification Of Change | `MerchantReferenceNumber (merchantReferenceNumber): string?`, `TransactionReferenceNumber (transactionReferenceNumber): string?`, `Time (time): DateTimeOffset?`, `Code (code): string?`, `AccountType (accountType): string?`, `RoutingNumber (routingNumber): string?`, `AccountNumber (accountNumber): string?`, `ConsumerName (consumerName): string?` | `Models/NotificationOfChange.cs` |
| `ObjectInformation` | — | `Title (title): string?`, `Comment (comment): string?` | `Models/ObjectInformation.cs` |
| `OctCreatePaymentRequest` | — | `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation62?`, `OrderInformation (orderInformation): OrderInformation43?`, `MerchantInformation (merchantInformation): MerchantInformation21?`, `RecipientInformation (recipientInformation): RecipientInformation3?`, `SenderInformation (senderInformation): SenderInformation3?`, `ProcessingInformation (processingInformation): ProcessingInformation61?`, `PaymentInformation (paymentInformation): PaymentInformation37?`, `AggregatorInformation (aggregatorInformation): AggregatorInformation7?` | `Models/OctCreatePaymentRequest.cs` |
| `OctSurcharge` | — | `Amount (amount): string?` | `Models/OctSurcharge.cs` |
| `Options` | — | `Id (id): string?` | `Models/Options.cs` |
| `Options1` | — | `Id (id): string?` | `Models/Options1.cs` |
| `Orchestration` | — | `InfoCodes (infoCodes): IReadOnlyList<string>?` | `Models/Orchestration.cs` |
| `Order` | — | `TotalAmount (totalAmount): string?`, `Currency (currency): string?`, `SubTotalAmount (subTotalAmount): string?`, `HandlingAmount (handlingAmount): string?`, `ShippingAmount (shippingAmount): string?`, `ShippingDiscountAmount (shippingDiscountAmount): string?`, `TaxAmount (taxAmount): string?`, `InsuranceAmount (insuranceAmount): string?`, `GiftWrapAmount (giftWrapAmount): string?` | `Models/Order.cs` |
| `OrderInformation` | — | `ExtensionDays (extensionDays): string?`, `AmountDetails (amountDetails): AmountDetails?`, `BillTo (billTo): BillTo?`, `ShipTo (shipTo): ShipTo?`, `LineItems (lineItems): IReadOnlyList<LineItem>?`, `InvoiceDetails (invoiceDetails): InvoiceDetails?`, `ShippingDetails (shippingDetails): ShippingDetails?`, `DigitalCurrency (digitalCurrency): DigitalCurrency?`, `ReturnsAccepted (returnsAccepted): bool?`, `IsCryptocurrencyPurchase (isCryptocurrencyPurchase): string?`, `CutoffDateTime (cutoffDateTime): string?`, `PreOrder (preOrder): string?`, `PreOrderDate (preOrderDate): string?`, `Reordered (reordered): bool?`, `TotalOffersCount (totalOffersCount): string?` | `Models/OrderInformation.cs` |
| `OrderInformation1` | — | `AmountDetails (amountDetails): AmountDetails2?`, `InvoiceDetails (invoiceDetails): InvoiceDetails2?`, `RewardPointsDetails (rewardPointsDetails): RewardPointsDetails?`, `BillTo (billTo): BillTo1?`, `ShipTo (shipTo): ShipTo1?` | `Models/OrderInformation1.cs` |
| `OrderInformation14` | — | `AmountDetails (amountDetails): AmountDetails5?` | `Models/OrderInformation14.cs` |
| `OrderInformation19` | — | `BillTo (billTo): BillTo6?`, `ShipTo (shipTo): ShipTo6?`, `AmountDetails (amountDetails): AmountDetails22?` | `Models/OrderInformation19.cs` |
| `OrderInformation2` | — | `AmountDetails (amountDetails): AmountDetails3?` | `Models/OrderInformation2.cs` |
| `OrderInformation20` | — | `AmountDetails (amountDetails): AmountDetails23?`, `InvoiceDetails (invoiceDetails): InvoiceDetails12?`, `BillTo (billTo): BillTo7?` | `Models/OrderInformation20.cs` |
| `OrderInformation22` | — | `BillTo (billTo): BillTo9?`, `ShipTo (shipTo): ShipTo7?` | `Models/OrderInformation22.cs` |
| `OrderInformation24` | — | `AmountDetails (amountDetails): AmountDetails26?` | `Models/OrderInformation24.cs` |
| `OrderInformation25` | — | `BillTo (billTo): BillTo11?`, `ShipTo (shipTo): ShipTo8?`, `AmountDetails (amountDetails): AmountDetails27?`, `ShippingDetails (shippingDetails): ShippingDetails5?` | `Models/OrderInformation25.cs` |
| `OrderInformation26` | — | `BillTo (billTo): BillTo12?`, `ShipTo (shipTo): ShipTo9?`, `AmountDetails (amountDetails): AmountDetails28?`, `LineItems (lineItems): IReadOnlyList<LineItem7>?`, `InvoiceDetails (invoiceDetails): InvoiceDetails15?`, `ShippingDetails (shippingDetails): ShippingDetails5?` | `Models/OrderInformation26.cs` |
| `OrderInformation27` | — | `AmountDetails (amountDetails): AmountDetails29?` | `Models/OrderInformation27.cs` |
| `OrderInformation3` | — | `AmountDetails (amountDetails): AmountDetails2?`, `InvoiceDetails (invoiceDetails): InvoiceDetails3?` | `Models/OrderInformation3.cs` |
| `OrderInformation30` | — | `AmountDetails (amountDetails): AmountDetails32?`, `BillTo (billTo): BillTo14?`, `ShipTo (shipTo): ShipTo11?`, `LineItems (lineItems): IReadOnlyList<LineItem9>?`, `InvoiceDetails (invoiceDetails): InvoiceDetails12?` | `Models/OrderInformation30.cs` |
| `OrderInformation31` | — | `AmountDetails (amountDetails): AmountDetails32?`, `ShipTo (shipTo): ShipTo11?`, `LineItems (lineItems): IReadOnlyList<LineItem9>?`, `InvoiceDetails (invoiceDetails): InvoiceDetails12?` | `Models/OrderInformation31.cs` |
| `OrderInformation32` | — | `ShipTo (shipTo): ShipTo13?` | `Models/OrderInformation32.cs` |
| `OrderInformation33` | — | `AmountDetails (amountDetails): AmountDetails34?`, `BillTo (billTo): BillTo20?` | `Models/OrderInformation33.cs` |
| `OrderInformation35` | Contains detailed order-level information. | `AmountDetails (amountDetails): AmountDetails36?`, `PreOrder (preOrder): string?`, `PreOrderDate (preOrderDate): string?`, `CutoffDateTime (cutoffDateTime): string?`, `Reordered (reordered): bool?`, `ShippingDetails (shippingDetails): ShippingDetails8?`, `ShipTo (shipTo): ShipTo27?`, `ReturnsAccepted (returnsAccepted): bool?`, `LineItems (lineItems): IReadOnlyList<LineItem11>?`, `BillTo (billTo): BillTo64?`, `TotalOffersCount (totalOffersCount): string?` | `Models/OrderInformation35.cs` |
| `OrderInformation36` | — | `AmountDetails (amountDetails): AmountDetails37?` | `Models/OrderInformation36.cs` |
| `OrderInformation37` | — | `AmountDetails (amountDetails): AmountDetails38?`, `PreOrder (preOrder): string?`, `PreOrderDate (preOrderDate): string?`, `Reordered (reordered): bool?`, `ShipTo (shipTo): ShipTo27?`, `LineItems (lineItems): IReadOnlyList<LineItem12>?`, `BillTo (billTo): BillTo65?`, `TotalOffersCount (totalOffersCount): string?` | `Models/OrderInformation37.cs` |
| `OrderInformation39` | — | `AmountDetails (amountDetails): AmountDetails40?` | `Models/OrderInformation39.cs` |
| `OrderInformation4` | — | `AmountDetails (amountDetails): AmountDetails6?`, `LineItems (lineItems): IReadOnlyList<LineItem1>?` | `Models/OrderInformation4.cs` |
| `OrderInformation40` | — | `Address (address): Address?`, `BillTo (billTo): BillTo66?`, `ShipTo (shipTo): ShipTo29?`, `LineItems (lineItems): IReadOnlyList<LineItem13>?` | `Models/OrderInformation40.cs` |
| `OrderInformation41` | — | `BillTo (billTo): BillTo67?`, `ShipTo (shipTo): ShipTo30?`, `LineItems (lineItems): IReadOnlyList<LineItem14>?` | `Models/OrderInformation41.cs` |
| `OrderInformation42` | — | `BillTo (billTo): BillTo68?`, `ShipTo (shipTo): ShipTo31?`, `LineItems (lineItems): IReadOnlyList<LineItem15>?` | `Models/OrderInformation42.cs` |
| `OrderInformation43` | — | `AmountDetails (amountDetails): AmountDetails41?`, `BillTo (billTo): BillTo69?`, `IsCryptocurrencyPurchase (isCryptocurrencyPurchase): string?` | `Models/OrderInformation43.cs` |
| `OrderInformation44` | — | `AmountDetails (amountDetails): AmountDetails42?` | `Models/OrderInformation44.cs` |
| `OrderInformation45` | — | `AmountDetails (amountDetails): AmountDetails43?`, `IsCryptoCurrencyPurchase (isCryptoCurrencyPurchase): string?` | `Models/OrderInformation45.cs` |
| `OrderInformation46` | — | `AmountDetails (amountDetails): AmountDetails44?` | `Models/OrderInformation46.cs` |
| `OrderInformation47` | — | `AmountDetails (amountDetails): AmountDetails46 !req` | `Models/OrderInformation47.cs` |
| `OrderInformation48` | — | `AmountDetails (amountDetails): AmountDetails47?` | `Models/OrderInformation48.cs` |
| `OrderInformation49` | — | `AmountDetails (amountDetails): AmountDetails48?` | `Models/OrderInformation49.cs` |
| `OrderInformation52` | — | `AmountDetails (amountDetails): AmountDetails51?` | `Models/OrderInformation52.cs` |
| `OrderInformation53` | — | `AmountDetails (amountDetails): AmountDetails51?`, `BillTo (billTo): BillTo70?` | `Models/OrderInformation53.cs` |
| `OrderInformation55` | — | `AmountDetails (amountDetails): AmountDetails54?` | `Models/OrderInformation55.cs` |
| `OrderInformation57` | — | `BillTo (billTo): BillTo73?`, `ShipTo (shipTo): ShipTo33?`, `LineItems (lineItems): IReadOnlyList<LineItem16>?`, `AmountDetails (amountDetails): AmountDetails57?`, `ShippingDetails (shippingDetails): ShippingDetails9?`, `InvoiceDetails (invoiceDetails): InvoiceDetails19?` | `Models/OrderInformation57.cs` |
| `OrderInformation58` | — | `BillTo (billTo): BillTo74?`, `ShipTo (shipTo): ShipTo34?`, `AmountDetails (amountDetails): AmountDetails5?` | `Models/OrderInformation58.cs` |
| `OrderInformation6` | — | `AmountDetails (amountDetails): AmountDetails9?`, `BillTo (billTo): BillTo2?`, `ShipTo (shipTo): ShipTo2?`, `LineItems (lineItems): IReadOnlyList<LineItem3>?`, `InvoiceDetails (invoiceDetails): InvoiceDetails4?`, `ShippingDetails (shippingDetails): ShippingDetails1?` | `Models/OrderInformation6.cs` |
| `OrderInformation60` | Contains all of the order-related fields, such as the amount and line item details. | `AmountDetails (amountDetails): AmountDetails60 !req`, `LineItems (lineItems): IReadOnlyList<LineItem17>?` | `Models/OrderInformation60.cs` |
| `OrderInformation61` | Contains all of the order-related fields, such as the amount and line item details. | `AmountDetails (amountDetails): AmountDetails61?`, `LineItems (lineItems): IReadOnlyList<LineItem17>?` | `Models/OrderInformation61.cs` |
| `OrderInformation62` | Contains all of the order-related fields, such as the amount and line item details. | `AmountDetails (amountDetails): AmountDetails62?` | `Models/OrderInformation62.cs` |
| `OrderInformation7` | — | `AmountDetails (amountDetails): AmountDetails10?`, `InvoiceDetails (invoiceDetails): InvoiceDetails5?` | `Models/OrderInformation7.cs` |
| `OrderInformation8` | — | `AmountDetails (amountDetails): AmountDetails9?`, `BillTo (billTo): BillTo2?`, `ShipTo (shipTo): ShipTo2?`, `LineItems (lineItems): IReadOnlyList<LineItem4>?`, `InvoiceDetails (invoiceDetails): InvoiceDetails4?`, `ShippingDetails (shippingDetails): ShippingDetails2?`, `DigitalCurrency (digitalCurrency): DigitalCurrency?` | `Models/OrderInformation8.cs` |
| `OrderInformation9` | — | `AmountDetails (amountDetails): AmountDetails12?`, `InvoiceDetails (invoiceDetails): InvoiceDetails5?` | `Models/OrderInformation9.cs` |
| `OrderPaymentRequest` | — | `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation3?`, `ProcessingInformation (processingInformation): ProcessingInformation21?`, `PaymentInformation (paymentInformation): PaymentInformation20?`, `OrderInformation (orderInformation): OrderInformation24?` | `Models/OrderPaymentRequest.cs` |
| `OriginatorInitiatedTransaction` | — | `OriginalTransactionId (originalTransactionId): string?`, `Reason (reason): string?` | `Models/OriginatorInitiatedTransaction.cs` |
| `Other` | Other Merchant Details Values. | `RequestId (requestId): string?`, `MerchantData1 (merchantData1): string?`, `MerchantData2 (merchantData2): string?`, `MerchantData3 (merchantData3): string?`, `MerchantData4 (merchantData4): string?`, `FirstName (firstName): string?`, `LastName (lastName): string?` | `Models/Other.cs` |
| `Partner` | — | `OriginalTransactionId (originalTransactionId): string?`, `DeveloperId (developerId): string?`, `SolutionId (solutionId): string?`, `ThirdPartyCertificationNumber (thirdPartyCertificationNumber): string?` | `Models/Partner.cs` |
| `Partner1` | — | `OriginalTransactionId (originalTransactionId): string?`, `DeveloperId (developerId): string?`, `SolutionId (solutionId): string?` | `Models/Partner1.cs` |
| `Partner16` | — | `DeveloperId (developerId): string?`, `SolutionId (solutionId): string?` | `Models/Partner16.cs` |
| `Partner2` | — | `DeveloperId (developerId): string?`, `SolutionId (solutionId): string?`, `ThirdPartyCertificationNumber (thirdPartyCertificationNumber): string?` | `Models/Partner2.cs` |
| `Partner33` | — | `SolutionId (solutionId): string?`, `ThirdPartyCertificationNumber (thirdPartyCertificationNumber): string?` | `Models/Partner33.cs` |
| `Partner34` | — | `SolutionId (solutionId): string?` | `Models/Partner34.cs` |
| `Partner35` | — | `OriginalTransactionId (originalTransactionId): string?` | `Models/Partner35.cs` |
| `Partner38` | — | `DeveloperId (developerId): string?`, `SolutionId (solutionId): string?` | `Models/Partner38.cs` |
| `Passcode` | Passcode by issuer for ID&amp;V. | `Value (value): string?` | `Models/Passcode.cs` |
| `Passenger` | Contains travel-related passenger details used by DM service only. | `Type (type): string?`, `Status (status): string?`, `Phone (phone): string?`, `FirstName (firstName): string?`, `LastName (lastName): string?`, `Id (id): string?`, `Email (email): string?`, `Nationality (nationality): string?` | `Models/Passenger.cs` |
| `Passenger3` | — | `FirstName (firstName): string?`, `LastName (lastName): string?` | `Models/Passenger3.cs` |
| `PassiveProfile` | — | `Name (name): string?`, `Decision (decision): string?` | `Models/PassiveProfile.cs` |
| `PassiveRule` | Names of one or more rules that were processed, and the decisions made by the rules. | `Name (name): string?`, `Decision (decision): string?` | `Models/PassiveRule.cs` |
| `PatchCustomerException` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchCustomerException.cs` |
| `PatchCustomerException1` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchCustomerException1.cs` |
| `PatchCustomerException2` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchCustomerException2.cs` |
| `PatchCustomerException21` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchCustomerException21.cs` |
| `PatchCustomerException3` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchCustomerException3.cs` |
| `PatchCustomerException31` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchCustomerException31.cs` |
| `PatchCustomerException4` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchCustomerException4.cs` |
| `PatchCustomerException41` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchCustomerException41.cs` |
| `PatchCustomerException5` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchCustomerException5.cs` |
| `PatchCustomerException51` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchCustomerException51.cs` |
| `PatchCustomerException6` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchCustomerException6.cs` |
| `PatchCustomerException61` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchCustomerException61.cs` |
| `PatchCustomerException7` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchCustomerException7.cs` |
| `PatchCustomerException71` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchCustomerException71.cs` |
| `PatchCustomerPaymentInstrumentRequest` | — | `Links (_links): Links20?`, `Id (id): string?`, `Object (object): string?`, `Default (default): bool?`, `State (state): string?`, `Type (type): string?`, `BankAccount (bankAccount): BankAccount?`, `Card (card): Card13?`, `BuyerInformation (buyerInformation): BuyerInformation13?`, `BillTo (billTo): BillTo15?`, `ProcessingInformation (processingInformation): TmsPaymentInstrumentProcessingInfo?`, `MerchantInformation (merchantInformation): TmsMerchantInformation?`, `InstrumentIdentifier (instrumentIdentifier): InstrumentIdentifier10?`, `Metadata (metadata): Metadata1?`, `Embedded (_embedded): Embedded1?` | `Models/PatchCustomerPaymentInstrumentRequest.cs` |
| `PatchCustomerRequest` | — | `Links (_links): Links19?`, `Id (id): string?`, `ObjectInformation (objectInformation): ObjectInformation?`, `BuyerInformation (buyerInformation): BuyerInformation12?`, `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation42?`, `MerchantDefinedInformation (merchantDefinedInformation): IReadOnlyList<MerchantDefinedInformation7>?`, `DefaultPaymentInstrument (defaultPaymentInstrument): DefaultPaymentInstrument?`, `DefaultShippingAddress (defaultShippingAddress): DefaultShippingAddress?`, `Metadata (metadata): Metadata?`, `Embedded (_embedded): Embedded?` | `Models/PatchCustomerRequest.cs` |
| `PatchCustomerResponse` | — | `Links (_links): Links19?`, `Id (id): string?`, `ObjectInformation (objectInformation): ObjectInformation?`, `BuyerInformation (buyerInformation): BuyerInformation12?`, `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation42?`, `MerchantDefinedInformation (merchantDefinedInformation): IReadOnlyList<MerchantDefinedInformation7>?`, `DefaultPaymentInstrument (defaultPaymentInstrument): DefaultPaymentInstrument?`, `DefaultShippingAddress (defaultShippingAddress): DefaultShippingAddress?`, `Metadata (metadata): Metadata?`, `Embedded (_embedded): Embedded?` | `Models/PatchCustomerResponse.cs` |
| `PatchCustomerShippingAddressRequest` | — | `Links (_links): Links26?`, `Id (id): string?`, `Default (default): bool?`, `ShipTo (shipTo): ShipTo14?`, `Metadata (metadata): Metadata4?` | `Models/PatchCustomerShippingAddressRequest.cs` |
| `PatchCustomersPaymentInstrumentException` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException.cs` |
| `PatchCustomersPaymentInstrumentException1` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException1.cs` |
| `PatchCustomersPaymentInstrumentException2` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException2.cs` |
| `PatchCustomersPaymentInstrumentException21` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException21.cs` |
| `PatchCustomersPaymentInstrumentException3` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException3.cs` |
| `PatchCustomersPaymentInstrumentException31` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException31.cs` |
| `PatchCustomersPaymentInstrumentException4` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException4.cs` |
| `PatchCustomersPaymentInstrumentException41` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException41.cs` |
| `PatchCustomersPaymentInstrumentException5` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchCustomersPaymentInstrumentException5.cs` |
| `PatchCustomersPaymentInstrumentException51` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchCustomersPaymentInstrumentException51.cs` |
| `PatchCustomersPaymentInstrumentException6` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException6.cs` |
| `PatchCustomersPaymentInstrumentException61` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException61.cs` |
| `PatchCustomersPaymentInstrumentException7` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException7.cs` |
| `PatchCustomersPaymentInstrumentException71` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchCustomersPaymentInstrumentException71.cs` |
| `PatchCustomersShippingAddressException` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchCustomersShippingAddressException.cs` |
| `PatchCustomersShippingAddressException1` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchCustomersShippingAddressException1.cs` |
| `PatchCustomersShippingAddressException2` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchCustomersShippingAddressException2.cs` |
| `PatchCustomersShippingAddressException21` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchCustomersShippingAddressException21.cs` |
| `PatchCustomersShippingAddressException3` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchCustomersShippingAddressException3.cs` |
| `PatchCustomersShippingAddressException31` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchCustomersShippingAddressException31.cs` |
| `PatchCustomersShippingAddressException4` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchCustomersShippingAddressException4.cs` |
| `PatchCustomersShippingAddressException41` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchCustomersShippingAddressException41.cs` |
| `PatchCustomersShippingAddressException5` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchCustomersShippingAddressException5.cs` |
| `PatchCustomersShippingAddressException51` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchCustomersShippingAddressException51.cs` |
| `PatchCustomersShippingAddressException6` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchCustomersShippingAddressException6.cs` |
| `PatchCustomersShippingAddressException61` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchCustomersShippingAddressException61.cs` |
| `PatchCustomersShippingAddressException7` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchCustomersShippingAddressException7.cs` |
| `PatchCustomersShippingAddressException71` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchCustomersShippingAddressException71.cs` |
| `PatchCustomersShippingAddressResponse` | — | `Links (_links): Links26?`, `Id (id): string?`, `Default (default): bool?`, `ShipTo (shipTo): ShipTo14?`, `Metadata (metadata): Metadata4?` | `Models/PatchCustomersShippingAddressResponse.cs` |
| `PatchInstrumentIdentifierException` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchInstrumentIdentifierException.cs` |
| `PatchInstrumentIdentifierException1` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchInstrumentIdentifierException1.cs` |
| `PatchInstrumentIdentifierException2` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchInstrumentIdentifierException2.cs` |
| `PatchInstrumentIdentifierException21` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchInstrumentIdentifierException21.cs` |
| `PatchInstrumentIdentifierException3` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchInstrumentIdentifierException3.cs` |
| `PatchInstrumentIdentifierException31` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchInstrumentIdentifierException31.cs` |
| `PatchInstrumentIdentifierException4` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchInstrumentIdentifierException4.cs` |
| `PatchInstrumentIdentifierException41` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchInstrumentIdentifierException41.cs` |
| `PatchInstrumentIdentifierException5` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchInstrumentIdentifierException5.cs` |
| `PatchInstrumentIdentifierException51` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchInstrumentIdentifierException51.cs` |
| `PatchInstrumentIdentifierException6` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchInstrumentIdentifierException6.cs` |
| `PatchInstrumentIdentifierException61` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchInstrumentIdentifierException61.cs` |
| `PatchInstrumentIdentifierException7` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchInstrumentIdentifierException7.cs` |
| `PatchInstrumentIdentifierException71` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchInstrumentIdentifierException71.cs` |
| `PatchInstrumentIdentifierRequest` | — | `Links (_links): Links21?`, `Id (id): string?`, `Object (object): string?`, `State (state): string?`, `Type (type): string?`, `Source (source): string?`, `TokenProvisioningInformation (tokenProvisioningInformation): TokenProvisioningInformation?`, `Card (card): Card14?`, `PointOfSaleInformation (pointOfSaleInformation): TmsPointOfSaleInformation?`, `BankAccount (bankAccount): BankAccount1?`, `TokenizedCard (tokenizedCard): Tmsv2TokenizedCard?`, `Issuer (issuer): Issuer4?`, `ProcessingInformation (processingInformation): ProcessingInformation29?`, `BillTo (billTo): BillTo16?`, `Metadata (metadata): Metadata3?`, `Embedded (_embedded): Embedded2?` | `Models/PatchInstrumentIdentifierRequest.cs` |
| `PatchInstrumentIdentifierResponse` | — | `Links (_links): Links21?`, `Id (id): string?`, `Object (object): string?`, `State (state): string?`, `Type (type): string?`, `Source (source): string?`, `TokenProvisioningInformation (tokenProvisioningInformation): TokenProvisioningInformation?`, `Card (card): Card14?`, `PointOfSaleInformation (pointOfSaleInformation): TmsPointOfSaleInformation?`, `BankAccount (bankAccount): BankAccount1?`, `TokenizedCard (tokenizedCard): Tmsv2TokenizedCard?`, `Issuer (issuer): Issuer4?`, `ProcessingInformation (processingInformation): ProcessingInformation29?`, `BillTo (billTo): BillTo16?`, `Metadata (metadata): Metadata3?`, `Embedded (_embedded): Embedded2?` | `Models/PatchInstrumentIdentifierResponse.cs` |
| `PatchPaymentInstrumentException` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchPaymentInstrumentException.cs` |
| `PatchPaymentInstrumentException1` | — | `Errors (errors): IReadOnlyList<Tms400ResponseError>?` | `Models/PatchPaymentInstrumentException1.cs` |
| `PatchPaymentInstrumentException2` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchPaymentInstrumentException2.cs` |
| `PatchPaymentInstrumentException21` | — | `Errors (errors): IReadOnlyList<Tms403ResponseError>?` | `Models/PatchPaymentInstrumentException21.cs` |
| `PatchPaymentInstrumentException3` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchPaymentInstrumentException3.cs` |
| `PatchPaymentInstrumentException31` | — | `Errors (errors): IReadOnlyList<Tms404ResponseError>?` | `Models/PatchPaymentInstrumentException31.cs` |
| `PatchPaymentInstrumentException4` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchPaymentInstrumentException4.cs` |
| `PatchPaymentInstrumentException41` | — | `Errors (errors): IReadOnlyList<Tms410ResponseError>?` | `Models/PatchPaymentInstrumentException41.cs` |
| `PatchPaymentInstrumentException5` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchPaymentInstrumentException5.cs` |
| `PatchPaymentInstrumentException51` | — | `Errors (errors): IReadOnlyList<Error7>?` | `Models/PatchPaymentInstrumentException51.cs` |
| `PatchPaymentInstrumentException6` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchPaymentInstrumentException6.cs` |
| `PatchPaymentInstrumentException61` | — | `Errors (errors): IReadOnlyList<Tms424ResponseError>?` | `Models/PatchPaymentInstrumentException61.cs` |
| `PatchPaymentInstrumentException7` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchPaymentInstrumentException7.cs` |
| `PatchPaymentInstrumentException71` | — | `Errors (errors): IReadOnlyList<Tms500ResponseError>?` | `Models/PatchPaymentInstrumentException71.cs` |
| `PatchPaymentInstrumentRequest` | — | `Links (_links): Links20?`, `Id (id): string?`, `Object (object): string?`, `Default (default): bool?`, `State (state): string?`, `Type (type): string?`, `BankAccount (bankAccount): BankAccount?`, `Card (card): Card13?`, `BuyerInformation (buyerInformation): BuyerInformation13?`, `BillTo (billTo): BillTo15?`, `ProcessingInformation (processingInformation): TmsPaymentInstrumentProcessingInfo?`, `MerchantInformation (merchantInformation): TmsMerchantInformation?`, `InstrumentIdentifier (instrumentIdentifier): InstrumentIdentifier10?`, `Metadata (metadata): Metadata1?`, `Embedded (_embedded): Embedded1?` | `Models/PatchPaymentInstrumentRequest.cs` |
| `PayerAuthSetupRequest` | — | `ClientReferenceInformation (clientReferenceInformation): ClientReferenceInformation48?`, `PaymentInformation (paymentInformation): PaymentInformation33?`, `ProcessingInformation (processingInformation): ProcessingInformation57?`, `TokenInformation (tokenInformation): TokenInformation6?` | `Models/PayerAuthSetupRequest.cs` |
| `PaymentAccountInformation` | — | `Card (card): Card1?`, `TokenizedCard (tokenizedCard): TokenizedCard1?` | `Models/PaymentAccountInformation.cs` |
| `PaymentAccountInformation1` | — | `Card (card): Card1?` | `Models/PaymentAccountInformation1.cs` |
| `PaymentAccountInformation2` | — | `Card (card): Card16?`, `Features (features): Features?`, `Network (network): Network17?` | `Models/PaymentAccountInformation2.cs` |
| `PaymentAccountReference` | — | `Id (id): string?` | `Models/PaymentAccountReference.cs` |
| `PaymentBatchSummary` | — | `CurrencyCode (currencyCode): string?`, `PaymentSubTypeDescription (paymentSubTypeDescription): string?`, `StartTime (startTime): DateTimeOffset?`, `EndTime (endTime): DateTimeOffset?`, `SalesCount (salesCount): int?`, `SalesAmount (salesAmount): string?`, `CreditCount (creditCount): int?`, `CreditAmount (creditAmount): string?`, `AccountName (accountName): string?`, `AccountId (accountId): string?`, `MerchantId (merchantId): string?`, `MerchantName (merchantName): string?` | `Models/PaymentBatchSummary.cs` |
| `PaymentInformation` | — | `Card (card): Card?`, `TokenizedCard (tokenizedCard): TokenizedCard?`, `TokenizedPaymentMethod (tokenizedPaymentMethod): TokenizedPaymentMethod?`, `DirectDebit (directDebit): DirectDebit?`, `FluidData (fluidData): FluidData?`, `Customer (customer): Customer?`, `PaymentInstrument (paymentInstrument): PaymentInstrument?`, `InstrumentIdentifier (instrumentIdentifier): InstrumentIdentifier?`, `ShippingAddress (shippingAddress): ShippingAddress?`, `LegacyToken (legacyToken): LegacyToken?`, `Bank (bank): Bank?`, `Options (options): Options?`, `PaymentType (paymentType): PaymentType?`, `InitiationChannel (initiationChannel): string?`, `Sepa (sepa): Sepa?`, `EWallet (eWallet): EWallet?`, `PaymentAccountReference (paymentAccountReference): PaymentAccountReference?`, `ThirdPartyToken (thirdPartyToken): ThirdPartyToken?`, `MerchantLimitedAcceptanceIndicator (merchantLimitedAcceptanceIndicator): string?` | `Models/PaymentInformation.cs` |
| `PaymentInformation1` | — | `Card (card): Card1?`, `TokenizedCard (tokenizedCard): TokenizedCard1?`, `TokenizedPaymentMethod (tokenizedPaymentMethod): TokenizedPaymentMethod1?`, `AccountFeatures (accountFeatures): AccountFeatures?`, `Bank (bank): Bank1?`, `Customer (customer): Customer?`, `PaymentInstrument (paymentInstrument): PaymentInstrument?`, `InstrumentIdentifier (instrumentIdentifier): InstrumentIdentifier2?`, `ShippingAddress (shippingAddress): ShippingAddress?`, `Scheme (scheme): string?`, `Bin (bin): string?`, `AccountType (accountType): string?`, `Issuer (issuer): string?`, `BinCountry (binCountry): string?`, `EWallet (eWallet): EWallet1?` | `Models/PaymentInformation1.cs` |
| `PaymentInformation14` | — | `Customer (customer): Customer10?`, `PaymentType (paymentType): PaymentType11?` | `Models/PaymentInformation14.cs` |
| `PaymentInformation15` | — | `PaymentType (paymentType): PaymentType12?`, `EWallet (eWallet): EWallet5?`, `Customer (customer): Customer10?`, `Bank (bank): Bank6?` | `Models/PaymentInformation15.cs` |
| `PaymentInformation16` | — | `Card (card): Card8?`, `TokenizedCard (tokenizedCard): TokenizedCard6?`, `PaymentType (paymentType): PaymentType13?`, `Bank (bank): Bank7?` | `Models/PaymentInformation16.cs` |
| `PaymentInformation18` | — | `EWallet (eWallet): EWallet6?`, `Bank (bank): Bank9?` | `Models/PaymentInformation18.cs` |
| `PaymentInformation2` | — | `AccountFeatures (accountFeatures): AccountFeatures1?` | `Models/PaymentInformation2.cs` |
| `PaymentInformation20` | — | `PaymentType (paymentType): PaymentType1?`, `EWallet (eWallet): EWallet7?` | `Models/PaymentInformation20.cs` |
| `PaymentInformation21` | — | `EWallet (eWallet): EWallet8?` | `Models/PaymentInformation21.cs` |
| `PaymentInformation22` | — | `Card (card): Card11?`, `Bank (bank): Bank11?`, `EWallet (eWallet): EWallet9?`, `Options (options): Options1?`, `PaymentType (paymentType): PaymentType?` | `Models/PaymentInformation22.cs` |
| `PaymentInformation23` | — | `EWallet (eWallet): EWallet10?` | `Models/PaymentInformation23.cs` |
| `PaymentInformation26` | — | `PaymentType (paymentType): PaymentType19?`, `TokenizedPaymentMethod (tokenizedPaymentMethod): TokenizedPaymentMethod2?`, `IndustryType (industryType): string?`, `EWallet (eWallet): EWallet13?` | `Models/PaymentInformation26.cs` |
| `PaymentInformation28` | — | `PaymentType (paymentType): PaymentType19?` | `Models/PaymentInformation28.cs` |
| `PaymentInformation29` | — | `PaymentType (paymentType): PaymentType11?`, `TokenizedPaymentMethod (tokenizedPaymentMethod): TokenizedPaymentMethod?` | `Models/PaymentInformation29.cs` |
| `PaymentInformation3` | — | `PaymentType (paymentType): PaymentType1?`, `MerchantLimitedAcceptanceIndicator (merchantLimitedAcceptanceIndicator): string?` | `Models/PaymentInformation3.cs` |
| `PaymentInformation30` | — | `TokenizedPaymentMethod (tokenizedPaymentMethod): TokenizedPaymentMethod4?`, `EWallet (eWallet): EWallet13?` | `Models/PaymentInformation30.cs` |
| `PaymentInformation31` | Contains the payment data for this transaction. | `Card (card): Card120?`, `TokenizedCard (tokenizedCard): TokenizedCard14?`, `Customer (customer): Customer?`, `Bank (bank): Bank?`, `Method (method): string?` | `Models/PaymentInformation31.cs` |
| `PaymentInformation32` | Contains response information about the payment. | `BinCountry (binCountry): string?`, `AccountType (accountType): string?`, `Issuer (issuer): string?`, `Scheme (scheme): string?`, `Bin (bin): string?` | `Models/PaymentInformation32.cs` |
| `PaymentInformation33` | — | `Card (card): Card121?`, `TokenizedCard (tokenizedCard): TokenizedCard15?`, `FluidData (fluidData): FluidData4?`, `Customer (customer): Customer50?` | `Models/PaymentInformation33.cs` |
| `PaymentInformation34` | — | `Card (card): Card121?`, `TokenizedCard (tokenizedCard): TokenizedCard16?`, `FluidData (fluidData): FluidData4?`, `Customer (customer): Customer51?` | `Models/PaymentInformation34.cs` |
| `PaymentInformation35` | — | `Card (card): Card123?`, `TokenizedCard (tokenizedCard): TokenizedCard17?`, `FluidData (fluidData): FluidData?`, `Customer (customer): Customer51?` | `Models/PaymentInformation35.cs` |
| `PaymentInformation36` | Contains the payment data for updating in List Management. | `Card (card): Card124?`, `Bank (bank): Bank14?` | `Models/PaymentInformation36.cs` |
| `PaymentInformation37` | — | `Card (card): Card125?`, `Customer (customer): Customer?`, `PaymentInstrument (paymentInstrument): PaymentInstrument?`, `InstrumentIdentifier (instrumentIdentifier): InstrumentIdentifier2?`, `TokenizedCard (tokenizedCard): TokenizedCard?` | `Models/PaymentInformation37.cs` |
| `PaymentInformation38` | — | `Card (card): Card127?`, `TokenizedCard (tokenizedCard): TokenizedCard19?`, `Customer (customer): Customer56?`, `PaymentInstrument (paymentInstrument): PaymentInstrument23?`, `InstrumentIdentifier (instrumentIdentifier): InstrumentIdentifier34?`, `AccountType (accountType): string?` | `Models/PaymentInformation38.cs` |
| `PaymentInformation39` | — | `Customer (customer): Customer59?` | `Models/PaymentInformation39.cs` |
| `PaymentInformation4` | — | `Customer (customer): Customer?`, `Card (card): Card3?`, `PaymentType (paymentType): PaymentType2?` | `Models/PaymentInformation4.cs` |
| `PaymentInformation40` | — | `Customer (customer): Customer60?` | `Models/PaymentInformation40.cs` |
| `PaymentInformation42` | — | `Card (card): Card129?`, `Customer (customer): Customer60?`, `PaymentInstrument (paymentInstrument): PaymentInstrument?`, `InstrumentIdentifier (instrumentIdentifier): InstrumentIdentifier?` | `Models/PaymentInformation42.cs` |
