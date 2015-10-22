using System;

namespace MangoPay.SDK.Entities.GET
{
	public class DocumentDTO : EntityBase
	{
		/// <summary>Refused reason type.</summary>
		public String RefusedReasonType { get; set; }

		/// <summary>Refused reason message.</summary>
		public String RefusedReasonMessage { get; set; }
	}
}
