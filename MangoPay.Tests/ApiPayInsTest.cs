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
    public class ApiPayInsTest : BaseTest
    {
        [TestMethod]
        public void Test_PayIns_Create_CardWeb()
        {
            try
            {
                PayIn payIn = null;
                payIn = this.GetJohnsPayInCardWeb();

                Assert.IsTrue(payIn.Id.Length > 0);
                Assert.IsTrue(payIn.PaymentType == "CARD");
                Assert.IsTrue(payIn.PaymentDetails is PayInPaymentDetailsCard);
                Assert.IsTrue(payIn.ExecutionType == "WEB");
                Assert.IsTrue(payIn.ExecutionDetails is PayInExecutionDetailsWeb);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_PayIns_Get_CardWeb()
        {
            try
            {
                PayIn payIn = null;
                payIn = this.GetJohnsPayInCardWeb();

                PayIn getPayIn = this.Api.PayIns.Get(payIn.Id);

                Assert.IsTrue(payIn.Id == getPayIn.Id);
                Assert.IsTrue(payIn.PaymentType == "CARD");
                Assert.IsTrue(payIn.PaymentDetails is PayInPaymentDetailsCard);
                Assert.IsTrue(payIn.ExecutionType == "WEB");
                Assert.IsTrue(payIn.ExecutionDetails is PayInExecutionDetailsWeb);

                AssertEqualInputProps(payIn, getPayIn);

                Assert.IsTrue(getPayIn.Status == "CREATED");
                Assert.IsTrue(getPayIn.ExecutionDate == null);

                Assert.IsNotNull(((PayInExecutionDetailsWeb)getPayIn.ExecutionDetails).RedirectURL);
                Assert.IsNotNull(((PayInExecutionDetailsWeb)getPayIn.ExecutionDetails).ReturnURL);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_PayIns_Create_CardDirect()
        {
            try
            {
                Wallet johnWallet = this.GetJohnsWalletWithMoney();
                Wallet beforeWallet = this.Api.Wallets.Get(johnWallet.Id);

                PayIn payIn = this.GetNewPayInCardDirect();
                Wallet wallet = this.Api.Wallets.Get(johnWallet.Id);
                UserNatural user = this.GetJohn();

                Assert.IsTrue(payIn.Id.Length > 0);
                Assert.AreEqual(wallet.Id, payIn.CreditedWalletId);
                Assert.AreEqual("CARD", payIn.PaymentType);
                Assert.IsTrue(payIn.PaymentDetails is PayInPaymentDetailsCard);
                Assert.AreEqual("DIRECT", payIn.ExecutionType);
                Assert.IsTrue(payIn.ExecutionDetails is PayInExecutionDetailsDirect);
                Assert.IsTrue(payIn.DebitedFunds is Money);
                Assert.IsTrue(payIn.CreditedFunds is Money);
                Assert.IsTrue(payIn.Fees is Money);
                Assert.AreEqual(user.Id, payIn.AuthorId);
                Assert.IsTrue(wallet.Balance.Amount == beforeWallet.Balance.Amount + payIn.CreditedFunds.Amount);
                Assert.AreEqual("SUCCEEDED", payIn.Status);
                Assert.AreEqual("PAYIN", payIn.Type);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_PayIns_Get_CardDirect()
        {
            try
            {
                PayIn payIn = this.GetNewPayInCardDirect();

                PayIn getPayIn = this.Api.PayIns.Get(payIn.Id);

                Assert.IsTrue(payIn.Id == getPayIn.Id);
                Assert.IsTrue(payIn.PaymentType == "CARD");
                Assert.IsTrue(payIn.PaymentDetails is PayInPaymentDetailsCard);
                Assert.IsTrue(payIn.ExecutionType == "DIRECT");
                Assert.IsTrue(payIn.ExecutionDetails is PayInExecutionDetailsDirect);
                AssertEqualInputProps(payIn, getPayIn);
                Assert.IsNotNull(((PayInPaymentDetailsCard)getPayIn.PaymentDetails).CardId);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_PayIns_CreateRefund_CardDirect()
        {
            try
            {
                PayIn payIn = this.GetNewPayInCardDirect();
                Wallet wallet = this.GetJohnsWalletWithMoney();
                Wallet walletBefore = this.Api.Wallets.Get(wallet.Id);

                Refund refund = this.GetNewRefundForPayIn(payIn);
                Wallet walletAfter = this.Api.Wallets.Get(wallet.Id);

                Assert.IsTrue(refund.Id.Length > 0);
                Assert.IsTrue(refund.DebitedFunds.Amount == payIn.DebitedFunds.Amount);
                Assert.IsTrue(walletBefore.Balance.Amount == (walletAfter.Balance.Amount + payIn.DebitedFunds.Amount));
                Assert.AreEqual("PAYOUT", refund.Type);
                Assert.AreEqual("REFUND", refund.Nature);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_PayIns_PreAuthorizedDirect()
        {
            try
            {
                CardPreAuthorization cardPreAuthorization = this.GetJohnsCardPreAuthorization();
                Wallet wallet = this.GetJohnsWalletWithMoney();
                UserNatural user = this.GetJohn();

                // create pay-in PRE-AUTHORIZED DIRECT
                PayIn payIn = new PayIn();
                payIn.CreditedWalletId = wallet.Id;
                payIn.AuthorId = user.Id;
                payIn.DebitedFunds = new Money();
                payIn.DebitedFunds.Amount = 10000.0;
                payIn.DebitedFunds.Currency = "EUR";
                payIn.Fees = new Money();
                payIn.Fees.Amount = 0.0;
                payIn.Fees.Currency = "EUR";

                // payment type as CARD
                payIn.PaymentDetails = new PayInPaymentDetailsPreAuthorized();
                ((PayInPaymentDetailsPreAuthorized)payIn.PaymentDetails).PreauthorizationId = cardPreAuthorization.Id;

                // execution type as DIRECT
                payIn.ExecutionDetails = new PayInExecutionDetailsDirect();
                ((PayInExecutionDetailsDirect)payIn.ExecutionDetails).SecureModeReturnURL = "http://test.com";

                PayIn createPayIn = this.Api.PayIns.Create(payIn);

                Assert.IsTrue("" != createPayIn.Id);
                Assert.AreEqual(wallet.Id, createPayIn.CreditedWalletId);
                Assert.AreEqual("PREAUTHORIZED", createPayIn.PaymentType);
                Assert.IsTrue(createPayIn.PaymentDetails is PayInPaymentDetailsPreAuthorized);
                Assert.AreEqual("DIRECT", createPayIn.ExecutionType);
                Assert.IsTrue(createPayIn.ExecutionDetails is PayInExecutionDetailsDirect);
                Assert.IsTrue(createPayIn.DebitedFunds is Money);
                Assert.IsTrue(createPayIn.CreditedFunds is Money);
                Assert.IsTrue(createPayIn.Fees is Money);
                Assert.AreEqual(user.Id, createPayIn.AuthorId);
                Assert.AreEqual("SUCCEEDED", createPayIn.Status);
                Assert.AreEqual("PAYIN", createPayIn.Type);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_PayIns_BankWireDirect_Create()
        {
            try
            {
                Wallet wallet = this.GetJohnsWallet();
                UserNatural user = this.GetJohn();

                // create pay-in PRE-AUTHORIZED DIRECT
                PayIn payIn = new PayIn();
                payIn.CreditedWalletId = wallet.Id;
                payIn.AuthorId = user.Id;

                // payment type as CARD
                payIn.PaymentDetails = new PayInPaymentDetailsBankWire();
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredDebitedFunds = new Money();
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredDebitedFunds.Amount = 10000.0;
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredDebitedFunds.Currency = "EUR";
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredFees = new Money();
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredFees.Amount = 0.0;
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredFees.Currency = "EUR";
                payIn.ExecutionDetails = new PayInExecutionDetailsDirect();

                PayIn createPayIn = this.Api.PayIns.Create(payIn);

                Assert.IsTrue("" != createPayIn.Id);
                Assert.AreEqual(wallet.Id, createPayIn.CreditedWalletId);
                Assert.AreEqual("BANK_WIRE", createPayIn.PaymentType);
                Assert.IsTrue(createPayIn.PaymentDetails is PayInPaymentDetailsBankWire);
                Assert.IsTrue(((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).DeclaredDebitedFunds is Money);
                Assert.IsTrue(((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).DeclaredFees is Money);
                Assert.AreEqual("DIRECT", createPayIn.ExecutionType);
                Assert.IsTrue(createPayIn.ExecutionDetails is PayInExecutionDetailsDirect);
                Assert.AreEqual(user.Id, createPayIn.AuthorId);
                Assert.AreEqual("CREATED", createPayIn.Status);
                Assert.AreEqual("PAYIN", createPayIn.Type);
                Assert.IsNotNull(((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).WireReference);
                Assert.IsTrue(((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).BankAccount is BankAccount);
                Assert.AreEqual(((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).BankAccount.Type, "IBAN");
                Assert.IsTrue(((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).BankAccount.Details is BankAccountDetailsIBAN);
                Assert.IsNotNull(((BankAccountDetailsIBAN)((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).BankAccount.Details).IBAN);
                Assert.IsNotNull(((BankAccountDetailsIBAN)((PayInPaymentDetailsBankWire)createPayIn.PaymentDetails).BankAccount.Details).BIC);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Test_PayIns_BankWireDirect_Get()
        {
            try
            {
                Wallet wallet = this.GetJohnsWallet();
                UserNatural user = this.GetJohn();

                // create pay-in PRE-AUTHORIZED DIRECT
                PayIn payIn = new PayIn();
                payIn.CreditedWalletId = wallet.Id;
                payIn.AuthorId = user.Id;

                // payment type as CARD
                payIn.PaymentDetails = new PayInPaymentDetailsBankWire();
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredDebitedFunds = new Money();
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredDebitedFunds.Amount = 10000.0;
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredDebitedFunds.Currency = "EUR";
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredFees = new Money();
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredFees.Amount = 0.0;
                ((PayInPaymentDetailsBankWire)payIn.PaymentDetails).DeclaredFees.Currency = "EUR";
                payIn.ExecutionDetails = new PayInExecutionDetailsDirect();
                PayIn createdPayIn = this.Api.PayIns.Create(payIn);

                PayIn getPayIn = this.Api.PayIns.Get(createdPayIn.Id);

                Assert.AreEqual(getPayIn.Id, createdPayIn.Id);
                Assert.AreEqual("BANK_WIRE", getPayIn.PaymentType);
                Assert.IsTrue(getPayIn.PaymentDetails is PayInPaymentDetailsBankWire);
                Assert.IsTrue(((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).DeclaredDebitedFunds is Money);
                Assert.IsTrue(((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).DeclaredFees is Money);
                Assert.AreEqual("DIRECT", getPayIn.ExecutionType);
                Assert.IsTrue(getPayIn.ExecutionDetails is PayInExecutionDetailsDirect);
                Assert.AreEqual(user.Id, getPayIn.AuthorId);
                Assert.AreEqual("PAYIN", getPayIn.Type);
                Assert.IsNotNull(((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).WireReference);
                Assert.IsTrue(((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).BankAccount is BankAccount);
                Assert.AreEqual(((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).BankAccount.Type, "IBAN");
                Assert.IsTrue(((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).BankAccount.Details is BankAccountDetailsIBAN);
                Assert.IsNotNull(((BankAccountDetailsIBAN)((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).BankAccount.Details).IBAN);
                Assert.IsNotNull(((BankAccountDetailsIBAN)((PayInPaymentDetailsBankWire)getPayIn.PaymentDetails).BankAccount.Details).BIC);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
