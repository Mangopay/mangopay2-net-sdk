namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn mbway web POST entity.</summary>
    public class PayInMbwayWebPostDTO : EntityPostBase
    {
        public PayInMbwayWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string phone, string statementDescriptor = null, string tag = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            StatementDescriptor = statementDescriptor;
            Tag = tag;
            Phone = phone;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }
        
        /// <summary>The mobile phone number of the user initiating the pay-in Country code
        /// followed by hash symbol (#) followed by the rest of the number. Only digits and hash allowed</summary>
        public string Phone { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}
