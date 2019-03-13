using System;

namespace MangoPay.SDK.Core.Enumerations
{
	[Flags]
	public enum UboRefusedReasonType
	{
		NotSpecified			= 0x00,

		MISSING_UBO				= 0x01,

		INVALID_DECLARED_UBO	= 0x02,

		INVALID_UBO_DETAILS		= 0x04
	}
}
