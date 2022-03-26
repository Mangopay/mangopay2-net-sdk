using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInCardWebDTO : PayInDTO
    {
        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        public string CardType { get; set; }

        /// <summary>Card identifier.</summary>
        public string CardId { get; set; }

        /// <summary>URL format expected.</summary>
        public string TemplateURL { get; set; }

		/// <summary>Culture.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
        public CultureCode Culture { get; set; }

        /// <summary>Mode3DSType { DEFAULT, FORCE }.</summary>
        public string SecureMode { get; set; }

        /// <summary>Redirect URL.</summary>
        public string RedirectURL { get; set; }

        /// <summary>Return URL.</summary>
        public string ReturnURL { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }

        public Shipping Shipping { get; set; }
    }
}
