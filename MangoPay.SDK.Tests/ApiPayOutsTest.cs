using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiPayOutsTest : BaseTest
    {
        [Test]
        public async Task Test_PayOuts_Create_BankWire()
        {
            try
            {
                PayInDTO payIn = await this.GetJohnsPayInCardWeb();
                PayOutDTO payOut = await this.GetJohnsPayOutBankWire();

                Assert.IsTrue(payOut.Id.Length > 0);
                Assert.AreEqual(payOut.PaymentType, PayOutPaymentType.BANK_WIRE);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_PayOuts_Get_Bankwire()
        {
            var john = await this.GetJohnsPayOutBankWire();

            var getJohnBankwire = await Api.PayOuts.GetBankwirePayoutAsync(john.Id);

            Assert.NotNull(john);
            Assert.NotNull(getJohnBankwire);

            Assert.AreEqual(john.Id, getJohnBankwire.Id);
            Assert.IsTrue(getJohnBankwire.ModeRequested == "STANDARD");
            Assert.IsTrue(getJohnBankwire.ModeApplied.Length != 0);
        }
    }
}
