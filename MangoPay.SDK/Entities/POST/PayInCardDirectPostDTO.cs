using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn card direct POST entity.</summary>
    public class PayInCardDirectPostDTO : EntityPostBase
    {
        public PayInCardDirectPostDTO(string authorId, string creditedUserId, Money debitedFunds, Money fees, string creditedWalletId, string secureModeReturnURL, string cardId, string statementDescriptor = null, Billing billing = null, BrowserInfo bInfo = null)
        {
            AuthorId = authorId;
            CreditedUserId = creditedUserId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            SecureModeReturnURL = secureModeReturnURL;
            CardId = cardId;
            StatementDescriptor = statementDescriptor;
            Billing = Billing;
            BrowserInfo = bInfo;
        }

        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public String SecureModeReturnURL { get; set; }

        /// <summary>Card identifier.</summary>
        public String CardId { get; set; }

        /// <summary>SecureMode { DEFAULT, FORCE }.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode? SecureMode { get; set; }

        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType? CardType { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public String StatementDescriptor { get; set; }

        public Billing Billing { get; set; }

        public SecurityInfo SecurityInfo { get; set; }
        
        public BrowserInfo BrowserInfo { get; set; }
    }
}
