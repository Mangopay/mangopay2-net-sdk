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
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
