using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn card web POST entity.</summary>
    public class PayInCardWebPostDTO : EntityPostBase
    {
        public PayInCardWebPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl, string culture, string cardType)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
            Culture = culture;
            CardType = cardType;
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
        public String TemplateURLOptions { get; set; }

        /// <summary>Culture.</summary>
        public String Culture { get; set; }

        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        public String CardType { get; set; }

        /// <summary>Mode3DSType { DEFAULT, FORCE }.</summary>
        public String SecureMode { get; set; }

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }
    }
}
