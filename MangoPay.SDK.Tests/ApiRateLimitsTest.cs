using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiRateLimitsTest : BaseTest
    {
        [Test]
        public async Task Test_RateLimits_Retreive()
        {
            Assert.IsNull(Api.LastRequestInfo);
            
            try
            {
                await this.GetJohn(true);
                Assert.IsNotNull(Api.LastRequestInfo);
                Assert.IsNotNull(Api.LastRequestInfo.RateLimitingCallsRemaining);
                Assert.IsNotNull(Api.LastRequestInfo.RateLimitingTimeTillReset);
                Assert.IsNotNull(Api.LastRequestInfo.RateLimitingCallsMade);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
