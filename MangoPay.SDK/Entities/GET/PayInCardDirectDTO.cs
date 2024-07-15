using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInCardDirectDTO : PayInDTO
    {
        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        public string CardType { get; set; }

        /// <summary>Card identifier.</summary>
        public string CardId { get; set; }

        /// <summary>SecureMode { DEFAULT, FORCE }.</summary>
        public string SecureMode { get; set; }

        /// <summary>Secure mode redirect URL.</summary>
        public string SecureModeRedirectURL { get; set; }
        
        /// <summary>Secure mode return URL.</summary>
        public string SecureModeReturnURL { get; set; }

		/// <summary>The value is { true } if the SecureMode was used.</summary>
        public bool SecureModeNeeded { get; set; }

        /// <summary>An optional value to be specified on the user's bank statement.</summary>
        public string StatementDescriptor { get; set; }

        public Billing Billing { get; set; }

        public SecurityInfo SecurityInfo { get; set; }

        public Shipping Shipping { get; set; }

        public BrowserInfo BrowserInfo { get; set; }

        /// <summary>
        /// → Is not Mandatory for 3DSv1 (flag “Use 3DSV2 Scenario” OFF)
        /// → Is mandatory when the flag “Use 3DSV2 Scenario” is active for (FORCE/DEFAULT/FRICTIONLESS both 3)
        /// </summary>
        public string IpAddress { get; set; }
        
        public CardInfo CardInfo { get; set; }
        
        /// <summary>
        /// The channel through which the user provided their card details, used to indicate mail-order and telephone-order (MOTO) payments:
        /// ECommerce – Payment received online.
        /// TelephoneOrder – Payment received via mail order or telephone order (MOTO).
        /// </summary>
        public string PaymentCategory { get; set; }
    }
}
