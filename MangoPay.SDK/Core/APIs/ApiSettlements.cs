using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for settlements.</summary>
    public class ApiSettlements : ApiBase
    {
        /// <summary>Instantiates new ApiSettlements object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiSettlements(MangoPayApi root) : base(root)
        {
        }

        /// <summary>Uploads a settlement file.</summary>
        /// <param name="file">The file to be uploaded</param>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<IntentSettlementDTO> Upload(
            byte[] file,
            string idempotentKey = null
        )
        {
            return await CreateOrUpdateMultipartAsync<IntentSettlementDTO>(MethodKey.SettlementCreate, file,
                idempotentKey);
        }

        /// <summary>Fetches details about a Settlement.</summary>
        /// <param name="settlementId">Settlement identifier</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<IntentSettlementDTO> Get(string settlementId)
        {
            return await GetObjectAsync<IntentSettlementDTO>(MethodKey.SettlementGet, entitiesId: settlementId);
        }

        /// <summary>Updates a settlement file.</summary>
        /// <param name="settlementId">Settlement identifier</param>
        /// <param name="file">The file to be updated</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<IntentSettlementDTO> Update(
            string settlementId,
            byte[] file
        )
        {
            return await CreateOrUpdateMultipartAsync<IntentSettlementDTO>(MethodKey.SettlementUpdate, file,
                entitiesId: settlementId);
        }
    }
}