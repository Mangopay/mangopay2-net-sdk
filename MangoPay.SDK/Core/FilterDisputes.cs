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
        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            UnixDateTimeConverter dateConverter = new UnixDateTimeConverter();

			if (Status != DisputeStatus.NotSpecified) result.Add(Constants.STATUS, Status.ToString("G").Replace(" ", ""));
			if (Type != DisputeType.NotSpecified) result.Add(Constants.DISPUTE_TYPE, Type.ToString("G").Replace(" ", ""));
			if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());

            return result;
        }
    }
}
