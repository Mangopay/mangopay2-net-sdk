using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.GET
{
	/// <summary>Report request entity.</summary>
	public class ReportRequestDTO : EntityBase
	{
		/// <summary>Date of when the report was requested.</summary>
		[JsonConverter(typeof(Core.UnixDateTimeConverter))]
		public DateTime? ReportDate { get; set; }

		/// <summary>Status of the report.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public ReportStatus Status { get; set; }

		/// <summary>Download file format.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DownloadReportFormat DownloadFormat { get; set; }

		/// <summary>Download URL.</summary>
		public string DownloadURL { get; set; }

		/// <summary>Callback URL.</summary>
		public string CallbackURL { get; set; }

		/// <summary>Type of the report.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public ReportType ReportType { get; set; }

		/// <summary>Sorting.</summary>
		public string Sort { get; set; }

		/// <summary>If true, the report will be limited to the first 10 lines.</summary>
		public bool Preview { get; set; }

		/// <summary>Filters for the report list.</summary>
		public FilterReports Filters { get; set; }

		/// <summary>Allowed values: "Alias", "BankAccountId", "BankWireRef", "CardId", "CardType", "Country", "Culture", "Currency", "DeclaredDebitedFundsAmount", "DeclaredDebitedFundsCurrency", "DeclaredFeesAmount", "DeclaredFeesCurrency", "ExecutionType", "ExpirationDate", "PaymentType", "PreauthorizationId", "WireReference".</summary>
		public List<string> Columns { get; set; }

		/// <summary>Result code.</summary>
		public string ResultCode { get; set; }

		/// <summary>Result message.</summary>
		public string ResultMessage { get; set; }
	}
}
