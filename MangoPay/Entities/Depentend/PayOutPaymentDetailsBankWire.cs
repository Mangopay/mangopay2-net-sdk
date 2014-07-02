using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class representing the BankWire type for mean of payment in PayOut entity.</summary>
    public class PayOutPaymentDetailsBankWire : Dto, IPayOutPaymentDetails
    {
        /// <summary>Bank account identifier.</summary>
        public String BankAccountId;

        /// <summary>Communication.</summary>
        public String Communication;
    }
}
