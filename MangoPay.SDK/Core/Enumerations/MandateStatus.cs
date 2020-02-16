
namespace MangoPay.SDK.Core.Enumerations
{
	/// <summary>Status of the mandate.</summary>
	public enum MandateStatus
	{
		/// <summary>Not specified.</summary>
		NotSpecified = 0,

		/// <summary>The mandate has been created.</summary>
		CREATED,

		/// <summary>The mandate has been submitted to the banks and you can now do payments with this mandate.</summary>
		SUBMITTED,

		/// <summary>The mandate is active and has been accepted by the banks and/or successfully used in a payment.</summary>
		ACTIVE,

		/// <summary>The mandate has failed for a variety of reasons and is no longer available for payments.</summary>
		FAILED,
		
		/// <summary>The mandate his expired and is no longer available for Payins. A new mandate must be created</summary>
		EXPIRED
		
		
	}
}
