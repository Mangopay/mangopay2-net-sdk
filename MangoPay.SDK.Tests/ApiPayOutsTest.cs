using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiPayOutsTest : BaseTest
    {
        [Test]
        public void Test_PayOuts_Create_BankWire()
        {
            try
            {
                PayInDTO payIn = this.GetJohnsPayInCardWeb();
                PayOutDTO payOut = this.GetJohnsPayOutBankWire();

                Assert.IsTrue(payOut.Id.Length > 0);
                Assert.AreEqual(payOut.PaymentType, PayOutPaymentType.BANK_WIRE);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
