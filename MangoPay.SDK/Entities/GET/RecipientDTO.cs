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