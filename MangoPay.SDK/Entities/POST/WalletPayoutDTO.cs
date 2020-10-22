using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>
    /// Class used for wallets payouts
    /// </summary>
    public class WalletPayoutDTO : EntityPostBase
    {
        /// <summary>
        /// Money used
        /// </summary>
        public Money DebitedFunds { get; set; }

        /// <summary>
        /// the id of the bank account
        /// </summary>
        public string BankAccountId { get; set; }

        /// <summary>
        /// The id of the wallet
        /// </summary>
        public string DebitedWalletId { get; set; }

        /// <summary>
        /// bank wire reference
        /// </summary>
        public string BankWireRef { get; set; }
    }
}