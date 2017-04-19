using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    public class ApiReportsWalletsTest : BaseTest
    {
        [Test]
        public void Test_Report_Wallets_Create()
        {
            try
            {
				ReportRequestPostDTO reportPost = new ReportRequestPostDTO(ReportType.WALLETS);

				ReportRequestDTO report = this.Api.Reports.Create(reportPost);
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
		public void Test_Report_Wallets_Filtered_Create()
		{
			try
			{
				ReportRequestPostDTO reportPost = new ReportRequestPostDTO(ReportType.WALLETS);
				string johnsId = this.GetJohn().Id;
				var minBalance = new Money() { Amount = 1, Currency = CurrencyIso.EUR };
				var maxBalance = new Money() { Amount = 1000, Currency = CurrencyIso.EUR };
				var currency = CurrencyIso.EUR;
				reportPost.Filters.OwnerId = johnsId;
				reportPost.Filters.MinBalanceAmount = minBalance.Amount;
				reportPost.Filters.MinBalanceCurrency = minBalance.Currency;
				reportPost.Filters.MaxBalanceAmount = maxBalance.Amount;
				reportPost.Filters.MaxBalanceCurrency = maxBalance.Currency;
				reportPost.Filters.Currency = currency;
				ReportRequestDTO report = this.Api.Reports.Create(reportPost);
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
        public void Test_Report_Wallets_Get()
        {
            try
            {
				ReportRequestDTO report = this.GetJohnsReport(ReportType.WALLETS);
				ReportRequestDTO getReport = this.Api.Reports.Get(report.Id);

				Assert.AreEqual(getReport.Id, report.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
