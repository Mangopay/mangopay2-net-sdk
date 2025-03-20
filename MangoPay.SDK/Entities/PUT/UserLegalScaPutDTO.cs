using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>User legal SCA PUT entity.</summary>
    public class UserLegalScaPutDTO : EntityPutBase
    {
	    /// <summary>Name of this user.</summary>
	    public string Name { get; set; }
        
	    /// <summary>Type of legal user.</summary>
	    [JsonConverter(typeof(StringEnumConverter))]
	    public LegalPersonType? LegalPersonType { get; set; }
        
	    /// <summary>Legal Representative</summary>
	    public LegalRepresentative LegalRepresentative { get; set; }
	    
	    /// <summary>Company Number</summary>
	    public string CompanyNumber { get; set; }
	    
	    /// <summary>Headquarters address.</summary>
	    public Address HeadquartersAddress { get; set; }
        
	    /// <summary>Legal representative address.</summary>
	    public Address LegalRepresentativeAddress { get; set; }

	    public bool? TermsAndConditionsAccepted { get; set; }
	    
	    public string Tag { get; set; }
	    
	    public string Email { get; set; }
    }
}
