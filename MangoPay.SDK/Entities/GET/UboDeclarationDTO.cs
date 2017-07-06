using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Entities.GET
{
	public class UboDeclarationDTO : EntityBase
	{
		public UboDeclarationDTO()
		{
		}

		public UboDeclarationDTO(UboRefusedReasonType[] refusedReasonTypes, string refusedReasonMessage)
		{
			RefusedReasonTypes = refusedReasonTypes;
			RefusedReasonMessage = refusedReasonMessage;
		}

		public string ID { get; set; }

		public string UserId { get; set; }

		public UboDeclarationType Status { get; set; }

		public UboRefusedReasonType[] RefusedReasonTypes { get; set; }

		public string RefusedReasonMessage { get; set; }

		public UserValidationStatusDTO[] DeclaredUBOs { get; set; }
	}
}
