using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.POST
{
	public class ReportRequestPostDTO : EntityPostBase
	{
		public ReportRequestPostDTO(ReportType reportType, Sort sort = null)
		{
			DownloadFormat = DownloadReportFormat.CSV;

			Filters = new FilterReports();

			if (reportType == Core.Enumerations.ReportType.NotSpecified)
				reportType = Core.Enumerations.ReportType.TRANSACTIONS;

			ReportType = reportType;

			if (sort == null)
			{
				sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);
			}

			Sort = sort.GetFields();
		}

		/// <summary>Download file format.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DownloadReportFormat DownloadFormat { get; set; }

		/// <summary>Callback URL.</summary>
		public String CallbackURL { get; set; }

		/// <summary>Type of the report.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public ReportType? ReportType { get; set; }

		/// <summary>Sorting (defaults to: CreationDate, ascending).</summary>
		public String Sort { get; set; }

		/// <summary>If true, the report will be limited to the first 10 lines.</summary>
		public bool Preview { get; set; }

		/// <summary>Filters for the report list.</summary>
		public FilterReports Filters { get; set; }

		/// <summary>Allowed values: "Alias", "BankAccountId", "BankWireRef", "CardId", "CardType", "Country", "Culture", "Currency", "DeclaredDebitedFundsAmount", "DeclaredDebitedFundsCurrency", "DeclaredFeesAmount", "DeclaredFeesCurrency", "ExecutionType", "ExpirationDate", "PaymentType", "PreauthorizationId", "WireReference".</summary>
		public List<String> Columns { get; set; }
	}
}
