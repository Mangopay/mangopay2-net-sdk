﻿using System;
using System.Collections.Generic;
using MangoPay.SDK.Core;
using Newtonsoft.Json;

namespace MangoPay.SDK.Entities.POST
{
    public class ReportPostDTO : EntityPostBase
    {
        /// <summary>
        /// The format in which the report is going to be downloaded.
        /// </summary>
        public string DownloadFormat { get; set; }

        /// <summary>
        /// Type of the report: USER_WALLET_TRANSACTIONS, COLLECTED_FEES
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// The sorting direction of the CreationDate column. By default, the generated report is sorted by ascending creation date.
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// The date and time after which the report’s transaction was created, based on the transaction’s CreationDate.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime AfterDate { get; set; }

        /// <summary>
        /// The date and time before which the report’s transaction was created, based on the transaction’s CreationDate.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime BeforeDate { get; set; }

        /// <summary>
        /// Filters for the report list.
        /// </summary>
        public ReportV2Filter Filters { get; set; }

        /// <summary>
        /// The data columns to be included in the report.
        /// </summary>
        public List<string> Columns { get; set; }
    }
}