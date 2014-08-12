using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>Filter for events list.</summary>
    public class FilterEvents : Dto
    {
        /// <summary>Type of events.</summary>
        public EventType Type;

        /// <summary>Start date in Unix format.</summary>
        public Int64? BeforeDate;

        /// <summary>End date in Unix format.</summary>
        public Int64? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Collection of field name-field value pairs.</returns>
        public Dictionary<String, String> GetValues()
        {
            Dictionary<String, String> result = new Dictionary<String, String>();

            result.Add("eventtype", Type.ToString());

            if (BeforeDate != null) result.Add("beforeDate", BeforeDate.ToString());
            if (AfterDate != null) result.Add("afterDate", AfterDate.ToString());

            return result;
        }
    }
}
