using RestSharp;

namespace MangoPay.SDK.Core
{
    public class LastRequestInfo
    {
        public RestRequest Request { get; set; }    

        public RestResponse Response { get; set; }

        public string RateLimitingCallsAllowed { get; set; }

        public string RateLimitingCallsMade { get; set; }

        public string RateLimitingCallsRemaining { get; set; }

        public string RateLimitingTimeTillReset { get; set; }
    }
}