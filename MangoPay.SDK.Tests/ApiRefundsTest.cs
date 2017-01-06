using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiRefundsTest : BaseTest
    {
        [Test]
        public void Test_Refund_GetForTransfer()
        {
			WalletDTO wallet = this.GetNewJohnsWalletWithMoney(10000);
			TransferDTO transfer = this.GetNewTransfer(wallet);
            RefundDTO refund = this.GetNewRefundForTransfer(transfer);
            UserNaturalDTO user = this.GetJohn();

            RefundDTO getRefund = this.Api.Refunds.Get(refund.Id);

            Assert.AreEqual(getRefund.Id, refund.Id);
            Assert.AreEqual(getRefund.InitialTransactionId, transfer.Id);
            Assert.AreEqual(getRefund.AuthorId, user.Id);
			Assert.AreEqual(getRefund.Type, TransactionType.TRANSFER);
			Assert.IsNotNull(getRefund.RefundReason);
			Assert.AreEqual(getRefund.RefundReason.RefundReasonType, RefundReasonType.OTHER);
        }

        [Test]
        public void Test_Refund_GetForPayIn()
        {
            PayInDTO payIn = this.GetNewPayInCardDirect();
            RefundDTO refund = this.GetNewRefundForPayIn(payIn);
            UserNaturalDTO user = this.GetJohn();

            RefundDTO getRefund = this.Api.Refunds.Get(refund.Id);

            Assert.AreEqual(getRefund.Id, refund.Id);
            Assert.AreEqual(getRefund.InitialTransactionId, payIn.Id);
            Assert.AreEqual(getRefund.AuthorId, user.Id);
			Assert.AreEqual(getRefund.Type, TransactionType.PAYOUT);
			Assert.IsNotNull(getRefund.RefundReason);
			Assert.AreEqual(getRefund.RefundReason.RefundReasonType, RefundReasonType.INITIALIZED_BY_CLIENT);
        }
    }
}
