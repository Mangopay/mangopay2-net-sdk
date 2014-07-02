using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Hooks and Notifications entity.</summary>
    public class Hook : EntityBase
    {
        /// <summary>This is the URL where you receive notification for each EventType.</summary>
        public String Url;

        /// <summary>Status { ENABLED, DISABLED }.</summary>
        public String Status;

        /// <summary>Validity { VALID, INVALID }.</summary>
        public String Validity;

        /// <summary>Event type (the <code>EventType.All</code> value is forbidden here).</summary>
        public EventType EventType;
    }
}
