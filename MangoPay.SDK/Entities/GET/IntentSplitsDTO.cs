using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    public class IntentSplitsDTO : EntityBase
    {
        public List<PayInIntentSplit> Splits { get; set; }
    }
}