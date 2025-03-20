using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class LegalRepresentative
    {
        /// <summary>First name.</summary>
        public string FirstName { get; set; }

        /// <summary>Last name.</summary>
        public string LastName { get; set; }
        
        /// <summary>Date of birth (UNIX timestamp). Required if UserCategory is OWNER.</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? Birthday { get; set; }
        
        /// <summary>User's country. Required if UserCategory is OWNER.</summary>
        [JsonConverter(typeof(EnumerationConverter))]
        public CountryIso? Nationality { get; set; }

        /// <summary>Country of residence. Required if UserCategory is OWNER.</summary>
        [JsonConverter(typeof(EnumerationConverter))]
        public CountryIso? CountryOfResidence { get; set; }
        
        /// <summary>Email.</summary>
        public string Email { get; set; }
        
        /// <summary>
        /// The individual’s phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Required if the PhoneNumber is provided in local format (recommended), to render the value in the E.164 standard.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? PhoneNumberCountry { get; set; }
    }
}