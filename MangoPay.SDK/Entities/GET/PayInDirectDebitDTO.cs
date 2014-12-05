using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInDirectDebitDTO : PayInDTO
    {
        /// <summary>Direct debit type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DirectDebitType DirectDebitType { get; set; }

        /// <summary>Culture.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso Culture { get; set; }

        /// <summary>Redirect URL.</summary>
        public String RedirectURL { get; set; }

        /// <summary>Return URL.</summary>
        public String ReturnURL { get; set; }

        /// <summary>Template URL.</summary>
        public String TemplateURL { get; set; }
    }
}
