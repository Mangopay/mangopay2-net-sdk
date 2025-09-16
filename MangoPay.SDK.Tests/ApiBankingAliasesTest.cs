using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

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
				var john = await this.GetJohn();
				var wallet = await this.GetJohnsWallet();
				var bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};

				var bankingAlias = await Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);

				Assert.IsNotEmpty(bankingAlias.Id);
				Assert.IsNotEmpty(bankingAlias.VirtualAccountPurpose);
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
				var john = await this.GetJohn();
				var walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
				var wallet = await this.Api.Wallets.CreateAsync(walletPost);
				var bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
				var bankingAliasCreated = await this.Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);

                var bankingAlias = await this.Api.BankingAlias.GetAsync(bankingAliasCreated.Id);

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
                var john = await this.GetJohn();
                var walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
                var wallet = await this.Api.Wallets.CreateAsync(walletPost);
                var bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
                var bankingAliasCreated = await Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);

                var bankingAlias = await this.Api.BankingAlias.GetIbanAsync(bankingAliasCreated.Id);

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
                var john = await this.GetJohn();
                var walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
                var wallet = await this.Api.Wallets.CreateAsync(walletPost);
                var bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
                var bankingAliasCreated = await this.Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);
                var pagination = new Pagination(1, 2);
                var sort = new Sort();
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
                var john = await this.GetJohn();
                var walletPost = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);
                var wallet = await this.Api.Wallets.CreateAsync(walletPost);
                var bankingAliasIban = new BankingAliasIbanPostDTO(
					john.FirstName + " " + john.LastName, CountryIso.LU)
				{
					Tag = "Tag test"
				};
                var bankingAliasCreated = await this.Api.BankingAlias.CreateIbanAsync(wallet.Id, bankingAliasIban);
                var bankingAliasPut = new BankingAliasPutDTO
				{
					Active = false
				};

                var bankingAlias = await this.Api.BankingAlias.UpdateAsync(bankingAliasPut, bankingAliasCreated.Id);

                var bankingAliasGet = await this.Api.BankingAlias.GetAsync(bankingAliasCreated.Id);

				Assert.IsFalse(bankingAliasGet.Active);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
