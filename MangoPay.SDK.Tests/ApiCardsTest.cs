using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Core;
using System.Threading.Tasks;

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
        [Ignore("Ignored as it will deactivate the test card")]
        public async Task Test_Card_Validate()
        {
            var payIn = await GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            var card = await Api.Cards.GetAsync(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            var validated = await Api.Cards.ValidateAsync(card.Id);
            Assert.IsNotNull(validated);
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
