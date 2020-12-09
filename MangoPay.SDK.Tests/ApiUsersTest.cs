using MangoPay.SDK.Core;
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
                UserNaturalDTO john = await this.GetJohn();
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
                UserLegalDTO matrix = await this.GetMatrix();
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
                UserLegalPostDTO userPost = new UserLegalPostDTO("email@email.org", "SomeOtherSampleOrg", LegalPersonType.BUSINESS, "RepFName", "RepLName", new DateTime(1975, 12, 21, 0, 0, 0), CountryIso.FR, CountryIso.FR);

                UserLegalDTO userCreated = await this.Api.Users.CreateAsync(userPost);

                UserLegalDTO userGet = await this.Api.Users.GetLegalAsync(userCreated.Id);

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
                UserNaturalDTO john = await this.GetNewJohn();

                UserNaturalDTO userNatural = await this.Api.Users.GetNaturalAsync(john.Id);

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
                UserLegalDTO matrix = await this.GetMatrix();

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
                ListPaginated<UserDTO> users = await this.Api.Users.GetAllAsync();

                Assert.IsNotNull(users);
                Assert.IsTrue(users.Count > 0);


                // test sorting
                ListPaginated<UserDTO> result = null;
                ListPaginated<UserDTO> result2 = null;

                Pagination pagination = new Pagination(1, 2);
                Sort sort = new Sort();
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
                UserNaturalDTO john = await this.GetJohn();

                UserNaturalPutDTO johnPut = new UserNaturalPutDTO
                {
					LastName = john.LastName + " - CHANGED",
					Nationality = CountryIso.DK
                };

                UserNaturalDTO userSaved = await this.Api.Users.UpdateNaturalAsync(johnPut, john.Id);
                UserNaturalDTO userFetched = await this.Api.Users.GetNaturalAsync(john.Id);

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
                UserNaturalDTO john = await this.GetJohn();

                UserNaturalPutDTO johnPut = new UserNaturalPutDTO
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

                UserNaturalDTO userSaved = await this.Api.Users.UpdateNaturalAsync(johnPut, john.Id);
                UserNaturalDTO userFetched = await this.Api.Users.GetNaturalAsync(john.Id);

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
                UserLegalDTO matrix = await this.GetMatrix();

                UserLegalPutDTO matrixPut = new UserLegalPutDTO
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

                UserLegalDTO userSaved = await this.Api.Users.UpdateLegalAsync(matrixPut, matrix.Id);
                UserLegalDTO userFetched = await this.Api.Users.GetLegalAsync(userSaved.Id);

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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountDTO account = await this.GetJohnsAccount();

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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountGbPostDTO account = new BankAccountGbPostDTO(john.FirstName + " " + john.LastName, john.Address, "63956474")
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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountUsPostDTO account = new BankAccountUsPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "234334789");

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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountCaPostDTO account = new BankAccountCaPostDTO(john.FirstName + " " + john.LastName, john.Address, "TestBankName", "123", "12345", "234234234234");

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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountOtherPostDTO account = new BankAccountOtherPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "BINAADADXXX");
                account.Type = BankAccountType.OTHER;
                account.Country = CountryIso.FR;

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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountIbanDTO account = await this.GetJohnsAccount();

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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountIbanDTO account = await this.GetJohnsAccount();

                BankAccountIbanDTO accountFetched = await this.Api.Users.GetBankAccountIbanAsync(john.Id, account.Id);

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
                UserNaturalDTO john = await this.GetJohn();
                BankAccountIbanDTO account = await this.GetJohnsAccount();
                Pagination pagination = new Pagination(1, 12);

                ListPaginated<BankAccountDTO> list = await this.Api.Users.GetBankAccountsAsync(john.Id, pagination);

                int listIndex;
                for (listIndex = 0; listIndex < list.Count; listIndex++)
                {
                    if (list[listIndex].Id == account.Id) break;
                }

                Assert.IsTrue(list[listIndex] is BankAccountDTO);

                BankAccountIbanDTO castedBankAccount = await this.Api.Users.GetBankAccountIbanAsync(john.Id, list[listIndex].Id);

                Assert.IsTrue(account.Id == castedBankAccount.Id);
                AssertEqualInputProps(account, castedBankAccount);
                Assert.IsTrue(pagination.Page == 1);
                Assert.IsTrue(pagination.ItemsPerPage == 12);


                // test sorting
                ListPaginated<BankAccountDTO> result = null;
                ListPaginated<BankAccountDTO> result2 = null;

                BankAccountOtherPostDTO account2 = new BankAccountOtherPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "BINAADADXXX");
                account2.Type = BankAccountType.OTHER;
                account2.Country = CountryIso.FR;

                var other = await this.Api.Users.CreateBankAccountOtherAsync(john.Id, account2);

                pagination = new Pagination(1, 2);
                Sort sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Users.GetBankAccountsAsync(john.Id, pagination, sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

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
				UserNaturalDTO john = await this.GetJohn();
				BankAccountIbanDTO account = await this.GetJohnsAccount();

				Assert.IsTrue(account.Id.Length > 0);
				Assert.IsTrue(account.UserId == (john.Id));
				Assert.IsTrue(account.Active);

				// disactivate bank account
				DisactivateBankAccountPutDTO disactivateBankAccount = new DisactivateBankAccountPutDTO();
				disactivateBankAccount.Active = false;

				BankAccountDTO result = await this.Api.Users.UpdateBankAccountAsync(john.Id, disactivateBankAccount, account.Id);

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
                KycDocumentDTO kycDocument = await this.GetJohnsKycDocument();

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
                UserNaturalDTO john = await this.GetJohn();
                KycDocumentDTO kycDocument = await this.GetJohnsKycDocument();

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location);

                await this.Api.Users.CreateKycPageAsync(john.Id, kycDocument.Id, fi.FullName);

                KycDocumentPutDTO kycDocumentPut = new KycDocumentPutDTO 
                {
                    Status = KycStatus.VALIDATION_ASKED
                };

                KycDocumentDTO result = await this.Api.Users.UpdateKycDocumentAsync(john.Id, kycDocumentPut, kycDocument.Id);

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
                UserNaturalDTO john = await this.GetJohn();
                KycDocumentDTO kycDocument = await this.GetJohnsKycDocument();

                KycDocumentDTO result = await this.Api.Users.GetKycDocumentAsync(john.Id, kycDocument.Id);

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
                UserNaturalDTO john = await this.GetJohn();
                KycDocumentDTO kycDocument = await this.GetNewKycDocument();

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
                UserNaturalDTO john = await this.GetJohn();
                KycDocumentDTO kycDocument = await this.GetNewKycDocument();

                var assembly = Assembly.GetExecutingAssembly();
                var fi = this.GetFileInfoOfFile(assembly.Location);
                byte[] bytes = File.ReadAllBytes(fi.FullName);

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
                UserNaturalDTO john = await this.GetJohn();
                PayInCardDirectDTO payIn = await this.GetNewPayInCardDirect();
                Pagination pagination = new Pagination(1, 1);
                CardDTO card = await this.Api.Cards.GetAsync(payIn.CardId);
                ListPaginated<CardDTO> cards = await this.Api.Users.GetCardsAsync(john.Id, pagination);

                Assert.IsTrue(cards.Count == 1);
                Assert.IsTrue(cards[0].CardType != CardType.NotSpecified);
                AssertEqualInputProps(cards[0], card);


                // test sorting
                ListPaginated<CardDTO> result = null;
                ListPaginated<CardDTO> result2 = null;

                pagination = new Pagination(1, 2);
                Sort sort = new Sort();
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
                UserNaturalDTO john = await this.GetJohn();
                TransferDTO transfer = await this.GetNewTransfer();
                Pagination pagination = new Pagination(1, 1);

                ListPaginated<TransactionDTO> transactions = await this.Api.Users.GetTransactionsAsync(john.Id, pagination, new FilterTransactions());

                Assert.IsTrue(transactions.Count > 0);

                // test sorting
                ListPaginated<TransactionDTO> result = null;
                ListPaginated<TransactionDTO> result2 = null;

                pagination = new Pagination(1, 2);
                Sort sort = new Sort();
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

            UserNaturalDTO john = await this.GetJohn();
            KycDocumentDTO kycDocument = await this.GetJohnsKycDocument();

            try
            {
                result = await this.Api.Users.GetKycDocumentsAsync(john.Id, null, null);

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);


                // test sorting
                await GetNewKycDocument();
                result = null;
                ListPaginated<KycDocumentDTO> result2 = null;

                Pagination pagination = new Pagination(1, 2);
                Sort sort = new Sort();
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
				var wallet = await GetNewJohnsWalletWithMoney(10000, user);

				var emoney = await Api.Users.GetEmoneyAsync(user.Id);

				Assert.AreEqual(user.Id, emoney.UserId);
				Assert.AreEqual(10000, emoney.CreditedEMoney.Amount);
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
                var wallet = await GetNewJohnsWalletWithMoney(10000, user);
		        var year = DateTime.Now.Year.ToString();
                var emoney = await Api.Users.GetEmoneyForYearAsync(user.Id, year);

                Assert.IsNotNull(emoney);
                Assert.AreEqual(user.Id, emoney.UserId);
                //Assert.AreEqual("2019","2019");
                Assert.AreEqual(10000, emoney.CreditedEMoney.Amount);
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
                var wallet = await GetNewJohnsWalletWithMoney(10000, user);
		        var year = DateTime.Now.Year.ToString();
                var month = DateTime.Now.Month.ToString();

                var emoney = await Api.Users.GetEmoneyForYearAndMonthAsync(user.Id, year, month);

                Assert.AreEqual(user.Id, emoney.UserId);
                //Assert.AreEqual("2019","2019");
                //Assert.AreEqual("04","04");
                Assert.AreEqual(10000, emoney.CreditedEMoney.Amount);
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
				var wallet = GetNewJohnsWalletWithMoney(10000, user);

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
                var wallet = GetNewJohnsWalletWithMoney(10000, user);
                var year = DateTime.Now.Year.ToString();

                var emoney = await Api.Users.GetEmoneyAsync(user.Id, year, CurrencyIso.USD);

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
                var wallet = GetNewJohnsWalletWithMoney(10000, user);
                var year = DateTime.Now.Year.ToString();
                var month = DateTime.Now.Month.ToString();

                var emoney = await Api.Users.GetEmoneyAsync(user.Id, year, month, CurrencyIso.USD);

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
				string bankAccountId = johnsAccount.Id;

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
        [Ignore("not on api yet")]
        public async Task Test_Users_GetUserBlockStatus()
        {
            try
            {
                var john = await GetJohn();

                var status = await Api.Users.GetUserBlockStatusAsync(john.Id);

                Assert.NotNull(status);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        [Ignore("not on api yet")]
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
    }
}
