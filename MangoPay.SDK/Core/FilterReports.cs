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
		}

		/// <summary>Transaction status.</summary>
		public List<TransactionStatus> Status;

		/// <summary>Transaction type.</summary>
		public List<TransactionType> Type;

		/// <summary>Transaction nature.</summary>
		public List<TransactionNature> Nature;

		/// <summary>End date: return only transactions that have CreationDate BEFORE this date.</summary>
		public DateTime? BeforeDate;

		/// <summary>Start date: return only transactions that have CreationDate AFTER this date.</summary>
		public DateTime? AfterDate;

		public List<ReportResultCode> ResultCode { get; set; }

		public String AuthorId { get; set; }

		public String WalletId { get; set; }

		public Int32? MinDebitedFundsAmount { get; set; }

		public CurrencyIso? MinDebitedFundsCurrency { get; set; }

		public Int32? MaxDebitedFundsAmount { get; set; }

		public CurrencyIso? MaxDebitedFundsCurrency { get; set; }
	}
}
