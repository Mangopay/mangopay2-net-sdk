﻿using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class MangoPayApiTest
    {
        [Test]
        public void ApiAndUsersConstructionTest()
        {
            var api = new MangoPayApi();
            Assert.IsNotNull(api);
            Assert.IsNotNull(api.Users);
        }
    }
}
