using System;

namespace MangoPay.SDK.Core.Enumerations
{
	[Flags]
	public enum UboRefusedReasonType
	{
		DECLARATION_DO_NOT_MATCH_UBO_INFORMATION			= 0x00,

		MISSING_UBO											= 0x01,
		
	}
}
