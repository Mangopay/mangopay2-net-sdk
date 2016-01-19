using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiClientsTest : BaseTest
    {
        [TestMethod]
        public void Test_ClientsCreateClient()
        {
            try
            {
                Random rand = new Random();
                String id = (rand.Next(1000000000) + 1).ToString();
                ClientDTO client = this.Api.Clients.Create(id, "test", "test@o2.pl");
                Assert.IsTrue("test" == (client.Name));
                Assert.IsTrue(client.Passphrase.Length > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Clients_TryCreateInvalidClient()
        {
            ClientDTO client = null;
            try
            {
                // invalid id
                client = this.Api.Clients.Create("0", "test", "test@o2.pl");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ResponseException);
            }

            Assert.IsTrue(client == null);
        }

        [TestMethod]
        public void Test_Client_GetKycDocuments()
        {
            ListPaginated<KycDocumentDTO> result = null;
            ListPaginated<KycDocumentDTO> result2 = null;

            try
            {
                result = this.Api.Clients.GetKycDocuments(null, null);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                Pagination pagination = new Pagination(1, 2);
                Sort sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = this.Api.Clients.GetKycDocuments(pagination, null, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = this.Api.Clients.GetKycDocuments(pagination, null, sort);
                Assert.IsNotNull(result2);
                Assert.IsTrue(result2.Count > 0);

                Assert.IsTrue(result[0].Id != result2[0].Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[TestMethod]
		public void Test_Client_GetWallets()
		{
			ListPaginated<WalletDTO> feesWallets = null;
			ListPaginated<WalletDTO> creditWallets = null;
			try
			{
				feesWallets = this.Api.Clients.GetWallets(FundsType.FEES, new Pagination(1, 100));
				creditWallets = this.Api.Clients.GetWallets(FundsType.CREDIT, new Pagination(1, 100));
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
			Assert.IsNotNull(feesWallets);
			Assert.IsNotNull(creditWallets);
		}

		[TestMethod]
		public void Test_Client_GetTransactions()
		{
			ListPaginated<TransactionDTO> result = null;

			try
			{
				result = this.Api.Clients.GetTransactions(null, null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}
    }
}
