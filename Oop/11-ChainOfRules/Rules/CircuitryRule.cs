
using System;

namespace Oop._11_ChainOfRules.Rules
{
    class CircuitryRule : ChainedRule
    {
        private Action<Action> ClaimAction { get; }

        public CircuitryRule(Action<Action> claimAction, IWarrantyRules next)
            : base(next)
        {
            ClaimAction = claimAction;
            Claim = Forward;
        }

        protected override void HandleCircuitryFailed()
        {
            Claim = ClaimAction;
        }

        protected override void HandleCircuitryOperational()
        {
            Claim = Forward;
        }
    }
}
