using System;
using System.Collections.Generic;

namespace MangoPay.Core
{
    /// <summary>Filter for events list.</summary>
    public class FilterEvents
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

			if (Type != EventType.All)
				result.Add(Constants.EVENTTYPE, Type.ToString());

            if (BeforeDate != null) result.Add(Constants.BEFOREDATE, BeforeDate.ToString());
            if (AfterDate != null) result.Add(Constants.AFTERDATE, AfterDate.ToString());

            return result;
        }
    }
}
