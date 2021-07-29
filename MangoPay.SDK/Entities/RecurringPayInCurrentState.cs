namespace MangoPay.SDK.Entities
{
    public class RecurringPayInCurrentState
    {
        public int? PayinsLinked { get; set; }

        public Money CumulatedDebitedAmount { get; set; }

        public Money CumulatedFeesAmount { get; set; }

        public string LastPayinId { get; set; }
    }
}
