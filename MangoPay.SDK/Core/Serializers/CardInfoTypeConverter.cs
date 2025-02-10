using System;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;

namespace MangoPay.SDK.Core.Serializers
{
    /// <summary>
    /// Serialize "CHARGE_CARD" as "CHARGE CARD"
    /// </summary>
    public class CardInfoTypeConverter : JsonConverter<CardInfoType?>
    {
        public override void WriteJson(JsonWriter writer, CardInfoType? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            var stringValue = value == CardInfoType.CHARGE_CARD ? "CHARGE CARD" : value.ToString();
            writer.WriteValue(stringValue);
        }

        public override CardInfoType? ReadJson(JsonReader reader, Type objectType, CardInfoType? existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }
            var value = reader.Value.ToString();
            var cardInfo = value == "CHARGE CARD" ? CardInfoType.CHARGE_CARD : (CardInfoType)Enum.Parse(typeof(CardInfoType), value);
            return cardInfo;
        }
    }
}