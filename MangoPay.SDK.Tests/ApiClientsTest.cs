using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiClientsTest : BaseTest
    {
        [Test]
        public async Task Test_Client_GetWallets()
        {
            ListPaginated<WalletDTO> feesWallets = null;
            ListPaginated<WalletDTO> creditWallets = null;
            try
            {
                feesWallets = await this.Api.Clients.GetWalletsAsync(FundsType.FEES, new Pagination(1, 100));
                creditWallets = await this.Api.Clients.GetWalletsAsync(FundsType.CREDIT, new Pagination(1, 100));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(feesWallets);
            Assert.IsNotNull(creditWallets);
        }

        [Test]
        public async Task Test_Client_GetWallet()
        {
            ListPaginated<WalletDTO> feesWallets = null;
            ListPaginated<WalletDTO> creditWallets = null;
            try
            {
                feesWallets = await this.Api.Clients.GetWalletsAsync(FundsType.FEES, new Pagination(1, 1));
                creditWallets = await this.Api.Clients.GetWalletsAsync(FundsType.CREDIT, new Pagination(1, 1));
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
            if (feesWallets.Count > 0)
                wallet = feesWallets[0];
            else if (creditWallets.Count > 0)
                wallet = creditWallets[0];

            result = await this.Api.Clients.GetWalletAsync(wallet.FundsType, wallet.Currency);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.FundsType == wallet.FundsType);
            Assert.IsTrue(result.Currency == wallet.Currency);
        }

        [Test]
        public async Task Test_Client_GetWalletTransactions()
        {
            ListPaginated<WalletDTO> feesWallets = null;
            ListPaginated<WalletDTO> creditWallets = null;
            try
            {
                feesWallets = await this.Api.Clients.GetWalletsAsync(FundsType.FEES, new Pagination(1, 1));
                creditWallets = await this.Api.Clients.GetWalletsAsync(FundsType.CREDIT, new Pagination(1, 1));
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
            if (feesWallets.Count > 0)
                wallet = feesWallets[0];
            else if (creditWallets.Count > 0)
                wallet = creditWallets[0];

            result = await this.Api.Clients.GetWalletTransactionsAsync(wallet.FundsType, wallet.Currency, new Pagination(1, 1), null);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        [Ignore("endpoint removed")]
        public async Task Test_Client_GetTransactions()
        {
            ListPaginated<TransactionDTO> result = null;

            try
            {
                result = await this.Api.Clients.GetTransactionsAsync(null, null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Test_Client_CreateBankWireDirect()
        {
            try
            {
                var bankwireDirectPost = new ClientBankWireDirectPostDTO("CREDIT_EUR", new Money { Amount = 1000, Currency = CurrencyIso.EUR });

                PayInDTO result = await this.Api.Clients.CreateBankWireDirectAsync(bankwireDirectPost);

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
        public async Task Test_ClientGet()
        {
            var client = await this.Api.Clients.GetAsync();

            Assert.IsNotNull(client);
            Assert.IsTrue("sdk-unit-tests".Equals(client.ClientId));
            Assert.IsNotNull(client.Licensor);
        }

        [Test]
        public async Task Test_ClientSave()
        {
            var client = new ClientPutDTO();

            var rand = new Random();
            var color1 = (rand.Next(100000) + 100000).ToString();
            var color2 = (rand.Next(100000) + 100000).ToString();
            var headquartersPhoneNumber = (rand.Next(10000000, 99999999)).ToString();

            client.PrimaryButtonColour = "#" + color1;
            client.PrimaryThemeColour = "#" + color2;
            client.AdminEmails = new List<string> { "support@mangopay.com", "technical@mangopay.com" };
            client.BillingEmails = new List<string> { "support@mangopay.com", "technical@mangopay.com" };
            client.FraudEmails = new List<string> { "support@mangopay.com", "technical@mangopay.com" };
            client.TechEmails = new List<string> { "support@mangopay.com", "technical@mangopay.com" };
            client.TaxNumber = "123456";
            client.PlatformDescription = "Description";
            client.PlatformType = PlatformType.MARKETPLACE;
            client.PlatformURL = "http://test.com";
            client.HeadquartersAddress = new Address
            {
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                City = "City",
                Country = CountryIso.FR,
                PostalCode = "51234",
                Region = "Region"
            };
            client.HeadquartersPhoneNumber = headquartersPhoneNumber;

            var clientNew = await this.Api.Clients.SaveAsync(client);

            Assert.IsNotNull(clientNew);
            Assert.AreEqual(client.PrimaryButtonColour, clientNew.PrimaryButtonColour);
            Assert.AreEqual(client.PrimaryThemeColour, clientNew.PrimaryThemeColour);
            Assert.AreEqual(client.AdminEmails.Count, 2);
            Assert.AreEqual(client.AdminEmails[0], "support@mangopay.com");
            Assert.AreEqual(client.AdminEmails[1], "technical@mangopay.com");
            Assert.AreEqual(client.BillingEmails.Count, 2);
            Assert.AreEqual(client.BillingEmails[0], "support@mangopay.com");
            Assert.AreEqual(client.BillingEmails[1], "technical@mangopay.com");
            Assert.AreEqual(client.FraudEmails.Count, 2);
            Assert.AreEqual(client.FraudEmails[0], "support@mangopay.com");
            Assert.AreEqual(client.FraudEmails[1], "technical@mangopay.com");
            Assert.AreEqual(client.TechEmails.Count, 2);
            Assert.AreEqual(client.TechEmails[0], "support@mangopay.com");
            Assert.AreEqual(client.TechEmails[1], "technical@mangopay.com");
            Assert.AreEqual(client.TaxNumber, "123456");
            Assert.AreEqual(client.PlatformDescription, "Description");
            Assert.AreEqual(client.PlatformType, PlatformType.MARKETPLACE);
            Assert.AreEqual(client.PlatformURL, "http://test.com");
            Assert.IsNotNull(client.HeadquartersAddress);
            Assert.AreEqual(client.HeadquartersAddress.AddressLine1, "AddressLine1");
            Assert.AreEqual(client.HeadquartersAddress.AddressLine2, "AddressLine2");
            Assert.AreEqual(client.HeadquartersAddress.City, "City");
            Assert.AreEqual(client.HeadquartersAddress.Country, CountryIso.FR);
            Assert.AreEqual(client.HeadquartersAddress.PostalCode, "51234");
            Assert.AreEqual(client.HeadquartersAddress.Region, "Region");
            Assert.IsNotNull(client.HeadquartersPhoneNumber);
            Assert.AreEqual(headquartersPhoneNumber, client.HeadquartersPhoneNumber);
        }

        [Test]
        public async Task Test_Client_SaveAddressNull()
        {
            var client = new ClientPutDTO();

            var rand = new Random();
            var color1 = (rand.Next(100000) + 100000).ToString();
            var color2 = (rand.Next(100000) + 100000).ToString();

            client.PrimaryButtonColour = "#" + color1;
            client.PrimaryThemeColour = "#" + color2;
            client.HeadquartersAddress = new Address();

            var clientNew = await this.Api.Clients.SaveAsync(client);

            Assert.IsNotNull(clientNew);
        }

        [Test]
		[Ignore("skip")]
        public async Task Test_ClientLogo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fi = this.GetFileInfoOfFile(assembly.Location, "TestKycPageFile.png");

            await this.Api.Clients.UploadLogoAsync(fi.FullName);
            await this.Api.Clients.UploadLogoAsync(File.ReadAllBytes(fi.FullName));
        }

        [Test]
        public async Task Test_BankAccountCreation()
        {
            var john = await this.GetJohn();
            var account = new BankAccountIbanPostDTO(john.FirstName + " " + john.LastName, john.Address, "FR7630004000031234567890143")
            {
                UserId = john.Id,
                BIC = "BNPAFRPP"
            };

            var result = await Api.Clients.CreateBankAccountIbanAsync(account);

            Assert.NotNull(result);
            Assert.AreEqual(result.Type, BankAccountType.IBAN);
            Assert.NotNull(result.Id);
        }

        [Test]
        public async Task Test_Payout()
        {
            var john = await this.GetJohn();

            var wallet = (await Api.Clients.GetWalletsAsync(FundsType.FEES, new Pagination(1, 10))).FirstOrDefault();

            var account = new BankAccountIbanPostDTO(john.FirstName + " " + john.LastName, john.Address, "FR7630004000031234567890143")
            {
                UserId = john.Id,
                BIC = "BNPAFRPP"
            };

            var result = await Api.Clients.CreateBankAccountIbanAsync(account);

            var payOut = new WalletPayoutDTO
            {
                BankAccountId = result.Id,
                BankWireRef = "invoice 7282",
                DebitedFunds = new Money
                {
                    Amount = 12,
                    Currency = CurrencyIso.EUR
                },
                DebitedWalletId = wallet.Id,
                Tag = "DefaultTag"
            };

            var bankWire = await this.Api.Clients.CreatePayoutAsync(payOut);

            Assert.NotNull(bankWire);
            Assert.NotNull(bankWire.Id);
        }
    }
} 