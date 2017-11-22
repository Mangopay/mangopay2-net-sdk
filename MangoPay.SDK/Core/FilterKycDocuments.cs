using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Filter for KYC documents list.</summary>
    public class FilterKycDocuments
    {
        /// <summary>Document status.</summary>
        public KycStatus? Status;

        /// <summary>Document type.</summary>
        public KycDocumentType? Type;

        /// <summary>End date: return only documents that have CreationDate BEFORE this date.</summary>
        public DateTime? BeforeDate;

        /// <summary>Start date: return only documents that have CreationDate AFTER this date.</summary>
        public DateTime? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<String, String> GetValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            UnixDateTimeConverter dateConverter = new UnixDateTimeConverter();

			if (Status.HasValue && Status.Value != KycStatus.NotSpecified) result.Add(Constants.STATUS, Status.Value.ToString("G").Replace(" ", ""));
			if (Type.HasValue && Type.Value != KycDocumentType.NotSpecified) result.Add(Constants.TYPE, Type.Value.ToString("G").Replace(" ", ""));
			if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());

            return result;
        }
    }
}
