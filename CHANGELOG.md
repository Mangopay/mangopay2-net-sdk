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