using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Client bankwire direct POST entity.</summary>
    public class ClientBankWireDirectPostDTO : EntityPostBase
    {
        public ClientBankWireDirectPostDTO(string creditedWalletAlias, Money declaredDebitedFunds)
        {
			CreditedWalletId = creditedWalletAlias;
            DeclaredDebitedFunds = declaredDebitedFunds;
        }

        /// <summary>Declared debited funds.</summary>
        public Money DeclaredDebitedFunds { get; set; }

        /// <summary>Credited wallet alias.</summary>
        public String CreditedWalletId { get; set; }
    }
}
