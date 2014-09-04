using MangoPay.Core;
using System;

namespace MangoPay.Entities
{
    /// <summary>PayIn bank wire direct POST entity.</summary>
    public class PayInBankWireDirectPostDTO : EntityPostBase
    {
        public PayInBankWireDirectPostDTO(string authorId, String creditedWalletId, Money declaredDebitedFunds, Money declaredFees)
        {
            AuthorId = authorId;
            CreditedWalletId = creditedWalletId;
            DeclaredDebitedFunds = declaredDebitedFunds;
            DeclaredFees = declaredFees;
        }

        /// <summary>Declared debited funds.</summary>
        public Money DeclaredDebitedFunds { get; set; }

        /// <summary>Declared fees.</summary>
        public Money DeclaredFees { get; set; }

        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }
    }
}
