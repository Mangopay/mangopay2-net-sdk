using System;
using System.Linq;
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

		[Test]
		public void Test_Refund_GetRefundsForPayOut()
		{
			try
			{
				var payOut = GetJohnsPayOutBankWire();

				var pagination = new Pagination(1, 1);

				var filter = new FilterRefunds();

				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var refunds = Api.Refunds.GetRefundsForPayOut(payOut.Id, pagination, filter, sort);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_Refund_GetRefundsForPayIn()
		{
			try
			{
				PayInDTO payIn = GetNewPayInCardDirect();
				RefundDTO refund = GetNewRefundForPayIn(payIn);

				var pagination = new Pagination(1, 1);

				var filter = new FilterRefunds
				{
					ResultCode = payIn.ResultCode,
					Status = payIn.Status
				};

				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var refunds = Api.Refunds.GetRefundsForPayIn(payIn.Id, pagination, filter, sort);

				Assert.IsTrue(refunds.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_Refund_GetRefundsForTransfer()
		{
			try
			{
				var wallet = this.GetNewJohnsWalletWithMoney(10000);
				TransferDTO transfer = this.GetNewTransfer(wallet);
				RefundDTO refund = this.GetNewRefundForTransfer(transfer);

				var pagination = new Pagination(1, 1);

				var filter = new FilterRefunds
				{
					ResultCode = transfer.ResultCode,
					Status = transfer.Status
				};

				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var refunds = Api.Refunds.GetRefundsForTransfer(transfer.Id, pagination, filter, sort);

				Assert.IsTrue(refunds.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

           /** TO BE FIXED DUE TO BAD DATA REASONS
		[Test]
		public void Test_Refund_GetRefundsForRepudiation()
		{
			try
			{
				Sort sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var _clientDisputes = Api.Disputes.GetAll(new Pagination(1, 100), null, sort);
				DisputeDTO dispute = _clientDisputes.FirstOrDefault(x => x.InitialTransactionId != null && x.DisputeType.HasValue && x.DisputeType.Value == DisputeType.NOT_CONTESTABLE);
				
				string repudiationId = Api.Disputes.GetTransactions(dispute.Id, new Pagination(1, 1), null)[0].Id;
				
				var pagination = new Pagination(1, 1);
				var filter = new FilterRefunds();

				var refunds = Api.Refunds.GetRefundsForRepudiation(repudiationId, pagination, filter, sort);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		*/
	}
}
