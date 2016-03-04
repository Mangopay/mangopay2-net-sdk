using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiCardRegistrationsTest : BaseTest
    {
        [TestMethod]
        public void Test_CardRegistrations_Create()
        {
            try
            {
                CardRegistrationDTO cardRegistration_visa = this.GetJohnsCardRegistration();
                UserNaturalDTO user = this.GetJohn();

                Assert.IsNotNull(cardRegistration_visa.Id);
                Assert.IsTrue(cardRegistration_visa.Id.Length > 0);

                Assert.IsNotNull(cardRegistration_visa.AccessKey);
                Assert.IsNotNull(cardRegistration_visa.PreregistrationData);
                Assert.IsNotNull(cardRegistration_visa.CardRegistrationURL);
                Assert.AreEqual(user.Id, cardRegistration_visa.UserId);
                Assert.AreEqual(CurrencyIso.EUR, cardRegistration_visa.Currency);
                Assert.AreEqual("CREATED", cardRegistration_visa.Status);
				Assert.AreEqual(CardType.CB_VISA_MASTERCARD, cardRegistration_visa.CardType);
                Assert.AreEqual("DefaultTag", cardRegistration_visa.Tag);

				CardRegistrationDTO cardRegistration_maestro = this.GetNewJohnsCardRegistration(CardType.MAESTRO);

				Assert.IsNotNull(cardRegistration_maestro.Id);
				Assert.IsTrue(cardRegistration_maestro.Id.Length > 0);

				Assert.IsNotNull(cardRegistration_maestro.AccessKey);
				Assert.IsNotNull(cardRegistration_maestro.PreregistrationData);
				Assert.IsNotNull(cardRegistration_maestro.CardRegistrationURL);
				Assert.AreEqual(user.Id, cardRegistration_maestro.UserId);
				Assert.AreEqual(CurrencyIso.EUR, cardRegistration_maestro.Currency);
				Assert.AreEqual("CREATED", cardRegistration_maestro.Status);
				Assert.AreEqual(CardType.MAESTRO, cardRegistration_maestro.CardType);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_CardRegistrations_Get()
        {
            try
            {
                CardRegistrationDTO cardRegistration = this.GetJohnsCardRegistration();

                CardRegistrationDTO getCardRegistration = this.Api.CardRegistrations.Get(cardRegistration.Id);

                Assert.IsTrue(getCardRegistration.Id.Length > 0);
                Assert.AreEqual(cardRegistration.Id, getCardRegistration.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_CardRegistrations_Update()
        {
            try
            {
                CardRegistrationDTO cardRegistration = this.GetJohnsCardRegistration();
                CardRegistrationPutDTO cardRegistrationPut = new CardRegistrationPutDTO();
                String registrationData = this.GetPaylineCorrectRegistartionData(cardRegistration);
                cardRegistrationPut.RegistrationData = registrationData;
                cardRegistrationPut.Tag = "DefaultTag - Updated";

                CardRegistrationDTO getCardRegistration = this.Api.CardRegistrations.Update(cardRegistrationPut, cardRegistration.Id);

                Assert.AreEqual(registrationData, getCardRegistration.RegistrationData);
                Assert.IsNotNull(getCardRegistration.CardId);
                Assert.AreEqual("VALIDATED", getCardRegistration.Status);
                Assert.AreEqual("000000", getCardRegistration.ResultCode);
                Assert.AreEqual(cardRegistrationPut.Tag, getCardRegistration.Tag);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
