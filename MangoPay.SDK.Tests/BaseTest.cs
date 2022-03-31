using Common.Logging.Simple;
using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MangoPay.SDK.Tests
{
    /// <summary>Base abstract class for tests.</summary>
    public abstract class BaseTest
    {
        /// <summary>The MangoPayApi instance.</summary>
        protected MangoPayApi Api;

        private static UserNaturalDTO _john;
        private static UserLegalDTO _matrix;
        private static BankAccountIbanDTO _johnsAccount;
        private static WalletDTO _johnsWallet;
        private static WalletDTO _johnsWalletWithMoney;
        private static PayInCardWebDTO _johnsPayInCardWeb;
        private static PayOutBankWireDTO _johnsPayOutBankWire;
        private static CardRegistrationDTO _johnsCardRegistration;
        private static KycDocumentDTO _johnsKycDocument;
        private static PayOutBankWireDTO _johnsPayOutForCardDirect;
        private static HookDTO _johnsHook;
        private static Dictionary<ReportType, ReportRequestDTO> _johnsReports;

        public BaseTest()
        {
            this.Api = BuildNewMangoPayApi();
            _johnsReports = new Dictionary<ReportType, ReportRequestDTO>();

        }

        protected static List<UserNaturalPostDTO> UserNaturalPostCollection
        {
            get
            {
                return new List<UserNaturalPostDTO>(){
                    new UserNaturalPostDTO(
                    "john.doenatural@natual1.com",
                    "JohnNatural1",
                    "DoeNatural1",
                    new DateTime(1985, 12, 21, 0, 0, 0),
                    CountryIso.DE,
                    CountryIso.DE)
                    {
                    Address = new Address()
                    {
                        AddressLine1 = "Address line Natural1 1",
                        AddressLine2 = "Address line Natural1 2",
                        City = "CityNatural1",
                        Country = CountryIso.PL,
                        PostalCode = "11222",
                        Region = "RegionNatural1"
                    },
                    Occupation = "programmer1",
                    IncomeRange = 5,
                    Capacity = CapacityType.NORMAL
                    },

                    new UserNaturalPostDTO(
                    "john.doenatural@natual2.com",
                    "JohnNatural2",
                    "DoeNatural2",
                    new DateTime(1985, 12, 21, 0, 0, 0),
                    CountryIso.DE,
                    CountryIso.DE)
                    {
                    Address = new Address()
                    {
                        AddressLine1 = "Address line Natural2 1",
                        AddressLine2 = "Address line Natural2 2",
                        City = "CityNatural2",
                        Country = CountryIso.PL,
                        PostalCode = "11222",
                        Region = "RegionNatural2"
                    },
                    Occupation = "programmer2",
                    IncomeRange = 3,
                    Capacity = CapacityType.NORMAL
                    }
                };
            }
        }

        protected static UserLegalPostDTO CreateUserLegalPost()
        {
            UserLegalPostDTO user = new UserLegalPostDTO(
              "john.doe@sample.org",
              "MartixSampleOrg",
              LegalPersonType.BUSINESS,
              "JohnUbo",
              "DoeUbo",
              new DateTime(1975, 12, 21, 0, 0, 0),
              CountryIso.PL,
              CountryIso.PL);

            user.HeadquartersAddress = new Address
            {
                AddressLine1 = "Address line ubo 1",
                AddressLine2 = "Address line ubo 2",
                City = "CityUbo",
                Country = CountryIso.PL,
                PostalCode = "11222",
                Region = "RegionUbo"
            };

            user.LegalRepresentativeAddress = new Address
            {
                AddressLine1 = "Address line ubo 1",
                AddressLine2 = "Address line ubo 2",
                City = "CityUbo",
                Country = CountryIso.PL,
                PostalCode = "11222",
                Region = "RegionUbo"
            };

            user.LegalRepresentativeEmail = "john.doe@sample.org";
            user.LegalRepresentativeBirthday = new DateTime(1975, 12, 21, 0, 0, 0);
            user.Email = "john.doe@sample.org";
            return user;
        }

        protected MangoPayApi BuildNewMangoPayApi()
        {
            MangoPayApi api = new MangoPayApi();

            // use test client credentails
            api.Config.ClientId = "sdk-unit-tests";
            api.Config.ClientPassword = "cqFfFrWfCcb7UadHNxx2C9Lo6Djw8ZduLi7J9USTmu8bhxxpju";
            api.Config.BaseUrl = "https://api.sandbox.mangopay.com";
            api.Config.ApiVersion = "v2.01";
#if NET461
            api.Config.LoggerFactoryAdapter = new ConsoleOutLoggerFactoryAdapter();
#endif

            // register storage strategy for tests
            api.OAuthTokenManager.RegisterCustomStorageStrategy(new DefaultStorageStrategyForTests());

            return api;
        }

        protected async Task<UserNaturalDTO> GetJohn(bool recreate = false)
        {
            if (BaseTest._john == null || recreate)
            {
                UserNaturalPostDTO user = new UserNaturalPostDTO("john.doe@sample.org", "John", "Doe", new DateTime(1975, 12, 21, 0, 0, 0), CountryIso.FR, CountryIso.FR);
                user.Occupation = "programmer";
                user.IncomeRange = 3;
                user.Address = new Address { AddressLine1 = "Address line 1", AddressLine2 = "Address line 2", City = "City", Country = CountryIso.PL, PostalCode = "11222", Region = "Region" };
                user.Capacity = CapacityType.DECLARATIVE;

                BaseTest._john = await this.Api.Users.CreateAsync(user);

                BaseTest._johnsWallet = null;
            }
            return BaseTest._john;
        }

        protected async Task<UserNaturalDTO> GetNewJohn()
        {
            UserNaturalPostDTO user = new UserNaturalPostDTO("john.doe@sample.org", "John", "Doe", new DateTime(1975, 12, 21, 0, 0, 0), CountryIso.FR, CountryIso.FR)
            {
                Occupation = "programmer",
                IncomeRange = 3,
                Address = new Address { AddressLine1 = "Address line 1", AddressLine2 = "Address line 2", City = "City", Country = CountryIso.PL, PostalCode = "11222", Region = "Region" },
                Capacity = CapacityType.DECLARATIVE
            };

            return await this.Api.Users.CreateAsync(user);
        }

        protected async Task<UserLegalDTO> GetMatrix()
        {
            if (BaseTest._matrix == null)
            {
                UserNaturalDTO john = await this.GetJohn();
                var birthday = john.Birthday ?? new DateTime();
                UserLegalPostDTO user = new UserLegalPostDTO(john.Email, "MartixSampleOrg", LegalPersonType.BUSINESS, john.FirstName, john.LastName, birthday, john.Nationality, john.CountryOfResidence)
                {
                    HeadquartersAddress = new Address { AddressLine1 = "Address line 1", AddressLine2 = "Address line 2", City = "City", Country = CountryIso.PL, PostalCode = "11222", Region = "Region" },
                    LegalRepresentativeAddress = john.Address,
                    LegalRepresentativeEmail = john.Email,
                    LegalRepresentativeBirthday = new DateTime(1975, 12, 21, 0, 0, 0),
                    Email = john.Email
                };

                BaseTest._matrix = await this.Api.Users.CreateAsync(user);
            }

            return BaseTest._matrix;
        }

        protected async Task<BankAccountIbanDTO> GetJohnsAccount(bool recreate = false)
        {
            if (BaseTest._johnsAccount == null || recreate)
            {
                UserNaturalDTO john = await this.GetJohn();
                BankAccountIbanPostDTO account = new BankAccountIbanPostDTO(john.FirstName + " " + john.LastName, john.Address, "FR7630004000031234567890143")
                {
                    UserId = john.Id,
                    BIC = "BNPAFRPP"
                };
                BaseTest._johnsAccount =  await this.Api.Users.CreateBankAccountIbanAsync(john.Id, account);
            }

            return BaseTest._johnsAccount;
        }

        protected async Task<WalletDTO> GetJohnsWallet()
        {
            if (BaseTest._johnsWallet == null)
            {
                UserNaturalDTO john = await this.GetJohn();

                WalletPostDTO wallet = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);

                BaseTest._johnsWallet = await this.Api.Wallets.CreateAsync(wallet);
            }

            return BaseTest._johnsWallet;
        }


        protected async Task<WalletDTO> CreateJohnsWallet()
        {

            UserNaturalDTO john = await this.GetJohn();

            WalletPostDTO wallet = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR", CurrencyIso.EUR);

            return await Api.Wallets.CreateAsync(wallet);
        }

        /// <summary>Creates wallet for John, loaded with 10k EUR (John's got lucky) if not created yet, or returns an existing one.</summary>
        /// <returns>Wallet instance loaded with 10k EUR.</returns>
        protected async Task<WalletDTO> GetJohnsWalletWithMoney()
        {
            return await GetJohnsWalletWithMoney(100);
        }

        /// <summary>Creates wallet for John, if not created yet, or returns an existing one.</summary>
        /// <param name="amount">Initial wallet's money amount.</param>
        /// <returns>Wallet entity instance returned from API.</returns>
        protected async Task<WalletDTO> GetJohnsWalletWithMoney(int amount)
        {
            if (BaseTest._johnsWalletWithMoney == null)
                BaseTest._johnsWalletWithMoney = await GetNewJohnsWalletWithMoney(amount);

            return BaseTest._johnsWalletWithMoney;
        }

        /// <summary>Creates new wallet for John.</summary>
        /// <param name="amount">Initial wallet's money amount.</param>
        /// <returns>Wallet entity instance returned from API.</returns>
        protected async Task<WalletDTO> GetNewJohnsWalletWithMoney(int amount, UserNaturalDTO user = null)
        {
            UserNaturalDTO john = user;
            if (john == null)
            {
                john = await this.GetJohn();
            }

            // create wallet with money
            WalletPostDTO wallet = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR WITH MONEY", CurrencyIso.EUR);

            var johnsWalletWithMoney = await this.Api.Wallets.CreateAsync(wallet);

            CardRegistrationPostDTO cardRegistrationPost = new CardRegistrationPostDTO(johnsWalletWithMoney.Owners[0], CurrencyIso.EUR);
            CardRegistrationDTO cardRegistration = await this.Api.CardRegistrations.CreateAsync(cardRegistrationPost);

            CardRegistrationPutDTO cardRegistrationPut = new CardRegistrationPutDTO
            {
                RegistrationData = await this.GetPaylineCorrectRegistartionData(cardRegistration)
            };
            cardRegistration = await this.Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);

            CardDTO card = await this.Api.Cards.GetAsync(cardRegistration.CardId);

            // create pay-in CARD DIRECT
            PayInCardDirectPostDTO payIn = new PayInCardDirectPostDTO(cardRegistration.UserId, cardRegistration.UserId,
                new Money { Amount = amount, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR },
                johnsWalletWithMoney.Id, "http://test.com", card.Id);

            payIn.CardType = card.CardType;

            // create Pay-In
            var result = await this.Api.PayIns.CreateCardDirectAsync(payIn);

            return await this.Api.Wallets.GetAsync(johnsWalletWithMoney.Id);
        }

        protected async Task<Tuple<string, WalletDTO>> GetNewJohnsWalletWithMoneyAndCardId(int amount, UserNaturalDTO user = null)
        {
            var john = user ?? await this.GetJohn();

            // create wallet with money
            var wallet = new WalletPostDTO(new List<string> { john.Id }, "WALLET IN EUR WITH MONEY", CurrencyIso.EUR);

            var johnsWalletWithMoney = await this.Api.Wallets.CreateAsync(wallet);

            var cardRegistrationPost = new CardRegistrationPostDTO(johnsWalletWithMoney.Owners[0], CurrencyIso.EUR);
            var cardRegistration = await this.Api.CardRegistrations.CreateAsync(cardRegistrationPost);

            var cardRegistrationPut = new CardRegistrationPutDTO
            {
                RegistrationData = await this.GetPaylineCorrectRegistartionData3DSecure(cardRegistration)
            };
            cardRegistration = await this.Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);

            var card = await this.Api.Cards.GetAsync(cardRegistration.CardId);

            // create pay-in CARD DIRECT
            var payIn = new PayInCardDirectPostDTO(cardRegistration.UserId, cardRegistration.UserId,
                new Money {Amount = amount, Currency = CurrencyIso.EUR},
                new Money {Amount = 0, Currency = CurrencyIso.EUR},
                johnsWalletWithMoney.Id, "http://www.my-site.com/returnurl", card.Id)
            {
                CardType = card.CardType,
                IpAddress = "2001:0620:0000:0000:0211:24FF:FE80:C12C",
                Requested3DSVersion = "V2_1",
                BrowserInfo = new BrowserInfo
                {
                    AcceptHeader = "text/html, application/xhtml+xml, application/xml;q=0.9, /;q=0.8",
                    JavaEnabled = true,
                    Language = "FR-FR",
                    ColorDepth = 4,
                    ScreenHeight = 1800,
                    ScreenWidth = 400,
                    JavascriptEnabled = true,
                    TimeZoneOffset = "+60",
                    UserAgent =
                        "Mozilla/5.0 (iPhone; CPU iPhone OS 13_6_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148"
                }
            };


            // create Pay-In
            var result = await this.Api.PayIns.CreateCardDirectAsync(payIn);

            var createdWallet = await this.Api.Wallets.GetAsync(johnsWalletWithMoney.Id);

            return new Tuple<string, WalletDTO>(card.Id, createdWallet);
        }

        protected async Task<PayInCardWebDTO> GetJohnsPayInCardWeb()
        {
            if (BaseTest._johnsPayInCardWeb == null)
            {
                WalletDTO wallet = await this.GetJohnsWallet();
                UserNaturalDTO user = await this.GetJohn();

                PayInCardWebPostDTO payIn = new PayInCardWebPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "https://test.com", CultureCode.FR, CardType.CB_VISA_MASTERCARD);

                BaseTest._johnsPayInCardWeb = await this.Api.PayIns.CreateCardWebAsync(payIn);
            }

            return BaseTest._johnsPayInCardWeb;
        }

        protected async Task<PayInCardWebDTO> GetJohnsNewPayInCardWeb()
        {
            BaseTest._johnsPayInCardWeb = null;

            return await GetJohnsPayInCardWeb();
        }

        protected async Task<PayInCardWebDTO> GetJohnsPayInCardWeb(string walletId)
        {
            if (BaseTest._johnsPayInCardWeb == null)
            {
                UserNaturalDTO user = await this.GetJohn();

                PayInCardWebPostDTO payIn = new PayInCardWebPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, walletId, "https://test.com", CultureCode.FR, CardType.CB_VISA_MASTERCARD)
                {
                    //Add TemplateURLOptionsCard for tests
                    TemplateURLOptionsCard = new TemplateURLOptionsCard { PAYLINEV2 = "https://www.maysite.com/payline_template/" }
                };

                BaseTest._johnsPayInCardWeb = await this.Api.PayIns.CreateCardWebAsync(payIn);
            }

            return BaseTest._johnsPayInCardWeb;
        }

        protected async Task<PayInCardWebDTO> CreateJohnsPayInCardWeb(string walletId)
        {

            UserNaturalDTO user = await this.GetJohn();

            PayInCardWebPostDTO payIn = new PayInCardWebPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, walletId, "https://test.com", CultureCode.FR, CardType.CB_VISA_MASTERCARD);

            return await this.Api.PayIns.CreateCardWebAsync(payIn);
        }

        protected async Task<PayInCardWebDTO> GetNewPayInCardWeb()
        {
            WalletDTO wallet = await this.GetJohnsWallet();
            UserNaturalDTO user = await this.GetJohn();

            PayInCardWebPostDTO payIn = new PayInCardWebPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "https://test.com", CultureCode.FR, CardType.CB_VISA_MASTERCARD);

            BaseTest._johnsPayInCardWeb = await this.Api.PayIns.CreateCardWebAsync(payIn);

            return BaseTest._johnsPayInCardWeb;
        }

        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirect()
        {
            return await GetNewPayInCardDirect(null);
        }

        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirectWithBilling()
        {
            return await GetNewPayInCardDirectWithBilling(null);
        }

        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirectWithBillingAndShipping()
        {
            return await GetNewPayInCardDirectWithBillingAndShipping(null);
        }

        /// <summary>Creates PayIn Card Direct object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>PayIn Card Direct instance returned from API.</returns>
        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirect(String userId)
        {
            return await GetNewPayInCardDirect(userId, null);
        }

        /// <summary>Creates PayIn Card Direct object with billing information.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>PayIn Card Direct instance returned from API.</returns>
        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirectWithBilling(String userId)
        {
            return await GetNewPayInCardDirectWithBilling(userId, null);
        }

        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirectWithBillingAndShipping(String userId)
        {
            return await GetNewPayInCardDirectWithBillingAndShipping(userId, null);
        }

        /// <summary>Creates PayIn Card Direct object.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>PayIn Card Direct instance returned from API.</returns>
        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirect(String userId, string idempotencyKey)
        {

            PayInCardDirectPostDTO payIn = await GetPayInCardDirectPost(userId, idempotencyKey);
            return await this.Api.PayIns.CreateCardDirectAsync(payIn);
        }

        /// <summary>Creates PayIn Card Direct object with billing details.</summary>
        /// <param name="userId">User identifier.</param>
        /// <returns>PayIn Card Direct instance returned from API.</returns>
        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirectWithBilling(String userId, string idempotencyKey)
        {
            Address address = new Address
            {
                AddressLine1 = "Test address line 1",
                AddressLine2 = "Test address line 2",
                City = "Test city",
                Country = CountryIso.RO,
                PostalCode = "65400"
            };

            Billing billing = new Billing
            {
                Address = address,
                FirstName = "John",
                LastName = "Doe"
            };

            PayInCardDirectPostDTO payIn = await GetPayInCardDirectPost(userId, idempotencyKey);
            payIn.Billing = billing;

            return await this.Api.PayIns.CreateCardDirectAsync(payIn);
        }

        protected async Task<PayInCardDirectDTO> GetNewPayInCardDirectWithBillingAndShipping(String userId, string idempotencyKey)
        {
            var address = new Address
            {
                AddressLine1 = "Test address line 1",
                AddressLine2 = "Test address line 2",
                City = "Test city",
                Country = CountryIso.RO,
                PostalCode = "65400"
            };

            var billing = new Billing
            {
                Address = address,
                FirstName = "John",
                LastName = "Doe"
            };

            var shipping = new Shipping
            {
                Address = address,
                FirstName = "John",
                LastName = "Doe"
            };

            var payIn = await GetPayInCardDirectPost(userId, idempotencyKey);
            payIn.Billing = billing;
            payIn.Shipping = shipping;

            return await this.Api.PayIns.CreateCardDirectAsync(payIn);
        }

        protected async Task<PayInCardDirectPostDTO> GetPayInCardDirectPost(String userId, string idempotencyKey)
        {
            WalletDTO wallet = await this.GetJohnsWalletWithMoney();

            if (userId == null)
            {
                UserNaturalDTO user = await this.GetJohn();
                userId = user.Id;
            }

            CardRegistrationPostDTO cardRegistrationPost = new CardRegistrationPostDTO(userId, CurrencyIso.EUR);

            CardRegistrationDTO cardRegistration = await this.Api.CardRegistrations.CreateAsync(idempotencyKey, cardRegistrationPost);

            CardRegistrationPutDTO cardRegistrationPut = new CardRegistrationPutDTO
            {
                RegistrationData = await this.GetPaylineCorrectRegistartionData(cardRegistration)
            };

            cardRegistration = await this.Api.CardRegistrations.UpdateAsync(cardRegistrationPut, cardRegistration.Id);

            CardDTO card = await this.Api.Cards.GetAsync(cardRegistration.CardId);

            // create pay-in CARD DIRECT
            PayInCardDirectPostDTO payIn = new PayInCardDirectPostDTO(cardRegistration.UserId, cardRegistration.UserId,
                    new Money { Amount = 100, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR },
                    wallet.Id, "http://test.com", card.Id);

            // payment type as CARD
            payIn.CardType = card.CardType;

            return payIn;
        }

        protected async Task<PayOutBankWireDTO> GetJohnsPayOutBankWire()
        {
            if (BaseTest._johnsPayOutBankWire == null)
            {
                WalletDTO wallet = await this.GetJohnsWalletWithMoney();
                UserNaturalDTO user = await this.GetJohn();
                BankAccountDTO account = await this.GetJohnsAccount();

                PayOutBankWirePostDTO payOut = new PayOutBankWirePostDTO(user.Id, wallet.Id, new Money { Amount = 10, Currency = CurrencyIso.EUR }, new Money { Amount = 5, Currency = CurrencyIso.EUR }, account.Id, "Johns bank wire ref", PayoutModeRequested.STANDARD);
                payOut.Tag = "DefaultTag";
                payOut.CreditedUserId = user.Id;

                BaseTest._johnsPayOutBankWire = await this.Api.PayOuts.CreateBankWireAsync(payOut);
            }

            return BaseTest._johnsPayOutBankWire;
        }

        /// <summary>Creates PayOut Bank Wire object.</summary>
        /// <returns>PayOut Bank Wire instance returned from API.</returns>
        protected async Task<PayOutBankWireDTO> GetJohnsPayOutForCardDirect()
        {
            if (BaseTest._johnsPayOutForCardDirect == null)
            {
                PayInCardDirectDTO payIn = await this.GetNewPayInCardDirect();
                BankAccountDTO account = await this.GetJohnsAccount();

                PayOutBankWirePostDTO payOut = new PayOutBankWirePostDTO(payIn.AuthorId, payIn.CreditedWalletId, new Money { Amount = 10, Currency = CurrencyIso.EUR },
                    new Money { Amount = 5, Currency = CurrencyIso.EUR }, account.Id, "Johns bank wire ref", PayoutModeRequested.STANDARD)
                {
                    Tag = "DefaultTag",
                    CreditedUserId = payIn.AuthorId
                };

                BaseTest._johnsPayOutForCardDirect = await this.Api.PayOuts.CreateBankWireAsync(payOut);
            }

            return BaseTest._johnsPayOutForCardDirect;
        }

        protected async Task<PayOutBankWireDTO> GetJohnsPayoutBankwire()
        {
            if (_johnsPayOutBankWire != null) 
                return _johnsPayOutBankWire;

            var payIn = await this.GetNewPayInCardDirect();
            var account = await this.GetJohnsAccount();

            var payOut = new PayOutBankWirePostDTO(payIn.AuthorId, payIn.CreditedWalletId, new Money { Amount = 10, Currency = CurrencyIso.EUR },
                new Money { Amount = 5, Currency = CurrencyIso.EUR }, account.Id, "Johns bank wire ref", PayoutModeRequested.STANDARD)
            {
                Tag = "DefaultTag",
                CreditedUserId = payIn.AuthorId
            };

            return await this.Api.PayOuts.CreateBankWireAsync(payOut);
        }

        protected async Task<TransferDTO> GetNewTransfer(WalletDTO walletIn = null)
        {
            WalletDTO walletWithMoney = walletIn;
            if (walletWithMoney == null)
                walletWithMoney = await this.GetJohnsWalletWithMoney();

            UserNaturalDTO user = await this.GetJohn();
            WalletPostDTO walletPost = new WalletPostDTO(new List<string> { user.Id }, "WALLET IN EUR FOR TRANSFER", CurrencyIso.EUR);
            WalletDTO wallet = await this.Api.Wallets.CreateAsync(walletPost);

            TransferPostDTO transfer = new TransferPostDTO(user.Id, user.Id, new Money { Amount = 100, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, walletWithMoney.Id, wallet.Id);
            transfer.Tag = "DefaultTag";

            return await this.Api.Transfers.CreateAsync(transfer);
        }

        /// <summary>Creates refund object for transfer.</summary>
        /// <param name="transfer">Transfer.</param>
        /// <returns>Refund instance returned from API.</returns>
        protected async Task<RefundDTO> GetNewRefundForTransfer(TransferDTO transfer)
        {
            UserNaturalDTO user = await this.GetJohn();

            RefundTransferPostDTO refund = new RefundTransferPostDTO(user.Id);

            return await this.Api.Transfers.CreateRefundAsync(transfer.Id, refund);
        }

        /// <summary>Creates refund object for PayIn.</summary>
        /// <param name="payIn">PayIn entity.</param>
        /// <returns>Refund instance returned from API.</returns>
        protected async Task<RefundDTO> GetNewRefundForPayIn(PayInDTO payIn)
        {
            return await GetNewRefundForPayIn(payIn, null);
        }

        /// <summary>Creates refund object for PayIn.</summary>
        /// <param name="payIn">PayIn entity.</param>
        /// <returns>Refund instance returned from API.</returns>
        protected async Task<RefundDTO> GetNewRefundForPayIn(PayInDTO payIn, string idempotencyKey)
        {
            UserNaturalDTO user = await this.GetJohn();

            Money debitedFunds = new Money
            {
                Amount = payIn.DebitedFunds.Amount,
                Currency = payIn.DebitedFunds.Currency
            };
            Money fees = new Money
            {
                Amount = payIn.Fees.Amount,
                Currency = payIn.Fees.Currency
            };

            RefundPayInPostDTO refund = new RefundPayInPostDTO(user.Id, fees, debitedFunds);
            return await this.Api.PayIns.CreateRefundAsync(idempotencyKey, payIn.Id, refund);
        }

        /// <summary>Creates card registration object.</summary>
        /// <param name="cardType">Card type.</param>
        /// <returns>CardRegistration instance returned from API.</returns>
        protected async Task<CardRegistrationDTO> GetJohnsCardRegistration(CardType cardType = CardType.CB_VISA_MASTERCARD)
        {
            if (BaseTest._johnsCardRegistration == null)
            {
                UserNaturalDTO user = await this.GetJohn();

                CardRegistrationPostDTO cardRegistration = new CardRegistrationPostDTO(user.Id, CurrencyIso.EUR, cardType);
                cardRegistration.Tag = "DefaultTag";

                BaseTest._johnsCardRegistration = await this.Api.CardRegistrations.CreateAsync(cardRegistration);
            }

            return BaseTest._johnsCardRegistration;
        }

        /// <summary>Creates new card registration object.</summary>
        /// <param name="cardType">Card type.</param>
        /// <returns>CardRegistration instance returned from API.</returns>
        protected async Task<CardRegistrationDTO> GetNewJohnsCardRegistration(CardType cardType = CardType.CB_VISA_MASTERCARD)
        {
            BaseTest._johnsCardRegistration = null;

            return await GetJohnsCardRegistration(cardType);
        }

        /// <summary>Creates card registration object.</summary>
        /// <returns>CardPreAuthorization instance returned from API.</returns>
        protected async Task<CardPreAuthorizationDTO> GetJohnsCardPreAuthorization()
        {
            return await GetJohnsCardPreAuthorization(null);
        }

        /// <summary>Creates card registration object.</summary>
        /// <returns>CardPreAuthorization instance returned from API.</returns>
        protected async Task<CardPreAuthorizationDTO> GetJohnsCardPreAuthorization(string idempotencyKey)
        {
            UserNaturalDTO user = await this.GetJohn();
            CardPreAuthorizationPostDTO cardPreAuthorization = await GetPreAuthorization(user.Id);

            return await this.Api.CardPreAuthorizations.CreateAsync(idempotencyKey, cardPreAuthorization);
        }

        protected async Task<CardPreAuthorizationPostDTO> GetPreAuthorization(string userId)
        {
            CardRegistrationPostDTO cardRegistrationPost = new CardRegistrationPostDTO(userId, CurrencyIso.EUR);
            CardRegistrationDTO newCardRegistration = await this.Api.CardRegistrations.CreateAsync(cardRegistrationPost);

            CardRegistrationPutDTO cardRegistrationPut = new CardRegistrationPutDTO();
            string registrationData = await this.GetPaylineCorrectRegistartionData(newCardRegistration);
            cardRegistrationPut.RegistrationData = registrationData;
            CardRegistrationDTO getCardRegistration = await this.Api.CardRegistrations.UpdateAsync(cardRegistrationPut, newCardRegistration.Id);

            CardPreAuthorizationPostDTO cardPreAuthorization = new CardPreAuthorizationPostDTO(userId, new Money { Amount = 100, Currency = CurrencyIso.EUR }, SecureMode.DEFAULT, getCardRegistration.CardId, "http://test.com");

            return cardPreAuthorization;
        }

        protected async Task<KycDocumentDTO> GetJohnsKycDocument()
        {
            if (BaseTest._johnsKycDocument == null)
            {
                var john = await this.GetJohn();
                String johnsId = john.Id;

                BaseTest._johnsKycDocument = await this.Api.Users.CreateKycDocumentAsync(johnsId, KycDocumentType.IDENTITY_PROOF);
            }

            return BaseTest._johnsKycDocument;
        }

        protected async Task<KycDocumentDTO> GetNewKycDocument()
        {
            BaseTest._johnsKycDocument = null;
            return await GetJohnsKycDocument();
        }

        /// <summary>Gets registration data from Payline service.</summary>
        /// <param name="cardRegistration">CardRegistration instance.</param>
        /// <returns>Registration data.</returns>
        protected async Task<string> GetPaylineCorrectRegistartionData(CardRegistrationDTO cardRegistration)
        {
            RestClient client = new RestClient(cardRegistration.CardRegistrationURL);

            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("data", cardRegistration.PreregistrationData);
            request.AddParameter("accessKeyRef", cardRegistration.AccessKey);
            request.AddParameter("cardNumber", "4972485830400056");
            request.AddParameter("cardExpirationDate", "1224");
            request.AddParameter("cardCvx", "123");

            // Payline requires TLS
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            IRestResponse response = await client.ExecuteAsync(request);

            String responseString = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
                return responseString;
            else
                throw new Exception(responseString);
        }

        protected async Task<string> GetPaylineCorrectRegistartionData3DSecure(CardRegistrationDTO cardRegistration)
        {
            RestClient client = new RestClient(cardRegistration.CardRegistrationURL);

            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("data", cardRegistration.PreregistrationData);
            request.AddParameter("accessKeyRef", cardRegistration.AccessKey);
            request.AddParameter("cardNumber", "4970105191923460");
            request.AddParameter("cardExpirationDate", "1224");
            request.AddParameter("cardCvx", "123");

            // Payline requires TLS
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            IRestResponse response = await client.ExecuteAsync(request);

            String responseString = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
                return responseString;
            else
                throw new Exception(responseString);
        }

        protected FileInfo GetFileInfoOfFile(string location)
        {
            bool exit = false;
            var fi = new FileInfo(location);
            var directory = Directory.GetParent(location);
            do
            {
                fi = directory.GetFiles("TestKycPageFile.png", SearchOption.AllDirectories).SingleOrDefault();
                if (fi == null)
                {
                    directory = Directory.GetParent(directory.FullName);
                }
                else
                {
                    exit = true;
                }
            } while (exit == false);

            return fi;
        }

        protected async Task<HookDTO> GetJohnsHook()
        {
            if (BaseTest._johnsHook == null)
            {

                Pagination pagination = new Pagination(1, 1);
                ListPaginated<HookDTO> list = await this.Api.Hooks.GetAllAsync(pagination);

                if (list != null && list.Count > 0 && list[0] != null)
                {
                    BaseTest._johnsHook = list[0];
                }
                else
                {
                    HookPostDTO hook = new HookPostDTO("http://test.com", EventType.PAYIN_NORMAL_CREATED);
                    BaseTest._johnsHook = await this.Api.Hooks.CreateAsync(hook);
                }
            }

            return BaseTest._johnsHook;
        }

        protected async Task<ReportRequestDTO> GetJohnsReport(ReportType reportType)
        {
            if (!BaseTest._johnsReports.ContainsKey(reportType))
            {
                ReportRequestPostDTO reportPost = new ReportRequestPostDTO(ReportType.TRANSACTIONS);
                var reportRequest = await this.Api.Reports.CreateAsync(reportPost);
                BaseTest._johnsReports.Add(reportType, reportRequest);
            }

            return BaseTest._johnsReports[reportType];
        }

        protected async Task<MandateDTO> GetNewMandate()
        {
            var john = await GetJohnsAccount();
            var bankAccountId = john.Id;
            var returnUrl = "http://test.test";
            var mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);
            var mandate = await Api.Mandates.CreateAsync(mandatePost);

            return mandate;
        }

        protected void AssertEqualInputProps<T>(T entity1, T entity2)
        {
            Assert.IsNotNull(entity1);
            Assert.IsNotNull(entity2);

            if (entity1 is UserNaturalDTO && entity2 is UserNaturalDTO)
            {
                Assert.AreEqual((entity1 as UserNaturalDTO).Tag, (entity2 as UserNaturalDTO).Tag);
                Assert.AreEqual((entity1 as UserNaturalDTO).PersonType, (entity2 as UserNaturalDTO).PersonType);
                Assert.AreEqual((entity1 as UserNaturalDTO).FirstName, (entity2 as UserNaturalDTO).FirstName);
                Assert.AreEqual((entity1 as UserNaturalDTO).LastName, (entity2 as UserNaturalDTO).LastName);
                Assert.AreEqual((entity1 as UserNaturalDTO).Email, (entity2 as UserNaturalDTO).Email);
                Assert.AreEqual((entity1 as UserNaturalDTO).Address.AddressLine1, (entity2 as UserNaturalDTO).Address.AddressLine1);
                Assert.AreEqual((entity1 as UserNaturalDTO).Address.AddressLine2, (entity2 as UserNaturalDTO).Address.AddressLine2);
                Assert.AreEqual((entity1 as UserNaturalDTO).Address.City, (entity2 as UserNaturalDTO).Address.City);
                Assert.AreEqual((entity1 as UserNaturalDTO).Address.Country, (entity2 as UserNaturalDTO).Address.Country);
                Assert.AreEqual((entity1 as UserNaturalDTO).Address.PostalCode, (entity2 as UserNaturalDTO).Address.PostalCode);
                Assert.AreEqual((entity1 as UserNaturalDTO).Address.Region, (entity2 as UserNaturalDTO).Address.Region);
                Assert.AreEqual((entity1 as UserNaturalDTO).Birthday, (entity2 as UserNaturalDTO).Birthday);
                Assert.AreEqual((entity1 as UserNaturalDTO).Nationality, (entity2 as UserNaturalDTO).Nationality);
                Assert.AreEqual((entity1 as UserNaturalDTO).CountryOfResidence, (entity2 as UserNaturalDTO).CountryOfResidence);
                Assert.AreEqual((entity1 as UserNaturalDTO).Occupation, (entity2 as UserNaturalDTO).Occupation);
                Assert.AreEqual((entity1 as UserNaturalDTO).IncomeRange, (entity2 as UserNaturalDTO).IncomeRange);
            }
            else if (entity1 is UserLegalDTO && entity2 is UserLegalDTO)
            {
                Assert.AreEqual((entity1 as UserLegalDTO).Tag, (entity2 as UserLegalDTO).Tag);
                Assert.AreEqual((entity1 as UserLegalDTO).PersonType, (entity2 as UserLegalDTO).PersonType);
                Assert.AreEqual((entity1 as UserLegalDTO).Name, (entity2 as UserLegalDTO).Name);
                Assert.AreEqual((entity1 as UserLegalDTO).HeadquartersAddress.AddressLine1, (entity2 as UserLegalDTO).HeadquartersAddress.AddressLine1);
                Assert.AreEqual((entity1 as UserLegalDTO).HeadquartersAddress.AddressLine2, (entity2 as UserLegalDTO).HeadquartersAddress.AddressLine2);
                Assert.AreEqual((entity1 as UserLegalDTO).HeadquartersAddress.City, (entity2 as UserLegalDTO).HeadquartersAddress.City);
                Assert.AreEqual((entity1 as UserLegalDTO).HeadquartersAddress.Country, (entity2 as UserLegalDTO).HeadquartersAddress.Country);
                Assert.AreEqual((entity1 as UserLegalDTO).HeadquartersAddress.PostalCode, (entity2 as UserLegalDTO).HeadquartersAddress.PostalCode);
                Assert.AreEqual((entity1 as UserLegalDTO).HeadquartersAddress.Region, (entity2 as UserLegalDTO).HeadquartersAddress.Region);
                Assert.AreEqual((entity1 as UserLegalDTO).LegalRepresentativeFirstName, (entity2 as UserLegalDTO).LegalRepresentativeFirstName);
                Assert.AreEqual((entity1 as UserLegalDTO).LegalRepresentativeLastName, (entity2 as UserLegalDTO).LegalRepresentativeLastName);
                //Assert.AreEqual("***** TEMPORARY API ISSUE: RETURNED OBJECT MISSES THIS PROP AFTER CREATION *****", (entity1 as UserLegal).LegalRepresentativeAddress, (entity2 as UserLegal).LegalRepresentativeAddress);
                Assert.AreEqual((entity1 as UserLegalDTO).LegalRepresentativeEmail, (entity2 as UserLegalDTO).LegalRepresentativeEmail);
                //Assert.AreEqual("***** TEMPORARY API ISSUE: RETURNED OBJECT HAS THIS PROP CHANGED FROM TIMESTAMP INTO ISO STRING AFTER CREATION *****", (entity1 as UserLegal).LegalRepresentativeBirthday, (entity2 as UserLegal).LegalRepresentativeBirthday);
                Assert.AreEqual((entity1 as UserLegalDTO).LegalRepresentativeBirthday, (entity2 as UserLegalDTO).LegalRepresentativeBirthday);
                Assert.AreEqual((entity1 as UserLegalDTO).LegalRepresentativeNationality, (entity2 as UserLegalDTO).LegalRepresentativeNationality);
                Assert.AreEqual((entity1 as UserLegalDTO).LegalRepresentativeCountryOfResidence, (entity2 as UserLegalDTO).LegalRepresentativeCountryOfResidence);
            }
            else if (entity1 is BankAccountDTO && entity2 is BankAccountDTO)
            {
                Assert.AreEqual((entity1 as BankAccountDTO).Tag, (entity2 as BankAccountDTO).Tag);
                Assert.AreEqual((entity1 as BankAccountDTO).UserId, (entity2 as BankAccountDTO).UserId);
                Assert.AreEqual((entity1 as BankAccountDTO).Type, (entity2 as BankAccountDTO).Type);
                Assert.AreEqual((entity1 as BankAccountDTO).OwnerName, (entity2 as BankAccountDTO).OwnerName);
                Assert.AreEqual((entity1 as BankAccountDTO).OwnerAddress.AddressLine1, (entity2 as BankAccountDTO).OwnerAddress.AddressLine1);
                Assert.AreEqual((entity1 as BankAccountDTO).OwnerAddress.AddressLine2, (entity2 as BankAccountDTO).OwnerAddress.AddressLine2);
                Assert.AreEqual((entity1 as BankAccountDTO).OwnerAddress.City, (entity2 as BankAccountDTO).OwnerAddress.City);
                Assert.AreEqual((entity1 as BankAccountDTO).OwnerAddress.Country, (entity2 as BankAccountDTO).OwnerAddress.Country);
                Assert.AreEqual((entity1 as BankAccountDTO).OwnerAddress.PostalCode, (entity2 as BankAccountDTO).OwnerAddress.PostalCode);
                Assert.AreEqual((entity1 as BankAccountDTO).OwnerAddress.Region, (entity2 as BankAccountDTO).OwnerAddress.Region);
                if ((entity1 as BankAccountDTO).Type == BankAccountType.IBAN)
                {
                    Assert.AreEqual((entity1 as BankAccountIbanDTO).IBAN, (entity2 as BankAccountIbanDTO).IBAN);
                    Assert.AreEqual((entity1 as BankAccountIbanDTO).BIC, (entity2 as BankAccountIbanDTO).BIC);
                }
                else if ((entity1 as BankAccountDTO).Type == BankAccountType.GB)
                {
                    Assert.AreEqual((entity1 as BankAccountGbDTO).AccountNumber, (entity2 as BankAccountGbDTO).AccountNumber);
                    Assert.AreEqual((entity1 as BankAccountGbDTO).SortCode, (entity2 as BankAccountGbDTO).SortCode);
                }
                else if ((entity1 as BankAccountDTO).Type == BankAccountType.US)
                {
                    Assert.AreEqual((entity1 as BankAccountUsDTO).AccountNumber, (entity2 as BankAccountUsDTO).AccountNumber);
                    Assert.AreEqual((entity1 as BankAccountUsDTO).ABA, (entity2 as BankAccountUsDTO).ABA);
                }
                else if ((entity1 as BankAccountDTO).Type == BankAccountType.CA)
                {
                    Assert.AreEqual((entity1 as BankAccountCaDTO).AccountNumber, (entity2 as BankAccountCaDTO).AccountNumber);
                    Assert.AreEqual((entity1 as BankAccountCaDTO).BankName, (entity2 as BankAccountCaDTO).BankName);
                    Assert.AreEqual((entity1 as BankAccountCaDTO).InstitutionNumber, (entity2 as BankAccountCaDTO).InstitutionNumber);
                    Assert.AreEqual((entity1 as BankAccountCaDTO).BranchCode, (entity2 as BankAccountCaDTO).BranchCode);
                }
                else if ((entity1 as BankAccountDTO).Type == BankAccountType.OTHER)
                {
                    Assert.AreEqual((entity1 as BankAccountOtherDTO).AccountNumber, (entity2 as BankAccountOtherDTO).AccountNumber);
                    Assert.AreEqual((entity1 as BankAccountOtherDTO).Type, (entity2 as BankAccountOtherDTO).Type);
                    Assert.AreEqual((entity1 as BankAccountOtherDTO).Country, (entity2 as BankAccountOtherDTO).Country);
                    Assert.AreEqual((entity1 as BankAccountOtherDTO).BIC, (entity2 as BankAccountOtherDTO).BIC);
                }
            }
            else if (entity1 is PayInDTO && entity2 is PayInDTO)
            {
                Assert.AreEqual((entity1 as PayInDTO).Tag, (entity2 as PayInDTO).Tag);
                Assert.AreEqual((entity1 as PayInDTO).AuthorId, (entity2 as PayInDTO).AuthorId);
                Assert.AreEqual((entity1 as PayInDTO).CreditedUserId, (entity2 as PayInDTO).CreditedUserId);

                AssertEqualInputProps((entity1 as PayInDTO).DebitedFunds, (entity2 as PayInDTO).DebitedFunds);
                AssertEqualInputProps((entity1 as PayInDTO).CreditedFunds, (entity2 as PayInDTO).CreditedFunds);
                AssertEqualInputProps((entity1 as PayInDTO).Fees, (entity2 as PayInDTO).Fees);
            }
            else if (typeof(T) == typeof(CardDTO))
            {
                Assert.AreEqual((entity1 as CardDTO).ExpirationDate, (entity2 as CardDTO).ExpirationDate);
                Assert.AreEqual((entity1 as CardDTO).Alias, (entity2 as CardDTO).Alias);
                Assert.AreEqual((entity1 as CardDTO).CardType, (entity2 as CardDTO).CardType);
                Assert.AreEqual((entity1 as CardDTO).Currency, (entity2 as CardDTO).Currency);
            }
            else if (typeof(T) == typeof(PayOutDTO))
            {
                Assert.AreEqual((entity1 as PayOutDTO).Tag, (entity2 as PayOutDTO).Tag);
                Assert.AreEqual((entity1 as PayOutDTO).AuthorId, (entity2 as PayOutDTO).AuthorId);
                Assert.AreEqual((entity1 as PayOutDTO).CreditedUserId, (entity2 as PayOutDTO).CreditedUserId);

                AssertEqualInputProps((entity1 as PayOutDTO).DebitedFunds, (entity2 as PayOutDTO).DebitedFunds);
                AssertEqualInputProps((entity1 as PayOutDTO).CreditedFunds, (entity2 as PayOutDTO).CreditedFunds);
                AssertEqualInputProps((entity1 as PayOutDTO).Fees, (entity2 as PayOutDTO).Fees);
            }
            else if (typeof(T) == typeof(TransferDTO))
            {
                Assert.AreEqual((entity1 as TransferDTO).Tag, (entity2 as TransferDTO).Tag);
                Assert.AreEqual((entity1 as TransferDTO).AuthorId, (entity2 as TransferDTO).AuthorId);
                Assert.AreEqual((entity1 as TransferDTO).CreditedUserId, (entity2 as TransferDTO).CreditedUserId);

                AssertEqualInputProps((entity1 as TransferDTO).DebitedFunds, (entity2 as TransferDTO).DebitedFunds);
                AssertEqualInputProps((entity1 as TransferDTO).CreditedFunds, (entity2 as TransferDTO).CreditedFunds);
                AssertEqualInputProps((entity1 as TransferDTO).Fees, (entity2 as TransferDTO).Fees);
            }
            else if (typeof(T) == typeof(TransactionDTO))
            {
                Assert.AreEqual((entity1 as TransactionDTO).Tag, (entity2 as TransactionDTO).Tag);

                AssertEqualInputProps((entity1 as TransactionDTO).DebitedFunds, (entity2 as TransactionDTO).DebitedFunds);
                AssertEqualInputProps((entity1 as TransactionDTO).Fees, (entity2 as TransactionDTO).Fees);
                AssertEqualInputProps((entity1 as TransactionDTO).CreditedFunds, (entity2 as TransactionDTO).CreditedFunds);

                Assert.AreEqual((entity1 as TransactionDTO).Status, (entity2 as TransactionDTO).Status);
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
