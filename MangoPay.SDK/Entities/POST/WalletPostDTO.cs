using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Wallet POST entity.</summary>
    public class WalletPostDTO : EntityPostBase
    {
        public WalletPostDTO(List<string> owners, string description, CurrencyIso currency)
        {
            Owners = owners;
            Description = description;
            Currency = currency;
        }

        /// <summary>Collection of owners identifiers.</summary>
        public List<string> Owners { get; set; }

        /// <summary>Wallet description.</summary>
        public string Description { get; set; }

        /// <summary>Currency code in ISO.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency { get; set; }
    }
}
