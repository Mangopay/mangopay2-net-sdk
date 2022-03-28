using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    public class ApiReportsTransactionsTest : BaseTest
    {
        [Test]
        public async Task Test_Report_Transactions_Create()
        {
            try
            {
                var reportPost = new ReportRequestPostDTO(ReportType.TRANSACTIONS);

                var report = await this.Api.Reports.CreateAsync(reportPost);
				Assert.IsNotNull(report);
				Assert.AreEqual(ReportType.TRANSACTIONS, report.ReportType);
				Assert.IsTrue(report.Id.Length > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_Report_Transactions_Filtered_Create()
		{
			try
			{
                var reportPost = new ReportRequestPostDTO(ReportType.TRANSACTIONS);
                var john = await GetJohn();
                var wallet = await GetJohnsWallet();
                var johnsId = john.Id;
                var walletId = wallet.Id;
				var minDebitedFunds = new Money() { Amount = 111, Currency = CurrencyIso.EUR };
				var maxDebitedFunds = new Money() { Amount = 222, Currency = CurrencyIso.EUR };
				var minFees = new Money() { Amount = 3, Currency = CurrencyIso.JPY };
				var maxFees = new Money() { Amount = 4, Currency = CurrencyIso.JPY };
				reportPost.Filters.AuthorId = johnsId;
				reportPost.Filters.WalletId = walletId;
				reportPost.Filters.MinDebitedFundsAmount = minDebitedFunds.Amount;
				reportPost.Filters.MinDebitedFundsCurrency = minDebitedFunds.Currency;
				reportPost.Filters.MaxDebitedFundsAmount = maxDebitedFunds.Amount;
				reportPost.Filters.MaxDebitedFundsCurrency = maxDebitedFunds.Currency;
				reportPost.Filters.MinFeesAmount = minFees.Amount;
				reportPost.Filters.MinFeesCurrency = minFees.Currency;
				reportPost.Filters.MaxFeesAmount = maxFees.Amount;
				reportPost.Filters.MaxFeesCurrency = maxFees.Currency;

                var report = await this.Api.Reports.CreateAsync(reportPost);
				Assert.IsNotNull(report);
				Assert.AreEqual(ReportType.TRANSACTIONS, report.ReportType);
				Assert.IsNotNull(report.Filters);
				Assert.IsNotNull(report.Filters.AuthorId);
				Assert.AreEqual(johnsId, report.Filters.AuthorId);
				Assert.IsNotNull(report.Filters.WalletId);
				Assert.AreEqual(walletId, report.Filters.WalletId);
				Assert.AreEqual(minDebitedFunds.Amount, reportPost.Filters.MinDebitedFundsAmount);
				Assert.AreEqual(minDebitedFunds.Currency, reportPost.Filters.MinDebitedFundsCurrency);
				Assert.AreEqual(maxDebitedFunds.Amount, reportPost.Filters.MaxDebitedFundsAmount);
				Assert.AreEqual(maxDebitedFunds.Currency, reportPost.Filters.MaxDebitedFundsCurrency);
				Assert.AreEqual(minFees.Amount, reportPost.Filters.MinFeesAmount);
				Assert.AreEqual(minFees.Currency, reportPost.Filters.MinFeesCurrency);
				Assert.AreEqual(maxFees.Amount, reportPost.Filters.MaxFeesAmount);
				Assert.AreEqual(maxFees.Currency, reportPost.Filters.MaxFeesCurrency);
				Assert.IsTrue(report.Id.Length > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

        [Test]
        public async Task Test_Report_Transactions_Get()
        {
            try
            {
                var report = await this.GetJohnsReport(ReportType.TRANSACTIONS);
                var getReport = await this.Api.Reports.GetAsync(report.Id);

				Assert.AreEqual(getReport.Id, report.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
