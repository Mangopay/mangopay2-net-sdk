using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiCardRegistrationsTest : BaseTest
    {
        [Test]
        public async Task Test_CardRegistrations_Create()
        {
            try
            {
                var cardRegistrationVisa = await this.GetJohnsCardRegistration();
                var user = await this.GetJohn();

                Assert.IsNotNull(cardRegistrationVisa.Id);
                Assert.IsTrue(cardRegistrationVisa.Id.Length > 0);

                Assert.IsNotNull(cardRegistrationVisa.AccessKey);
                Assert.IsNotNull(cardRegistrationVisa.PreregistrationData);
                Assert.IsNotNull(cardRegistrationVisa.CardRegistrationURL);
                Assert.AreEqual(user.Id, cardRegistrationVisa.UserId);
                Assert.AreEqual(CurrencyIso.EUR, cardRegistrationVisa.Currency);
                Assert.AreEqual("CREATED", cardRegistrationVisa.Status);
				Assert.AreEqual(CardType.CB_VISA_MASTERCARD, cardRegistrationVisa.CardType);
                Assert.AreEqual("DefaultTag", cardRegistrationVisa.Tag);

                var cardRegistrationMaestro = await this.GetNewJohnsCardRegistration(CardType.MAESTRO);

				Assert.IsNotNull(cardRegistrationMaestro.Id);
				Assert.IsTrue(cardRegistrationMaestro.Id.Length > 0);

				Assert.IsNotNull(cardRegistrationMaestro.AccessKey);
				Assert.IsNotNull(cardRegistrationMaestro.PreregistrationData);
				Assert.IsNotNull(cardRegistrationMaestro.CardRegistrationURL);
				Assert.AreEqual(user.Id, cardRegistrationMaestro.UserId);
				Assert.AreEqual(CurrencyIso.EUR, cardRegistrationMaestro.Currency);
				Assert.AreEqual("CREATED", cardRegistrationMaestro.Status);
				Assert.AreEqual(CardType.MAESTRO, cardRegistrationMaestro.CardType);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardRegistrations_Get()
        {
            try
            {
                var cardRegistration = await this.GetJohnsCardRegistration();

                var getCardRegistration = await this.Api.CardRegistrations.GetAsync(cardRegistration.Id);

                Assert.IsTrue(getCardRegistration.Id.Length > 0);
                Assert.AreEqual(cardRegistration.Id, getCardRegistration.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardRegistrations_Update()
        {
            try
            {
                var cardRegistration = await this.GetJohnsCardRegistration();
                var cardRegistrationPut = new CardRegistrationPutDTO();
                var registrationData = await this.GetPaylineCorrectRegistartionData(cardRegistration);
                cardRegistrationPut.RegistrationData = registrationData;
                cardRegistrationPut.CardHolderName = "John Silver";

                var getCardRegistration = await this.Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);

                Assert.AreEqual(registrationData, getCardRegistration.RegistrationData);
                Assert.IsNotNull(getCardRegistration.CardId);
                Assert.AreEqual("VALIDATED", getCardRegistration.Status);
                Assert.AreEqual("000000", getCardRegistration.ResultCode);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
