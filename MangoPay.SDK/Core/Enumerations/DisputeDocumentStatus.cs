
using System;

namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Dispute document status enumeration.</summary>
	[Flags]
	public enum DisputeDocumentStatus
    {
        /// <summary>Not specified.</summary>
        NotSpecified		= 0x00,

        /// <summary>CREATED dispute document status.</summary>
        CREATED				= 0x01,

		/// <summary>VALIDATION ASKED dispute document status.</summary>
        VALIDATION_ASKED	= 0x02,

		/// <summary>VALIDATED dispute document status.</summary>
        VALIDATED			= 0x04,

		/// <summary>REFUSED dispute document status.</summary>
        REFUSED				= 0x08
    }
}
