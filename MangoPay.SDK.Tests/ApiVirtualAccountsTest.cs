using System.Threading.Tasks;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiVirtualAccountsTest : BaseTest
    {
        [Test]
        public async Task Test_VirtualAccounts_Create()
        {
            var wallet = await GetJohnsWallet();
            var virtualAccount = await GetJohnsVirtualAccount();
            
            Assert.IsNotNull(virtualAccount);
            Assert.AreEqual(virtualAccount.WalletId, wallet.Id);
        }

        [Test]
        public async Task Test_VirtualAccounts_Get()
        {
            var virtualAccount = await GetJohnsVirtualAccount();
            var wallet = await GetJohnsWallet();

            var fetchedVirtualAccount = await Api.VirtualAccounts.GetAsync(wallet.Id, virtualAccount.Id);
            
            Assert.IsNotNull(fetchedVirtualAccount);
            Assert.AreEqual(fetchedVirtualAccount.Id, virtualAccount.Id);
        }

        [Test]
        public async Task Test_VirtualAccounts_GetAll()
        {
            var virtualAccount = await GetJohnsVirtualAccount();
            var wallet = await GetJohnsWallet();

            var virtualAccounts = await Api.VirtualAccounts.GetAllAsync(wallet.Id);
            
            Assert.IsNotNull(virtualAccounts);
            Assert.AreEqual(1, virtualAccounts.Count);
            Assert.AreEqual(virtualAccount.Id, virtualAccounts[0].Id);
        }

        
        [Test]
        [Ignore("API issue. To be re-enabled after fix.")]
        // TODO
        public async Task Test_VirtualAccounts_GetAvailabilities()
        {
            var availabilities = await Api.VirtualAccounts.GetAvailabilitiesAsync();
            
            Assert.IsNotNull(availabilities);
            Assert.IsTrue(availabilities.Collection.GetType().IsArray);
            Assert.IsTrue(availabilities.UserOwned.GetType().IsArray);
            Assert.IsNotEmpty(availabilities.Collection);
            Assert.IsNotEmpty(availabilities.UserOwned);
        }

        [Test]
        public async Task Test_VirtualAccounts_Deactivate()
        {
            var virtualAccount = await GetJohnsVirtualAccount();
            var wallet = await GetJohnsWallet();
            var deactivatedVirtualAccount = await Api.VirtualAccounts.DeactivateAsync(wallet.Id, virtualAccount.Id);
            
            Assert.AreEqual(virtualAccount.Id, deactivatedVirtualAccount.Id);
            Assert.IsFalse(deactivatedVirtualAccount.Active);
            Assert.AreEqual("CLOSED", deactivatedVirtualAccount.Status);
        }
    }
}