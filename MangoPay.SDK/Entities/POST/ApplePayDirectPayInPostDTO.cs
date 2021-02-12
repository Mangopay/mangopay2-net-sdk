using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    public class ApplePayDirectPayInPostDTO : EntityPostBase
    {
        public ApplePayDirectPayInPostDTO()
        {
            
        }

        public ApplePayDirectPayInPostDTO(String authorId, String creditedWalletId, String creditedUserId, Money debitedFunds, Money fees, PaymentData paymentData, String statementDescriptor)
        {
            AuthorId = authorId;
            
            DebitedFunds = debitedFunds;
            CreditedWalletId = creditedWalletId;
            CreditedUserId = creditedUserId;
            Fees = fees;
            PaymentData = paymentData;
            StatementDescriptor = statementDescriptor;
        }
        
        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Debited founds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Credited user identifier</summary>
        public String CreditedUserId { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary> Payment Data </summary>
        public PaymentData PaymentData { get; set; }

        /// <summary> A custom description to appear on the user's bank statement </summary>
        public String StatementDescriptor { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PayInPaymentType PaymentType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PayInExecutionType ExecutionType { get; set; }
    }
}