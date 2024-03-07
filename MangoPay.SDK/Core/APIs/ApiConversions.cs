using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;

namespace MangoPay.SDK.Core.APIs
{
    public class ApiConversions : ApiBase
    {
        public ApiConversions(MangoPayApi root) : base(root)
        {
        }

        public async Task<ConversionRateDTO> GetConversionRate(string debitedCurrency, string creditedCurrency)
        {
            return await this.GetObjectAsync<ConversionRateDTO>(MethodKey.GetConversionRate,
                entitiesId: new[] { debitedCurrency, creditedCurrency });
        }

        public async Task<ConversionDTO> CreateInstantConversion(InstantConversionPostDTO instantConversion,
            string idempotentKey = null)
        {
            return await
                this.CreateObjectAsync<ConversionDTO, InstantConversionPostDTO>(MethodKey.CreateInstantConversion,
                    instantConversion, idempotentKey);
        }

        public async Task<ConversionDTO> GetInstantConversion(string id)
        {
            return await this.GetObjectAsync<ConversionDTO>(MethodKey.GetConversion,
                entitiesId: id);
        }

        public async Task<ConversionQuoteDTO> CreateConversionQuote(ConversionQuotePostDTO conversionQuote,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<ConversionQuoteDTO, ConversionQuotePostDTO>(
                MethodKey.CreateConversionQuote,
                conversionQuote,
                idempotentKey);
        }

        public async Task<ConversionQuoteDTO> GetConversionQuote(string id)
        {
            return await this.GetObjectAsync<ConversionQuoteDTO>(MethodKey.GetConversionQuote, entitiesId: id);
        }

        public async Task<ConversionDTO> CreateQuotedConversion(
            QuotedConversionPostDTO quotedConversionPostDto,
            string idempotentKey = null)
        {
            return await this.CreateObjectAsync<ConversionDTO, QuotedConversionPostDTO>(
                MethodKey.CreateQuotedConversion,
                quotedConversionPostDto,
                idempotentKey);
        }
    }
}