using System;
using System.Collections.Generic;
using System.Text;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.PUT
{
    public class RecurringPayInPutDTO : EntityPutBase
    {
        public string CardId { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RecurringPaymentStatus Status { get; set; }
    }
}
