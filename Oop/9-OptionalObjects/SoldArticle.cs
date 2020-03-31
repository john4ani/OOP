
using Oop._8_Null;
using Oop.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop._9_OptionalObjects
{
    class SoldArticle
    {
        public IWarranty MoneyBackGuatrantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        public IWarranty NotOperationalWarranty { get;}

        //Step 1
        //private Part Circuitry { get; private set; }

        //Step 2
        //private List<Part> Circuitry { get; set; } = new List<Part>();

        //Step 3
        private Option<Part> Circuitry { get; set; } = Option<Part>.None();

        public IWarranty FailedCircuitryWarranty { get; private set; }
        public IWarranty CircuitryWarranty { get; set; }

        public SoldArticle(IWarranty moneyBackGuatrantee, IWarranty expressWarranty)
        {
            if (moneyBackGuatrantee == null)
                throw new ArgumentNullException(nameof(moneyBackGuatrantee));
            if (expressWarranty == null)
                throw new ArgumentNullException(nameof(expressWarranty));

            MoneyBackGuatrantee = moneyBackGuatrantee;
            ExpressWarranty = VoidWarranty.Instance;
            NotOperationalWarranty = expressWarranty;
            CircuitryWarranty = VoidWarranty.Instance;
        }

        public void VisibleDamaged()
        {
            MoneyBackGuatrantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            MoneyBackGuatrantee = VoidWarranty.Instance;
            ExpressWarranty = NotOperationalWarranty;
        }

        //public void CircuitryNotOperational(DateTime detectedOn)
        //{
        //    if (Circuitry != null)
        //    {
        //        Circuitry.MarkAsDefective(detectedOn);
        //        CircuitryWarranty = FailedCircuitryWarranty;
        //    }
        //}

        //public void CircuitryNotOperational(DateTime detectedOn)
        //{
        //    Circuitry.ForEach(circuitry =>
        //    {
        //        circuitry.MarkAsDefective(detectedOn);
        //        CircuitryWarranty = FailedCircuitryWarranty;
        //    });
        //}

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            Circuitry.ToList().ForEach(circuitry =>
            {
                circuitry.MarkAsDefective(detectedOn);
                CircuitryWarranty = FailedCircuitryWarranty;
            });
        }

        //public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        //{
        //    Circuitry = circuitry;
        //    FailedCircuitryWarranty = extendedWarranty;
        //}

        //public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        //{
        //    Circuitry = new List<Part> { circuitry };
        //    FailedCircuitryWarranty = extendedWarranty;
        //}

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            FailedCircuitryWarranty = extendedWarranty;
        }

        //public void ClaimCircuitryWarranty(Action onValidClaim)
        //{
        //    if (Circuitry != null)
        //    {
        //        CircuitryWarranty.Claim(Circuitry.DefectDetectedOn, onValidClaim);
        //    }
        //}

        //public void ClaimCircuitryWarranty(Action onValidClaim)
        //{
        //    Circuitry.ForEach(circuitry => CircuitryWarranty.Claim(circuitry.DefectDetectedOn, onValidClaim));            
        //}

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            Circuitry.ToList().ForEach(circuitry => CircuitryWarranty.Claim(circuitry.DefectDetectedOn, onValidClaim));
        }
    }
}
