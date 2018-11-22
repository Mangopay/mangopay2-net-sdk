using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiCardPreAuthorizationsTest : BaseTest
    {
        [Test]
        public void Test_CardPreAuthorization_Create()
        {
            try
            {
                CardPreAuthorizationDTO cardPreAuthorization = this.GetJohnsCardPreAuthorization();

                Assert.IsTrue(cardPreAuthorization.Id.Length > 0);
                Assert.AreEqual(cardPreAuthorization.Status, PreAuthorizationStatus.SUCCEEDED);
                Assert.AreEqual(cardPreAuthorization.PaymentStatus, PaymentStatus.WAITING);
                Assert.AreEqual(cardPreAuthorization.ExecutionType, PreAuthorizationExecutionType.DIRECT);
                Assert.AreEqual(cardPreAuthorization.PaymentType, PreAuthorizationPaymentType.CARD);
                Assert.IsNull(cardPreAuthorization.PayInId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_CardPreAuthorization_Create_WithBilling()
        {
            try
            {
                CardPreAuthorizationPostDTO cardPreAuthorization = getPreAuthorization(GetJohn().Id);
                Billing billing = new Billing();
                Address address = new Address();
                address.City = "Test city";
                address.AddressLine1 = "Test address line 1";
                address.AddressLine2 = "Test address line 2";
                address.Country = CountryIso.RO;
                address.PostalCode = "65400";
                billing.Address = address;
                cardPreAuthorization.Billing = billing;

                CardPreAuthorizationDTO cardPreAuthorizationWithBilling = this.Api.CardPreAuthorizations.Create(cardPreAuthorization);

                Assert.IsNotNull(cardPreAuthorizationWithBilling);
                Assert.IsNotNull(cardPreAuthorizationWithBilling.Billing);
                Assert.IsNotNull(cardPreAuthorizationWithBilling.SecurityInfo);
                Assert.IsNotNull(cardPreAuthorizationWithBilling.SecurityInfo.AVSResult);
                Assert.AreEqual(cardPreAuthorizationWithBilling.SecurityInfo.AVSResult, AVSResult.ADDRESS_MATCH_ONLY);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
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

        [Test]
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

        [Test]
        public void Test_CardPreAuthorizations_GetPreAuthorizationsForUser()
        {
            try
            {
                var cardPreAuthorization = GetJohnsCardPreAuthorization();

                var pagination = new Pagination(1, 1);

                var filter = new FilterPreAuthorizations();
                filter.ResultCode = cardPreAuthorization.ResultCode;
                filter.PaymentStatus = cardPreAuthorization.PaymentStatus;
                filter.Status = cardPreAuthorization.Status;

                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);

                var preAuthorizations = Api.CardPreAuthorizations.GetPreAuthorizationsForUser(cardPreAuthorization.AuthorId, pagination, filter, sort);

                Assert.IsTrue(preAuthorizations.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_CardPreAuthorizations_GetPreAuthorizationsForCard()
        {
            try
            {
                var cardPreAuthorization = GetJohnsCardPreAuthorization();

                var pagination = new Pagination(1, 1);

                var filter = new FilterPreAuthorizations();
                filter.ResultCode = cardPreAuthorization.ResultCode;
                filter.PaymentStatus = cardPreAuthorization.PaymentStatus;
                filter.Status = cardPreAuthorization.Status;

                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);

                var preAuthorizations = Api.CardPreAuthorizations.GetPreAuthorizationsForCard(cardPreAuthorization.CardId, pagination, filter, sort);

                Assert.IsTrue(preAuthorizations.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
