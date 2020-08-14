using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    public class ApiReportsTest : BaseTest
    {
        [Test]
        public async Task Test_Reports_All()
        {
            try
            {
				ReportRequestDTO report = await this.GetJohnsReport(ReportType.TRANSACTIONS);
                Pagination pagination = new Pagination(1, 10);
				Sort sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				ListPaginated<ReportRequestDTO> list = await this.Api.Reports.GetAllAsync(pagination, null, sort);

				var exist = false;
				for (int i = 0; i < pagination.ItemsPerPage; i++)
				{
					if (report.Id == list[i].Id)
					{
						exist = true;
						break;
					}
				}

                Assert.IsNotNull(list[0]);
				Assert.IsTrue(exist);
                Assert.AreEqual(pagination.Page, 1);
				Assert.IsTrue(pagination.ItemsPerPage <= 10);

				FilterReportsList filters = new FilterReportsList();
				filters.AfterDate = list[0].CreationDate;
				filters.BeforeDate = DateTime.Today;

				list = await this.Api.Reports.GetAllAsync(pagination, filters, sort);

				Assert.IsNotNull(list);
				Assert.IsTrue(list.Count == 0);

				filters.BeforeDate = filters.AfterDate;
				filters.AfterDate = DateTime.Today.AddYears(-10);

				list = await this.Api.Reports.GetAllAsync(pagination, filters, sort);

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
