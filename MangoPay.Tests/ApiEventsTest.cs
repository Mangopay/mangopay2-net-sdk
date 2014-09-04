using MangoPay.Core;
using MangoPay.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MangoPay.Tests
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

                List<EventDTO> getEvents = this.Api.Events.GetAll(null, eventsFilter);

                eventsFilter.Type = EventType.All;
                List<EventDTO> getAllEvents = this.Api.Events.GetAll(null, eventsFilter);

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
