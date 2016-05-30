
namespace MangoPay.SDK.Core.Enumerations
{
	/// <summary>Status of a report.</summary>
	public enum ReportStatus
	{
		/// <summary>Not specified.</summary>
		NotSpecified = 0,

		/// <summary>Report is pending.</summary>
		PENDING,

		/// <summary>Report has expired.</summary>
		EXPIRED,

		/// <summary>Report creation failed.</summary>
		FAILED,

		/// <summary>Report is ready to download.</summary>
		READY_FOR_DOWNLOAD
	}
}
