using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.GET
{
    public class UsersBlockStatusDTO
    {
        public string Id { get; set; }

        public string ActionCode { get; set; }

        public ScopeBlocked ScopeBlocked { get; set;  }
    }

    public class ScopeBlocked
    {
        public bool Inflows { get; set; }

        public bool Outflows { get; set;  }
    }
}
