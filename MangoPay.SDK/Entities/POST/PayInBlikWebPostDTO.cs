namespace MangoPay.SDK.Entities.POST
{
    public class PayInBlikWebPostDTO: EntityPostBase
    {
        public PayInBlikWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId,
            string returnUrl, string tag = null, string statementDescriptor = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            StatementDescriptor = statementDescriptor;
            Tag = tag;
        }

        public PayInBlikWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId,
            string returnUrl, string code, string ipAddress, BrowserInfo browserInfo, string tag = null,
            string statementDescriptor = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            StatementDescriptor = statementDescriptor;
            Tag = tag;
            Code = code;
            IpAddress = ipAddress;
            BrowserInfo = browserInfo;
        }
        
        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }
        
        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }
        
        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }
        
        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not
        public string ReturnURL { get; set; }
        
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
        
        /// <summary>
        /// The 6-digit code from the user’s banking application.
        /// Required when creating a Blik PayIn with code.
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// The IP address of the end user initiating the transaction, in IPV4 or IPV6 format.
        /// Required when creating a Blik PayIn with code.
        /// </summary>
        public string IpAddress { get; set; }
        
        /// <summary>
        /// Information about the browser used by the end user (author) to perform the payment.
        /// Required when creating a Blik PayIn with code.
        /// </summary>
        public BrowserInfo BrowserInfo { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}