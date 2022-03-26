using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    public class ApiSingleSignOnsTest : BaseTest
    {
        [Test]
        public async Task Test_SingleSignOns_Create()
        {
            try
            {
				var email = "email_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName", "lastName", email, "READ");

				var singleSignOn = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);

                Assert.IsTrue(singleSignOn.Id.Length > 0);
                Assert.AreEqual("firstName", singleSignOn.FirstName);
                Assert.AreEqual("lastName", singleSignOn.LastName);
                Assert.AreEqual(email, singleSignOn.Email);
                Assert.AreEqual("READ", singleSignOn.PermissionGroupId);
                Assert.AreEqual(Api.Config.ClientId, singleSignOn.ClientId);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_SingleSignOns_CreateWithIdempotencyKey()
		{
			try
			{
				var email = "email_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName", "lastName", email, "READ");
				var idempotencyKey = "keysso" + DateTime.Now.Ticks.ToString();

				var singleSignOn = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost, idempotencyKey);

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
        public async Task Test_SingleSignOns_Get()
        {
            try
            {
				var email = "email-Get_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-Get", "lastName-Get", email, "READ");
				var singleSignOnCreated = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);

				var singleSignOn = await this.Api.SingleSignOns.GetAsync(singleSignOnCreated.Id);

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
        public async Task Test_SingleSignOns_GetAll()
        {
            try
            {
				var email = "email-GetAll_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-GetAll", "lastName-GetAll", email, "READ");
				var singleSignOnCreated = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);

				var singleSignOns = await this.Api.SingleSignOns.GetAllAsync();

                Assert.IsNotNull(singleSignOns);
                Assert.IsTrue(singleSignOns.Count > 0);				
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_SingleSignOns_GetAllWithPagination()
		{
			try
			{
				var email = "email-GetAll_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-GetAll", "lastName-GetAll", email, "READ");
				var singleSignOnCreated = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);
				var pagination = new Pagination(1, 1);
				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);
				
				var singleSignOns = await this.Api.SingleSignOns.GetAllAsync(pagination, sort);

				Assert.IsNotNull(singleSignOns);
				Assert.AreEqual(1, singleSignOns.Count);			
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
        public async Task Test_SingleSignOns_Save()
        {
            try
            {
				var email = "email-Save_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-Save", "lastName-Save", email, "READ");
				var singleSignOnCreated = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);
				var singleSignOnPut = new SingleSignOnPutDTO
				{
					FirstName = "firstName-Save-Updated",
					LastName = "lastName-Save-Updated",
					Active = false
				};

				var singleSignOnSaved = await this.Api.SingleSignOns.UpdateAsync(singleSignOnPut, singleSignOnCreated.Id);
                var singleSignOn = await this.Api.SingleSignOns.GetAsync(singleSignOnCreated.Id);

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
        public async Task Test_SingleSignOns_Save_NonASCII()
        {
            try
            {
               	var email = "email-Save_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-Save", "lastName-Save", email, "READ");
				var singleSignOnCreated = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);
				var singleSignOnPut = new SingleSignOnPutDTO
				{
					FirstName = "firstName-Save-Updated - CHANGED (éèęóąśłżźćń)",
					LastName = "lastName-Save-Updated - CHANGED(éèęóąśłżźćń)",
				};

				var singleSignOnSaved = await this.Api.SingleSignOns.UpdateAsync(singleSignOnPut, singleSignOnCreated.Id);
				var singleSignOn = await this.Api.SingleSignOns.GetAsync(singleSignOnCreated.Id);

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
		public async Task Test_SingleSignOns_ExtendInvitation()
		{
			try
			{
				var email = "email-ExtendInvitation_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName-ExtendInvitation", "lastName-ExtendInvitation", email, "READ");
				var singleSignOnCreated = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);

				var singleSignOn = await this.Api.SingleSignOns.ExtendInvitationAsync(singleSignOnCreated.Id);

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
