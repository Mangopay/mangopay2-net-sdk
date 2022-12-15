using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class CardPreAuthorizedDepositPayInDTO : EntityBase
    {
        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>Credited User identifier.</summary>
        public string CreditedUserId { get; set; }
        
        /// <summary>Deposit identifier.</summary>
        public string DepositId { get; set; }
        
        /// <summary>ResultCode.</summary>
        public string ResultCode { get; set; }

        /// <summary>ResultMessage.</summary>
        public string ResultMessage { get; set; }
        
        /// <summary>Transaction status.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }
        
        /// <summary>The execution date.</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime ExecutionDate { get; set; }
        
        /// <summary>Transaction type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        
        /// <summary>Transaction nature.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionNature Nature { get; set; }
        
        /// <summary>Type of payment.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayInPaymentType PaymentType { get; set; }

        /// <summary>Type of execution.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayInExecutionType ExecutionType { get; set; }
        
        /// <summary>Debited Funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Credited Funds.</summary>
        public Money CreditedFunds { get; set; }
        
        /// <summary>Fees.</summary>
        public Money Fees { get; set; }
    }
}