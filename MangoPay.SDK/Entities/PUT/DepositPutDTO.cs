using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Update Deposit DTO.</summary>
    public class DepositPutDTO : EntityPutBase
    {
        /// <summary>The status of the payment after the Deposit. You can pass the PaymentStatus from “WAITING” to “CANCELED” should you need/want to.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus PaymentStatus { get; set; }
    }
}