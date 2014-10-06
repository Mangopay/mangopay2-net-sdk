using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Tests
{
    [TestClass]
    public class ApiUsersTest : BaseTest
    {
        [TestMethod]
        public void Test_Users_CreateNatural()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                Assert.IsTrue(john.Id.Length > 0);
                Assert.IsTrue(john.PersonType == PersonType.NATURAL);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_CreateLegal()
        {
            try
            {
                UserLegalDTO matrix = this.GetMatrix();
                Assert.IsTrue(matrix.Id.Length > 0);
                Assert.IsTrue(matrix.PersonType == PersonType.LEGAL);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_CreateLegal_PassesIfRequiredPropsProvided()
        {
            try
            {
                UserLegalPostDTO userPost = new UserLegalPostDTO("email@email.org", "SomeOtherSampleOrg", LegalPersonType.BUSINESS, "RepFName", "RepLName", new DateTime(1975, 12, 21, 0, 0, 0), CountryIso.FR, CountryIso.FR);

                UserLegalDTO userCreated = this.Api.Users.Create(userPost);

                UserLegalDTO userGet = this.Api.Users.GetLegal(userCreated.Id);

                Assert.IsTrue(userCreated.Id.Length > 0, "Created successfully after required props set.");

                AssertEqualInputProps(userCreated, userGet);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_GetNatural()
        {
            try
            {
                UserNaturalDTO john = this.GetNewJohn();

                UserNaturalDTO userNatural = this.Api.Users.GetNatural(john.Id);

                Assert.IsTrue(userNatural.PersonType == PersonType.NATURAL);
                Assert.IsTrue(userNatural.Id == john.Id);

                AssertEqualInputProps(userNatural, john);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_GetNatural_FailsForLegalUser()
        {
            UserLegalDTO matrix = null;
            try
            {
                matrix = this.GetMatrix();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            UserNaturalDTO user = null;
            try
            {
                user = this.Api.Users.GetNatural(matrix.Id);

                Assert.Fail("GetUser() should throw an exception when called with legal user id.");
            }
            catch (ResponseException)
            {
                Assert.IsNull(user);
            }
        }

        [TestMethod]
        public void Test_Users_GetLegal_FailsForNaturalUser()
        {
            UserNaturalDTO john = null;
            try
            {
                john = this.GetJohn();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            UserDTO user = null;
            try
            {
                user = this.Api.Users.GetLegal(john.Id);

                Assert.IsTrue(false, "GetLegal() should throw an exception when called with natural user id");
            }
            catch (ResponseException)
            {
                Assert.IsNull(user);
            }
        }

        [TestMethod]
        public void Test_Users_GetLegal()
        {
            try
            {
                UserLegalDTO matrix = this.GetMatrix();

                UserDTO userLegal = this.Api.Users.GetLegal(matrix.Id);

                AssertEqualInputProps((UserLegalDTO)userLegal, matrix);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_GetAll()
        {
            try
            {
                ListPaginated<UserDTO> users = this.Api.Users.GetAll();

                Assert.IsNotNull(users);
                Assert.IsTrue(users.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_Save_Natural()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();

                UserNaturalPutDTO johnPut = new UserNaturalPutDTO
                {
                    Tag = john.Tag,
                    Email = john.Email,
                    FirstName = john.FirstName,
                    LastName = john.LastName + " - CHANGED",
                    Address = john.Address,
                    Birthday = john.Birthday,
                    Nationality = john.Nationality,
                    CountryOfResidence = john.CountryOfResidence,
                    Occupation = john.Occupation,
                    IncomeRange = john.IncomeRange
                };

                UserNaturalDTO userSaved = this.Api.Users.UpdateNatural(johnPut, john.Id);
                UserNaturalDTO userFetched = this.Api.Users.GetNatural(john.Id);

                Assert.AreEqual(johnPut.LastName, userSaved.LastName);
                AssertEqualInputProps(userSaved, userFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_Save_Natural_NonASCII()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();

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

                UserNaturalDTO userSaved = this.Api.Users.UpdateNatural(johnPut, john.Id);
                UserNaturalDTO userFetched = this.Api.Users.GetNatural(john.Id);

                Assert.AreEqual(johnPut.LastName, userSaved.LastName);
                AssertEqualInputProps(userSaved, userFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_Save_Legal()
        {
            try
            {
                UserLegalDTO matrix = this.GetMatrix();

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

                UserLegalDTO userSaved = this.Api.Users.UpdateLegal(matrixPut, matrix.Id);
                UserLegalDTO userFetched = this.Api.Users.GetLegal(userSaved.Id);

                Assert.AreEqual(matrixPut.LegalRepresentativeLastName, userFetched.LegalRepresentativeLastName);
                AssertEqualInputProps(userSaved, userFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_CreateBankAccount_IBAN()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountDTO account = this.GetJohnsAccount();

                Assert.IsTrue(account.Id.Length > 0);
                Assert.AreEqual(account.UserId, john.Id);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_CreateBankAccount_GB()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountGbPostDTO account = new BankAccountGbPostDTO(john.FirstName + " " + john.LastName, john.Address, "18329068");
                account.SortCode = "306541";

                BankAccountDTO createAccount = this.Api.Users.CreateBankAccountGb(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == BankAccountType.GB);
                Assert.IsTrue(((BankAccountGbDTO)createAccount).AccountNumber == "18329068");
                Assert.IsTrue(((BankAccountGbDTO)createAccount).SortCode == "306541");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_CreateBankAccount_US()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountUsPostDTO account = new BankAccountUsPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "234334789");

                BankAccountDTO createAccount = this.Api.Users.CreateBankAccountUs(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == BankAccountType.US);
                Assert.IsTrue(((BankAccountUsDTO)createAccount).AccountNumber == "234234234234");
                Assert.IsTrue(((BankAccountUsDTO)createAccount).ABA == "234334789");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_CreateBankAccount_CA()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountCaPostDTO account = new BankAccountCaPostDTO(john.FirstName + " " + john.LastName, john.Address, "TestBankName", "123", "12345", "234234234234");

                BankAccountDTO createAccount = this.Api.Users.CreateBankAccountCa(john.Id, account);

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

        [TestMethod]
        public void Test_Users_CreateBankAccount_OTHER()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountOtherPostDTO account = new BankAccountOtherPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234", "BINAADADXXX");
                account.Type = BankAccountType.OTHER;
                account.Country = CountryIso.FR;

                BankAccountDTO createAccount = this.Api.Users.CreateBankAccountOther(john.Id, account);

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

        [TestMethod]
        public void Test_Users_CreateBankAccount()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountIbanDTO account = this.GetJohnsAccount();

                Assert.IsTrue(account.Id.Length > 0);
                Assert.IsTrue(account.UserId == (john.Id));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_BankAccount()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountIbanDTO account = this.GetJohnsAccount();

                BankAccountIbanDTO accountFetched = this.Api.Users.GetBankAccountIban(john.Id, account.Id);

                AssertEqualInputProps(account, accountFetched);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_BankAccounts()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                BankAccountIbanDTO account = this.GetJohnsAccount();
                Pagination pagination = new Pagination(1, 12);

                ListPaginated<BankAccountDTO> list = this.Api.Users.GetBankAccounts(john.Id, pagination);

                int listIndex;
                for (listIndex = 0; listIndex < list.Count; listIndex++)
                {
                    if (list[listIndex].Id == account.Id) break;
                }

                Assert.IsTrue(list[listIndex] is BankAccountDTO);

                BankAccountIbanDTO castedBankAccount = this.Api.Users.GetBankAccountIban(john.Id, list[listIndex].Id);

                Assert.IsTrue(account.Id == castedBankAccount.Id);
                AssertEqualInputProps(account, castedBankAccount);
                Assert.IsTrue(pagination.Page == 1);
                Assert.IsTrue(pagination.ItemsPerPage == 12);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        public void Test_Users_CreateKycDocument()
        {
            try
            {
                KycDocumentDTO kycDocument = this.GetJohnsKycDocument();

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

        [TestMethod]
        public void Test_Users_SaveKycDocument()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                KycDocumentDTO kycDocument = this.GetJohnsKycDocument();

                KycDocumentPutDTO kycDocumentPut = new KycDocumentPutDTO 
                {
                    Status = KycStatus.VALIDATION_ASKED
                };

                KycDocumentDTO result = this.Api.Users.UpdateKycDocument(john.Id, kycDocumentPut, kycDocument.Id);

                Assert.IsNotNull(result);
                Assert.IsTrue(kycDocument.Type == result.Type);
                Assert.IsTrue(result.Status == KycStatus.VALIDATION_ASKED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_GetKycDocument()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                KycDocumentDTO kycDocument = this.GetJohnsKycDocument();

                KycDocumentDTO result = this.Api.Users.GetKycDocument(john.Id, kycDocument.Id);

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

        [TestMethod]
        public void Test_Users_CreateKycPage()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                KycDocumentDTO kycDocument = this.GetNewKycDocument();

                this.Api.Users.CreateKycPage(john.Id, kycDocument.Id, Encoding.UTF8.GetBytes("Test KYC page"));

                String filePath = "TestKycPageFile.txt";
                this.Api.Users.CreateKycPage(john.Id, kycDocument.Id, filePath);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_AllCards()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                PayInCardDirectDTO payIn = this.GetNewPayInCardDirect();
                Pagination pagination = new Pagination(1, 1);
                CardDTO card = this.Api.Cards.Get(payIn.CardId);
                ListPaginated<CardDTO> cards = this.Api.Users.GetCards(john.Id, pagination);

                Assert.IsTrue(cards.Count == 1);
                Assert.IsTrue(cards[0].CardType != CardType.NotSpecified);
                AssertEqualInputProps(cards[0], card);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_Transactions()
        {
            try
            {
                UserNaturalDTO john = this.GetJohn();
                TransferDTO transfer = this.GetNewTransfer();
                Pagination pagination = new Pagination(1, 1);

                ListPaginated<TransactionDTO> transactions = this.Api.Users.GetTransactions(john.Id, pagination, new FilterTransactions());

                Assert.IsTrue(transactions.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_GetKycDocuments()
        {
            ListPaginated<KycDocumentDTO> result = null;

            UserNaturalDTO john = this.GetJohn();
            KycDocumentDTO kycDocument = this.GetJohnsKycDocument();

            try
            {
                result = this.Api.Users.GetKycDocuments(john.Id, null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
