using System;
using System.Collections.Generic;
using System.Text;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MangoPay.SDK.Entities.GET
{
    public class RecurringPayInDTO : PayInDTO
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureMode? SecureMode { get; set; }

        public String CardId { get; set; }

        public bool SecureModeNeeded { get; set; }

        public String SecureModeRedirectURL { get; set; }

        public String SecureModeReturnURL { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public CultureCode? Culture { get; set; }

        public SecurityInfo SecurityInfo { get; set; }

        public string StatementDescriptor { get; set; }

        public BrowserInfo BrowserInfo { get; set; }

        public string IpAddress { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }

        public string Requested3DSVersion { get; set; }

        public string Applied3DSVersion { get; set; }

        public string RecurringPayinRegistrationId { get; set; }
    }
}
