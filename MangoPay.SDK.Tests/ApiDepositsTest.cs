using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
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
				var john = await this.GetJohn();
				var cardRegistration = await this.GetCardRegistrationForDeposit();

				var dto = new DepositPostDTO();
				dto.AuthorId = john.Id;
				
				var debitedFunds = new Money();
				debitedFunds.Amount = 1000;
				debitedFunds.Currency = CurrencyIso.EUR;

				dto.DebitedFunds = debitedFunds;
				dto.CardId = cardRegistration.CardId;
				dto.SecureModeReturnURL = "https://lorem";
				dto.IpAddress = "2001:0620:0000:0000:0211:24FF:FE80:C12C";
				dto.BrowserInfo = getBrowserInfo();

				DepositDTO deposit = await this.Api.Deposits.Create(dto);
				Console.Write(deposit);
				
				Assert.IsNotNull(deposit);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

	}
}
