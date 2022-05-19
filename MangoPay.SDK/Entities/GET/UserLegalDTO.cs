using MangoPay.SDK.Core;
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
        public string Name { get; set; }

        /// <summary>Company Number</summary>
        public string CompanyNumber { get; set; }
        
        /// <summary>Type of legal user.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
        public LegalPersonType LegalPersonType { get; set; }

        /// <summary>Headquarters address.</summary>
		public Address HeadquartersAddress { get; set; }

		public string HeadquartersAddressObsolete { get; set; }

        /// <summary>Legal representative first name.</summary>
        public string LegalRepresentativeFirstName { get; set; }

        /// <summary>Legal representative last name.</summary>
        public string LegalRepresentativeLastName { get; set; }

        /// <summary>Legal representative address.</summary>
		public Address LegalRepresentativeAddress { get; set; }

		public string LegalRepresentativeAddressObsolete { get; set; }

        /// <summary>Legal representative email.</summary>
        public string LegalRepresentativeEmail { get; set; }

        /// <summary>Legal representative birthday.</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? LegalRepresentativeBirthday { get; set; }

        /// <summary>Legal representative nationality.</summary>
		[JsonConverter(typeof(EnumerationConverter))]
        public CountryIso LegalRepresentativeNationality { get; set; }

        /// <summary>Legal representative country of residence.</summary>
		[JsonConverter(typeof(EnumerationConverter))]
        public CountryIso LegalRepresentativeCountryOfResidence { get; set; }

        /// <summary>Statute.</summary>
        public string Statute { get; set; }

        /// <summary>Proof of registration.</summary>
        public string ProofOfRegistration { get; set; }

        /// <summary>Shareholder declaration.</summary>
        public string ShareholderDeclaration { get; set; }

        /// <summary>Legal Representative Proof Of Identity.</summary>
        public string LegalRepresentativeProofOfIdentity { get; set; }

        public bool? TermsAndConditionsAccepted { get; set; }

        /// <summary>Execution date.</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? TermsAndConditionsAcceptedDate { get; set; }

        public string UserCategory { get; set; }
    }
}
