using System;
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