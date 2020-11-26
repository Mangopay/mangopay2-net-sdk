using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiHooksTest : BaseTest
    {
        /*
         * The Test_Hooks_Create() has been intentionally commented out.
         * This is because hooks are assigned to API client, which is
         * always the same. There is not possible to create a hook twice,
         * so the test will be failing all the time.
         
        [Test]
        public void Test_Hooks_Create()
        {
            try
            {
                HookPostDTO hookPost = new HookPostDTO("http://test.com", EventType.TRANSFER_REFUND_FAILED);

                HookDTO hook = this.Api.Hooks.Create(hookPost);
                Assert.IsTrue(hook.Id.Length > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
         
         */ 

        [Test]
        public async Task Test_Hooks_Get()
        {
            try
            {
                HookDTO hook = await this.GetJohnsHook();
                HookDTO getHook = await this.Api.Hooks.GetAsync(hook.Id);

                Assert.AreEqual(getHook.Id, hook.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Hooks_Update()
        {
            try
            {
                HookDTO hook = await this.GetJohnsHook();
                HookPutDTO hookPut = new HookPutDTO
                {
                    Status = hook.Status,
                    Url = String.Format("http://test{0}.com", DateTime.Now.Ticks)
                };

                HookDTO saveHook = await this.Api.Hooks.UpdateAsync(hookPut, hook.Id);

                Assert.AreEqual(saveHook.Id, hook.Id);
                Assert.AreEqual(hookPut.Url, saveHook.Url);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Hooks_All()
        {
            try
            {
                HookDTO hook = await this.GetJohnsHook();
                Pagination pagination = new Pagination(1, 1);

                ListPaginated<HookDTO> list = await this.Api.Hooks.GetAllAsync(pagination);

                Assert.IsNotNull(list[0]);
                Assert.IsTrue(list[0] is HookDTO);
                Assert.AreEqual(hook.Id, list[0].Id);
                Assert.AreEqual(pagination.Page, 1);
                Assert.AreEqual(pagination.ItemsPerPage, 1);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Ignore("no testable hooks")]
        [Test]
        public async Task Test_Hooks_GetByIdNewHooks()
        {
            try
            {
                var pagination = new Pagination(1, 100);
                var hooks = await this.Api.Hooks.GetAllAsync(pagination, null);
                var neededHooks = new List<HookDTO>();
                for (var i = 0; i < hooks.Count; i++)
                {
                    if (hooks[i].EventType == EventType.USER_INFLOWS_BLOCKED ||
                        hooks[i].EventType == EventType.USER_INFLOWS_UNBLOCKED ||
                        hooks[i].EventType == EventType.USER_OUTFLOWS_BLOCKED ||
                        hooks[i].EventType == EventType.USER_OUTFLOWS_UNBLOCKED)
                    {
                        neededHooks.Add(hooks[i]);
                    }
                }

                if (neededHooks.Count == 0)
                {
                    throw new Exception("no testable hooks");
                }

                Assert.NotNull(neededHooks);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                // hooks exampled in the API are not available
            }
        }
    }
}
