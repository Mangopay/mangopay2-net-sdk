using System;

namespace MangoPay.SDK.Entities
{
    public class PaymentData
    {
        /// <summary> Id of the apple payment transaction </summary>
        public string TransactionId;
        /// <summary> Network card used for the transaction </summary>
        public string Network;
        /// <summary> Data block containing payment information </summary>
        public string TokenData;

        public PaymentData()
        {
                
        }

        public PaymentData(string transactionId, string network, string tokenData)
        {
            TransactionId = transactionId;
            Network = network;
            TokenData = tokenData;
        }
    }
}