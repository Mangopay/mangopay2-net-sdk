using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using MangoPay.SDK.Core.Deserializers;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Bank Account base entity.</summary>
    [JsonConverter(typeof(BankAccountDeserializer))]
    public class BankAccountDTO : EntityBase
    {
        /// <summary>User identifier.</summary>
        public string UserId { get; set; }

        /// <summary>Type of bank account.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public BankAccountType Type { get; set; }

        /// <summary>Owner name.</summary>
        public string OwnerName { get; set; }

        /// <summary>Owner address.</summary>
		public Address OwnerAddress { get; set; }

		public string OwnerAddressObsolete { get; set; }

	    /// <summary>Denotes whether the bank account is active or not.</summary>
	    public bool Active { get; set; }
    }
}
