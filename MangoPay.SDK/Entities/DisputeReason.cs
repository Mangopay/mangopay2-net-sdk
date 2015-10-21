using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities
{
    /// <summary>Class represents dispute's reason.</summary>
	public class DisputeReason
    {
        /// <summary>Dispute's reason type.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DisputeReasonType DisputeReasonType;

        /// <summary>Dispute's reason message.</summary>
		public string DisputeReasonMessage;
    }
}
