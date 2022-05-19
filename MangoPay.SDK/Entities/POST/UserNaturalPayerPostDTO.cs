using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>User natural Payer POST entity.</summary>
    public class UserNaturalPayerPostDTO : EntityPostBase
    {
        /// <summary>First name.</summary>
        public string FirstName { get; set; }

        /// <summary>Last name.</summary>
        public string LastName { get; set; }

        /// <summary>Email address.</summary>
        public string Email { get; set; }

        /// <summary>Address.</summary>
        public Address Address { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UserCategory UserCategory { get; set; }


        public bool? TermsAndConditionsAccepted { get; set; }
    }
}
