using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiRefundsTest : BaseTest
    {
        [Test]
        public async Task Test_Refund_GetForTransfer()
        {
            var wallet = await this.GetNewJohnsWalletWithMoney(100);
            var transfer = await this.GetNewTransfer(wallet);
            var refund = await this.GetNewRefundForTransfer(transfer);
            var user = await this.GetJohn();

            var getRefund = await this.Api.Refunds.GetAsync(refund.Id);

            Assert.AreEqual(getRefund.Id, refund.Id);
            Assert.AreEqual(getRefund.InitialTransactionId, transfer.Id);
            Assert.AreEqual(getRefund.AuthorId, user.Id);
			Assert.AreEqual(getRefund.Type, TransactionType.TRANSFER);
			Assert.IsNotNull(getRefund.RefundReason);
			// Assert.AreEqual(getRefund.RefundReason.RefundReasonType, "OTHER");
        }

        [Test]
        public async Task Test_Refund_GetForPayIn()
        {
            PayInDTO payIn = await this.GetNewPayInCardDirect();
            var refund = await this.GetNewRefundForPayIn(payIn);
            var user = await this.GetJohn();

            var getRefund = await this.Api.Refunds.GetAsync(refund.Id);

            Assert.AreEqual(getRefund.Id, refund.Id);
            Assert.AreEqual(getRefund.InitialTransactionId, payIn.Id);
            Assert.AreEqual(getRefund.AuthorId, user.Id);
			Assert.AreEqual(getRefund.Type, TransactionType.PAYOUT);
			Assert.IsNotNull(getRefund.RefundReason);
			Assert.AreEqual(getRefund.RefundReason.RefundReasonType, "INITIALIZED_BY_CLIENT");
        }

		[Test]
		public async Task Test_Refund_GetRefundsForPayOut()
		{
			try
			{
				var payOut = await GetJohnsPayOutBankWire();

				var pagination = new Pagination(1, 1);

				var filter = new FilterRefunds();

				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var refunds = await Api.Refunds.GetRefundsForPayOutAsync(payOut.Id, pagination, filter, sort);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_Refund_GetRefundsForPayIn()
		{
			try
			{
				PayInDTO payIn = await GetNewPayInCardDirect();
                var refund = await GetNewRefundForPayIn(payIn);

				var pagination = new Pagination(1, 1);

				var filter = new FilterRefunds
				{
					ResultCode = payIn.ResultCode,
					Status = payIn.Status
				};

				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var refunds = await Api.Refunds.GetRefundsForPayInAsync(payIn.Id, pagination, filter, sort);

				Assert.IsTrue(refunds.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_Refund_GetRefundsForTransfer()
		{
			try
			{
				var wallet = await this.GetNewJohnsWalletWithMoney(100);
                var transfer = await this.GetNewTransfer(wallet);
                var refund = await this.GetNewRefundForTransfer(transfer);

				var pagination = new Pagination(1, 1);

				var filter = new FilterRefunds
				{
					ResultCode = transfer.ResultCode,
					Status = transfer.Status
				};

				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var refunds = await Api.Refunds.GetRefundsForTransferAsync(transfer.Id, pagination, filter, sort);

				Assert.IsTrue(refunds.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
    }
}
