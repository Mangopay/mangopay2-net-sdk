using MangoPay.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Tests
{
    [TestClass]
    public class ApiTransfersTest : BaseTest
    {
        [TestMethod]
        public void Test_Transfers_Create()
        {
            UserNatural john = this.GetJohn();

            Transfer transfer = this.GetNewTransfer();
            Wallet creditedWallet = this.Api.Wallets.Get(transfer.CreditedWalletId);

            Assert.IsTrue(transfer.Id.Length > 0);
            Assert.AreEqual(transfer.AuthorId, john.Id);
            Assert.AreEqual(transfer.CreditedUserId, john.Id);
            Assert.IsTrue(creditedWallet.Balance.Amount == 100.0);
        }

        [TestMethod]
        public void Test_Transfers_Get()
        {
            UserNatural john = this.GetJohn();
            Transfer transfer = this.GetNewTransfer();

            Transfer getTransfer = this.Api.Transfers.Get(transfer.Id);

            Assert.AreEqual(transfer.Id, getTransfer.Id);
            Assert.AreEqual(getTransfer.AuthorId, john.Id);
            Assert.AreEqual(getTransfer.CreditedUserId, john.Id);
            AssertEqualInputProps(transfer, getTransfer);
        }

        [TestMethod]
        public void Test_Transfers_CreateRefund()
        {
            Transfer transfer = this.GetNewTransfer();
            Wallet wallet = this.GetJohnsWalletWithMoney();
            Wallet walletBefore = this.Api.Wallets.Get(wallet.Id);


            Refund refund = this.GetNewRefundForTransfer(transfer);
            Wallet walletAfter = this.Api.Wallets.Get(wallet.Id);

            Assert.IsTrue(refund.Id.Length > 0);
            Assert.IsTrue(refund.DebitedFunds.Amount == transfer.DebitedFunds.Amount);
            Assert.IsTrue(walletBefore.Balance.Amount == (walletAfter.Balance.Amount - transfer.DebitedFunds.Amount));
            Assert.AreEqual("TRANSFER", refund.Type);
            Assert.AreEqual("REFUND", refund.Nature);
        }
    }
}
