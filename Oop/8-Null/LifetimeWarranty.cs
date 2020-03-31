using System;

namespace Oop._8_Null
{
    class LifetimeWarranty : IWarranty
    {
        private DateTime IssuingDate { get; }

        public LifetimeWarranty(DateTime issuingDate)
        {
            IssuingDate = issuingDate;
        }       

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate))
                return;
            onValidClaim();
        }

        private bool IsValidOn(DateTime date) =>
           date.Date >= IssuingDate;
    }
}
