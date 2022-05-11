using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Filter for events list.</summary>
    public class FilterEvents
    {
        /// <summary>Type of events.</summary>
        public EventType Type;

        /// <summary>End date.</summary>
        public DateTime? BeforeDate;

        /// <summary>Start date.</summary>
        public DateTime? AfterDate;

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Collection of field name-field value pairs.</returns>
        public Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();

			if (Type != EventType.All)
				result.Add(Constants.EVENTTYPE, Type.ToString("G").Replace(" ", ""));

			var dateConverter = new UnixDateTimeConverter();

            if (BeforeDate.HasValue) result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue) result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());

            return result;
        }
    }
}
