using System.Collections.Generic;
using MangoPay.SDK.Core.Deserializers;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.GET
{
    [JsonConverter(typeof(PayPalDataCollectionDeserializer))]
    public class PayPalDataCollectionDTO : EntityBase
    {
        public Dictionary<string, object> Data { get; set; }
    }
}