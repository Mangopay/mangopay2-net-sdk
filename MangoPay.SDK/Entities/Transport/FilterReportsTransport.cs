using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Entities.Transport
{
	internal class FilterReportsTransport
	{
		/// <summary>Transaction status.</summary>
		public String[] Status;

		/// <summary>Transaction type.</summary>
		public String[] Type;

		/// <summary>Transaction nature.</summary>
		public String[] Nature;

		/// <summary>End date: return only transactions that have CreationDate BEFORE this date.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? BeforeDate;

		/// <summary>Start date: return only transactions that have CreationDate AFTER this date.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? AfterDate;

		public String[] ResultCode { get; set; }

		public Int32? MinDebitedFundsAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MinDebitedFundsCurrency { get; set; }

		public Int32? MaxDebitedFundsAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MaxDebitedFundsCurrency { get; set; }

		public FilterReports GetBusinessObject()
		{
			FilterReports result = new FilterReports
			{
				AfterDate = this.AfterDate,
				BeforeDate = this.BeforeDate,
				MaxDebitedFundsAmount = this.MaxDebitedFundsAmount,
				MaxDebitedFundsCurrency = this.MaxDebitedFundsCurrency,
				MinDebitedFundsAmount = this.MinDebitedFundsAmount,
				MinDebitedFundsCurrency = this.MinDebitedFundsCurrency,
				Nature = new List<TransactionNature>(),
				Status = new List<TransactionStatus>(),
				Type = new List<TransactionType>()
			};

			if (Nature != null)
				foreach (var n in Nature)
				{
					result.Nature.Add((TransactionNature)Enum.Parse(typeof(TransactionNature), n));
				}
			
			if (Status != null)
				foreach (var s in Status)
				{
					result.Status.Add((TransactionStatus)Enum.Parse(typeof(TransactionStatus), s));
				}

			if (Type != null)
				foreach (var t in Type)
				{
					result.Type.Add((TransactionType)Enum.Parse(typeof(TransactionType), t));
				}

			result.ResultCode = new List<ReportResultCode>();
			foreach (string rc in ResultCode)
			{
				int enumInt = Int32.Parse(rc);
				result.ResultCode.Add((ReportResultCode)enumInt);
			}

			return result;
		}

		public static FilterReportsTransport CreateFromBusinessObject(FilterReports filters)
		{
			FilterReportsTransport result = new FilterReportsTransport
			{
				AfterDate = filters.AfterDate,
				BeforeDate = filters.BeforeDate,
				MaxDebitedFundsAmount = filters.MaxDebitedFundsAmount,
				MaxDebitedFundsCurrency = filters.MaxDebitedFundsCurrency,
				MinDebitedFundsAmount = filters.MinDebitedFundsAmount,
				MinDebitedFundsCurrency = filters.MinDebitedFundsCurrency
			};

			if (filters.Nature != null)
			{
				result.Nature = new String[filters.Nature.Count];
				for (int i = 0; i < filters.Nature.Count; i++)
				{
					result.Nature[i] = filters.Nature[i].ToString();
				}
			}
			if (filters.Status != null)
			{
				result.Status = new String[filters.Status.Count];
				for (int i = 0; i < filters.Status.Count; i++)
				{
					result.Status[i] = filters.Status[i].ToString();
				}
			}
			if (filters.Type != null)
			{
				result.Type = new String[filters.Type.Count];
				for (int i = 0; i < filters.Type.Count; i++)
				{
					result.Type[i] = filters.Type[i].ToString();
				}
			}

			if (filters.ResultCode != null)
			{
				result.ResultCode = new String[filters.ResultCode.Count];

				for (int i = 0; i < filters.ResultCode.Count; i++)
				{
					result.ResultCode[i] = String.Format("{0:######}", (int)filters.ResultCode[i]);
				}
			}

			return result;
		}
	}
}
