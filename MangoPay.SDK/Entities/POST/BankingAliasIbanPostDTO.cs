using MangoPay.SDK.Core.Enumerations;
using System;

namespace MangoPay.SDK.Entities.POST
{
	/// <summary>IBAN bank account POST entity.</summary>
	public class BankingAliasIbanPostDTO : BankingAliasPostDTO
	{
		public BankingAliasIbanPostDTO(String ownerName, CountryIso country)
        {
            OwnerName = ownerName;
			Country = country;
		}

		/// <summary>THe name of the owner of the bank account.</summary>
		public CountryIso Country { get; set; }
	}
}
