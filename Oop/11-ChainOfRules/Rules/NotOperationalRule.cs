

using System;

namespace Oop._11_ChainOfRules.Rules
{
    class NotOperationalRule : ChainedRule
    {
        //private bool IsOperational { get; set; } = true;
        private Action<Action> ClaimAction { get; }
        

        //public Action<Action> ClaimStrategy { get; private set; }

        public Action<Action> Claim { get; private set; }

        
        public NotOperationalRule(Action<Action> claimAction, IWarrantyRules next)
            :base(next)
        {
            ClaimAction = claimAction;
            Claim = Forward;
        }

        //public override void NotOperational()
        //{
        //    Claim = ClaimAction;
        //}

        //public override void Operational()
        //{
        //    Claim = Forward;
        //}

        protected override void HandleNotOperational()
        {
            Claim = ClaimAction;
        }

        protected override void HandleOperational()
        {
            Claim = Forward;
        }

        //public void Claim(Action onValidClaim)
        //{
        //    //if (!IsOperational)
        //    //    ClaimAction(onValidClaim);

        //    //if (IsOperational)
        //    //    Next.Claim(onValidClaim);
        //    //else
        //    //    ClaimAction(onValidClaim);

        //    ClaimStrategy(onValidClaim);
        //}


    }
}
