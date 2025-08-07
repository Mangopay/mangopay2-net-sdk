using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.POST;
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

        [Test]
        public async Task Test_Create_Intent_Report()
        {
            var reportPost = new ReportPostDTO
            {
                ReportType = "ECHO_INTENT",
                AfterDate = DateTimeOffset.FromUnixTimeSeconds(1740787200).DateTime,
                BeforeDate = DateTimeOffset.FromUnixTimeSeconds(1743544740).DateTime,
                DownloadFormat = "CSV",
                Filters = new ReportV2Filter
                {
                    Status = "CAPTURED",
                    PaymentMethod = "PAYPAL",
                    Type = "PAYIN"
                }
            };

            var report = await this.Api.ReportsV2.CreateAsync(reportPost);
            Assert.IsNotNull(report);
            Assert.AreEqual("ECHO_INTENT", report.ReportType);
            Assert.AreEqual("PENDING", report.Status);
            Assert.AreEqual("CAPTURED", report.Filters.Status);
        }
        
        [Test]
        public async Task Test_Create_Intent_Action_Report()
        {
            var reportPost = new ReportPostDTO
            {
                ReportType = "ECHO_INTENT_ACTION",
                AfterDate = DateTimeOffset.FromUnixTimeSeconds(1740787200).DateTime,
                BeforeDate = DateTimeOffset.FromUnixTimeSeconds(1743544740).DateTime,
                DownloadFormat = "CSV",
                Filters = new ReportV2Filter
                {
                    Status = "CAPTURED",
                    PaymentMethod = "PAYPAL",
                    Type = "PAYIN"
                }
            };

            var report = await this.Api.ReportsV2.CreateAsync(reportPost);
            Assert.IsNotNull(report);
            Assert.AreEqual("ECHO_INTENT_ACTION", report.ReportType);
            Assert.AreEqual("PENDING", report.Status);
            Assert.AreEqual("CAPTURED", report.Filters.Status);
        }
        
        [Test]
        public async Task Test_Create_Settlement_Report()
        {
            var reportPost = new ReportPostDTO
            {
                ReportType = "ECHO_SETTLEMENT",
                AfterDate = DateTimeOffset.FromUnixTimeSeconds(1740787200).DateTime,
                BeforeDate = DateTimeOffset.FromUnixTimeSeconds(1743544740).DateTime,
                DownloadFormat = "CSV",
                Filters = new ReportV2Filter
                {
                    Status = "RECONCILED",
                    ExternalProviderName = "PAYPAL"
                }
            };

            var report = await this.Api.ReportsV2.CreateAsync(reportPost);
            Assert.IsNotNull(report);
            Assert.AreEqual("ECHO_SETTLEMENT", report.ReportType);
            Assert.AreEqual("PENDING", report.Status);
            Assert.AreEqual("RECONCILED", report.Filters.Status);
        }
        
        [Test]
        public async Task Test_Create_Split_Report()
        {
            var reportPost = new ReportPostDTO
            {
                ReportType = "ECHO_SPLIT",
                AfterDate = DateTimeOffset.FromUnixTimeSeconds(1740787200).DateTime,
                BeforeDate = DateTimeOffset.FromUnixTimeSeconds(1743544740).DateTime,
                DownloadFormat = "CSV",
                Filters = new ReportV2Filter
                {
                    Status = "COMPLETED",
                    IntentId = "int_0197f975-63f6-714e-8fc6-4451e128170f",
                    Scheduled = false
                }
            };

            var report = await this.Api.ReportsV2.CreateAsync(reportPost);
            Assert.IsNotNull(report);
            Assert.AreEqual("ECHO_SPLIT", report.ReportType);
            Assert.AreEqual("PENDING", report.Status);
            Assert.AreEqual("COMPLETED", report.Filters.Status);
            Assert.AreEqual("int_0197f975-63f6-714e-8fc6-4451e128170f", report.Filters.IntentId);
        }
    }
}