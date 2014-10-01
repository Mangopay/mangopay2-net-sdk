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

        /// <summary>Transaction direction.</summary>
        public TransactionDirection? Direction;

        /// <summary>End date: return only transactions that have CreationDate BEFORE this date.</summary>
        public DateTime? BeforeDate;

        /// <summary>Start date: return only transactions that have CreationDate AFTER this date.</summary>
        public DateTime? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<String, String> GetValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            UnixDateTimeConverter dateConverter = new UnixDateTimeConverter();

            if (Status.HasValue) result.Add(Constants.STATUS, Status.Value.ToString());
            if (Type.HasValue) result.Add(Constants.TYPE, Type.Value.ToString());
            if (Nature.HasValue) result.Add(Constants.NATURE, Nature.Value.ToString());
            if (Direction.HasValue) result.Add(Constants.DIRECTION, Direction.Value.ToString());
            if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());

            return result;
        }
    }
}
