using System.Collections.Generic;

namespace MangoPay.SDK.Entities
{
    public class PayoutMethods : EntityBase
    {
        public List<string> AvailablePayoutMethods { get; set; }
    }
}