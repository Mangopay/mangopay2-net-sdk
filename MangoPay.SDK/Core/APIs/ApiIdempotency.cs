using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for Idempotency.</summary>
    public class ApiIdempotency : ApiBase
    {
		/// <summary>Instantiates new ApiIdempotency object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
		public ApiIdempotency(MangoPayApi root) : base(root) { }

        /// <summary>Gets idempotency response.</summary>
		/// <param name="idempotencyKey">Idempotency key for .</param>
		/// <returns>Idempotency response instance returned from API.</returns>
        public IdempotencyResponseDTO Get(String idempotencyKey)
        {
			var response = this.GetObject<IdempotencyResponseDTO>(MethodKey.IdempotencyResponseGet, idempotencyKey);
			LoadResourceObject(response);
			
			return response;
        }

		private void LoadResourceObject(IdempotencyResponseDTO response)
		{
			Type targetType = null;
			var map = GetMapForResource();
			foreach (var mapItem in map)
			{
				var endPoint = GetApiEndPoint(mapItem.Key);
				endPoint.SetParameters("[0-9a-zA-Z]+", "[0-9a-zA-Z]+");

				var sourceUrl = endPoint.GetUrl();
				sourceUrl = sourceUrl.Replace("/", "\\/");
				Regex ex = new Regex(sourceUrl);
				if (ex.IsMatch(response.RequestURL))
				{
					targetType = mapItem.Value;
					break;
				}
			}

			if (targetType == null)
				return;

			MethodInfo method = typeof(MangoPayJsonDeserializer).GetMethod("DeserializeString").MakeGenericMethod(targetType);
			response.Resource = method.Invoke(new MangoPayJsonDeserializer(), new object[] { response.Resource });
		}

		private Dictionary<MethodKey, Type> GetMapForResource()
		{
			return new Dictionary<MethodKey, Type>
			{
				{ MethodKey.PreauthorizationCreate, typeof(CardPreAuthorizationDTO) },
				{ MethodKey.HooksCreate, typeof(HookDTO) },
				{ MethodKey.CardRegistrationCreate, typeof(CardRegistrationDTO) },
				{ MethodKey.PayinsCardWebCreate, typeof(PayInCardWebDTO) },
				{ MethodKey.PayinsCardDirectCreate, typeof(PayInCardDirectDTO) },
				{ MethodKey.PayinsCreateRefunds, typeof(RefundDTO) },
				{ MethodKey.PayinsPreauthorizedDirectCreate, typeof(PayInPreauthorizedDirectDTO) },
				{ MethodKey.PayinsBankwireDirectCreate, typeof(PayInBankWireDirectDTO) },
				{ MethodKey.PayinsDirectDebitCreate, typeof(PayInDirectDebitDTO) },
				{ MethodKey.PayinsMandateDirectDebitCreate, typeof(PayInMandateDirectDTO) },
				{ MethodKey.PayoutsBankwireCreate, typeof(PayOutBankWireDTO) },
				{ MethodKey.TransfersCreateRefunds, typeof(RefundDTO) },
				{ MethodKey.TransfersCreate, typeof(TransferDTO) },
				{ MethodKey.UsersCreateNaturals, typeof(UserNaturalDTO) },
				{ MethodKey.UsersCreateLegals, typeof(UserLegalDTO) },
				{ MethodKey.UsersCreateKycDocument, typeof(KycDocumentDTO) },
				{ MethodKey.UsersCreateBankAccountsIban, typeof(BankAccountIbanDTO) },
				{ MethodKey.UsersCreateBankAccountsGb, typeof(BankAccountGbDTO) },
				{ MethodKey.UsersCreateBankAccountsUs, typeof(BankAccountUsDTO) },
				{ MethodKey.UsersCreateBankAccountsCa, typeof(BankAccountCaDTO) },
				{ MethodKey.UsersCreateBankAccountsOther, typeof(BankAccountOtherDTO) },
				{ MethodKey.WalletsCreate, typeof(WalletDTO) },
				{ MethodKey.ClientCreateBankwireDirect, typeof(PayInBankWireDirectDTO) },
				{ MethodKey.DisputesDocumentCreate, typeof(DisputeDocumentDTO) },
				{ MethodKey.DisputesRepudiationCreateSettlement, typeof(SettlementDTO) },
				{ MethodKey.MandateCreate, typeof(MandateDTO) }
			};
		}
	}
}
