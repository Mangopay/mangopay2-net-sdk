using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Hook entity.</summary>
    public class HookDTO : EntityBase
    {
        /// <summary>This is the URL where you receive notification for various event types.</summary>
        public string Url { get; set; }

        /// <summary>Hook status.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public HookStatus Status { get; set; }

        /// <summary>Hook validity.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Validity Validity { get; set; }

        /// <summary>Event type (the <code>EventType.All</code> value is forbidden here).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType EventType { get; set; }
    }
}
