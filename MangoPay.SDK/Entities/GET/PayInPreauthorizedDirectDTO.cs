using System;

namespace MangoPay.SDK.Entities.GET
{
    public class PayInPreauthorizedDirectDTO : PayInDTO
    {
        /// <summary>Pre-authorization identifier.</summary>
        public string PreauthorizationId { get; set; }

        /// <summary>Card identifier.</summary>
        public string CardId { get; set; }

        /// <summary>SecureMode { DEFAULT, FORCE }.</summary>
        public string SecureMode { get; set; }

        /// <summary>Secure mode return URL.</summary>
        public string SecureModeReturnURL { get; set; }

        public Shipping Shipping { get; set; }

        public BrowserInfo BrowserInfo { get; set; }

        /// <summary>
        /// → Is not Mandatory for 3DSv1 (flag “Use 3DSV2 Scenario” OFF)
        /// → Is mandatory when the flag “Use 3DSV2 Scenario” is active for (FORCE/DEFAULT/FRICTIONLESS both 3)
        /// </summary>
        public string IpAddress { get; set; }
    }
}
