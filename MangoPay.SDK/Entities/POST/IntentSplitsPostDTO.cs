using System.Collections.Generic;

namespace MangoPay.SDK.Entities.POST
{
    public class IntentSplitsPostDTO : EntityPostBase
    {
        public List<PayInIntentSplitPostDTO> Splits { get; set; }
    }
}