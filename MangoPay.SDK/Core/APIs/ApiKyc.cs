using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.PUT;
using System;

namespace MangoPay.SDK.Core.APIs
{
    /// <summary>API for KYC documents.</summary>
    public class ApiKyc : ApiBase
    {
        /// <summary>Instantiates new ApiKyc object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiKyc(MangoPayApi root) : base(root) { }

        /// <summary>Gets KYC document.</summary>
        /// <param name="kycDocumentId">KYC document identifier.</param>
        /// <returns>KYC document instance returned from API.</returns>
        public KycDocumentDTO Get(String kycDocumentId)
        {
            return this.GetObject<KycDocumentDTO>(MethodKey.GetKycDocument, kycDocumentId);
        }
    }
}