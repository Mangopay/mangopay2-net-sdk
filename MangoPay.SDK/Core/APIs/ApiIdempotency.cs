using MangoPay.SDK.Core.Enumerations;
using MangoPay.SDK.Entities;
using MangoPay.SDK.Entities.GET;
using MangoPay.SDK.Entities.POST;
using MangoPay.SDK.Entities.PUT;
using System;
using System.Collections.Generic;

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
			return this.GetObject<IdempotencyResponseDTO>(MethodKey.IdempotencyResponseGet, idempotencyKey);
        }
    }
}
