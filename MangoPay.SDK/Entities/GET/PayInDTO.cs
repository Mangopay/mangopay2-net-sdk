using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
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
        
        /// <summary>
        /// The unique reference generated for the profiling session
        /// </summary>
        public string ProfilingAttemptReference { get; set; }
    }
}
