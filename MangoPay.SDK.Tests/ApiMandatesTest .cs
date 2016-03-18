using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiMandatesTest : BaseTest
    {
        [TestMethod]
        public void Test_Mandate_Create()
        {
            try
            {
				string bankAccountId = this.GetJohnsAccount().Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandate = this.Api.Mandates.Create(mandatePost);
				Assert.IsNotNull(mandate);
                Assert.IsFalse(String.IsNullOrEmpty(mandate.Id));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Mandate_Get()
        {
            try
            {
				string bankAccountId = this.GetJohnsAccount().Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandateCreated = this.Api.Mandates.Create(mandatePost);

				MandateDTO mandate = this.Api.Mandates.Get(mandateCreated.Id);

				Assert.IsNotNull(mandate);
				Assert.IsFalse(String.IsNullOrEmpty(mandate.Id));
                Assert.AreEqual(mandateCreated.Id, mandate.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[TestMethod]
		public void test_Mandate_Cancel()
		{
			string bankAccountId = this.GetJohnsAccount().Id;
			string returnUrl = "http://test.test";

			MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);
        
			MandateDTO mandate = this.Api.Mandates.Create(mandatePost);
        
			//	! IMPORTANT NOTE !
			//	
			//	In order to make this test pass, at this place you have to set a breakpoint,
			//	navigate to URL the mandate.RedirectURL property points to and click "CONFIRM" button.
        
			mandate = this.Api.Mandates.Get(mandate.Id);

			Assert.IsTrue(mandate.Status == MandateStatus.SUBMITTED, "In order to make this test pass, after creating mandate and before cancelling it you have to navigate to URL the mandate.RedirectURL property points to and click CONFIRM button.");
        
			mandate = this.Api.Mandates.Cancel(mandate.Id);
        
			Assert.IsNotNull(mandate);
			Assert.IsTrue(mandate.Status == MandateStatus.FAILED);
		}

        [TestMethod]
        public void Test_Mandates_GetAll()
        {
            try
            {
				ListPaginated<MandateDTO> mandates = this.Api.Mandates.GetAll();

				Assert.IsNotNull(mandates);
				Assert.IsTrue(mandates.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[TestMethod]
		public void Test_Mandate_GetForUser()
		{
			try
			{
				UserNaturalDTO user = this.GetJohn(true);
				string bankAccountId = this.GetJohnsAccount(true).Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandateCreated = this.Api.Mandates.Create(mandatePost);

				ListPaginated<MandateDTO> mandates = this.Api.Mandates.GetForUser(user.Id, new Pagination(1, 1), null);

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

		[TestMethod]
		public void Test_Mandate_GetForBankAccount()
		{
			try
			{
				UserNaturalDTO user = this.GetJohn(true);
				string bankAccountId = this.GetJohnsAccount(true).Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);

				MandateDTO mandateCreated = this.Api.Mandates.Create(mandatePost);

				ListPaginated<MandateDTO> mandates = this.Api.Mandates.GetForBankAccount(user.Id, bankAccountId, new Pagination(1, 1), null);

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
    }
}
