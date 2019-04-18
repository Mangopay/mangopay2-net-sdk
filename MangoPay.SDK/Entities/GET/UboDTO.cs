using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
    public class UboDTO:EntityBase
    {
        public UboDTO()
        {
   
        }
        
        /// <summary>First name.</summary>
        public String FirstName { get; set; }
        
        /// <summary>Last name.</summary>
        public String LastName { get; set; }
        
        /// <summary>Address.</summary>
        public Address Address { get; set; }
                
        /// <summary>User's country.</summary>
        [JsonConverter(typeof(EnumerationConverter))]
        public CountryIso Nationality { get; set; }
                
        /// <summary>Date of birth (UNIX timestamp).</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Birthday { get; set; }
                
        /// <summary>Birthplace.</summary>
        public Birthplace Birthplace { get; set; }
    }
}