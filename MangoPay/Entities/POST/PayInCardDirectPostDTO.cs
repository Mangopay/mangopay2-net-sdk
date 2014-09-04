using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>PayIn card direct POST entity.</summary>
    public class PayInCardDirectPostDTO : EntityPostBase
    {
        public PayInCardDirectPostDTO(string authorId, string creditedUserId, Money debitedFunds, Money fees, string creditedWalletId, string secureModeReturnURL, string cardId)
        {
            AuthorId = authorId;
            CreditedUserId = creditedUserId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            SecureModeReturnURL = secureModeReturnURL;
            CardId = cardId;
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
        public String SecureMode { get; set; }

        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        public String CardType { get; set; }
    }
}
