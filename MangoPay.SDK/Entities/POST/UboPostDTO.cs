using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.POST
{
    public class UboPostDTO : EntityPostBase
    {
        public UboPostDTO(string firstName, string lastName, Address address, CountryIso nationality, DateTime birthday,
            Birthplace birthplace)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Nationality = nationality;
            Birthday = birthday;
            Birthplace = birthplace;
        }

        /// <summary>First name.</summary>
        public string FirstName { get; set; }

        /// <summary>Last name.</summary>
        public string LastName { get; set; }

        /// <summary>Address.</summary>
        public Address Address { get; set; }

        /// <summary>User's country.</summary>
        [JsonConverter(typeof(EnumerationConverter))]
        public CountryIso Nationality { get; set; }

        /// <summary>Date of birth (UNIX timestamp).</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Birthday { get; set; }

        /// <summary>Birthplace.</summary>
        public Birthplace Birthplace { get; set; }
    }
}