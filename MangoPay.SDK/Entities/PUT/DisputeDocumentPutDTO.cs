using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Dispute document PUT entity.</summary>
	public class DisputeDocumentPutDTO : EntityPutBase
    {
        /// <summary>Status of dispute document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public DisputeDocumentStatus? Status { get; set; }
    }
}
