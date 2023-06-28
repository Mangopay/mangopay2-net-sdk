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
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> CreateBankWireDirectAsync(PayInBankWireDirectPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInBankWireDirectDTO, PayInBankWireDirectPostDTO>(MethodKey.PayinsBankwireDirectCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin card direct.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardDirectDTO> CreateCardDirectAsync(PayInCardDirectPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInCardDirectDTO, PayInCardDirectPostDTO>(MethodKey.PayinsCardDirectCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin card web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInCardWebDTO> CreateCardWebAsync(PayInCardWebPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInCardWebDTO, PayInCardWebPostDTO>(MethodKey.PayinsCardWebCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin by PayPal.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        [Obsolete("CreatePayPalAsync is deprecated, please use CreatePayPalV2Async instead.")]
        public async Task<PayInPayPalDTO> CreatePayPalAsync(PayInPayPalPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayPalDTO, PayInPayPalPostDTO>(MethodKey.PayinsPayPalCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin by PayPal V2.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayPalV2DTO> CreatePayPalV2Async(PayInPayPalV2PostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayPalV2DTO, PayInPayPalV2PostDTO>(MethodKey.PayinsPayPalV2Create, payIn, idempotentKey);
        }

        /// <summary>Creates new payin by Payconiq.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayconiqDTO> CreatePayconiqAsync(PayInPayconiqPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayconiqDTO, PayInPayconiqPostDTO>(MethodKey.PayinsPayconiqWebCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin preauthorized direct.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> CreatePreauthorizedDirectAsync(PayInPreauthorizedDirectPostDTO payIn, string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<PayInPreauthorizedDirectDTO, PayInPreauthorizedDirectPostDTO>(MethodKey.PayinsPreauthorizedDirectCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin direct debit.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInDirectDebitDTO> CreateDirectDebitAsync(PayInDirectDebitPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInDirectDebitDTO, PayInDirectDebitPostDTO>(MethodKey.PayinsDirectDebitCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new pay in mandate direct debit.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMandateDirectDTO> CreateMandateDirectDebitAsync(PayInMandateDirectPostDTO payIn, string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<PayInMandateDirectDTO, PayInMandateDirectPostDTO>(MethodKey.PayinsMandateDirectDebitCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin mbway direct.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMbwayDirectDTO> CreateMbwayDirectAsync(PayInMbwayDirectPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInMbwayDirectDTO, PayInMbwayDirectPostDTO>(MethodKey.PayinsMbwayDirectCreate, payIn, idempotentKey);
        }

        /// <summary>Gets PayIn entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInDTO> GetAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn bankwire direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInBankWireDirectDTO> GetBankWireDirectAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInBankWireDirectDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn bankwire external instruction entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInBankWireExternalInstructionDTO> GetBankWireExternalInstructionAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInBankWireExternalInstructionDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn card direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInCardDirectDTO> GetCardDirectAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInCardDirectDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn card web entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInCardWebDTO> GetCardWebAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInCardWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets limited card data for PayIn card web.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>Simplified Card object returned from API.</returns>
        public async Task<CardDTO> GetCardDataForCardWebAsync(string payInId)
        {
            return await this.GetObjectAsync<CardDTO>(MethodKey.PayinsCardWebGetCardData, entitiesId: payInId);
        }

        /// <summary>Gets PayIn preauthorized direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPreauthorizedDirectDTO> GetPreauthorizedDirectAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInPreauthorizedDirectDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn direct debit entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInDirectDebitDTO> GetDirectDebitAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInDirectDebitDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn direct debit direct entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInMandateDirectDTO> GetMandateDirectDebitAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInMandateDirectDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn PayPal entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        [Obsolete("GetPayPalAsync is deprecated, please use GetPayPalAsync instead.")]
        public async Task<PayInPayPalDTO> GetPayPalAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInPayPalDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn PayPal V2 entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPayPalV2DTO> GetPayPalV2Async(string payInId)
        {
            return await this.GetObjectAsync<PayInPayPalV2DTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn Payconiq entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPayconiqDTO> GetPayconiqAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInPayconiqDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Mbway entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInMbwayDirectDTO> GetMbwayAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInMbwayDirectDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Creates refund for PayIn object.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="refund">Refund object to be created.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public async Task<RefundDTO> CreateRefundAsync(string payInId, RefundPayInPostDTO refund, string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<RefundDTO, RefundPayInPostDTO>(MethodKey.PayinsCreateRefunds, refund, idempotentKey, payInId);
        }

        public async Task<ApplePayDirectPayinDTO> CreateApplePayAsync(ApplePayDirectPayInPostDTO payIn, string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<ApplePayDirectPayinDTO, ApplePayDirectPayInPostDTO>(MethodKey.ApplePayinsDirectCreate, payIn, idempotentKey);
        }

        public async Task<GooglePayDirectPayInDTO> CreateGooglePayAsync(GooglePayDirectPayInPostDTO payIn, string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<GooglePayDirectPayInDTO, GooglePayDirectPayInPostDTO>(MethodKey.GooglePayinsDirectCreate, payIn, idempotentKey);
        }

        public async Task<RecurringPayInRegistrationGetDTO> GetRecurringPayInRegistration(string recurringRegistrationId)
        {
            return await this.GetObjectAsync<RecurringPayInRegistrationGetDTO>(MethodKey.PayinsGetRecurringRegistration,
                entitiesId: recurringRegistrationId);
        }

        public async Task<RecurringPayInRegistrationGetDTO> UpdateRecurringPayInRegistration(string recurringRegistrationId, RecurringPayInPutDTO payIn)
        {
            return await this.UpdateObjectAsync<RecurringPayInRegistrationGetDTO, RecurringPayInPutDTO>(
                MethodKey.PayinsPutRecurringRegistration,
                payIn, entitiesId: recurringRegistrationId);
        }

        public async Task<RecurringPayInRegistrationDTO> CreateRecurringPayInRegistration(RecurringPayInRegistrationPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<RecurringPayInRegistrationDTO, RecurringPayInRegistrationPostDTO>(
                MethodKey.PayinsRecurringRegistration, payIn, idempotentKey);
        }

        public async Task<RecurringPayInDTO> CreateRecurringPayInRegistrationCIT(RecurringPayInCITPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayInCITPostDTO>(
                MethodKey.PayinsRecurringCardDirect, payIn, idempotentKey);
        }

        public async Task<RecurringPayInDTO> CreateRecurringPayInRegistrationMIT(RecurringPayInMITPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayInMITPostDTO>(
                MethodKey.PayinsRecurringCardDirect, payIn, idempotentKey);
        }
        
        public async Task<CardPreAuthorizedDepositPayInDTO> CreateCardPreAuthorizedDepositPayIn(
            CardPreAuthorizedDepositPayInPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<CardPreAuthorizedDepositPayInDTO, CardPreAuthorizedDepositPayInPostDTO>(
                MethodKey.PayInsCreateCardPreAuthorizedDeposit, payIn, idempotentKey);
        }
    }
}
