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
    public class ApiCardRegistrationsTest : BaseTest
    {
        [TestMethod]
        public void Test_CardRegistrations_Create()
        {
            try
            {
                CardRegistration cardRegistration = this.GetJohnsCardRegistration();
                UserNatural user = this.GetJohn();

                Assert.IsNotNull(cardRegistration.Id);
                Assert.IsTrue(cardRegistration.Id.Length > 0);

                Assert.IsNotNull(cardRegistration.AccessKey);
                Assert.IsNotNull(cardRegistration.PreregistrationData);
                Assert.IsNotNull(cardRegistration.CardRegistrationURL);
                Assert.AreEqual(user.Id, cardRegistration.UserId);
                Assert.AreEqual("EUR", cardRegistration.Currency);
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
                CardRegistration cardRegistration = this.GetJohnsCardRegistration();

                CardRegistration getCardRegistration = this.Api.CardRegistrations.Get(cardRegistration.Id);

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
                CardRegistration cardRegistration = this.GetJohnsCardRegistration();
                String registrationData = this.GetPaylineCorrectRegistartionData(cardRegistration);
                cardRegistration.RegistrationData = registrationData;

                CardRegistration getCardRegistration = this.Api.CardRegistrations.Update(cardRegistration);

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
