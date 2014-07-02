using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Refund entity.</summary>
    public class Refund : Transaction
    {
        /// <summary>Initial transaction identifier.</summary>
        public String InitialTransactionId;

        /// <summary>Debited wallet identifier.</summary>
        public String DebitedWalletId;

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId;
    }
}
