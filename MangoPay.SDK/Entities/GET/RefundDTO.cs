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
        public String InitialTransactionId { get; set; }

        /// <summary>Initial transaction type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public InitialTransactionType InitialTransactionType { get; set; }

        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }

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
        public String ResultCode { get; set; }

        /// <summary>The pre-authorization result message explaining the result code.</summary>
        public String ResultMessage { get; set; }

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
        public String CreditedWalletId { get; set; }

        /// <summary>Debited wallet identifier.</summary>
        public String DebitedWalletId { get; set; }

		/// <summary>Contains info about the reason for refund.</summary>
		public RefundReason RefundReason { get; set; }
    }
}
