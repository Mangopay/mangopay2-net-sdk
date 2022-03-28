using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.POST
{
    public class CreateOAuthTokenPostDTO
    {
        [JsonProperty("grant_type")]
        public string GrantType => "client_credentials";
    }
}
