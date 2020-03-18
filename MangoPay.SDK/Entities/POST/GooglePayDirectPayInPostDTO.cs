using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Entities.POST
{
    public class GooglePayDirectPayInPostDTO : EntityPostBase
    {
        public GooglePayDirectPayInPostDTO()
        {

        }


        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Credited user identifier</summary>
        public String CreditedUserId { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }

        /// <summary>Debited founds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary> Payment Data </summary>
        public PaymentData PaymentData { get; set; }

        /// <summary> Billing </summary>
        public Billing Billing { get; set; }

        /// <summary> A custom description to appear on the user's bank statement </summary>
        public String StatementDescriptor { get; set; }
    }
}
