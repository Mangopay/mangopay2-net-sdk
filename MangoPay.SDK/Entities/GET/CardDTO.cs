using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Card entity.</summary>
    public class CardDTO : EntityBase
    {
        /// <summary>Country.</summary>
        public String Country { get; set; }

        /// <summary>Expiration date.</summary>
        public String ExpirationDate { get; set; }

        /// <summary>Alias.</summary>
        public String Alias { get; set; }

        /// <summary>Card type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType CardType { get; set; }

        /// <summary>The card provider, it could be CB, VISA, MASTERCARD, etc.</summary>
        public String CardProvider { get; set; }

        /// <summary>Product codes.</summary>
        public String Product { get; set; }

        /// <summary>Bank code.</summary>
        public String BankCode { get; set; }

        /// <summary>Active.</summary>
        public bool Active { get; set; }

        /// <summary>User identifier.</summary>
        public String UserId { get; set; }

        /// <summary>The currency accepted in the wallet.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency { get; set; }

        /// <summary>Validity.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Validity Validity { get; set; }

        ///<summary>Card's fingerprint, which is unique per 16-digit card number.</summary>
        public String Fingerprint { get; set; }
    }
}
