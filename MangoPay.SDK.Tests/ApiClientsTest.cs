using MangoPay.SDK.Core;
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

            try
            {
                result = this.Api.Clients.GetKycDocuments(null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
