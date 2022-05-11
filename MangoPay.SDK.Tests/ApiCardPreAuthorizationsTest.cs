using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiCardPreAuthorizationsTest : BaseTest
    {
        [Test]
        public async Task Test_CardPreAuthorization_Create()
        {
            try
            {
                var cardPreAuthorization = await this.GetJohnsCardPreAuthorization();

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
        public async Task Test_CardPreAuthorization_Create_WithBilling()
        {
            try
            {
                var john = await GetJohn();
                var cardPreAuthorization = await GetPreAuthorization(john.Id);
                var billing = new Billing();
                var address = new Address
                {
                    City = "Test city",
                    AddressLine1 = "Test address line 1",
                    AddressLine2 = "Test address line 2",
                    Country = CountryIso.RO,
                    PostalCode = "65400"
                };
                billing.Address = address;
                billing.FirstName = "Joe";
                billing.LastName = "Doe";
                cardPreAuthorization.Billing = billing;

                var cardPreAuthorizationWithBilling = await this.Api.CardPreAuthorizations.CreateAsync(cardPreAuthorization);

                Assert.IsNotNull(cardPreAuthorizationWithBilling);
                Assert.IsNotNull(cardPreAuthorizationWithBilling.Billing);
                Assert.IsNotNull(cardPreAuthorizationWithBilling.SecurityInfo);
                Assert.IsNotNull(cardPreAuthorizationWithBilling.SecurityInfo.AVSResult);
                Assert.AreEqual(cardPreAuthorizationWithBilling.SecurityInfo.AVSResult, AVSResult.NO_CHECK);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardPreAuthorization_Create_WithRequested3DS()
        {
            try
            {
                var john = await GetJohn();
                var cardPreAuthorization = await GetPreAuthorization(john.Id);
                var billing = new Billing();
                var address = new Address
                {
                    City = "Test city",
                    AddressLine1 = "Test address line 1",
                    AddressLine2 = "Test address line 2",
                    Country = CountryIso.RO,
                    PostalCode = "65400"
                };
                billing.Address = address;
                billing.FirstName = "Joe";
                billing.LastName = "Doe";
                cardPreAuthorization.Billing = billing;
                cardPreAuthorization.Requested3DSVersion = "V1";

                var cardPreAuthorizationPost = await this.Api.CardPreAuthorizations.CreateAsync(cardPreAuthorization);

                Assert.IsNotNull(cardPreAuthorizationPost);
                Assert.IsNotNull(cardPreAuthorizationPost.Billing);
                Assert.IsNotNull(cardPreAuthorizationPost.SecurityInfo);
                Assert.IsNotNull(cardPreAuthorizationPost.SecurityInfo.AVSResult);
                Assert.AreEqual(cardPreAuthorizationPost.SecurityInfo.AVSResult, AVSResult.NO_CHECK);
                Assert.IsNotNull(cardPreAuthorizationPost.Requested3DSVersion);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardPreAuthorization_Get()
        {
            try
            {
                var cardPreAuthorization = await this.GetJohnsCardPreAuthorization();

                var getCardPreAuthorization = await this.Api.CardPreAuthorizations.GetAsync(cardPreAuthorization.Id);

                Assert.AreEqual(cardPreAuthorization.Id, getCardPreAuthorization.Id);
                Assert.AreEqual(getCardPreAuthorization.ResultCode, "000000");
                Assert.IsNotNull(getCardPreAuthorization.MultiCapture);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardPreAuthorizationTransactions_Get()
        {
            try
            {
                var cardPreAuthorization = await this.GetJohnsCardPreAuthorization();
                var wallet = await this.GetJohnsWalletWithMoney();
                var user = await this.GetJohn();
                var payIn = new PayInPreauthorizedDirectPostDTO(user.Id,
                    new Money {Amount = 100, Currency = CurrencyIso.EUR},
                    new Money {Amount = 0, Currency = CurrencyIso.EUR}, wallet.Id, cardPreAuthorization.Id)
                {
                    SecureModeReturnURL = "http://test.com"
                };

                await Api.PayIns.CreatePreauthorizedDirectAsync(payIn);

                var preAuthTransactions = await this.Api.CardPreAuthorizations.GetTransactionsAsync(cardPreAuthorization.Id, new Pagination(1, 10));

                Assert.NotNull(preAuthTransactions);
                Assert.NotNull(preAuthTransactions.ElementAt(0));
                Assert.AreEqual(preAuthTransactions.ElementAt(0).Status, TransactionStatus.SUCCEEDED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardPreAuthorization_Update()
        {
            try
            {
                var cardPreAuthorization = await this.GetJohnsCardPreAuthorization();
                var cardPreAuthorizationPut = new CardPreAuthorizationPutDTO
                {
                    Tag = cardPreAuthorization.Tag,
                    PaymentStatus = PaymentStatus.CANCELED
                };

                var resultCardPreAuthorization = await this.Api.CardPreAuthorizations.UpdateAsync(cardPreAuthorizationPut, cardPreAuthorization.Id);

                Assert.AreEqual(resultCardPreAuthorization.Status, PreAuthorizationStatus.SUCCEEDED);
                Assert.AreEqual(resultCardPreAuthorization.PaymentStatus, PaymentStatus.CANCELED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardPreAuthorizations_GetPreAuthorizationsForUser()
        {
            try
            {
                var cardPreAuthorization = await GetJohnsCardPreAuthorization();

                var pagination = new Pagination(1, 1);

                var filter = new FilterPreAuthorizations
                {
                    ResultCode = cardPreAuthorization.ResultCode,
                    PaymentStatus = cardPreAuthorization.PaymentStatus,
                    Status = cardPreAuthorization.Status
                };

                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);

                var preAuthorizations = await Api.CardPreAuthorizations.GetPreAuthorizationsForUserAsync(cardPreAuthorization.AuthorId, pagination, filter, sort);

                Assert.IsTrue(preAuthorizations.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_CardPreAuthorizations_GetPreAuthorizationsForCard()
        {
            try
            {
                var cardPreAuthorization = await GetJohnsCardPreAuthorization();

                var pagination = new Pagination(1, 1);

                var filter = new FilterPreAuthorizations
                {
                    ResultCode = cardPreAuthorization.ResultCode,
                    PaymentStatus = cardPreAuthorization.PaymentStatus,
                    Status = cardPreAuthorization.Status
                };

                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);

                var preAuthorizations = await Api.CardPreAuthorizations.GetPreAuthorizationsForCardAsync(cardPreAuthorization.CardId, pagination, filter, sort);

                Assert.IsTrue(preAuthorizations.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
