using System;
using System.Collections.Generic;
using RestSharp;

namespace MangoPay.SDK.Core
{
    public class LastRequestInfo
    {
        public RestRequest Request { get; set; }

        public RestResponse Response { get; set; }

        [Obsolete("This property only holds one of the values. Please use 'RateLimits' instead")]
        public string RateLimitingCallsAllowed { get; set; }

        [Obsolete("This property only holds one of the values. Please use 'RateLimits' instead")]
        public string RateLimitingCallsMade { get; set; }

        [Obsolete("This property only holds one of the values. Please use 'RateLimits' instead")]
        public string RateLimitingCallsRemaining { get; set; }

        [Obsolete("This property only holds one of the values. Please use 'RateLimits' instead")]
        public string RateLimitingTimeTillReset { get; set; }

        public List<RateLimit> RateLimits { get; set; }
    }
}