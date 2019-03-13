
using System;

namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Transaction nature enumeration.</summary>
	[Flags]
    public enum TransactionNature
    {
        /// <summary>Not specified.</summary>
        NotSpecified	= 0x00,

        /// <summary>REGULAR transaction nature.</summary>
        REGULAR			= 0x01, 

        /// <summary>REFUND transaction nature.</summary>
        REFUND			= 0x02, 

        /// <summary>REPUDIATION transaction nature.</summary>
        REPUDIATION		= 0x04,

		/// <summary>SETTLEMENT transaction nature.</summary>
		SETTLEMENT		= 0x08
    }
}
