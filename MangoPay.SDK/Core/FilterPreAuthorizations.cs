using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
	/// <summary>Filter for PreAuthorizations list.</summary>
	public class FilterPreAuthorizations
	{
		/// <summary>PreAuthorization ResultCode.</summary>
		public string ResultCode;

		/// <summary>Status of the PreAuthorization.</summary>
		public PreAuthorizationStatus Status;

		/// <summary>The status of the payment after the PreAuthorization. You can pass the PaymentStatus from "WAITING" to "CANCELED" should you need/want to.</summary>
		public PaymentStatus PaymentStatus;

		/// <summary>Gets map of fields and values.</summary>
		/// <returns>Returns collection of field_name-field_value pairs.</returns>
		public Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();


			if (!string.IsNullOrEmpty(ResultCode)) result.Add(Constants.RESULT_CODE, ResultCode.ToString());
			if (Status != PreAuthorizationStatus.NotSpecified) result.Add(Constants.STATUS, Status.ToString());
			if (PaymentStatus != PaymentStatus.NotSpecified) result.Add(Constants.PAYMENT_STATUS, PaymentStatus.ToString());

            return result;
        }
    }
}
