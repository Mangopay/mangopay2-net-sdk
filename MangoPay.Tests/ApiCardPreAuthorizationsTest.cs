using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MangoPay.Entities;

namespace MangoPay.Tests
{
    [TestClass]
    public class ApiCardPreAuthorizationsTest : BaseTest
    {
        [TestMethod]
        public void Test_CardPreAuthorization_Create()
        {
            try
            {
                CardPreAuthorization cardPreAuthorization = this.GetJohnsCardPreAuthorization();

                Assert.IsTrue(cardPreAuthorization.Id != "");
                Assert.AreEqual(cardPreAuthorization.Status, "SUCCEEDED");
                Assert.AreEqual(cardPreAuthorization.PaymentStatus, "WAITING");
                Assert.AreEqual(cardPreAuthorization.ExecutionType, "DIRECT");
                Assert.IsNull(cardPreAuthorization.PayInId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_CardPreAuthorization_Get()
        {
            try
            {
                CardPreAuthorization cardPreAuthorization = this.GetJohnsCardPreAuthorization();

                CardPreAuthorization getCardPreAuthorization = this.Api.CardPreAuthorizations.Get(cardPreAuthorization.Id);

                Assert.AreEqual(cardPreAuthorization.Id, getCardPreAuthorization.Id);
                Assert.AreEqual(getCardPreAuthorization.ResultCode, "000000");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_CardPreAuthorization_Update()
        {
            try
            {
                CardPreAuthorization cardPreAuthorization = this.GetJohnsCardPreAuthorization();
                cardPreAuthorization.PaymentStatus = "CANCELED ";

                CardPreAuthorization resultCardPreAuthorization = this.Api.CardPreAuthorizations.Update(cardPreAuthorization);

                Assert.AreEqual(resultCardPreAuthorization.Status, "SUCCEEDED");
                Assert.AreEqual(resultCardPreAuthorization.PaymentStatus, "CANCELED");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
