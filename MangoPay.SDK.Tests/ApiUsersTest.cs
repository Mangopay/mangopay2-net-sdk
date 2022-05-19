﻿using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiUsersTest : BaseTest
    {
        [Test]
        public async Task Test_Users_CreateNatural()
        {
            try
            {
                var john = await this.GetJohn();
                Assert.IsTrue(john.Id.Length > 0);
                Assert.IsTrue(john.PersonType == PersonType.NATURAL);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateLegal()
        {
            try
            {
                var matrix = await this.GetMatrix();
                Assert.IsTrue(matrix.Id.Length > 0);
                Assert.IsTrue(matrix.PersonType == PersonType.LEGAL);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateLegal_PassesIfRequiredPropsProvided()
        {
            try
            {
                var userPost = new UserLegalPayerPostDTO
                {
                    Email = "email@email.org",
                    Name = "SomeOtherSampleOrg",
                    UserCategory = UserCategory.PAYER,
                    LegalPersonType = LegalPersonType.BUSINESS,
                    LegalRepresentativeFirstName = "RepFName",
                    LegalRepresentativeLastName = "RepLName",
                    TermsAndConditionsAccepted = true
                };

                var userCreated = await this.Api.Users.CreatePayerAsync(userPost);

                var userGet = await this.Api.Users.GetLegalAsync(userCreated.Id);

                Assert.IsTrue(userCreated.Id.Length > 0, "Created successfully after required props set.");

                AssertEqualInputProps(userCreated, userGet);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_GetNatural()
        {
            try
            {
                var john = await this.GetNewJohn();

                var userNatural = await this.Api.Users.GetNaturalAsync(john.Id);

                Assert.IsTrue(userNatural.PersonType == PersonType.NATURAL);
                Assert.IsTrue(userNatural.Id == john.Id);

                AssertEqualInputProps(userNatural, john);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_GetNatural_FailsForLegalUser()
        {
            UserLegalDTO matrix = null;
            try
            {
                matrix = await this.GetMatrix();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            UserNaturalDTO user = null;
            try
            {
                user = await this.Api.Users.GetNaturalAsync(matrix.Id);

                Assert.Fail("GetUser() should throw an exception when called with legal user id.");
            }
            catch (ResponseException)
            {
                Assert.IsNull(user);
            }
        }

        [Test]
        public async Task Test_Users_GetLegal_FailsForNaturalUser()
        {
            UserNaturalDTO john = null;
            try
            {
                john = await this.GetJohn();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            UserDTO user = null;
            try
            {
                user = await this.Api.Users.GetLegalAsync(john.Id);

                Assert.IsTrue(false, "GetLegal() should throw an exception when called with natural user id");
            }
            catch (ResponseException)
            {
                Assert.IsNull(user);
            }
        }

        [Test]
        public async Task Test_Users_GetLegal()
        {
            try
            {
                var matrix = await this.GetMatrix();

                UserDTO userLegal = await this.Api.Users.GetLegalAsync(matrix.Id);

                AssertEqualInputProps((UserLegalDTO)userLegal, matrix);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_GetAll()
        {
            try
            {
                var users = await this.Api.Users.GetAllAsync();

                Assert.IsNotNull(users);
                Assert.IsTrue(users.Count > 0);


                // test sorting
                ListPaginated<UserDTO> result = null;
                ListPaginated<UserDTO> result2 = null;

                var pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Users.GetAllAsync(pagination, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Users.GetAllAsync(pagination, sort);
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
        public async Task Test_Users_Save_Natural()
        {
            try
            {
                var john = await this.GetJohn();

                var johnPut = new UserNaturalPutDTO
                {
					LastName = john.LastName + " - CHANGED",
					Nationality = CountryIso.DK
                };

                var userSaved = await this.Api.Users.UpdateNaturalAsync(johnPut, john.Id);
                var userFetched = await this.Api.Users.GetNaturalAsync(john.Id);

                Assert.AreEqual(johnPut.LastName, userSaved.LastName);
                AssertEqualInputProps(userSaved, userFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_Save_Natural_NonASCII()
        {
            try
            {
                var john = await this.GetJohn();

                var johnPut = new UserNaturalPutDTO
                {
                    Tag = john.Tag,
                    Email = john.Email,
                    FirstName = john.FirstName,
                    LastName = john.LastName + " - CHANGED (éèęóąśłżźćń)",
                    Address = john.Address,
                    Birthday = john.Birthday,
                    Nationality = john.Nationality,
                    CountryOfResidence = john.CountryOfResidence,
                    Occupation = john.Occupation,
                    IncomeRange = john.IncomeRange
                };

                var userSaved = await this.Api.Users.UpdateNaturalAsync(johnPut, john.Id);
                var userFetched = await this.Api.Users.GetNaturalAsync(john.Id);

                Assert.AreEqual(johnPut.LastName, userSaved.LastName);
                AssertEqualInputProps(userSaved, userFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_Save_Legal()
        {
            try
            {
                var matrix = await this.GetMatrix();

                var matrixPut = new UserLegalPutDTO
                {
                    Tag = matrix.Tag,
                    Email = matrix.Email,
                    Name = matrix.Name,
                    LegalPersonType = matrix.LegalPersonType,
                    HeadquartersAddress = matrix.HeadquartersAddress,
                    LegalRepresentativeFirstName = matrix.LegalRepresentativeFirstName,
                    LegalRepresentativeLastName = matrix.LegalRepresentativeLastName + " - CHANGED",
                    LegalRepresentativeAddress = matrix.LegalRepresentativeAddress,
                    LegalRepresentativeEmail = matrix.LegalRepresentativeEmail,
                    LegalRepresentativeBirthday = matrix.LegalRepresentativeBirthday,
                    LegalRepresentativeNationality = matrix.LegalRepresentativeNationality,
                    LegalRepresentativeCountryOfResidence = matrix.LegalRepresentativeCountryOfResidence
                };

                var userSaved = await this.Api.Users.UpdateLegalAsync(matrixPut, matrix.Id);
                var userFetched = await this.Api.Users.GetLegalAsync(userSaved.Id);

                Assert.AreEqual(matrixPut.LegalRepresentativeLastName, userFetched.LegalRepresentativeLastName);
                AssertEqualInputProps(userSaved, userFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateBankAccount_IBAN()
        {
            try
            {
                var john = await this.GetJohn();
                var account = await this.GetJohnsAccount();

                Assert.IsTrue(account.Id.Length > 0);
                Assert.AreEqual(account.UserId, john.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateBankAccount_GB()
        {
            try
            {
                var john = await this.GetJohn();
                var account = new BankAccountGbPostDTO(john.FirstName + " " + john.LastName, john.Address, "63956474")
                {
                    SortCode = "200000"
                };

                BankAccountDTO createAccount = await this.Api.Users.CreateBankAccountGbAsync(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == BankAccountType.GB);
                Assert.IsTrue(((BankAccountGbDTO)createAccount).AccountNumber == "63956474");
                Assert.IsTrue(((BankAccountGbDTO)createAccount).SortCode == "200000");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateBankAccount_US()
        {
            try
            {
                var john = await this.GetJohn();
                var account = new BankAccountUsPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "234334789");

				BankAccountDTO createAccount = await this.Api.Users.CreateBankAccountUsAsync(john.Id, account);

				Assert.IsTrue(createAccount.Id.Length > 0);
				Assert.IsTrue(createAccount.UserId == (john.Id));
				Assert.IsTrue(createAccount.Type == BankAccountType.US);
				Assert.IsTrue(((BankAccountUsDTO)createAccount).AccountNumber == "234234234234");
				Assert.IsTrue(((BankAccountUsDTO)createAccount).ABA == "234334789");
				Assert.IsTrue(((BankAccountUsDTO)createAccount).DepositAccountType == DepositAccountType.CHECKING);

				account.DepositAccountType = DepositAccountType.SAVINGS;
				BankAccountDTO createAccountSavings = await this.Api.Users.CreateBankAccountUsAsync(john.Id, account);

				Assert.IsTrue(createAccountSavings.Id.Length > 0);
				Assert.IsTrue(createAccountSavings.UserId == (john.Id));
				Assert.IsTrue(createAccountSavings.Type == BankAccountType.US);
				Assert.IsTrue(((BankAccountUsDTO)createAccountSavings).AccountNumber == "234234234234");
				Assert.IsTrue(((BankAccountUsDTO)createAccountSavings).ABA == "234334789");
				Assert.IsTrue(((BankAccountUsDTO)createAccountSavings).DepositAccountType == DepositAccountType.SAVINGS);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateBankAccount_CA()
        {
            try
            {
                var john = await this.GetJohn();
                var account = new BankAccountCaPostDTO(john.FirstName + " " + john.LastName, john.Address, "TestBankName", "123", "12345", "234234234234");

                BankAccountDTO createAccount = await this.Api.Users.CreateBankAccountCaAsync(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == BankAccountType.CA);
                Assert.IsTrue(((BankAccountCaDTO)createAccount).AccountNumber == "234234234234");
                Assert.IsTrue(((BankAccountCaDTO)createAccount).BankName == "TestBankName");
                Assert.IsTrue(((BankAccountCaDTO)createAccount).BranchCode == "12345");
                Assert.IsTrue(((BankAccountCaDTO)createAccount).InstitutionNumber == "123");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateBankAccount_OTHER()
        {
            try
            {
                var john = await this.GetJohn();
                var account = new BankAccountOtherPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "BINAADADXXX")
                    {
                        Type = BankAccountType.OTHER,
                        Country = CountryIso.FR
                    };

                BankAccountDTO createAccount = await this.Api.Users.CreateBankAccountOtherAsync(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == BankAccountType.OTHER);
                Assert.IsTrue(((BankAccountOtherDTO)createAccount).Type == BankAccountType.OTHER);
                Assert.IsTrue(((BankAccountOtherDTO)createAccount).Country == CountryIso.FR);
                Assert.IsTrue(((BankAccountOtherDTO)createAccount).AccountNumber == ("234234234234"));
                Assert.IsTrue(((BankAccountOtherDTO)createAccount).BIC == ("BINAADADXXX"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateBankAccount()
        {
            try
            {
                var john = await this.GetJohn();
                var account = await this.GetJohnsAccount();

                Assert.IsTrue(account.Id.Length > 0);
                Assert.IsTrue(account.UserId == (john.Id));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_BankAccount()
        {
            try
            {
                var john = await this.GetJohn();
                var account = await this.GetJohnsAccount();

                var accountFetched = await this.Api.Users.GetBankAccountIbanAsync(john.Id, account.Id);

                AssertEqualInputProps(account, accountFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_BankAccounts()
        {
            try
            {
                var john = await this.GetJohn();
                var account = await this.GetJohnsAccount();
                var pagination = new Pagination(1, 12);

                var list = await this.Api.Users.GetBankAccountsAsync(john.Id, pagination);

                int listIndex;
                for (listIndex = 0; listIndex < list.Count; listIndex++)
                {
                    if (list[listIndex].Id == account.Id) break;
                }

                Assert.IsTrue(list[listIndex] is BankAccountDTO);
                Assert.IsTrue(list[listIndex] is BankAccountIbanDTO);

                var castedBankAccount = await this.Api.Users.GetBankAccountIbanAsync(john.Id, list[listIndex].Id);

                Assert.IsTrue(account.Id == castedBankAccount.Id);
                AssertEqualInputProps(account, castedBankAccount);
                Assert.IsTrue(pagination.Page == 1);
                Assert.IsTrue(pagination.ItemsPerPage == 12);


                // test sorting
                ListPaginated<BankAccountDTO> result = null;
                ListPaginated<BankAccountDTO> result2 = null;

                var account2 = new BankAccountOtherPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "BINAADADXXX");
                account2.Type = BankAccountType.OTHER;
                account2.Country = CountryIso.FR;

                var other = await this.Api.Users.CreateBankAccountOtherAsync(john.Id, account2);

                pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Users.GetBankAccountsAsync(john.Id, pagination, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);
                Assert.IsTrue(result[1] is BankAccountOtherDTO);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Users.GetBankAccountsAsync(john.Id, pagination, sort);
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
		public async Task Test_Users_UpdateBankAccount() 
		{
			try
			{
                var john = await this.GetJohn();
                var account = await this.GetJohnsAccount();

				Assert.IsTrue(account.Id.Length > 0);
				Assert.IsTrue(account.UserId == (john.Id));
				Assert.IsTrue(account.Active);

                // deactivate bank account
                var deactivateBankAccount = new DisactivateBankAccountPutDTO
                {
                    Active = false
                };

                var result = await this.Api.Users.UpdateBankAccountAsync(john.Id, deactivateBankAccount, account.Id);

				Assert.IsNotNull(result);
				Assert.IsTrue(account.Id == result.Id);
				Assert.IsFalse(result.Active);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

        [Test]
        public async Task Test_Users_CreateKycDocument()
        {
            try
            {
                var kycDocument = await this.GetJohnsKycDocument();

                Assert.IsNotNull(kycDocument);
                Assert.IsTrue(kycDocument.Id.Length > 0);
                Assert.IsTrue(kycDocument.Status == KycStatus.CREATED);
                Assert.IsTrue(kycDocument.Type == KycDocumentType.IDENTITY_PROOF);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_SaveKycDocument()
        {
            try
            {
                var john = await this.GetJohn();
                var kycDocument = await this.GetJohnsKycDocument();

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location);

                await this.Api.Users.CreateKycPageAsync(john.Id, kycDocument.Id, fi.FullName);

                var kycDocumentPut = new KycDocumentPutDTO 
                {
                    Status = KycStatus.VALIDATION_ASKED
                };

                var result = await this.Api.Users.UpdateKycDocumentAsync(john.Id, kycDocumentPut, kycDocument.Id);

                Assert.IsNotNull(result);
                Assert.IsTrue(kycDocument.Type == result.Type);
                Assert.IsTrue(result.Status == KycStatus.VALIDATION_ASKED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_GetKycDocument()
        {
            try
            {
                var john = await this.GetJohn();
                var kycDocument = await this.GetJohnsKycDocument();

                var result = await this.Api.Users.GetKycDocumentAsync(john.Id, kycDocument.Id);

                Assert.IsNotNull(result);
                Assert.IsTrue(kycDocument.Id == (result.Id));
                Assert.IsTrue(kycDocument.Type == (result.Type));
                Assert.IsTrue(kycDocument.CreationDate == result.CreationDate);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateKycPageFromFile()
        {
            try
            {
                var john = await this.GetJohn();
                var kycDocument = await this.GetNewKycDocument();

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location);

                await this.Api.Users.CreateKycPageAsync(john.Id, kycDocument.Id, fi.FullName);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_CreateKycPageFromBytes()
        {            
            try
            {
                var john = await this.GetJohn();
                var kycDocument = await this.GetNewKycDocument();

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location);
                var bytes = await File.ReadAllBytesAsync(fi.FullName);

                await this.Api.Users.CreateKycPageAsync(john.Id, kycDocument.Id, bytes);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_AllCards()
        {
            try
            {
                var john = await this.GetJohn();
                var payIn = await this.GetNewPayInCardDirect();
                var pagination = new Pagination(1, 1);
                var card = await this.Api.Cards.GetAsync(payIn.CardId);
                var cards = await this.Api.Users.GetCardsAsync(john.Id, pagination);

                Assert.IsTrue(cards.Count == 1);
                Assert.IsTrue(cards[0].CardType != CardType.NotSpecified);
                AssertEqualInputProps(cards[0], card);


                // test sorting
                ListPaginated<CardDTO> result = null;
                ListPaginated<CardDTO> result2 = null;

                pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Users.GetCardsAsync(john.Id, pagination, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Users.GetCardsAsync(john.Id, pagination, sort);
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
        public async Task Test_Users_Transactions()
        {
            try
            {
                var john = await this.GetJohn();
                var transfer = await this.GetNewTransfer();
                var pagination = new Pagination(1, 1);

                var transactions = await this.Api.Users.GetTransactionsAsync(john.Id, pagination, new FilterTransactions());

                Assert.IsTrue(transactions.Count > 0);

                // test sorting
                ListPaginated<TransactionDTO> result = null;
                ListPaginated<TransactionDTO> result2 = null;

                pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Users.GetTransactionsAsync(john.Id, pagination, new FilterTransactions(), sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Users.GetTransactionsAsync(john.Id, pagination, new FilterTransactions(), sort);
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
        public async Task Test_Users_GetKycDocuments()
        {
            ListPaginated<KycDocumentDTO> result = null;

            var john = await this.GetJohn();
            var kycDocument = await this.GetJohnsKycDocument();

            try
            {
                result = await this.Api.Users.GetKycDocumentsAsync(john.Id, null, null);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);


                // test sorting
                await GetNewKycDocument();
                result = null;
                ListPaginated<KycDocumentDTO> result2 = null;

                var pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Users.GetKycDocumentsAsync(john.Id, pagination, null, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Users.GetKycDocumentsAsync(john.Id, pagination, null, sort);
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
		public async Task Test_Users_GetEmoney()
		{
			try
			{
				var user = await GetNewJohn();
				await GetNewJohnsWalletWithMoney(100, user);

				var emoney = await Api.Users.GetEmoneyAsync(user.Id);

				Assert.AreEqual(user.Id, emoney.UserId);
				Assert.AreEqual(100, emoney.CreditedEMoney.Amount);
				Assert.AreEqual(CurrencyIso.EUR, emoney.CreditedEMoney.Currency);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

        [Test]
        public async Task Test_User_GetEmoneyForYear()
        {
            try
            {
                var user = await GetNewJohn();
                await GetNewJohnsWalletWithMoney(100, user);
		        var year = DateTime.Now.Year.ToString();
                var emoney = await Api.Users.GetEmoneyForYearAsync(user.Id, year);

                Assert.IsNotNull(emoney);
                Assert.AreEqual(user.Id, emoney.UserId);
                Assert.AreEqual(100, emoney.CreditedEMoney.Amount);
                Assert.AreEqual(CurrencyIso.EUR, emoney.CreditedEMoney.Currency);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task GetTest_User_GetEmoneyForYearAndMonth()
        {
            try
            {
                var user = await GetNewJohn();
                await GetNewJohnsWalletWithMoney(100, user);
		        var year = DateTime.Now.Year.ToString();
                var month = DateTime.Now.Month.ToString();

                var emoney = await Api.Users.GetEmoneyForYearAndMonthAsync(user.Id, year, month);

                Assert.AreEqual(user.Id, emoney.UserId);
                Assert.AreEqual(100, emoney.CreditedEMoney.Amount);
                Assert.AreEqual(CurrencyIso.EUR, emoney.CreditedEMoney.Currency);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
		public async Task Test_Users_GetEmoneyWithCurrency()
		{
			try
			{
				var user = await GetNewJohn();
				await GetNewJohnsWalletWithMoney(100, user);

				var emoney = await Api.Users.GetEmoneyAsync(user.Id, CurrencyIso.USD);

				Assert.AreEqual(user.Id, emoney.UserId);
				Assert.AreEqual(CurrencyIso.USD, emoney.CreditedEMoney.Currency);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

        [Test]
        public async Task Test_Users_GetEmoneyWithYearAndCurrency()
        {
            try
            {
                var user = await GetNewJohn();
                await GetNewJohnsWalletWithMoney(100, user);
                var year = DateTime.Now.Year.ToString();

                var emoney = await Api.Users.GetEmoneyForYearAsync(user.Id, year, CurrencyIso.USD);

                Assert.NotNull(emoney);
                Assert.AreEqual(user.Id, emoney.UserId);
                Assert.AreEqual(CurrencyIso.USD, emoney.CreditedEMoney.Currency);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task Test_Users_GetEmoneyWithYearAndMonthAndCurrency()
        {
            try
            {
                var user = await GetNewJohn();
                await GetNewJohnsWalletWithMoney(100, user);
                var year = DateTime.Now.Year.ToString();
                var month = DateTime.Now.Month.ToString();

                var emoney = await Api.Users.GetEmoneyForYearAndMonthAsync(user.Id, year, month, CurrencyIso.USD);

                Assert.NotNull(emoney);
                Assert.AreEqual(user.Id, emoney.UserId);
                Assert.AreEqual(CurrencyIso.USD, emoney.CreditedEMoney.Currency);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
		public async Task Test_Users_GetTransactionsForBankAccount()
		{
			try
			{
				var payOut = await GetJohnsPayOutBankWire();
                var johnsAccount = await GetJohnsAccount();
                var bankAccountId = johnsAccount.Id;

				var pagination = new Pagination(1, 1);
				var filter = new FilterTransactions();
				var sort = new Sort();
				sort.AddField("CreationDate", SortDirection.desc);

				var transactions = await Api.Users.GetTransactionsForBankAccountAsync(bankAccountId, pagination, filter, sort);

				Assert.IsTrue(transactions.Count > 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

        [Test]
        public async Task Test_Users_GetUserRegulatory()
        {
            try
            {
                var john = await GetJohn();

                var status = await Api.Users.GetUserRegulatoryAsync(john.Id);

                Assert.NotNull(status);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Test_Users_Natural_TermsAndConditions()
        {
            try
            {
                var naturalJohn = await GetNewJohn();
                Assert.False(naturalJohn.TermsAndConditionsAccepted ?? false);

                var naturalJohnAccepted = await GetNewJohn(true);
                Assert.True(naturalJohnAccepted.TermsAndConditionsAccepted ?? true);
                Assert.True(naturalJohnAccepted.TermsAndConditionsAcceptedDate.HasValue);

                var updatedJohn = await this.Api.Users.UpdateNaturalAsync(new UserNaturalPutDTO
                {
                    TermsAndConditionsAccepted = true
                }, naturalJohn.Id);

                Assert.True(updatedJohn.TermsAndConditionsAccepted ?? true);
                Assert.True(updatedJohn.TermsAndConditionsAcceptedDate.HasValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task Test_Users_Legal_TermsAndConditions()
        {
            try
            {
                var legalJohn = await GetMatrix();
                Assert.False(legalJohn.TermsAndConditionsAccepted ?? false);

                var legalJohnAccepted = await GetMatrix(true, true);
                Assert.True(legalJohnAccepted.TermsAndConditionsAccepted ?? true);
                Assert.True(legalJohnAccepted.TermsAndConditionsAcceptedDate.HasValue);

                var updatedJohn = await this.Api.Users.UpdateLegalAsync(new UserLegalPutDTO
                {
                    TermsAndConditionsAccepted = true
                }, legalJohn.Id);

                Assert.True(updatedJohn.TermsAndConditionsAccepted ?? true);
                Assert.True(updatedJohn.TermsAndConditionsAcceptedDate.HasValue);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task TestNaturalUserPayerSuccessful()
        {
            try
            {
                var user = new UserNaturalPayerPostDTO
                {
                    FirstName = "Karim",
                    LastName = "Benzema",
                    Email = "karim.benzema@realmadrid.es",
                    Address = new Address
                    {
                        AddressLine1 = "Valdebebas Ciudat Deportiva",
                        AddressLine2 = "Barajas, Madrid",
                        City = "Madrid",
                        Country = CountryIso.ES,
                        PostalCode = "28080",
                        Region = "Central"
                    },
                    Tag = "BALON DE ORO",
                    TermsAndConditionsAccepted = true,
                    UserCategory = UserCategory.PAYER,
                };

                var result = await this.Api.Users.CreatePayerAsync(user);

                Assert.NotNull(result);
                Assert.IsTrue(result.UserCategory is UserCategory.PAYER);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task TestNaturalUserPayerFails()
        {
            try
            {
                var user = new UserNaturalPayerPostDTO
                {
                    FirstName = "Karim",
                    LastName = "Benzema",
                    Email = "karim.benzema@realmadrid.es",
                    Address = new Address
                    {
                        AddressLine1 = "Valdebebas Ciudat Deportiva",
                        AddressLine2 = "Barajas, Madrid",
                        City = "Madrid",
                        Country = CountryIso.ES,
                        PostalCode = "28080",
                        Region = "Central"
                    },
                    Tag = "BALON DE ORO",
                    TermsAndConditionsAccepted = true,
                    UserCategory = UserCategory.OWNER,
                };

                await this.Api.Users.CreatePayerAsync(user);
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("BadRequest"));
            }
        }

        [Test]
        public async Task TestLegalUserOwner()
        {
            try
            {
                var user = new UserLegalOwnerPostDTO
                {
                    Name = "MartixSampleOrg",
                    LegalPersonType = LegalPersonType.BUSINESS,
                    UserCategory = UserCategory.OWNER,
                    TermsAndConditionsAccepted = true,
                    LegalRepresentativeFirstName = "JohnUbo",
                    LegalRepresentativeLastName = "DoeUbo",
                    LegalRepresentativeCountryOfResidence = CountryIso.PL,
                    LegalRepresentativeNationality = CountryIso.PL,
                    HeadquartersAddress = new Address
                    {
                        AddressLine1 = "Address line ubo 1",
                        AddressLine2 = "Address line ubo 2",
                        City = "CityUbo",
                        Country = CountryIso.PL,
                        PostalCode = "11222",
                        Region = "RegionUbo"
                    },
                    LegalRepresentativeAddress = new Address
                    {
                        AddressLine1 = "Address line ubo 1",
                        AddressLine2 = "Address line ubo 2",
                        City = "CityUbo",
                        Country = CountryIso.PL,
                        PostalCode = "11222",
                        Region = "RegionUbo"
                    },
                    LegalRepresentativeEmail = "john.doe@sample.org",
                    LegalRepresentativeBirthday = new DateTime(1975, 12, 21, 0, 0, 0),
                    Email = "john.doe@sample.org",
                    CompanyNumber = "LU72HN11"
                };

                var result = await Api.Users.CreatePayerAsync(user);

                Assert.NotNull(result);
                Assert.IsTrue(result.UserCategory is UserCategory.OWNER);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public async Task TestLegallUserPayerFails()
        {
            try
            {
                var user = new UserLegalOwnerPostDTO
                {
                    Name = "MartixSampleOrg",
                    LegalPersonType = LegalPersonType.BUSINESS,
                    UserCategory = UserCategory.OWNER,
                    TermsAndConditionsAccepted = true,
                    LegalRepresentativeFirstName = "JohnUbo",
                    LegalRepresentativeLastName = "DoeUbo",
                    LegalRepresentativeCountryOfResidence = CountryIso.PL,
                    LegalRepresentativeNationality = CountryIso.PL,
                    LegalRepresentativeEmail = "john.doe@sample.org",
                    LegalRepresentativeBirthday = new DateTime(1975, 12, 21, 0, 0, 0),
                    Email = "john.doe@sample.org"
                };

                await this.Api.Users.CreatePayerAsync(user);
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("BadRequest"));
            }
        }
    }
}
