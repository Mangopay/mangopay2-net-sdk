using System;

namespace MangoPay.SDK.Core.Enumerations
{
	[Flags]
	public enum UboValidationStatusType
	{
		NotSpecified	= 0x00,

		CREATED			= 0x01,

		VALIDATED		= 0x02,

		REFUSED			= 0x04
	}
}
