using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiWalletsTest : BaseTest
    {
        [Test]
        public async Task Test_Wallets_Create()
        {
            var john = await this.GetJohn();
            var wallet = await this.GetJohnsWallet();

            Assert.IsTrue(wallet.Id.Length > 0);
            Assert.IsTrue(wallet.Owners.Contains(john.Id));
        }

        [Test]
        public async Task Test_Wallets_Get()
        {
            var john = await this.GetJohn();
            var wallet = await this.GetJohnsWallet();

            var getWallet = await this.Api.Wallets.GetAsync(wallet.Id);

            Assert.AreEqual(wallet.Id, getWallet.Id);
            Assert.IsTrue(wallet.Owners.Contains(john.Id));
        }

        [Test]
        public async Task Test_Wallets_Save()
        {
            var wallet = await this.GetJohnsWallet();
            var walletPut = new WalletPutDTO
            {
                Description = wallet.Description + " - changed",
                Owners = wallet.Owners,
                Tag = wallet.Tag
            };

            var saveWallet = await this.Api.Wallets.UpdateAsync(walletPut, wallet.Id);

            Assert.AreEqual(wallet.Id, saveWallet.Id);
            Assert.AreEqual(wallet.Description + " - changed", saveWallet.Description);
        }

        [Test]
        public async Task Test_Wallets_Transactions()
        {
            var john = await GetJohn();

            var wallet = await CreateJohnsWallet();
            PayInDTO payIn = await CreateJohnsPayInCardWeb(wallet.Id);

            var pagination = new Pagination(1, 1);
            var filter = new FilterTransactions
            {
                Type = TransactionType.PAYIN
            };
            var transactions = await Api.Wallets.GetTransactionsAsync(wallet.Id, pagination, filter, null);

            Assert.IsTrue(transactions.Count == 1);
            Assert.IsTrue(transactions[0] is TransactionDTO);
            Assert.AreEqual(transactions[0].AuthorId, john.Id);
            AssertEqualInputProps(transactions[0], payIn);
        }
    }
}
