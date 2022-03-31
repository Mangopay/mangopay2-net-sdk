using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.POST;

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
                await this.GetJohnsPayInCardWeb();
                var payOut = await this.GetJohnsPayOutBankWire();

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

        [Test]
        public async Task Test_PayOuts_Check_Eligibility()
        {
            try
            {
                var payIn = await this.GetJohnsPayInCardWeb();
                var payOut = await this.GetJohnsPayOutBankWire();

                Assert.IsTrue(payOut.Id.Length > 0);
                Assert.AreEqual(payOut.PaymentType, PayOutPaymentType.BANK_WIRE);

                var payOutEligibility = new PayOutEligibilityPostDTO
                {
                    AuthorId = payIn.AuthorId,
                    DebitedFunds = new Money
                    {
                        Amount = 10,
                        Currency = CurrencyIso.EUR
                    },
                    PayoutModeRequested = PayoutModeRequested.INSTANT_PAYMENT,
                    BankAccountId = payOut.BankAccountId,
                    DebitedWalletId = payOut.DebitedWalletId
                };

                var result = await this.Api.PayOuts.CheckInstantPayoutEligibility(payOutEligibility);

                Assert.NotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
