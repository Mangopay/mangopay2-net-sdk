using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MangoPay.SDK.Entities.Transport
{
	internal class ReportRequestTransportDTO : EntityBase
	{
		/// <summary>Date of when the report was requested.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? ReportDate { get; set; }

		/// <summary>Status of the report.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public ReportStatus Status { get; set; }

		/// <summary>Download file format.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public DownloadReportFormat DownloadFormat { get; set; }

		/// <summary>Download URL.</summary>
		public String DownloadURL { get; set; }

		/// <summary>Callback URL.</summary>
		public String CallbackURL { get; set; }

		/// <summary>Type of the report.</summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public ReportType ReportType { get; set; }

		/// <summary>Sorting.</summary>
		public String Sort { get; set; }

		/// <summary>If true, the report will be limited to the first 10 lines.</summary>
		public bool Preview { get; set; }

		/// <summary>Filters for the report list.</summary>
		public FilterReportsTransport Filters { get; set; }

		/// <summary>Allowed values: "Alias", "BankAccountId", "BankWireRef", "CardId", "CardType", "Country", "Culture", "Currency", "DeclaredDebitedFundsAmount", "DeclaredDebitedFundsCurrency", "DeclaredFeesAmount", "DeclaredFeesCurrency", "ExecutionType", "ExpirationDate", "PaymentType", "PreauthorizationId", "WireReference".</summary>
		public String[] Columns { get; set; }

		/// <summary>Result code.</summary>
		public String ResultCode { get; set; }

		/// <summary>Result message.</summary>
		public String ResultMessage { get; set; }

		public ReportRequestDTO GetBusinessObject()
		{
			ReportRequestDTO result = new ReportRequestDTO
			{
				Id = this.Id,
				CreationDate = this.CreationDate,
				Tag = this.Tag,
				ReportDate = this.ReportDate,
				Status = this.Status,
				DownloadFormat = this.DownloadFormat,
				DownloadURL = this.DownloadURL,
				CallbackURL = this.CallbackURL,
				ReportType = this.ReportType,
				Preview = this.Preview,
				ResultCode = this.ResultCode,
				ResultMessage = this.ResultMessage
			};

			if (Columns != null) result.Columns = this.Columns.ToList<string>();

			if (Filters != null) result.Filters = this.Filters != null ? this.Filters.GetBusinessObject() : null;

			return result;
		}
	}
}
