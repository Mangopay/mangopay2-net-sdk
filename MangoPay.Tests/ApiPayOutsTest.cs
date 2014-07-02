using MangoPay.Core;
using MangoPay.Entities;
using MangoPay.Entities.Dependend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Tests
{
    [TestClass]
    public class ApiPayOutsTest : BaseTest
    {
        [TestMethod]
        public void Test_PayOuts_Create_BankWire()
        {
            try
            {
                PayIn payIn = this.GetJohnsPayInCardWeb();
                PayOut payOut = this.GetJohnsPayOutBankWire();

                Assert.IsTrue(payOut.Id.Length > 0);
                Assert.AreEqual(payOut.PaymentType, "BANK_WIRE");
                Assert.IsTrue(payOut.MeanOfPaymentDetails is PayOutPaymentDetailsBankWire);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
