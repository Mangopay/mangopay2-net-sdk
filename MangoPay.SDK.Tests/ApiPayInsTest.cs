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
                payIn = this.GetJohnsPayInCardWeb
		();

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
        public void Test_Payins_CardDirect_Create_WithBilling()
        {
            try
            {
                WalletDTO johnWallet = this.GetJohnsWalletWithMoney();
                WalletDTO wallet = this.Api.Wallets.Get(johnWallet.Id);
                UserNaturalDTO user = this.GetJohn();

                PayInCardDirectDTO payIn = this.GetNewPayInCardDirectWithBilling();

                Assert.IsTrue(payIn.Id.Length > 0);
                Assert.AreEqual(wallet.Id, payIn.CreditedWalletId);
                Assert.AreEqual(PayInPaymentType.CARD, payIn.PaymentType);
                Assert.AreEqual(PayInExecutionType.DIRECT, payIn.ExecutionType);
                Assert.IsTrue(payIn.DebitedFunds is Money);
                Assert.IsTrue(payIn.CreditedFunds is Money);
                Assert.IsTrue(payIn.Fees is Money);
                Assert.AreEqual(user.Id, payIn.AuthorId);
                Assert.AreEqual(TransactionStatus.SUCCEEDED, payIn.Status);
                Assert.AreEqual(TransactionType.PAYIN, payIn.Type);
                Assert.IsNotNull(payIn.Billing);
                Assert.IsNotNull(payIn.SecurityInfo);
                Assert.IsNotNull(payIn.SecurityInfo.AVSResult);
                Assert.AreEqual(payIn.SecurityInfo.AVSResult, AVSResult.NO_CHECK);
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
        public void TestApplePayIn()
        {
            var wallet = GetJohnsWallet();
            var user = GetMatrix();
            var paymentData = new PaymentData
            {
                Network = "VISA",
                TransactionId = "061EB32181A2D9CA42AD16031B476EEBAA62A9A095AD660E2759FBA52B51A61",
                TokenData = "{\"version\":\"EC_v1\"," +
                            "\"data\":\"w4HMBVqNC9ghPP4zncTA\\/0oQAsduERfsx78oxgniynNjZLANTL6+0koEtkQnW\\/K38Zew8qV1GLp+fLHo+qCBpiKCIwlz3eoFBTbZU+8pYcjaeIYBX9SOxcwxXsNGrGLk+kBUqnpiSIPaAG1E+WPT8R1kjOCnGvtdombvricwRTQkGjtovPfzZo8LzD3ZQJnHMsWJ8QYDLyr\\/ZN9gtLAtsBAMvwManwiaG3pOIWpyeOQOb01YcEVO16EZBjaY4x4C\\/oyFLWDuKGvhbJwZqWh1d1o9JT29QVmvy3Oq2JEjq3c3NutYut4rwDEP4owqI40Nb7mP2ebmdNgnYyWfPmkRfDCRHIWtbMC35IPg5313B1dgXZ2BmyZRXD5p+mr67vAk7iFfjEpu3GieFqwZrTl3\\/pI5V8Sxe3SIYKgT5Hr7ow==\"," +
                            "\"signature\":\"MIAGCSqGSIb3DQEHAqCAMIACAQExDzANBglghkgBZQMEAgEFADCABgkqhkiG9w0BBwEAAKCAMIID5jCCA4ugAwIBAgIIaGD2mdnMpw8wCgYIKoZIzj0EAwIwejEuMCwGA1UEAwwlQXBwbGUgQXBwbGljYXRpb24gSW50ZWdyYXRpb24gQ0EgLSBHMzEmMCQGA1UECwwdQXBwbGUgQ2VydGlmaWNhdGlvbiBBdXRob3JpdHkxEzARBgNVBAoMCkFwcGxlIEluYy4xCzAJBgNVBAYTAlVTMB4XDTE2MDYwMzE4MTY0MFoXDTIxMDYwMjE4MTY0MFowYjEoMCYGA1UEAwwfZWNjLXNtcC1icm9rZXItc2lnbl9VQzQtU0FOREJPWDEUMBIGA1UECwwLaU9TIFN5c3RlbXMxEzARBgNVBAoMCkFwcGxlIEluYy4xCzAJBgNVBAYTAlVTMFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEgjD9q8Oc914gLFDZm0US5jfiqQHdbLPgsc1LUmeY+M9OvegaJajCHkwz3c6OKpbC9q+hkwNFxOh6RCbOlRsSlaOCAhEwggINMEUGCCsGAQUFBwEBBDkwNzA1BggrBgEFBQcwAYYpaHR0cDovL29jc3AuYXBwbGUuY29tL29jc3AwNC1hcHBsZWFpY2EzMDIwHQYDVR0OBBYEFAIkMAua7u1GMZekplopnkJxghxFMAwGA1UdEwEB\\/wQCMAAwHwYDVR0jBBgwFoAUI\\/JJxE+T5O8n5sT2KGw\\/orv9LkswggEdBgNVHSAEggEUMIIBEDCCAQwGCSqGSIb3Y2QFATCB\\/jCBwwYIKwYBBQUHAgIwgbYMgbNSZWxpYW5jZSBvbiB0aGlzIGNlcnRpZmljYXRlIGJ5IGFueSBwYXJ0eSBhc3N1bWVzIGFjY2VwdGFuY2Ugb2YgdGhlIHRoZW4gYXBwbGljYWJsZSBzdGFuZGFyZCB0ZXJtcyBhbmQgY29uZGl0aW9ucyBvZiB1c2UsIGNlcnRpZmljYXRlIHBvbGljeSBhbmQgY2VydGlmaWNhdGlvbiBwcmFjdGljZSBzdGF0ZW1lbnRzLjA2BggrBgEFBQcCARYqaHR0cDovL3d3dy5hcHBsZS5jb20vY2VydGlmaWNhdGVhdXRob3JpdHkvMDQGA1UdHwQtMCswKaAnoCWGI2h0dHA6Ly9jcmwuYXBwbGUuY29tL2FwcGxlYWljYTMuY3JsMA4GA1UdDwEB\\/wQEAwIHgDAPBgkqhkiG92NkBh0EAgUAMAoGCCqGSM49BAMCA0kAMEYCIQDaHGOui+X2T44R6GVpN7m2nEcr6T6sMjOhZ5NuSo1egwIhAL1a+\\/hp88DKJ0sv3eT3FxWcs71xmbLKD\\/QJ3mWagrJNMIIC7jCCAnWgAwIBAgIISW0vvzqY2pcwCgYIKoZIzj0EAwIwZzEbMBkGA1UEAwwSQXBwbGUgUm9vdCBDQSAtIEczMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwHhcNMTQwNTA2MjM0NjMwWhcNMjkwNTA2MjM0NjMwWjB6MS4wLAYDVQQDDCVBcHBsZSBBcHBsaWNhdGlvbiBJbnRlZ3JhdGlvbiBDQSAtIEczMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwWTATBgcqhkjOPQIBBggqhkjOPQMBBwNCAATwFxGEGddkhdUaXiWBB3bogKLv3nuuTeCN\\/EuT4TNW1WZbNa4i0Jd2DSJOe7oI\\/XYXzojLdrtmcL7I6CmE\\/1RFo4H3MIH0MEYGCCsGAQUFBwEBBDowODA2BggrBgEFBQcwAYYqaHR0cDovL29jc3AuYXBwbGUuY29tL29jc3AwNC1hcHBsZXJvb3RjYWczMB0GA1UdDgQWBBQj8knET5Pk7yfmxPYobD+iu\\/0uSzAPBgNVHRMBAf8EBTADAQH\\/MB8GA1UdIwQYMBaAFLuw3qFYM4iapIqZ3r6966\\/ayySrMDcGA1UdHwQwMC4wLKAqoCiGJmh0dHA6Ly9jcmwuYXBwbGUuY29tL2FwcGxlcm9vdGNhZzMuY3JsMA4GA1UdDwEB\\/wQEAwIBBjAQBgoqhkiG92NkBgIOBAIFADAKBggqhkjOPQQDAgNnADBkAjA6z3KDURaZsYb7NcNWymK\\/9Bft2Q91TaKOvvGcgV5Ct4n4mPebWZ+Y1UENj53pwv4CMDIt1UQhsKMFd2xd8zg7kGf9F3wsIW2WT8ZyaYISb1T4en0bmcubCYkhYQaZDwmSHQAAMYIBizCCAYcCAQEwgYYwejEuMCwGA1UEAwwlQXBwbGUgQXBwbGljYXRpb24gSW50ZWdyYXRpb24gQ0EgLSBHMzEmMCQGA1UECwwdQXBwbGUgQ2VydGlmaWNhdGlvbiBBdXRob3JpdHkxEzARBgNVBAoMCkFwcGxlIEluYy4xCzAJBgNVBAYTAlVTAghoYPaZ2cynDzANBglghkgBZQMEAgEFAKCBlTAYBgkqhkiG9w0BCQMxCwYJKoZIhvcNAQcBMBwGCSqGSIb3DQEJBTEPFw0xOTA1MjMxMTA1MDdaMCoGCSqGSIb3DQEJNDEdMBswDQYJYIZIAWUDBAIBBQChCgYIKoZIzj0EAwIwLwYJKoZIhvcNAQkEMSIEIIvfGVQYBeOilcB7GNI8m8+FBVZ28QfA6BIXaggBja2PMAoGCCqGSM49BAMCBEYwRAIgU01yYfjlx9bvGeC5CU2RS5KBEG+15HH9tz\\/sg3qmQ14CID4F4ZJwAz+tXAUcAIzoMpYSnM8YBlnGJSTSp+LhspenAAAAAAAA\"," +
                            "\"header\":" +
                            "{\"ephemeralPublicKey\":\"MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE0rs3wRpirXjPbFDQfPRdfEzRIZDWm0qn7Y0HB0PNzV1DDKfpYrnhRb4GEhBF\\/oEXBOe452PxbCnN1qAlqcSUWw==\"," +
                            "\"publicKeyHash\":\"saPRAqS7TZ4bAYwzBj8ezDDC55ZolyH1FL+Xc8fd93o=\"," +
                            "\"transactionId\":\"b061eb32181a2d9ca42ad16031b476eebaa62a9a095ad660e2759fba52b51a61\"}}"
            };
            var applePayIn = new ApplePayDirectPayInPostDTO
            {
                CreditedWalletId = wallet.Id,
                AuthorId = user.Id,
                CreditedUserId = user.Id,
                DebitedFunds = new Money
                {
                    Amount = 199,
                    Currency = CurrencyIso.EUR
                },
                Fees = new Money
                {
                    Amount = 1,
                    Currency = CurrencyIso.EUR
                },
                Tag = "Create an ApplePay card direct Payin",
                PaymentType = PayInPaymentType.APPLEPAY,
                ExecutionType = PayInExecutionType.DIRECT,
                PaymentData = paymentData
            };

            var getPayIn = Api.PayIns.CreateApplePay(DateTime.Now.Ticks.ToString(), applePayIn);

            Assert.IsNotNull(getPayIn);
            Assert.AreEqual(getPayIn.AuthorId, applePayIn.AuthorId);
            Assert.AreEqual(getPayIn.PaymentType, PayInPaymentType.APPLEPAY);
            Assert.AreEqual(getPayIn.Status, TransactionStatus.SUCCEEDED);
        }

        [Ignore("Cannot test Google Pay")]
        public void TestGooglePayIn()
        {
            var wallet = GetJohnsWallet();
            var user = GetNewJohn();
            var paymentData = new PaymentData
            {
                Network = "VISA",
                TransactionId = "061EB32181A2D9CA42AD16031B476EEBAA62A9A095AD660E2759FBA52B51A61",
                TokenData = "tokenData"
            };
            var googlePayIn = new GooglePayDirectPayInPostDTO
            {
                CreditedWalletId = wallet.Id,
                AuthorId = user.Id,
                CreditedUserId = user.Id,
                DebitedFunds = new Money
                {
                    Amount = 200,
                    Currency = CurrencyIso.EUR
                },
                Fees = new Money
                {
                    Amount = 0,
                    Currency = CurrencyIso.EUR
                },
                Tag = "Create an GooglePay card direct Payin",
                PaymentData = paymentData,
                StatementDescriptor = "Bob",
                Billing = new Billing
                {
                    Address = user.Address
                }
            };

            var getPayIn = Api.PayIns.CreateGooglePay(null, googlePayIn);

            Assert.IsNotNull(getPayIn);
            Assert.AreEqual(getPayIn.AuthorId, googlePayIn.AuthorId);
            Assert.AreEqual(getPayIn.PaymentType, PayInPaymentType.GOOGLEPAY);
            Assert.AreEqual(getPayIn.Status, TransactionStatus.SUCCEEDED);
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

        [Test]
        public void Test_PayIns_Get_PayPal_WithPayPalBuyerAccountEmail()
        {
            try
            {
                string payInId = "54088959";
                string payPalBuyerEmail = "paypal-buyer-user@mangopay.com";
                PayInPayPalDTO payIn = Api.PayIns.GetPayPal(payInId);

                Assert.NotNull(payIn);
                Assert.NotNull(payIn.Id);
                Assert.NotNull(payIn.PaypalBuyerAccountEmail);
                Assert.AreEqual(payInId, payIn.Id);
                Assert.AreEqual(payPalBuyerEmail, payIn.PaypalBuyerAccountEmail);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_GetBankWireExternalInstructionIBAN()
        {
            try
            {
                var payInId = "74980101";

                var payIn = this.Api.PayIns.Get(payInId);

                Assert.IsNotNull(payIn);

                Assert.True(payIn.Type == TransactionType.PAYIN);
                Assert.True(payIn.PaymentType == PayInPaymentType.BANK_WIRE);
                Assert.True(payIn.ExecutionType == PayInExecutionType.EXTERNAL_INSTRUCTION);

                Assert.True(payIn.Status == TransactionStatus.SUCCEEDED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void Test_PayIns_GetBankWireExternalInstructionAccountNumber()
        {
            try
            {
                var payInId = "74981216";

                var payIn = this.Api.PayIns.Get(payInId);

                Assert.IsNotNull(payIn);

                Assert.True(payIn.Type == TransactionType.PAYIN);
                Assert.True(payIn.PaymentType == PayInPaymentType.BANK_WIRE);
                Assert.True(payIn.ExecutionType == PayInExecutionType.EXTERNAL_INSTRUCTION);

                Assert.True(payIn.Status == TransactionStatus.SUCCEEDED);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
