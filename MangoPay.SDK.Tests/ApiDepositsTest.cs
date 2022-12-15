using System;
using System.Threading.Tasks;
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
	}
}
