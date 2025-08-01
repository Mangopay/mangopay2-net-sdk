﻿using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
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
        [Obsolete("CreatePayPalAsync is deprecated, please use CreatePayPalWebAsync instead.")]
        public async Task<PayInPayPalDTO> CreatePayPalAsync(PayInPayPalPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayPalDTO, PayInPayPalPostDTO>(MethodKey.PayinsPayPalCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin by PayPal Web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayPalWebDTO> CreatePayPalWebAsync(PayInPayPalWebPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayPalWebDTO, PayInPayPalWebPostDTO>(MethodKey.PayinsPayPalWebCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin by Payconiq.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayconiqDTO> CreatePayconiqAsync(PayInPayconiqPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayconiqDTO, PayInPayconiqPostDTO>(MethodKey.PayinsPayconiqWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin by Payconiq using the latest API url (/payment-methods/payconiq)</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayconiqDTO> CreatePayconiqV2Async(PayInPayconiqPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayconiqDTO, PayInPayconiqPostDTO>(MethodKey.PayinsPayconiqV2WebCreate, payIn, idempotentKey);
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
        
        /// <summary>Creates new payin mbway web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMbwayWebDTO> CreateMbwayWebAsync(PayInMbwayWebPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInMbwayWebDTO, PayInMbwayWebPostDTO>(MethodKey.PayinsMbwayWebCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin multibanco web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInMultibancoWebDTO> CreateMultibancoWebAsync(PayInMultibancoWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInMultibancoWebDTO, PayInMultibancoWebPostDTO>(
                MethodKey.PayinsMultibancoWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin satispay web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInSatispayWebDTO> CreateSatispayWebAsync(PayInSatispayWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInSatispayWebDTO, PayInSatispayWebPostDTO>(
                MethodKey.PayinsSatispayWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin blik web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBlikWebDTO> CreateBlikWebAsync(PayInBlikWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInBlikWebDTO, PayInBlikWebPostDTO>(
                MethodKey.PayinsBlikWebCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin klarna web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInKlarnaWebDTO> CreateKlarnaWebAsync(PayInKlarnaWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInKlarnaWebDTO, PayInKlarnaWebPostDTO>(
                MethodKey.PayinsKlarnaWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin ideal web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInIdealWebDTO> CreateIdealWebAsync(PayInIdealWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInIdealWebDTO, PayInIdealWebPostDTO>(
                MethodKey.PayinsIdealWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin giropay web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInGiropayWebDTO> CreateGiropayWebAsync(PayInGiropayWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInGiropayWebDTO, PayInGiropayWebPostDTO>(
                MethodKey.PayinsGiropayWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin Swish web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInSwishWebDTO> CreateSwishWebAsync(PayInSwishWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInSwishWebDTO, PayInSwishWebPostDTO>(
                MethodKey.PayinsSwishWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin Twint web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInTwintWebDTO> CreateTwintWebAsync(PayInTwintWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInTwintWebDTO, PayInTwintWebPostDTO>(
                MethodKey.PayinsTwintWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin pay-by-bank web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInPayByBankWebDTO> CreatePayByBankWebAsync(PayInPayByBankWebPostDTO payIn,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInPayByBankWebDTO, PayInPayByBankWebPostDTO>(
                MethodKey.PayinsPayByBankWebCreate, payIn, idempotentKey);
        }
        
        /// <summary>Creates new payin bancontact web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBancontactWebDTO> CreateBancontactWebAsync(PayInBancontactWebPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInBancontactWebDTO, PayInBancontactWebPostDTO>(MethodKey.PayinsBancontactWebCreate, payIn, idempotentKey);
        }

        /// <summary>Creates new payin bizum web.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payIn">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInBizumWebDTO> CreateBizumWebAsync(PayInBizumWebPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInBizumWebDTO, PayInBizumWebPostDTO>(MethodKey.PayinsBizumWebCreate,
                payIn, idempotentKey);
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
        [Obsolete("GetPayPalAsync is deprecated, please use GetPayPalWebAsync instead.")]
        public async Task<PayInPayPalDTO> GetPayPalAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInPayPalDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn PayPal Web entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPayPalWebDTO> GetPayPalWebAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInPayPalWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
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
        public async Task<PayInMbwayWebDTO> GetMbwayAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInMbwayWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Multibanco entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInMultibancoWebDTO> GetMultibancoAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInMultibancoWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Satispay entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInSatispayWebDTO> GetSatispayAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInSatispayWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Blik entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInBlikWebDTO> GetBlikAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInBlikWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Klarna entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInKlarnaWebDTO> GetKlarnaAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInKlarnaWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Ideal entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInIdealWebDTO> GetIdealAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInIdealWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Giropay entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInGiropayWebDTO> GetGiropayAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInGiropayWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Swish entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInSwishWebDTO> GetSwishAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInSwishWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Twint entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInTwintWebDTO> GetTwintAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInTwintWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }
        
        /// <summary>Gets PayIn Bancontact entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInBancontactWebDTO> GetBancontactAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInBancontactWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn Bizum entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInBizumWebDTO> GetBizumAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInBizumWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Gets PayIn PayByBank entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<PayInPayByBankWebDTO> GetPayByBankAsync(string payInId)
        {
            return await this.GetObjectAsync<PayInPayByBankWebDTO>(MethodKey.PayinsGet, entitiesId: payInId);
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

        public async Task<PayInGooglePayDirectDTO> CreateGooglePayDirectV2Async(PayInGooglePayDirectPostDTO payIn,
            string idempotentKey = null)
        {
            return await CreateObjectAsync<PayInGooglePayDirectDTO, PayInGooglePayDirectPostDTO>(
                MethodKey.GooglePayinsDirectCreateV2, payIn, idempotentKey);
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
        
        public async Task<RecurringPayInDTO> CreateRecurringPayPalPayInCIT(RecurringPayPalPayInCITPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayPalPayInCITPostDTO>(
                MethodKey.PayinsRecurringPayPal, payIn, idempotentKey);
        }

        public async Task<RecurringPayInDTO> CreateRecurringPayPalPayInMIT(RecurringPayPalPayInMITPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<RecurringPayInDTO, RecurringPayPalPayInMITPostDTO>(
                MethodKey.PayinsRecurringPayPal, payIn, idempotentKey);
        }
        
        /// <summary>
        /// Create a Deposit Preauthorized PayIn without complement
        /// </summary>
        /// <param name="payIn"></param> The PayIn to be created
        /// <param name="idempotentKey"></param> Idempotency key (optional)
        /// <returns>The created PayIn</returns>
        public async Task<CardPreAuthorizedDepositPayInDTO> CreateCardPreAuthorizedDepositPayIn(
            CardPreAuthorizedDepositPayInPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<CardPreAuthorizedDepositPayInDTO, CardPreAuthorizedDepositPayInPostDTO>(
                MethodKey.PayInsCreateCardPreAuthorizedDeposit, payIn, idempotentKey);
        }
        
        /// <summary>
        /// Create a Deposit Preauthorized PayIn prior to complement
        /// </summary>
        /// <param name="payIn"></param> The PayIn to be created
        /// <param name="idempotentKey"></param> Idempotency key (optional)
        /// <returns>The created PayIn</returns>
        public async Task<CardPreAuthorizedDepositPayInDTO> CreateDepositPreauthorizedPayInPriorToComplement(
            CardPreAuthorizedDepositPayInPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<CardPreAuthorizedDepositPayInDTO, CardPreAuthorizedDepositPayInPostDTO>(
                MethodKey.PayInsCreateDepositPreauthorizedPayInPriorToComplement, payIn, idempotentKey);
        }
        
        /// <summary>
        /// Create a Deposit Preauthorized PayIn complement
        /// </summary>
        /// <param name="payIn"></param> The PayIn to be created
        /// <param name="idempotentKey"></param> Idempotency key (optional)
        /// <returns>The created PayIn</returns>
        public async Task<CardPreAuthorizedDepositPayInDTO> CreateDepositPreauthorizedPayInComplement(
            CardPreAuthorizedDepositPayInPostDTO payIn, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<CardPreAuthorizedDepositPayInDTO, CardPreAuthorizedDepositPayInPostDTO>(
                MethodKey.PayInsCreateDepositPreauthorizedPayInComplement, payIn, idempotentKey);
        }
        
        /// <summary>Look up metadata from BIN or Google Pay token</summary>
        /// <param name="metadata">PaymentMethodMetadata object</param>
        /// <returns>Object returned from API.</returns>
        public async Task<PaymentMethodMetadataDTO> GetPaymentMethodMetadataAsync(PaymentMethodMetadataPostDTO metadata)
        {
            return await this.CreateObjectAsync<PaymentMethodMetadataDTO, PaymentMethodMetadataPostDTO>(MethodKey.GetPaymentMethodMetadata, metadata, null);
        }
        
        /// <summary>Add tracking information to a PayPal PayIn (add the tracking number and carrier for LineItems shipments.)</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <param name="trackingInformation">The tracking information to be added.</param>
        /// <returns>The updated PayPal PayIn.</returns>
        public async Task<PayInPayPalWebDTO> AddPayPalTrackingInformation(string payInId, PayPalTrackingInformationPutDTO trackingInformation)
        {
            return await this.UpdateObjectAsync<PayInPayPalWebDTO, PayPalTrackingInformationPutDTO>(MethodKey.PayInsAddTrackingInformation, trackingInformation, null, payInId);
        }
        
        /// <summary>Gets PayIn ApplePay entity by its identifier.</summary>
        /// <param name="payInId">PayIn identifier.</param>
        /// <returns>PayIn object returned from API.</returns>
        public async Task<ApplePayDirectPayinDTO> GetApplePayAsync(string payInId)
        {
            return await this.GetObjectAsync<ApplePayDirectPayinDTO>(MethodKey.PayinsGet, entitiesId: payInId);
        }

        /// <summary>Creates new payin intent authorization.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payInIntentAuthorization">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInIntentDTO> CreatePayInIntentAuthorizationAsync(
            PayInIntentAuthorizationPostDTO payInIntentAuthorization, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInIntentDTO, PayInIntentAuthorizationPostDTO>(
                MethodKey.PayInIntentAuthorizationCreate, payInIntentAuthorization, idempotentKey);
        }
        
        /// <summary>Creates new payin intent full capture.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payInIntentFullCapture">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInIntentDTO> CreatePayInIntentFullCaptureAsync(
            PayInIntentFullCapturePostDTO payInIntentFullCapture, string payInIntentId, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInIntentDTO, PayInIntentFullCapturePostDTO>(
                MethodKey.PayInIntentCaptureCreate, payInIntentFullCapture, idempotentKey, entitiesId: payInIntentId);
        }

        /// <summary>Creates new payin intent partial capture.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payInIntentPartialCapture">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInIntentDTO> CreatePayInIntentPartialCaptureAsync(
            PayInIntentPartialCapturePostDTO payInIntentPartialCapture, string payInIntentId,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayInIntentDTO, PayInIntentPartialCapturePostDTO>(
                MethodKey.PayInIntentCaptureCreate, payInIntentPartialCapture, idempotentKey,
                entitiesId: payInIntentId);
        }
        
        /// <summary>Get a PayInIntent</summary>
        /// <returns>Object instance returned from API.</returns>
        public async Task<PayInIntentDTO> GetPayInIntentAsync(string payInIntentId)
        {
            return await this.GetObjectAsync<PayInIntentDTO>(MethodKey.PayInIntentGet, entitiesId: payInIntentId);
        }

        // /// <summary>
        // /// Update an Intent
        // /// </summary>
        // /// <param name="payInIntentId">Intent identifier</param>
        // /// <param name="intent">Object containing the fields to be updated</param>
        // /// <returns>Object intent returned from API.</returns>
        // public async Task<PayInIntentDTO> UpdatePayInIntentAsync(string payInIntentId, PayInIntentPutDTO intent)
        // {
        //     return await this.UpdateObjectAsync<PayInIntentDTO, PayInIntentPutDTO>(MethodKey.PayInIntentUpdate, intent,
        //         entitiesId: payInIntentId);
        // }
        
        /*
        /// <summary>
        /// Cancel an Intent
        /// </summary>
        /// <param name="payInIntentId">Intent identifier</param>
        /// <param name="intent">Object containing required fields for canceling</param>
        /// <returns>Object intent returned from API.</returns>
        public async Task<PayInIntentDTO> CancelPayInIntentAsync(string payInIntentId, PayInIntentCancelPutDTO intent)
        {
            return await this.UpdateObjectAsync<PayInIntentDTO, PayInIntentCancelPutDTO>(MethodKey.PayInIntentCancel, 
                intent, entitiesId: payInIntentId);
        }*/

        /// <summary>Create PayInIntent Splits</summary>
        /// <param name="payInIntentId">Intent identifier</param>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="splits">Object instance to be created.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<IntentSplitsDTO> CreatePayInIntentSplitsAsync(IntentSplitsPostDTO splits, string payInIntentId,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<IntentSplitsDTO, IntentSplitsPostDTO>(MethodKey.PayInIntentCreateSplits, 
                splits, idempotentKey, entitiesId: payInIntentId);
        }
        
        /// <summary>
        /// Retrieve a paginated list of banks that you can present to the user for selection during their Pay by Bank checkout experience
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <param name="pagination">Pagination</param>
        /// <returns>Supported banks as PayInPayByBankSupportedBankDTO</returns>
        public async Task<PayInPayByBankSupportedBankDTO> GetPayByBankSupportedBanks(FilterSupportedBanks filter = null, 
            Pagination pagination = null)
        {
            return await this.GetObjectAsync<PayInPayByBankSupportedBankDTO>(MethodKey.PayByBankGetSupportedBanks, 
                filter?.GetValues(), pagination);
        }
    }
}
