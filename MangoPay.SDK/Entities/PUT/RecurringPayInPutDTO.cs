using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.PUT
{
    public class RecurringPayInPutDTO : EntityPutBase
    {
        public string CardId { get; set; }

        public Billing Billing { get; set; }

        public Shipping Shipping { get; set; }
    }
}
