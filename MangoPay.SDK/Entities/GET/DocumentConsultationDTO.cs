using MangoPay.SDK.Core;
using Newtonsoft.Json;
using System;

namespace MangoPay.SDK.Entities.GET
{
	public class DocumentConsultationDTO
	{
		/// <summary>URL you receive in order to consult a file linked to a KYC or dispute document.</summary>
		public String Url { get; set; }

		/// <summary>Date of expiration of an URL that provides access to a page file for KYC or dispute document.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime ExpirationDate { get; set; }
	}
}
