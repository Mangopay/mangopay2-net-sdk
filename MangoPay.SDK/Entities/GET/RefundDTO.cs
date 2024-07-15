using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Refund entity.</summary>
    public class RefundDTO : EntityBase
    {
        /// <summary>Initial transaction identifier.</summary>
        public string InitialTransactionId { get; set; }

        /// <summary>Initial transaction type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public InitialTransactionType InitialTransactionType { get; set; }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public string CreditedUserId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Credited funds.</summary>
        public Money CreditedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Transaction status.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }

        /// <summary>Result code.</summary>
        public string ResultCode { get; set; }

        /// <summary>The pre-authorization result message explaining the result code.</summary>
        public string ResultMessage { get; set; }

        /// <summary>Execution date.</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime? ExecutionDate { get; set; }

        /// <summary>Transaction type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }

        /// <summary>Transaction nature.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionNature Nature { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary>Debited wallet identifier.</summary>
        public string DebitedWalletId { get; set; }

		/// <summary>Contains info about the reason for refund.</summary>
		public RefundReason RefundReason { get; set; }
        
        public string Reference { get; set; }
        
        /// <summary>
        /// Custom description to appear on the user’s bank statement along with the platform name.
        /// Note that a particular bank may show more or less information.
        /// </summary>
        public string StatementDescriptor { get; set; }
    }
}
