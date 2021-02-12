using JsonSubTypes;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;

namespace MangoPay.SDK.Core
{
    public sealed class MangoPayJsonDeserializer : IDeserializer
    {
        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
			if (typeof(T) == typeof(MangoPay.SDK.Entities.GET.IdempotencyResponseDTO))
			{
				JToken token = JObject.Parse(response.Content);

				MangoPay.SDK.Entities.GET.IdempotencyResponseDTO result = new Entities.GET.IdempotencyResponseDTO();

				result.StatusCode = (string)token.SelectToken("StatusCode");
				result.ContentLength = (string)token.SelectToken("ContentLength");
				result.ContentType = (string)token.SelectToken("ContentType");
				result.Date = (string)token.SelectToken("Date");
				result.RequestURL = (string)token.SelectToken("RequestURL");
				result.Resource = token.SelectToken("Resource") != null ? token.SelectToken("Resource").ToString() : "";

				return (T)((object)result);
			}

            if (typeof(T) == typeof(BankAccountDTO))
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(
                    JsonSubtypesConverterBuilder.Of<BankAccountDTO>("Type")
                        .RegisterSubtype<BankAccountIbanDTO>(BankAccountType.IBAN)
                        .SerializeDiscriminatorProperty()
                        .Build()
                );

                return JsonConvert.DeserializeObject<T>(response.Content, settings);
			}

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

		public T DeserializeString<T>(object resource)
		{
			return JsonConvert.DeserializeObject<T>((string)resource);
		}
	}
}
