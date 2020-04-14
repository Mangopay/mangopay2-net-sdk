using System;

namespace MangoPay.SDK.Core
{
    /// <summary>Template URL options Card class.</summary>
    public class TemplateURLOptionsCard
    {
        /// <summary>PAYLINE: will be deprecated on April 30th in production and ignored. Please use PAYLINEV2 parameter</summary>
        [ObsoleteAttribute("PAYLINE attribute is now obsolete. Please use PAYLINEV2 instead", true)] 
        public String PAYLINE;
        
        /// <summary>PAYLINEV2: should be set to apply your own template on our new payment widget for Payin Card Web</summary>
        public String PAYLINEV2;
    }
}
