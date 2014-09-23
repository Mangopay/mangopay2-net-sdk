using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities
{
    /// <summary>Class represents money value with currency.</summary>
    public class Money
    {
        /// <summary>Currency code in ISO 4217 standard.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyIso Currency;

        /// <summary>Amount of money.</summary>
        public int Amount;
    }
}
