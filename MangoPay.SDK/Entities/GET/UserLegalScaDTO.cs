using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>UserLegal SCA entity.</summary>
    public sealed class UserLegalScaDTO : UserDTO
    {
        /// <summary>Name of this user.</summary>
        public string Name { get; set; }

        /// <summary>Type of legal user.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LegalPersonType LegalPersonType { get; set; }

        /// <summary>Legal Representative</summary>
        public LegalRepresentative LegalRepresentative { get; set; }

        /// <summary>Proof of registration.</summary>
        public string ProofOfRegistration { get; set; }

        /// <summary>Shareholder declaration.</summary>
        public string ShareholderDeclaration { get; set; }

        /// <summary>Statute.</summary>
        public string Statute { get; set; }

        /// <summary>Company Number</summary>
        public string CompanyNumber { get; set; }

        /// <summary>
        /// Object containing the link needed for SCA redirection if triggered by the API call (otherwise returned null).
        /// </summary>
        public PendingUserActionDTO PendingUserAction { get; set; }

        /// <summary>Headquarters address.</summary>
        public Address HeadquartersAddress { get; set; }

        /// <summary>Legal representative address.</summary>
        public Address LegalRepresentativeAddress { get; set; }
    }
}