using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using System;
using System.Threading.Tasks;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for pay-outs.</summary>
    public class ApiPayOuts : ApiBase
    {
        /// <summary>Instantiates new ApiPayOuts object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiPayOuts(MangoPayApi root) : base(root) { }

        /// <summary>Creates new PayOut object.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="payOut">The PayOut object to be created.</param>
        /// <returns>Created PayOut object returned from API.</returns>
        public async Task<PayOutBankWireDTO> CreateBankWireAsync(PayOutBankWirePostDTO payOut, string idempotentKey = null)
        {
            return await this.CreateObjectAsync<PayOutBankWireDTO, PayOutBankWirePostDTO>(MethodKey.PayoutsBankwireCreate, payOut, idempotentKey);
        }

        public async Task<PayOutEligibilityDTO> CheckInstantPayoutEligibility(PayOutEligibilityPostDTO payOut, string idempotencyKey = null)
        {
            return await this.CreateObjectAsync<PayOutEligibilityDTO, PayOutEligibilityPostDTO>(MethodKey.PayoutsEligibility, payOut, idempotencyKey);
        }

        /// <summary>Gets PayOut entity by its identifier.</summary>
        /// <param name="payOutId">PayOut identifier.</param>
        /// <returns>PayOut instance returned from API.</returns>
        public async Task<PayOutDTO> GetAsync(string payOutId)
        {
            return await this.GetObjectAsync<PayOutDTO>(MethodKey.PayoutsGet, entitiesId: payOutId);
        }

        /// <summary>Gets PayOut entity by its identifier.</summary>
        /// <param name="payOutId">PayOutBankWire identifier.</param>
        /// <returns>PayOutBankWire instance returned from API.</returns>
        public async Task<PayOutBankWireDTO> GetBankWireAsync(string payOutId)
        {
            return await this.GetObjectAsync<PayOutBankWireDTO>(MethodKey.PayoutsGet, entitiesId: payOutId);
        }

        /// <summary>
        /// Gets async PayOut Bankwire Entity by its identifier
        /// </summary>
        /// <param name="payoutId">PayOutBankWire identifier.</param>
        /// <returns></returns>
        public async Task<PayOutBankWireGetDTO> GetBankwirePayoutAsync(string payoutId)
        {
            return await this.GetObjectAsync<PayOutBankWireGetDTO>(MethodKey.PayoutsBankwireGet, entitiesId: payoutId);
        }
    }
}
