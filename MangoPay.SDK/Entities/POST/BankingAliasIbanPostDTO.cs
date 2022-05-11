using MangoPay.SDK.Core.Enumerations;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
	/// <summary>IBAN bank account POST entity.</summary>
	public class BankingAliasIbanPostDTO : BankingAliasPostDTO
	{
		public BankingAliasIbanPostDTO(string ownerName, CountryIso country)
        {
            OwnerName = ownerName;
			Country = country;
		}

        /// <summary>THe name of the owner of the bank account.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
        public CountryIso Country { get; set; }
	}
}
