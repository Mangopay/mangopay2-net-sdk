using MangoPay.Core;
using MangoPay.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Hook hook = this.GetJohnsHook();
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
                Hook hook = this.GetJohnsHook();
                Hook getHook = this.Api.Hooks.Get(hook.Id);

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
                Hook hook = this.GetJohnsHook();
                hook.Url = String.Format("http://test{0}.com", DateTime.Now.Ticks);

                Hook saveHook = this.Api.Hooks.Update(hook);

                Assert.AreEqual(saveHook.Id, hook.Id);
                Assert.AreEqual(saveHook.Url, hook.Url);
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
                Hook hook = this.GetJohnsHook();
                Pagination pagination = new Pagination(1, 1);

                List<Hook> list = this.Api.Hooks.GetAll(pagination);

                Assert.IsNotNull(list[0]);
                Assert.IsTrue(list[0] is Hook);
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
