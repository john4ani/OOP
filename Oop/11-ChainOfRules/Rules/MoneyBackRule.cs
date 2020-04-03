
using System;

namespace Oop._11_ChainOfRules.Rules
{
    class MoneyBackRule : ChainedRule
    {
        private Action<Action> ClaimAction { get; }

        public MoneyBackRule(Action<Action> claimAction, IWarrantyRules next)
            : base(next)
        {
            ClaimAction = claimAction;            
        }

        protected override void HandleVisiblyDamaged()
        {
            Claim = Forward;
        }

        protected override void HandleNotOperational()
        {
            Claim = Forward;
        }

        protected override void HandleCircuitryFailed()
        {
            Claim = Forward;
        }
    }
}
