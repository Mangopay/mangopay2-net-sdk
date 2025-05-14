using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnixDateTimeConverter = MangoPay.SDK.Core.UnixDateTimeConverter;

namespace MangoPay.SDK.Entities.GET
{
    /// <summary>Deposit entity.</summary>
    public class DepositDTO : EntityBase
    {
        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Deposit status.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DepositStatus Status { get; set; }

        /// <summary>The status of the payment after the deposit.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>Details about payments related to the deposit object.</summary>
        public PayinsLinkedDTO PayinsLinked { get; set; }

        /// <summary>ResultCode.</summary>
        public string ResultCode { get; set; }

        /// <summary>ResultMessage.</summary>
        public string ResultMessage { get; set; }

        /// <summary>CardId.</summary>
        public string CardId { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public string SecureModeReturnURL { get; set; }

        /// <summary>Secure mode redirect URL.</summary>
        public string SecureModeRedirectURL { get; set; }

        /// <summary>The value is { true } if the SecureMode was used.</summary>
        public bool? SecureModeNeeded { get; set; }

        /// <summary>The date when the payment is to be processed by.</summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime ExpirationDate { get; set; }

        /// <summary>Type of payment. In this case CARD</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayInPaymentType PaymentType { get; set; }

        /// <summary>Type of execution. In this case DIRECT</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayInExecutionType ExecutionType { get; set; }

        /// <summary>StatementDescriptor.</summary>
        public string StatementDescriptor { get; set; }

        /// <summary>Culture (language).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode? Culture { get; set; }

        /// <summary>IpAddress.</summary>
        public string IpAddress { get; set; }

        /// <summary>BrowserInfo.</summary>
        public BrowserInfo BrowserInfo { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }

        public string Requested3DSVersion { get; set; }

        public string Applied3DSVersion { get; set; }
        
        public CardInfo CardInfo { get; set; }
    }
}