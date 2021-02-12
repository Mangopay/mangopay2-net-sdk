using System;
using System.Collections.Generic;
using System.Text;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MangoPay.SDK.Core.Deserializers
{
    public class BankAccountDeserializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var bankAccountType = jsonObject["Type"];
            if (bankAccountType == null) throw new ArgumentException("Couldn't cast json");
            
            BankAccountDTO dto;
            Enum.TryParse(bankAccountType.ToString(), out BankAccountType bat);
            switch (bat)
            {
                case BankAccountType.IBAN:
                    dto = new BankAccountIbanDTO();
                    break;
                case BankAccountType.GB:
                    dto = new BankAccountGbDTO();
                    break;
                case BankAccountType.US:
                    dto = new BankAccountUsDTO();
                    break;
                case BankAccountType.CA:
                    dto = new BankAccountCaDTO();
                    break;
                case BankAccountType.OTHER:
                    dto = new BankAccountOtherDTO();
                    break;
                case BankAccountType.NotSpecified:
                    throw new ArgumentOutOfRangeException();
                default:
                    throw new ArgumentOutOfRangeException();
            }

            serializer.Populate(jsonObject.CreateReader(), dto);

            return dto;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(BankAccountDTO).IsAssignableFrom(objectType);
        }

        public override bool CanWrite => false;
    }
}
