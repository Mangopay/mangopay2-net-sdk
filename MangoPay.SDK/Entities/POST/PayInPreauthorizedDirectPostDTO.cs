using MangoPay.SDK.Core;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn pre-authorized direct POST entity.</summary>
    public class PayInPreauthorizedDirectPostDTO : EntityPostBase
    {
        public PayInPreauthorizedDirectPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string preauthorizationId, BrowserInfo bInfo = null)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            PreauthorizationId = preauthorizationId;
            BrowserInfo = bInfo;
        }

        /// <summary>Author identifier.</summary>
        public String AuthorId { get; set; }

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }

        /// <summary>Pre-authorization identifier.</summary>
        public String PreauthorizationId { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public String SecureModeReturnURL { get; set; }

        public BrowserInfo BrowserInfo { get; set; }

        /// <summary>
        /// → Is not Mandatory for 3DSv1 (flag “Use 3DSV2 Scenario” OFF)
        /// → Is mandatory when the flag “Use 3DSV2 Scenario” is active for (FORCE/DEFAULT/FRICTIONLESS both 3)
        /// </summary>
        public string IpAddress { get; set; }
    }
}
