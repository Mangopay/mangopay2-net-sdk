using MangoPay.Core;
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
    public class ApiWalletsTest : BaseTest
    {
        [TestMethod]
        public void Test_Wallets_Create()
        {
            UserNatural john = this.GetJohn();
            Wallet wallet = this.GetJohnsWallet();

            Assert.IsTrue(wallet.Id.Length > 0);
            Assert.IsTrue(wallet.Owners.Contains(john.Id));
        }

        [TestMethod]
        public void Test_Wallets_Get()
        {
            UserNatural john = this.GetJohn();
            Wallet wallet = this.GetJohnsWallet();

            Wallet getWallet = this.Api.Wallets.Get(wallet.Id);

            Assert.AreEqual(wallet.Id, getWallet.Id);
            Assert.IsTrue(wallet.Owners.Contains(john.Id));
        }

        [TestMethod]
        public void Test_Wallets_Save()
        {
            Wallet wallet = this.GetJohnsWallet();
            wallet.Description = "New description to test";

            Wallet saveWallet = this.Api.Wallets.Update(wallet);

            Assert.AreEqual(wallet.Id, saveWallet.Id);
            Assert.AreEqual("New description to test", saveWallet.Description);
        }

        [TestMethod]
        public void Test_Wallets_Transactions()
        {
            UserNatural john = this.GetJohn();
            Wallet wallet = this.GetJohnsWallet();
            PayIn payIn = this.GetJohnsPayInCardWeb();

            Pagination pagination = new Pagination(1, 1);
            FilterTransactions filter = new FilterTransactions();
            filter.Type = "PAYIN";
            List<Transaction> transactions = this.Api.Wallets.GetTransactions(wallet.Id, pagination, filter);

            Assert.IsTrue(transactions.Count == 1);
            Assert.IsTrue(transactions[0] is Transaction);
            Assert.AreEqual(transactions[0].AuthorId, john.Id);
            AssertEqualInputProps(transactions[0], payIn);
        }
    }
}
