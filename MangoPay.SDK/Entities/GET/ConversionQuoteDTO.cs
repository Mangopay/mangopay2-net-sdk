using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class ConversionQuoteDTO : EntityBase
    {
        /// <summary>The date and time at which the quote expires</summary>
        [JsonConverter(typeof(Core.UnixDateTimeConverter))]
        public DateTime ExpirationDate { get; set; }

        /// <summary>The status of the transaction.</summary>
        public string Status { get; set; }

        /// <summary>The sell funds</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>The buy funds</summary>
        public Money CreditedFunds { get; set; }

        /// <summary>Real time indicative market rate of a specific currency pair</summary>
        public ConversionRateDTO ConversionRateResponse { get; set; }
    }
}