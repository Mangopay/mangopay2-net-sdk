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

			var result = Api.Idempotency.Get(key);

			Assert.IsInstanceOf<HookDTO>(result.Resource);
		}*/

        [Test]
        public async Task Test_Idempotency_CardRegistrationCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            await GetNewPayInCardDirect(null, key);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<CardRegistrationDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_ClientCreateBankwireDirect()
        {
            string key = DateTime.Now.Ticks.ToString();
            var bankwireDirectPost =
                new ClientBankWireDirectPostDTO("CREDIT_EUR", new Money {Amount = 1000, Currency = CurrencyIso.EUR});
            await Api.Clients.CreateBankWireDirectAsync(key, bankwireDirectPost);

            var result = await Api.Idempotency.GetAsync(key);

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

			var result = Api.Idempotency.Get(key);

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

            var result = Api.Idempotency.Get(key);

            Assert.IsInstanceOf<SettlementDTO>(result.Resource);
        }
*/
        [Test]
        public async Task Test_Idempotency_MandateCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            var bankAccount = await this.GetJohnsAccount();
            string returnUrl = "http://test.test";
            MandatePostDTO mandatePost = new MandatePostDTO(bankAccount.Id, CultureCode.EN, returnUrl);
            await Api.Mandates.CreateAsync(key, mandatePost);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<MandateDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsBankwireDirectCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            WalletDTO wallet = await this.GetJohnsWallet();
            UserNaturalDTO user = await this.GetJohn();
            PayInBankWireDirectPostDTO payIn = new PayInBankWireDirectPostDTO(user.Id, wallet.Id,
                new Money {Amount = 10000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR});
            payIn.CreditedWalletId = wallet.Id;
            payIn.AuthorId = user.Id;
            await Api.PayIns.CreateBankWireDirectAsync(key, payIn);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<PayInBankWireDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsCardDirectCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            UserNaturalDTO john = await this.GetJohn();
            WalletPostDTO wallet =
                new WalletPostDTO(new List<string> {john.Id}, "WALLET IN EUR WITH MONEY", CurrencyIso.EUR);
            var johnsWallet = await this.Api.Wallets.CreateAsync(wallet);
            CardRegistrationPostDTO cardRegistrationPost =
                new CardRegistrationPostDTO(johnsWallet.Owners[0], CurrencyIso.EUR);
            CardRegistrationDTO cardRegistration = await this.Api.CardRegistrations.CreateAsync(cardRegistrationPost);
            CardRegistrationPutDTO cardRegistrationPut = new CardRegistrationPutDTO();
            cardRegistrationPut.RegistrationData = await this.GetPaylineCorrectRegistartionData(cardRegistration);
            cardRegistration = await this.Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);
            CardDTO card = await this.Api.Cards.GetAsync(cardRegistration.CardId);
            PayInCardDirectPostDTO payIn = new PayInCardDirectPostDTO(cardRegistration.UserId, cardRegistration.UserId,
                new Money {Amount = 1000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR},
                johnsWallet.Id, "http://test.com", card.Id);
            payIn.Requested3DSVersion = "V1";
            payIn.CardType = card.CardType;
            await Api.PayIns.CreateCardDirectAsync(key, payIn);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<PayInCardDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsCardWebCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            WalletDTO wallet = await this.GetJohnsWallet();
            UserNaturalDTO user = await this.GetJohn();
            PayInCardWebPostDTO payIn = new PayInCardWebPostDTO(user.Id,
                new Money {Amount = 1000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, wallet.Id, "https://test.com", CultureCode.FR,
                CardType.CB_VISA_MASTERCARD);
            await Api.PayIns.CreateCardWebAsync(key, payIn);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<PayInCardWebDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsCreateRefunds()
        {
            string key = DateTime.Now.Ticks.ToString();
            PayInDTO payIn = await this.GetNewPayInCardDirect();
            RefundDTO refund = await this.GetNewRefundForPayIn(payIn, key);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<RefundDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsDirectDebitCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            WalletDTO wallet = await this.GetJohnsWallet();
            UserNaturalDTO user = await this.GetJohn();
            PayInDirectDebitPostDTO payIn = new PayInDirectDebitPostDTO(user.Id,
                new Money {Amount = 10000, Currency = CurrencyIso.EUR},
                new Money {Amount = 100, Currency = CurrencyIso.EUR}, wallet.Id, "http://www.mysite.com/returnURL/",
                CultureCode.FR, DirectDebitType.GIROPAY);
            payIn.TemplateURLOptions = new TemplateURLOptions {PAYLINE = "https://www.maysite.com/payline_template/"};
            payIn.Tag = "DirectDebit test tag";
            await Api.PayIns.CreateDirectDebitAsync(key, payIn);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<PayInDirectDebitDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsMandateDirectDebitCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            WalletDTO wallet = await this.GetJohnsWallet();
            UserNaturalDTO user = await this.GetJohn();
            var bankAccount = await this.GetJohnsAccount();
            string returnUrl = "http://test.test";
            MandatePostDTO mandatePost = new MandatePostDTO(bankAccount.Id, CultureCode.EN, returnUrl);
            MandateDTO mandate = await this.Api.Mandates.CreateAsync(mandatePost);

            /*	
			 *	! IMPORTANT NOTE !
			 *	
			 *	In order to make this test pass, at this place you have to set a breakpoint,
			 *	navigate to URL the mandate.RedirectURL property points to and click "CONFIRM" button.
			 * 
			 */
            PayInMandateDirectPostDTO payIn = new PayInMandateDirectPostDTO(user.Id,
                new Money {Amount = 10000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, wallet.Id, "http://test.test", mandate.Id);
            await Api.PayIns.CreateMandateDirectDebitAsync(key, payIn);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<PayInMandateDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayinsPreauthorizedDirectCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            string okCode = "200";
            CardPreAuthorizationDTO cardPreAuthorization = await this.GetJohnsCardPreAuthorization();
            WalletDTO wallet = await this.GetJohnsWalletWithMoney();
            UserNaturalDTO user = await this.GetJohn();
            PayInPreauthorizedDirectPostDTO payIn = new PayInPreauthorizedDirectPostDTO(user.Id,
                new Money {Amount = 10000, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, wallet.Id, cardPreAuthorization.Id);
            payIn.SecureModeReturnURL = "http://test.com";
            await Api.PayIns.CreatePreauthorizedDirectAsync(key, payIn);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.AreEqual(result.StatusCode, okCode);
            Assert.IsInstanceOf<PayInPreauthorizedDirectDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PayoutsBankwireCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            WalletDTO wallet = await this.GetJohnsWallet();
            UserNaturalDTO user = await this.GetJohn();
            BankAccountDTO account = await this.GetJohnsAccount();
            PayOutBankWirePostDTO payOut = new PayOutBankWirePostDTO(user.Id, wallet.Id,
                new Money {Amount = 10, Currency = CurrencyIso.EUR}, new Money {Amount = 5, Currency = CurrencyIso.EUR},
                account.Id, "Johns bank wire ref", "STANDARD");
            payOut.Tag = "DefaultTag";
            payOut.CreditedUserId = user.Id;
            await Api.PayOuts.CreateBankWireAsync(key, payOut);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<PayOutBankWireDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_PreauthorizationCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            await GetJohnsCardPreAuthorization(key);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<CardPreAuthorizationDTO>(result.Resource);
            Assert.AreEqual(result.StatusCode, "200");
        }

        [Test]
        public async Task Test_Idempotency_TransfersCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            WalletDTO walletWithMoney = await this.GetJohnsWalletWithMoney();
            UserNaturalDTO user = await this.GetJohn();
            WalletPostDTO walletPost =
                new WalletPostDTO(new List<string> {user.Id}, "WALLET IN EUR FOR TRANSFER", CurrencyIso.EUR);
            WalletDTO wallet = await this.Api.Wallets.CreateAsync(walletPost);
            TransferPostDTO transfer = new TransferPostDTO(user.Id, user.Id,
                new Money {Amount = 100, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR}, walletWithMoney.Id, wallet.Id);
            transfer.Tag = "DefaultTag";
            await Api.Transfers.CreateAsync(key, transfer);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<TransferDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_TransfersCreateRefunds()
        {
            string key = DateTime.Now.Ticks.ToString();
            TransferDTO transfer = await this.GetNewTransfer();
            UserNaturalDTO user = await this.GetJohn();
            RefundTransferPostDTO refund = new RefundTransferPostDTO(user.Id);
            await Api.Transfers.CreateRefundAsync(key, transfer.Id, refund);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<RefundDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UboDeclarationCreate()
        {
            string key = DateTime.Now.Ticks.ToString();

            var refusedReasons = new UboRefusedReasonType[]
            {
                UboRefusedReasonType.MISSING_UBO,
                UboRefusedReasonType.DECLARATION_DO_NOT_MATCH_UBO_INFORMATION
            };

            var userLegal = await Api.Users.CreateAsync(CreateUserLegalPost());

            await Api.UboDeclarations.CreateUboDeclarationAsync(key, userLegal.Id);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<UboDeclarationDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsCa()
        {
            string key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountCaPostDTO(john.FirstName + " " + john.LastName, john.Address, "TestBankName",
                "123", "12345", "234234234234");
            await Api.Users.CreateBankAccountCaAsync(key, john.Id, account);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<BankAccountCaDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsGb()
        {
            string key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountGbPostDTO(john.FirstName + " " + john.LastName, john.Address, "63956474");
            account.SortCode = "200000";
            await Api.Users.CreateBankAccountGbAsync(key, john.Id, account);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<BankAccountGbDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsIban()
        {
            string key = DateTime.Now.Ticks.ToString();
            UserNaturalDTO john = await this.GetJohn();
            var account = new BankAccountIbanPostDTO(john.FirstName + " " + john.LastName, john.Address,
                "FR7630004000031234567890143");
            account.UserId = john.Id;
            account.BIC = "CRLYFRPP";
            await Api.Users.CreateBankAccountIbanAsync(key, john.Id, account);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<BankAccountIbanDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsOther()
        {
            string key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountOtherPostDTO(john.FirstName + " " + john.LastName, john.Address,
                "234234234234", "BINAADADXXX");
            account.Type = BankAccountType.OTHER;
            account.Country = CountryIso.FR;
            await Api.Users.CreateBankAccountOtherAsync(key, john.Id, account);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<BankAccountOtherDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateBankAccountsUs()
        {
            string key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var account = new BankAccountUsPostDTO(john.FirstName + " " + john.LastName, john.Address, "234234234234",
                "234334789");
            await Api.Users.CreateBankAccountUsAsync(key, john.Id, account);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<BankAccountUsDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateKycDocument()
        {
            string key = DateTime.Now.Ticks.ToString();
            var john = await GetJohn();
            await Api.Users.CreateKycDocumentAsync(key, john.Id, KycDocumentType.IDENTITY_PROOF);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<KycDocumentDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateLegals()
        {
            string key = DateTime.Now.Ticks.ToString();
            var userPost = new UserLegalPostDTO("email@email.org", "SomeOtherSampleOrg", LegalPersonType.BUSINESS,
                "RepFName", "RepLName", new DateTime(1975, 12, 21, 0, 0, 0), CountryIso.FR, CountryIso.FR);
            await Api.Users.CreateAsync(key, userPost);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<UserLegalDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_UsersCreateNaturals()
        {
            string key = DateTime.Now.Ticks.ToString();
            UserNaturalPostDTO user = new UserNaturalPostDTO("john.doe@sample.org", "John", "Doe",
                new DateTime(1975, 12, 21, 0, 0, 0), CountryIso.FR, CountryIso.FR);
            user.Occupation = "programmer";
            user.IncomeRange = 3;
            user.Address = new Address
            {
                AddressLine1 = "Address line 1", AddressLine2 = "Address line 2", City = "City",
                Country = CountryIso.PL, PostalCode = "11222", Region = "Region"
            };
            user.Capacity = CapacityType.NORMAL;

            await Api.Users.CreateAsync(key, user);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<UserNaturalDTO>(result.Resource);
        }

        [Test]
        public async Task Test_Idempotency_WalletsCreate()
        {
            string key = DateTime.Now.Ticks.ToString();
            var john = await this.GetJohn();
            var wallet = new WalletPostDTO(new List<string> {john.Id}, "WALLET IN EUR", CurrencyIso.EUR);
            await Api.Wallets.CreateAsync(key, wallet);

            var result = await Api.Idempotency.GetAsync(key);

            Assert.IsInstanceOf<WalletDTO>(result.Resource);
        }
    }
}
