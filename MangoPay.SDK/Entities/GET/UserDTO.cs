using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>User entity base class. Parent for <code>UserNatural</code> or <code>UserLegal</code> child types.</summary>
    public class UserDTO : EntityBase
    {
        /// <summary>Type of user.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PersonType PersonType { get; set; }

        /// <summary>Email address.</summary>
        public String Email { get; set; }

        public UserDTO(PersonType personType)
        {
            PersonType = personType;
        }

        /// <summary>Descendant classes override it.</summary>
        public UserDTO() { }
    }
}
