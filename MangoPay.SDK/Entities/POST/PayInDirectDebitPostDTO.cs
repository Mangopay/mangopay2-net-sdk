using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn direct debit POST entity.</summary>
    public class PayInDirectDebitPostDTO : EntityPostBase
    {
        public PayInDirectDebitPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl, CultureCode culture, DirectDebitType directDebitType)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            Culture = culture;
            DirectDebitType = directDebitType;
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

        /// <summary>The URL where you host the iFramed template.</summary>
        public TemplateURLOptions TemplateURLOptions { get; set; }

        /// <summary>Culture (language).</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode Culture { get; set; }

        /// <summary>Direct debit type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public DirectDebitType DirectDebitType { get; set; }

        /// <summary>Identifier of the credited user (owner of the credited wallet).</summary>
        public String CreditedUserId { get; set; }
    }
}
