using System;
using MangoPay.SDK.Core.Enumerations;
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

		public UboDeclarationDTO Create(String idempotencyKey, UboDeclarationPostDTO uboDeclaration)
		{
			return CreateObject<UboDeclarationDTO, UboDeclarationPostDTO>(
			  idempotencyKey,
			  MethodKey.UboDeclarationCreate,
			  uboDeclaration,
			  uboDeclaration.UserId
			);
		}

		public UboDeclarationDTO Update(UboDeclarationPutDTO uboDeclaration)
		{
			return UpdateObject<UboDeclarationDTO, UboDeclarationPutDTO>(
			  MethodKey.HooksSave,
			  uboDeclaration,
			  uboDeclaration.ID
			);
		}
	}
}