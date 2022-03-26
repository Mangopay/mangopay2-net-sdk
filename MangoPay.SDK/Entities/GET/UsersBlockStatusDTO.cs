using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.GET
{
    public class UsersBlockStatusDTO : EntityBase
    {
        public string ActionCode { get; set; }

        public ScopeBlocked ScopeBlocked { get; set; }

        public List<string> GetActionCodes()
        {
            var list = new List<string>
            {
                "008701",
                "008702",
                "008703",
                "008704",
                "008710",
                "008711",
                "008712",
                "008713",
                "008714"
            };

            return list;
        }
    }

    public class ScopeBlocked
    {
        public bool Inflows { get; set; }

        public bool Outflows { get; set;  }
    }
}
