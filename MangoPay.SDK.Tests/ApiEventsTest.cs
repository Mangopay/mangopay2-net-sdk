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
    public class ApiEventsTest : BaseTest
    {
        [Test]
        public async Task Test_Events_Get()
        {
            try
            {
                FilterEvents eventsFilter = new FilterEvents
                {
                    Type = EventType.PAYIN_NORMAL_CREATED
                };

                var getEvents = await this.Api.Events.GetAllAsync(null, eventsFilter);

                eventsFilter.Type = EventType.All;
                var getAllEvents = await this.Api.Events.GetAllAsync(null, eventsFilter);

                Assert.IsNotNull(getEvents);
                Assert.IsNotNull(getAllEvents);


                // test sorting
                ListPaginated<EventDTO> result = null;
                ListPaginated<EventDTO> result2 = null;

                var pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Events.GetAllAsync(pagination, eventsFilter, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Events.GetAllAsync(pagination, eventsFilter, sort);
                Assert.IsNotNull(result2);
                Assert.IsTrue(result2.Count > 0);

                Assert.IsTrue(result[0].ResourceId != result2[0].ResourceId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
        public async Task Test_Events_GetAll_SortByCreationDate()
		{
			try
			{
                var payIn1 = await GetJohnsNewPayInCardWeb();
                var payIn2 = await GetJohnsNewPayInCardWeb();

                var eventsFilter = new FilterEvents();
				eventsFilter.BeforeDate = payIn2.CreationDate.AddSeconds(1);
				eventsFilter.AfterDate = payIn1.CreationDate;
				eventsFilter.Type = EventType.PAYIN_NORMAL_CREATED;

                var sort = new Sort();
				sort.AddField("Date", SortDirection.desc);

                var pagination = new Pagination();

                var result = await this.Api.Events.GetAllAsync(pagination, eventsFilter, sort);

				Assert.IsNotNull(result);
				Assert.IsTrue(result.Count > 1);
				Assert.IsTrue(result[0].Date >= result[1].Date);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
    }
}
