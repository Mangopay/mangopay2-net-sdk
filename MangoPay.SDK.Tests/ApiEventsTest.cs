using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiEventsTest : BaseTest
    {
        [TestMethod]
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
    }
}
