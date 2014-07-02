using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>Event entity.</summary>
    public class Event : EntityBase
    {
        /// <summary>Resource identifier.</summary>
        public String ResourceId;

        /// <summary>Type of event.</summary>
        public String EventType;

        /// <summary>Date as UNIX timestamp.</summary>
        public long Date;
    }
}
