using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    public class ApiSingleSignOnsTest : BaseTest
    {
        [Test]
        public void Test_SingleSignOns_Create()
        {
            try
            {
				var email = "email_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName", "lastName", email);

				var singleSignOn = this.Api.SingleSignOns.Create(singleSignOnPost);

                Assert.IsTrue(singleSignOn.Id.Length > 0);
                Assert.AreEqual("firstName", singleSignOn.FirstName);
                Assert.AreEqual("lastName", singleSignOn.LastName);
                Assert.AreEqual(email, singleSignOn.Email);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public void Test_SingleSignOns_CreateWithIdempotencyKey()
		{
			try
			{
				var email = "email_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName", "lastName", email);
				var idempotencyKey = "keysso" + DateTime.Now.Ticks.ToString();

				var singleSignOn = this.Api.SingleSignOns.Create(idempotencyKey, singleSignOnPost);

				Assert.IsTrue(singleSignOn.Id.Length > 0);
				Assert.AreEqual("firstName", singleSignOn.FirstName);
				Assert.AreEqual("lastName", singleSignOn.LastName);
				Assert.AreEqual(email, singleSignOn.Email);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
        public void Test_SingleSignOns_Get()
        {
            try
            {
				var email = "email-Get_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-Get", "lastName-Get", email);
				var singleSignOnCreated = this.Api.SingleSignOns.Create(singleSignOnPost);

				var singleSignOn = this.Api.SingleSignOns.Get(singleSignOnCreated.Id);

				Assert.IsTrue(singleSignOn.Id.Length > 0);
				Assert.AreEqual("firstName-Get", singleSignOn.FirstName);
				Assert.AreEqual("lastName-Get", singleSignOn.LastName);
				Assert.AreEqual(email, singleSignOn.Email);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
		       
        [Test]
        public void Test_SingleSignOns_GetAll()
        {
            try
            {
				var email = "email-GetAll_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-GetAll", "lastName-GetAll", email);
				var singleSignOnCreated = this.Api.SingleSignOns.Create(singleSignOnPost);

				var singleSignOns = this.Api.SingleSignOns.GetAll();

                Assert.IsNotNull(singleSignOns);
                Assert.IsTrue(singleSignOns.Count > 0);				
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public void Test_SingleSignOns_GetAllWithPagination()
		{
			try
			{
				var email = "email-GetAll_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-GetAll", "lastName-GetAll", email);
				var singleSignOnCreated = this.Api.SingleSignOns.Create(singleSignOnPost);
				var pagination = new Pagination(1, 1);
				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);
				
				var singleSignOns = this.Api.SingleSignOns.GetAll(pagination, sort);

				Assert.IsNotNull(singleSignOns);
				Assert.AreEqual(1, singleSignOns.Count);
				Assert.IsTrue(singleSignOns.TotalItems > 0);				
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
        public void Test_SingleSignOns_Save()
        {
            try
            {
				var email = "email-Save_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-Save", "lastName-Save", email);
				var singleSignOnCreated = this.Api.SingleSignOns.Create(singleSignOnPost);
				var singleSignOnPut = new SingleSignOnPutDTO
				{
					FirstName = "firstName-Save-Updated",
					LastName = "lastName-Save-Updated",
					Active = false
				};

				var singleSignOnSaved = this.Api.SingleSignOns.Update(singleSignOnPut, singleSignOnCreated.Id);
                var singleSignOn = this.Api.SingleSignOns.Get(singleSignOnCreated.Id);

				Assert.AreEqual(singleSignOnCreated.Id, singleSignOn.Id);
				Assert.AreEqual("firstName-Save-Updated", singleSignOn.FirstName);
				Assert.AreEqual("lastName-Save-Updated", singleSignOn.LastName);
				Assert.IsFalse(singleSignOn.Active);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_SingleSignOns_Save_NonASCII()
        {
            try
            {
               	var email = "email-Save_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-Save", "lastName-Save", email);
				var singleSignOnCreated = this.Api.SingleSignOns.Create(singleSignOnPost);
				var singleSignOnPut = new SingleSignOnPutDTO
				{
					FirstName = "firstName-Save-Updated - CHANGED (éèęóąśłżźćń)",
					LastName = "lastName-Save-Updated - CHANGED(éèęóąśłżźćń)",
				};

				var singleSignOnSaved = this.Api.SingleSignOns.Update(singleSignOnPut, singleSignOnCreated.Id);
				var singleSignOn = this.Api.SingleSignOns.Get(singleSignOnCreated.Id);

				Assert.AreEqual(singleSignOnCreated.Id, singleSignOn.Id);
				Assert.AreEqual("firstName-Save-Updated - CHANGED (éèęóąśłżźćń)", singleSignOn.FirstName);
				Assert.AreEqual("lastName-Save-Updated - CHANGED(éèęóąśłżźćń)", singleSignOn.LastName);
				Assert.IsTrue(singleSignOn.Active);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public void Test_SingleSignOns_ExtendInvitation()
		{
			try
			{
				var email = "email-ExtendInvitation_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-ExtendInvitation", "lastName-ExtendInvitation", email);
				var singleSignOnCreated = this.Api.SingleSignOns.Create(singleSignOnPost);

				var singleSignOn = this.Api.SingleSignOns.ExtendInvitation(singleSignOnCreated.Id);

				Assert.IsTrue(singleSignOn.Id.Length > 0);
				Assert.AreEqual("firstName-ExtendInvitation", singleSignOn.FirstName);
				Assert.AreEqual("lastName-ExtendInvitation", singleSignOn.LastName);
				Assert.AreEqual(email, singleSignOn.Email);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
