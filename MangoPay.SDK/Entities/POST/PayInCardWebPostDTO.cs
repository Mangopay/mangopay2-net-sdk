using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn card web POST entity.</summary>
    public class PayInCardWebPostDTO : EntityPostBase
    {
        public PayInCardWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl, CultureCode culture, CardType cardType, string statementDescriptor = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            Culture = culture;
            CardType = cardType;
            StatementDescriptor = statementDescriptor;
        }

        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }

        /// <summary>Return URL.</summary>
        public String ReturnURL { get; set; }

        /// <summary>The URL where iFramed template is hosted.</summary>
        public TemplateURLOptions TemplateURLOptions { get; set; }

        /// <summary>Culture.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
		public CultureCode Culture { get; set; }

        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType CardType { get; set; }

        /// <summary>Mode3DSType { DEFAULT, FORCE }.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode? SecureMode { get; set; }

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public String StatementDescriptor { get; set; }
    }
}
