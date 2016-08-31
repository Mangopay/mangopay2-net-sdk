using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.IO;

namespace MangoPay.SDK.Tests
{
	[TestFixture]
	public class ApiClientsTest : BaseTest
	{
		[Test]
		public void Test_ClientsCreateClient()
		{
			try
			{
				Random rand = new Random();
				String id = (rand.Next(1000000000) + 1).ToString();
				ClientDTO client = this.Api.Clients.Create(id, "test", "test@o2.pl");
				Assert.IsTrue("test" == (client.Name));
				Assert.IsTrue(client.Passphrase.Length > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_Clients_TryCreateInvalidClient()
		{
			ClientDTO client = null;
			try
			{
				// invalid id
				client = this.Api.Clients.Create("0", "test", "test@o2.pl");
			}
			catch (Exception ex)
			{
				Assert.IsTrue(ex is ResponseException);
			}

			Assert.IsTrue(client == null);
		}

		[Test]
		public void Test_Client_GetKycDocuments()
		{
			ListPaginated<KycDocumentDTO> result = null;
			ListPaginated<KycDocumentDTO> result2 = null;

			try
			{
				result = this.Api.Clients.GetKycDocuments(null, null);
				Assert.IsNotNull(result);
				Assert.IsTrue(result.Count > 0);

				Pagination pagination = new Pagination(1, 2);
				Sort sort = new Sort();
				sort.AddField("CreationDate", SortDirection.asc);
				result = this.Api.Clients.GetKycDocuments(pagination, null, sort);
				Assert.IsNotNull(result);
				Assert.IsTrue(result.Count > 0);

				sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);
				result2 = this.Api.Clients.GetKycDocuments(pagination, null, sort);
				Assert.IsNotNull(result2);
				Assert.IsTrue(result2.Count > 0);

				Assert.IsTrue(result[0].Id != result2[0].Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_Client_GetWallets()
		{
			ListPaginated<WalletDTO> feesWallets = null;
			ListPaginated<WalletDTO> creditWallets = null;
			try
			{
				feesWallets = this.Api.Clients.GetWallets(FundsType.FEES, new Pagination(1, 100));
				creditWallets = this.Api.Clients.GetWallets(FundsType.CREDIT, new Pagination(1, 100));
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
			Assert.IsNotNull(feesWallets);
			Assert.IsNotNull(creditWallets);
		}

		[Test]
		public void Test_Client_GetWallet()
		{
			ListPaginated<WalletDTO> feesWallets = null;
			ListPaginated<WalletDTO> creditWallets = null;
			try
			{
				feesWallets = this.Api.Clients.GetWallets(FundsType.FEES, new Pagination(1, 1));
				creditWallets = this.Api.Clients.GetWallets(FundsType.CREDIT, new Pagination(1, 1));
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			if ((feesWallets == null || feesWallets.Count == 0) ||
				(creditWallets == null || creditWallets.Count == 0))
				Assert.Fail("Cannot test getting client's wallet because there is no any wallet for client.");

			WalletDTO wallet = null;
			WalletDTO result = null;
			if (feesWallets != null && feesWallets.Count > 0)
				wallet = feesWallets[0];
			else if (creditWallets != null && creditWallets.Count > 0)
				wallet = creditWallets[0];

			result = this.Api.Clients.GetWallet(wallet.FundsType, wallet.Currency);

			Assert.IsNotNull(result);
			Assert.IsTrue(result.FundsType == wallet.FundsType);
			Assert.IsTrue(result.Currency == wallet.Currency);
		}

		[Test]
		public void Test_Client_GetWalletTransactions()
		{
			ListPaginated<WalletDTO> feesWallets = null;
			ListPaginated<WalletDTO> creditWallets = null;
			try
			{
				feesWallets = this.Api.Clients.GetWallets(FundsType.FEES, new Pagination(1, 1));
				creditWallets = this.Api.Clients.GetWallets(FundsType.CREDIT, new Pagination(1, 1));
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			if ((feesWallets == null || feesWallets.Count == 0) ||
				(creditWallets == null || creditWallets.Count == 0))
				Assert.Fail("Cannot test getting client's wallet transactions because there is no any wallet for client.");

			WalletDTO wallet = null;
			ListPaginated<TransactionDTO> result = null;
			if (feesWallets != null && feesWallets.Count > 0)
				wallet = feesWallets[0];
			else if (creditWallets != null && creditWallets.Count > 0)
				wallet = creditWallets[0];

			result = this.Api.Clients.GetWalletTransactions(wallet.FundsType, wallet.Currency, new Pagination(1, 1), null);

			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
		}

		[Test]
		public void Test_Client_GetTransactions()
		{
			ListPaginated<TransactionDTO> result = null;

			try
			{
				result = this.Api.Clients.GetTransactions(null, null);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(result);
		}

		[Test]
		public void Test_Client_CreateBankWireDirect()
		{
			try
			{
				ClientBankWireDirectPostDTO bankwireDirectPost = new ClientBankWireDirectPostDTO("CREDIT_EUR", new Money { Amount = 1000, Currency = CurrencyIso.EUR });

				PayInDTO result = this.Api.Clients.CreateBankWireDirect(bankwireDirectPost);

				Assert.IsTrue(result.Id.Length > 0);
				Assert.AreEqual("CREDIT_EUR", result.CreditedWalletId);
				Assert.AreEqual(PayInPaymentType.BANK_WIRE, result.PaymentType);
				Assert.AreEqual(PayInExecutionType.DIRECT, result.ExecutionType);
				Assert.AreEqual(TransactionStatus.CREATED, result.Status);
				Assert.AreEqual(TransactionType.PAYIN, result.Type);
				Assert.IsNotNull(((PayInBankWireDirectDTO)result).WireReference);
				Assert.AreEqual(((PayInBankWireDirectDTO)result).BankAccount.Type, BankAccountType.IBAN);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_ClientGet()
		{
			ClientDTO client = this.Api.Clients.Get();

			Assert.IsNotNull(client);
			Assert.IsTrue("sdk-unit-tests".Equals(client.ClientId));
		}

		[Test]
		public void Test_ClientSave()
		{
			ClientPutDTO client = new ClientPutDTO();

			Random rand = new Random();
			String color1 = (rand.Next(100000) + 100000).ToString();
			String color2 = (rand.Next(100000) + 100000).ToString();

			client.PrimaryButtonColour = "#" + color1;
			client.PrimaryThemeColour = "#" + color2;

			ClientDTO clientNew = this.Api.Clients.Save(client);

			Assert.IsNotNull(clientNew);
			Assert.AreEqual(client.PrimaryButtonColour, clientNew.PrimaryButtonColour);
			Assert.AreEqual(client.PrimaryThemeColour, clientNew.PrimaryThemeColour);
		}

		[Test]
		public void Test_ClientLogo()
		{
			string filePath = "TestKycPageFile.png";

			this.Api.Clients.UploadLogo(filePath);
			this.Api.Clients.UploadLogo(File.ReadAllBytes(filePath));
		}
	}
}
