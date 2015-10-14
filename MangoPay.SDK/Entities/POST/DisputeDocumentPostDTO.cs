using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Dispute document POST entity.</summary>
    public class DisputeDocumentPostDTO : EntityPostBase
    {
		public DisputeDocumentPostDTO(DisputeDocumentType disputeDocumentType)
        {
            Type = disputeDocumentType;
        }

        /// <summary>Type of dispute document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DisputeDocumentType Type { get; set; }
    }
}
