using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;

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
        public async Task Test_Users_EnrollIntoSca()
        {
            try
            {
                var john = await this.GetJohn();
                var enrollmentResult = await Api.Users.EnrollSca(john.Id);
                
                Assert.IsNotNull(enrollmentResult.PendingUserAction.RedirectUrl);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_CreateNaturalScaPayer()
        {
            try
            {
                var john = await GetJohnScaPayer();
                Assert.IsTrue(john.Id.Length > 0);
                Assert.IsTrue(john.PersonType == PersonType.NATURAL);
                Assert.IsTrue(john.UserCategory == UserCategory.PAYER);
                Assert.IsTrue(john.UserStatus == UserStatus.ACTIVE);
                Assert.IsNotNull(john.PhoneNumber);
                Assert.IsNotNull(john.PhoneNumberCountry);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_CreateNaturalScaOwner()
        {
            try
            {
                var john = await GetJohnScaOwner();
                Assert.IsTrue(john.Id.Length > 0);
                Assert.IsTrue(john.PersonType == PersonType.NATURAL);
                Assert.IsTrue(john.UserCategory == UserCategory.OWNER);
                Assert.IsTrue(john.UserStatus == UserStatus.PENDING_USER_ACTION);
                Assert.IsNotNull(john.PhoneNumber);
                Assert.IsNotNull(john.PhoneNumberCountry);
                Assert.IsNotNull(john.PendingUserAction.RedirectUrl);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_CategorizeNaturalScaPayer()
        {
            try
            {
                var john = await GetJohnScaPayer();
                var categorize = new CategorizeUserNaturalPutDTO
                {
                    TermsAndConditionsAccepted = true,
                    UserCategory = UserCategory.OWNER,
                    Email = "john.doe.sca@sample.org",
                    PhoneNumber = "+33611111111",
                    PhoneNumberCountry = CountryIso.FR,
                    Birthday = new DateTime(1975, 12, 21, 0, 0, 0),
                    Nationality = CountryIso.FR,
                    CountryOfResidence = CountryIso.FR,
                };

                var response = await Api.Users.CategorizeNaturalAsync(categorize, john.Id);
                
                Assert.IsTrue(response.Id.Length > 0);
                Assert.IsTrue(response.PersonType == PersonType.NATURAL);
                Assert.IsTrue(john.UserCategory == UserCategory.PAYER);
                Assert.IsTrue(response.UserCategory == UserCategory.OWNER);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_CategorizeLegalScaPayer()
        {
            try
            {
                var matrix = await GetMatrixScaPayer();
                var categorize = new CategorizeUserLegalPutDTO()
                {
                    TermsAndConditionsAccepted = true,
                    UserCategory = UserCategory.OWNER,
                    LegalRepresentative = new LegalRepresentative()
                    {
                        Email = "john.doe.sca@sample.org",
                        FirstName = "John SCA",
                        LastName = "Doe SCA Review",
                        PhoneNumber = "+33611111111",
                        PhoneNumberCountry = CountryIso.FR,
                        Birthday = new DateTime(1975, 12, 21, 0, 0, 0),
                        Nationality = CountryIso.FR,
                        CountryOfResidence = CountryIso.FR
                    },
                    HeadquartersAddress = new Address
                    {
                        AddressLine1 = "Address line ubo 1",
                        AddressLine2 = "Address line ubo 2",
                        City = "CityUbo",
                        Country = CountryIso.PL,
                        PostalCode = "11222",
                        Region = "RegionUbo"
                    },
                    CompanyNumber = "LU72HN11"
                };

                var response = await Api.Users.CategorizeLegalAsync(categorize, matrix.Id);
                
                Assert.IsTrue(response.Id.Length > 0);
                Assert.IsTrue(response.PersonType == PersonType.LEGAL);
                Assert.IsTrue(matrix.UserCategory == UserCategory.PAYER);
                Assert.IsTrue(response.UserCategory == UserCategory.OWNER);
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
        public async Task Test_Users_CreateLegalScaPayer()
        {
            try
            {
                var matrix = await this.GetMatrixScaPayer();
                Assert.IsTrue(matrix.Id.Length > 0);
                Assert.IsTrue(matrix.PersonType == PersonType.LEGAL);
                Assert.IsTrue(matrix.UserCategory == UserCategory.PAYER);
                Assert.IsTrue(matrix.UserStatus == UserStatus.ACTIVE);
                Assert.IsNotNull(matrix.LegalRepresentative);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_CreateLegalScaOwner()
        {
            try
            {
                var matrix = await this.GetMatrixScaOwner();
                Assert.IsTrue(matrix.Id.Length > 0);
                Assert.IsTrue(matrix.PersonType == PersonType.LEGAL);
                Assert.IsTrue(matrix.UserCategory == UserCategory.OWNER);
                Assert.IsTrue(matrix.UserStatus == UserStatus.PENDING_USER_ACTION);
                Assert.IsNotNull(matrix.LegalRepresentative);
                Assert.IsNotNull(matrix.HeadquartersAddress);
                Assert.IsNotNull(matrix.CompanyNumber);
                Assert.IsNotNull(matrix.PendingUserAction.RedirectUrl);
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
        public async Task Test_Users_GetNaturalSca()
        {
            var john = await this.GetJohnScaOwner();
            var userNatural = await this.Api.Users.GetNaturalScaAsync(john.Id);
            var userNatural2 = await this.Api.Users.GetScaAsync(john.Id);

            Assert.IsTrue(userNatural.PersonType == PersonType.NATURAL);
            Assert.IsTrue(userNatural.Id == john.Id);
            Assert.IsTrue(userNatural2.Id == john.Id);
            
            Assert.IsTrue(userNatural.Email == userNatural2.Email);
            Assert.IsTrue(userNatural.Tag == userNatural2.Tag);
            Assert.IsTrue(userNatural.CreationDate == userNatural2.CreationDate);
        }
        
        [Test]
        public async Task Test_Users_GetLegalSca()
        {
            var matrix = await this.GetMatrixScaOwner();
            var userLegal = await this.Api.Users.GetLegalScaAsync(matrix.Id);
            var userLegal2 = await this.Api.Users.GetScaAsync(matrix.Id);

            Assert.IsTrue(userLegal.PersonType == PersonType.LEGAL);
            Assert.IsTrue(userLegal.Id == matrix.Id);
            Assert.IsTrue(userLegal2.Id == matrix.Id);
            
            Assert.IsTrue(userLegal.Email == userLegal2.Email);
            Assert.IsTrue(userLegal.Tag == userLegal2.Tag);
            Assert.IsTrue(userLegal.CreationDate == userLegal2.CreationDate);
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
        public async Task Test_Users_Save_NaturalSca()
        {
            try
            {
                var john = await GetJohnScaOwner();

                var johnPut = new UserNaturalScaPutDTO
                {
                    LastName = john.LastName + " - CHANGED",
                    Nationality = CountryIso.DK,
                    TermsAndConditionsAccepted = true
                };

                var userSaved = await Api.Users.UpdateNaturalAsync(johnPut, john.Id);
                var userFetched = await Api.Users.GetNaturalScaAsync(john.Id);

                Assert.AreEqual(johnPut.LastName, userSaved.LastName);
                Assert.AreEqual(johnPut.LastName, userFetched.LastName);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_Save_LegalSca()
        {
            try
            {
                var matrix = await GetMatrixScaOwner();

                var matrixPut = new UserLegalScaPutDTO()
                {
                    Name = matrix.Name + " - CHANGED",
                    LegalPersonType = LegalPersonType.SOLETRADER,
                    TermsAndConditionsAccepted = true,
                    LegalRepresentative = new LegalRepresentative()
                    {
                        Email = "john.doe.sca@sample.org",
                        FirstName = "John SCA",
                        LastName = "Doe SCA Review",
                        PhoneNumber = "+33611111111",
                        PhoneNumberCountry = CountryIso.FR,
                        Birthday = new DateTime(1975, 12, 21, 0, 0, 0),
                        Nationality = CountryIso.FR,
                        CountryOfResidence = CountryIso.FR
                    }
                };

                var userSaved = await Api.Users.UpdateLegalAsync(matrixPut, matrix.Id);
                var userFetched = await Api.Users.GetLegalScaAsync(matrix.Id);

                Assert.AreEqual(matrixPut.Name, userSaved.Name);
                Assert.AreEqual(matrixPut.Name, userFetched.Name);
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
                    LastName = john.LastName + " - CHANGED éèęóąśłżźćń",
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
        public async Task Test_Users_Save_Legal()
        {
            try
            {
                var matrix = await this.GetMatrix(newJohn: true);

                var matrixPut = new UserLegalPutDTO
                {
                    LegalRepresentativeLastName = matrix.LegalRepresentativeLastName + " - CHANGED",
                    UserCategory = UserCategory.OWNER
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
                var fi = this.GetFileInfoOfFile(assembly.Location, "TestKycPageFile.png");

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
                var fi = this.GetFileInfoOfFile(assembly.Location, "TestKycPageFile.png");

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
                var fi = this.GetFileInfoOfFile(assembly.Location, "TestKycPageFile.png");
                var bytes = File.ReadAllBytes(fi.FullName);

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
                var transfer = await this.GetNewTransfer();
                var pagination = new Pagination(1, 1);
                var transactions = await this.Api.Users.GetTransactionsAsync(transfer.AuthorId, pagination, new FilterTransactions());

                Assert.IsTrue(transactions.Count > 0);

                // test sorting
                ListPaginated<TransactionDTO> result = null;
                ListPaginated<TransactionDTO> result2 = null;

                pagination = new Pagination(1, 2);
                var sort = new Sort();
                sort.AddField("CreationDate", SortDirection.asc);
                result = await this.Api.Users.GetTransactionsAsync(transfer.AuthorId, pagination, new FilterTransactions(), sort);
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);

                sort = new Sort();
                sort.AddField("CreationDate", SortDirection.desc);
                result2 = await this.Api.Users.GetTransactionsAsync(transfer.AuthorId, pagination, new FilterTransactions(), sort);
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

                Thread.Sleep(2000);
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
                var legalJohn = await GetMatrix(newJohn: true);
                Assert.False(legalJohn.TermsAndConditionsAccepted ?? false);

                var legalJohnAccepted = await GetMatrix(true, true);
                Assert.True(legalJohnAccepted.TermsAndConditionsAccepted ?? true);
                Assert.True(legalJohnAccepted.TermsAndConditionsAcceptedDate.HasValue);

                var updatedJohn = await this.Api.Users.UpdateLegalAsync(new UserLegalPutDTO
                {
                    TermsAndConditionsAccepted = true,
                    UserCategory = UserCategory.OWNER
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
                Assert.IsTrue(e.Message.Contains("The Birthday field is required"), e.Message);
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
                Assert.IsTrue(e.Message.Contains("The CompanyNumber field is required"), e.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_CloseNatural()
        {
            try
            {
                var user = new UserNaturalOwnerPostDTO
                {
                    Email = "john.doe@sample.org",
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = new DateTime(1975, 12, 21, 0, 0, 0),
                    Nationality = CountryIso.FR,
                    CountryOfResidence = CountryIso.FR,
                    Occupation = "programmer",
                    IncomeRange = 3,
                    Address = new Address
                    {
                        AddressLine1 = "Address line 1", AddressLine2 = "Address line 2", City = "City",
                        Country = CountryIso.PL, PostalCode = "11222", Region = "Region"
                    }
                };

                var john = await this.Api.Users.CreateOwnerAsync(user);
                await Api.Users.CloseNaturalAsync(john.Id);
                var closed = await Api.Users.GetAsync(john.Id);
                
                Assert.IsTrue(john.UserStatus == UserStatus.ACTIVE);
                Assert.IsTrue(closed.UserStatus == UserStatus.CLOSED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_CloseLegal()
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

                var matrix = await this.Api.Users.CreateOwnerAsync(user);
                await Api.Users.CloseLegalAsync(matrix.Id);
                var closed = await Api.Users.GetAsync(matrix.Id);
                
                Assert.IsTrue(matrix.UserStatus == UserStatus.ACTIVE);
                Assert.IsTrue(closed.UserStatus == UserStatus.CLOSED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        
        [Test]
        public async Task Test_Users_GetWallets()
        {
            var john = await GetJohn();
            await this.GetJohnsWallet();
            var pagination = new Pagination(1, 1);

            var wallets = await this.Api.Users.GetWalletsAsync(john.Id, pagination);
            Assert.IsTrue(wallets.Count >= 1);
        }
        
        [Test]
        public async Task Test_Users_GetWalletsSca()
        {
            var john = await GetJohn();
            var pagination = new Pagination(1, 1);

            try
            {
                var filter = new FilterWallets
                {
                    ScaContext = "USER_PRESENT"
                };
                await this.Api.Users.GetWalletsAsync(john.Id, pagination, filter);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ResponseException);
                string redirectUrl = ((ResponseException)ex).ResponseError.Data["RedirectUrl"];
                Assert.IsNotNull(redirectUrl);
                Assert.IsNotEmpty(redirectUrl); 
            }
        }
        
        [Test]
        public async Task Test_Users_TransactionsSca()
        {
            var john = await GetJohn();
            var pagination = new Pagination(1, 1);
            var filter = new FilterTransactions
            {
                ScaContext = "USER_PRESENT"
            };
            
            try
            {
                await Api.Users.GetTransactionsAsync(john.Id, pagination, filter);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ResponseException);
                string redirectUrl = ((ResponseException)ex).ResponseError.Data["RedirectUrl"];
                Assert.IsNotNull(redirectUrl);
                Assert.IsNotEmpty(redirectUrl);
            }
        }
        
        [Test]
        public async Task Test_Users_ValidateDataFormat()
        {
            var post = new UserDataFormatValidationPostDTO()
            {
                CompanyNumber = new CompanyNumberValidation
                {
                    CompanyNumber = "AB123456",
                    CountryCode = CountryIso.IT
                }
            };
            var result = await Api.Users.ValidateUserDataFormat(post);
            Assert.IsNotNull(result.CompanyNumber);

            
            try
            {
                post.CompanyNumber.CompanyNumber = "123";
                await Api.Users.ValidateUserDataFormat(post);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ResponseException);
                Assert.Equals(400, ((ResponseException)ex).ResponseStatusCode);
            }
        }
    }
}
