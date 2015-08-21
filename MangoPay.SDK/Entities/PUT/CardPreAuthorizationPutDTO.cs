using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.PUT
{
    /// <summary>Card Pre-authorization PUT entity.</summary>
    public class CardPreAuthorizationPutDTO : EntityPutBase
    {
        /// <summary>Custom data.</summary>
        public String Tag { get; set; }

        /// <summary>The status of the payment after the PreAuthorization.</summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus? PaymentStatus { get; set; }
    }
}
