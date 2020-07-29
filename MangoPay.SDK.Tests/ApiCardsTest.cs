using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Core;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiCardsTest : BaseTest
    {
        [Test]
        public void Test_Card_GetTransactionsForCard()
        {
            try
            {
                PayInCardDirectDTO payIn = GetNewPayInCardDirect();

                var pagination = new Pagination(1, 1);
                var filter = new FilterTransactions();
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);

                var transactions = Api.Cards.GetTransactionsForCard(payIn.CardId, pagination, filter, sort);

                Assert.IsTrue(transactions.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_Card_GetByFingerprint()
        {
            PayInCardDirectDTO payIn = GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            CardDTO card = Api.Cards.Get(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            ListPaginated<CardDTO> cards = Api.Cards.GetCardsByFingerprint(card.Fingerprint);

            Assert.True(cards.Count > 0, "Card lsit is empty");

            foreach (CardDTO cardDTO in cards)
            {
                Assert.AreEqual(card.Fingerprint, cardDTO.Fingerprint);
            }
        }

        [Test]
        [Ignore("Ignored as it will deactivate the test card")]
        public void Test_Card_Validate()
        {
            var payIn = GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            var card = Api.Cards.Get(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            var validated = Api.Cards.Validate(card.Id);
            Assert.IsNotNull(validated);
        }

        [Test]
        public void Test_Card_GetByFingerprint_Paginated()
        {
            PayInCardDirectDTO payIn = GetNewPayInCardDirect();
            Assert.IsNotNull(payIn, "PayIn object is null!");
            CardDTO card = Api.Cards.Get(payIn.CardId);

            Assert.IsNotNull(card, "Card is null!");
            Assert.IsNotNull(card.Fingerprint, "Card fingerprint is null!");
            Assert.IsNotEmpty(card.Fingerprint, "Card fingerprint is empty!");

            Pagination pagination = new Pagination(1, 1);
            ListPaginated<CardDTO> cards = Api.Cards.GetCardsByFingerprint(card.Fingerprint, pagination, null);

            Assert.True(cards.Count == 1, String.Format("Requested 1 entity, got {0}", cards.Count));

            foreach (CardDTO cardDTO in cards)
            {
                Assert.AreEqual(card.Fingerprint, cardDTO.Fingerprint);
            }
        }
    }
}
