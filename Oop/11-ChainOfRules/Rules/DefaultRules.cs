using System;

namespace Oop._11_ChainOfRules.Rules
{
    class DefaultRules : IWarrantyRulesFactory
    {
        public IWarrantyRules Create(Action<Action> claimMoneyBack,
                                     Action<Action> claimNotOperationalWarranty,
                                     Action<Action> claimCircuitryWarranty) =>
            new NotOperationalRule(claimNotOperationalWarranty,
                new CircuitryRule(claimCircuitryWarranty,
                    new MoneyBackRule(claimMoneyBack, new NotSatisfiedRule())));
    }
}
