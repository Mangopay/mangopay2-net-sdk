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
        
        /// <summary>Secure mode needed.</summary>
        public String SecureModeNeeded { get; set; }
    }
}
