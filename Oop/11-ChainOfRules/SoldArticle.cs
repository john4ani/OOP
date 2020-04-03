

using Oop._8_Null;
using Oop._9_OptionalObjects;
using Oop.Common;
using System;

namespace Oop._11_ChainOfRules
{
    class SoldArticle
    {
        public IWarranty MoneyBackGuatrantee { get; private set; }
        public IWarranty NotOperationalWarranty { get; }
        public IWarranty CircutryWarranty { get; private set; }

        private Option<Part> Circuitry { get; set; } = Option<Part>.None();

        //public bool IsOperational { get; private set; }
        //public bool IsCircuitryOperational { get; private set; }
        //public bool IsVisiblyDamaged { get; private set; }

        private IWarrantyRules WarrantyRules { get; }

        public SoldArticle(IWarranty moneyBackGuatrantee, IWarranty expressWarranty,
            IWarrantyRulesFactory factory)
        {
            if (moneyBackGuatrantee == null)
                throw new ArgumentNullException(nameof(moneyBackGuatrantee));
            if (expressWarranty == null)
                throw new ArgumentNullException(nameof(expressWarranty));

            MoneyBackGuatrantee = moneyBackGuatrantee;
            NotOperationalWarranty = expressWarranty;
            CircutryWarranty = VoidWarranty.Instance;

            //IsOperational = true;
            WarrantyRules = factory.Create(
                ClaimMoneyBack, ClaimNotOperationalWarranty, ClaimCircuitryWarranty);
        }

        private void ClaimMoneyBack(Action action)
        {
            MoneyBackGuatrantee.Claim(DateTime.Now,action);
        }

        private void ClaimNotOperationalWarranty (Action action)
        {
            NotOperationalWarranty.Claim(DateTime.Now, action);
        }

        private void ClaimCircuitryWarranty(Action action)
        {
            Circuitry.Do(c => CircutryWarranty.Claim(c.DefectDetectedOn, action));
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            CircutryWarranty = extendedWarranty;
            //IsCircuitryOperational = true;
            WarrantyRules.CircuitryOperational();

        }

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            //IsCircuitryOperational = false;
            WarrantyRules.CircuitryFailed();
        }

        public void VisibleDamaged()
        {
            //MoneyBackGuatrantee = VoidWarranty.Instance;
            WarrantyRules.VisibilyDamaged();
        }

        public void NotOperational()
        {
            //IsOperational = false;            
            WarrantyRules.NotOperational();
        }

        public void Repaired()
        {
            //IsOperational = true;
            WarrantyRules.Operational();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            //bool moneyReturned = false;
            //bool isAroundChristmas = IsAroundChristmas();

            //if (isAroundChristmas)
            //{
            //    MoneyBackGuatrantee.Claim(DateTime.Now, () =>
            //    {
            //        moneyReturned = true;
            //        onValidClaim();
            //    });
            //}

            //if (!moneyReturned && !IsOperational)
            //    NotOperationalWarranty.Claim(DateTime.Now, onValidClaim);
            //else if (!moneyReturned && !IsCircuitryOperational)
            //    Circuitry.Do(c => CircuitryWarranty.Claim(c.DefectDetectedOn, onValidClaim));
            //else if (!isAroundChristmas && !IsVisiblyDamaged)
            //    MoneyBackGuatrantee.Claim(DateTime.Now, onValidClaim);

            WarrantyRules.Claim(onValidClaim);
        }

        private bool IsAroundChristmas()
        {
            throw new NotImplementedException();
        }
    }
}
