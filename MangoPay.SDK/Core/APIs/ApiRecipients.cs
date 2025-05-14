using System.Collections.Generic;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for recipients.</summary>
    public class ApiRecipients : ApiBase
    {
        /// <summary>Instantiates new ApiRecipients object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiRecipients(MangoPayApi root) : base(root)
        {
        }

        /// <summary>Creates new recipient.</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="recipient">Object instance to be created.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task<RecipientDTO> CreateAsync(RecipientPostDTO recipient, string userId,
            string idempotentKey = null)
        {
            return await CreateObjectAsync<RecipientDTO, RecipientPostDTO>(MethodKey.RecipientCreate, recipient,
                idempotentKey, userId);
        }

        /// <summary>Gets recipient.</summary>
        /// <param name="recipientId">Recipient identifier.</param>
        /// <returns>Recipient instance returned from API.</returns>
        public async Task<RecipientDTO> GetAsync(string recipientId)
        {
            return await GetObjectAsync<RecipientDTO>(MethodKey.RecipientGet, entitiesId: recipientId);
        }

        /// <summary>Gets all recipients for a user.</summary>
        /// <param name="userId">Recipient identifier.</param>
        /// <param name="pagination">Pagination.</param>
        /// <param name="sort">Sort.</param>
        /// <returns>Recipient instance returned from API.</returns>
        public async Task<ListPaginated<RecipientDTO>> GetUserRecipientsAsync(string userId,
            Pagination pagination = null,
            Sort sort = null)
        {
            return await GetListAsync<RecipientDTO>(MethodKey.RecipientGetAll, pagination, sort, entitiesId: userId);
        }

        /// <summary>See payout methods available to your platform by currency and country.</summary>
        /// <param name="country">Recipient identifier.</param>
        /// <param name="currency">Pagination.</param>
        /// <returns>Recipient instance returned from API.</returns>
        public async Task<PayoutMethods> GetPayoutMethodsAsync(CountryIso country, CurrencyIso currency)
        {
            return await GetObjectAsync<PayoutMethods>(MethodKey.RecipientGetPayoutMethods,
                new Dictionary<string, string>
                {
                    { "country", country.ToString() },
                    { "currency", currency.ToString() }
                });
        }

        /// <summary>Gets a Recipient schema.</summary>
        /// <param name="payoutMethodType">Defines the payout method (e.g., LocalBankTransfer, InternationalBankTransfer).</param>
        /// <param name="recipientType">Specifies whether the recipient is an Individual or a Business.</param>
        /// <param name="currency">3-letter ISO 4217 destination currency code (e.g. EUR, USD, GBP, AUD, CAD,HKD, SGD, MXN).</param>
        /// <param name="country">Country ISO</param>
        /// <returns>RecipientSchema instance returned from API.</returns>
        public async Task<RecipientSchemaDTO> GetSchemaAsync(string payoutMethodType, string recipientType,
            CurrencyIso currency, CountryIso country)
        {
            return await GetObjectAsync<RecipientSchemaDTO>(MethodKey.RecipientGetSchema,
                additionalUrlParams: new Dictionary<string, string>
                {
                    { "payoutMethodType", payoutMethodType },
                    { "recipientType", recipientType },
                    { "currency", currency.ToString() },
                    { "country", country.ToString() }
                });
        }

        /// <summary>Validate recipient data</summary>
        /// <param name="idempotentKey">Idempotent key for this request.</param>
        /// <param name="recipient">Object instance to be created.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Object instance returned from API.</returns>
        public async Task ValidateAsync(RecipientPostDTO recipient, string userId,
            string idempotentKey = null)
        {
            await CreateObjectAsync<RecipientDTO, RecipientPostDTO>(MethodKey.RecipientValidate, recipient,
                idempotentKey, userId);
        }

        /// <summary>Deactivate recipient.</summary>
        /// <param name="recipient">Recipient update DTO. The status should be set to DEACTIVATED</param>
        /// <param name="recipientId">Recipient identifier.</param>
        /// <returns>Recipient object returned from API.</returns>
        public async Task<RecipientDTO> DeactivateAsync(RecipientPutDTO recipient, string recipientId)
        {
            return await UpdateObjectAsync<RecipientDTO, RecipientPutDTO>(
                MethodKey.RecipientDeactivate, recipient, entitiesId: recipientId);
        }
    }
}