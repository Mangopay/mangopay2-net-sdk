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
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandate = await this.Api.Mandates.Create(mandatePost);
				Assert.IsNotNull(mandate);
                Assert.IsFalse(String.IsNullOrEmpty(mandate.Id));
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
                string bankAccountId = bankAccount.Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandateCreated = await this.Api.Mandates.Create(mandatePost);

				MandateDTO mandate = await this.Api.Mandates.Get(mandateCreated.Id);

				Assert.IsNotNull(mandate);
				Assert.IsFalse(String.IsNullOrEmpty(mandate.Id));
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
			string bankAccountId = johnsAccount.Id;
			string returnUrl = "http://test.test";

			MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);
        
			MandateDTO mandate = await this.Api.Mandates.Create(mandatePost);
        
			//	! IMPORTANT NOTE !
			//	
			//	In order to make this test pass, at this place you have to set a breakpoint,
			//	navigate to URL the mandate.RedirectURL property points to and click "CONFIRM" button.
        
			mandate = await this.Api.Mandates.Get(mandate.Id);

			Assert.IsTrue(mandate.Status == MandateStatus.SUBMITTED, "In order to make this test pass, after creating mandate and before cancelling it you have to navigate to URL the mandate.RedirectURL property points to and click CONFIRM button.");
        
			mandate = await this.Api.Mandates.Cancel(mandate.Id);
        
			Assert.IsNotNull(mandate);
			Assert.IsTrue(mandate.Status == MandateStatus.FAILED);
		}

        [Test]
        public async Task Test_Mandates_GetAll()
        {
            try
            {
				ListPaginated<MandateDTO> mandates = await this.Api.Mandates.GetAll();

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
				UserNaturalDTO user = await this.GetJohn(true);
                var johnsAccount = await GetJohnsAccount(true);
				string bankAccountId = johnsAccount.Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandateCreated = await this.Api.Mandates.Create(mandatePost);

				ListPaginated<MandateDTO> mandates = await this.Api.Mandates.GetForUser(user.Id, new Pagination(1, 1), null);

				Assert.IsNotNull(mandates);
				Assert.IsTrue(mandates.Count > 0);

				Assert.IsNotNull(mandates[0]);
				Assert.IsFalse(String.IsNullOrEmpty(mandates[0].Id));
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
				UserNaturalDTO user = await this.GetJohn(true);
                var johnsAccount = await GetJohnsAccount(true);
				string bankAccountId = johnsAccount.Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandateCreated = await this.Api.Mandates.Create(mandatePost);

				ListPaginated<MandateDTO> mandates = await this.Api.Mandates.GetForBankAccount(user.Id, bankAccountId, new Pagination(1, 1), null);

                Assert.IsNotNull(mandateCreated);
				Assert.IsNotNull(mandates);
				Assert.IsTrue(mandates.Count > 0);

				Assert.IsNotNull(mandates[0]);
				Assert.IsFalse(String.IsNullOrEmpty(mandates[0].Id));
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

				WalletDTO wallet = await GetJohnsWallet();
				UserNaturalDTO user = await GetJohn();
				PayInMandateDirectPostDTO payIn = new PayInMandateDirectPostDTO(user.Id, new Money { Amount = 10000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "http://test.test", mandate.Id);
				PayInDTO createPayIn = await this.Api.PayIns.CreateMandateDirectDebit(payIn);

				var pagination = new Pagination(1, 1);
				var filter = new FilterTransactions();
				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var transactions = await Api.Mandates.GetTransactionsForMandate(mandate.Id, pagination, filter, sort);

				Assert.IsTrue(transactions.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
