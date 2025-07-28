using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities
{
    public class BanksByCountry
    {
        public List<Bank> Banks { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso Country { get; set; } 
    }
}