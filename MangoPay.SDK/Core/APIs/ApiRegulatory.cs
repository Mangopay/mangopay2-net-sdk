using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for refunds.</summary>
    public class ApiRegulatory : ApiBase
    {
        /// <summary>Instantiates new ApiRefunds object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiRegulatory(MangoPayApi root) : base(root) { }

        /// <summary>Gets Country Authorizations based on country code</summary>
        /// <param name="countryCode">Country Code.</param>
        public async Task<CountryAuthorizationDTO> GetCountryAuthorizations(CountryIso countryCode)
        {
            return await this.GetObjectAsyncNoClientId<CountryAuthorizationDTO>(MethodKey.CountryAuthorizationGet, entitiesId: countryCode.ToString());
        }

        /// <summary>Gets All Countries Authorizations.</summary>
        public async Task<ListPaginated<CountryAuthorizationDTO>> GetAllCountriesAuthorizations()
        {
            return await GetListAsyncNoClientId<CountryAuthorizationDTO>(MethodKey.CountryAuthorizationGetAll);
        }
    }
}
