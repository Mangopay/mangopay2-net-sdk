using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
	/// <summary>Filter for refunds list.</summary>
	public class FilterRefunds
	{
		/// <summary>Refund ResultCode.</summary>
		public string ResultCode;

		/// <summary>Status of the Transaction.</summary>
		public TransactionStatus Status;

		/// <summary>Gets map of fields and values.</summary>
		/// <returns>Returns collection of field_name-field_value pairs.</returns>
		public Dictionary<String, String> GetValues()
        {
            var result = new Dictionary<String, String>();

			if (!String.IsNullOrEmpty(ResultCode)) result.Add(Constants.RESULT_CODE, ResultCode.ToString());
			if (Status != TransactionStatus.NotSpecified) result.Add(Constants.TRANSACTION_STATUS, Status.ToString());

            return result;
        }
    }
}
