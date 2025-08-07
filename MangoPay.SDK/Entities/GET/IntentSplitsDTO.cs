using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
    public class IntentSplitsDTO : EntityBase
    {
        public List<PayInIntentSplitDTO> Splits { get; set; }
    }
}