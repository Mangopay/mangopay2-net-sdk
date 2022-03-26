using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Bank account base class for POST DTO objects.</summary>
    public class BankAccountPostDTO : EntityPostBase
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

		public bool ShouldSerializeOwnerAddress()
		{
			return OwnerAddress != null;
		}
    }
}
