using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Card pre-authorization POST entity.</summary>
    public class CardPreAuthorizationPostDTO : EntityPostBase
    {
        public CardPreAuthorizationPostDTO(string authorId, Money debitedFunds, SecureMode secureMode, string cardId, string secureModeReturnURL, string statementDescriptor = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            SecureMode = secureMode;
            CardId = cardId;
            SecureModeReturnURL = secureModeReturnURL;
            StatementDescriptor = statementDescriptor;
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
        public PaymentStatus? PaymentStatus { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public String StatementDescriptor { get; set; }

        public Billing Billing { get; set; }

        public SecurityInfo SecurityInfo { get; set; }

        public Money RemainingFunds { get; set; }

        public Boolean MultiCapture { get; set; }

        public Shipping Shipping { get; set; }

        public BrowserInfo BrowserInfo { get; set; }

        /// <summary>
        /// → Is not Mandatory for 3DSv1 (flag “Use 3DSV2 Scenario” OFF)
        /// → Is mandatory when the flag “Use 3DSV2 Scenario” is active for (FORCE/DEFAULT/FRICTIONLESS both 3)
        /// </summary>
        public string IpAddress { get; set; }

    }
}
