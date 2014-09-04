using MangoPay.Core;
using MangoPay.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MangoPay.Tests
{
    [TestClass]
    public class ApiHooksTest : BaseTest
    {
        [TestMethod]
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

        [TestMethod]
        public void Test_Hooks_Get()
        {
            try
            {
                HookDTO hook = this.GetJohnsHook();
                HookDTO getHook = this.Api.Hooks.Get(hook.Id);

                Assert.AreEqual(getHook.Id, hook.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Hooks_Update()
        {
            try
            {
                HookDTO hook = this.GetJohnsHook();
                HookPutDTO hookPut = new HookPutDTO();
                hookPut.Status = hook.Status;
                hookPut.Url = String.Format("http://test{0}.com", DateTime.Now.Ticks);

                HookDTO saveHook = this.Api.Hooks.Update(hookPut, hook.Id);

                Assert.AreEqual(saveHook.Id, hook.Id);
                Assert.AreEqual(hookPut.Url, saveHook.Url);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Hooks_All()
        {
            try
            {
                HookDTO hook = this.GetJohnsHook();
                Pagination pagination = new Pagination(1, 1);

                List<HookDTO> list = this.Api.Hooks.GetAll(pagination);

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
    }
}
