using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.POST
{
    public class RecurringPayInCITPostDTO : EntityPostBase
    {
        public string RecurringPayinRegistrationId { get; set; }

        public BrowserInfo BrowserInfo { get; set; }

        public string IpAddress { get; set; }

        public string SecureModeReturnURL { get; set; }

        public string StatementDescriptor { get; set; }
    }
}
