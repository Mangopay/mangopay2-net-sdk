namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn mandate direct POST entity.</summary>
    public class PayInMandateDirectPostDTO : EntityPostBase
    {
		public PayInMandateDirectPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl, string mandateId, string statementDescriptor = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
			ReturnURL = returnUrl;
            MandateId = mandateId;
	    StatementDescriptor = statementDescriptor;
        }

		/// <summary>The user identifier of the Payin transaction’s author.</summary>
		public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

		/// <summary>URL format expected.</summary>
		public string ReturnURL { get; set; }

        /// <summary>Mandate identifier.</summary>
		public string MandateId { get; set; }

		/// <summary>Credited user identifier.</summary>
		public string CreditedUserId { get; set; }

	/// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
	
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}
