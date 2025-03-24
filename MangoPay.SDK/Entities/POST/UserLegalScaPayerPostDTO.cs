using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>User legal SCA Payer POST entity.</summary>
    public class UserLegalScaPayerPostDTO : EntityPostBase
    {
        /// <summary>Name of this user.</summary>
        public string Name { get; set; }
        
        /// <summary>Type of legal user.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LegalPersonType LegalPersonType { get; set; }
        
        /// <summary>Legal Representative</summary>
        public LegalRepresentative LegalRepresentative { get; set; }
        
        /// <summary>Legal representative address.</summary>
        public Address LegalRepresentativeAddress { get; set; }
        
        /// <summary>Email address.</summary>
        public string Email { get; set; }
        
        public bool TermsAndConditionsAccepted { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public UserCategory UserCategory { get; set; }
    }
}
