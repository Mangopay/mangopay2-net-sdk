
namespace MangoPay.SDK.Core.Enumerations
{
    /// <summary>Dispute document status enumeration.</summary>
	public enum DisputeDocumentStatus
    {
        /// <summary>Not specified.</summary>
        NotSpecified,

        /// <summary>CREATED dispute document status.</summary>
        CREATED,

		/// <summary>VALIDATION ASKED dispute document status.</summary>
        VALIDATION_ASKED,

		/// <summary>VALIDATED dispute document status.</summary>
        VALIDATED,

		/// <summary>REFUSED dispute document status.</summary>
        REFUSED
    }
}
