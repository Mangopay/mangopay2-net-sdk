using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Entities
{
    public class VirtualAccountCapabilities
    {
        public VirtualAccountCapabilities()
        {
            Currencies = new List<CurrencyIso>();
        }

        public VirtualAccountCapabilities(bool localPayInAvailable, bool internationalPayInAvailable)
        {
            LocalPayInAvailable = localPayInAvailable;
            InternationalPayInAvailable = internationalPayInAvailable;
            Currencies = new List<CurrencyIso>();
        }

        private bool LocalPayInAvailable { get; set; }
        
        private bool InternationalPayInAvailable { get; set; }

        public List<CurrencyIso> Currencies;
    }
}