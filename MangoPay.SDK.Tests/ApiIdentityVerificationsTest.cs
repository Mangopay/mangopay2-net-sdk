using System.Threading.Tasks;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    [Explicit]
    public class ApiIdentityVerifications : BaseTest
    {
        private static IdentityVerificationDTO _identityVerification;

        [Test]
        public async Task Test_CreateIdentityVerification()
        {
            await GetNewIdentityVerification();

            Assert.IsNotNull(_identityVerification);
            Assert.IsNotNull(_identityVerification.ReturnUrl);
            Assert.IsNotNull(_identityVerification.HostedUrl);
            Assert.IsNotNull(_identityVerification.Status);
        }
        
        [Test]
        public async Task Test_GetIdentityVerification()
        {
            await GetNewIdentityVerification();
            IdentityVerificationDTO fetched = await Api.IdentityVerifications.GetAsync(_identityVerification.Id);

            Assert.IsNotNull(fetched);
            Assert.AreEqual(_identityVerification.HostedUrl, fetched.HostedUrl);
            Assert.AreEqual(_identityVerification.ReturnUrl, fetched.ReturnUrl);
            Assert.AreEqual(_identityVerification.Status, fetched.Status);
        }
        
        [Test]
        public async Task Test_GetIdentityVerificationChecks()
        {
            await GetNewIdentityVerification();
            IdentityVerificationCheckDTO check =
                await Api.IdentityVerifications.GetChecksAsync(_identityVerification.Id);

            Assert.IsNotNull(check);
            Assert.IsNotNull(check.SessionId);
            Assert.IsNotNull(check.Status);
            Assert.IsNotNull(check.LastUpdate);
            Assert.IsNotNull(check.CreationDate);
            Assert.IsNotNull(check.Checks);
        }

        private async Task GetNewIdentityVerification()
        {
            if (_identityVerification == null)
            {
                UserNaturalDTO john = await GetJohn();
                IdentityVerificationPostDto postDto = new IdentityVerificationPostDto();
                postDto.ReturnUrl = "https://example.com";
                postDto.Tag = "Created by the .NET SDK";

                _identityVerification = await Api.IdentityVerifications.CreateAsync(postDto, john.Id);
            }
        }
    }
}