using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
				result.Resource = token.SelectToken("Resource") != null ? token.SelectToken("Resource").ToString() : "";

				return (T)((object)result);
			}
			else return JsonConvert.DeserializeObject<T>(response.Content, new StringEnumConverter());
        }
    }
}
