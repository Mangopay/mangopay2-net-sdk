using MangoPay.Core;
using MangoPay.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
                CardPreAuthorizationDTO cardPreAuthorization = this.GetJohnsCardPreAuthorization();

                Assert.IsTrue(cardPreAuthorization.Id.Length > 0);
                Assert.AreEqual(cardPreAuthorization.Status, PreAuthorizationStatus.SUCCEEDED);
                Assert.AreEqual(cardPreAuthorization.PaymentStatus, PaymentStatus.WAITING);
                Assert.AreEqual(cardPreAuthorization.ExecutionType, PreAuthorizationExecutionType.DIRECT);
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
                CardPreAuthorizationDTO cardPreAuthorization = this.GetJohnsCardPreAuthorization();

                CardPreAuthorizationDTO getCardPreAuthorization = this.Api.CardPreAuthorizations.Get(cardPreAuthorization.Id);

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
                CardPreAuthorizationDTO cardPreAuthorization = this.GetJohnsCardPreAuthorization();
                CardPreAuthorizationPutDTO cardPreAuthorizationPut = new CardPreAuthorizationPutDTO();
                cardPreAuthorizationPut.Tag = cardPreAuthorization.Tag;
                cardPreAuthorizationPut.PaymentStatus = PaymentStatus.CANCELED;

                CardPreAuthorizationDTO resultCardPreAuthorization = this.Api.CardPreAuthorizations.Update(cardPreAuthorizationPut, cardPreAuthorization.Id);

                Assert.AreEqual(resultCardPreAuthorization.Status, PreAuthorizationStatus.SUCCEEDED);
                Assert.AreEqual(resultCardPreAuthorization.PaymentStatus, PaymentStatus.CANCELED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
