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
        public string Tag { get; set; }

        /// <summary>Email address.</summary>
        public string Email { get; set; }

        /// <summary>Name of this user.</summary>
        public string Name { get; set; }

        /// <summary>Company Number</summary>
        public string CompanyNumber { get; set; }

        /// <summary>Type of legal user.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LegalPersonType? LegalPersonType { get; set; }

        /// <summary>Headquarters address.</summary>
		public Address HeadquartersAddress { get; set; }

        /// <summary>Legal representative first name.</summary>
        public string LegalRepresentativeFirstName { get; set; }

        /// <summary>Legal representative last name.</summary>
        public string LegalRepresentativeLastName { get; set; }

        /// <summary>Legal representative address.</summary>
		public Address LegalRepresentativeAddress { get; set; }

        /// <summary>Legal representative email.</summary>
        public string LegalRepresentativeEmail { get; set; }

        /// <summary>Legal representative birthday.</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? LegalRepresentativeBirthday { get; set; }

        /// <summary>Legal representative nationality.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? LegalRepresentativeNationality { get; set; }

        /// <summary>Legal representative country of residence.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? LegalRepresentativeCountryOfResidence { get; set; }

        public bool? TermsAndConditionsAccepted { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UserCategory UserCategory { get; set; }

        public bool ShouldSerializeHeadquartersAddress()
		{
			return HeadquartersAddress != null && HeadquartersAddress.IsValid();
		}

		public bool ShouldSerializeLegalRepresentativeAddress()
		{
			return LegalRepresentativeAddress != null && LegalRepresentativeAddress.IsValid();
		}
    }
}
