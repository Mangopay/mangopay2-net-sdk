using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>KYC document entity.</summary>
    public class KycDocumentDTO : EntityBase
    {
        /// <summary>Type of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KycDocumentType Type { get; set; }

        /// <summary>Status of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KycStatus Status { get; set; }

        /// <summary>Refused reason type.</summary>
        public String RefusedReasonType { get; set; }

        /// <summary>Refused reason message.</summary>
        public String RefusedReasonMessage { get; set; }
    }
}
