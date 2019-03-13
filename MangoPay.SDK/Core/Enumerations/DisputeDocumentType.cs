using System;

namespace MangoPay.SDK.Core.Enumerations
{
	[Flags]
	public enum DisputeDocumentType
	{
		/// <summary>Not specified.</summary>
		NotSpecified				= 0x00,

		DELIVERY_PROOF				= 0x01, 
		INVOICE						= 0x02, 
		REFUND_PROOF				= 0x04, 
		USER_CORRESPONDANCE			= 0x08, 
		USER_ACCEPTANCE_PROOF		= 0x10, 
		PRODUCT_REPLACEMENT_PROOF	= 0x20, 
		OTHER						= 0x40
	}
}
