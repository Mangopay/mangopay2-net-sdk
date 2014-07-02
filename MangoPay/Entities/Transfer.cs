using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Transfer entity.</summary>
    public class Transfer : Transaction
    {
        /// <summary>Debited wallet identifier.</summary>
        public String DebitedWalletId;

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId;
    }
}
