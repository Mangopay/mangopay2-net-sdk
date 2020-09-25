## [2.1.2]
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
