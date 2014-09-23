using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>UserLegal entity.</summary>
    public sealed class UserLegalDTO : UserDTO
    {
        /// <summary>Name of this user.</summary>
        public String Name { get; set; }

        /// <summary>Type of legal user.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LegalPersonType LegalPersonType { get; set; }

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
        public long LegalRepresentativeBirthday { get; set; }

        /// <summary>Legal representative nationality.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso LegalRepresentativeNationality { get; set; }

        /// <summary>Legal representative country of residence.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso LegalRepresentativeCountryOfResidence { get; set; }

        /// <summary>Statute.</summary>
        public String Statute { get; set; }

        /// <summary>Proof of registration.</summary>
        public String ProofOfRegistration { get; set; }

        /// <summary>Shareholder declaration.</summary>
        public String ShareholderDeclaration { get; set; }
    }
}
