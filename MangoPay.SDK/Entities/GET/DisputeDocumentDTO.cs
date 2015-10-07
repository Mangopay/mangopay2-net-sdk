using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Dispute document entity.</summary>
	public class DisputeDocumentDTO : DocumentDTO
    {
        /// <summary>Type of dispute document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DisputeDocumentType Type { get; set; }

        /// <summary>Status of dispute document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DisputeDocumentStatus Status { get; set; }
    }
}
