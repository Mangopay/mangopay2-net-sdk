using System;

namespace MangoPay.Entities
{
    public class PayInCardWebDTO : PayInDTO
    {
        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        public String CardType { get; set; }

        /// <summary>Card identifier.</summary>
        public String CardId { get; set; }

        /// <summary>URL format expected.</summary>
        public String TemplateURL { get; set; }

        /// <summary>Culture.</summary>
        public String Culture { get; set; }

        /// <summary>Mode3DSType { DEFAULT, FORCE }.</summary>
        public String SecureMode { get; set; }

        /// <summary>Redirect URL.</summary>
        public String RedirectURL { get; set; }

        /// <summary>Return URL.</summary>
        public String ReturnURL { get; set; }
    }
}
