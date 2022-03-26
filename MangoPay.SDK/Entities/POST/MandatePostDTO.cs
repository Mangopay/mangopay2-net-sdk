using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
	/// <summary>Mandate POST entity.</summary>
	public class MandatePostDTO : EntityPostBase
	{
		public MandatePostDTO(string bankAccountId, CultureCode culture, string returnUrl)
		{
			BankAccountId = bankAccountId;
			Culture = culture;
			ReturnUrl = returnUrl;
		}

		/// <summary>The bank account ID to create the mandate against – can only be GB or IBAN type bank accounts for SEPA, but only GB type for BACS (UK) mandates.</summary>
		public string BankAccountId { get; set; }

		/// <summary>The language of the confirmation web page – can be EN or FR for SEPA mandates, but only EN for BACS (UK) mandates.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public CultureCode Culture { get; set; }

		/// <summary>URL format expected.</summary>
		public string ReturnUrl { get; set; }
	}
}
