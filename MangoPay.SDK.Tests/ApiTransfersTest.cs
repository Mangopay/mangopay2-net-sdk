using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiTransfersTest : BaseTest
    {
        [Test]
        public async Task Test_Transfers_Create()
        {
            var john = await this.GetJohn();
            var wallet = await this.GetNewJohnsWalletWithMoney(100);

            var transfer = await this.GetNewTransfer(wallet);
            var creditedWallet = await this.Api.Wallets.GetAsync(transfer.CreditedWalletId);

            Assert.IsTrue(transfer.Id.Length > 0);
            Assert.AreEqual(transfer.AuthorId, john.Id);
            Assert.AreEqual(transfer.CreditedUserId, john.Id);
            Assert.AreEqual(100, creditedWallet.Balance.Amount);
        }

        [Test]
        public async Task Test_Transfers_Get()
        {
            var john = await this.GetJohn();
			var wallet = await this.GetNewJohnsWalletWithMoney(100);
            var transfer = await this.GetNewTransfer(wallet);

            var getTransfer = await this.Api.Transfers.GetAsync(transfer.Id);

            Assert.AreEqual(transfer.Id, getTransfer.Id);
            Assert.AreEqual(getTransfer.AuthorId, john.Id);
            Assert.AreEqual(getTransfer.CreditedUserId, john.Id);
            AssertEqualInputProps(transfer, getTransfer);
        }

        [Test]
        public async Task Test_Transfers_CreateRefund()
        {
            var wallet = await this.GetNewJohnsWalletWithMoney(100);
            var transfer = await this.GetNewTransfer(wallet);
            var walletBefore = await this.Api.Wallets.GetAsync(wallet.Id);

            var refund = await this.GetNewRefundForTransfer(transfer);
            var walletAfter = await this.Api.Wallets.GetAsync(wallet.Id);

            Assert.IsNotNull(walletBefore);
            Assert.IsTrue(refund.Id.Length > 0);
            Assert.IsTrue(refund.DebitedFunds.Amount == transfer.DebitedFunds.Amount);
            Assert.IsTrue(walletBefore.Balance.Amount == (walletAfter.Balance.Amount - transfer.DebitedFunds.Amount));
            Assert.AreEqual(TransactionType.TRANSFER, refund.Type);
            Assert.AreEqual(TransactionNature.REFUND, refund.Nature);
        }
    }
}
