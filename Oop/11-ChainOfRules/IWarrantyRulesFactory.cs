using System;

namespace Oop._11_ChainOfRules
{
    public interface IWarrantyRulesFactory
    {
        IWarrantyRules Create(Action<Action> claimMoneyBack, 
                              Action<Action> claimNotOperationalWarranty, 
                              Action<Action> claimCircuitryWarranty);
    }
}