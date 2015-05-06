using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Card registration POST entity.</summary>
    public class CardRegistrationPostDTO : EntityPostBase
    {
		public CardRegistrationPostDTO(string userId, CurrencyIso currency, CardType cardType = CardType.CB_VISA_MASTERCARD)
		{
			UserId = userId;
			Currency = currency;
			CardType = cardType;
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

		/// <summary>Card type.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public CardType CardType { get; set; }
    }
}
