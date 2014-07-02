using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Core
{
    /// <summary>API for transfers.</summary>
    public class ApiTransfers : ApiBase
    {
        /// <summary>Instantiates new ApiTransfers object.</summary>
        /// <param name="root">Root/parent instance that holds the OAuthToken and Configuration instance.</param>
        public ApiTransfers(MangoPayApi root) : base(root) { }

        /// <summary>Creates new transfer.</summary>
        /// <param name="transfer">Transfer entity instance to be created.</param>
        /// <returns>Transfer object returned from API.</returns>
        public Transfer Create(Transfer transfer)
        {
            return this.CreateObject<Transfer>("transfers_create", transfer);
        }

        /// <summary>Gets the transfer.</summary>
        /// <param name="transferId">Transfer identifier.</param>
        /// <returns>Transfer instance returned from API.</returns>
        public Transfer Get(String transferId)
        {
            return this.GetObject<Transfer>("transfers_get", transferId);
        }

        /// <summary>Creates refund for transfer object.</summary>
        /// <param name="transferId">Transfer identifier.</param>
        /// <param name="refund">Refund object to create.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public Refund CreateRefund(String transferId, Refund refund)
        {
            return this.CreateObject<Refund>("transfers_createrefunds", refund, transferId);
        }

        /// <summary>Gets refund for transfer object.</summary>
        /// <param name="transferId">Transfer identifier.</param>
        /// <returns>Refund entity instance returned from API.</returns>
        public Refund GetRefund(String transferId)
        {
            return this.GetObject<Refund>("transfers_getrefunds", transferId);
        }
    }
}
