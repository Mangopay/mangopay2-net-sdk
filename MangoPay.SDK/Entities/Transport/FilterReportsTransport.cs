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
		#region Common report filters

		/// <summary>End date: return only transactions that have CreationDate BEFORE this date.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? BeforeDate;

		/// <summary>Start date: return only transactions that have CreationDate AFTER this date.</summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? AfterDate;

		#endregion

		#region Transactions report filters

		/// <summary>Transaction type.</summary>
		public String[] Type;

		/// <summary>Transaction status.</summary>
		public String[] Status;

		/// <summary>Transaction nature.</summary>
		public String[] Nature;

		public Int64? MinDebitedFundsAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MinDebitedFundsCurrency { get; set; }

		public Int64? MaxDebitedFundsAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MaxDebitedFundsCurrency { get; set; }

		public Int64? MinFeesAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MinFeesCurrency { get; set; }

		public Int64? MaxFeesAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MaxFeesCurrency { get; set; }

		public String AuthorId { get; set; }

		public String WalletId { get; set; }

		public String[] ResultCode { get; set; }

		#endregion

		#region Wallets report filters

		public String OwnerId { get; set; }

		public Int64? MinBalanceAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MinBalanceCurrency { get; set; }

		public Int64? MaxBalanceAmount { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? MaxBalanceCurrency { get; set; }

		[JsonConverter(typeof(StringEnumConverter))]
		public CurrencyIso? Currency { get; set; }

		#endregion

		public FilterReports GetBusinessObject()
		{
			FilterReports result = new FilterReports();

			// Common report filters
			result.BeforeDate = BeforeDate;
			result.AfterDate = AfterDate;

			// Transactions report filters
			if (Type != null)
				foreach (var t in Type)
				{
					result.Type.Add((TransactionType)Enum.Parse(typeof(TransactionType), t));
				}

			if (Status != null)
				foreach (var s in Status)
				{
					result.Status.Add((TransactionStatus)Enum.Parse(typeof(TransactionStatus), s));
				}

			if (Nature != null)
				foreach (var n in Nature)
				{
					result.Nature.Add((TransactionNature)Enum.Parse(typeof(TransactionNature), n));
				}

			result.MinDebitedFundsAmount = MinDebitedFundsAmount;
			result.MinDebitedFundsCurrency = MinDebitedFundsCurrency;
			result.MaxDebitedFundsAmount = MaxDebitedFundsAmount;
			result.MaxDebitedFundsCurrency = MaxDebitedFundsCurrency;
			result.MinFeesAmount = MinFeesAmount;
			result.MinFeesCurrency = MinFeesCurrency;
			result.MaxFeesAmount = MaxFeesAmount;
			result.MaxFeesCurrency = MaxFeesCurrency;
			result.AuthorId = AuthorId;
			result.WalletId = WalletId;

			if (ResultCode != null)
				foreach (string rc in ResultCode)
				{
					if (String.IsNullOrEmpty(rc))
						continue;

					int enumInt = Int32.Parse(rc);
					result.ResultCode.Add((ReportResultCode)enumInt);
				}

			#region Wallets report filters

			result.OwnerId = OwnerId;
			result.MinBalanceAmount = MinBalanceAmount;
			result.MinBalanceCurrency = MinBalanceCurrency;
			result.MaxBalanceAmount = MaxBalanceAmount;
			result.MaxBalanceCurrency = MaxBalanceCurrency;
			result.Currency = Currency;

			#endregion

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
				MinDebitedFundsCurrency = filters.MinDebitedFundsCurrency,
				MinFeesAmount = filters.MinFeesAmount,
				MinFeesCurrency = filters.MinFeesCurrency,
				MaxFeesAmount = filters.MaxFeesAmount,
				MaxFeesCurrency = filters.MaxFeesCurrency,
				MinBalanceAmount = filters.MinBalanceAmount,
				MinBalanceCurrency = filters.MinBalanceCurrency,
				MaxBalanceAmount = filters.MaxBalanceAmount,
				MaxBalanceCurrency = filters.MaxBalanceCurrency,
				Currency = filters.Currency,
				OwnerId = filters.OwnerId,
				AuthorId = filters.AuthorId,
				WalletId = filters.WalletId
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
					result.ResultCode[i] = String.Format("{0:000000}", (int)filters.ResultCode[i]);
				}
			}

			return result;
		}
	}
}
