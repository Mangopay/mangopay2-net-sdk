using MangoPay.SDK.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core
{
	/// <summary>Filter for report list.</summary>
	public class FilterReports
	{
		public FilterReports()
		{
			ResultCode = new List<ReportResultCode>();
			Nature = new List<TransactionNature>();
			Status = new List<TransactionStatus>();
			Type = new List<TransactionType>();
		}

		#region Common report filters

		/// <summary>End date: return only transactions that have CreationDate BEFORE this date.</summary>
		public DateTime? BeforeDate;

		/// <summary>Start date: return only transactions that have CreationDate AFTER this date.</summary>
		public DateTime? AfterDate;

		#endregion

		#region Transactions report filters

		/// <summary>The type of the transaction</summary>
		public List<TransactionType> Type;

		/// <summary>The status of the transaction</summary>
		public List<TransactionStatus> Status;

		/// <summary>The nature of the transaction</summary>
		public List<TransactionNature> Nature;

		/// <summary>The minimum amount of DebitedFunds</summary>
		public Int64? MinDebitedFundsAmount { get; set; }

		/// <summary>The currency for the minimum amount of DebitedFunds</summary>
		public CurrencyIso? MinDebitedFundsCurrency { get; set; }

		/// <summary>The maximum amount of DebitedFunds</summary>
		public Int64? MaxDebitedFundsAmount { get; set; }

		/// <summary>The currency for the maximum amount of DebitedFunds</summary>
		public CurrencyIso? MaxDebitedFundsCurrency { get; set; }

		/// <summary>The minimum amount of Fees</summary>
		public Int64? MinFeesAmount { get; set; }

		/// <summary>The currency for the minimum amount of Fees</summary>
		public CurrencyIso? MinFeesCurrency { get; set; }

		/// <summary>The maximum amount of Fees</summary>
		public Int64? MaxFeesAmount { get; set; }

		/// <summary>The currency for the maximum amount of Fees</summary>
		public CurrencyIso? MaxFeesCurrency { get; set; }

		/// <summary>A user's ID</summary>
		public String AuthorId { get; set; }

		/// <summary>The ID of a wallet</summary>
		public String WalletId { get; set; }

		/// <summary>Transaction result code</summary>
		public List<ReportResultCode> ResultCode { get; set; }

		#endregion

		#region Wallets report filters

		/// <summary></summary>
		public String OwnerId { get; set; }

		/// <summary></summary>
		public Int64? MinBalanceAmount { get; set; }

		/// <summary></summary>
		public CurrencyIso? MinBalanceCurrency { get; set; }

		/// <summary></summary>
		public Int64? MaxBalanceAmount { get; set; }

		/// <summary></summary>
		public CurrencyIso? MaxBalanceCurrency { get; set; }

		/// <summary></summary>
		public CurrencyIso? Currency { get; set; }

		#endregion
	}
}
