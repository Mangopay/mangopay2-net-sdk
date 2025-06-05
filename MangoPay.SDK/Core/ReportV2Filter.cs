using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Core
{
	/// <summary>Filter for report list.</summary>
	public class ReportV2Filter
	{
		/// <summary>Currency</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? Currency { get; set; }
		
		public string UserId { get; set; }
		
		public string WalletId { get; set; }
	}
}
