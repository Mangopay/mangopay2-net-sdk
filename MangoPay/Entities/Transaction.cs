using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Transaction entity. Base class for: PayIn, PayOut, Transfer.</summary>
    public class Transaction : EntityBase
    {
        /// <summary>Author identifier.</summary>
        public String AuthorId;

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId;

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds;

        /// <summary>Credited funds.</summary>
        public Money CreditedFunds;

        /// <summary>Fees.</summary>
        public Money Fees;

        /// <summary>TransactionStatus { CREATED, SUCCEEDED, FAILED }.</summary>
        public String Status;

        /// <summary>Result code.</summary>
        public String ResultCode;

        /// <summary>The pre-authorization result message explaining the result code.</summary>
        public String ResultMessage;

        /// <summary>Execution date (UNIX timestamp).</summary>
        public long? ExecutionDate;

        /// <summary>TransactionType { PAYIN, PAYOUT, TRANSFER }.</summary>
        public String Type;

        /// <summary>TransactionNature { REGULAR, REFUND, REPUDIATION }.</summary>
        public String Nature;

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId;

        /// <summary>Debited wallet identifier.</summary>
        public string DebitedWalletId;

        /// <summary>Gets map which property is an object and what type of object.</summary>
        /// <returns>Collection of field name-field type pairs.</returns>
        public override Dictionary<String, Type> GetSubObjects()
        {

            Dictionary<String, Type> result = new Dictionary<String, Type>();

            result.Add("DebitedFunds", typeof(Money));
            result.Add("CreditedFunds", typeof(Money));
            result.Add("Fees", typeof(Money));

            return result;
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<String> GetReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("Status");
            result.Add("ResultCode");
            result.Add("ExecutionDate");

            return result;
        }
    }
}
