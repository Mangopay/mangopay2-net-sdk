using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.Entities
{
    /// <summary>Card pre-authorization POST entity.</summary>
    public class CardPreAuthorizationPostDTO : EntityPostBase
    {
        public CardPreAuthorizationPostDTO(string authorId, Money debitedFunds, SecureMode secureMode, string cardId, string secureModeReturnURL)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            SecureMode = secureMode;
            CardId = cardId;
            SecureModeReturnURL = secureModeReturnURL;
        }

        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Secure mode.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode SecureMode { get; set; }

        /// <summary>Card identifier.</summary>
        public String CardId { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public String SecureModeReturnURL { get; set; }

        /// <summary>The status of the payment after the PreAuthorization.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; }
    }
}
