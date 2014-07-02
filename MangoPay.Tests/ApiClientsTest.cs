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
    public class ApiClientsTest : BaseTest
    {
        [TestMethod]
        public void Test_ClientsCreateClient()
        {
            try
            {
                Random rand = new Random();
                String id = (rand.Next(1000000000) + 1).ToString();
                Client client = this.Api.Clients.Create(id, "test", "test@o2.pl");
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
            Client client = null;
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
    }
}
