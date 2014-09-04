using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Serializers;

namespace MangoPay.Core
{
    public sealed class MangoPayJsonSerializer : ISerializer
    {
        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, new StringEnumConverter());
        }
    }
}
