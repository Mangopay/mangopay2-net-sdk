using System;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;

namespace MangoPay.SDK.Core.APIs
{
    public class ApiUboDeclarations : ApiBase
    {
        public ApiUboDeclarations(MangoPayApi root)
            : base(root) {}

        public async Task<ListPaginated<UboDeclarationDTO>> GetUboDeclarationByUserIdAsync(string userId, Pagination pagination = null,
            Sort sort = null)
        {
            return await GetListAsync<UboDeclarationDTO>(
                MethodKey.UboDeclarationsGet,
                pagination,
                sort,
                entitiesId: userId
            );
        }

        public async Task<UboDeclarationDTO> CreateUboDeclarationAsync(string userId, string idempotentKey = null)
        {
            return await CreateObjectAsync<UboDeclarationDTO, EntityPostBase>(
                MethodKey.UboDeclarationCreate,
                null,
                idempotentKey,
                userId
            );
        }

        public async Task<UboDeclarationDTO> GetUboDeclarationByIdAsync(string userId, string uboDeclarationId)
        {
            return await GetObjectAsync<UboDeclarationDTO>(
                MethodKey.UboDeclarationGet,
                null,
                userId,
                uboDeclarationId
            );
        }

        public async Task<UboDeclarationDTO> GetUboDeclarationByIdAsync(string uboDeclarationId)
        {
            return await GetObjectAsync<UboDeclarationDTO>(
                MethodKey.UboDeclarationGetById,
                null,
                uboDeclarationId
            );
        }

        public async Task<UboDeclarationDTO> UpdateUboDeclarationAsync(UboDeclarationPutDTO uboDeclaration, string userId,
            string uboDeclarationId)
        {
            return await UpdateObjectAsync<UboDeclarationDTO, UboDeclarationPutDTO>(
                MethodKey.UboDeclarationUpdate,
                uboDeclaration,
                null,
                userId,
                uboDeclarationId
            );
        }

        public async Task<UboDTO> GetUboAsync(string userId, string uboDeclarationId, string uboId)
        {
            return await GetObjectAsync<UboDTO>(
                MethodKey.UboGet,
                null,
                userId,
                uboDeclarationId,
                uboId);
        }

        public async Task<UboDTO> CreateUboAsync(UboPostDTO ubo, string userId, string uboDeclarationId, string idempotentKey = null)
        {
            return await CreateObjectAsync<UboDTO, UboPostDTO>(
                MethodKey.UboCreate,
                ubo,
                idempotentKey,
                userId,
                uboDeclarationId);
        }

        public async Task<UboDTO> UpdateUboAsync(UboPutDTO ubo, string userId, string uboDeclarationId, string uboId)
        {
            return await UpdateObjectAsync<UboDTO, UboPutDTO>(
                MethodKey.UboUpdate,
                ubo,
                null,
                userId,
                uboDeclarationId,
                uboId
            );
        }
    }
}