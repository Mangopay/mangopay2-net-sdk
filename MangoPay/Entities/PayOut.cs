using MangoPay.Core;
using MangoPay.Core.Interfaces;
using MangoPay.Entities.Dependend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoPay.Entities
{
    /// <summary>PayOut entity.</summary>
    public class PayOut : Transaction
    {
        /// <summary>Debited wallet identifier.</summary>
        public String DebitedWalletId;

        /// <summary>PaymentType { BANK_WIRE, MERCHANT_EXPENSE, AMAZON_GIFTCARD }.</summary>
        public String PaymentType;

        /// <summary>One of IPayOutPaymentDetails implementations, depending on PaymentType.</summary>
        public IPayOutPaymentDetails MeanOfPaymentDetails;

        /// <summary>Gets the structure that maps which property depends on other property.</summary>
        /// <returns></returns>
        public override Dictionary<string, Dictionary<string, Dictionary<string, Type>>> GetDependentObjects()
        {
            return new Dictionary<string, Dictionary<string, Dictionary<string, Type>>>
            {
                { "PaymentType", new Dictionary<string, Dictionary<string, Type>> 
                    {
                        { "BANK_WIRE", new Dictionary<string, Type> 
                            {
                                { "MeanOfPaymentDetails", typeof(PayOutPaymentDetailsBankWire) }
                            }
                        },
                        // ...and more in future...
                    }
                }
            };
        }

        /// <summary>Gets the collection of read-only fields names.</summary>
        /// <returns>List of field names.</returns>
        public override List<String> GetReadOnlyProperties()
        {
            List<String> result = base.GetReadOnlyProperties();

            result.Add("PaymentType");

            return result;
        }
    }
}
