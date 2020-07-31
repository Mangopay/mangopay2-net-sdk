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

        public async Task<UboDeclarationDTO> Create(String userId)
        {
            return await CreateUboDeclaration(null, userId);
        }

        public async Task<ListPaginated<UboDeclarationDTO>> GetUboDeclarationByUserId(String userId, Pagination pagination,
            Sort sort = null)
        {
            return await GetList<UboDeclarationDTO>(
                MethodKey.UboDeclarationsGet,
                pagination,
                sort,
                userId
            );
        }

        public async Task<UboDeclarationDTO> GetUboDeclarationById(String userId, String uboDeclarationId)
        {
            return await GetObject<UboDeclarationDTO>(
                MethodKey.UboDeclarationGet,
                userId,
                uboDeclarationId
            );
        }

        public async Task<UboDeclarationDTO> GetUboDeclarationById(String uboDeclarationId)
        {
            return await GetObject<UboDeclarationDTO>(
                MethodKey.UboDeclarationGetById,
                uboDeclarationId
            );
        }

        public async Task<UboDeclarationDTO> CreateUboDeclaration(String idempotencyKey, String userId)
        {
            return await CreateObject<UboDeclarationDTO, EntityPostBase>(
                idempotencyKey,
                MethodKey.UboDeclarationCreate,
                null,
                userId
            );
        }

        public async Task<UboDeclarationDTO> UpdateUboDeclaration(UboDeclarationPutDTO uboDeclaration, String userId,
            String uboDeclarationId)
        {
            return await UpdateObject<UboDeclarationDTO, UboDeclarationPutDTO>(
                MethodKey.UboDeclarationUpdate,
                uboDeclaration,
                userId,
                uboDeclarationId
            );
        }

        public async Task<UboDTO> GetUbo(String userId, String uboDeclarationId, String uboId)
        {
            return await GetObject<UboDTO>(
                MethodKey.UboGet,
                userId,
                uboDeclarationId,
                uboId);
        }

        public async Task<UboDTO> CreateUbo(UboPostDTO ubo, String userId, String uboDeclarationId)
        {
            return await CreateUbo(null, ubo, userId, uboDeclarationId);
        }

        public async Task<UboDTO> CreateUbo(String idempotencyKey, UboPostDTO ubo, String userId, String uboDeclarationId)
        {
            return await CreateObject<UboDTO, UboPostDTO>(
                idempotencyKey,
                MethodKey.UboCreate,
                ubo,
                userId,
                uboDeclarationId);
        }

        public async Task<UboDTO> UpdateUbo(UboPutDTO ubo, String userId, String uboDeclarationId, String uboId)
        {
            return await UpdateObject<UboDTO, UboPutDTO>(
                MethodKey.UboUpdate,
                ubo,
                userId,
                uboDeclarationId,
                uboId
            );
        }
    }
}