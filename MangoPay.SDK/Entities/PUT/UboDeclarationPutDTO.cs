using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Entities.PUT
{
	public class UboDeclarationPutDTO : EntityPutBase
	{
		public UboDeclarationPutDTO()
		{
		}

		public string ID { get; set; }

		public string UserId { get; set; }

		public UboDeclarationType Status { get; set; }

		public UboRefusedReasonType[] RefusedReasonTypes { get; set; }

		public string RefusedReasonMessage { get; set; }

		public string[] DeclaredUBOs { get; set; }
	}
}
