using System;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
    public class CardValidationDTO : EntityBase
    {
        /// <summary> The unique identifier of the user at the source of the transaction. </summary>
        public string AuthorId { get; set; }

        /// <summary> The URL to which users are automatically returned after
        /// 3DS2 if it is triggered (i.e., if the SecureModeNeeded parameter is set to true). </summary>
        public string SecureModeReturnUrl { get; set; }

        /// <summary> The URL to which users are to be redirected to proceed to 3DS2 validation. </summary>
        public string SecureModeRedirectURL { get; set; }

        /// <summary> Whether or not the SecureMode was used. </summary>
        public Boolean SecureModeNeeded { get; set; }

        /// <summary> The IP address of the end user initiating the transaction, in IPV4 or IPV6 format </summary>
        public string IpAddress { get; set; }

        /// <summary> Information about the browser used by the end user (author) to perform the payment. </summary>
        public BrowserInfo BrowserInfo { get; set; }

        /// <summary> Whether the card is valid or not. </summary>
        public string Validity { get; set; }

        /// <summary> The type of transaction. In the specific case of the Card Validation object, this value
        /// indicates a transaction made to perform a strong customer authentication without debiting the card. </summary>
        public TransactionType Type { get; set; }

        /// <summary> The 3DS protocol version applied to the transaction. </summary>
        public string Applied3DSVersion { get; set; }

        /// <summary> The status of the transaction. </summary>
        public TransactionStatus Status { get; set; }

        /// <summary> The code indicating the result of the operation. This information is mostly
        /// used to handle errors or for filtering purposes. </summary>
        public string ResultCode { get; set; }

        /// <summary> The explanation of the result code. </summary>
        public string ResultMessage { get; set; }

        ///  <summary> Allowed values: VISA, MASTERCARD, CB, MAESTRO
        /// 
        /// The card network to use, as chosen by the cardholder, in case of co-branded card products. </summary>
        public string PreferredCardNetwork { get; set; }

        /// <summary> The date and time at which successful authorization occurred. If authorization failed, the value is null. </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? AuthorizationDate { get; set; }

        /// <summary> Information about the card used for the transaction. </summary>
        public CardInfo CardInfo { get; set; }
    }
}