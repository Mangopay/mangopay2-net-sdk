using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System;

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

        /// <summary>Gets refund for PayIn object.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public RefundDTO GetRefund(String payInId)
        {
            return this.GetObject<RefundDTO>(MethodKey.PayinsGetRefunds, payInId);
        }
    }
}
