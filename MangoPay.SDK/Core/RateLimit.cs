namespace MangoPay.SDK.Core
{
    public class RateLimit
    {
        public int IntervalMinutes { get; set; }

        public int CallsMade { get; set; }

        public int CallsRemaining { get; set; }

        public long ResetTimeSeconds { get; set; }
    }
}