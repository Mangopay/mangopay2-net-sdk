using System;
using System.Collections.Generic;
using System.Text;

namespace MangoPay.SDK.Entities.POST
{
    public class RecurringPayInMITPostDTO : EntityPostBase
    {
        /// <summary>
        /// The recurring's ID
        /// </summary>
        public string RecurringPayinRegistrationId { get; set; }

        /// <summary>
        /// Amount of the subsequent payment. If this field is empty we will take the amount entered in the NextTransactionDebitedFunds of the Recurring PayIn Registration. An amount must be transmitted during either registration or pay-in (if it’s different from the registration one).
        /// </summary>
        public Money DebitedFunds { get; set; }

        /// <summary>
        /// Amount of the subsequent fees. If this field is empty we will take the amount entered in the NextTransactionFees of the Recurring PayIn Registration. An amount must be transmitted during either registration or pay-in.
        /// </summary>
        public Money Fees { get; set; }

        /// <summary>
        /// A custom description to appear on the user's bank statement. It can be up to 10 characters long, and can only include alphanumeric characters or spaces. See here for important info. Note that each bank handles this information differently, some show less or no information.
        /// </summary>
        public string StatementDescriptor { get; set; }
    }
}
