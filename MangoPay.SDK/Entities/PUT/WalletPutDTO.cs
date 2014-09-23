using MangoPay.SDK.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Wallet PUT entity.</summary>
    public class WalletPutDTO : EntityPutBase
    {
        /// <summary>Custom data.</summary>
        public String Tag { get; set; }

        /// <summary>Collection of owners identifiers.</summary>
        public List<String> Owners { get; set; }

        /// <summary>Wallet description.</summary>
        public String Description { get; set; }
    }
}
