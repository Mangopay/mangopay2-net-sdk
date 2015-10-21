
namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Transaction nature enumeration.</summary>
    public enum TransactionNature
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

        /// <summary>REGULAR transaction nature.</summary>
        REGULAR, 

        /// <summary>REFUND transaction nature.</summary>
        REFUND, 

        /// <summary>REPUDIATION transaction nature.</summary>
        REPUDIATION,

		/// <summary>SETTLEMENT transaction nature.</summary>
		SETTLEMENT
    }
}
