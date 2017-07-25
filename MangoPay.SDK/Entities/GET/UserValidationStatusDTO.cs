using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Entities.GET
{
	public class UserValidationStatusDTO
	{
		public int Id { get; set; }

		public UboValidationStatusType Status { get; set; }

		public UboRefusedReasonType? RefusedReasonType { get; set; }

		public string RefuseReasonMessage { get; set; }
	}
}
