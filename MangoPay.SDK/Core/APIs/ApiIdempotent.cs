using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for Idempotent.</summary>
    public class ApiIdempotent : ApiBase
    {
        /// <summary>Instantiates new ApiIdempotent object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiIdempotent(MangoPayApi root) : base(root) { }

        /// <summary>Gets idempotent response.</summary>
		/// <param name="key">Idempotent key for .</param>
		/// <returns>Idempotent response instance returned from API.</returns>
        public async Task<IdempotencyResponseDTO> GetAsync(string key)
        {
            var response = await this.GetObjectAsync<IdempotencyResponseDTO>(MethodKey.IdempotencyResponseGet, entitiesId: key);
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
                endPoint.SetParameters(new[] { "[0-9a-zA-Z_-]+", "[0-9a-zA-Z]+" });

                var sourceUrl = endPoint.GetUrl();
                sourceUrl = sourceUrl.Replace("/", "\\/");
                var ex = new Regex(sourceUrl);
                if (!ex.IsMatch(response.RequestURL)) continue;
                
                targetType = mapItem.Value;
                break;
            }

            if (targetType == null)
                return;

            var method = typeof(MangoPayJsonDeserializer).GetMethod("DeserializeString")?.MakeGenericMethod(targetType);
            response.Resource = method?.Invoke(new MangoPayJsonDeserializer(), new object[] { response.Resource });
        }

        private static Dictionary<MethodKey, Type> GetMapForResource()
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
                { MethodKey.UboDeclarationCreate, typeof(UboDeclarationDTO) },
                { MethodKey.UsersCreateNaturals, typeof(UserNaturalDTO) },
                { MethodKey.UsersCreateLegals, typeof(UserLegalDTO) },
                { MethodKey.UsersCreateNaturalsSca, typeof(UserNaturalScaDTO) },
                { MethodKey.UsersCreateLegalsSca, typeof(UserLegalScaDTO) },
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
                { MethodKey.MandateCreate, typeof(MandateDTO) },
                { MethodKey.PayinsPayByBankWebCreate, typeof(PayInPayByBankWebDTO) },
                { MethodKey.PayinsRecurringPayPal, typeof(RecurringPayInDTO) },
                { MethodKey.RecipientCreate, typeof(RecipientDTO) },
                { MethodKey.UsersValidateDataFormat, typeof(UserDataFormatValidationDTO) },
                { MethodKey.ReportCreate, typeof(ReportDTO) },
                { MethodKey.SettlementCreate, typeof(IntentSettlementDTO) },
                { MethodKey.PayInIntentCreateSplits, typeof(IntentSplitsDTO) },
                { MethodKey.PayInIntentExecuteSplit, typeof(PayInIntentSplitDTO) },
                { MethodKey.PayInIntentReverseSplit, typeof(PayInIntentSplitDTO) }
            };
        }
    }
}