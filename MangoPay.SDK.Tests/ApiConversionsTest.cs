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
    public class ApiConversionsTest : BaseTest
    {
        [Test]
        public async Task Test_GetConversionRate()
        {
            var conversionRate = await Api.Conversions.GetConversionRate("EUR", "GBP");

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
            var returnedInstantConversion = await Api.Conversions.GetInstantConversion(createdInstantConversion.Id);

            Assert.IsNotNull(returnedInstantConversion);
            Assert.IsNotNull(returnedInstantConversion.CreditedFunds.Amount);
            Assert.IsNotNull(returnedInstantConversion.DebitedFunds.Amount);
            Assert.AreEqual(returnedInstantConversion.Status, TransactionStatus.SUCCEEDED);
            Assert.AreEqual(returnedInstantConversion.Type, TransactionType.CONVERSION);
        }

        [Test]
        public async Task Test_GetQuotedConversion()
        {
            var createdQuotedConversion = await CreateQuotedConversion();
            var returnedInstantConversion = await Api.Conversions.GetInstantConversion(createdQuotedConversion.Id);

            Assert.IsNotNull(returnedInstantConversion);
            Assert.IsNotNull(returnedInstantConversion.Id);
            Assert.IsNotNull(returnedInstantConversion.CreditedFunds.Amount);
            Assert.IsNotNull(returnedInstantConversion.DebitedFunds.Amount);
            Assert.AreEqual(returnedInstantConversion.Status, TransactionStatus.SUCCEEDED);
            Assert.AreEqual(returnedInstantConversion.Type, TransactionType.CONVERSION);
        }

        [Test]
        public async Task Test_CreateConversionQuote()
        {
            var createdConversionQuote = await CreateConversionQuote();

            Assert.IsNotNull(createdConversionQuote);
            Assert.IsNotNull(createdConversionQuote.CreditedFunds);
            Assert.IsNotNull(createdConversionQuote.DebitedFunds);
            Assert.IsNotNull(createdConversionQuote.ConversionRateResponse);
            Assert.AreEqual("ACTIVE", createdConversionQuote.Status);
        }

        [Test]
        public async Task Test_GetConversionQuote()
        {
            var createdConversionQuote = await CreateConversionQuote();
            var returnedConversionQuote = await Api.Conversions.GetConversionQuote(createdConversionQuote.Id);

            Assert.IsNotNull(returnedConversionQuote);
            Assert.IsNotNull(returnedConversionQuote.CreditedFunds);
            Assert.IsNotNull(returnedConversionQuote.DebitedFunds);
            Assert.IsNotNull(returnedConversionQuote.ConversionRateResponse);
            Assert.AreEqual("ACTIVE", returnedConversionQuote.Status);
        }

        [Test]
        public async Task Test_CreateQuotedConversion()
        {
            var john = await GetJohn();
            var wallet =
                new WalletPostDTO(new List<string> { john.Id }, "WALLET IN GBP WITH MONEY", CurrencyIso.GBP);
            var creditedWallet = await Api.Wallets.CreateAsync(wallet);

            var debitedWallet = await GetJohnsWalletWithMoney();

            var quote = await CreateConversionQuote();
            var quotedConversionPostDTO = new QuotedConversionPostDTO(
                quoteId: quote.Id,
                authorId: debitedWallet.Owners[0],
                debitedWalletId: debitedWallet.Id,
                creditedWalletId: creditedWallet.Id,
                tag: "Created using the Mangopay .NET SDK"
            );

            var quotedConversion = await this.Api.Conversions.CreateQuotedConversion(quotedConversionPostDTO);

            Assert.IsNotNull(quotedConversion);
            Assert.AreEqual(TransactionStatus.SUCCEEDED, quotedConversion.Status);
            Assert.AreEqual(TransactionNature.REGULAR, quotedConversion.Nature);
        }

        private async Task<ConversionDTO> CreateInstantConversion()
        {
            var john = await GetJohn();
            var wallet =
                new WalletPostDTO(new List<string> { john.Id }, "WALLET IN GBP WITH MONEY", CurrencyIso.GBP);
            var creditedWallet = await Api.Wallets.CreateAsync(wallet);

            var debitedWallet = await GetJohnsWalletWithMoney();

            var instantConversion = new InstantConversionPostDTO(
                john.Id,
                debitedWallet.Id,
                creditedWallet.Id,
                new Money { Amount = 20, Currency = CurrencyIso.EUR },
                new Money { Currency = CurrencyIso.GBP },
                new Money { Amount = 10, Currency = CurrencyIso.EUR },
                "create instant conversion"
            );

            return await Api.Conversions.CreateInstantConversion(instantConversion);
        }

        private async Task<ConversionDTO> CreateQuotedConversion()
        {
            var john = await GetJohn();
            var wallet =
                new WalletPostDTO(new List<string> { john.Id }, "WALLET IN GBP WITH MONEY", CurrencyIso.GBP);
            var creditedWallet = await Api.Wallets.CreateAsync(wallet);

            var debitedWallet = await GetJohnsWalletWithMoney();

            var quote = await CreateConversionQuote();
            var quotedConversionPostDTO = new QuotedConversionPostDTO(
                quoteId: quote.Id,
                authorId: debitedWallet.Owners[0],
                debitedWalletId: debitedWallet.Id,
                creditedWalletId: creditedWallet.Id,
                tag: "Created using the Mangopay .NET SDK"
            );

            return await this.Api.Conversions.CreateQuotedConversion(quotedConversionPostDTO);
        }

        private async Task<ConversionQuoteDTO> CreateConversionQuote()
        {
            var conversionQuote = new ConversionQuotePostDTO(
                new Money { Amount = 20, Currency = CurrencyIso.EUR },
                new Money { Currency = CurrencyIso.GBP },
                300,
                "Created using the Mangopay .NET SDK"
            );

            return await Api.Conversions.CreateConversionQuote(conversionQuote);
        }
    }
}