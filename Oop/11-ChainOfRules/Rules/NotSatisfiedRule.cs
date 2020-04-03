using System;

namespace Oop._11_ChainOfRules.Rules
{
    class NotSatisfiedRule : IWarrantyRules
    {
        public Action<Action> Claim => (action) => { };

        public void CircuitryFailed() { }

        public void CircuitryOperational() { }

        public void NotOperational() { }

        public void Operational() { }

        public void VisibilyDamaged() { }
    }
}
