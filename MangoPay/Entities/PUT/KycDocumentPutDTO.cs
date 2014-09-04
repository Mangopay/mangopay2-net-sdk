using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.Entities
{
    /// <summary>KYC document PUT entity.</summary>
    public class KycDocumentPutDTO : EntityPutBase
    {
        /// <summary>Status of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KycStatus Status { get; set; }
    }
}
