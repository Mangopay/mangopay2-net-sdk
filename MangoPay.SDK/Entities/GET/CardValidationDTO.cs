using System;
using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Entities.GET
{
    public class CardValidationDTO: EntityBase
    {

        /// <summary> The unique identifier of the user at the source of the transaction.
        public string AuthorId;
        
        /// <summary> The URL to which users are automatically returned after
        /// 3DS2 if it is triggered (i.e., if the SecureModeNeeded parameter is set to true).
        public string SecureModeReturnUrl;
        
        /// <summary> The URL to which users are to be redirected to proceed to 3DS2 validation.
        public string SecureModeRedirectURL;
        
        /// <summary> Whether or not the SecureMode was used.
        public Boolean SecureModeNeeded;
        
        /// <summary> The IP address of the end user initiating the transaction, in IPV4 or IPV6 format
        public string IpAddress;
        
        /// <summary> Information about the browser used by the end user (author) to perform the payment.
        public BrowserInfo BrowserInfo;
        
        /// <summary> Whether the card is valid or not.
        public string Validity;
        
        /// <summary> The type of transaction. In the specific case of the Card Validation object, this value
        /// indicates a transaction made to perform a strong customer authentication without debiting the card.
        public TransactionType Type;
        
        /// <summary> The 3DS protocol version applied to the transaction.
        public string Applied3DSVersion;
        
        /// <summary>
        public TransactionStatus Status;
        
        /// <summary> The code indicating the result of the operation. This information is mostly
        /// used to handle errors or for filtering purposes.
        public string ResultCode;
        
        /// <summary> The explanation of the result code.
        public string ResultMessage;
    }
}