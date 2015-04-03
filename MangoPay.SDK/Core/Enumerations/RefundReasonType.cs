
namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>PreAuthorization status enumeration.</summary>
    public enum RefundReasonType
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

		/// <summary>Incorrect bank account.</summary>
		BANKACCOUNT_INCORRECT, 
		
		/// <summary>Closed bank account.</summary>
		BANKACCOUNT_HAS_BEEN_CLOSED, 
		
		/// <summary>Owner-bank account mismatch.</summary>
		OWNER_DOT_NOT_MATCH_BANKACCOUNT, 
		
		/// <summary>Withdrawal impossible on savings accounts.</summary>
		WITHDRAWAL_IMPOSSIBLE_ON_SAVINGS_ACCOUNTS, 
		
		/// <summary>Initialized by client.</summary>
		INITIALIZED_BY_CLIENT, 
		
		/// <summary>Other.</summary>
		OTHER
    }
}
