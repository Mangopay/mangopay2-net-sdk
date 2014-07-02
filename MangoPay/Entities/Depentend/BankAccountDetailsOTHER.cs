using MangoPay.Core;
using MangoPay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class represents OTHER type of bank account.</summary>
    public class BankAccountDetailsOTHER : Dto, IBankAccountDetails
    {
        /// <summary>Type.</summary>
        public String Type;

        /// <summary>The Country associate to the BankAccount. 
        /// ISO 3166-1 alpha-2 format is expected.</summary>
        public String Country;

        /// <summary>Valid BIC format.</summary>
        public String BIC;

        /// <summary>Account number.</summary>
        public String AccountNumber;
    }
}
