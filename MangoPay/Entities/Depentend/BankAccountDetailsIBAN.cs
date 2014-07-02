using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class represents IBAN type of bank account.</summary>
    public class BankAccountDetailsIBAN : Dto, IBankAccountDetails
    {
        /// <summary>IBAN number.</summary>
        public string IBAN;

        /// <summary>BIC.</summary>
        public string BIC;
    }
}
