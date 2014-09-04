using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>Hook PUT entity.</summary>
    public class HookPutDTO : EntityPutBase
    {
        /// <summary>This is the URL where you receive notification.</summary>
        public String Url { get; set; }

        /// <summary>Hook status.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public HookStatus Status { get; set; }
    }
}
