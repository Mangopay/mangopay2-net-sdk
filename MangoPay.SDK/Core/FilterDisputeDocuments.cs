using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Filter for dispute documents list.</summary>
	public class FilterDisputeDocuments
    {
        /// <summary>Dispute document status.</summary>
        public DisputeDocumentStatus? Status;

        /// <summary>Dispute document type.</summary>
		public DisputeDocumentType? Type;

        /// <summary>End date: return only dispute documents that have CreationDate BEFORE this date.</summary>
        public DateTime? BeforeDate;

		/// <summary>Start date: return only dispute documents that have CreationDate AFTER this date.</summary>
        public DateTime? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<String, String> GetValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            UnixDateTimeConverter dateConverter = new UnixDateTimeConverter();

			if (Status.HasValue && Status.Value != DisputeDocumentStatus.NotSpecified) result.Add(Constants.STATUS, Status.Value.ToString("G").Replace(" ", ""));
			if (Type.HasValue && Type.Value != DisputeDocumentType.NotSpecified) result.Add(Constants.TYPE, Type.Value.ToString("G").Replace(" ", ""));
			if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());

            return result;
        }
    }
}
