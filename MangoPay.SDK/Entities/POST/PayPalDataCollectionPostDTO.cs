using System.Collections.Generic;
using MangoPay.SDK.Core.Serializers;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.POST
{
    [JsonConverter(typeof(PayPalDataCollectionSerializer))]
    public class PayPalDataCollectionPostDTO : EntityPostBase
    {
        public Dictionary<string, object> Data { get; set; }
    }
}