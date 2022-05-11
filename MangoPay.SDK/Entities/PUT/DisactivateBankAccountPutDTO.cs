using System;

namespace MangoPay.SDK.Entities.PUT
{
	/// <summary>Bank account PUT DTO class for disactivating bank account.</summary>
	public class DisactivateBankAccountPutDTO : EntityPutBase
	{
		/// <summary>Custom data.</summary>
		public string Tag { get; set; }

		/// <summary>Denotes whether the bank account is active or not.</summary>
		public bool? Active { get; set; }
	}
}
