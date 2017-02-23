using System;

namespace MangoPay.SDK.Entities.GET
{
	public class BankingAliasIbanDTO : BankingAliasDTO
	{
		/// <summary>The IBAN of the banking alias.</summary>
		public String IBAN { get; set; }

		/// <summary>The BIC of the banking alias.</summary>
		public String BIC { get; set; }
	}
}
