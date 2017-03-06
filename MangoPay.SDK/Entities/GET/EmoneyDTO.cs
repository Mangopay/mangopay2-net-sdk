using System;

namespace MangoPay.SDK.Entities.GET
{
	public class EmoneyDTO
	{
		/// <summary>User identifier.</summary>
		public String UserId { get; set; }

		/// <summary>The amount of money that has been credited to this user.</summary>
		public Money CreditedEMoney { get; set; }

		/// <summary>The amount of money that has been debited to this user.</summary>
		public Money DebitedEMoney { get; set; }
	}
}
