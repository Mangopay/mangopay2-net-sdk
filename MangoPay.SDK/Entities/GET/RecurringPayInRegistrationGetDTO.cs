namespace MangoPay.SDK.Entities.GET
{
    public class RecurringPayInRegistrationGetDTO : RecurringPayInRegistrationDTO
    {
        public bool Migration { get; set; }

        public RecurringPayInCurrentState CurrentState { get; set; }
    }
}
