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
    public class ApiReportsWalletsTest : BaseTest
    {
        [Test]
        public async Task Test_Report_Wallets_Create()
        {
            try
            {
                var reportPost = new ReportRequestPostDTO(ReportType.WALLETS);

                var report = await this.Api.Reports.CreateAsync(reportPost);
				Assert.IsNotNull(report);
				Assert.AreEqual(ReportType.WALLETS, report.ReportType);
				Assert.IsTrue(report.Id.Length > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_Report_Wallets_Filtered_Create()
		{
			try
			{
                var reportPost = new ReportRequestPostDTO(ReportType.WALLETS);
                var john = await this.GetJohn();
                var johnsId = john.Id;
				var minBalance = new Money() { Amount = 1, Currency = CurrencyIso.EUR };
				var maxBalance = new Money() { Amount = 1000, Currency = CurrencyIso.EUR };
				var currency = CurrencyIso.EUR;
				reportPost.Filters.OwnerId = johnsId;
				reportPost.Filters.MinBalanceAmount = minBalance.Amount;
				reportPost.Filters.MinBalanceCurrency = minBalance.Currency;
				reportPost.Filters.MaxBalanceAmount = maxBalance.Amount;
				reportPost.Filters.MaxBalanceCurrency = maxBalance.Currency;
				reportPost.Filters.Currency = currency;
                var report = await this.Api.Reports.CreateAsync(reportPost);
				Assert.IsNotNull(report);
				Assert.AreEqual(ReportType.WALLETS, report.ReportType);
				Assert.IsNotNull(report.Filters);
				Assert.IsNotNull(report.Filters.OwnerId);
				Assert.AreEqual(johnsId, report.Filters.OwnerId);
				Assert.AreEqual(minBalance.Amount, reportPost.Filters.MinBalanceAmount);
				Assert.AreEqual(minBalance.Currency, reportPost.Filters.MinBalanceCurrency);
				Assert.AreEqual(maxBalance.Amount, reportPost.Filters.MaxBalanceAmount);
				Assert.AreEqual(maxBalance.Currency, reportPost.Filters.MaxBalanceCurrency);
				Assert.AreEqual(currency, reportPost.Filters.Currency);
				Assert.IsTrue(report.Id.Length > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

        [Test]
        public async Task Test_Report_Wallets_Get()
        {
            try
            {
                var report = await this.GetJohnsReport(ReportType.WALLETS);
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
