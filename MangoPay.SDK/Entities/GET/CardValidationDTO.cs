using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
    public class CardValidationDTO: EntityBase
    {

        /// <summary> The unique identifier of the user at the source of the transaction. &lt;/summary&gt;
        public string AuthorId;
        
        /// <summary> The URL to which users are automatically returned after
        /// 3DS2 if it is triggered (i.e., if the SecureModeNeeded parameter is set to true). &lt;/summary&gt;
        public string SecureModeReturnUrl;
        
        /// <summary> The URL to which users are to be redirected to proceed to 3DS2 validation. &lt;/summary&gt;
        public string SecureModeRedirectURL;
        
        /// <summary> Whether or not the SecureMode was used. &lt;/summary&gt;
        public Boolean SecureModeNeeded;
        
        /// <summary> The IP address of the end user initiating the transaction, in IPV4 or IPV6 format &lt;/summary&gt;
        public string IpAddress;
        
        /// <summary> Information about the browser used by the end user (author) to perform the payment. &lt;/summary&gt;
        public BrowserInfo BrowserInfo;
        
        /// <summary> Whether the card is valid or not. &lt;/summary&gt;
        public string Validity;
        
        /// <summary> The type of transaction. In the specific case of the Card Validation object, this value
        /// indicates a transaction made to perform a strong customer authentication without debiting the card. &lt;/summary&gt;
        public TransactionType Type;
        
        /// <summary> The 3DS protocol version applied to the transaction. &lt;/summary&gt;
        public string Applied3DSVersion;
        
        /// <summary>
        public TransactionStatus Status;
        
        /// <summary> The code indicating the result of the operation. This information is mostly
        /// used to handle errors or for filtering purposes. &lt;/summary&gt;
        public string ResultCode;
        
        /// <summary> The explanation of the result code. </summary>
        public string ResultMessage;

        ///  <summary> Allowed values: VISA, MASTERCARD, CB, MAESTRO
        /// 
        /// The card network to use, as chosen by the cardholder, in case of co-branded card products. &lt;/summary&gt;
        public string PreferredCardNetwork;

        /// &lt;summary&gt; The date and time at which successful authorization occurred. If authorization failed, the value is null. &lt;/summary&gt;
        public DateTime AuthorizationDate;

        /// <summary> Information about the card used for the transaction. </summary>
        public CardInfo CardInfo;
    }
}