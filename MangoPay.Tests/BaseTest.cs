using MangoPay.Core;
using MangoPay.Entities;
using MangoPay.Entities.Dependend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Tests
{
    /// <summary>Base abstract class for tests.</summary>
    public abstract class BaseTest
    {
        /// <summary>The MangoPayApi instance.</summary>
        protected MangoPayApi Api;

        private static UserNatural _john;
        private static UserLegal _matrix;
        private static BankAccount _johnsAccount;
        private static Wallet _johnsWallet;
        private static Wallet _johnsWalletWithMoney;
        private static PayIn _johnsPayInCardWeb;
        private static PayInPaymentDetailsCard _payInPaymentDetailsCard;
        private static PayInExecutionDetailsWeb _payInExecutionDetailsWeb;
        private static PayOut _johnsPayOutBankWire;
        private static CardRegistration _johnsCardRegistration;
        private static KycDocument _johnsKycDocument;
        private static PayOut _johnsPayOutForCardDirect;
        private static Hook _johnsHook;

        public BaseTest()
        {
            this.Api = BuildNewMangoPayApi();
        }

        protected MangoPayApi BuildNewMangoPayApi()
        {
            MangoPayApi api = new MangoPayApi();

            // use test client credentails
            api.Config.ClientId = "sdk-unit-tests";
            api.Config.ClientPassword = "cqFfFrWfCcb7UadHNxx2C9Lo6Djw8ZduLi7J9USTmu8bhxxpju";
            api.Config.DebugMode = true;

            // register storage strategy for tests
            api.OAuthTokenManager.RegisterCustomStorageStrategy(new DefaultStorageStrategyForTests());

            return api;
        }

        protected UserNatural GetJohn()
        {
            if (BaseTest._john == null)
            {
                UserNatural user = new UserNatural();
                user.FirstName = "John";
                user.LastName = "Doe";
                user.Email = "john.doe@sample.org";
                user.Address = "Some Address";
                user.Birthday = (long)(new DateTime(1975, 12, 21, 0, 0, 0) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                user.Nationality = "FR";
                user.CountryOfResidence = "FR";
                user.Occupation = "programmer";
                user.IncomeRange = 3;

                BaseTest._john = (UserNatural)this.Api.Users.Create(user);
            }
            return BaseTest._john;
        }

        protected UserNatural GetNewJohn()
        {
            UserNatural user = new UserNatural();
            user.FirstName = "John";
            user.LastName = "Doe";
            user.Email = "john.doe@sample.org";
            user.Address = "Some Address";
            user.Birthday = (long)(new DateTime(1975, 12, 21, 0, 0, 0) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            user.Nationality = "FR";
            user.CountryOfResidence = "FR";
            user.Occupation = "programmer";
            user.IncomeRange = 3;
            return (UserNatural)this.Api.Users.Create(user);

        }

        protected UserLegal GetMatrix()
        {
            if (BaseTest._matrix == null)
            {
                UserNatural john = this.GetJohn();
                UserLegal user = new UserLegal();
                user.Name = "MartixSampleOrg";
                user.LegalPersonType = "BUSINESS";
                user.HeadquartersAddress = "Some Address";
                user.LegalRepresentativeFirstName = john.FirstName;
                user.LegalRepresentativeLastName = john.LastName;
                user.LegalRepresentativeAddress = john.Address;
                user.LegalRepresentativeEmail = john.Email;
                user.LegalRepresentativeBirthday = john.Birthday;
                user.LegalRepresentativeNationality = john.Nationality;
                user.LegalRepresentativeCountryOfResidence = john.CountryOfResidence;

                user.LegalRepresentativeBirthday = (long)(new DateTime(1975, 12, 21, 0, 0, 0) - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                user.Email = john.Email;

                BaseTest._matrix = (UserLegal)this.Api.Users.Create(user);
            }
            return BaseTest._matrix;
        }

        protected BankAccount GetJohnsAccount()
        {
            if (BaseTest._johnsAccount == null)
            {
                UserNatural john = this.GetJohn();
                BankAccount account = new BankAccount();
                account.Type = "IBAN";
                account.OwnerName = john.FirstName + " " + john.LastName;
                account.OwnerAddress = john.Address;
                account.UserId = john.Id;
                BankAccountDetailsIBAN bankAccountDetails = new BankAccountDetailsIBAN();
                bankAccountDetails.IBAN = "FR76 1790 6000 3200 0833 5232 973";
                bankAccountDetails.BIC = "BINAADADXXX";
                account.Details = bankAccountDetails;
                BaseTest._johnsAccount = this.Api.Users.CreateBankAccount(john.Id, account);
            }
            return BaseTest._johnsAccount;
        }

        protected Wallet GetJohnsWallet()
        {
            if (BaseTest._johnsWallet == null)
            {
                UserNatural john = this.GetJohn();

                Wallet wallet = new Wallet();
                wallet.Owners = new List<string>();
                wallet.Owners.Add(john.Id);

                wallet.Currency = "EUR";
                wallet.Description = "WALLET IN EUR";

                BaseTest._johnsWallet = this.Api.Wallets.Create(wallet);
            }

            return BaseTest._johnsWallet;
        }

        /// <summary>Creates wallet for John, loaded with 10k EUR (John's got lucky) if not created yet, or returns an existing one.</summary>
        /// <returns>Wallet instance loaded with 10k EUR.</returns>
        protected Wallet GetJohnsWalletWithMoney()
        {
            return GetJohnsWalletWithMoney(10000);
        }

        /// <summary>Creates wallet for John, if not created yet, or returns an existing one.</summary>
        /// <param name="amount">Initial wallet's money amount.</param>
        /// <returns>Wallet entity instance returned from API.</returns>
        protected Wallet GetJohnsWalletWithMoney(double amount)
        {
            if (BaseTest._johnsWalletWithMoney == null)
            {
                UserNatural john = this.GetJohn();

                // create wallet with money
                Wallet wallet = new Wallet();
                wallet.Owners = new List<string>();
                wallet.Owners.Add(john.Id);
                wallet.Currency = "EUR";
                wallet.Description = "WALLET IN EUR WITH MONEY";

                BaseTest._johnsWalletWithMoney = this.Api.Wallets.Create(wallet);

                CardRegistration cardRegistration = new CardRegistration();
                cardRegistration.UserId = BaseTest._johnsWalletWithMoney.Owners[0];
                cardRegistration.Currency = "EUR";
                cardRegistration = this.Api.CardRegistrations.Create(cardRegistration);

                cardRegistration.RegistrationData = this.GetPaylineCorrectRegistartionData(cardRegistration);
                cardRegistration = this.Api.CardRegistrations.Update(cardRegistration);

                Card card = this.Api.Cards.Get(cardRegistration.CardId);

                // create pay-in CARD DIRECT
                PayIn payIn = new PayIn();
                payIn.CreditedWalletId = BaseTest._johnsWalletWithMoney.Id;
                payIn.AuthorId = cardRegistration.UserId;
                payIn.DebitedFunds = new Money();
                payIn.DebitedFunds.Amount = amount;
                payIn.DebitedFunds.Currency = "EUR";
                payIn.Fees = new Money();
                payIn.Fees.Amount = 0.0;
                payIn.Fees.Currency = "EUR";

                // payment type as CARD
                payIn.PaymentDetails = new PayInPaymentDetailsCard();
                if (card.CardType == "CB" || card.CardType == "VISA" || card.CardType == "MASTERCARD" || card.CardType == "CB_VISA_MASTERCARD")
                    ((PayInPaymentDetailsCard)payIn.PaymentDetails).CardType = "CB_VISA_MASTERCARD";
                else if (card.CardType == "AMEX")
                    ((PayInPaymentDetailsCard)payIn.PaymentDetails).CardType = "AMEX";

                // execution type as DIRECT
                payIn.ExecutionDetails = new PayInExecutionDetailsDirect();
                ((PayInExecutionDetailsDirect)payIn.ExecutionDetails).CardId = card.Id;
                ((PayInExecutionDetailsDirect)payIn.ExecutionDetails).SecureModeReturnURL = "http://test.com";
                // create Pay-In
                this.Api.PayIns.Create(payIn);
            }

            return this.Api.Wallets.Get(BaseTest._johnsWalletWithMoney.Id);
        }

        private PayInPaymentDetailsCard GetPayInPaymentDetailsCard()
        {
            if (BaseTest._payInPaymentDetailsCard == null)
            {
                BaseTest._payInPaymentDetailsCard = new PayInPaymentDetailsCard();
                BaseTest._payInPaymentDetailsCard.CardType = "CB_VISA_MASTERCARD";
            }

            return BaseTest._payInPaymentDetailsCard;
        }

        private PayInExecutionDetailsWeb GetPayInExecutionDetailsWeb()
        {
            if (BaseTest._payInExecutionDetailsWeb == null)
            {
                BaseTest._payInExecutionDetailsWeb = new PayInExecutionDetailsWeb();
                BaseTest._payInExecutionDetailsWeb.TemplateURL = "https://TemplateURL.com";
                BaseTest._payInExecutionDetailsWeb.SecureMode = "DEFAULT";
                BaseTest._payInExecutionDetailsWeb.Culture = "fr";
                BaseTest._payInExecutionDetailsWeb.ReturnURL = "https://test.com";
            }

            return BaseTest._payInExecutionDetailsWeb;
        }

        protected PayIn GetJohnsPayInCardWeb()
        {
            if (BaseTest._johnsPayInCardWeb == null)
            {
                Wallet wallet = this.GetJohnsWallet();
                UserNatural user = this.GetJohn();

                PayIn payIn = new PayIn();
                payIn.AuthorId = user.Id;
                payIn.CreditedUserId = user.Id;
                payIn.DebitedFunds = new Money();
                payIn.DebitedFunds.Currency = "EUR";
                payIn.DebitedFunds.Amount = 1000.0;
                payIn.Fees = new Money();
                payIn.Fees.Currency = "EUR";
                payIn.Fees.Amount = 5.0;
                payIn.CreditedWalletId = wallet.Id;
                payIn.PaymentDetails = this.GetPayInPaymentDetailsCard();
                payIn.ExecutionDetails = this.GetPayInExecutionDetailsWeb();

                BaseTest._johnsPayInCardWeb = this.Api.PayIns.Create(payIn);
            }

            return BaseTest._johnsPayInCardWeb;
        }

        protected PayIn GetNewPayInCardDirect()
        {
            return GetNewPayInCardDirect(null);
        }

        /// <summary>Creates PayIn Card Direct object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>PayIn Card Direct instance returned from API.</returns>
        protected PayIn GetNewPayInCardDirect(String userId)
        {
            Wallet wallet = this.GetJohnsWalletWithMoney();

            if (userId == null)
            {
                UserNatural user = this.GetJohn();
                userId = user.Id;
            }

            CardRegistration cardRegistration = new CardRegistration();
            cardRegistration.UserId = userId;
            cardRegistration.Currency = "EUR";
            cardRegistration = this.Api.CardRegistrations.Create(cardRegistration);
            cardRegistration.RegistrationData = this.GetPaylineCorrectRegistartionData(cardRegistration);
            cardRegistration = this.Api.CardRegistrations.Update(cardRegistration);

            Card card = this.Api.Cards.Get(cardRegistration.CardId);

            // create pay-in CARD DIRECT
            PayIn payIn = new PayIn();
            payIn.CreditedWalletId = wallet.Id;
            payIn.AuthorId = userId;
            payIn.DebitedFunds = new Money();
            payIn.DebitedFunds.Amount = 10000.0;
            payIn.DebitedFunds.Currency = "EUR";
            payIn.Fees = new Money();
            payIn.Fees.Amount = 0.0;
            payIn.Fees.Currency = "EUR";

            // payment type as CARD
            payIn.PaymentDetails = new PayInPaymentDetailsCard();
            ((PayInPaymentDetailsCard)payIn.PaymentDetails).CardId = card.Id;
            if (card.CardType == "CB" || card.CardType == "VISA" || card.CardType == "MASTERCARD" || card.CardType == "CB_VISA_MASTERCARD")
                ((PayInPaymentDetailsCard)payIn.PaymentDetails).CardType = "CB_VISA_MASTERCARD";
            else if (card.CardType == "AMEX")
                ((PayInPaymentDetailsCard)payIn.PaymentDetails).CardType = "AMEX";

            // execution type as DIRECT
            payIn.ExecutionDetails = new PayInExecutionDetailsDirect();
            ((PayInExecutionDetailsDirect)payIn.ExecutionDetails).CardId = card.Id;
            ((PayInExecutionDetailsDirect)payIn.ExecutionDetails).SecureModeReturnURL = "http://test.com";

            return this.Api.PayIns.Create(payIn);
        }

        protected PayOut GetJohnsPayOutBankWire()
        {
            if (BaseTest._johnsPayOutBankWire == null)
            {
                Wallet wallet = this.GetJohnsWallet();
                UserNatural user = this.GetJohn();
                BankAccount account = this.GetJohnsAccount();

                PayOut payOut = new PayOut();
                payOut.Tag = "DefaultTag";
                payOut.AuthorId = user.Id;
                payOut.CreditedUserId = user.Id;
                payOut.DebitedFunds = new Money();
                payOut.DebitedFunds.Currency = "EUR";
                payOut.DebitedFunds.Amount = 10.0;
                payOut.Fees = new Money();
                payOut.Fees.Currency = "EUR";
                payOut.Fees.Amount = 5.0;

                payOut.DebitedWalletId = wallet.Id;
                payOut.MeanOfPaymentDetails = new PayOutPaymentDetailsBankWire();
                ((PayOutPaymentDetailsBankWire)payOut.MeanOfPaymentDetails).BankAccountId = account.Id;
                ((PayOutPaymentDetailsBankWire)payOut.MeanOfPaymentDetails).Communication = "Communication text";

                BaseTest._johnsPayOutBankWire = this.Api.PayOuts.Create(payOut);
            }

            return BaseTest._johnsPayOutBankWire;
        }

        /// <summary>Creates PayOut Bank Wire object.</summary>
        /// <returns>PayOut Bank Wire instance returned from API.</returns>
        protected PayOut GetJohnsPayOutForCardDirect()
        {
            if (BaseTest._johnsPayOutForCardDirect == null)
            {
                PayIn payIn = this.GetNewPayInCardDirect();
                BankAccount account = this.GetJohnsAccount();

                PayOut payOut = new PayOut();
                payOut.Tag = "DefaultTag";
                payOut.AuthorId = payIn.AuthorId;
                payOut.CreditedUserId = payIn.AuthorId;
                payOut.DebitedFunds = new Money();
                payOut.DebitedFunds.Currency = "EUR";
                payOut.DebitedFunds.Amount = 10.0;
                payOut.Fees = new Money();
                payOut.Fees.Currency = "EUR";
                payOut.Fees.Amount = 5.0;

                payOut.DebitedWalletId = payIn.CreditedWalletId;
                payOut.MeanOfPaymentDetails = new PayOutPaymentDetailsBankWire();
                ((PayOutPaymentDetailsBankWire)payOut.MeanOfPaymentDetails).BankAccountId = account.Id;
                ((PayOutPaymentDetailsBankWire)payOut.MeanOfPaymentDetails).Communication = "Communication text";

                BaseTest._johnsPayOutForCardDirect = this.Api.PayOuts.Create(payOut);
            }

            return BaseTest._johnsPayOutForCardDirect;
        }

        protected Transfer GetNewTransfer()
        {
            Wallet walletWithMoney = this.GetJohnsWalletWithMoney();
            UserNatural user = this.GetJohn();

            Wallet wallet = new Wallet();
            wallet.Owners = new List<string>();
            wallet.Owners.Add(user.Id);
            wallet.Currency = "EUR";
            wallet.Description = "WALLET IN EUR FOR TRANSFER";
            wallet = this.Api.Wallets.Create(wallet);

            Transfer transfer = new Transfer();
            transfer.Tag = "DefaultTag";
            transfer.AuthorId = user.Id;
            transfer.CreditedUserId = user.Id;
            transfer.DebitedFunds = new Money();
            transfer.DebitedFunds.Currency = "EUR";
            transfer.DebitedFunds.Amount = 100.0;
            transfer.Fees = new Money();
            transfer.Fees.Currency = "EUR";
            transfer.Fees.Amount = 0.0;

            transfer.DebitedWalletId = walletWithMoney.Id;
            transfer.CreditedWalletId = wallet.Id;

            return this.Api.Transfers.Create(transfer);
        }

        /// <summary>Creates refund object for transfer.</summary>
        /// <param name="transfer">Transfer.</param>
        /// <returns>Refund instance returned from API.</returns>
        protected Refund GetNewRefundForTransfer(Transfer transfer)
        {
            UserNatural user = this.GetJohn();

            Refund refund = new Refund();
            refund.DebitedWalletId = transfer.DebitedWalletId;
            refund.CreditedWalletId = transfer.CreditedWalletId;
            refund.AuthorId = user.Id;
            refund.DebitedFunds = new Money();
            refund.DebitedFunds.Amount = transfer.DebitedFunds.Amount;
            refund.DebitedFunds.Currency = transfer.DebitedFunds.Currency;
            refund.Fees = new Money();
            refund.Fees.Amount = transfer.Fees.Amount;
            refund.Fees.Currency = transfer.Fees.Currency;

            return this.Api.Transfers.CreateRefund(transfer.Id, refund);
        }

        /// <summary>Creates refund object for PayIn.</summary>
        /// <param name="payIn">PayIn entity.</param>
        /// <returns>Refund instance returned from API.</returns>
        protected Refund GetNewRefundForPayIn(PayIn payIn)
        {
            UserNatural user = this.GetJohn();

            Refund refund = new Refund();
            refund.CreditedWalletId = payIn.CreditedWalletId;
            refund.AuthorId = user.Id;
            refund.DebitedFunds = new Money();
            refund.DebitedFunds.Amount = payIn.DebitedFunds.Amount;
            refund.DebitedFunds.Currency = payIn.DebitedFunds.Currency;
            refund.Fees = new Money();
            refund.Fees.Amount = payIn.Fees.Amount;
            refund.Fees.Currency = payIn.Fees.Currency;

            return this.Api.PayIns.CreateRefund(payIn.Id, refund);
        }

        /// <summary>Creates card registration object.</summary>
        /// <returns>CardRegistration instance returned from API.</returns>
        protected CardRegistration GetJohnsCardRegistration()
        {
            if (BaseTest._johnsCardRegistration == null)
            {
                UserNatural user = this.GetJohn();

                CardRegistration cardRegistration = new CardRegistration();
                cardRegistration.UserId = user.Id;
                cardRegistration.Currency = "EUR";

                BaseTest._johnsCardRegistration = this.Api.CardRegistrations.Create(cardRegistration);
            }

            return BaseTest._johnsCardRegistration;
        }

        /// <summary>Creates card registration object.</summary>
        /// <returns>CardPreAuthorization instance returned from API.</returns>
        protected CardPreAuthorization GetJohnsCardPreAuthorization()
        {
            UserNatural user = this.GetJohn();
            CardRegistration cardRegistration = new CardRegistration();
            cardRegistration.UserId = user.Id;
            cardRegistration.Currency = "EUR";
            CardRegistration newCardRegistration = this.Api.CardRegistrations.Create(cardRegistration);

            String registrationData = this.GetPaylineCorrectRegistartionData(newCardRegistration);
            newCardRegistration.RegistrationData = registrationData;
            CardRegistration getCardRegistration = this.Api.CardRegistrations.Update(newCardRegistration);

            CardPreAuthorization cardPreAuthorization = new CardPreAuthorization();
            cardPreAuthorization.AuthorId = user.Id;
            cardPreAuthorization.DebitedFunds = new Money();
            cardPreAuthorization.DebitedFunds.Currency = "EUR";
            cardPreAuthorization.DebitedFunds.Amount = 10000.0;
            cardPreAuthorization.CardId = getCardRegistration.CardId;
            cardPreAuthorization.SecureModeReturnURL = "http://test.com";

            return this.Api.CardPreAuthorizations.Create(cardPreAuthorization);
        }

        protected KycDocument GetJohnsKycDocument()
        {
            if (BaseTest._johnsKycDocument == null)
            {
                String johnsId = this.GetJohn().Id;

                BaseTest._johnsKycDocument = this.Api.Users.CreateKycDocument(johnsId, KycDocumentType.IDENTITY_PROOF);
            }

            return BaseTest._johnsKycDocument;
        }

        /// <summary>Gets registration data from Payline service.</summary>
        /// <param name="cardRegistration">CardRegistration instance.</param>
        /// <returns>Registration data.</returns>
        protected String GetPaylineCorrectRegistartionData(CardRegistration cardRegistration)
        {
            RestClient client = new RestClient(cardRegistration.CardRegistrationURL);

            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("data", cardRegistration.PreregistrationData);
            request.AddParameter("accessKeyRef", cardRegistration.AccessKey);
            request.AddParameter("cardNumber", "4970100000000154");
            request.AddParameter("cardExpirationDate", "1214");
            request.AddParameter("cardCvx", "123");

            IRestResponse response = client.Execute(request);

            String responseString = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
                return responseString;
            else
                throw new Exception(responseString);
        }

        protected Hook GetJohnsHook()
        {
            if (BaseTest._johnsHook == null)
            {

                Pagination pagination = new Pagination(1, 1);
                List<Hook> list = this.Api.Hooks.GetAll(pagination);

                if (list != null && list.Count > 0 && list[0] != null)
                {
                    BaseTest._johnsHook = list[0];
                }
                else
                {
                    Hook hook = new Hook();
                    hook.EventType = EventType.PAYIN_NORMAL_CREATED;
                    hook.Url = "http://test.com";
                    BaseTest._johnsHook = this.Api.Hooks.Create(hook);
                }
            }

            return BaseTest._johnsHook;
        }

        protected void AssertEqualInputProps<T>(T entity1, T entity2)
        {
            Assert.IsNotNull(entity1);
            Assert.IsNotNull(entity2);

            if (entity1 is UserNatural && entity2 is UserNatural)
            {
                Assert.AreEqual((entity1 as UserNatural).Tag, (entity2 as UserNatural).Tag);
                Assert.AreEqual((entity1 as UserNatural).PersonType, (entity2 as UserNatural).PersonType);
                Assert.AreEqual((entity1 as UserNatural).FirstName, (entity2 as UserNatural).FirstName);
                Assert.AreEqual((entity1 as UserNatural).LastName, (entity2 as UserNatural).LastName);
                Assert.AreEqual((entity1 as UserNatural).Email, (entity2 as UserNatural).Email);
                Assert.AreEqual((entity1 as UserNatural).Address, (entity2 as UserNatural).Address);
                Assert.AreEqual((entity1 as UserNatural).Birthday, (entity2 as UserNatural).Birthday);
                Assert.AreEqual((entity1 as UserNatural).Nationality, (entity2 as UserNatural).Nationality);
                Assert.AreEqual((entity1 as UserNatural).CountryOfResidence, (entity2 as UserNatural).CountryOfResidence);
                Assert.AreEqual((entity1 as UserNatural).Occupation, (entity2 as UserNatural).Occupation);
                Assert.AreEqual((entity1 as UserNatural).IncomeRange, (entity2 as UserNatural).IncomeRange);
            }
            else if (entity1 is UserLegal && entity2 is UserLegal)
            {
                Assert.AreEqual((entity1 as UserLegal).Tag, (entity2 as UserLegal).Tag);
                Assert.AreEqual((entity1 as UserLegal).PersonType, (entity2 as UserLegal).PersonType);
                Assert.AreEqual((entity1 as UserLegal).Name, (entity2 as UserLegal).Name);
                Assert.AreEqual((entity1 as UserLegal).HeadquartersAddress, (entity2 as UserLegal).HeadquartersAddress);
                Assert.AreEqual((entity1 as UserLegal).LegalRepresentativeFirstName, (entity2 as UserLegal).LegalRepresentativeFirstName);
                Assert.AreEqual((entity1 as UserLegal).LegalRepresentativeLastName, (entity2 as UserLegal).LegalRepresentativeLastName);
                //Assert.AreEqual("***** TEMPORARY API ISSUE: RETURNED OBJECT MISSES THIS PROP AFTER CREATION *****", (entity1 as UserLegal).LegalRepresentativeAddress, (entity2 as UserLegal).LegalRepresentativeAddress);
                Assert.AreEqual((entity1 as UserLegal).LegalRepresentativeEmail, (entity2 as UserLegal).LegalRepresentativeEmail);
                //Assert.AreEqual("***** TEMPORARY API ISSUE: RETURNED OBJECT HAS THIS PROP CHANGED FROM TIMESTAMP INTO ISO STRING AFTER CREATION *****", (entity1 as UserLegal).LegalRepresentativeBirthday, (entity2 as UserLegal).LegalRepresentativeBirthday);
                Assert.AreEqual((entity1 as UserLegal).LegalRepresentativeBirthday, (entity2 as UserLegal).LegalRepresentativeBirthday);
                Assert.AreEqual((entity1 as UserLegal).LegalRepresentativeNationality, (entity2 as UserLegal).LegalRepresentativeNationality);
                Assert.AreEqual((entity1 as UserLegal).LegalRepresentativeCountryOfResidence, (entity2 as UserLegal).LegalRepresentativeCountryOfResidence);
            }
            else if (typeof(T) == typeof(BankAccount))
            {
                Assert.AreEqual((entity1 as BankAccount).Tag, (entity2 as BankAccount).Tag);
                Assert.AreEqual((entity1 as BankAccount).UserId, (entity2 as BankAccount).UserId);
                Assert.AreEqual((entity1 as BankAccount).Type, (entity2 as BankAccount).Type);
                Assert.AreEqual((entity1 as BankAccount).OwnerName, (entity2 as BankAccount).OwnerName);
                Assert.AreEqual((entity1 as BankAccount).OwnerAddress, (entity2 as BankAccount).OwnerAddress);
                if ((entity1 as BankAccount).Type == "IBAN")
                {
                    Assert.AreEqual(((BankAccountDetailsIBAN)(entity1 as BankAccount).Details).IBAN, ((BankAccountDetailsIBAN)(entity2 as BankAccount).Details).IBAN);
                    Assert.AreEqual(((BankAccountDetailsIBAN)(entity1 as BankAccount).Details).BIC, ((BankAccountDetailsIBAN)(entity2 as BankAccount).Details).BIC);
                }
                else if ((entity1 as BankAccount).Type == "GB")
                {
                    Assert.AreEqual(((BankAccountDetailsGB)(entity1 as BankAccount).Details).AccountNumber, ((BankAccountDetailsGB)(entity2 as BankAccount).Details).AccountNumber);
                    Assert.AreEqual(((BankAccountDetailsGB)(entity1 as BankAccount).Details).SortCode, ((BankAccountDetailsGB)(entity2 as BankAccount).Details).SortCode);
                }
                else if ((entity1 as BankAccount).Type == "US")
                {
                    Assert.AreEqual(((BankAccountDetailsUS)(entity1 as BankAccount).Details).AccountNumber, ((BankAccountDetailsUS)(entity2 as BankAccount).Details).AccountNumber);
                    Assert.AreEqual(((BankAccountDetailsUS)(entity1 as BankAccount).Details).ABA, ((BankAccountDetailsUS)(entity2 as BankAccount).Details).ABA);
                }
                else if ((entity1 as BankAccount).Type == "CA")
                {
                    Assert.AreEqual(((BankAccountDetailsCA)(entity1 as BankAccount).Details).AccountNumber, ((BankAccountDetailsCA)(entity2 as BankAccount).Details).AccountNumber);
                    Assert.AreEqual(((BankAccountDetailsCA)(entity1 as BankAccount).Details).BankName, ((BankAccountDetailsCA)(entity2 as BankAccount).Details).BankName);
                    Assert.AreEqual(((BankAccountDetailsCA)(entity1 as BankAccount).Details).InstitutionNumber, ((BankAccountDetailsCA)(entity2 as BankAccount).Details).InstitutionNumber);
                    Assert.AreEqual(((BankAccountDetailsCA)(entity1 as BankAccount).Details).BranchCode, ((BankAccountDetailsCA)(entity2 as BankAccount).Details).BranchCode);
                }
                else if ((entity1 as BankAccount).Type == "OTHER")
                {
                    Assert.AreEqual(((BankAccountDetailsOTHER)(entity1 as BankAccount).Details).AccountNumber, ((BankAccountDetailsOTHER)(entity2 as BankAccount).Details).AccountNumber);
                    Assert.AreEqual(((BankAccountDetailsOTHER)(entity1 as BankAccount).Details).Type, ((BankAccountDetailsOTHER)(entity2 as BankAccount).Details).Type);
                    Assert.AreEqual(((BankAccountDetailsOTHER)(entity1 as BankAccount).Details).Country, ((BankAccountDetailsOTHER)(entity2 as BankAccount).Details).Country);
                    Assert.AreEqual(((BankAccountDetailsOTHER)(entity1 as BankAccount).Details).BIC, ((BankAccountDetailsOTHER)(entity2 as BankAccount).Details).BIC);
                }
            }
            else if (typeof(T) == typeof(PayIn))
            {
                Assert.AreEqual((entity1 as PayIn).Tag, (entity2 as PayIn).Tag);
                Assert.AreEqual((entity1 as PayIn).AuthorId, (entity2 as PayIn).AuthorId);
                Assert.AreEqual((entity1 as PayIn).CreditedUserId, (entity2 as PayIn).CreditedUserId);

                AssertEqualInputProps((entity1 as PayIn).DebitedFunds, (entity2 as PayIn).DebitedFunds);
                AssertEqualInputProps((entity1 as PayIn).CreditedFunds, (entity2 as PayIn).CreditedFunds);
                AssertEqualInputProps((entity1 as PayIn).Fees, (entity2 as PayIn).Fees);
            }
            else if (typeof(T) == typeof(Card))
            {
                Assert.AreEqual((entity1 as Card).ExpirationDate, (entity2 as Card).ExpirationDate);
                Assert.AreEqual((entity1 as Card).Alias, (entity2 as Card).Alias);
                Assert.AreEqual((entity1 as Card).CardType, (entity2 as Card).CardType);
                Assert.AreEqual((entity1 as Card).Currency, (entity2 as Card).Currency);
            }
            else if (typeof(T) == typeof(PayInPaymentDetailsCard))
            {
                Assert.AreEqual((entity1 as PayInPaymentDetailsCard).CardType, (entity2 as PayInPaymentDetailsCard).CardType);
            }
            else if (typeof(T) == typeof(PayInExecutionDetailsWeb))
            {
                Assert.AreEqual((entity1 as PayInExecutionDetailsWeb).TemplateURL, (entity2 as PayInExecutionDetailsWeb).TemplateURL);
                Assert.AreEqual((entity1 as PayInExecutionDetailsWeb).Culture, (entity2 as PayInExecutionDetailsWeb).Culture);
                Assert.AreEqual((entity1 as PayInExecutionDetailsWeb).SecureMode, (entity2 as PayInExecutionDetailsWeb).SecureMode);
                Assert.AreEqual((entity1 as PayInExecutionDetailsWeb).RedirectURL, (entity2 as PayInExecutionDetailsWeb).RedirectURL);
                Assert.AreEqual((entity1 as PayInExecutionDetailsWeb).ReturnURL, (entity2 as PayInExecutionDetailsWeb).ReturnURL);
            }
            else if (typeof(T) == typeof(PayOut))
            {
                Assert.AreEqual((entity1 as PayOut).Tag, (entity2 as PayOut).Tag);
                Assert.AreEqual((entity1 as PayOut).AuthorId, (entity2 as PayOut).AuthorId);
                Assert.AreEqual((entity1 as PayOut).CreditedUserId, (entity2 as PayOut).CreditedUserId);

                AssertEqualInputProps((entity1 as PayOut).DebitedFunds, (entity2 as PayOut).DebitedFunds);
                AssertEqualInputProps((entity1 as PayOut).CreditedFunds, (entity2 as PayOut).CreditedFunds);
                AssertEqualInputProps((entity1 as PayOut).Fees, (entity2 as PayOut).Fees);
                AssertEqualInputProps((entity1 as PayOut).MeanOfPaymentDetails, (entity2 as PayOut).MeanOfPaymentDetails);
            }
            else if (typeof(T) == typeof(Transfer))
            {
                Assert.AreEqual((entity1 as Transfer).Tag, (entity2 as Transfer).Tag);
                Assert.AreEqual((entity1 as Transfer).AuthorId, (entity2 as Transfer).AuthorId);
                Assert.AreEqual((entity1 as Transfer).CreditedUserId, (entity2 as Transfer).CreditedUserId);

                AssertEqualInputProps((entity1 as Transfer).DebitedFunds, (entity2 as Transfer).DebitedFunds);
                AssertEqualInputProps((entity1 as Transfer).CreditedFunds, (entity2 as Transfer).CreditedFunds);
                AssertEqualInputProps((entity1 as Transfer).Fees, (entity2 as Transfer).Fees);
            }
            else if (typeof(T) == typeof(PayOutPaymentDetailsBankWire))
            {
                Assert.AreEqual((entity1 as PayOutPaymentDetailsBankWire).BankAccountId, (entity2 as PayOutPaymentDetailsBankWire).BankAccountId);
                Assert.AreEqual((entity1 as PayOutPaymentDetailsBankWire).Communication, (entity2 as PayOutPaymentDetailsBankWire).Communication);
            }
            else if (typeof(T) == typeof(Transaction))
            {
                Assert.AreEqual((entity1 as Transaction).Tag, (entity2 as Transaction).Tag);

                AssertEqualInputProps((entity1 as Transaction).DebitedFunds, (entity2 as Transaction).DebitedFunds);
                AssertEqualInputProps((entity1 as Transaction).Fees, (entity2 as Transaction).Fees);
                AssertEqualInputProps((entity1 as Transaction).CreditedFunds, (entity2 as Transaction).CreditedFunds);

                Assert.AreEqual((entity1 as Transaction).Status, (entity2 as Transaction).Status);
            }
            else if (typeof(T) == typeof(Money))
            {
                Assert.AreEqual((entity1 as Money).Currency, (entity2 as Money).Currency);
                Assert.AreEqual((entity1 as Money).Amount, (entity2 as Money).Amount);
            }
            else
            {
                throw new ArgumentException("Unsupported type.");
            }
        }
    }
}
