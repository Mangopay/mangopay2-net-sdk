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

        [JsonConverter(typeof(StringEnumConverter))]
        public UserCategory UserCategory { get; set; }

        /// <summary>Legal representative first name.</summary>
        public string LegalRepresentativeFirstName { get; set; }

        /// <summary>Legal representative last name.</summary>
        public string LegalRepresentativeLastName { get; set; }

        /// <summary>Email address.</summary>
        public string Email { get; set; }

        public bool? TermsAndConditionsAccepted { get; set; }
    }
}
