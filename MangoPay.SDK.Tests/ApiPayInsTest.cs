using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using NUnit.Framework;
using System;

namespace MangoPay.SDK.Tests
{
    [TestFixture]
    public class ApiPayInsTest : BaseTest
    {
        [Test]
        public void Test_PayIns_Create_CardWeb()
        {
            try
            {
                PayInDTO payIn = null;
                payIn = this.GetJohnsPayInCardWeb();

                Assert.IsTrue(payIn.Id.Length > 0);
                Assert.IsTrue(payIn.PaymentType == PayInPaymentType.CARD);
                Assert.IsTrue(payIn.ExecutionType == PayInExecutionType.WEB);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_Get_CardWeb()
        {
            try
            {
                PayInDTO payIn = null;
                payIn = this.GetJohnsPayInCardWeb();

                PayInDTO getPayIn = this.Api.PayIns.Get(payIn.Id);

                Assert.IsTrue(payIn.Id == getPayIn.Id);
                Assert.IsTrue(payIn.PaymentType == PayInPaymentType.CARD);
                Assert.IsTrue(payIn.ExecutionType == PayInExecutionType.WEB);

                AssertEqualInputProps(payIn, getPayIn);

                Assert.IsTrue(getPayIn.Status == TransactionStatus.CREATED);
                Assert.IsNull(getPayIn.ExecutionDate);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		[Test]
		public void Test_PayIns_Create_PayPal()
		{
			try
			{
				PayInDTO payIn = null;
				WalletDTO wallet = this.GetJohnsWallet();
				UserNaturalDTO user = this.GetJohn();

				PayInPayPalPostDTO payInPost = new PayInPayPalPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "http://test/test");

				payIn = this.Api.PayIns.CreatePayPal(payInPost);

				Assert.IsTrue(payIn.Id.Length > 0);
				Assert.IsTrue(payIn.PaymentType == PayInPaymentType.PAYPAL);
				Assert.IsTrue(payIn.ExecutionType == PayInExecutionType.WEB);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_PayIns_Create_PayPal_WithShippingAddress()
		{
			try
			{
				PayInPayPalDTO payIn = null;
				WalletDTO wallet = this.GetJohnsWallet();
				UserNaturalDTO user = this.GetJohn();
				Address AddressForShippingAddress = new Address
				{
					AddressLine1 = "Address line 1",
					AddressLine2 = "Address line 2",
					City = "City",
					Country = CountryIso.PL,
					PostalCode = "11222",
					Region = "Region"
				};
				PayInPayPalPostDTO payInPost = new PayInPayPalPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "http://test/test");
				payInPost.ShippingAddress = new ShippingAddress("recipient name", AddressForShippingAddress);

				payIn = this.Api.PayIns.CreatePayPal(payInPost);

				Assert.IsNotNull(payIn.ShippingAddress);
				Assert.AreEqual("recipient name", payIn.ShippingAddress.RecipientName);
				Assert.IsNotNull(payIn.ShippingAddress.Address);				
				Assert.AreEqual("Address line 1", payIn.ShippingAddress.Address.AddressLine1);
				Assert.AreEqual("Address line 2", payIn.ShippingAddress.Address.AddressLine2);
				Assert.AreEqual("City", payIn.ShippingAddress.Address.City);
				Assert.AreEqual(CountryIso.PL, payIn.ShippingAddress.Address.Country);
				Assert.AreEqual("11222", payIn.ShippingAddress.Address.PostalCode);
				Assert.AreEqual("Region", payIn.ShippingAddress.Address.Region);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
        public void Test_PayIns_Create_CardDirect()
        {
            try
            {
                WalletDTO johnWallet = this.GetJohnsWalletWithMoney();
                WalletDTO beforeWallet = this.Api.Wallets.Get(johnWallet.Id);

                PayInDTO payIn = this.GetNewPayInCardDirect();
                WalletDTO wallet = this.Api.Wallets.Get(johnWallet.Id);
                UserNaturalDTO user = this.GetJohn();

                Assert.IsTrue(payIn.Id.Length > 0);
                Assert.AreEqual(wallet.Id, payIn.CreditedWalletId);
                Assert.AreEqual(PayInPaymentType.CARD, payIn.PaymentType);
                Assert.AreEqual(PayInExecutionType.DIRECT, payIn.ExecutionType);
                Assert.IsTrue(payIn.DebitedFunds is Money);
                Assert.IsTrue(payIn.CreditedFunds is Money);
                Assert.IsTrue(payIn.Fees is Money);
                Assert.AreEqual(user.Id, payIn.AuthorId);
                Assert.IsTrue(wallet.Balance.Amount == beforeWallet.Balance.Amount + payIn.CreditedFunds.Amount);
                Assert.AreEqual(TransactionStatus.SUCCEEDED, payIn.Status);
                Assert.AreEqual(TransactionType.PAYIN, payIn.Type);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_Get_CardDirect()
        {
            try
            {
                PayInCardDirectDTO payIn = this.GetNewPayInCardDirect();

                PayInCardDirectDTO getPayIn = this.Api.PayIns.GetCardDirect(payIn.Id);

                Assert.IsTrue(payIn.Id == getPayIn.Id);
                Assert.IsTrue(payIn.PaymentType == PayInPaymentType.CARD);
                Assert.IsTrue(payIn.ExecutionType == PayInExecutionType.DIRECT);
                AssertEqualInputProps(payIn, getPayIn);
                Assert.IsNotNull(getPayIn.CardId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_CreateRefund_CardDirect()
        {
            try
            {
                PayInDTO payIn = this.GetNewPayInCardDirect();
                WalletDTO wallet = this.GetJohnsWalletWithMoney();
                WalletDTO walletBefore = this.Api.Wallets.Get(wallet.Id);

                RefundDTO refund = this.GetNewRefundForPayIn(payIn);
                WalletDTO walletAfter = this.Api.Wallets.Get(wallet.Id);

                Assert.IsTrue(refund.Id.Length > 0);
                Assert.IsTrue(refund.DebitedFunds.Amount == payIn.DebitedFunds.Amount);
                Assert.IsTrue(walletBefore.Balance.Amount == (walletAfter.Balance.Amount + payIn.DebitedFunds.Amount));
                Assert.AreEqual(TransactionType.PAYOUT, refund.Type);
                Assert.AreEqual(TransactionNature.REFUND, refund.Nature);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_PreAuthorizedDirect()
        {
            try
            {
                CardPreAuthorizationDTO cardPreAuthorization = this.GetJohnsCardPreAuthorization();
                WalletDTO wallet = this.GetJohnsWalletWithMoney();
                UserNaturalDTO user = this.GetJohn();

                // create pay-in PRE-AUTHORIZED DIRECT
                PayInPreauthorizedDirectPostDTO payIn = new PayInPreauthorizedDirectPostDTO(user.Id, new Money { Amount = 10000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, cardPreAuthorization.Id);
               
                payIn.SecureModeReturnURL = "http://test.com";

                PayInPreauthorizedDirectDTO createPayIn = this.Api.PayIns.CreatePreauthorizedDirect(payIn);

                Assert.IsTrue("" != createPayIn.Id);
                Assert.AreEqual(wallet.Id, createPayIn.CreditedWalletId);
                Assert.AreEqual(PayInPaymentType.PREAUTHORIZED, createPayIn.PaymentType);
                Assert.AreEqual(PayInExecutionType.DIRECT, createPayIn.ExecutionType);
                Assert.IsTrue(createPayIn.DebitedFunds is Money);
                Assert.IsTrue(createPayIn.CreditedFunds is Money);
                Assert.IsTrue(createPayIn.Fees is Money);
                Assert.AreEqual(user.Id, createPayIn.AuthorId);
                Assert.AreEqual(TransactionStatus.SUCCEEDED, createPayIn.Status);
                Assert.AreEqual(TransactionType.PAYIN, createPayIn.Type);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_BankWireDirect_Create()
        {
            try
            {
                WalletDTO wallet = this.GetJohnsWallet();
                UserNaturalDTO user = this.GetJohn();

                // create pay-in BANKWIRE DIRECT
                PayInBankWireDirectPostDTO payIn = new PayInBankWireDirectPostDTO(user.Id, wallet.Id, new Money { Amount = 10000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR });
                payIn.CreditedWalletId = wallet.Id;
                payIn.AuthorId = user.Id;

                PayInDTO createPayIn = this.Api.PayIns.CreateBankWireDirect(payIn);

                Assert.IsTrue(createPayIn.Id.Length > 0);
                Assert.AreEqual(wallet.Id, createPayIn.CreditedWalletId);
                Assert.AreEqual(PayInPaymentType.BANK_WIRE, createPayIn.PaymentType);
                Assert.AreEqual(PayInExecutionType.DIRECT, createPayIn.ExecutionType);
                Assert.AreEqual(user.Id, createPayIn.AuthorId);
                Assert.AreEqual(TransactionStatus.CREATED, createPayIn.Status);
                Assert.AreEqual(TransactionType.PAYIN, createPayIn.Type);
                Assert.IsNotNull(((PayInBankWireDirectDTO)createPayIn).WireReference);
                Assert.AreEqual(((PayInBankWireDirectDTO)createPayIn).BankAccount.Type, BankAccountType.IBAN);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

		/*
		 * Uncomment the attribute below to test payins with a mandate
		 * This test needs your manual confirmation on the web page (see note in test's body)
		 */
		//[Test]
		public void Test_PayIns_MandateDirect_Create_Get()
		{
			try
			{
				WalletDTO wallet = this.GetJohnsWallet();
				UserNaturalDTO user = this.GetJohn();

				string bankAccountId = this.GetJohnsAccount().Id;
				string returnUrl = "http://test.test";
				MandatePostDTO mandatePost = new MandatePostDTO(bankAccountId, CultureCode.EN, returnUrl);
				MandateDTO mandate = this.Api.Mandates.Create(mandatePost);

				/*	
				 *	! IMPORTANT NOTE !
				 *	
				 *	In order to make this test pass, at this place you have to set a breakpoint,
				 *	navigate to URL the mandate.RedirectURL property points to and click "CONFIRM" button.
				 * 
				 */

				PayInMandateDirectPostDTO payIn = new PayInMandateDirectPostDTO(user.Id, new Money { Amount = 10000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "http://test.test", mandate.Id);

				PayInDTO createPayIn = this.Api.PayIns.CreateMandateDirectDebit(payIn);

				Assert.IsNotNull(createPayIn);
				Assert.AreNotEqual(TransactionStatus.FAILED, createPayIn.Status, "In order to make this test pass, after creating mandate and before creating the payin you have to navigate to URL the mandate.RedirectURL property points to and click CONFIRM button.");

				Assert.IsTrue(createPayIn.Id.Length > 0);
				Assert.AreEqual(wallet.Id, createPayIn.CreditedWalletId);
				Assert.AreEqual(PayInPaymentType.DIRECT_DEBIT, createPayIn.PaymentType);
				Assert.AreEqual(PayInExecutionType.DIRECT, createPayIn.ExecutionType);
				Assert.AreEqual(user.Id, createPayIn.AuthorId);
				Assert.AreEqual(TransactionStatus.CREATED, createPayIn.Status);
				Assert.AreEqual(TransactionType.PAYIN, createPayIn.Type);
				Assert.IsNotNull(((PayInMandateDirectDTO)createPayIn).MandateId);
				Assert.AreEqual(((PayInMandateDirectDTO)createPayIn).MandateId, mandate.Id);

				PayInMandateDirectDTO getPayIn = this.Api.PayIns.GetMandateDirectDebit(createPayIn.Id);

				Assert.IsNotNull(getPayIn);
				Assert.IsTrue(getPayIn.Id == createPayIn.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

        [Test]
        public void Test_PayIns_BankWireDirect_Get()
        {
            try
            {
                WalletDTO wallet = this.GetJohnsWallet();
                UserNaturalDTO user = this.GetJohn();

                // create pay-in BANKWIRE DIRECT
                PayInBankWireDirectPostDTO payIn = new PayInBankWireDirectPostDTO(user.Id, wallet.Id, new Money { Amount = 10000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR });
                payIn.CreditedWalletId = wallet.Id;
                payIn.AuthorId = user.Id;

                PayInBankWireDirectDTO createdPayIn = this.Api.PayIns.CreateBankWireDirect(payIn);

                PayInBankWireDirectDTO getPayIn = this.Api.PayIns.GetBankWireDirect(createdPayIn.Id);

                Assert.AreEqual(getPayIn.Id, createdPayIn.Id);
                Assert.AreEqual(PayInPaymentType.BANK_WIRE, getPayIn.PaymentType);
                Assert.AreEqual(PayInExecutionType.DIRECT, getPayIn.ExecutionType);
                Assert.AreEqual(user.Id, getPayIn.AuthorId);
                Assert.AreEqual(TransactionType.PAYIN, getPayIn.Type);
                Assert.IsNotNull(getPayIn.WireReference);
                Assert.AreEqual(getPayIn.BankAccount.Type, BankAccountType.IBAN);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_DirectDebit_Create_Get()
        {
            WalletDTO wallet = this.GetJohnsWallet();
            UserNaturalDTO user = this.GetJohn();
            // create pay-in DIRECT DEBIT
            PayInDirectDebitPostDTO payIn = new PayInDirectDebitPostDTO(user.Id, new Money { Amount = 10000, Currency = CurrencyIso.EUR }, new Money { Amount = 100, Currency = CurrencyIso.EUR }, wallet.Id, "http://www.mysite.com/returnURL/", CultureCode.FR, DirectDebitType.GIROPAY);

            payIn.TemplateURLOptions = new TemplateURLOptions { PAYLINE = "https://www.maysite.com/payline_template/" };
            payIn.Tag = "DirectDebit test tag";

            PayInDirectDebitDTO createPayIn = this.Api.PayIns.CreateDirectDebit(payIn);

            Assert.IsNotNull(createPayIn);
            Assert.IsTrue(createPayIn.Id.Length > 0);
            Assert.AreEqual(wallet.Id, createPayIn.CreditedWalletId);
            Assert.IsTrue(createPayIn.PaymentType == PayInPaymentType.DIRECT_DEBIT);
            Assert.IsTrue(createPayIn.DirectDebitType == DirectDebitType.GIROPAY);
            Assert.IsTrue(createPayIn.Culture == CultureCode.FR);
            Assert.AreEqual(user.Id, createPayIn.AuthorId);
            Assert.IsTrue(createPayIn.Status == TransactionStatus.CREATED);
            Assert.IsTrue(createPayIn.Type == TransactionType.PAYIN);
            Assert.IsNotNull(createPayIn.DebitedFunds);
            Assert.IsTrue(createPayIn.DebitedFunds is Money);
            Assert.AreEqual(10000, createPayIn.DebitedFunds.Amount);
            Assert.IsTrue(createPayIn.DebitedFunds.Currency == CurrencyIso.EUR);

            Assert.IsNotNull(createPayIn.CreditedFunds);
            Assert.IsTrue(createPayIn.CreditedFunds is Money);
            Assert.AreEqual(9900, createPayIn.CreditedFunds.Amount);
            Assert.IsTrue(createPayIn.CreditedFunds.Currency == CurrencyIso.EUR);

            Assert.IsNotNull(createPayIn.Fees);
            Assert.IsTrue(createPayIn.Fees is Money);
            Assert.AreEqual(100, createPayIn.Fees.Amount);
            Assert.IsTrue(createPayIn.Fees.Currency == CurrencyIso.EUR);

            Assert.IsNotNull(createPayIn.ReturnURL);
            Assert.IsNotNull(createPayIn.RedirectURL);
            Assert.IsNotNull(createPayIn.TemplateURL);


            PayInDirectDebitDTO getPayIn = this.Api.PayIns.GetDirectDebit(createPayIn.Id);

            Assert.IsNotNull(getPayIn);
            Assert.IsTrue(getPayIn.Id == createPayIn.Id);
            Assert.IsTrue(getPayIn.Tag == createPayIn.Tag);
        }

		[Test]
		public void Test_PayIns_Get_PayPal()
		{
			try
			{
				PayInDTO payIn = null;
				WalletDTO wallet = this.GetJohnsWallet();
				UserNaturalDTO user = this.GetJohn();

				PayInPayPalPostDTO payInPost = new PayInPayPalPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "http://test/test");

				payIn = this.Api.PayIns.CreatePayPal(payInPost);

				Assert.IsTrue(payIn.Id.Length > 0);
				Assert.IsTrue(payIn.PaymentType == PayInPaymentType.PAYPAL);
				Assert.IsTrue(payIn.ExecutionType == PayInExecutionType.WEB);

				PayInPayPalDTO getPayIn = this.Api.PayIns.GetPayPal(payIn.Id);

				Assert.IsNotNull(getPayIn);
				Assert.IsTrue(getPayIn.Id == payIn.Id);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[Test]
		public void Test_PayIns_Get_PayPal_WithShippingAddress()
		{
			try
			{
				PayInDTO payIn = null;
				WalletDTO wallet = this.GetJohnsWallet();
				UserNaturalDTO user = this.GetJohn();
				Address AddressForShippingAddress = new Address
				{
					AddressLine1 = "Address line 1",
					AddressLine2 = "Address line 2",
					City = "City",
					Country = CountryIso.PL,
					PostalCode = "11222",
					Region = "Region"
				};
				PayInPayPalPostDTO payInPost = new PayInPayPalPostDTO(user.Id, new Money { Amount = 1000, Currency = CurrencyIso.EUR }, new Money { Amount = 0, Currency = CurrencyIso.EUR }, wallet.Id, "http://test/test");
				payInPost.ShippingAddress = new ShippingAddress("recipient name", AddressForShippingAddress);
				payIn = this.Api.PayIns.CreatePayPal(payInPost);

				PayInPayPalDTO getPayIn = this.Api.PayIns.GetPayPal(payIn.Id);

				Assert.IsNotNull(getPayIn.ShippingAddress);
				Assert.AreEqual("recipient name", getPayIn.ShippingAddress.RecipientName);
				Assert.IsNotNull(getPayIn.ShippingAddress.Address);
				Assert.AreEqual("Address line 1", getPayIn.ShippingAddress.Address.AddressLine1);
				Assert.AreEqual("Address line 2", getPayIn.ShippingAddress.Address.AddressLine2);
				Assert.AreEqual("City", getPayIn.ShippingAddress.Address.City);
				Assert.AreEqual(CountryIso.PL, getPayIn.ShippingAddress.Address.Country);
				Assert.AreEqual("11222", getPayIn.ShippingAddress.Address.PostalCode);
				Assert.AreEqual("Region", getPayIn.ShippingAddress.Address.Region);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
