using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiEventsTest : BaseTest
    {
        [Test]
        public void Test_Events_Get()
        {
            try
            {
                FilterEvents eventsFilter = new FilterEvents();
                eventsFilter.Type = EventType.PAYIN_NORMAL_CREATED;

                ListPaginated<EventDTO> getEvents = this.Api.Events.GetAll(null, eventsFilter);

                eventsFilter.Type = EventType.All;
                ListPaginated<EventDTO> getAllEvents = this.Api.Events.GetAll(null, eventsFilter);

                Assert.IsNotNull(getEvents);
                Assert.IsNotNull(getAllEvents);


                // test sorting
                ListPaginated<EventDTO> result = null;
                ListPaginated<EventDTO> result2 = null;

                Pagination pagination = new Pagination(1, 2);
                Sort sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = this.Api.Events.GetAll(pagination, eventsFilter, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = this.Api.Events.GetAll(pagination, eventsFilter, sort);
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
        public void Test_Events_GetAll_SortByCreationDate()
		{
			try
			{
				PayInCardWebDTO payIn1 = GetJohnsNewPayInCardWeb();
				PayInCardWebDTO payIn2 = GetJohnsNewPayInCardWeb();

				FilterEvents eventsFilter = new FilterEvents();
				eventsFilter.BeforeDate = payIn2.CreationDate;
				eventsFilter.AfterDate = payIn1.CreationDate;
				eventsFilter.Type = EventType.PAYIN_NORMAL_CREATED;

				Sort sort = new Sort();
				sort.AddField("Date", SortDirection.desc);

				Pagination pagination = new Pagination();

				ListPaginated<EventDTO> result = this.Api.Events.GetAll(pagination, eventsFilter, sort);

				Assert.IsNotNull(result);
				Assert.IsTrue(result.Count > 1);
				Assert.IsTrue(result[0].Date > result[1].Date);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
    }
}
