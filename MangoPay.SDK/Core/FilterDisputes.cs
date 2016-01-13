using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Filter for disputes list.</summary>
	public class FilterDisputes
    {
		/// <summary>Dispute status.</summary>
		public DisputeStatus Status;

		/// <summary>Dispute type.</summary>
		public DisputeType Type;

        /// <summary>End date: return only disputes that have CreationDate BEFORE this date.</summary>
        public DateTime? BeforeDate;

        /// <summary>Start date: return only disputes that have CreationDate AFTER this date.</summary>
        public DateTime? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<String, String> GetValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            UnixDateTimeConverter dateConverter = new UnixDateTimeConverter();

			if (Status != DisputeStatus.NotSpecified) result.Add(Constants.STATUS, Status.ToString());
			if (Type != DisputeType.NotSpecified) result.Add(Constants.DISPUTE_TYPE, Type.ToString());
            if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());

            return result;
        }
    }
}
