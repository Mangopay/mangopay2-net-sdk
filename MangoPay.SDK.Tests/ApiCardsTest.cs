using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Core;
using System.Threading.Tasks;
using MangoPay.SDK.Entities.POST;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiCardsTest : BaseTest
    {
        [Test]
        public async Task Test_Card_GetTransactionsForCard()
        {
            try
            {
                var payIn = await GetNewPayInCardDirect();

                var pagination = new Pagination(1, 1);
                var filter = new FilterTransactions();
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);

                var transactions = await Api.Cards.GetTransactionsForCardAsync(payIn.CardId, pagination, filter, sort);

                Assert.IsTrue(transactions.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Card_GetByFingerprint()
        {
            var payIn = await GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            var card = await Api.Cards.GetAsync(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            var cards = await Api.Cards.GetCardsByFingerprintAsync(card.Fingerprint);

            Assert.True(cards.Count > 0, "Card lsit is empty");

            foreach (CardDTO cardDTO in cards)
            {
                Assert.AreEqual(card.Fingerprint, cardDTO.Fingerprint);
            }
        }

        [Test]
        public async Task Test_Card_Validation()
        {
            var john = await GetJohn();
            var wallet =
                new WalletPostDTO(new List<string> {john.Id}, "WALLET IN EUR WITH MONEY", CurrencyIso.EUR);
            var johnsWallet = await Api.Wallets.CreateAsync(wallet);
            var cardRegistrationPost =
                new CardRegistrationPostDTO(johnsWallet.Owners[0], CurrencyIso.EUR);
            var cardRegistration = await Api.CardRegistrations.CreateAsync(cardRegistrationPost);
            var cardRegistrationPut = new CardRegistrationPutDTO();
            cardRegistrationPut.RegistrationData = await GetPaylineCorrectRegistartionData(cardRegistration);
            cardRegistration = await Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);
            
            var cardValidation = new CardValidationPostDTO(
                john.Id,
                "http://www.example.com/",
                "2001:0620:0000:0000:0211:24FF:FE80:C12C",
                getBrowserInfo(),
                "Test card validate"
            );

            Assert.IsNotNull(cardRegistration, "Card is null!");

            var validated = await Api.Cards.ValidateAsync(cardRegistration.CardId, cardValidation);
            Assert.IsNotNull(validated);
            Assert.IsNotNull(validated.Id);
        }
        
        [Test]
        public async Task Test_Get_Card_Validation()
        {
            var john = await GetJohn();
            var wallet =
                new WalletPostDTO(new List<string> {john.Id}, "WALLET IN EUR WITH MONEY", CurrencyIso.EUR);
            var johnsWallet = await Api.Wallets.CreateAsync(wallet);
            var cardRegistrationPost =
                new CardRegistrationPostDTO(johnsWallet.Owners[0], CurrencyIso.EUR);
            var cardRegistration = await Api.CardRegistrations.CreateAsync(cardRegistrationPost);
            var cardRegistrationPut = new CardRegistrationPutDTO();
            cardRegistrationPut.RegistrationData = await GetPaylineCorrectRegistartionData(cardRegistration);
            cardRegistration = await Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);
            
            var cardValidation = new CardValidationPostDTO(
                john.Id,
                "http://www.example.com/",
                "2001:0620:0000:0000:0211:24FF:FE80:C12C",
                getBrowserInfo(),
                "Test card validate"
            );

            Assert.IsNotNull(cardRegistration, "Card is null!");

            var validatedResponse = await Api.Cards.ValidateAsync(cardRegistration.CardId, cardValidation);
            Assert.IsNotNull(validatedResponse);
            Assert.IsNotNull(validatedResponse.Id);
            var getCardValidation =
                await Api.Cards.GetCardValidationAsync(cardRegistration.CardId, validatedResponse.Id);
            Assert.IsNotNull(getCardValidation);
            Assert.IsNotNull(getCardValidation.Id);
            Assert.Equals(getCardValidation.Id, validatedResponse.Id);
        }

        [Test]
        public async Task Test_Card_GetByFingerprint_Paginated()
        {
            var payIn = await GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            var card = await Api.Cards.GetAsync(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            var pagination = new Pagination(1, 1);
            var cards = await Api.Cards.GetCardsByFingerprintAsync(card.Fingerprint, pagination, null);

            Assert.True(cards.Count == 1, $"Requested 1 entity, got {cards.Count}");

            foreach (CardDTO cardDTO in cards)
            {
                Assert.AreEqual(card.Fingerprint, cardDTO.Fingerprint);
            }
        }
    }
}