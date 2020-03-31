using System;


namespace Oop._8_Null
{
    class TimeLimitedWarranty : IWarranty
    {
        private DateTime DateIssued { get; set; }
        private TimeSpan Duration { get; set; }

        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            DateIssued = dateIssued;
            Duration = duration;
        }        

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate))
                return;
            onValidClaim();
        }

        private bool IsValidOn(DateTime date) =>
            date.Date >= DateIssued && date.Date < DateIssued + Duration;
    }
}
