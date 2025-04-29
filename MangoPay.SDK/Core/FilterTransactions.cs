using System;
using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;

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
		
		/// <summary>Possible values: USER_PRESENT, USER_NOT_PRESENT</summary>
		public string ScaContext;

		/// <summary>Gets map of fields and values.</summary>
		/// <returns>Returns collection of field_name-field_value pairs.</returns>
		public Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();

            var dateConverter = new UnixDateTimeConverter();

			if (Status.HasValue && Status.Value != TransactionStatus.NotSpecified) result.Add(Constants.STATUS, Status.Value.ToString("G").Replace(" ", ""));
			if (Type.HasValue && Type.Value != TransactionType.NotSpecified) result.Add(Constants.TYPE, Type.Value.ToString("G").Replace(" ", ""));
			if (Nature.HasValue && Nature != TransactionNature.NotSpecified) result.Add(Constants.NATURE, Nature.Value.ToString("G").Replace(" ", ""));
			if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());
			if (!string.IsNullOrEmpty(ResultCode)) result.Add(Constants.RESULT_CODE, ResultCode.ToString());
			if (!string.IsNullOrEmpty(ScaContext)) result.Add(Constants.SCA_CONTEXT, ScaContext);

			return result;
        }
    }
}
