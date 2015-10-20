using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Dispute contest PUT entity.</summary>
	public class DisputeContestPutDTO : EntityPutBase
    {
		/// <summary>The amount you wish to contest (must be the same currency as the DisputedFunds, and the amount can be up to and including the DisputedFunds).</summary>
		public Money ContestedFunds { get; set; }

		/// <summary>Status of dispute.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DisputeStatus? Status { get; set; }
    }
}
