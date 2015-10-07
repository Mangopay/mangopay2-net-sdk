
namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Dispute contest PUT entity.</summary>
	public class DisputeContestPutDTO : EntityPutBase
    {
		/// <summary>The amount you wish to contest (must be the same currency as the DisputedFunds, and the amount can be up to and including the DisputedFunds).</summary>
		public Money ContestedFunds { get; set; }
    }
}
