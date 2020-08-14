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
                PayInCardDirectDTO payIn = await GetNewPayInCardDirect();

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
            PayInCardDirectDTO payIn = await GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            CardDTO card = await Api.Cards.GetAsync(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            ListPaginated<CardDTO> cards = await Api.Cards.GetCardsByFingerprintAsync(card.Fingerprint);

            Assert.True(cards.Count > 0, "Card lsit is empty");

            foreach (CardDTO cardDTO in cards)
            {
                Assert.AreEqual(card.Fingerprint, cardDTO.Fingerprint);
            }
        }

        [Test]
        public async Task Test_Card_GetByFingerprint_Paginated()
        {
            PayInCardDirectDTO payIn = await GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            CardDTO card = await Api.Cards.GetAsync(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            Pagination pagination = new Pagination(1, 1);
            ListPaginated<CardDTO> cards = await Api.Cards.GetCardsByFingerprintAsync(card.Fingerprint, pagination, null);

            Assert.True(cards.Count == 1, String.Format("Requested 1 entity, got {0}", cards.Count));

            foreach (CardDTO cardDTO in cards)
            {
                Assert.AreEqual(card.Fingerprint, cardDTO.Fingerprint);
            }
        }
    }
}
