using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MangoPay.SDK.Tests
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
