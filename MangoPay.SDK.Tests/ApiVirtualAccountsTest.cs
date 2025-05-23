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
            Assert.AreEqual("Success", virtualAccount.ResultMessage);
            Assert.AreEqual("000000", virtualAccount.ResultCode);
            Assert.IsNotNull(virtualAccount.LocalAccountDetails.BankName);
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
        public async Task Test_VirtualAccounts_GetAvailabilities()
        {
            var availabilities = await Api.VirtualAccounts.GetAvailabilitiesAsync();
            
            Assert.IsNotNull(availabilities);
            Assert.IsTrue(availabilities.Collection.Count > 0);
            Assert.IsTrue(availabilities.UserOwned.Count > 0);
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