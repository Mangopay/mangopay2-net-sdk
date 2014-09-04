using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>Card registration POST entity.</summary>
    public class CardRegistrationPostDTO : EntityPostBase
    {
        public CardRegistrationPostDTO(string userId, CurrencyIso currency)
        {
            UserId = userId;
            Currency = currency;
        }

        /// <summary>User identifier.</summary>
        public String UserId { get; set; }

        /// <summary>Currency.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency { get; set; }

        /// <summary>Card registration URL.</summary>
        public String CardRegistrationURL { get; set; }

        /// <summary>Registration data.</summary>
        public String RegistrationData { get; set; }
    }
}
