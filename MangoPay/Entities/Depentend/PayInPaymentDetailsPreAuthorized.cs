using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class representing the PreAuthorized type for execution option in PayIn entity.</summary>
    public class PayInPaymentDetailsPreAuthorized : Dto, IPayInPaymentDetails
    {
        /// <summary>Pre-authorization identifier.</summary>
        public String PreauthorizationId;
    }
}
