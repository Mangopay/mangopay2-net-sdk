using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>CardRegistration entity.</summary>
    public class CardRegistrationDTO : EntityBase
    {
        /// <summary>User identifier.</summary>
        public string UserId { get; set; }

        /// <summary>Access key.</summary>
        public string AccessKey { get; set; }

        /// <summary>Pre-registration data.</summary>
        public string PreregistrationData { get; set; }

        /// <summary>Card registration URL.</summary>
        public string CardRegistrationURL { get; set; }

        /// <summary>Card identifier.</summary>
        public string CardId { get; set; }

        /// <summary>Card registration data.</summary>
        public string RegistrationData { get; set; }

        /// <summary>Result code.</summary>
        public string ResultCode { get; set; }

        /// <summary>Currency.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency { get; set; }

        /// <summary>Status.</summary>
        public string Status { get; set; }

		/// <summary>Card type.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public CardType CardType { get; set; }
    }
}
