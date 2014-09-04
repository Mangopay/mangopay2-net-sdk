using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>Bank account base class for POST DTO objects.</summary>
    public class BankAccountPostDTO : EntityPostBase
    {
        /// <summary>User identifier.</summary>
        public String UserId { get; set; }

        /// <summary>Type of bank account.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public BankAccountType Type { get; set; }

        /// <summary>Owner name.</summary>
        public String OwnerName { get; set; }

        /// <summary>Owner address.</summary>
        public String OwnerAddress { get; set; }
    }
}
