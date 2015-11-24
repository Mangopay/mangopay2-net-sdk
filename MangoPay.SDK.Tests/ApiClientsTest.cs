using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
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
        public void Test_CardRegistrationData()
        {
            var userId = this.GetJohn().Id;
            var cardRegistrationPost = new CardRegistrationPostDTO(userId,
                CurrencyIso.EUR,
               CardType.CB_VISA_MASTERCARD);
            var cardRegistrationGet = this.Api.CardRegistrations.Create(cardRegistrationPost);

            var cardRegistrationDataPost = new CardRegistrationDataPostDTO(cardRegistrationGet.PreregistrationData,
                cardRegistrationGet.AccessKey, "4970100000000154", "1218", "123", cardRegistrationGet.CardRegistrationURL);
            var cardRegistrationDataGet = this.Api.CardRegistrations.RegisterCardData(cardRegistrationDataPost);

            var cardRegistrationPut = new CardRegistrationPutDTO();
            cardRegistrationPut.RegistrationData = cardRegistrationDataGet.RegistrationData;
            var cardRegistrationPutGet = this.Api.CardRegistrations.Update(cardRegistrationPut, cardRegistrationGet.Id);

        }
    }
}
