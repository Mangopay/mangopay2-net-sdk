using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
	/// <summary>Mandate entity.</summary>
	public class MandateDTO : EntityBase
	{
		/// <summary>The bank account ID to associate this mandate against (and hence from where the payins will come from).</summary>
		public String BankAccountId { get; set; }

		/// <summary>Bank reference for the mandate.</summary>
		public String BankReference { get; set; }

		/// <summary>The type of mandate – it will be <code>SEPA</code> or <code>BACS</code> but will only be completed once the mandate has been submitted.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public MandateScheme? Scheme { get; set; }

		/// <summary>The language to use for the confirmation web page presented to your user.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public CultureCode Culture { get; set; }

		/// <summary>The URL to view/download the mandate document.</summary>
		public String DocumentURL { get; set; }

		/// <summary>The URL where you must redirect the user for them to confirm the setup of their mandate and then he will be redirected to the ReturnURL.</summary>
		public String RedirectURL { get; set; }

		/// <summary>URL format expected.</summary>
		public String ReturnURL { get; set; }

		/// <summary>ID of the user to which this mandate belongs.</summary>
		public String UserId { get; set; }

		/// <summary>The status of the mandate: 
		/// <code>CREATED</code> (the mandate has been created),
		/// <code>SUBMITTED</code> (the mandate has been submitted to the banks and you can now do payments with this mandate),
		/// <code>ACTIVE</code> (the mandate is active and has been accepted by the banks and/or successfully used in a payment),
		/// <code>FAILED</code> (the mandate has failed for a variety of reasons and is no longer available for payments).</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public MandateStatus Status { get; set; }

		/// <summary>Mandate result code.</summary>
		public String ResultCode { get; set; }

		/// <summary>Mandate result message.</summary>
		public String ResultMessage { get; set; }

		/// <summary>Type of mandate.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public MandateType MandateType { get; set; }

		/// <summary>How the mandate has been created.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public MandateExecutionType ExecutionType { get; set; }
	}
}
