using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>User legal PUT entity.</summary>
    public class UserLegalPutDTO : EntityPutBase
    {
        /// <summary>Custom data.</summary>
        public String Tag { get; set; }

        /// <summary>Email address.</summary>
        public String Email { get; set; }

        /// <summary>Name of this user.</summary>
        public String Name { get; set; }

        /// <summary>Type of legal user.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LegalPersonType? LegalPersonType { get; set; }

        /// <summary>Headquarters address.</summary>
        public String HeadquartersAddress { get; set; }

        /// <summary>Legal representative first name.</summary>
        public String LegalRepresentativeFirstName { get; set; }

        /// <summary>Legal representative last name.</summary>
        public String LegalRepresentativeLastName { get; set; }

        /// <summary>Legal representative address.</summary>
        public String LegalRepresentativeAddress { get; set; }

        /// <summary>Legal representative email.</summary>
        public String LegalRepresentativeEmail { get; set; }

        /// <summary>Legal representative birthday.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? LegalRepresentativeBirthday { get; set; }

        /// <summary>Legal representative nationality.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? LegalRepresentativeNationality { get; set; }

        /// <summary>Legal representative country of residence.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? LegalRepresentativeCountryOfResidence { get; set; }
    }
}
