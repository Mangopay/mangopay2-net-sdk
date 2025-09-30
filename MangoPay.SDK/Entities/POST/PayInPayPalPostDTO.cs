﻿using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>PayIn by PayPal POST entity.</summary>
    [Obsolete("PayInPayPalPostDTO is deprecated, please use PayInPayPalWebPostDTO instead.")]
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
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }

        /// <summary>Credited wallet identifier.</summary>
        public string CreditedWalletId { get; set; }

        /// <summary>Return URL.</summary>
        public string ReturnURL { get; set; }

        /// <summary>Credited user identifier.</summary>
        public string CreditedUserId { get; set; }

		/// <summary>The shipping address for PayPal PayIn.</summary>
		public ShippingAddress ShippingAddress { get; set; }
		
		/// <summary>
		/// The unique reference generated for the profiling session
		/// </summary>
		public string ProfilingAttemptReference { get; set; }
	}
}
