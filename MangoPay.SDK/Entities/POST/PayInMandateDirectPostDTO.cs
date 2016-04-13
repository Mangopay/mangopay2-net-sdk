using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn mandate direct POST entity.</summary>
    public class PayInMandateDirectPostDTO : EntityPostBase
    {
		public PayInMandateDirectPostDTO(string authorId, Money debitedFunds, Money fees, string creditedWalletId, string returnUrl, string mandateId)
        {
            AuthorId = authorId;
            DebitedFunds = debitedFunds;
            Fees = fees;
            CreditedWalletId = creditedWalletId;
			ReturnURL = returnUrl;
            MandateId = mandateId;
        }

		/// <summary>The user identifier of the Payin transaction’s author.</summary>
		public String AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId { get; set; }

		/// <summary>URL format expected.</summary>
		public String ReturnURL { get; set; }

        /// <summary>Mandate identifier.</summary>
		public String MandateId { get; set; }

		/// <summary>Credited user identifier.</summary>
		public String CreditedUserId { get; set; }
    }
}
