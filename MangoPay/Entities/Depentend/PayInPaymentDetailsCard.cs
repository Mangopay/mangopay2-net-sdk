using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class representing the Card type for mean of payment in PayIn entity.</summary>
    public class PayInPaymentDetailsCard : Dto, IPayInPaymentDetails
    {
        /// <summary>Card type { CB_VISA_MASTERCARD, AMEX }.</summary>
        public String CardType;

        /// <summary>Card identifier.</summary>
        public String CardId;
    }
}
