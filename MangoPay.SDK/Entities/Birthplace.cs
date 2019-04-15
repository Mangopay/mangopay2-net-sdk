using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities
{
    public class Birthplace
    {
        /// <summary>City.</summary>
        public String City;
        
        /// <summary>Country.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryIso? Country;
    }
}