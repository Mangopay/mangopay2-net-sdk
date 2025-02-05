using System;
using MangoPay.SDK.Entities;
using Newtonsoft.Json;

namespace MangoPay.SDK.Core.Serializers
{
    /// <summary>
    /// Write 'amount' as NULL if the value is 0
    /// </summary>
    public class MoneyConverter : JsonConverter<Money>
    {
        public override void WriteJson(JsonWriter writer, Money value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();

            writer.WritePropertyName("Currency");
            serializer.Serialize(writer, value.Currency.ToString());

            writer.WritePropertyName("Amount");
            if (value.Amount == 0)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(value.Amount);
            }

            writer.WriteEndObject();
        }

        public override Money ReadJson(JsonReader reader, Type objectType, Money existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var obj = serializer.Deserialize<dynamic>(reader);
            return new Money
            {
                Currency = obj.Currency,
                Amount = obj.Amount ?? 0
            };
        }
    }
}