using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Categorize User legal PUT entity.</summary>
    public class CategorizeUserLegalPutDTO : EntityPutBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public UserCategory UserCategory { get; set; }

        public bool TermsAndConditionsAccepted { get; set; }
        
        /// <summary>Legal Representative</summary>
        public LegalRepresentative LegalRepresentative { get; set; }
        
        /// <summary>Headquarters address.</summary>
        public Address HeadquartersAddress { get; set; }
        
        /// <summary>Company Number. Required if LegalPersonType is BUSINESS.</summary>
        public string CompanyNumber { get; set; }
    }
}
