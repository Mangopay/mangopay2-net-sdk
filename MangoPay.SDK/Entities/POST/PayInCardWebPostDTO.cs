using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn card web POST entity.</summary>
    public class PayInCardWebPostDTO : EntityPostBase
    {
        public PayInCardWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl, CultureCode culture, CardType cardType, string statementDescriptor = null, string bic = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            Culture = culture;
            CardType = cardType;
            StatementDescriptor = statementDescriptor;
            Bic = bic;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary>Return URL.</summary>
        public string ReturnURL { get; set; }

        /// <summary>The URL where iFramed template is hosted.</summary>
        public TemplateURLOptionsCard TemplateURLOptionsCard { get; set; }

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
        public string CreditedUserId { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }

        public Shipping Shipping { get; set; }
        
        /// <summary> The BIC identifier of the end-user’s bank
        public string Bic { get; set; }
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}
