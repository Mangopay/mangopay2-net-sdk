using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
	[Ignore("endpoints return 404")]
    public class ApiPermissionGroupsTests : BaseTest
    {
        [Test]
        public async Task Test_PermissionGroup_GetAdmin()
        {
            try
            {
				var permissionGroups = await Api.PermissionGroups.GetAsync("ADMIN");

                Assert.IsTrue(permissionGroups.Id.Length > 0);
                Assert.AreEqual("Admin", permissionGroups.Name);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_PermissionGroup_Create()
		{
			try
			{
                var group = new PermissionGroupPostDTO("Test name")
                {
                    Tag = "Test tag",
                    Scopes = new Scopes
                    {
                        BankAccounts = new Permissions(true, false, true),
                        Cards = new Permissions(false, true, false)
                    }
                };
                var permissionGroup = await Api.PermissionGroups.CreateAsync(group);

				Assert.IsTrue(permissionGroup.Id.Length > 0);
				Assert.AreEqual("Test name", permissionGroup.Name);
				Assert.AreEqual("Test tag", permissionGroup.Tag);
				Assert.IsTrue(permissionGroup.Scopes.BankAccounts.Read);
				Assert.IsFalse(permissionGroup.Scopes.BankAccounts.Edit);
				Assert.IsTrue(permissionGroup.Scopes.BankAccounts.Create);
				Assert.IsFalse(permissionGroup.Scopes.Cards.Read);
				Assert.IsTrue(permissionGroup.Scopes.Cards.Edit);
				Assert.IsFalse(permissionGroup.Scopes.Cards.Create);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_PermissionGroup_CreateIdempotencyKey()
		{
			try
			{
                var group = new PermissionGroupPostDTO("Test name")
                {
                    Tag = "Test tag",
                    Scopes = new Scopes
                    {
                        ClientDetails = new Permissions(true, false, true),
                        BankingAliases = new Permissions(false, true, false)
                    }
                };
                var idempotencyKey = "keypergroup" + DateTime.Now.Ticks.ToString();
				var permissionGroup = await Api.PermissionGroups.CreateAsync(group, idempotencyKey);

				Assert.IsTrue(permissionGroup.Id.Length > 0);
				Assert.AreEqual("Test name", permissionGroup.Name);
				Assert.AreEqual("Test tag", permissionGroup.Tag);
				Assert.IsTrue(permissionGroup.Scopes.ClientDetails.Read);
				Assert.IsFalse(permissionGroup.Scopes.ClientDetails.Edit);
				Assert.IsTrue(permissionGroup.Scopes.ClientDetails.Create);
				Assert.IsFalse(permissionGroup.Scopes.BankingAliases.Read);
				Assert.IsTrue(permissionGroup.Scopes.BankingAliases.Edit);
				Assert.IsFalse(permissionGroup.Scopes.BankingAliases.Create);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_PermissionGroups_GetAll()
		{
			try
			{
				var group = new PermissionGroupPostDTO("Test name");
			    await Api.PermissionGroups.CreateAsync(group);

				var permissionGroups = await Api.SingleSignOns.GetAllAsync();

				Assert.IsNotNull(permissionGroups);
				Assert.IsTrue(permissionGroups.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_PermissionGroups_GetAllWithPagination()
		{
			try
			{
				var group = new PermissionGroupPostDTO("Test name");
				await Api.PermissionGroups.CreateAsync(group);
				var pagination = new Pagination(1, 1);
				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);

				var permissionGroups = await Api.SingleSignOns.GetAllAsync(pagination, sort);

				Assert.IsNotNull(permissionGroups);
				Assert.AreEqual(1, permissionGroups.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_PermissionGroups_GetAllSSOs()
		{
			try
			{
				var group = new PermissionGroupPostDTO("Test name");
				var createdGroup = await Api.PermissionGroups.CreateAsync(group);
				var email = "email_" + DateTime.Now.Ticks + "@email.com";
				var singleSignOnPost = new SingleSignOnPostDTO("firstName", "lastName", email, createdGroup.Id);
				var singleSignOn = await this.Api.SingleSignOns.CreateAsync(singleSignOnPost);
				var pagination = new Pagination(1, 1);
				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);

				var singleSignOns = await Api.PermissionGroups.GetSingleSignOnsAsync(createdGroup.Id, pagination, sort);

				Assert.IsNotNull(singleSignOns);
				Assert.AreEqual(1, singleSignOns.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_PermissionGroup_Update()
		{
			try
			{
                var group = new PermissionGroupPostDTO("Test name")
                {
                    Tag = "Test tag",
                    Scopes = new Scopes
                    {
                        BankAccounts = new Permissions(true, false, true),
                        Cards = new Permissions(false, true, false)
                    }
                };
                var createdGroup = await Api.PermissionGroups.CreateAsync(group);

				var putGroup = new PermissionGroupPutDTO
				{
					Name = "New name test",
					Tag = "New name tag",
					Scopes = new Scopes
					{
						BankAccounts = new Permissions(false, false, true),
						Cards = new Permissions(false, false, true)
					}
				};

				var permissionGroup = await Api.PermissionGroups.UpdateAsync(putGroup, createdGroup.Id);
				
				Assert.IsTrue(permissionGroup.Id.Length > 0);
				Assert.AreEqual("New name test", permissionGroup.Name);
				Assert.AreEqual("New name tag", permissionGroup.Tag);
				Assert.IsFalse(permissionGroup.Scopes.BankAccounts.Read);
				Assert.IsFalse(permissionGroup.Scopes.BankAccounts.Edit);
				Assert.IsTrue(permissionGroup.Scopes.BankAccounts.Create);
				Assert.IsFalse(permissionGroup.Scopes.Cards.Read);
				Assert.IsFalse(permissionGroup.Scopes.Cards.Edit);
				Assert.IsTrue(permissionGroup.Scopes.Cards.Create);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
