using System;

namespace MangoPay.SDK.Entities.GET
{
    public class ApplePayDirectPayinDTO : PayInDTO
    {
        /// <summary> A custom description to appear </summary>
        public String StatementDescriptor { get; set; }
    }
}