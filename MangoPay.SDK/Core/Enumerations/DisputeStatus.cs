
using System;

namespace MangoPay.SDK.Core.Enumerations
{
	/// <summary>Dispute status enumeration.</summary>
	[Flags]
	public enum DisputeStatus
	{
		/// <summary>Not specified.</summary>
		NotSpecified = 0x00,

		CREATED = 0x01,

		PENDING_CLIENT_ACTION = 0x02,

		SUBMITTED = 0x04,

		PENDING_BANK_ACTION = 0x08,

		REOPENED_PENDING_CLIENT_ACTION = 0x10,

		CLOSED = 0x20
	}
}
