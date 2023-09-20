using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;

namespace MangoPay.SDK.Core.APIs
{
    public class ApiInstantConversion : ApiBase
    {
        public ApiInstantConversion(MangoPayApi root) : base(root)
        {
        }

        public async Task<ConversionRateDTO> GetConversionRate(string debitedCurrency, string creditedCurrency)
        {
            return await this.GetObjectAsync<ConversionRateDTO>(MethodKey.GetConversionRate,
                entitiesId: new[] { debitedCurrency, creditedCurrency });
        }

        public async Task<InstantConversionDTO> CreateInstantConversion(InstantConversionPostDTO instantConversion,
            string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<InstantConversionDTO, InstantConversionPostDTO>(MethodKey.CreateInstantConversion,
                    instantConversion, idempotentKey);
        }
        
        public async Task<InstantConversionDTO> GetInstantConversion(string id)
        {
            return await this.GetObjectAsync<InstantConversionDTO>(MethodKey.GetInstantConversion,
                entitiesId: id);
        }
    }
}