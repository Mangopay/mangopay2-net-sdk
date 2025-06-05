using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Core
{
    /// <summary>Filter for reports list V2 (2025).</summary>
    public class FilterReportsListV2
    {
        /// <summary>
        /// The date and time after which the report’s transaction was created, based on the transaction’s CreationDate.
        /// </summary>
        public DateTime? AfterDate { get; set; }

        /// <summary>
        /// The date and time before which the report’s transaction was created, based on the transaction’s CreationDate.
        /// </summary>
        public DateTime? BeforeDate { get; set; }

        /// <summary>
        /// Status of the report.
        /// Returned values: PENDING, READY_FOR_DOWNLOAD, FAILED, EXPIRED
        /// </summary>
        public string Status { get; set; }

        /// <summary>Gets map of fields and values.</summary>
        /// <returns>Returns collection of field_name-field_value pairs.</returns>
        public Dictionary<string, string> GetValues()
        {
            var result = new Dictionary<string, string>();

            var dateConverter = new UnixDateTimeConverter();

            if (BeforeDate.HasValue)
                result.Add(Constants.BEFOREDATE, dateConverter.ConvertToUnixFormat(BeforeDate).Value.ToString());
            if (AfterDate.HasValue)
                result.Add(Constants.AFTERDATE, dateConverter.ConvertToUnixFormat(AfterDate).Value.ToString());
            if (!string.IsNullOrEmpty(Status)) result.Add(Constants.STATUS, Status);

            return result;
        }
    }
}