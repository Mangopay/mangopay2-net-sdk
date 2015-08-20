using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Wallet entity.</summary>
    public class WalletDTO : EntityBase
    {
        /// <summary>Collection of owners identifiers.</summary>
        public List<String> Owners { get; set; }

        /// <summary>Wallet description.</summary>
        public String Description { get; set; }

        /// <summary>Money in wallet.</summary>
        public Money Balance { get; set; }

        /// <summary>Currency code in ISO.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso Currency { get; set; }

		/// <summary>Currency code in ISO.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public FundsType FundsType { get; set; }
    }
}
