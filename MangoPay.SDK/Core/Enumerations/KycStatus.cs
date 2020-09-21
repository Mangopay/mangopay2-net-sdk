
using System;

namespace MangoPay.SDK.Core.Enumerations
{
	/// <summary>KYC document status enumeration.</summary>
	[Flags]
	public enum KycStatus
	{
		/// <summary>Not specified.</summary>
		NotSpecified = 0x00,

		/// <summary>CREATED KYC status.</summary>
		CREATED = 0x01,

		/// <summary>VALIDATION ASKED KYC status.</summary>
		VALIDATION_ASKED = 0x02,

		/// <summary>VALIDATED KYC status.</summary>
		VALIDATED = 0x04,

		/// <summary>REFUSED KYC status.</summary>
		REFUSED = 0x08,

        /// <summary> OUT_OF_DATE KYC status. </summary>
        OUT_OF_DATE = 0x10
    }
}
