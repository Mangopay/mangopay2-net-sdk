using MangoPay.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Tests
{
    [TestClass]
    public class ApiRefundsTest : BaseTest
    {
        [TestMethod]
        public void Test_Refund_GetForTransfer()
        {
            Transfer transfer = this.GetNewTransfer();
            Refund refund = this.GetNewRefundForTransfer(transfer);
            UserNatural user = this.GetJohn();

            Refund getRefund = this.Api.Refunds.Get(refund.Id);

            Assert.AreEqual(getRefund.Id, refund.Id);
            Assert.AreEqual(getRefund.InitialTransactionId, transfer.Id);
            Assert.AreEqual(getRefund.AuthorId, user.Id);
            Assert.AreEqual(getRefund.Type, "TRANSFER");
        }

        [TestMethod]
        public void Test_Refund_GetForPayIn()
        {
            PayIn payIn = this.GetNewPayInCardDirect();
            Refund refund = this.GetNewRefundForPayIn(payIn);
            UserNatural user = this.GetJohn();

            Refund getRefund = this.Api.Refunds.Get(refund.Id);

            Assert.AreEqual(getRefund.Id, refund.Id);
            Assert.AreEqual(getRefund.InitialTransactionId, payIn.Id);
            Assert.AreEqual(getRefund.AuthorId, user.Id);
            Assert.AreEqual(getRefund.Type, "PAYOUT");
        }
    }
}
