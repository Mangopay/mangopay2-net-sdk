using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace MangoPay.SDK.Core
{
    public sealed class MangoPayJsonSerializer : ISerializer
    {
        public ContentType ContentType { get; set; }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
