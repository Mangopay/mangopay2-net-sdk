using MangoPay.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>KYC document entity.</summary>
    public class KycDocument : EntityBase
    {
        /// <summary>Possible values: { IDENTITY_PROOF, REGISTRATION_PROOF, ARTICLES_OF_ASSOCIATION, SHAREHOLDER_DECLARATION, ADDRESS_PROOF }.</summary>
        public String Type;

        /// <summary>Possible values: { CREATED, VALIDATION_ASKED, VALIDATED, REFUSED }.</summary>
        public String Status;

        /// <summary>Refused reason type.</summary>
        public String RefusedReasonType;

        /// <summary>Refused reason message.</summary>
        public String RefusedReasonMessage;
    }
}
