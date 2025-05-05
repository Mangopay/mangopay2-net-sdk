using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    [Explicit]
	public class ApiDepositsTest : BaseTest
	{
		
		[Test]
		public async Task Test_CreateDeposit()
		{
			try
			{
				DepositDTO deposit = await this.CreateNewDeposit();
				
				Assert.IsNotNull(deposit);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		
		[Test]
		public async Task Test_CreateDeposit_CheckCardInfo()
		{
			try
			{
				DepositDTO deposit = await this.CreateNewDeposit();
				
				Assert.IsNotNull(deposit.CardInfo);
				// Assert.IsNotNull(deposit.CardInfo.IssuingBank);
				// Assert.IsNotNull(deposit.CardInfo.Brand);
				// Assert.IsNotNull(deposit.CardInfo.Type);
				// Assert.IsNotNull(deposit.CardInfo.IssuerCountryCode);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_GetDeposit()
		{
			try
			{
				DepositDTO deposit = await this.CreateNewDeposit();
				DepositDTO fetchedDeposit = await this.Api.Deposits.GetAsync(deposit.Id);
				
				Assert.IsNotNull(fetchedDeposit);
				Assert.AreEqual(deposit.Id, fetchedDeposit.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		
		/*[Test]
		public async Task Test_CancelDeposit()
		{
			try
			{
				DepositDTO deposit = await this.CreateNewDeposit();

				await this.Api.Deposits.CancelAsync(deposit.Id);
				
				DepositDTO canceledDeposit = await this.Api.Deposits.GetAsync(deposit.Id);
				
				Assert.IsNotNull(canceledDeposit);
				Assert.AreEqual(deposit.Id, canceledDeposit.Id);
				Assert.AreEqual(canceledDeposit.PaymentStatus, PaymentStatus.CANCELED);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}*/
		
		[Test]
		public async Task Test_GetDepositsForCard()
		{
			DepositDTO deposit = await this.CreateNewDeposit();
			var filter = new FilterPreAuthorizations();
			filter.PaymentStatus = PaymentStatus.WAITING;
			var deposits = await this.Api.Deposits.GetAllForCardAsync(deposit.CardId, filter);
				
			Assert.IsNotNull(deposits);
			Assert.IsTrue(deposits.Count > 0);
		}
		
		[Test]
		public async Task Test_GetDepositsForUser()
		{
			DepositDTO deposit = await this.CreateNewDeposit();
			var filter = new FilterPreAuthorizations();
			filter.PaymentStatus = PaymentStatus.WAITING;
			var deposits = await this.Api.Deposits.GetAllForUserAsync(deposit.AuthorId, filter);
				
			Assert.IsNotNull(deposits);
			Assert.IsTrue(deposits.Count > 0);
		}
	}
}
