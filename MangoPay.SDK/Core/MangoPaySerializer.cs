using RestSharp;
using RestSharp.Serializers;

namespace MangoPay.SDK.Core
{
    public sealed class MangoPaySerializer : IRestSerializer
    {
        public MangoPaySerializer()
        {
            Serializer = new MangoPayJsonSerializer();
            Deserializer = new MangoPayJsonDeserializer();
            SupportsContentType = type => true;
        }

        public string Serialize(object obj)
        {
            var ser = new MangoPayJsonSerializer();
            return ser.Serialize(obj);
        }

        public string Serialize(Parameter bodyParameter) => Serialize(bodyParameter.Value);

        public ISerializer Serializer { get; }

        public IDeserializer Deserializer { get; }

        public string[] AcceptedContentTypes { get; } =
        {
            "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
        };

        public SupportsContentType SupportsContentType { get; }

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }
}