using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    public class PayInGooglePayDirectPostDTO: EntityPostBase
    {
        public PayInGooglePayDirectPostDTO(
            string authorId, 
            Money debitedFunds, 
            Money fees, 
            string creditedWalletId,
            string returnUrl,
            string secureModeReturnUrl, 
            string ipAddress,
            BrowserInfo browserInfo,
            string paymentData, 
            SecureMode secureMode = Core.Enumerations.SecureMode.DEFAULT, 
            Billing billing = null, 
            Shipping shipping = null, 
            string statementDescriptor = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            SecureModeReturnURL = secureModeReturnUrl;
            IpAddress = ipAddress;
            BrowserInfo = browserInfo;
            PaymentData = paymentData;
            SecureMode = secureMode;
            Billing = billing;
            Shipping = shipping;
            StatementDescriptor = statementDescriptor;
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
        
        /// <summary> The URL to which the user is redirected to complete the payment.
        public string SecureModeReturnURL { get; set; }
        
        /// <summary> The mode applied for the 3DS2 protocol for CB,Visa,and Mastercard.
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode? SecureMode { get; set; }
        
        /// <summary> Information about the browser used by the end user (author)
        /// to perform the payment.
        public string IpAddress { get; set; }
        
        /// <summary> The IP address of the end user initiating the transaction, in IPV4 or IPV6 format.
        public BrowserInfo BrowserInfo { get; set; }
        
        /// <summary> Data received from the GooglePayAPI
        public string PaymentData { get; set; }
        
        /// <summary> Information about the end user billing address
        public Billing Billing { get; set; }

        /// <summary> Information about the end user shipping address
        public Shipping Shipping { get; set; }
        
        /// <summary> A custom description to appear on the user’s bank statement
        public string StatementDescriptor { get; set; }
    }
}