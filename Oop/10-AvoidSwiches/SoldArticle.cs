
using Oop._8_Null;
using Oop._9_OptionalObjects;
using Oop.Common;
using System;
using System.Collections.Generic;

namespace Oop._10_AvoidSwiches
{
    class SoldArticle
    {
        public IWarranty MoneyBackGuatrantee { get; private set; }
        public IWarranty NotOperationalWarranty { get;}
        public IWarranty CircuitryWarranty { get; set; }

        private Option<Part> Circuitry { get; set; } = Option<Part>.None();

        private DeviceStatus OperationalStatus { get; set; }

        private IReadOnlyDictionary<DeviceStatus, Action<Action>> WarrantyMap { get; }

        public SoldArticle(IWarranty moneyBackGuatrantee, IWarranty expressWarranty,
            IWarranryMapFactory rulesFactory)
        {
            if (moneyBackGuatrantee == null)
                throw new ArgumentNullException(nameof(moneyBackGuatrantee));
            if (expressWarranty == null)
                throw new ArgumentNullException(nameof(expressWarranty));

            MoneyBackGuatrantee = moneyBackGuatrantee;
            NotOperationalWarranty = expressWarranty;
            CircuitryWarranty = VoidWarranty.Instance;

            OperationalStatus = DeviceStatus.AllFine();

            //WarrantyMap = WarrantyRules.GetCommonRule(
            //    ClaimMoneyBack, ClaimNotOperationalWarranty, ClaimCircuitryWarranty);

            WarrantyMap = rulesFactory.Create(ClaimMoneyBack, ClaimNotOperationalWarranty, ClaimCircuitryWarranty);
        }            

        private void ClaimCircuitryWarranty(Action obj)
        {
            throw new NotImplementedException();
        }

        private void ClaimNotOperationalWarranty(Action obj)
        {
            throw new NotImplementedException();
        }

        private void ClaimMoneyBack(Action obj)
        {
            throw new NotImplementedException();
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            CircuitryWarranty = extendedWarranty;
            OperationalStatus = OperationalStatus.CircuitryReplaced();
        }

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            Circuitry.Do(C => 
            {
                C.MarkAsDefective(detectedOn);
                OperationalStatus = OperationalStatus.CircuitryFailed();
            });
        }

        public void VisibleDamaged()
        {
            OperationalStatus = OperationalStatus.WithVisibleDamage();
        }

        public void NotOperational()
        {
            OperationalStatus = OperationalStatus.NotOperational();
        }

        public void Repaired()
        {
            OperationalStatus = OperationalStatus.Repaired(); ;
        }

        //public void ClaimWarranty(Action onValidClaim)
        //{
        //    switch (OperationalStatus)
        //    {
        //        case DeviceStatus.AllFine:
        //            MoneyBackGuatrantee.Claim(DateTime.Now, onValidClaim);
        //            break;
        //        case DeviceStatus.NotOperational:
        //        case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged:
        //        case DeviceStatus.NotOperational | DeviceStatus.CircuitryFailed:
        //        case DeviceStatus.NotOperational | DeviceStatus.VisiblyDamaged | DeviceStatus.CircuitryFailed:
        //            NotOperationalWarranty.Claim(DateTime.Now, onValidClaim);
        //            break;
        //        case DeviceStatus.VisiblyDamaged:
        //            break;                

        //        case DeviceStatus.CircuitryFailed:
        //        case DeviceStatus.VisiblyDamaged | DeviceStatus.CircuitryFailed:
        //            Circuitry.Do(c => CircuitryWarranty.Claim(c.DefectDetectedOn, onValidClaim));
        //            break;               

        //    }
        //}        

        public void ClaimWarranty(Action onValidClaim)
        {
            WarrantyMap[OperationalStatus].Invoke(onValidClaim);
        }
    }
}
