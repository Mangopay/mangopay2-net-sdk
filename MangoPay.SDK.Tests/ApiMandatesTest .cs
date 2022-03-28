using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;
using System;
using System.Threading;
using MangoPay.SDK.Core;
using System.Linq;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiMandatesTest : BaseTest
    {
        [Test]
        public async Task Test_Mandate_Create()
        {
            try
            {
				var bankAccount = await this.GetJohnsAccount();
                var bankAccountId = bankAccount.Id;
                var returnUrl = "http://test.test";
                var mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

                var mandate = await this.Api.Mandates.CreateAsync(mandatePost);
				Assert.IsNotNull(mandate);
                Assert.IsFalse(string.IsNullOrEmpty(mandate.Id));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Mandate_Get()
        {
            try
            {
				var bankAccount = await this.GetJohnsAccount();
                var bankAccountId = bankAccount.Id;
                var returnUrl = "http://test.test";
                var mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

                var mandateCreated = await this.Api.Mandates.CreateAsync(mandatePost);

                var mandate = await this.Api.Mandates.GetAsync(mandateCreated.Id);

				Assert.IsNotNull(mandate);
				Assert.IsFalse(string.IsNullOrEmpty(mandate.Id));
                Assert.AreEqual(mandateCreated.Id, mandate.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


		/*
		 * Uncomment the attribute below to test mandate cancellation.
		 * This test needs your manual confirmation on the web page (see note in test's body)
		 */
		//[Test]
		public async Task Test_Mandate_Cancel()
		{
            var johnsAccount = await GetJohnsAccount();
            var bankAccountId = johnsAccount.Id;
            var returnUrl = "http://test.test";

            var mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

            var mandate = await this.Api.Mandates.CreateAsync(mandatePost);
        
			//	! IMPORTANT NOTE !
			//	
			//	In order to make this test pass, at this place you have to set a breakpoint,
			//	navigate to URL the mandate.RedirectURL property points to and click "CONFIRM" button.
        
			mandate = await this.Api.Mandates.GetAsync(mandate.Id);

			Assert.IsTrue(mandate.Status == MandateStatus.SUBMITTED, "In order to make this test pass, after creating mandate and before cancelling it you have to navigate to URL the mandate.RedirectURL property points to and click CONFIRM button.");
        
			mandate = await this.Api.Mandates.CancelAsync(mandate.Id);
        
			Assert.IsNotNull(mandate);
			Assert.IsTrue(mandate.Status == MandateStatus.FAILED);
		}

        [Test]
        public async Task Test_Mandates_GetAll()
        {
            try
            {
                var mandates = await this.Api.Mandates.GetAllAsync();

				Assert.IsNotNull(mandates);
				Assert.IsTrue(mandates.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_Mandate_GetForUser()
		{
			try
			{
                var user = await this.GetJohn(true);
                var johnsAccount = await GetJohnsAccount(true);
                var bankAccountId = johnsAccount.Id;
                var returnUrl = "http://test.test";
                var mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

                var mandateCreated = await this.Api.Mandates.CreateAsync(mandatePost);

                var mandates = await this.Api.Mandates.GetForUserAsync(user.Id, new Pagination(1, 1), null);

				Assert.IsNotNull(mandates);
				Assert.IsTrue(mandates.Count > 0);

				Assert.IsNotNull(mandates[0]);
				Assert.IsFalse(string.IsNullOrEmpty(mandates[0].Id));
				Assert.AreEqual(mandateCreated.Id, mandates[0].Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_Mandate_GetForBankAccount()
		{
			try
			{
                var user = await this.GetJohn(true);
                var johnsAccount = await GetJohnsAccount(true);
                var bankAccountId = johnsAccount.Id;
                var returnUrl = "http://test.test";
                var mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

                var mandateCreated = await this.Api.Mandates.CreateAsync(mandatePost);

                var mandates = await this.Api.Mandates.GetForBankAccountAsync(user.Id, bankAccountId, new Pagination(1, 1), null);

                Assert.IsNotNull(mandateCreated);
				Assert.IsNotNull(mandates);
				Assert.IsTrue(mandates.Count > 0);

				Assert.IsNotNull(mandates[0]);
				Assert.IsFalse(string.IsNullOrEmpty(mandates[0].Id));
				Assert.AreEqual(mandateCreated.Id, mandates[0].Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_Mandate_GetTransactionsForMandate()
		{
			try
			{
				var mandate = await GetNewMandate();

                var wallet = await GetJohnsWallet();
                var user = await GetJohn();
                var payIn = new PayInMandateDirectPostDTO(user.Id, new Money { Amount = 100, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "http://test.test", mandate.Id);
				await this.Api.PayIns.CreateMandateDirectDebitAsync(payIn);

				var pagination = new Pagination(1, 1);
				var filter = new FilterTransactions();
				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var transactions = await Api.Mandates.GetTransactionsForMandateAsync(mandate.Id, pagination, filter, sort);

				Assert.IsTrue(transactions.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
