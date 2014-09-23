using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiTransfersTest : BaseTest
    {
        [TestMethod]
        public void Test_Transfers_Create()
        {
            UserNaturalDTO john = this.GetJohn();

            TransferDTO transfer = this.GetNewTransfer();
            WalletDTO creditedWallet = this.Api.Wallets.Get(transfer.CreditedWalletId);

            Assert.IsTrue(transfer.Id.Length > 0);
            Assert.AreEqual(transfer.AuthorId, john.Id);
            Assert.AreEqual(transfer.CreditedUserId, john.Id);
            Assert.IsTrue(creditedWallet.Balance.Amount == 100.0);
        }

        [TestMethod]
        public void Test_Transfers_Get()
        {
            UserNaturalDTO john = this.GetJohn();
            TransferDTO transfer = this.GetNewTransfer();

            TransferDTO getTransfer = this.Api.Transfers.Get(transfer.Id);

            Assert.AreEqual(transfer.Id, getTransfer.Id);
            Assert.AreEqual(getTransfer.AuthorId, john.Id);
            Assert.AreEqual(getTransfer.CreditedUserId, john.Id);
            AssertEqualInputProps(transfer, getTransfer);
        }

        [TestMethod]
        public void Test_Transfers_CreateRefund()
        {
            TransferDTO transfer = this.GetNewTransfer();
            WalletDTO wallet = this.GetJohnsWalletWithMoney();
            WalletDTO walletBefore = this.Api.Wallets.Get(wallet.Id);


            RefundDTO refund = this.GetNewRefundForTransfer(transfer);
            WalletDTO walletAfter = this.Api.Wallets.Get(wallet.Id);

            Assert.IsTrue(refund.Id.Length > 0);
            Assert.IsTrue(refund.DebitedFunds.Amount == transfer.DebitedFunds.Amount);
            Assert.IsTrue(walletBefore.Balance.Amount == (walletAfter.Balance.Amount - transfer.DebitedFunds.Amount));
            Assert.AreEqual(TransactionType.TRANSFER, refund.Type);
            Assert.AreEqual(TransactionNature.REFUND, refund.Nature);
        }
    }
}
