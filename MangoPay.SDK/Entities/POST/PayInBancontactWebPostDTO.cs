using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.POST
{
    public class PayInBancontactWebPostDTO : EntityPostBase
    {
        public PayInBancontactWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId,
            string returnUrl, string tag = null, string statementDescriptor = null, bool? recurring = null, CultureCode? culture = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            StatementDescriptor = statementDescriptor;
            Tag = tag;
            Recurring = recurring;
            Culture = culture;
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

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }
        
        /// <summary>Culture (language).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode? Culture { get; set; }
        
        /// <summary>Whether the Bancontact pay-ins are being made to be re-used in a recurring payment flow</summary>
        public bool? Recurring { get; set; }
    }
}