using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
	public class BankingAliasIbanDTO : BankingAliasDTO
	{
		/// <summary>The IBAN of the banking alias.</summary>
		public string IBAN { get; set; }

		/// <summary>The BIC of the banking alias.</summary>
		public string BIC { get; set; }

	    /// <summary>
	    /// Country (FR or LU)
	    /// </summary>
	    [JsonConverter(typeof(EnumerationConverter))]
	    public CountryIso Country { get; set; }
    }
}
