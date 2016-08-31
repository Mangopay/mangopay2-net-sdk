using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiReportsTest : BaseTest
    {
        [Test]
        public void Test_Report_Create()
        {
            try
            {
				ReportRequestPostDTO reportPost = new ReportRequestPostDTO(ReportType.TRANSACTIONS);

				ReportRequestDTO report = this.Api.Reports.Create(reportPost);
				Assert.IsNotNull(report);
				Assert.IsTrue(report.Id.Length > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_Report_Get()
        {
            try
            {
				ReportRequestDTO report = this.GetJohnsReport();
				ReportRequestDTO getReport = this.Api.Reports.Get(report.Id);

				Assert.AreEqual(getReport.Id, report.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_Reports_All()
        {
            try
            {
				ReportRequestDTO report = this.GetJohnsReport();
                Pagination pagination = new Pagination(1, 1);
				Sort sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				ListPaginated<ReportRequestDTO> list = this.Api.Reports.GetAll(pagination, null, sort);

                Assert.IsNotNull(list[0]);
				Assert.AreEqual(report.Id, list[0].Id);
                Assert.AreEqual(pagination.Page, 1);
                Assert.AreEqual(pagination.ItemsPerPage, 1);

				FilterReportsList filters = new FilterReportsList();
				filters.AfterDate = list[0].CreationDate;
				filters.BeforeDate = DateTime.Today;

				list = this.Api.Reports.GetAll(pagination, filters, sort);

				Assert.IsNotNull(list);
				Assert.IsTrue(list.Count == 0);

				filters.BeforeDate = filters.AfterDate;
				filters.AfterDate = DateTime.Today.AddYears(-10);

				list = this.Api.Reports.GetAll(pagination, filters, sort);

				Assert.IsNotNull(list);
				Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
