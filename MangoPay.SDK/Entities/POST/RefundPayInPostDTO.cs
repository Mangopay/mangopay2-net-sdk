using MangoPay.SDK.Core;
using MangoPay.SDK.Core.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace MangoPay.SDK.Entities.POST
{
    /// <summary>Refund for PayIn POST entity.</summary>
    public class RefundPayInPostDTO : EntityPostBase
    {
        public RefundPayInPostDTO(string authorId)
        {
            AuthorId = authorId;
        }

        public RefundPayInPostDTO(string authorId, Money fees, Money debitedFunds, string reference = null,
            string statementDescriptor = null)
        {
            AuthorId = authorId;
            Fees = fees;
            DebitedFunds = debitedFunds;
            Reference = reference;
            StatementDescriptor = statementDescriptor;
        }

        /// <summary>Author identifier.</summary>
        public string AuthorId { get; set; }

        /// <summary>Debited funds.</summary>
        public Money DebitedFunds { get; set; }

        /// <summary>Fees.</summary>
        public Money Fees { get; set; }
        
        public string Reference { get; set; }
        
        /// <summary>
        /// Custom description to appear on the user’s bank statement along with the platform name.
        /// Note that a particular bank may show more or less information.
        /// </summary>
        public string StatementDescriptor { get; set; }
    }
}
