using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.POST;
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
                var user = new UserNaturalOwnerPostDTO
                {
                    Email = "john.doe@sample.org",
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = new DateTime(1975, 12, 21, 0, 0, 0),
                    Nationality = CountryIso.FR,
                    CountryOfResidence = CountryIso.FR,
                    Occupation = "programmer",
                    IncomeRange = 3,
                    Address = new Address { AddressLine1 = "Address line 1", AddressLine2 = "Address line 2", City = "City", Country = CountryIso.PL, PostalCode = "11222", Region = "Region" }
                };

                await this.Api.Users.CreateOwnerAsync(user);
                
                Assert.IsNotNull(Api.LastRequestInfo);
                Assert.IsNotNull(Api.LastRequestInfo.RateLimitingCallsRemaining);
                Assert.IsNotNull(Api.LastRequestInfo.RateLimitingTimeTillReset);
                Assert.IsNotNull(Api.LastRequestInfo.RateLimitingCallsMade);
                Assert.IsNotNull(Api.LastRequestInfo.RateLimits);
                Assert.True(Api.LastRequestInfo.RateLimits.Count == 6);
                
                Assert.AreEqual(1, Api.LastRequestInfo.RateLimits[0].IntervalMinutes);
                Assert.AreEqual(5, Api.LastRequestInfo.RateLimits[1].IntervalMinutes);
                Assert.AreEqual(15, Api.LastRequestInfo.RateLimits[2].IntervalMinutes);
                Assert.AreEqual(30, Api.LastRequestInfo.RateLimits[3].IntervalMinutes);
                Assert.AreEqual(60, Api.LastRequestInfo.RateLimits[4].IntervalMinutes);
                Assert.AreEqual(1440, Api.LastRequestInfo.RateLimits[5].IntervalMinutes);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
