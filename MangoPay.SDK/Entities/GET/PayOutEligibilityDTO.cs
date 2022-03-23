using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.GET
{
    public class PayOutEligibilityDTO : EntityBase
    {
        public InstantPayoutDTO InstantPayout { get; set; }
    }

    public class InstantPayoutDTO
    {
        public bool? IsReachable { get; set; }

        public FallbackReason UnreachableReason { get; set; }
    }
}
