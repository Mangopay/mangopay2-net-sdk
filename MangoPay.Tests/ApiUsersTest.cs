using MangoPay.Core;
using MangoPay.Entities;
using MangoPay.Entities.Dependend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Tests
{
    [TestClass]
    public class ApiUsersTest : BaseTest
    {
        [TestMethod]
        public void Test_Users_CreateNatural()
        {
            try
            {
                UserNatural john = this.GetJohn();
                Assert.IsTrue(john.Id.Length > 0);
                Assert.IsTrue(john.PersonType == User.Types.Natural);
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
                UserLegal matrix = this.GetMatrix();
                Assert.IsTrue(matrix.Id.Length > 0);
                Assert.IsTrue(matrix.PersonType == User.Types.Legal);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_CreateLegal_FailsIfRequiredPropsNotProvided()
        {
            UserLegal user = new UserLegal();

            User ret = null;

            try
            {
                ret = this.Api.Users.Create(user);

                Assert.Fail("CreateLegal() should throw an exception when required props are not provided.");
            }
            catch (ResponseException ex)
            {
                Assert.IsNull(ret);
            }
        }

        [TestMethod]
        public void Test_Users_CreateLegal_PassesIfRequiredPropsProvided()
        {
            try
            {
                UserLegal user = new UserLegal();
                user.Name = "SomeOtherSampleOrg";
                user.LegalPersonType = "BUSINESS";
                user.LegalRepresentativeFirstName = "RepFName";
                user.LegalRepresentativeLastName = "RepLName";
                user.LegalRepresentativeBirthday = (long)(new DateTime(1975, 12, 21, 0, 0, 0) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                user.LegalRepresentativeNationality = "FR";
                user.LegalRepresentativeCountryOfResidence = "FR";
                user.Email = "email@email.org";

                User ret = null;

                ret = this.Api.Users.Create(user);

                Assert.IsTrue(ret.Id.Length > 0, "Created successfully after required props set.");

                AssertEqualInputProps(user, ret);
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
                UserNatural john = this.GetJohn();

                User user1 = this.Api.Users.Get(john.Id);
                UserNatural user2 = this.Api.Users.GetNatural(john.Id);

                Assert.IsTrue(user1.PersonType == (User.Types.Natural));
                Assert.IsTrue(user1.Id == (john.Id));
                Assert.IsTrue(user2.PersonType == (User.Types.Natural));
                Assert.IsTrue(user2.Id == (john.Id));

                AssertEqualInputProps(user1, john);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_Users_GetNatural_FailsForLegalUser()
        {
            UserLegal matrix = null;
            try
            {
                matrix = this.GetMatrix();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            UserNatural user = null;
            try
            {
                user = this.Api.Users.GetNatural(matrix.Id);

                Assert.Fail("GetUser() should throw an exception when called with legal user id.");
            }
            catch (ResponseException ex)
            {
                Assert.IsNull(user);
            }
        }

        [TestMethod]
        public void Test_Users_GetLegal_FailsForNaturalUser()
        {
            UserNatural john = null;
            try
            {
                john = this.GetJohn();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            User user = null;
            try
            {
                user = this.Api.Users.GetLegal(john.Id);

                Assert.IsTrue(false, "GetLegal() should throw an exception when called with natural user id");
            }
            catch (ResponseException ex)
            {
                Assert.IsNull(user);
            }
        }

        [TestMethod]
        public void Test_Users_GetLegal()
        {
            try
            {
                UserLegal matrix = this.GetMatrix();

                User user1 = this.Api.Users.Get(matrix.Id);
                User user2 = this.Api.Users.GetLegal(matrix.Id);

                AssertEqualInputProps((UserLegal)user1, matrix);
                AssertEqualInputProps((UserLegal)user2, matrix);
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
                UserNatural john = this.GetJohn();
                john.LastName += " - CHANGED";

                User userSaved = this.Api.Users.Update(john);
                User userFetched = this.Api.Users.Get(john.Id);

                AssertEqualInputProps(john, userSaved);
                AssertEqualInputProps(john, userFetched);
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
                UserNatural john = this.GetJohn();
                john.LastName += " - CHANGED (éèęóąśłżźćń)";

                User userSaved = this.Api.Users.Update(john);
                User userFetched = this.Api.Users.Get(john.Id);

                AssertEqualInputProps(john, userSaved);
                AssertEqualInputProps(john, userFetched);
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
                UserLegal matrix = this.GetMatrix();
                matrix.LegalRepresentativeLastName += " - CHANGED";

                User userSaved = this.Api.Users.Update(matrix);
                User userFetched = this.Api.Users.Get(matrix.Id);

                AssertEqualInputProps(userSaved, matrix);
                AssertEqualInputProps(userFetched, matrix);
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
                UserNatural john = this.GetJohn();
                BankAccount account = this.GetJohnsAccount();

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
                UserNatural john = this.GetJohn();
                BankAccount account = new BankAccount();
                account.OwnerName = john.FirstName + " " + john.LastName;
                account.OwnerAddress = john.Address;
                account.Details = new BankAccountDetailsGB();
                ((BankAccountDetailsGB)account.Details).AccountNumber = "18329068";
                ((BankAccountDetailsGB)account.Details).SortCode = "306541";

                BankAccount createAccount = this.Api.Users.CreateBankAccount(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == ("GB"));
                Assert.IsTrue(((BankAccountDetailsGB)createAccount.Details).AccountNumber == ("18329068"));
                Assert.IsTrue(((BankAccountDetailsGB)createAccount.Details).SortCode == ("306541"));
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
                UserNatural john = this.GetJohn();
                BankAccount account = new BankAccount();
                account.OwnerName = john.FirstName + " " + john.LastName;
                account.OwnerAddress = john.Address;
                account.Details = new BankAccountDetailsUS();
                ((BankAccountDetailsUS)account.Details).AccountNumber = "234234234234";
                ((BankAccountDetailsUS)account.Details).ABA = "234334789";

                BankAccount createAccount = this.Api.Users.CreateBankAccount(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == ("US"));
                Assert.IsTrue(((BankAccountDetailsUS)createAccount.Details).AccountNumber == ("234234234234"));
                Assert.IsTrue(((BankAccountDetailsUS)createAccount.Details).ABA == ("234334789"));
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
                UserNatural john = this.GetJohn();
                BankAccount account = new BankAccount();
                account.OwnerName = john.FirstName + " " + john.LastName;
                account.OwnerAddress = john.Address;
                account.Details = new BankAccountDetailsCA();
                ((BankAccountDetailsCA)account.Details).BankName = "TestBankName";
                ((BankAccountDetailsCA)account.Details).BranchCode = "12345";
                ((BankAccountDetailsCA)account.Details).AccountNumber = "234234234234";
                ((BankAccountDetailsCA)account.Details).InstitutionNumber = "123";

                BankAccount createAccount = this.Api.Users.CreateBankAccount(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == ("CA"));
                Assert.IsTrue(((BankAccountDetailsCA)createAccount.Details).AccountNumber == ("234234234234"));
                Assert.IsTrue(((BankAccountDetailsCA)createAccount.Details).BankName == ("TestBankName"));
                Assert.IsTrue(((BankAccountDetailsCA)createAccount.Details).BranchCode == ("12345"));
                Assert.IsTrue(((BankAccountDetailsCA)createAccount.Details).InstitutionNumber == ("123"));
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
                UserNatural john = this.GetJohn();
                BankAccount account = new BankAccount();
                account.OwnerName = john.FirstName + " " + john.LastName;
                account.OwnerAddress = john.Address;
                account.Details = new BankAccountDetailsOTHER();
                ((BankAccountDetailsOTHER)account.Details).Type = "OTHER";
                ((BankAccountDetailsOTHER)account.Details).Country = "FR";
                ((BankAccountDetailsOTHER)account.Details).AccountNumber = "234234234234";
                ((BankAccountDetailsOTHER)account.Details).BIC = "BINAADADXXX";

                BankAccount createAccount = this.Api.Users.CreateBankAccount(john.Id, account);

                Assert.IsTrue(createAccount.Id.Length > 0);
                Assert.IsTrue(createAccount.UserId == (john.Id));
                Assert.IsTrue(createAccount.Type == ("OTHER"));
                Assert.IsTrue(((BankAccountDetailsOTHER)createAccount.Details).Type == ("OTHER"));
                Assert.IsTrue(((BankAccountDetailsOTHER)createAccount.Details).Country == ("FR"));
                Assert.IsTrue(((BankAccountDetailsOTHER)createAccount.Details).AccountNumber == ("234234234234"));
                Assert.IsTrue(((BankAccountDetailsOTHER)createAccount.Details).BIC == ("BINAADADXXX"));
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
                UserNatural john = this.GetJohn();
                BankAccount account = this.GetJohnsAccount();

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
                UserNatural john = this.GetJohn();
                BankAccount account = this.GetJohnsAccount();

                BankAccount accountFetched = this.Api.Users.GetBankAccount(john.Id, account.Id);

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
                UserNatural john = this.GetJohn();
                BankAccount account = this.GetJohnsAccount();
                Pagination pagination = new Pagination(1, 12);

                List<BankAccount> list = this.Api.Users.GetBankAccounts(john.Id, pagination);

                Assert.IsTrue(list[0] is BankAccount);
                Assert.IsTrue(account.Id == list[0].Id);
                AssertEqualInputProps(account, list[0]);
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
                KycDocument kycDocument = this.GetJohnsKycDocument();

                Assert.IsNotNull(kycDocument);
                Assert.IsTrue(kycDocument.Id.Length > 0);
                Assert.IsTrue(kycDocument.Status == "CREATED");
                Assert.IsTrue(kycDocument.Type == "IDENTITY_PROOF");
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
                UserNatural john = this.GetJohn();
                KycDocument kycDocument = this.GetJohnsKycDocument();

                kycDocument.Status = "VALIDATION_ASKED";

                KycDocument result = this.Api.Users.UpdateKycDocument(john.Id, kycDocument);

                Assert.IsNotNull(result);
                Assert.IsTrue(kycDocument.Type == (result.Type));
                Assert.IsTrue(kycDocument.Status == ("VALIDATION_ASKED"));
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
                UserNatural john = this.GetJohn();
                KycDocument kycDocument = this.GetJohnsKycDocument();

                KycDocument result = this.Api.Users.GetKycDocument(john.Id, kycDocument.Id);

                Assert.IsNotNull(result);
                Assert.IsTrue(kycDocument.Id == (result.Id));
                Assert.IsTrue(kycDocument.Type == (result.Type));
                Assert.IsTrue(kycDocument.Status == (result.Status));
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
                UserNatural john = this.GetJohn();
                KycDocument kycDocument = this.GetJohnsKycDocument();

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
                UserNatural john = this.GetJohn();
                PayIn payIn = this.GetNewPayInCardDirect();
                Pagination pagination = new Pagination(1, 1);
                Card card = this.Api.Cards.Get(((PayInPaymentDetailsCard)payIn.PaymentDetails).CardId);
                List<Card> cards = this.Api.Users.GetCards(john.Id, pagination);

                Assert.IsTrue(cards.Count == 1);
                Assert.IsTrue(cards[0].CardType != null);
                Assert.IsTrue(cards[0].Currency != null);
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
                UserNatural john = this.GetJohn();
                Transfer transfer = this.GetNewTransfer();
                Pagination pagination = new Pagination(1, 1);

                List<Transaction> transactions = this.Api.Users.GetTransactions(john.Id, pagination, new FilterTransactions());

                Assert.IsTrue(transactions.Count > 0);
                Assert.IsTrue(transactions[0].Type != null);
                Assert.IsTrue(transactions[0].Status != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
