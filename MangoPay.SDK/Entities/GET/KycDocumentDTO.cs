using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>KYC document entity.</summary>
    public class KycDocumentDTO : DocumentDTO
    {
        /// <summary>Type of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KycDocumentType Type { get; set; }

        /// <summary>Status of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public KycStatus Status { get; set; }

		/// <summary>The User that this document belongs to.</summary>
		public String UserId { get; set; }

        /// <summary> More information regarding why the document has been rejected </summary>
        public List<string> Flags { get; set; }
    }
}
