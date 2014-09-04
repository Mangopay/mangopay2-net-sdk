using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>Hook POST entity.</summary>
    public class HookPostDTO : EntityPostBase
    {
        public HookPostDTO(String url, EventType eventType)
        {
            Url = url;
            EventType = eventType;
        }

        /// <summary>This is the URL where you receive notification for each EventType.</summary>
        public String Url { get; set; }

        /// <summary>Event type (the <code>EventType.All</code> value is forbidden here).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EventType EventType { get; set; }
    }
}
