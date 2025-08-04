namespace MangoPay.SDK.Entities.POST
{
    public class PayInBizumWebPostDTO : EntityPostBase
    {
        public PayInBizumWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId,
            string statementDescriptor = null, string returnUrl = null, string phone = null,
            string profilingAttemptReference = null, string tag = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            Tag = tag;
            StatementDescriptor = statementDescriptor;
            ReturnUrl = returnUrl;
            Phone = phone;
            ProfilingAttemptReference = profilingAttemptReference;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary>
        /// Max. length: 10 characters; only alphanumeric and spaces
        /// Custom description to appear on the user’s bank statement along with the platform name.
        /// Different banks may show more or less information.
        /// </summary>
        public string StatementDescriptor { get; set; }

        /// <summary>
        /// The URL to which the user is returned after the payment, whether the transaction is successful or not.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Format: International E.164 standard (preceded by plus sign and country code, +34 in Spain); pattern: ^\+[1-9][\d]{4,14}$
        /// If the Phone parameter is sent, then RedirectURL is not returned and ReturnURL is ignored.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}