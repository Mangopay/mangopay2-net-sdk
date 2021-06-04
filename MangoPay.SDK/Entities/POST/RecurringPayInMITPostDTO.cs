using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.POST
{
    public class RecurringPayInMITPostDTO : EntityPostBase
    {
        public string RecurringPayinRegistrationId { get; set; }

        public Money DebitedFunds { get; set; }

        public Money Fees { get; set; }

        public string StatementDescriptor { get; set; }
    }
}
