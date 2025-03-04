namespace MangoPay.SDK.Entities.GET
{
    public class PayInBlikWebDTO: PayInDTO
    {
        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
        
        /// <summary> The URL to redirect to after the payment, whether the transaction was successful or not
        public string ReturnURL { get; set; }

        /// <summary> The URL to which the user is redirected to complete the payment
        public string RedirectURL { get; set; }
        
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
    }
}