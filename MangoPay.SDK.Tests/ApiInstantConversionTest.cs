using System.Collections.Generic;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiInstantConversionTest: BaseTest
    {
        [Test]
        public async Task Test_GetConversionRate()
        {
            var conversionRate = await Api.InstantConversion.GetConversionRate("EUR", "GBP");
            
            Assert.IsNotNull(conversionRate);
            Assert.IsNotNull(conversionRate.ClientRate);
            Assert.IsNotNull(conversionRate.MarketRate);
        }

        [Test]
        public async Task Test_CreateInstantConversion()
        {
            var createdInstantConversion = await CreateInstantConversion();
            
            Assert.IsNotNull(createdInstantConversion);
            Assert.IsNotNull(createdInstantConversion.CreditedFunds.Amount);
            Assert.IsNotNull(createdInstantConversion.DebitedFunds.Amount);
            Assert.AreEqual(createdInstantConversion.Status, TransactionStatus.SUCCEEDED);
            Assert.AreEqual(createdInstantConversion.Type, TransactionType.CONVERSION);
        }

        [Test]
        public async Task Test_GetInstantConversion()
        {
            var createdInstantConversion = await CreateInstantConversion();
            var returnedInstantConversion = await Api.InstantConversion.GetInstantConversion(createdInstantConversion.Id);
            
            Assert.IsNotNull(returnedInstantConversion);
            Assert.IsNotNull(returnedInstantConversion.CreditedFunds.Amount);
            Assert.IsNotNull(returnedInstantConversion.DebitedFunds.Amount);
            Assert.AreEqual(returnedInstantConversion.Status, TransactionStatus.SUCCEEDED);
            Assert.AreEqual(returnedInstantConversion.Type, TransactionType.CONVERSION);
        }

        private async Task<InstantConversionDTO> CreateInstantConversion() 
        {
            var john = await GetJohn();
            var wallet =
                new WalletPostDTO(new List<string> {john.Id}, "WALLET IN GBP WITH MONEY", CurrencyIso.GBP);
            var creditedWallet = await Api.Wallets.CreateAsync(wallet);
            
            var debitedWallet = await GetJohnsWalletWithMoney();

            var instantConversion = new InstantConversionPostDTO(
                john.Id,
                debitedWallet.Id,
                creditedWallet.Id,
                new Money { Amount = 79, Currency = CurrencyIso.EUR },
                new Money { Currency = CurrencyIso.GBP },
                "create instant conversion"
            );

            return await Api.InstantConversion.CreateInstantConversion(instantConversion);
        }
    }
}