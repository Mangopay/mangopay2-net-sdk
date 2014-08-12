using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Filter for transaction list.</summary>
    public class FilterTransactions : Dto
    {
        /// <summary>TransactionStatus { CREATED, SUCCEEDED, FAILED }.</summary>
        public String Status;

        /// <summary>TransactionType { PAYIN, PAYOUT, TRANSFER }.</summary>
        public String Type;

        /// <summary>TransactionNature { REGULAR, REFUND, REPUDIATION }.</summary>
        public String Nature;

        /// <summary>TransactionDirection { DEBIT, CREDIT }.</summary>
        public String Direction;

        /// <summary>Start date in Unix format: return only transactions that have CreationDate BEFORE this date.</summary>
        public Int64? BeforeDate;

        /// <summary>End date in Unix format: return only transactions that have CreationDate AFTER this date.</summary>
        public Int64? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<String, String> GetValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            if (!String.IsNullOrEmpty(Status)) result.Add("Status", Status);
            if (!String.IsNullOrEmpty(Type)) result.Add("Type", Type);
            if (!String.IsNullOrEmpty(Nature)) result.Add("Nature", Nature);
            if (!String.IsNullOrEmpty(Direction)) result.Add("Direction", Direction);
            if (BeforeDate != null) result.Add("BeforeDate", BeforeDate.ToString());
            if (AfterDate != null) result.Add("AfterDate", AfterDate.ToString());

            return result;
        }
    }
}
