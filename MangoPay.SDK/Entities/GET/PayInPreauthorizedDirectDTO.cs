using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInPreauthorizedDirectDTO : PayInDTO
    {
        /// <summary>Pre-authorization identifier.</summary>
        public String PreauthorizationId { get; set; }

        /// <summary>Card identifier.</summary>
        public String CardId { get; set; }

        /// <summary>SecureMode { DEFAULT, FORCE }.</summary>
        public String SecureMode { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public String SecureModeReturnURL { get; set; }
    }
}
