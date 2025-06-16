using System.Collections.Generic;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities
{
    public class CompanyNumberValidation
    {
        public string CompanyNumber { get; set; }

        [JsonConverter(typeof(EnumerationConverter))]
        public CountryIso CountryCode { get; set; }
        
        public bool IsValid { get; set; }
        
        public List<string> ValidationRules { get; set; }
    }
}