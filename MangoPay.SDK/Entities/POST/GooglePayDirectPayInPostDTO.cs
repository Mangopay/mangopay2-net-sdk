﻿namespace MangoPay.SDK.Entities.POST
{
    public class GooglePayDirectPayInPostDTO : EntityPostBase
    {
        public GooglePayDirectPayInPostDTO()
        {

        }


        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Credited user identifier</summary>
        public string CreditedUserId { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary>Debited founds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary> Payment Data </summary>
        public PaymentData PaymentData { get; set; }

        /// <summary> Billing </summary>
        public Billing Billing { get; set; }

        /// <summary> A custom description to appear on the user's bank statement </summary>
        public string StatementDescriptor { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}
