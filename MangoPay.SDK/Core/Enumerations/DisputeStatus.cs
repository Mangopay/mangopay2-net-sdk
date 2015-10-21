
namespace MangoPay.SDK.Core.Enumerations
{
	/// <summary>Dispute status enumeration.</summary>
	public enum DisputeStatus
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

		CREATED, 
		
		PENDING_CLIENT_ACTION, 
		
		SUBMITTED, 
		
		PENDING_BANK_ACTION, 
		
		REOPENED_PENDING_CLIENT_ACTION,
		
		CLOSED
    }
}
