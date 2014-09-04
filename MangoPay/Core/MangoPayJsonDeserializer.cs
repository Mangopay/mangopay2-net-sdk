using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Deserializers;

namespace MangoPay.Core
{
    public sealed class MangoPayJsonDeserializer : IDeserializer
    {
        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, new StringEnumConverter());
        }
    }
}
