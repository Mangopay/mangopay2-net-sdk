using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    public class CardValidationPostDTO: EntityPostBase
    {
        public CardValidationPostDTO(string authorId, string secureModeReturnUrl, string ipAddress, BrowserInfo browserInfo,
            string tag = null, SecureMode? secureMode = null, string paymentCategory = null)
        {
            AuthorId = authorId;
            SecureModeReturnUrl = secureModeReturnUrl;
            IpAddress = ipAddress;
            BrowserInfo = browserInfo;
            Tag = tag;
            SecureMode = secureMode;
            PaymentCategory = paymentCategory;
        }
            
        /// <summary> The unique identifier of the user at the source of the transaction.
        public string AuthorId;
        
        /// <summary> The URL to which users are automatically returned after
        /// 3DS2 if it is triggered (i.e., if the SecureModeNeeded parameter is set to true).
        public string SecureModeReturnUrl;
        
        /// <summary> The IP address of the end user initiating the transaction, in IPV4 or IPV6 format
        public string IpAddress;
        
        /// <summary> Information about the browser used by the end user (author) to perform the payment.
        public BrowserInfo BrowserInfo;
        
        /// <summary>Secure mode.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode? SecureMode { get; set; }
        
        /// <summary>
        /// The channel through which the user provided their card details, used to indicate mail-order and telephone-order (MOTO) payments:
        /// ECommerce – Payment received online.
        /// TelephoneOrder – Payment received via mail order or telephone order (MOTO).
        /// </summary>
        public string PaymentCategory { get; set; }
    }
}