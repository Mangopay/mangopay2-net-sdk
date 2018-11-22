using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Entities
{
    public class SecurityInfo
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public AVSResult AVSResult { get; set; }
    }
}
