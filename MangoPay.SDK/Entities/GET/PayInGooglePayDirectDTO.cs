
namespace MangoPay.SDK.Entities.GET
{
    public class PayInGooglePayDirectDTO: PayInDTO
    {
        /// <summary> The URL to which the user is redirected to complete the payment.
        public string SecureModeReturnURL { get; set; }
        
        /// <summary> The URL to which the user is redirected to complete the payment.
        public string SecureModeRedirectURL { get; set; }
        
        public bool SecureModeNeeded { get; set; }
        
        /// <summary> Information about the browser used by the end user (author)
        /// to perform the payment.
        public string IpAddress { get; set; }
        
        /// <summary> The IP address of the end user initiating the transaction, in IPV4 or IPV6 format.
        public BrowserInfo BrowserInfo { get; set; }
        
        /// <summary> Information about the end user billing address
        public Billing Billing { get; set; }

        /// <summary> Information about the end user shipping address
        public Shipping Shipping { get; set; }
        
        /// <summary> A custom description to appear on the user’s bank statement
        public string StatementDescriptor { get; set; }
    }
}