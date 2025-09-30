namespace MangoPay.SDK.Entities.GET
{
    public class PayInSwishWebPostDTO: EntityPostBase
    {
        public PayInSwishWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
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
        /// <p>Allowed values: WEB, APP</p>
        /// <p>Default value: WEB</p>
        /// <p>The platform environment of the post-payment flow. The PaymentFlow value combines with the ReturnURL to manage the redirection behavior after payment:</p>
        /// <p>Set the value to APP to send the user to your platform’s mobile app</p>
        /// <p>Set the value to WEB to send the user to a web browser</p>
        /// <p>In both cases you need to provide the relevant ReturnURL, whether to your app or website.</p>
        /// </summary>
        public string PaymentFlow { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}