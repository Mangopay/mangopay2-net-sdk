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
        public String UserId { get; set; }

        /// <summary>Access key.</summary>
        public String AccessKey { get; set; }

        /// <summary>Pre-registration data.</summary>
        public String PreregistrationData { get; set; }

        /// <summary>Card registration URL.</summary>
        public String CardRegistrationURL { get; set; }

        /// <summary>Card identifier.</summary>
        public String CardId { get; set; }

        /// <summary>Card registration data.</summary>
        public String RegistrationData { get; set; }

        /// <summary>Result code.</summary>
        public String ResultCode { get; set; }

        /// <summary>Currency.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency { get; set; }

        /// <summary>Status.</summary>
        public String Status { get; set; }

		/// <summary>Card type.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public CardType CardType { get; set; }
    }
}
