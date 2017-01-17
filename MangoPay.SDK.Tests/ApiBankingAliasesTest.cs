using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    public class ApiBankingAliasTest : BaseTest
    {
		[Test]
		public void Test_BankingAlias_CreateIban()
		{
			try
			{
				UserNaturalDTO john = this.GetJohn();
				WalletDTO wallet = this.GetJohnsWallet();
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.FR)
				{
					Tag = "Tag test"
				};

				BankingAliasDTO bankingAlias = Api.BankingAlias.CreateIban(wallet.Id, bankingAliasIban);

				Assert.IsNotEmpty(bankingAlias.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
        public void Test_BankingAlias_Get()
        {
            try
            {
				UserNaturalDTO john = this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = this.Api.Wallets.Create(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.FR)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = Api.BankingAlias.CreateIban(wallet.Id, bankingAliasIban);

				BankingAliasDTO bankingAlias = this.Api.BankingAlias.Get(bankingAliasCreated.Id);

                Assert.AreEqual(bankingAliasCreated.Id, bankingAlias.Id);
				Assert.AreEqual(BankingAliasType.IBAN, bankingAlias.Type);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public void Test_BankingAlias_GetIban()
		{
			try
			{
				UserNaturalDTO john = this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = this.Api.Wallets.Create(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.FR)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = Api.BankingAlias.CreateIban(wallet.Id, bankingAliasIban);

				BankingAliasDTO bankingAlias = this.Api.BankingAlias.GetIban(bankingAliasCreated.Id);

				Assert.AreEqual(bankingAliasCreated.Id, bankingAlias.Id);
				Assert.AreEqual(BankingAliasType.IBAN, bankingAlias.Type);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_BankingAlias_GetAll()
		{
			try
			{
				UserNaturalDTO john = this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = this.Api.Wallets.Create(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.FR)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = Api.BankingAlias.CreateIban(wallet.Id, bankingAliasIban);
				Pagination pagination = new Pagination(1, 2);
				Sort sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);

				var result = this.Api.BankingAlias.GetAll(wallet.Id, pagination, sort);

				Assert.IsNotNull(result);
				Assert.AreEqual(1, result.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_BankingAlias_Update()
		{
			try
			{
				UserNaturalDTO john = this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = this.Api.Wallets.Create(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.FR)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = Api.BankingAlias.CreateIban(wallet.Id, bankingAliasIban);
				BankingAliasPutDTO bankingAliasPut = new BankingAliasPutDTO
				{
					Active = false
				};

				BankingAliasDTO bankingAlias = this.Api.BankingAlias.Update(bankingAliasPut, bankingAliasCreated.Id);

				BankingAliasDTO bankingAliasGet = this.Api.BankingAlias.Get(bankingAliasCreated.Id);

				Assert.IsFalse(bankingAliasGet.Active);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
