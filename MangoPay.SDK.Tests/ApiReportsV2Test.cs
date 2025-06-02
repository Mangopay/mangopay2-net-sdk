using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
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

                Assert.IsNotNull(list[0]);
				Assert.IsTrue(exist);
                Assert.AreEqual(pagination.Page, 1);
				Assert.IsTrue(pagination.ItemsPerPage <= 10);

                var filters = new FilterReportsListV2
                {
                    AfterDate = list[0].CreationDate,
                    BeforeDate = DateTime.Today
                };

                list = await this.Api.ReportsV2.GetAllAsync(pagination, filters);

				Assert.IsNotNull(list);

				filters.BeforeDate = filters.AfterDate;
				filters.AfterDate = DateTime.Today.AddYears(-10);

				list = await this.Api.ReportsV2.GetAllAsync(pagination, filters);

				Assert.IsNotNull(list);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
