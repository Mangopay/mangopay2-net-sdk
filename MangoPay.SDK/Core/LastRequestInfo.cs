using RestSharp;

namespace MangoPay.SDK.Core
{
    public class LastRequestInfo
    {
        public IRestRequest Request { get; set; }    
        public IRestResponse Response { get; set; }
        public string RateLimitingCallsAllowed { get; set; }
        public string RateLimitingCallsRemaining { get; set; }
        public string RateLimitingTimeTillReset { get; set; }
    }
}