using MangoPay.SDK.Core;
using Newtonsoft.Json;
using System;

namespace MangoPay.SDK.Entities
{
    /// <summary>Base abstract class for entities. Provides common properties.</summary>
    public abstract class EntityBase
    {
        /// <summary>Unique identifier.</summary>
        public string Id { get; set; }

        /// <summary>Custom data.</summary>
        public string Tag { get; set; }

        /// <summary>Date of creation.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreationDate { get; set; }
    }
}
