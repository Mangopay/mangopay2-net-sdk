## [3.21.0] - 2025-01-10
### Added

New endpoints for The Virtual Account object:

- Create a Virtual Account
- Deactivate a Virtual Account
- View a Virtual Account
- List Virtual Accounts for a Wallet
- View Client Availabilities

Added all relevant `EVENT_TYPE_CHOICES`:

- `VIRTUAL_ACCOUNT_ACTIVE`
- `VIRTUAL_ACCOUNT_BLOCKED`
- `VIRTUAL_ACCOUNT_CLOSED`
- `VIRTUAL_ACCOUNT_FAILED`


### Added

- New `PaymentRef` parameter for [Payouts](https://docs.mangopay.com/api-reference/payouts/payout-object#the-payout-object)

## [3.19.3] - 2024-11-11
### Fixed

- #231 Update RestSharp from v107.3.0 to v112.1.0.
- #225 Add `RateLimitingCallsMade` to `LastRequestInfo`. Thanks for your contribution [@bosquig](https://github.com/bosquig)

## [3.19.2] - 2024-10-14
### Added

- Added new `PaymentFlow` parameter to the [Bancontact PayIn](https://docs.mangopay.com/api-reference/bancontact/bancontact-payin-object) endpoint.

## [3.19.1] - 2024-07-15
### Added

- Parameter `StatementDescriptor` for the endpoint [Create refund payin](https://mangopay.com/docs/endpoints/refunds#create-refund-payin)
- Parameter PaymentCategory for the endpoints : [Create a card validation](https://mangopay.com/docs/endpoints/card-validations#create-card-validation), [Create a direct card payin](https://mangopay.com/docs/endpoints/direct-card-payins#create-direct-card-payin), [Create a preauthorization](https://mangopay.com/docs/endpoints/preauthorizations#create-preauthorization)

## [3.19.0] - 2024-06-20
### Added

- New endpoint [Bancontact payin](https://mangopay.com/docs/endpoints/bancontact)
- New parameter for update card : `CardHolderName `

## [3.18.0] - 2024-05-20
### Added

- New endpoint [Add tracking to Paypal payin](https://mangopay.com/docs/endpoints/paypal#add-tracking-paypal-payin)
- New parameters for Paypal mean of payment : `CancelURL` & `Category` (sub-parameter of `LineItems`). And management of `PaypalPayerID`, `BuyerCountry`, `BuyerFirstname`, `BuyerLastname`, `BuyerPhone`, `PaypalOrderID` in the response.
- New parameter `SecureMode` for [Create card validation](https://mangopay.com/docs/endpoints/card-validations#create-card-validation)
- New parameter `CardHolderName` for [Update Card registration](https://mangopay.com/docs/endpoints/card-validations#update-card-registration)

## [3.17.1] - 2024-04-30
### Fixed

- Updated the implementation for [Look up metadata for a payment method](https://mangopay.com/docs/endpoints/payment-method-metadata#lookup-payment-method-metadata). The `CommercialIndicator` and `CardType` fields have been moved to the `BinData` object in the API response.

## [3.17.0] - 2024-03-08
### Fixed

- Fixed incorrect spelling of the `Subtype` key in the `BinData` parameter.
- Conversions endpoint spelling

### Added

- The optional Fees parameter is now available on instant conversions, allowing platforms to charge users for FX services. More information [here](https://mangopay.com/docs/release-notes/millefeuille).
- Platforms can now use a quote to secure the rate for a conversion between two currencies for a set amount of time. More information [here](https://mangopay.com/docs/release-notes/millefeuille).
- Introduced the `UKHeaderFlag` boolean configuration key. Platforms partnered with Mangopay's UK entity should set this key to true for proper configuration.

## [3.16.0] - 2024-02-13
### Added

- New endpoint to look up metadata from BIN or Google Pay token. More information [here](https://mangopay.com/docs/release-notes/kisale)
- [Get a card validation endpoint](https://mangopay.com/docs/endpoints/card-validations#view-card-validation)

## [3.15.0] - 2023-12-22
### Added

New `CardInfo` parameter returned on card transactions. More information [here](https://mangopay.com/docs/release-notes/chilka).

## [3.14.0] - 2023-12-07
### Added

The IDEAL legacy implementation has been enhanced. You can now pass the `Bic`., and if provided, the API response will include the `BankName` parameter. More information [here](https://mangopay.com/docs/endpoints/web-card-payins#create-web-card-payin).

## [3.13.2] - 2023-11-09
### Added

It's now possible to specify an amount for DebitedFunds and Fees when you create a refund.

## [3.13.1] - 2023-11-06
### Fixed

- Missing parameter for Klarna

## [3.13.0] - 2023-11-02
### Updated

- Giropay and Ideal integrations with Mangopay have been improved. Some methods have been deprecated.

### Added
- New Reference parameter for the new Paypal implementation. Some methods have been deprecated.
- New hooks event :
  DEPOSIT_PREAUTHORIZATION_PAYMENT_NO_SHOW_REQUESTED
  DEPOSIT_PREAUTHORIZATION_PAYMENT_NO_SHOW
  DEPOSIT_PREAUTHORIZATION_PAYMENT_TO_BE_COMPLETED
  DEPOSIT_PREAUTHORIZATION_PAYMENT_FAILED

## [3.12.2] - 2023-10-20
### Fixed
- fixed previous release (3.12.1)

## [3.12.1] - 2023-10-19
### Fixed

Two events types added to reflect changes in the API :
- LEGAL_COMPANY_NUMBER_VALIDATION_SUCCEEDED
- LEGAL_COMPANY_NUMBER_VALIDATION_FAILED

## [3.12.0] - 2023-09-29
### Added
- Instantly convert funds between 2 wallets of different currencies owned by the same user with the new SPOT FX endpoints

## [3.11.0] - 2023-09-20
### Added

- Multibanco, Satispay, Blik, Klarna are now available as a payment method with Mangopay. This payment method is in private beta. Please contact support if you have any questions.
- Card validation endpoint is now available (Private beta)
- A new parameter for Paypal : ShippingPreference

### Updated

- Google Pay integration with Mangopay has been improved. This payment method is in private beta. Please contact support if you have any questions.

### Fixed

- MBWay & PayPal are now using Web Execution Type.

## [3.10.1] - 2023-08-29
### Fixed

Implementation of PayPal and MBWay to reflect the API behavior

## [3.10.0] - 2023-07-07
### Added

Paypal integration with Mangopay has been improved. This payment method is in private beta. Please contact support if you have any questions.

### Fixed

- `Phone` parameter instead of `PhoneNumber` for MBWay

## [3.9.0] - 2023-06-21
### Added

- MB WAY is now available as a payment method with Mangopay. This payment method is in private beta. Please contact support if you have any questions.

## [3.8.0] - 2023-03-17
### Added

Knowing when a dispute was closed is now possible thanks to the new ClosedDate parameter for the Dispute object.

The following endpoints have been updated accordingly:

[Vew a Dispute](ttps://docs.mangopay.com/endpoints/v2.01/disputes#e240_view-a-dispute)

[List Disputes for a User](https://docs.mangopay.com/endpoints/v2.01/disputes#e817_list-a-users-disputes)

[List Disputes for a Wallet](https://docs.mangopay.com/endpoints/v2.01/disputes#e816_list-a-wallets-disputes)

[List all Disputes](https://docs.mangopay.com/endpoints/v2.01/disputes#e241_list-all-disputes)

[List Disputes that need settling](https://docs.mangopay.com/endpoints/v2.01/disputes#e980_list-disputes-that-need-settling)

Please note that the new ClosedDate field will only display values for the Disputes closed after this release. Otherwise, a null value will be returned.

## [3.7.1] - 2023-02-09
### Added

- User category enum adapted for some Mangopay users

## [3.7.0] - 2022-12-15
### Added

#### New 30-day preauthorization feature

Preauthorizations can now hold funds for up to 30 days, therefore ensuring the solvency of a registered card for the same amount of time.

- The **ApiDeposits** service has been added with methods for creating, fetching and canceling a deposit
- The **Deposit** DTOs have been created
- The **CreateCardPreAuthorizedDepositPayIn** method has been added to the ApiPayins service

Thanks to 30-day preauthorizations, MANGOPAY can provide a simpler and more flexible payment experience for a wide range of use cases, especially for rentals.

## [3.6.2] - 2022-11-25
### Added

#### New User LegalPersonType: Partnership

Verifying some specific legal structures is now more efficient thanks to a new legal entity type: PARTNERSHIP.

The Legal User LegalPersonType parameter now includes the “PARTNERSHIP” value. The following endpoints have been updated accordingly:

[Create a Legal User (Payer)](https://docs.mangopay.com/endpoints/v2.01/users#e259_create-a-legal-user)

[Create a Legal User (Owner)](https://docs.mangopay.com/endpoints/v2.01/users#e1060_create-a-legal-user-owner)

[Update a Legal User](https://docs.mangopay.com/endpoints/v2.01/users#e261_update-a-legal-user)

[View a User](https://docs.mangopay.com/endpoints/v2.01/users#e256_view-a-user)

Please note that changing the LegalPersonType to “PARTNERSHIP” for an existing user will automatically result in:

A KYC downgrade to Light (default) verification
The REGISTRATION_PROOF document being flagged as OUT_OF_DATE.
With this new LegalPersonType, the MANGOPAY team can better handle specific legal structures and speed up the validation process.

## [3.6.1] - 2022-11-08
### Fixed

- Compatibility issue fixed (Restsharp, Unit tests) : https://github.com/Mangopay/mangopay2-net-sdk/pull/174 

## [3.6.0] - 2022-10-06
### Added

**New country authorizations endpoints**

Country authorizations can now be viewed by using one of the following endpoints:

[View a country's authorizations](https://docs.mangopay.com/endpoints/v2.01/regulatory#e1061_the-country-authorizations-object)
[View all countries' authorizations](https://docs.mangopay.com/endpoints/v2.01/regulatory#e1061_the-country-authorizations-object)

With these calls, it is possible to check which countries have:

- Blocked user creation
- Blocked bank account creation
- Blocked payout creation

Please refer to the [Restrictions by country](https://docs.mangopay.com/guide/restrictions-by-country) article for more information.

**New country authorization hook**

Country authorization updates can now be received by setting up a hook for the following EventType: COUNTRY_AUTHORIZATION_UPDATED

With this hook, it is possible to be notified when a country’s restrictions are updated. 

## [3.5.0] - 2022-08-25
##Added
- It's now possible to fetch a Payconiq by ID

## [3.4.2] - 2022-07-21
##Fixed
- Bug with idempotency parameters with some GET requests (Disputes, Repudiations...) 

## [3.4.1] - 2022-07-18
##Fixed
Missing EventType have been added (RECURRING_REGISTRATION).

## [3.4.0] - 2022-06-29
##Added
**Recurring: €0 deadlines for CIT**

Setting free recurring payment deadlines is now possible for CIT (customer-initiated transactions) with the **FreeCycles** parameter.

The **FreeCycles** parameter allows platforms to define the number of consecutive deadlines that will be free. The following endpoints have been updated to take into account this new parameter:

<a href="https://docs.mangopay.com/endpoints/v2.01/payins#e1051_create-a-recurring-payin-registration">Create a Recurring PayIn Registration</a><br>
<a href="https://docs.mangopay.com/endpoints/v2.01/payins#e1056_view-a-recurring-payin-registration">View a Recurring PayIn Registration</a><br>

This feature provides new automation capabilities for platforms with offers such as “Get the first month free” or “free trial” subscriptions.

Please refer to the <a href="https://docs.mangopay.com/guide/recurring-payments-introduction">Recurring payments overview</a> documentation for more information.

## [3.3.1] - 2022.06.06
### Fixed

The SDK handles existing User without an UserCategory

## [3.3.0] - 2022.05.20
### Added

Users can now be differentiated depending on their MANGOPAY usage.

This is possible with the new UserCategory parameter, whose value can be set to:

- Payer – For users who are only using MANGOPAY to give money to other users (i.e., only pay).
- Owner – For users who are using MANGOPAY to receive funds (and who are therefore required to accept MANGOPAY’s terms and conditions).

Please note that the following parameters become required as soon as the UserCategory is set to “Owner”: 
- HeadquartersAddress
- CompanyNumber (if the LegalPersonType is “Business”)
- TermsAndConditionsAccepted.

The documentation of user-related endpoints has been updated and reorganised to take into account the new parameter:

[Create a Natural User (Payer)](https://docs.mangopay.com/endpoints/v2.01/users#e255_create-a-natural-user)
[Create a Natural User (Owner)](https://docs.mangopay.com/endpoints/v2.01/users#e1059_create-natural-user-owner)
[Update a Natural User](https://docs.mangopay.com/endpoints/v2.01/users#e260_update-a-natural-user)
[Create a Legal User (Payer)](https://docs.mangopay.com/endpoints/v2.01/users#e259_create-a-legal-user)
[Create a Legal User (Owner)](https://docs.mangopay.com/endpoints/v2.01/users#e1060_create-a-legal-user-owner)
[Update a Legal User](https://docs.mangopay.com/endpoints/v2.01/users#e261_update-a-legal-user)
[View a User](https://docs.mangopay.com/endpoints/v2.01/users#e256_view-a-user)
[List all Users](https://docs.mangopay.com/endpoints/v2.01/users#e257_list-all-users)

Differentiating the platform users results in a smoother user experience for “Payers” as they will have less declarative data to provide.

## [3.2.0] - 2022.05.18
### Added

#### Terms and conditions acceptance parameter

The acceptance of the MANGOPAY terms and conditions by the end user can now be registered via the SDK.

This information can be managed by using the new `TermsAndConditionsAccepted` parameter added to the `User` object.

The following API endpoints have been updated to take into account the new TermsAndConditionsAccepted parameter:

[Create a Natural User](https://docs.mangopay.com/endpoints/v2.01/users#e255_create-a-natural-user)
[Update a Natural User](https://docs.mangopay.com/endpoints/v2.01/users#e260_update-a-natural-user)
[Create a Legal User](https://docs.mangopay.com/endpoints/v2.01/users#e259_create-a-legal-user)
[Update a Legal User](https://docs.mangopay.com/endpoints/v2.01/users#e261_update-a-legal-user)
[View a User](https://docs.mangopay.com/endpoints/v2.01/users#e256_view-a-user)

Please note that:

- Existing users have to be updated to include the terms and conditions acceptance information.
- Once accepted, the terms and conditions cannot be revoked.

## [3.1.0] - 2022.05.12
###Changed

####Updated libraries

The SDK relies on .Net 6.0. You should update your project and librairies accordingly.
If you use a lower/older version, we will not be able to provide any support.

## [3.0.0] - 2022.05.11
The .Net SDK has been revamped in order to increase performances and improve the developer experience.

### Changed

#### Updated libraries

The SDK relies on .Net 5.0. You should update your project and librairies accordingly.
If you use a lower/older version, we will not be able to provide any support.

#### Functions include idempotency management

Previously, if you wish to use idempotency, you had to use a dedicated function for idempotency. These functions have been removed.
Now, each regular function can use idempotency, thanks to a new parameter.

For example : 

`await this.Api.PayIns.CreateRefundAsync(payIn.Id, refund, idempotentKey: idempotencyKey);`

#### Requests efficiency

We have improved our request management. This version uses a singleton RestClient and changes only the RestRequest at each request. Therefore, requests are faster and have less impact on your server. 

## [2.11.0] - 2022.03.31
### Added

#### Instant payment eligibility check

The destination bank reachability can now be verified prior to making an instant payout. This results in a better user experience, as this preliminary check will allow the platform to propose the instant payout option only to end users whose bank is eligible. 

#### Instant payment mode only

Instant Payment requests can now be automatically cancelled when an issue is encountered (rather than falling back to the standard payout mode).

This is possible by using the new `INSTANT_PAYMENT_ONLY` option that has been added to the `PayoutModeRequested` parameter.

### Fixed

- `RefundReasonType` is now a string


## [2.10.0] - 2021.11.19
## Added

We are now providing new hooks for our new feature [Instant payouts](https://docs.mangopay.com/guide/instant-payment-payout) :

- INSTANT_PAYOUT_SUCCEEDED
- INSTANT_PAYOUT_FALLBACKED

It will allow you to trigger an action depends on the Instant Payout treatment.

## [2.9.0] - 2021.10.20
## Added

You can now change the status to "ENDED" for a recurring payment.

## Fixed

- "Status" is now available in the response when you request a recurring payment registration.

## [2.8.0] - 2021.10.11
## Added

### Payconiq

As requested by numerous clients, we are now providing [Payconiq](https://www.payconiq.be) as a new mean-of-payment. To request access, please contact MANGOPAY.

### Flags for KYC documents

**We provide more information regarding refused KYC documents.** Therefore it will be easier for you to adapt your app behavior and help your end user.

You are now able to see the exact explanation thanks to a new parameter called “Flags”. 

It has been added to 

`this.Api.Kyc.GetAsync(kycDocument.Id);`

It will display one or several error codes that provide the reason(s) why your document validation has failed. These error codes description are available [here](https://docs.mangopay.com/guide/kyc-document).

## [2.7.1] - 2021.08.05
## Fixed

- Change `FallbackReason` parameter's type to object in PayOutBankWireDTO  

## [2.7.0] - 2021.07.29
## Added 

- You can now update and view a Recurring PayIn Registration object. To know more about this feature, please consult the documentation [here](https://docs.mangopay.com/guide/recurring-payments-introduction). 
- To improve recurring payments, we have added new parameters for CIT : DebitedFunds & Fees. To know more about this feature, please consult the documentation [here](https://docs.mangopay.com/endpoints/v2.01/payins#e1053_create-a-recurring-payin-cit)

## [2.6.0] - 2021.06.10
## Added 

We have added a new feature **[recurring payments](https://docs.mangopay.com/guide/recurring-payments)** dedicated to clients needing to charge a card repeatedly, such as subscriptions or payments installments. 

You can start testing in sandbox, to help you define your workflow. This release provides the first elements of the full feature.

- [Create a Recurring PayIn Registration object](https://docs.mangopay.com/endpoints/v2.01/payins#e1051_create-a-recurring-payin-registration), containing all the information to define the recurring payment
- [Initiate your recurring payment flow](https://docs.mangopay.com/endpoints/v2.01/payins#e1053_create-a-recurring-payin-cit) with an authenticated transaction (CIT) using the Card Recurring PayIn endpoint
- [Continue your recurring payment flow](https://docs.mangopay.com/endpoints/v2.01/payins#e1054_create-a-recurring-payin-mit) with an non-authenticated transaction (MIT) using the Card Recurring PayIn endpoint

This feature is not yet available in production and you need to contact the Support team to request access.


## [2.5.0] - 2021.05.27
## Added 

Mangopay introduces the instant payment mode. It allows payouts (transfer from wallet to user bank account) to be processed within 25 seconds, rather than the 48 hours for a standard payout.

You can now use this new type of payout with the .Net SDK.

Example :

```csharp
var getJohnBankwire = awaitApi.PayOuts.GetBankwirePayoutAsync(payOut.Id);
// where payOut.Id is the id of an existing payout
```

Please note that this feature must be authorized and activated by MANGOPAY. More information [here](https://docs.mangopay.com/guide/instant-payment-payout).

## [2.4.0]
## Fixed

⚠️ **IBAN provided for testing purpose should never be used outside of a testing environement!**

- Fix `BankAccount` IBAN reference for tests

More information about how to test payments, click [here](https://docs.mangopay.com/guide/testing-payments).

## Added 

Some of you use a lot the [PreAuthorization](https://docs.mangopay.com/endpoints/v2.01/preauthorizations#e183_the-preauthorization-object) feature of our API. To make your life easier, we have added three new events :

- PREAUTHORIZATION_CREATED
- PREAUTHORIZATION_SUCCEEDED
- PREAUTHORIZATION_FAILED

The goal is to help you monitor a PreAuthorization with a [webhook](https://docs.mangopay.com/endpoints/v2.01/hooks#e246_the-hook-object).

*Example: If a PreAuthorization is desynchronized, when the status is updated, you will be able to know it.*

## [2.3.0]

## Added

### On demand feature for 3DSv2

> **This on-demand feature is for testing purposes only and will not be available in production**

#### Request

We've added a new parameter `Requested3DSVersion` (not mandatory) that allows you to choose between versions of 3DS protocols (managed by the parameter `SecureMode`). Two values are available: 
* `V1`
* `V2_1`

If nothing is sent, the flow will be 3DS V1. 

The `Requested3DSVersion` may be included on all calls to the following endpoints:
* `/preauthorizations/card/direct`
* `/payins/card/direct`

#### Response

In the API response, the `Requested3DSVersion` will show the value you requested:
* `V1`
* `V2_1`
* `null` – indicates that nothing was requested

The parameter `Applied3DSVersion` shows you the version of the 3DS protocol used. Two values are possible:
* `V1`
* `V2_1`

## [2.2.0]
- 3DS2 integration with Shipping and Billing objects, including FirstName and LastName fields
The objects Billing and Shipping may be included on all calls to the following endpoints:
  - /preauthorizations/card/direct
  - /payins/card/direct
  - /payins/card/web
- Enable Instant Payment for payouts by adding a new parameter PayoutModeRequested on the following endpoint /payouts/bankwire
  - The new parameter PayoutModeRequested can take two differents values : "INSTANT_PAYMENT" or "STANDARD" (STANDARD = the way we procede normaly a payout request)
  - This new parameter is not mandatory and if empty or not present, the payout will be "STANDARD" by default
  - Instant Payment is in beta all over Europe - SEPA region
- Fix deserialize issue with api.Users.GetBankAccountsAsync
## [2.1.3]
- New endpoint to support changes to Card Validation process (please listen out for product announcements)
- Changes to TotalItems and TotalPages #115
- NullReferenceException: On dictionary in DefaultStorageStrategy #103
- Async improvements to Card Validation and a few other little fixes 

## [2.0.4]
- Added new `KYC_OUTDATED` value for `EventType`
- Added new `USER_KYC_LIGHT` value for `EventType`

## [2.0.2]
## Added
- Add new `USER_KYC_REGULAR` value for `EventType`

## [2.0.1]
## Fixed
- Add missing `UserID` parameter in UBODeclarationDTO.
- Fix typo for version number in CHANGELOG.md (3.x vs. 2.x)


## [2.0.0]
### Breaking changes
- `PAYLINEV2` parameter is now supported for Payin Web Card (only!) and replace `PAYLINE` deprecated parameter. You must now use `TemplateURLOptionsCard` instead of `TemplateURLOptions` for Payin Web Cards only. For Payin Web Direct Debit, `TemplateURLOptions` and its `PAYLINE` parameter should be always used.

### Added
- ApplePay Payin type is now supported and will be activated very soon. Stay tuned and feel free to share you interest on it !
- Quite the same for GooglePay Payin.
- `MANDATE_EXPIRED` new EventType and `EXPIRED` Mandate status have been added.
- `XK`country code for Kosovo has been added.
- `AccountNumber` property has been added for Payin EXTERNAL_INSTRUCTION (Banking Aliases Payins) to help identify payments coming from non-IBAN bankaccounts

### Technical
- .NET Core support has been added 