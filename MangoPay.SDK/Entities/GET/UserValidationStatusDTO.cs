using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
	public class UserValidationStatusDTO
	{
		public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
		public UboValidationStatusType Status { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
		public UboRefusedReasonType? RefusedReasonType { get; set; }

		public string RefuseReasonMessage { get; set; }
	}
}
