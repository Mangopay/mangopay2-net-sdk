using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn bank wire direct POST entity.</summary>
    public class PayInBankWireDirectPostDTO : EntityPostBase
    {
        public PayInBankWireDirectPostDTO(string authorId, string creditedWalletId, Money declaredDebitedFunds, Money declaredFees)
         : this(authorId, creditedWalletId, declaredDebitedFunds, declaredFees, null)
        {
        }
        
        public PayInBankWireDirectPostDTO(string authorId, string creditedWalletId, Money declaredDebitedFunds, Money declaredFees, string creditedUserId)
        {
            AuthorId = authorId;
            CreditedWalletId = creditedWalletId;
            DeclaredDebitedFunds = declaredDebitedFunds;
            DeclaredFees = declaredFees;
            CreditedUserId = creditedUserId;
        }

        /// <summary>Declared debited funds.</summary>
        public Money DeclaredDebitedFunds { get; set; }

        /// <summary>Declared fees.</summary>
        public Money DeclaredFees { get; set; }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public string CreditedUserId { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }
    }
}
