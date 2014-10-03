using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>KYC document POST entity.</summary>
    public class KycDocumentPostDTO : EntityPostBase
    {
        public KycDocumentPostDTO(KycDocumentType kycDocumentType)
        {
            Type = kycDocumentType;
        }

        /// <summary>Type of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KycDocumentType Type { get; set; }

        /// <summary>Status of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KycStatus? Status { get; set; }
    }
}
