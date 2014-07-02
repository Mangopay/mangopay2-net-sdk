using MangoPay.Core;
using MangoPay.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                List<Event> getEvents = this.Api.Events.Get(eventsFilter, null);

                eventsFilter.Type = EventType.All;
                List<Event> getAllEvents = this.Api.Events.Get(eventsFilter, null);

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
