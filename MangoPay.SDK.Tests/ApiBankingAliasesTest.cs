using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
    public class ApiBankingAliasTest : BaseTest
    {
		[Test]
		public async Task Test_BankingAlias_CreateIban()
		{
			try
			{
				UserNaturalDTO john = await this.GetJohn();
				WalletDTO wallet = await this.GetJohnsWallet();
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};

				BankingAliasDTO bankingAlias = await Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);

				Assert.IsNotEmpty(bankingAlias.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
        public async Task Test_BankingAlias_Get()
        {
            try
            {
				UserNaturalDTO john = await this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = await this.Api.Wallets.CreateAsync(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = await this.Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);

				BankingAliasDTO bankingAlias = await this.Api.BankingAlias.GetAsync(bankingAliasCreated.Id);

                Assert.AreEqual(bankingAliasCreated.Id, bankingAlias.Id);
				Assert.AreEqual(BankingAliasType.IBAN, bankingAlias.Type);
			}
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public async Task Test_BankingAlias_GetIban()
		{
			try
			{
				UserNaturalDTO john = await this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = await this.Api.Wallets.CreateAsync(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = await Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);

				BankingAliasDTO bankingAlias = await this.Api.BankingAlias.GetIbanAsync(bankingAliasCreated.Id);

				Assert.AreEqual(bankingAliasCreated.Id, bankingAlias.Id);
				Assert.AreEqual(BankingAliasType.IBAN, bankingAlias.Type);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_BankingAlias_GetAll()
		{
			try
			{
				UserNaturalDTO john = await this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = await this.Api.Wallets.CreateAsync(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = await this.Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);
				Pagination pagination = new Pagination(1, 2);
				Sort sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);

				var result = await this.Api.BankingAlias.GetAllAsync(wallet.Id, pagination, sort);

				Assert.IsNotNull(result);
				Assert.AreEqual(1, result.Count);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public async Task Test_BankingAlias_Update()
		{
			try
			{
				UserNaturalDTO john = await this.GetJohn();
				WalletPostDTO walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				WalletDTO wallet = await this.Api.Wallets.CreateAsync(walletPost);
				BankingAliasIbanPostDTO bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
				BankingAliasDTO bankingAliasCreated = await this.Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);
				BankingAliasPutDTO bankingAliasPut = new BankingAliasPutDTO
				{
					Active = false
				};

				BankingAliasDTO bankingAlias = await this.Api.BankingAlias.UpdateAsync(bankingAliasPut, bankingAliasCreated.Id);

				BankingAliasDTO bankingAliasGet = await this.Api.BankingAlias.GetAsync(bankingAliasCreated.Id);

				Assert.IsFalse(bankingAliasGet.Active);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
