using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MangoPay.Tests
{
    [TestClass]
    public class MangoPayApiTest
    {
        [TestMethod]
        public void ApiAndUsersConstructionTest()
        {
            MangoPayApi api = new MangoPayApi();
            Assert.IsNotNull(api);
            Assert.IsNotNull(api.Users);
        }
    }
}
