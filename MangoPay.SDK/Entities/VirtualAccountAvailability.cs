using System.Collections.Generic;
using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Entities
{
    public class VirtualAccountAvailability 
    {

        public VirtualAccountAvailability()
        {
            Currencies = new List<CurrencyIso>();
        }
        
        public VirtualAccountAvailability(string country, bool available)
        {
            Country = country;
            Available = available;
            Currencies = new List<CurrencyIso>();
        }

        private string Country { get; set; }

        private bool Available { get; set; }

        public List<CurrencyIso> Currencies;
    }
}