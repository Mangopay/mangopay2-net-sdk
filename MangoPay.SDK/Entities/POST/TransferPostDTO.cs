using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Transfer POST entity.</summary>
    public class TransferPostDTO : EntityPostBase
    {
        public TransferPostDTO(string authorId, string creditedUserId, Money debitedFunds, Money fees, string debitedWalletId, string creditedWalletId)
        {
            AuthorId = authorId;
            CreditedUserId = creditedUserId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            DebitedWalletId = debitedWalletId;
            CreditedWalletId = creditedWalletId;
        }

        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Debited wallet identifier.</summary>
        public String DebitedWalletId { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }
    }
}
