
using System;

namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Transaction status enumeration.</summary>
	[Flags]
    public enum TransactionStatus
    {
        /// <summary>Not specified.</summary>
        NotSpecified	= 0x00,

        /// <summary>CREATED transaction status.</summary>
        CREATED			= 0x01, 

        /// <summary>SUCCEEDED transaction status.</summary>
        SUCCEEDED		= 0x02, 

        /// <summary>FAILED transaction status.</summary>
        FAILED			= 0x04
    }
}
