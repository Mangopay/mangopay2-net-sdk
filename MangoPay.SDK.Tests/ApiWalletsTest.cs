using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiWalletsTest : BaseTest
    {
        [Test]
        public void Test_Wallets_Create()
        {
            UserNaturalDTO john = this.GetJohn();
            WalletDTO wallet = this.GetJohnsWallet();

            Assert.IsTrue(wallet.Id.Length > 0);
            Assert.IsTrue(wallet.Owners.Contains(john.Id));
        }

        [Test]
        public void Test_Wallets_Get()
        {
            UserNaturalDTO john = this.GetJohn();
            WalletDTO wallet = this.GetJohnsWallet();

            WalletDTO getWallet = this.Api.Wallets.Get(wallet.Id);

            Assert.AreEqual(wallet.Id, getWallet.Id);
            Assert.IsTrue(wallet.Owners.Contains(john.Id));
        }

        [Test]
        public void Test_Wallets_Save()
        {
            WalletDTO wallet = this.GetJohnsWallet();
            WalletPutDTO walletPut = new WalletPutDTO();
            walletPut.Description = wallet.Description + " - changed";
            walletPut.Owners = wallet.Owners;
            walletPut.Tag = wallet.Tag;

            WalletDTO saveWallet = this.Api.Wallets.Update(walletPut, wallet.Id);

            Assert.AreEqual(wallet.Id, saveWallet.Id);
            Assert.AreEqual(wallet.Description + " - changed", saveWallet.Description);
        }

        [Test]
        public void Test_Wallets_Transactions()
        {
            UserNaturalDTO john = GetJohn();
            
            WalletDTO wallet = CreateJohnsWallet();
            PayInDTO payIn = CreateJohnsPayInCardWeb(wallet.Id);

            Pagination pagination = new Pagination(1, 1);
            FilterTransactions filter = new FilterTransactions();
            filter.Type = TransactionType.PAYIN;
            ListPaginated<TransactionDTO> transactions = Api.Wallets.GetTransactions(wallet.Id, pagination, filter, null);

            Assert.IsTrue(transactions.Count == 1);
            Assert.IsTrue(transactions[0] is TransactionDTO);
            Assert.AreEqual(transactions[0].AuthorId, john.Id);
            AssertEqualInputProps(transactions[0], payIn);
        }

        [Test]
        public void Test_Issue47()
        {
            var wallet = this.GetJohnsWallet();
            var mpSort = new Sort();
            mpSort.AddField("CreationDate", SortDirection.desc);

            var result = Api.Wallets.GetTransactions(wallet.Id, new Pagination(2, 4), new FilterTransactions(), mpSort);

            Assert.NotNull(result);
        }

        /** FIXME: backend error to fix
        [Test]
        public void Test_Wallets_Transactions_With_Sorting()
        {
            WalletDTO wallet = this.GetJohnsWallet();

            // create 2 payins
            this.GetJohnsPayInCardWeb();
            this.GetNewPayInCardWeb();
            Sort sort = new Sort();
            sort.AddField("CreationDate", SortDirection.desc);
            Pagination pagination = new Pagination(1, 20);
            FilterTransactions filter = new FilterTransactions();
            filter.Type = TransactionType.PAYIN;

            ListPaginated<TransactionDTO> transactions = this.Api.Wallets.GetTransactions(wallet.Id, pagination, filter, sort);

            Assert.IsTrue(transactions[0].CreationDate > transactions[1].CreationDate);
        }
        */
    }
}
