using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>User legal Payer POST entity.</summary>
    public class UserLegalPayerPostDTO : EntityPostBase
    {
        /// <summary>Type of legal user.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LegalPersonType LegalPersonType { get; set; }

        /// <summary>Name of this user.</summary>
        public string Name { get; set; }

        /// <summary>Legal representative address.</summary>
        public Address LegalRepresentativeAddress { get; set; }

        public string UserCategory { get; set; }

        /// <summary>Legal representative first name.</summary>
        public string LegalRepresentativeFirstName { get; set; }

        /// <summary>Legal representative last name.</summary>
        public string LegalRepresentativeLastName { get; set; }

        /// <summary>Email address.</summary>
        public string Email { get; set; }

        public bool? TermsAndConditionsAccepted { get; set; }
    }

    /// <summary>User legal POST entity.</summary>
    public class UserLegalOwnerPostDTO : UserLegalPayerPostDTO
    {
        /// <summary>Headquarters address.</summary>
        public Address HeadquartersAddress { get; set; }

        /// <summary>Legal representative birthday.</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime LegalRepresentativeBirthday { get; set; }

        /// <summary>Legal representative email.</summary>
        public string LegalRepresentativeEmail { get; set; }

        /// <summary>Legal representative nationality.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso LegalRepresentativeNationality { get; set; }

        /// <summary>Legal representative country of residence.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso LegalRepresentativeCountryOfResidence { get; set; }

        /// <summary>Company Number</summary>
        public string CompanyNumber { get; set; }

        public bool ShouldSerializeLegalRepresentativeAddress()
        {
            return LegalRepresentativeAddress != null && LegalRepresentativeAddress.IsValid();
        }
    }
}
