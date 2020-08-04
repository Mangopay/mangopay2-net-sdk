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
            UserNaturalDTO john = await this.GetJohn();
            var wallet = await this.GetNewJohnsWalletWithMoney(10000);

			TransferDTO transfer = await this.GetNewTransfer(wallet);
            WalletDTO creditedWallet = await this.Api.Wallets.Get(transfer.CreditedWalletId);

            Assert.IsTrue(transfer.Id.Length > 0);
            Assert.AreEqual(transfer.AuthorId, john.Id);
            Assert.AreEqual(transfer.CreditedUserId, john.Id);
            Assert.AreEqual(100, creditedWallet.Balance.Amount);
        }

        [Test]
        public async Task Test_Transfers_Get()
        {
            UserNaturalDTO john = await this.GetJohn();
			var wallet = await this.GetNewJohnsWalletWithMoney(10000);
			TransferDTO transfer = await this.GetNewTransfer(wallet);

            TransferDTO getTransfer = await this.Api.Transfers.Get(transfer.Id);

            Assert.AreEqual(transfer.Id, getTransfer.Id);
            Assert.AreEqual(getTransfer.AuthorId, john.Id);
            Assert.AreEqual(getTransfer.CreditedUserId, john.Id);
            AssertEqualInputProps(transfer, getTransfer);
        }

        [Test]
        public async Task Test_Transfers_CreateRefund()
        {
			WalletDTO wallet = await this.GetNewJohnsWalletWithMoney(10000);
			TransferDTO transfer = await this.GetNewTransfer(wallet);
            WalletDTO walletBefore = await this.Api.Wallets.Get(wallet.Id);

			RefundDTO refund = await this.GetNewRefundForTransfer(transfer);
            WalletDTO walletAfter = await this.Api.Wallets.Get(wallet.Id);

            Assert.IsNotNull(walletBefore);
            Assert.IsTrue(refund.Id.Length > 0);
            Assert.IsTrue(refund.DebitedFunds.Amount == transfer.DebitedFunds.Amount);
            Assert.IsTrue(walletBefore.Balance.Amount == (walletAfter.Balance.Amount - transfer.DebitedFunds.Amount));
            Assert.AreEqual(TransactionType.TRANSFER, refund.Type);
            Assert.AreEqual(TransactionNature.REFUND, refund.Nature);
        }
    }
}
