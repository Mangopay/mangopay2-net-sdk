using MangoPay.Core;
using MangoPay.Core.Interfaces;
using MangoPay.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities.Dependend
{
    /// <summary>Class representing the BankWire type for mean of payment in PayIn entity.</summary>
    public class PayInPaymentDetailsBankWire : Dto, IPayInPaymentDetails
    {
        /// <summary>Declared debited funds.</summary>
        public Money DeclaredDebitedFunds;

        /// <summary>Declared fees.</summary>
        public Money DeclaredFees;

        /// <summary>Bank account details.</summary>
        public BankAccount BankAccount;

        /// <summary>Wire reference.</summary>
        public String WireReference;

        /// <summary>Gets map which property is an object and what type of object.</summary>
        /// <returns>Collection of field name-field type pairs.</returns>
        public override Dictionary<String, Type> GetSubObjects()
        {
            Dictionary<String, Type> result = new Dictionary<String, Type>();

            result.Add("DeclaredDebitedFunds", typeof(Money));
            result.Add("DeclaredFees", typeof(Money));
            result.Add("BankAccount", typeof(BankAccount));

            return result;
        }
    }
}
