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

        /// <summary>Start date in Unix format: return only transactions that have CreationDate BEFORE this date.</summary>
        public Int64? BeforeDate;

        /// <summary>End date in Unix format: return only transactions that have CreationDate AFTER this date.</summary>
        public Int64? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<String, String> GetValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            if (Status.HasValue) result.Add(Constants.STATUS, Status.Value.ToString());
            if (Type.HasValue) result.Add(Constants.TYPE, Type.Value.ToString());
            if (Nature.HasValue) result.Add(Constants.NATURE, Nature.Value.ToString());
            if (Direction.HasValue) result.Add(Constants.DIRECTION, Direction.Value.ToString());
            if (BeforeDate != null) result.Add(Constants.BEFOREDATE, BeforeDate.ToString());
            if (AfterDate != null) result.Add(Constants.AFTERDATE, AfterDate.ToString());

            return result;
        }
    }
}
