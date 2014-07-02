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
    /// <summary>PayIn entity.</summary>
    public class PayIn : Transaction
    {
        /// <summary>Credited wallet identifier.</summary>
        public String CreditedWalletId;

        /// <summary>PaymentType { CARD, BANK_WIRE, AUTOMATIC_DEBIT, DIRECT_DEBIT }.</summary>
        public String PaymentType;

        /// <summary>One of PayInPaymentDetails implementations, depending on PaymentType.</summary>
        public IPayInPaymentDetails PaymentDetails;

        /// <summary>ExecutionType { WEB, TOKEN, DIRECT, PREAUTHORIZED, RECURRING_ORDER_EXECUTION }.</summary>
        public String ExecutionType;

        /// <summary>One of PayInExecutionDetails implementations, depending on ExecutionType.</summary>
        public IPayInExecutionDetails ExecutionDetails;

        /// <summary>Gets the structure that maps which property depends on other property.</summary>
        /// <returns></returns>
        public override Dictionary<string, Dictionary<string, Dictionary<string, Type>>> GetDependentObjects()
        {
            return new Dictionary<string, Dictionary<string, Dictionary<string, Type>>>
            {
                { "PaymentType", new Dictionary<string, Dictionary<string, Type>> 
                    {
                        { "CARD", new Dictionary<string, Type> 
                            {
                                { "PaymentDetails", typeof(PayInPaymentDetailsCard) }
                            }
                        },
                        { "PREAUTHORIZED", new Dictionary<string, Type> 
                            {
                                { "PaymentDetails", typeof(PayInPaymentDetailsPreAuthorized) }
                            }
                        },
                        { "BANK_WIRE", new Dictionary<string, Type> 
                            {
                                { "PaymentDetails", typeof(PayInPaymentDetailsBankWire) }
                            }
                        },
                        // ...and more in future...
                    }
                },
                { "ExecutionType", new Dictionary<string, Dictionary<string, Type>> 
                    {
                        { "WEB", new Dictionary<string, Type> 
                            {
                                { "ExecutionDetails", typeof(PayInExecutionDetailsWeb) }
                            }
                        },
                        { "DIRECT", new Dictionary<string, Type> 
                            {
                                { "ExecutionDetails", typeof(PayInExecutionDetailsDirect) }
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
            result.Add("ExecutionType");

            return result;
        }
    }
}
