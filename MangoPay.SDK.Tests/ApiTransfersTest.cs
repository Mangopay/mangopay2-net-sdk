using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using NUnit.Framework;

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
        public async Task Test_Transfers_CreateSca()
        {
            string validUserNaturalScaId = "user_m_01JRFJJN9BR864A4KG7MH1WCZG";
            string validUserLegalScaId = "user_m_01JRG4ZWZ85RNZDKKTSFRMG6ZW";
            var debitedWallet = await GetNewJohnsWalletWithMoney(10000, validUserNaturalScaId);
            var transferUserPresent = await this.GetNewTransferSca(debitedWallet.Id, validUserNaturalScaId, validUserLegalScaId,
                3001, "USER_PRESENT");
            var transferUserPresentLowAmount = await this.GetNewTransferSca(debitedWallet.Id, validUserNaturalScaId, validUserLegalScaId,
                20, "USER_PRESENT");
            var transferUserNotPresent = await this.GetNewTransferSca(debitedWallet.Id, validUserNaturalScaId, validUserLegalScaId,
                3001, "USER_NOT_PRESENT");

            Assert.AreEqual(TransactionStatus.CREATED, transferUserPresent.Status);
            Assert.IsNotNull(transferUserPresent.PendingUserAction);
            
            Assert.AreEqual(TransactionStatus.SUCCEEDED, transferUserPresentLowAmount.Status);
            Assert.IsNull(transferUserPresentLowAmount.PendingUserAction);
            
            Assert.AreEqual(TransactionStatus.SUCCEEDED, transferUserNotPresent.Status);
            Assert.IsNull(transferUserNotPresent.PendingUserAction);
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
