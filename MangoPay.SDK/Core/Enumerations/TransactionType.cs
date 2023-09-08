
using System;

namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Transaction type enumeration.</summary>
	[Flags]
    public enum TransactionType
    {
        /// <summary>Not specified.</summary>
        NotSpecified	= 0x00,

        /// <summary>PAYIN transaction type.</summary>
        PAYIN			= 0x01, 

        /// <summary>PAYOUT transaction type.</summary>
        PAYOUT			= 0x02, 

        /// <summary>TRANSFER transaction type.</summary>
        TRANSFER		= 0x04,
        
        /// <summary>CARD_VALIDATION transaction type.</summary>
        CARD_VALIDATION		= 0x05
    }
}
