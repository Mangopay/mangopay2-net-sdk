using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Filter for transaction list.</summary>
    public class FilterTransactions
    {
        /// <summary>Transaction status.</summary>
        public TransactionStatus? Status;

        /// <summary>Transaction type.</summary>
        public TransactionType? Type;

        /// <summary>Transaction nature.</summary>
        public TransactionNature? Nature;

        /// <summary>End date: return only transactions that have CreationDate BEFORE this date.</summary>
        public DateTime? BeforeDate;

        /// <summary>Start date: return only transactions that have CreationDate AFTER this date.</summary>
        public DateTime? AfterDate;

		/// <summary>Transaction ResultCode.</summary>
		public string ResultCode;

		/// <summary>Gets map of fields and values.</summary>
		/// <returns>Returns collection of field_name-field_value pairs.</returns>
		public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            UnixDateTimeConverter dateConverter = new UnixDateTimeConverter();

			if (Status.HasValue && Status.Value != TransactionStatus.NotSpecified) result.Add(Constants.STATUS, Status.Value.ToString("G").Replace(" ", ""));
			if (Type.HasValue && Type.Value != TransactionType.NotSpecified) result.Add(Constants.TYPE, Type.Value.ToString("G").Replace(" ", ""));
			if (Nature.HasValue && Nature != TransactionNature.NotSpecified) result.Add(Constants.NATURE, Nature.Value.ToString("G").Replace(" ", ""));
			if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());
			if (!string.IsNullOrEmpty(ResultCode)) result.Add(Constants.RESULT_CODE, ResultCode.ToString());

			return result;
        }
    }
}
