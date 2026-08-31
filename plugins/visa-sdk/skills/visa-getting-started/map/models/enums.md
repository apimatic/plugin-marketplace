# Enums

12 enums (12 string / 0 int), namespace `CyberSourceMergedSpec.Models.Enums`. These are `StringEnum<T>` / `IntEnum<T>` records (NOT C# enums) — construct via the static members or `Type.FromValue(wireValue)`. Members are listed as `CSharpMemberName (wire_value)`: the member name is the literal C# identifier to write in code (e.g. `CollectionMethod.Invoice`), the parenthesized value is what goes over the wire. Summary is the enum's XML doc summary (`—` when the source has none).

| Enum | Backing | Members | Summary | Source |
|---|---|---|---|---|
| `AssetType` | StringEnum | `CardArtCombined (card-art-combined)`, `BrandLogo (brand-logo)`, `IssuerLogo (issuer-logo)`, `IconLogo (icon-logo)` | — | `Models/Enums/AssetType.cs` |
| `DeclineAniFlag` | StringEnum | `Y (Y)`, `O (O)`, `N (N)`, `U (U)`, `R (R)` | — | `Models/Enums/DeclineAniFlag.cs` |
| `FieldType` | StringEnum | `Text (text)`, `Select (select)` | — | `Models/Enums/FieldType.cs` |
| `Frequency` | StringEnum | `Annual (annual)`, `Monthly (monthly)`, `Quarterly (quarterly)`, `Semiannual (semiannual)`, `Weekly (weekly)`, `Daily (daily)`, `Adhoc (adhoc)`, `Intraday (intraday)`, `Fortnightly (fortnightly)` | Regularity with which the event occurs. | `Models/Enums/Frequency.cs` |
| `ProductType` | StringEnum | `Invoicing (INVOICING)`, `Paybylink (PAYBYLINK)` | — | `Models/Enums/ProductType.cs` |
| `Provider` | StringEnum | `ClientDeviceCertJws (CLIENT_DEVICE_CERT_JWS)`, `VisaPaymentPasskey (VISA_PAYMENT_PASSKEY)` | Provider of the authenticated identity. Identifies the authentication service or identity provider. | `Models/Enums/Provider.cs` |
| `ReferenceType` | StringEnum | `Invoice (Invoice)`, `Purchase (Purchase)`, `Donation (Donation)` | — | `Models/Enums/ReferenceType.cs` |
| `TokenProvider` | StringEnum | `Vts (vts)`, `Mdes (mdes)`, `Amex (amex)`, `Mscof (mscof)` | — | `Models/Enums/TokenProvider.cs` |
| `Type1` | StringEnum | `Recurring (recurring)`, `Oneoff (oneoff)`, `Split (split)`, `Usage (usage)` | Identifies the type of schedule as either recurring, one-off, split or usage. | `Models/Enums/Type1.cs` |
| `Type2` | StringEnum | `Phone (phone)`, `Email (email)`, `AccountNumber (accountNumber)`, `BusinessNumber (businessNumber)`, `AccountId (accountID)` | Indicates the kind of alias provided (phone, email, account number, business number, or organization ID). | `Models/Enums/Type2.cs` |
| `TypeEnum` | StringEnum | `Phone (phone)`, `Email (email)`, `AccountNumber (accountNumber)`, `BusinessNumber (businessNumber)`, `AccountId (accountID)` | Indicates the kind of alias (phone, email, account number, business number, or account ID) | `Models/Enums/TypeEnum.cs` |
| `UserAuthenticationMethod` | StringEnum | `UsernamePassword (USERNAME_PASSWORD)`, `PasscodePassword (PASSCODE_PASSWORD)`, `Passcode (PASSCODE)`, `Password (PASSWORD)`, `Pattern (PATTERN)`, `BiometricFingerprint (BIOMETRIC_FINGERPRINT)`, `BiometricFacial (BIOMETRIC_FACIAL)`, `BiometricIris (BIOMETRIC_IRIS)`, `BiometricVoice (BIOMETRIC_VOICE)`, `BiometricBehavioral (BIOMETRIC_BEHAVIORAL)`, `DeviceUnlockedMethodUnknown (DEVICE_UNLOCKED_METHOD_UNKNOWN)`, `OtpSms (OTP_SMS)`, `OtpEmail (OTP_EMAIL)`, `OtpSmsKnowledge (OTP_SMS_KNOWLEDGE)`, `KnowledgeBasedAuthentication (KNOWLEDGE_BASED_AUTHENTICATION)`, `UserUnverified (USER_UNVERIFIED)`, `Biometric (BIOMETRIC)` | The method used to authenticate the user. | `Models/Enums/UserAuthenticationMethod.cs` |
