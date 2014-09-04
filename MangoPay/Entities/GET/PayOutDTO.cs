using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.Entities
{
    /// <summary>PayOut entity.</summary>
    public class PayOutDTO : TransactionDTO
    {
        /// <summary>Payment type.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayOutPaymentType PaymentType { get; set; }
    }
}
