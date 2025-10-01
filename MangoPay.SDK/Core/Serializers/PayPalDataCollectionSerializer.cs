using System;
using System.Collections.Generic;
using MangoPay.SDK.Entities.POST;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MangoPay.SDK.Core.Serializers
{
    public class PayPalDataCollectionSerializer : JsonConverter<PayPalDataCollectionPostDTO>
    {
        public override void WriteJson(JsonWriter writer, PayPalDataCollectionPostDTO value, JsonSerializer serializer)
        {
            var obj = new JObject();

            if (value.Data != null)
            {
                foreach (var kvp in value.Data)
                {
                    obj[kvp.Key] = kvp.Value != null ? JToken.FromObject(kvp.Value, serializer) : JValue.CreateNull();
                }
            }

            obj.WriteTo(writer);
        }

        public override PayPalDataCollectionPostDTO ReadJson(JsonReader reader, Type objectType, PayPalDataCollectionPostDTO existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var dto = new PayPalDataCollectionPostDTO
            {
                Data = new Dictionary<string, object>()
            };

            foreach (var property in obj.Properties())
            {
                dto.Data[property.Name] = property.Value.ToObject<object>();
            }

            return dto;
        }
    }
}