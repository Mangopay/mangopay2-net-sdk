using System;
using System.Threading.Tasks;
using MangoPay.SDK.Entities;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiReportsV2Test : BaseTest
    {
        [Test]
        public async Task Test_Report_Create()
        {
            try
            {
                var report = await this.GetReportV2();
                Assert.IsNotNull(report);
                Assert.AreEqual("COLLECTED_FEES", report.ReportType);
                Assert.AreEqual("PENDING", report.Status);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Report_Get()
        {
            try
            {
                var report = await this.GetReportV2();
                Assert.IsNotNull(report);

                var reportGet = await this.Api.ReportsV2.GetAsync(report.Id);
                Assert.IsNotNull(reportGet);
                Assert.AreEqual(report.Id, reportGet.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Reports_All()
        {
            try
            {
                var report = await this.GetReportV2();
                var pagination = new Pagination(1, 10);

                var list = await this.Api.ReportsV2.GetAllAsync(pagination, null, null);

                var exist = false;
                for (var i = 0; i < pagination.ItemsPerPage; i++)
                {
                    if (report.Id != list[i].Id) continue;

                    exist = true;
                    break;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}