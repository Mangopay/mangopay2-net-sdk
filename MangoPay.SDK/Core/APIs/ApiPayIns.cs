using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for pay-ins.</summary>
    public class ApiPayIns : ApiBase
    {
        /// <summary>Instantiates new ApiPayIns object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiPayIns(MangoPayApi root) : base(root) { }

        /// <summary>Creates new payin bankwire direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> CreateBankWireDirectAsync(PayInBankWireDirectPostDTO payIn)
        {
            return await CreateBankWireDirectAsync(null, payIn);
        }

        /// <summary>Creates new payin bankwire direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> CreateBankWireDirectAsync(String idempotencyKey, PayInBankWireDirectPostDTO payIn)
        {
            return await this.CreateObjectAsync<PayInBankWireDirectDTO, PayInBankWireDirectPostDTO>(idempotencyKey, MethodKey.PayinsBankwireDirectCreate, payIn);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardDirectDTO> CreateCardDirectAsync(PayInCardDirectPostDTO payIn)
        {
            return await CreateCardDirectAsync(null, payIn);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardDirectDTO> CreateCardDirectAsync(String idempotencyKey, PayInCardDirectPostDTO payIn)
        {
            return await this.CreateObjectAsync<PayInCardDirectDTO, PayInCardDirectPostDTO>(idempotencyKey, MethodKey.PayinsCardDirectCreate, payIn);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardWebDTO> CreateCardWebAsync(PayInCardWebPostDTO payIn)
        {
            return await CreateCardWebAsync(null, payIn);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardWebDTO> CreateCardWebAsync(String idempotencyKey, PayInCardWebPostDTO payIn)
        {
            return await this.CreateObjectAsync<PayInCardWebDTO, PayInCardWebPostDTO>(idempotencyKey, MethodKey.PayinsCardWebCreate, payIn);
        }

        /// <summary>Creates new payin by PayPal.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayPalDTO> CreatePayPalAsync(PayInPayPalPostDTO payIn)
        {
            return await CreatePayPalAsync(null, payIn);
        }

        /// <summary>Creates new payin by PayPal.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayPalDTO> CreatePayPalAsync(String idempotencyKey, PayInPayPalPostDTO payIn)
        {
            return await this.CreateObjectAsync<PayInPayPalDTO, PayInPayPalPostDTO>(idempotencyKey, MethodKey.PayinsPayPalCreate, payIn);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> CreatePreauthorizedDirectAsync(PayInPreauthorizedDirectPostDTO payIn)
        {
            return await CreatePreauthorizedDirectAsync(null, payIn);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> CreatePreauthorizedDirectAsync(String idempotencyKey, PayInPreauthorizedDirectPostDTO payIn)
        {
            return await this.CreateObjectAsync<PayInPreauthorizedDirectDTO, PayInPreauthorizedDirectPostDTO>(idempotencyKey, MethodKey.PayinsPreauthorizedDirectCreate, payIn);
        }

        /// <summary>Creates new payin direct debit.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInDirectDebitDTO> CreateDirectDebitAsync(PayInDirectDebitPostDTO payIn)
        {
            return await CreateDirectDebitAsync(null, payIn);
        }

        /// <summary>Creates new payin direct debit.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInDirectDebitDTO> CreateDirectDebitAsync(String idempotencyKey, PayInDirectDebitPostDTO payIn)
        {
            return await this.CreateObjectAsync<PayInDirectDebitDTO, PayInDirectDebitPostDTO>(idempotencyKey, MethodKey.PayinsDirectDebitCreate, payIn);
        }

        /// <summary>Creates new payin mandate direct debit.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMandateDirectDTO> CreateMandateDirectDebitAsync(PayInMandateDirectPostDTO payIn)
        {
            return await CreateMandateDirectDebitAsync(null, payIn);
        }

        /// <summary>Creates new payin mandate direct debit.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMandateDirectDTO> CreateMandateDirectDebitAsync(String idempotencyKey, PayInMandateDirectPostDTO payIn)
        {
            return await this.CreateObjectAsync<PayInMandateDirectDTO, PayInMandateDirectPostDTO>(idempotencyKey, MethodKey.PayinsMandateDirectDebitCreate, payIn);
        }

        /// <summary>Gets PayIn entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInDTO> GetAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn bankwire direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> GetBankWireDirectAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInBankWireDirectDTO>(MethodKey.PayinsGet, payInId);
        }

		/// <summary>Gets PayIn bankwire external instruction entity by its identifier.</summary>
		/// <param name="payInId">PayIn identifier.</param>
		/// <returns>PayIn object returned from API.</returns>
		public async Task<PayInBankWireExternalInstructionDTO> GetBankWireExternalInstructionAsync(String payInId)
		{
			return await this.GetObjectAsync<PayInBankWireExternalInstructionDTO>(MethodKey.PayinsGet, payInId);
		}

		/// <summary>Gets PayIn card direct entity by its identifier.</summary>
		/// <param name="payInId">PayIn identifier.</param>
		/// <returns>PayIn object returned from API.</returns>
		public async Task<PayInCardDirectDTO> GetCardDirectAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInCardDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn card web entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInCardWebDTO> GetCardWebAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInCardWebDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets limited card data for PayIn card web.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>Simplified Card object returned from API.</returns>
        public async Task<CardDTO> GetCardDataForCardWebAsync(String payInId)
        {
            return await this.GetObjectAsync<CardDTO>(MethodKey.PayinsCardWebGetCardData, payInId);
        }

        /// <summary>Gets PayIn preauthorized direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> GetPreauthorizedDirectAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInPreauthorizedDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn direct debit entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInDirectDebitDTO> GetDirectDebitAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInDirectDebitDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn direct debit direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInMandateDirectDTO> GetMandateDirectDebitAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInMandateDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn PayPal entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPayPalDTO> GetPayPalAsync(String payInId)
        {
            return await this.GetObjectAsync<PayInPayPalDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public async Task<RefundDTO> CreateRefundAsync(String payInId, RefundPayInPostDTO refund)
        {
            return await CreateRefundAsync(null, payInId, refund);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public async Task<RefundDTO> CreateRefundAsync(String idempotencyKey, String payInId, RefundPayInPostDTO refund)
        {
            return await this.CreateObjectAsync<RefundDTO, RefundPayInPostDTO>(idempotencyKey, MethodKey.PayinsCreateRefunds, refund, payInId);
        }

        public async Task<ApplePayDirectPayinDTO> CreateApplePayAsync(String idempotencyKey, ApplePayDirectPayInPostDTO payIn)
        {
            return await this.CreateObjectAsync<ApplePayDirectPayinDTO, ApplePayDirectPayInPostDTO>(idempotencyKey, MethodKey.ApplePayinsDirectCreate, payIn);
        }

        public async Task<GooglePayDirectPayInDTO> CreateGooglePayAsync(String idempotencyKey, GooglePayDirectPayInPostDTO payIn)
        {
            return await this.CreateObjectAsync<GooglePayDirectPayInDTO, GooglePayDirectPayInPostDTO>(idempotencyKey, MethodKey.GooglePayinsDirectCreate, payIn);
        }

        public async Task<RecurringPayInRegistrationGetDTO> GetRecurringPayInRegistration(string recurringRegistrationId)
        {
            return await this.GetObjectAsync<RecurringPayInRegistrationGetDTO>(MethodKey.PayinsGetRecurringRegistration,
                recurringRegistrationId);
        }

        public async Task<RecurringPayInRegistrationGetDTO> UpdateRecurringPayInRegistration(string recurringRegistrationId, RecurringPayInPutDTO payIn)
        {
            return await this.UpdateObjectAsync<RecurringPayInRegistrationGetDTO, RecurringPayInPutDTO>(
                MethodKey.PayinsPutRecurringRegistration,
                payIn, recurringRegistrationId);
        }

        public async Task<RecurringPayInRegistrationDTO> CreateRecurringPayInRegistration(RecurringPayInRegistrationPostDTO payIn)
        {
            return await this.CreateObjectAsync<RecurringPayInRegistrationDTO, RecurringPayInRegistrationPostDTO>(
                null, MethodKey.PayinsRecurringRegistration, payIn);
        }

        public async Task<RecurringPayInRegistrationDTO> CreateRecurringPayInRegistration(string idempotencyKey, RecurringPayInRegistrationPostDTO payIn)
        {
            return await this.CreateObjectAsync<RecurringPayInRegistrationDTO, RecurringPayInRegistrationPostDTO>(
                idempotencyKey, MethodKey.PayinsRecurringRegistration, payIn);
        }

        public async Task<RecurringPayInDTO> CreateRecurringPayInRegistrationCIT(RecurringPayInCITPostDTO payIn)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayInCITPostDTO>(
                null, MethodKey.PayinsRecurringCardDirect, payIn);
        }

        public async Task<RecurringPayInDTO> CreateRecurringPayInRegistrationCIT(string idempotencyKey, RecurringPayInCITPostDTO payIn)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayInCITPostDTO>(
                idempotencyKey, MethodKey.PayinsRecurringCardDirect, payIn);
        }

        public async Task<RecurringPayInDTO> CreateRecurringPayInRegistrationMIT(RecurringPayInMITPostDTO payIn)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayInMITPostDTO>(
                null, MethodKey.PayinsRecurringCardDirect, payIn);
        }

        public async Task<RecurringPayInDTO> CreateRecurringPayInRegistrationMIT(string idempotencyKey, RecurringPayInMITPostDTO payIn)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayInMITPostDTO>(
                idempotencyKey, MethodKey.PayinsRecurringCardDirect, payIn);
        }

        public PayInBankWireDirectDTO CreateBankWireDirect(PayInBankWireDirectPostDTO payIn)
        {
            return CreateBankWireDirect(null, payIn);
        }

        /// <summary>Creates new payin bankwire direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInBankWireDirectDTO CreateBankWireDirect(String idempotencyKey, PayInBankWireDirectPostDTO payIn)
        {
            return this.CreateObject<PayInBankWireDirectDTO, PayInBankWireDirectPostDTO>(idempotencyKey, MethodKey.PayinsBankwireDirectCreate, payIn);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInCardDirectDTO CreateCardDirect(PayInCardDirectPostDTO payIn)
        {
            return CreateCardDirect(null, payIn);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInCardDirectDTO CreateCardDirect(String idempotencyKey, PayInCardDirectPostDTO payIn)
        {
            return this.CreateObject<PayInCardDirectDTO, PayInCardDirectPostDTO>(idempotencyKey, MethodKey.PayinsCardDirectCreate, payIn);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInCardWebDTO CreateCardWeb(PayInCardWebPostDTO payIn)
        {
            return CreateCardWeb(null, payIn);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInCardWebDTO CreateCardWeb(String idempotencyKey, PayInCardWebPostDTO payIn)
        {
            return this.CreateObject<PayInCardWebDTO, PayInCardWebPostDTO>(idempotencyKey, MethodKey.PayinsCardWebCreate, payIn);
        }

        /// <summary>Creates new payin by PayPal.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInPayPalDTO CreatePayPal(PayInPayPalPostDTO payIn)
        {
            return CreatePayPal(null, payIn);
        }

        /// <summary>Creates new payin by PayPal.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInPayPalDTO CreatePayPal(String idempotencyKey, PayInPayPalPostDTO payIn)
        {
            return this.CreateObject<PayInPayPalDTO, PayInPayPalPostDTO>(idempotencyKey, MethodKey.PayinsPayPalCreate, payIn);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInPreauthorizedDirectDTO CreatePreauthorizedDirect(PayInPreauthorizedDirectPostDTO payIn)
        {
            return CreatePreauthorizedDirect(null, payIn);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInPreauthorizedDirectDTO CreatePreauthorizedDirect(String idempotencyKey, PayInPreauthorizedDirectPostDTO payIn)
        {
            return this.CreateObject<PayInPreauthorizedDirectDTO, PayInPreauthorizedDirectPostDTO>(idempotencyKey, MethodKey.PayinsPreauthorizedDirectCreate, payIn);
        }

        /// <summary>Creates new payin direct debit.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInDirectDebitDTO CreateDirectDebit(PayInDirectDebitPostDTO payIn)
        {
            return CreateDirectDebit(null, payIn);
        }

        /// <summary>Creates new payin direct debit.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInDirectDebitDTO CreateDirectDebit(String idempotencyKey, PayInDirectDebitPostDTO payIn)
        {
            return this.CreateObject<PayInDirectDebitDTO, PayInDirectDebitPostDTO>(idempotencyKey, MethodKey.PayinsDirectDebitCreate, payIn);
        }

        /// <summary>Creates new payin mandate direct debit.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInMandateDirectDTO CreateMandateDirectDebit(PayInMandateDirectPostDTO payIn)
        {
            return CreateMandateDirectDebit(null, payIn);
        }

        /// <summary>Creates new payin mandate direct debit.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public PayInMandateDirectDTO CreateMandateDirectDebit(String idempotencyKey, PayInMandateDirectPostDTO payIn)
        {
            return this.CreateObject<PayInMandateDirectDTO, PayInMandateDirectPostDTO>(idempotencyKey, MethodKey.PayinsMandateDirectDebitCreate, payIn);
        }

        /// <summary>Gets PayIn entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInDTO Get(String payInId)
        {
            return this.GetObject<PayInDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn bankwire direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInBankWireDirectDTO GetBankWireDirect(String payInId)
        {
            return this.GetObject<PayInBankWireDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn bankwire external instruction entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInBankWireExternalInstructionDTO GetBankWireExternalInstruction(String payInId)
        {
            return this.GetObject<PayInBankWireExternalInstructionDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn card direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInCardDirectDTO GetCardDirect(String payInId)
        {
            return this.GetObject<PayInCardDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn card web entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInCardWebDTO GetCardWeb(String payInId)
        {
            return this.GetObject<PayInCardWebDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets limited card data for PayIn card web.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>Simplified Card object returned from API.</returns>
        public CardDTO GetCardDataForCardWeb(String payInId)
        {
            return this.GetObject<CardDTO>(MethodKey.PayinsCardWebGetCardData, payInId);
        }

        /// <summary>Gets PayIn preauthorized direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInPreauthorizedDirectDTO GetPreauthorizedDirect(String payInId)
        {
            return this.GetObject<PayInPreauthorizedDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn direct debit entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInDirectDebitDTO GetDirectDebit(String payInId)
        {
            return this.GetObject<PayInDirectDebitDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn direct debit direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInMandateDirectDTO GetMandateDirectDebit(String payInId)
        {
            return this.GetObject<PayInMandateDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn PayPal entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public PayInPayPalDTO GetPayPal(String payInId)
        {
            return this.GetObject<PayInPayPalDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO CreateRefund(String payInId, RefundPayInPostDTO refund)
        {
            return CreateRefund(null, payInId, refund);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO CreateRefund(String idempotencyKey, String payInId, RefundPayInPostDTO refund)
        {
            return this.CreateObject<RefundDTO, RefundPayInPostDTO>(idempotencyKey, MethodKey.PayinsCreateRefunds, refund, payInId);
        }

        public ApplePayDirectPayinDTO CreateApplePay(String idempotencyKey, ApplePayDirectPayInPostDTO payIn)
        {
            return this.CreateObject<ApplePayDirectPayinDTO, ApplePayDirectPayInPostDTO>(idempotencyKey, MethodKey.ApplePayinsDirectCreate, payIn);
        }

        public GooglePayDirectPayInDTO CreateGooglePay(String idempotencyKey, GooglePayDirectPayInPostDTO payIn)
        {
            return this.CreateObject<GooglePayDirectPayInDTO, GooglePayDirectPayInPostDTO>(idempotencyKey, MethodKey.GooglePayinsDirectCreate, payIn);
        }
    }
}























































