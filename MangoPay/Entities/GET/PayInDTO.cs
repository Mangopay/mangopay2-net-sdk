using MangoPay.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.Entities
{
    /// <summary>PayIn entity.</summary>
    public class PayInDTO : TransactionDTO
    {
        /// <summary>Type of payment.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayInPaymentType PaymentType { get; set; }

        /// <summary>Type of execution.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PayInExecutionType ExecutionType { get; set; }
    }
}
