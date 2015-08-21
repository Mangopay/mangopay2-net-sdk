using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>KYC document PUT entity.</summary>
    public class KycDocumentPutDTO : EntityPutBase
    {
        /// <summary>Status of KYC document.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public KycStatus? Status { get; set; }
    }
}
