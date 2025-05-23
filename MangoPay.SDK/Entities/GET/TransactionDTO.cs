using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Transaction entity. Base class for: PayIn, PayOut, Transfer.</summary>
    public class TransactionDTO : EntityBase
    {
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
        
        /// <summary>Deposit identifier.</summary>
        public string DepositId { get; set; }
    }
}
