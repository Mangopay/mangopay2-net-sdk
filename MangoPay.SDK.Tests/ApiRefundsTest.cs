using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiRefundsTest : BaseTest
    {
        [TestMethod]
        public void Test_Refund_GetForTransfer()
        {
            TransferDTO transfer = this.GetNewTransfer();
            RefundDTO refund = this.GetNewRefundForTransfer(transfer);
            UserNaturalDTO user = this.GetJohn();

            RefundDTO getRefund = this.Api.Refunds.Get(refund.Id);

            Assert.AreEqual(getRefund.Id, refund.Id);
            Assert.AreEqual(getRefund.InitialTransactionId, transfer.Id);
            Assert.AreEqual(getRefund.AuthorId, user.Id);
            Assert.AreEqual(getRefund.Type, TransactionType.TRANSFER);
        }

        [TestMethod]
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
        }
    }
}
