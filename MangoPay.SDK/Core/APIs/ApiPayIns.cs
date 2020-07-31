using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<PayInBankWireDirectDTO> CreateBankWireDirect(PayInBankWireDirectPostDTO payIn)
        {
            return await CreateBankWireDirect(null, payIn);
        }

        /// <summary>Creates new payin bankwire direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> CreateBankWireDirect(String idempotencyKey, PayInBankWireDirectPostDTO payIn)
        {
            return await this.CreateObject<PayInBankWireDirectDTO, PayInBankWireDirectPostDTO>(idempotencyKey, MethodKey.PayinsBankwireDirectCreate, payIn);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardDirectDTO> CreateCardDirect(PayInCardDirectPostDTO payIn)
        {
            return await CreateCardDirect(null, payIn);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardDirectDTO> CreateCardDirect(String idempotencyKey, PayInCardDirectPostDTO payIn)
        {
            return await this.CreateObject<PayInCardDirectDTO, PayInCardDirectPostDTO>(idempotencyKey, MethodKey.PayinsCardDirectCreate, payIn);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardWebDTO> CreateCardWeb(PayInCardWebPostDTO payIn)
        {
            return await CreateCardWeb(null, payIn);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardWebDTO> CreateCardWeb(String idempotencyKey, PayInCardWebPostDTO payIn)
        {
            return await this.CreateObject<PayInCardWebDTO, PayInCardWebPostDTO>(idempotencyKey, MethodKey.PayinsCardWebCreate, payIn);
        }

        /// <summary>Creates new payin by PayPal.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayPalDTO> CreatePayPal(PayInPayPalPostDTO payIn)
        {
            return await CreatePayPal(null, payIn);
        }

        /// <summary>Creates new payin by PayPal.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayPalDTO> CreatePayPal(String idempotencyKey, PayInPayPalPostDTO payIn)
        {
            return await this.CreateObject<PayInPayPalDTO, PayInPayPalPostDTO>(idempotencyKey, MethodKey.PayinsPayPalCreate, payIn);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> CreatePreauthorizedDirect(PayInPreauthorizedDirectPostDTO payIn)
        {
            return await CreatePreauthorizedDirect(null, payIn);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> CreatePreauthorizedDirect(String idempotencyKey, PayInPreauthorizedDirectPostDTO payIn)
        {
            return await this.CreateObject<PayInPreauthorizedDirectDTO, PayInPreauthorizedDirectPostDTO>(idempotencyKey, MethodKey.PayinsPreauthorizedDirectCreate, payIn);
        }

        /// <summary>Creates new payin direct debit.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInDirectDebitDTO> CreateDirectDebit(PayInDirectDebitPostDTO payIn)
        {
            return await CreateDirectDebit(null, payIn);
        }

        /// <summary>Creates new payin direct debit.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInDirectDebitDTO> CreateDirectDebit(String idempotencyKey, PayInDirectDebitPostDTO payIn)
        {
            return await this.CreateObject<PayInDirectDebitDTO, PayInDirectDebitPostDTO>(idempotencyKey, MethodKey.PayinsDirectDebitCreate, payIn);
        }

        /// <summary>Creates new payin mandate direct debit.</summary>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMandateDirectDTO> CreateMandateDirectDebit(PayInMandateDirectPostDTO payIn)
        {
            return await CreateMandateDirectDebit(null, payIn);
        }

        /// <summary>Creates new payin mandate direct debit.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMandateDirectDTO> CreateMandateDirectDebit(String idempotencyKey, PayInMandateDirectPostDTO payIn)
        {
            return await this.CreateObject<PayInMandateDirectDTO, PayInMandateDirectPostDTO>(idempotencyKey, MethodKey.PayinsMandateDirectDebitCreate, payIn);
        }

        /// <summary>Gets PayIn entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInDTO> Get(String payInId)
        {
            return await this.GetObject<PayInDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn bankwire direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> GetBankWireDirect(String payInId)
        {
            return await this.GetObject<PayInBankWireDirectDTO>(MethodKey.PayinsGet, payInId);
        }

		/// <summary>Gets PayIn bankwire external instruction entity by its identifier.</summary>
		/// <param name="payInId">PayIn identifier.</param>
		/// <returns>PayIn object returned from API.</returns>
		public async Task<PayInBankWireExternalInstructionDTO> GetBankWireExternalInstruction(String payInId)
		{
			return await this.GetObject<PayInBankWireExternalInstructionDTO>(MethodKey.PayinsGet, payInId);
		}

		/// <summary>Gets PayIn card direct entity by its identifier.</summary>
		/// <param name="payInId">PayIn identifier.</param>
		/// <returns>PayIn object returned from API.</returns>
		public async Task<PayInCardDirectDTO> GetCardDirect(String payInId)
        {
            return await this.GetObject<PayInCardDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn card web entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInCardWebDTO> GetCardWeb(String payInId)
        {
            return await this.GetObject<PayInCardWebDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets limited card data for PayIn card web.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>Simplified Card object returned from API.</returns>
        public async Task<CardDTO> GetCardDataForCardWeb(String payInId)
        {
            return await this.GetObject<CardDTO>(MethodKey.PayinsCardWebGetCardData, payInId);
        }

        /// <summary>Gets PayIn preauthorized direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> GetPreauthorizedDirect(String payInId)
        {
            return await this.GetObject<PayInPreauthorizedDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn direct debit entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInDirectDebitDTO> GetDirectDebit(String payInId)
        {
            return await this.GetObject<PayInDirectDebitDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn direct debit direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInMandateDirectDTO> GetMandateDirectDebit(String payInId)
        {
            return await this.GetObject<PayInMandateDirectDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Gets PayIn PayPal entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPayPalDTO> GetPayPal(String payInId)
        {
            return await this.GetObject<PayInPayPalDTO>(MethodKey.PayinsGet, payInId);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public async Task<RefundDTO> CreateRefund(String payInId, RefundPayInPostDTO refund)
        {
            return await CreateRefund(null, payInId, refund);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="idempotencyKey">Idempotency key for this request.</param>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public async Task<RefundDTO> CreateRefund(String idempotencyKey, String payInId, RefundPayInPostDTO refund)
        {
            return await this.CreateObject<RefundDTO, RefundPayInPostDTO>(idempotencyKey, MethodKey.PayinsCreateRefunds, refund, payInId);
        }

        public async Task<ApplePayDirectPayinDTO> CreateApplePay(String idempotencyKey, ApplePayDirectPayInPostDTO payIn)
        {
            return await this.CreateObject<ApplePayDirectPayinDTO, ApplePayDirectPayInPostDTO>(idempotencyKey, MethodKey.ApplePayinsDirectCreate, payIn);
        }

        public async Task<GooglePayDirectPayInDTO> CreateGooglePay(String idempotencyKey, GooglePayDirectPayInPostDTO payIn)
        {
            return await this.CreateObject<GooglePayDirectPayInDTO, GooglePayDirectPayInPostDTO>(idempotencyKey, MethodKey.GooglePayinsDirectCreate, payIn);
        }
    }
}























































