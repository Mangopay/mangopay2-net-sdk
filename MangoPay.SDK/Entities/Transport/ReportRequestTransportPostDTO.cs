using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.POST;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MangoPay.SDK.Entities.Transport
{
	internal class ReportRequestTransportPostDTO : EntityPostBase
	{
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
		public FilterReportsTransport Filters { get; set; }

		/// <summary>Allowed values: "Alias", "BankAccountId", "BankWireRef", "CardId", "CardType", "Country", "Culture", "Currency", "DeclaredDebitedFundsAmount", "DeclaredDebitedFundsCurrency", "DeclaredFeesAmount", "DeclaredFeesCurrency", "ExecutionType", "ExpirationDate", "PaymentType", "PreauthorizationId", "WireReference".</summary>
		public String[] Columns { get; set; }


		public ReportRequestPostDTO GetBusinessObject()
		{
			ReportRequestPostDTO result = new ReportRequestPostDTO(this.ReportType ?? Core.Enumerations.ReportType.TRANSACTIONS);

			result.CallbackURL = this.CallbackURL;
			result.Columns = this.Columns != null ? this.Columns.ToList<string>() : null;
			result.DownloadFormat = this.DownloadFormat;
			result.Preview = this.Preview;
			result.ReportType = this.ReportType;
			result.Sort = this.Sort;
			result.Tag = this.Tag;

			if (this.Filters != null) result.Filters = this.Filters.GetBusinessObject();

			return result;
		}

		public static ReportRequestTransportPostDTO CreateFromBusinessObject(ReportRequestPostDTO reportRequest)
		{
			ReportRequestTransportPostDTO result = new ReportRequestTransportPostDTO();

			result.CallbackURL = reportRequest.CallbackURL;
			result.Columns = reportRequest.Columns != null ? reportRequest.Columns.ToArray<string>() : null;
			result.DownloadFormat = reportRequest.DownloadFormat;
			result.Preview = reportRequest.Preview;
			result.ReportType = reportRequest.ReportType;
			result.Tag = reportRequest.Tag;

			if (reportRequest.Filters != null) result.Filters = FilterReportsTransport.CreateFromBusinessObject(reportRequest.Filters);

			if (String.IsNullOrWhiteSpace(reportRequest.Sort)) reportRequest.Sort = "CreationDate:asc";

			return result;
		}
	}
}
