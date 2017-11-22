
using System;

namespace MangoPay.SDK.Core.Enumerations
{
	[Flags]
	public enum DisputeType
	{
		/// <summary>Not specified.</summary>
		NotSpecified = 0x00,

		CONTESTABLE = 0x01,

		NOT_CONTESTABLE = 0x02,

		RETRIEVAL = 0x04
	}
}
