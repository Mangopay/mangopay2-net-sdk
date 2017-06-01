using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn by PayPal POST entity.</summary>
    public class PayInPayPalPostDTO : EntityPostBase
    {
		public PayInPayPalPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
            ReturnURL = returnUrl;
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

        /// <summary>Credited user identifier.</summary>
        public String CreditedUserId { get; set; }

		/// <summary>The shipping address for PayPal PayIn.</summary>
		public ShippingAddress ShippingAddress { get; set; }
	}
}
