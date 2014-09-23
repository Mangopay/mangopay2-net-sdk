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
                CardRegistrationDTO cardRegistration = this.GetJohnsCardRegistration();
                UserNaturalDTO user = this.GetJohn();

                Assert.IsNotNull(cardRegistration.Id);
                Assert.IsTrue(cardRegistration.Id.Length > 0);

                Assert.IsNotNull(cardRegistration.AccessKey);
                Assert.IsNotNull(cardRegistration.PreregistrationData);
                Assert.IsNotNull(cardRegistration.CardRegistrationURL);
                Assert.AreEqual(user.Id, cardRegistration.UserId);
                Assert.AreEqual(CurrencyIso.EUR, cardRegistration.Currency);
                Assert.AreEqual("CREATED", cardRegistration.Status);
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

                CardRegistrationDTO getCardRegistration = this.Api.CardRegistrations.Update(cardRegistrationPut, cardRegistration.Id);

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
