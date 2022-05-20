using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ApiIdempotencyTest : BaseTest
    {
        /*[Test]
		public void Test_Idempotency_HooksCreate()
		{
			string key = DateTime.Now.Ticks.ToString();
			HookPostDTO hook = new HookPostDTO("http://test.com", EventType.PAYIN_NORMAL_FAILED);
			Api.Hooks.Create(key, hook);

			var result = Api.Idempotent.Get(key);

			Assert.IsInstanceOf<HookDTO>(result.Resource);
		}*/

        [Test]
        public async Task Test_Idempotency_CardRegistrationCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            await GetNewPayInCardDirect(null, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<CardRegistrationDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_ClientCreateBankwireDirect()
        {
            var key = DateTime.Now.Ticks.ToString();
            var bankwireDirectPost =
                new ClientBankWireDirectPostDTO("CREDIT_EUR", new Money {Amount = 1000, Currency = CurrencyIso.EUR});
            await Api.Clients.CreateBankWireDirectAsync(bankwireDirectPost, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<PayInBankWireDirectDTO>(result.Resource);
        }
        /*
		[Test]
		public void Test_Idempotency_DisputesDocumentCreate()
		{
			string key = DateTime.Now.Ticks.ToString();
			Sort sort = new Sort();
			sort.AddField("CreationDate", SortDirection.desc);
			var clientDisputes = Api.Disputes.GetAll(new Pagination(1, 100), null, sort);
			if (clientDisputes == null || clientDisputes.Count == 0)
				Assert.Fail("INITIALIZATION FAILURE - cannot test disputes");
			DisputeDTO dispute = clientDisputes.FirstOrDefault(x => x.Status == DisputeStatus.PENDING_CLIENT_ACTION || x.Status == DisputeStatus.REOPENED_PENDING_CLIENT_ACTION);
			if (dispute == null)
				Assert.Fail("Cannot test creating dispute document because there's no dispute with expected status in the disputes list.");
			DisputeDocumentPostDTO documentPost = new DisputeDocumentPostDTO(DisputeDocumentType.DELIVERY_PROOF);
			Api.Disputes.CreateDisputeDocument(key, documentPost, dispute.Id);

			var result = Api.Idempotent.Get(key);

			Assert.IsInstanceOf<DisputeDocumentDTO>(result.Resource);
		}*/

       /* [Test]
        public void Test_Idempotency_DisputesRepudiationCreateSettlement()
        {
            string key = DateTime.Now.Ticks.ToString();
            Sort sort = new Sort();
            sort.AddField("CreationDate", SortDirection.desc);
            var clientDisputes = Api.Disputes.GetAll(new Pagination(1, 100), null, sort);
            if (clientDisputes == null || clientDisputes.Count == 0)
                Assert.Fail("INITIALIZATION FAILURE - cannot test disputes");
            DisputeDTO dispute = clientDisputes.FirstOrDefault(x =>
                x.Status == DisputeStatus.CLOSED && x.DisputeType == DisputeType.NOT_CONTESTABLE);
            if (dispute == null)
                Assert.Fail(
                    "Cannot test creating settlement transfer because there's no closed disputes in the disputes list.");
            string repudiationId = Api.Disputes.GetTransactions(dispute.Id, new Pagination(1, 1), null)[0].Id;
            var repudiation = Api.Disputes.GetRepudiation(repudiationId);
            SettlementTransferPostDTO post = new SettlementTransferPostDTO(repudiation.AuthorId,
                new Money {Currency = CurrencyIso.EUR, Amount = 1}, new Money {Currency = CurrencyIso.EUR, Amount = 0});
            Api.Disputes.CreateSettlementTransfer(key, post, repudiationId);

            var result = Api.Idempotent.Get(key);

            Assert.IsInstanceOf<SettlementDTO>(result.Resource);
        }
*/
        [Test]
        public async Task Test_Idempotency_MandateCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var bankAccount = await this.GetJohnsAccount();
            var returnUrl = "http://test.test";
            var mandatePost = new MandatePostDTO(bankAccount.Id, CultureCode.EN, returnUrl);
            await Api.Mandates.CreateAsync(mandatePost, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<MandateDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsBankwireDirectCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var wallet = await this.GetJohnsWallet();
            var user = await this.GetJohn();
            var payIn = new PayInBankWireDirectPostDTO(user.Id, wallet.Id,
                new Money {Amount = 100, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR});
            payIn.CreditedWalletId = wallet.Id;
            payIn.AuthorId = user.Id;
            await Api.PayIns.CreateBankWireDirectAsync(payIn, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<PayInBankWireDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsCardDirectCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var wallet =
                new WalletPostDTO(new List<string> {john.Id}, "WALLET IN EUR WITH MONEY", CurrencyIso.EUR);
            var johnsWallet = await this.Api.Wallets.CreateAsync(wallet);
            var cardRegistrationPost =
                new CardRegistrationPostDTO(johnsWallet.Owners[0], CurrencyIso.EUR);
            var cardRegistration = await this.Api.CardRegistrations.CreateAsync(cardRegistrationPost);
            var cardRegistrationPut = new CardRegistrationPutDTO();
            cardRegistrationPut.RegistrationData = await this.GetPaylineCorrectRegistartionData(cardRegistration);
            cardRegistration = await this.Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);
            var card = await this.Api.Cards.GetAsync(cardRegistration.CardId);
            var payIn = new PayInCardDirectPostDTO(cardRegistration.UserId, cardRegistration.UserId,
                new Money {Amount = 1000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR},
                johnsWallet.Id, "http://test.com", card.Id)
            {
                Requested3DSVersion = "V1",
                CardType = card.CardType
            };
            await Api.PayIns.CreateCardDirectAsync(payIn, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<PayInCardDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsCardWebCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var wallet = await this.GetJohnsWallet();
            var user = await this.GetJohn();
            var payIn = new PayInCardWebPostDTO(user.Id,
                new Money {Amount = 1000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, wallet.Id, "https://test.com", CultureCode.FR,
                CardType.CB_VISA_MASTERCARD);
            await Api.PayIns.CreateCardWebAsync(payIn, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<PayInCardWebDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsCreateRefunds()
        {
            var key = DateTime.Now.Ticks.ToString();
            var payIn = await this.GetNewPayInCardDirect();
            await this.GetNewRefundForPayIn(payIn, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<RefundDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsDirectDebitCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var wallet = await this.GetJohnsWallet();
            var user = await this.GetJohn();
            var payIn = new PayInDirectDebitPostDTO(user.Id,
                new Money {Amount = 100, Currency = CurrencyIso.EUR},
                new Money {Amount = 10, Currency = CurrencyIso.EUR}, wallet.Id, "http://www.mysite.com/returnURL/",
                CultureCode.FR, DirectDebitType.GIROPAY)
            {
                TemplateURLOptions = new TemplateURLOptions {PAYLINE = "https://www.maysite.com/payline_template/"},
                Tag = "DirectDebit test tag"
            };
            await Api.PayIns.CreateDirectDebitAsync(payIn, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<PayInDirectDebitDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsMandateDirectDebitCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var wallet = await this.GetJohnsWallet();
            var user = await this.GetJohn();
            var bankAccount = await this.GetJohnsAccount();
            var returnUrl = "http://test.test";
            var mandatePost = new MandatePostDTO(bankAccount.Id, CultureCode.EN, returnUrl);
            var mandate = await this.Api.Mandates.CreateAsync(mandatePost);

            /*	
			 *	! IMPORTANT NOTE !
			 *	
			 *	In order to make this test pass, at this place you have to set a breakpoint,
			 *	navigate to URL the mandate.RedirectURL property points to and click "CONFIRM" button.
			 * 
			 */
            var payIn = new PayInMandateDirectPostDTO(user.Id,
                new Money {Amount = 100, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, wallet.Id, "http://test.test", mandate.Id);
            await Api.PayIns.CreateMandateDirectDebitAsync(payIn, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<PayInMandateDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsPreauthorizedDirectCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var okCode = "200";
            var cardPreAuthorization = await this.GetJohnsCardPreAuthorization();
            var wallet = await this.GetJohnsWalletWithMoney();
            var user = await this.GetJohn();
            var payIn = new PayInPreauthorizedDirectPostDTO(user.Id,
                new Money {Amount = 10000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, wallet.Id, cardPreAuthorization.Id)
                {
                    SecureModeReturnURL = "http://test.com"
                };
            await Api.PayIns.CreatePreauthorizedDirectAsync(payIn, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.AreEqual(result.StatusCode, okCode);
            Assert.IsInstanceOf<PayInPreauthorizedDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayoutsBankwireCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var wallet = await this.GetJohnsWallet();
            var user = await this.GetJohn();
            var account = await this.GetJohnsAccount();
            var payOut = new PayOutBankWirePostDTO(user.Id, wallet.Id, 
                new Money {Amount = 10, Currency = CurrencyIso.EUR}, new Money {Amount = 5, Currency = CurrencyIso.EUR},
                account.Id, "Johns bank wire ref", PayoutModeRequested.STANDARD)
            {
                Tag = "DefaultTag",
                CreditedUserId = user.Id
            };
            await Api.PayOuts.CreateBankWireAsync(payOut, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<PayOutBankWireDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PreauthorizationCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            await GetJohnsCardPreAuthorization(key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<CardPreAuthorizationDTO>(result.Resource);
            Assert.AreEqual(result.StatusCode, "200");
        }

        [Test]
        public async Task Test_Idempotency_TransfersCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var walletWithMoney = await this.GetJohnsWalletWithMoney();
            var user = await this.GetJohn();
            var walletPost =
                new WalletPostDTO(new List<string> {user.Id}, "WALLET IN EUR FOR TRANSFER", CurrencyIso.EUR);
            var wallet = await this.Api.Wallets.CreateAsync(walletPost);
            var transfer = new TransferPostDTO(user.Id, user.Id,
                new Money {Amount = 100, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, walletWithMoney.Id, wallet.Id)
            {
                Tag = "DefaultTag"
            };
            await Api.Transfers.CreateAsync(transfer, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<TransferDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_TransfersCreateRefunds()
        {
            var key = DateTime.Now.Ticks.ToString();
            var transfer = await this.GetNewTransfer();
            var user = await this.GetJohn();
            var refund = new RefundTransferPostDTO(user.Id);
            await Api.Transfers.CreateRefundAsync(transfer.Id, refund, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<RefundDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UboDeclarationCreate()
        {
            var key = DateTime.Now.Ticks.ToString();

            var userLegal = await Api.Users.CreateOwnerAsync(CreateUserLegalPost());

            await Api.UboDeclarations.CreateUboDeclarationAsync(userLegal.Id, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<UboDeclarationDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsCa()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountCaPostDTO(john.FirstName + " " + john.LastName, john.Address, "TestBankName",
                "123", "12345", "234234234234");
            await Api.Users.CreateBankAccountCaAsync(john.Id, account, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<BankAccountCaDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsGb()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountGbPostDTO(john.FirstName + " " + john.LastName, john.Address, "63956474")
                {
                    SortCode = "200000"
                };
            await Api.Users.CreateBankAccountGbAsync(john.Id, account, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<BankAccountGbDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsIban()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountIbanPostDTO(john.FirstName + " " + john.LastName, john.Address,
                "FR7630004000031234567890143")
            {
                UserId = john.Id,
                BIC = "BNPAFRPP"
            };
            await Api.Users.CreateBankAccountIbanAsync(john.Id, account, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<BankAccountIbanDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsOther()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountOtherPostDTO(john.FirstName + " " + john.LastName, john.Address,
                "234234234234", "BINAADADXXX")
            {
                Type = BankAccountType.OTHER,
                Country = CountryIso.FR
            };
            await Api.Users.CreateBankAccountOtherAsync(john.Id, account, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<BankAccountOtherDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsUs()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountUsPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234",
                "234334789");
            await Api.Users.CreateBankAccountUsAsync(john.Id, account, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<BankAccountUsDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateKycDocument()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await GetJohn();
            await Api.Users.CreateKycDocumentAsync(john.Id, KycDocumentType.IDENTITY_PROOF, idempotentKey: key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<KycDocumentDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateLegals()
        {
            var key = DateTime.Now.Ticks.ToString();
            var userPost = new UserLegalPayerPostDTO
            {
                Email = "email@email.org",
                Name = "SomeOtherSampleOrg",
                LegalPersonType = LegalPersonType.BUSINESS,
                LegalRepresentativeFirstName = "RepFName",
                LegalRepresentativeLastName = "RepLName",
                TermsAndConditionsAccepted = true,
                UserCategory = UserCategory.PAYER
            };
            await Api.Users.CreatePayerAsync(userPost, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<UserLegalDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateNaturals()
        {
            var key = DateTime.Now.Ticks.ToString();
            var user = new UserNaturalOwnerPostDTO
            {
                Email = "john.doe@sample.org",
                FirstName = "John",
                LastName = "Doe",
                Birthday = new DateTime(1975, 12, 21, 0, 0, 0),
                CountryOfResidence = CountryIso.FR,
                Nationality = CountryIso.FR,
                Occupation = "programmer",
                IncomeRange = 3,
                Address = new Address
                {
                    AddressLine1 = "Address line 1", AddressLine2 = "Address line 2", City = "City",
                    Country = CountryIso.PL, PostalCode = "11222", Region = "Region"
                },
                TermsAndConditionsAccepted = true,
                UserCategory = UserCategory.OWNER
            };

            await Api.Users.CreateOwnerAsync(user, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<UserNaturalDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_WalletsCreate()
        {
            var key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var wallet = new WalletPostDTO(new List<string> {john.Id}, "WALLET IN EUR", CurrencyIso.EUR);
            await Api.Wallets.CreateAsync(wallet, key);

            var result = await Api.Idempotent.GetAsync(key);

            Assert.IsInstanceOf<WalletDTO>(result.Resource);
        }
    }
}
