using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class RecipientDTO : EntityBase
    {
        /// <summary>Status.</summary>
        public string Status { get; set; }

        /// <summary>A unique external identifier for the recipient's bank account.</summary>
        public string DisplayName { get; set; }

        /// <summary>Defines the payout method (e.g., LocalBankTransfer, InternationalBankTransfer).</summary>
        public string PayoutMethodType { get; set; }

        /// <summary>Specifies whether the recipient is an Individual or a Business.</summary>
        public string RecipientType { get; set; }

        /// <summary>3-letter ISO 4217 destination currency code (e.g. EUR, USD, GBP, AUD, CAD,HKD, SGD, MXN).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency { get; set; }
        
        /// <summary>Country ISO</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? Country { get; set; }
        
        /// <summary>
        /// The scope of the recipient:
        /// <para>- PAYOUT – Usable for payouts and in pay-in use cases. 
        /// A PAYOUT recipient can only be created by a user with the UserCategory OWNER 
        /// and requires SCA. You need to use the returned PendingUserAction.RedirectUrl value, 
        /// adding your encoded returnUrl as a query parameter, to redirect the user to the 
        /// hosted SCA session so they can complete the necessary steps.</para>
        /// <para>- PAYIN - Usable for pay-in use cases only, such as direct debit and refunds using payouts. 
        /// A PAYIN recipient can be created by a user with the UserCategory PAYER or OWNER, 
        /// and does not require SCA.</para>
        ///</summary>
        public string RecipientScope { get; set; }
        
        /// <summary>
        /// The unique identifier of the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>Individual recipient.</summary>
        public IndividualRecipient IndividualRecipient { get; set; }

        /// <summary>Business recipient.</summary>
        public BusinessRecipient BusinessRecipient { get; set; }

        /// <summary>Each currency has specific bank details that must be provided based on the recipient's location and payout requirements.</summary>
        public Dictionary<string, dynamic> LocalBankTransfer { get; set; }

        /// <summary>The account details if PayoutMethodType is InternationalBankTransfer.</summary>
        public Dictionary<string, dynamic> InternationalBankTransfer { get; set; }

        /// <summary>Information about the action required from the user.</summary>
        public PendingUserActionDTO PendingUserAction { get; set; }
    }
}