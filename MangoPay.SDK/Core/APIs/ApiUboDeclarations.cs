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
            : base(root)
        {
        }

        public async Task<UboDeclarationDTO> CreateAsync(String userId)
        {
            return await CreateUboDeclarationAsync(null, userId);
        }

        public async Task<ListPaginated<UboDeclarationDTO>> GetUboDeclarationByUserIdAsync(String userId, Pagination pagination,
            Sort sort = null)
        {
            return await GetListAsync<UboDeclarationDTO>(
                MethodKey.UboDeclarationsGet,
                pagination,
                sort,
                userId
            );
        }

        public async Task<UboDeclarationDTO> GetUboDeclarationByIdAsync(String userId, String uboDeclarationId)
        {
            return await GetObjectAsync<UboDeclarationDTO>(
                MethodKey.UboDeclarationGet,
                userId,
                uboDeclarationId
            );
        }

        public async Task<UboDeclarationDTO> GetUboDeclarationByIdAsync(String uboDeclarationId)
        {
            return await GetObjectAsync<UboDeclarationDTO>(
                MethodKey.UboDeclarationGetById,
                uboDeclarationId
            );
        }

        public async Task<UboDeclarationDTO> CreateUboDeclarationAsync(String idempotencyKey, String userId)
        {
            return await CreateObjectAsync<UboDeclarationDTO, EntityPostBase>(
                idempotencyKey,
                MethodKey.UboDeclarationCreate,
                null,
                userId
            );
        }

        public async Task<UboDeclarationDTO> UpdateUboDeclarationAsync(UboDeclarationPutDTO uboDeclaration, String userId,
            String uboDeclarationId)
        {
            return await UpdateObjectAsync<UboDeclarationDTO, UboDeclarationPutDTO>(
                MethodKey.UboDeclarationUpdate,
                uboDeclaration,
                userId,
                uboDeclarationId
            );
        }

        public async Task<UboDTO> GetUboAsync(String userId, String uboDeclarationId, String uboId)
        {
            return await GetObjectAsync<UboDTO>(
                MethodKey.UboGet,
                userId,
                uboDeclarationId,
                uboId);
        }

        public async Task<UboDTO> CreateUboAsync(UboPostDTO ubo, String userId, String uboDeclarationId)
        {
            return await CreateUboAsync(null, ubo, userId, uboDeclarationId);
        }

        public async Task<UboDTO> CreateUboAsync(String idempotencyKey, UboPostDTO ubo, String userId, String uboDeclarationId)
        {
            return await CreateObjectAsync<UboDTO, UboPostDTO>(
                idempotencyKey,
                MethodKey.UboCreate,
                ubo,
                userId,
                uboDeclarationId);
        }

        public async Task<UboDTO> UpdateUboAsync(UboPutDTO ubo, String userId, String uboDeclarationId, String uboId)
        {
            return await UpdateObjectAsync<UboDTO, UboPutDTO>(
                MethodKey.UboUpdate,
                ubo,
                userId,
                uboDeclarationId,
                uboId
            );
        }

        public UboDeclarationDTO Create(String userId)
        {
            return CreateUboDeclaration(null, userId);
        }

        public ListPaginated<UboDeclarationDTO> GetUboDeclarationByUserId(String userId, Pagination pagination,
            Sort sort = null)
        {
            return GetList<UboDeclarationDTO>(
                MethodKey.UboDeclarationsGet,
                pagination,
                sort,
                userId
            );
        }

        public UboDeclarationDTO GetUboDeclarationById(String userId, String uboDeclarationId)
        {
            return GetObject<UboDeclarationDTO>(
                MethodKey.UboDeclarationGet,
                userId,
                uboDeclarationId
            );
        }

        public UboDeclarationDTO GetUboDeclarationById(String uboDeclarationId)
        {
            return GetObject<UboDeclarationDTO>(
                MethodKey.UboDeclarationGetById,
                uboDeclarationId
            );
        }

        public UboDeclarationDTO CreateUboDeclaration(String idempotencyKey, String userId)
        {
            return CreateObject<UboDeclarationDTO, EntityPostBase>(
                idempotencyKey,
                MethodKey.UboDeclarationCreate,
                null,
                userId
            );
        }

        public UboDeclarationDTO UpdateUboDeclaration(UboDeclarationPutDTO uboDeclaration, String userId,
            String uboDeclarationId)
        {
            return UpdateObject<UboDeclarationDTO, UboDeclarationPutDTO>(
                MethodKey.UboDeclarationUpdate,
                uboDeclaration,
                userId,
                uboDeclarationId
            );
        }

        public UboDTO GetUbo(String userId, String uboDeclarationId, String uboId)
        {
            return GetObject<UboDTO>(
                MethodKey.UboGet,
                userId,
                uboDeclarationId,
                uboId);
        }

        public UboDTO CreateUbo(UboPostDTO ubo, String userId, String uboDeclarationId)
        {
            return CreateUbo(null, ubo, userId, uboDeclarationId);
        }

        public UboDTO CreateUbo(String idempotencyKey, UboPostDTO ubo, String userId, String uboDeclarationId)
        {
            return CreateObject<UboDTO, UboPostDTO>(
                idempotencyKey,
                MethodKey.UboCreate,
                ubo,
                userId,
                uboDeclarationId);
        }

        public UboDTO UpdateUbo(UboPutDTO ubo, String userId, String uboDeclarationId, String uboId)
        {
            return UpdateObject<UboDTO, UboPutDTO>(
                MethodKey.UboUpdate,
                ubo,
                userId,
                uboDeclarationId,
                uboId
            );
        }
    }
}