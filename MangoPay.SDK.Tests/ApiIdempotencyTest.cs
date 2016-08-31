using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
	public class ApiIdempotencyTest : BaseTest
	{
		[Test]
		public void Test_Idempotency()
		{
			string key = DateTime.Now.Ticks.ToString();

			PayOutBankWireDTO payOut = null;

			// create bankwire
			try
			{
				WalletDTO wallet = this.GetJohnsWallet();
				UserNaturalDTO user = this.GetJohn();
				BankAccountDTO account = this.GetJohnsAccount();

				PayOutBankWirePostDTO payOutPost = new PayOutBankWirePostDTO(user.Id, wallet.Id, new Money { Amount = 10, Currency = CurrencyIso.EUR }, new Money { Amount = 5, Currency = CurrencyIso.EUR }, account.Id, "Johns bank wire ref");
				payOutPost.Tag = "DefaultTag";
				payOutPost.CreditedUserId = user.Id;

				payOut = this.Api.PayOuts.CreateBankWire(key, payOutPost);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(payOut);


			// test existing key
			IdempotencyResponseDTO result = null;
			try
			{
				result = this.Api.Idempotency.Get(key);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);


			// test not existing key
			result = null;
			try
			{
				result = this.Api.Idempotency.Get(key + "_no");
				
				// expect a response error
				Assert.Fail();
			}
			catch (Exception ex)
			{
				/* catch block intentionally left empty */
			}
		}
	}
}
