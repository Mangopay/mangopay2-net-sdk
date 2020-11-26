using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInCardDirectDTO : PayInDTO
    {
        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        public String CardType { get; set; }

        /// <summary>Card identifier.</summary>
        public String CardId { get; set; }

        /// <summary>SecureMode { DEFAULT, FORCE }.</summary>
        public String SecureMode { get; set; }

        /// <summary>Secure mode redirect URL.</summary>
        public String SecureModeRedirectURL { get; set; }
        
        /// <summary>Secure mode return URL.</summary>
        public String SecureModeReturnURL { get; set; }

		/// <summary>The value is { true } if the SecureMode was used.</summary>
        public bool SecureModeNeeded { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public String StatementDescriptor { get; set; }

        public Billing Billing { get; set; }

        public SecurityInfo SecurityInfo { get; set; }

        public Shipping Shipping { get; set; }
    }
}
